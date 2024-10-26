using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InPatientWebAPI
{
    public partial class Inpatient : System.Web.UI.Page
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data")
        };

        private static List<CMSData> _cmsDataList;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    _cmsDataList = await FetchDataFromApiAsync();
                    await BindDropdownsAsync();
                }
                catch (Exception ex)
                {
                    lblTotalRecords.Text = $"Error during Page Load: {ex.Message}";
                    lblTotalRecords.Visible = true;
                }
            }
        }

        private static async Task<List<CMSData>> FetchDataFromApiAsync()
        {
            List<CMSData> data = new List<CMSData>();
            int size = 5000;
            int offset = 0;

            while (true)
            {
                HttpResponseMessage response = await _client.GetAsync($"data?size={size}&offset={offset}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var pageData = JsonConvert.DeserializeObject<List<CMSData>>(responseData);

                    if (!pageData.Any()) break; // Exit loop if no more data

                    data.AddRange(pageData);
                    offset += size;
                }
                else
                {
                    throw new Exception($"API request failed. Status Code: {response.StatusCode}");
                }
            }

            return data;
        }

        private async Task BindDropdownsAsync()
        {
            await BindDropdownAsync(ddlDRG, data => data.DRG_Desc);
            await BindDropdownAsync(ddlProviderName, data => data.Rndrng_Prvdr_Org_Name);
            await BindDropdownAsync(ddlState, data => data.Rndrng_Prvdr_State_Abrvtn);
        }

        private Task BindDropdownAsync(DropDownList ddl, Func<CMSData, string> selector)
        {
            var distinctValues = _cmsDataList.Select(selector).Distinct().ToList();
            ddl.DataSource = distinctValues;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Please Select", ""));
            return Task.CompletedTask;
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            try
            {
                List<CMSData> filteredData = null;

                if (RadioButtonList1.SelectedValue == "Hospital-wise")
                {
                    filteredData = _cmsDataList
                        .Where(data => data.DRG_Desc == ddlDRG.SelectedValue &&
                                        data.Rndrng_Prvdr_Org_Name == ddlProviderName.SelectedValue)
                        .ToList();
                }
                else if (RadioButtonList1.SelectedValue == "State-wise")
                {
                    filteredData = _cmsDataList
                        .Where(data => data.DRG_Desc == ddlDRG.SelectedValue &&
                                        data.Rndrng_Prvdr_State_Abrvtn == ddlState.SelectedValue)
                        .ToList();
                }

                if (filteredData != null)
                {
                    gvResults.DataSource = filteredData;
                    gvResults.DataBind();

                    totalRecords();

                    TotalRecords.Text = filteredData.Count.ToString();
                    lblTotalRecords.Visible = true;
                }
                else
                {
                    lblTotalRecords.Text = "No data found.";
                    lblTotalRecords.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblTotalRecords.Text = $"Error during search: {ex.Message}";
                lblTotalRecords.Visible = true;
            }
        }

        public void totalRecords()
        {
            // Display total records count
            int totalRows = gvResults.Rows.Count;
            TotalRecords.Text = totalRows.ToString();
        }

        protected void ddlDRG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedValue == "Hospital-wise")
                {
                    var providerName = _cmsDataList
                        .Where(data => data.DRG_Desc == ddlDRG.SelectedValue)
                        .Select(data => data.Rndrng_Prvdr_Org_Name)
                        .Distinct()
                        .ToList();

                    ddlProviderName.DataSource = providerName;
                    ddlProviderName.DataBind();
                    ddlProviderName.Items.Insert(0, new ListItem("Please Select", ""));
                }
                else if (RadioButtonList1.SelectedValue == "State-wise")
                {
                    var stateAbbreviation = _cmsDataList
                        .Where(data => data.DRG_Desc == ddlDRG.SelectedValue)
                        .Select(data => data.Rndrng_Prvdr_State_Abrvtn)
                        .Distinct()
                        .ToList();

                    ddlState.DataSource = stateAbbreviation;
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("Please Select", ""));
                }
            }
            catch (Exception ex)
            {
                lblTotalRecords.Text = $"Error during dropdown selection: {ex.Message}";
                lblTotalRecords.Visible = true;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Hospital-wise")
            {
                lblProviderName.Visible = true;
                ddlProviderName.Visible = true;
                lblState.Visible = false;
                ddlState.Visible = false;
            }
            else if (RadioButtonList1.SelectedValue == "State-wise")
            {
                lblState.Visible = true;
                ddlState.Visible = true;
                lblProviderName.Visible = false;
                ddlProviderName.Visible = false;
            }
            else
            {
                lblProviderName.Visible = false;
                ddlProviderName.Visible = false;
                lblState.Visible = false;
                ddlState.Visible = false;
            }
        }
    }

    public class CMSData
    {
        public string DRG_Desc { get; set; }
        public string Rndrng_Prvdr_Org_Name { get; set; }
        public string Rndrng_Prvdr_State_Abrvtn { get; set; }
        public string DRG_Cd { get; set; }
        public string Rndrng_Prvdr_St { get; set; }
        public string Rndrng_Prvdr_State_FIPS { get; set; }
        public string Rndrng_Prvdr_Zip5 { get; set; }
        public string Rndrng_Prvdr_RUCA { get; set; }
        public string Rndrng_Prvdr_RUCA_Desc { get; set; }
        public string Rndrng_Prvdr_City { get; set; }
        public double Avg_Submtd_Cvrd_Chrg { get; set; }
        public double Avg_Mdcr_Pymt_Amt { get; set; }
        public double Avg_Tot_Pymt_Amt { get; set; }
    }
}


#region MyRegion
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.UI.WebControls;

//namespace InPatientWebapplication
//{
//    public partial class WebForm1 : System.Web.UI.Page
//    {
//        protected async void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                // await GetAllDataAsync();
//                await ddlDRGBind();
//                //await ddlProvider();
//                //await ddlStateBind();
//            }
//        }

//        private HttpClient _client;
//        //public void InpatientWebapplication()
//        //{
//        //    _client = new HttpClient();
//        //    _client.BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");
//        //}
//        public async Task<List<CMSData>> GetAllDataAsync()
//        {
//            //// Ensure _client is initialized
//            //if (_client == null)
//            //{
//            //    InpatientWebapplication();
//            //}

//            List<CMSData> data = new List<CMSData>();
//            int size = 5000;
//            int offSet = 0;

//            while (data.Count < 145742)
//            {
//                _client = new HttpClient();
//                _client.BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");
//                HttpResponseMessage response = await _client.GetAsync($"data?size={size}&offset={offSet}");

//                if (response.IsSuccessStatusCode)
//                {
//                    // Deserialize JSON response to List<CMSData>
//                    List<CMSData> dataPage = await response.Content.ReadAsAsync<List<CMSData>>();
//                    data.AddRange(dataPage);
//                    offSet = data.Count;
//                }
//            }
//            return data;
//        }
//        public async Task<List<CMSData>> GetAllCMSData()
//        {
//            List<CMSData> cmsDataList = new List<CMSData>();
//            using (HttpClient _client = new HttpClient())
//            {
//                HttpResponseMessage response = await _client.GetAsync("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");

//                if (response.IsSuccessStatusCode)
//                {
//                    string json = await response.Content.ReadAsStringAsync();
//                    cmsDataList = JsonConvert.DeserializeObject<List<CMSData>>(json);
//                }
//                else
//                {
//                    // Handle unsuccessful response
//                    throw new Exception($"Failed to retrieve data from API. Status Code: {response.StatusCode}");
//                }
//            }
//            return cmsDataList;
//        }
//        public async Task ddlDRGBind()
//        {
//            try
//            {
//                List<CMSData> cmsDataList = await GetAllDataAsync();
//                // Bind DRG dropdown
//                ddlDRG.DataSource = cmsDataList.Select(data => data.DRG_Desc).Distinct().ToList();
//                ddlDRG.DataBind();
//                ddlDRG.Items.Insert(0, new ListItem("Please Select", ""));
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        public async Task ddlProviderBind()
//        {
//            try
//            {
//                List<CMSData> cmsDataList = await GetAllDataAsync();
//                // Bind Provider dropdown
//                ddlDRG.DataSource = cmsDataList.Select(data => data.Rndrng_Prvdr_Org_Name).Distinct().ToList();
//                ddlDRG.DataBind();
//                ddlDRG.Items.Insert(0, new ListItem("Please Select", ""));
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        public async Task ddlStateBind()
//        {
//            try
//            {
//                List<CMSData> cmsDataList = await GetAllDataAsync();
//                // Bind State dropdown
//                ddlDRG.DataSource = cmsDataList.Select(data => data.Rndrng_Prvdr_State_Abrvtn).Distinct().ToList();
//                ddlDRG.DataBind();
//                ddlDRG.Items.Insert(0, new ListItem("Please Select", ""));
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        protected async void btnSearch_Click1(object sender, EventArgs e)
//        {
//            if (RadioButtonList1.SelectedValue == "Hospital-wise")
//            {
//                await searchbyProvider();
//            }
//            else if (RadioButtonList1.SelectedValue == "State-wise")
//            {
//                await searchByState();
//            }
//        }
//        public async Task searchbyProvider()
//        {
//            try
//            {
//                // Create HttpClient instance
//                // using (HttpClient _client = new HttpClient())
//                {
//                    // Send GET request to the API
//                    //HttpResponseMessage response = await _client.GetAsync("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");

//                    //_client.BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");
//                    // HttpResponseMessage response = await _client.GetAsync($"https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data?size={size}&offset={offSet}");

//                    // Check if the response is successful
//                    //   if (response.IsSuccessStatusCode)
//                    {
//                        // Read response content as string
//                        // string json = await response.Content.ReadAsStringAsync();

//                        // Deserialize JSON to list of objects
//                        // List<CMSData> cmsDataList = JsonConvert.DeserializeObject<List<CMSData>>(json);

//                        List<CMSData> cmsDataList = await GetAllDataAsync();

//                        // Filter data based on selected values
//                        cmsDataList = cmsDataList.FindAll(data =>
//                            data.DRG_Desc == ddlDRG.SelectedValue &&
//                            data.Rndrng_Prvdr_Org_Name == ddlProviderName.SelectedValue);

//                        // Bind filtered data to GridView
//                        gvResults.DataSource = cmsDataList;
//                        gvResults.DataBind();

//                        totalRecords();

//                        // Display total records count
//                        TotalRecords.Text = cmsDataList.Count.ToString();
//                        lblTotalRecords.Visible = true;
//                    }
//                    //else
//                    //{
//                    //    // Handle unsuccessful response
//                    //    lblTotalRecords.Text = "Failed to retrieve data from API. Status Code: " + response.StatusCode;
//                    //    lblTotalRecords.Visible = true;
//                    //}
//                }
//            }
//            catch (HttpRequestException ex)
//            {
//                // Handle HTTP request exception
//                lblTotalRecords.Text = "HTTP Request Exception: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//            catch (Exception ex)
//            {
//                // Handle other exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        public async Task searchByState()
//        {
//            try
//            {
//                //string apiUrl = "https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data";
//                // Create HttpClient instance
//                // using (HttpClient _client = new HttpClient())
//                {
//                    // Send GET request to the API
//                    // HttpResponseMessage response = await _client.GetAsync("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");

//                    //_client.BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");
//                    //HttpResponseMessage response = await _client.GetAsync($"data?size={size}&offset={offSet}");

//                    //// Check if the response is successful
//                    //if (response.IsSuccessStatusCode)
//                    {
//                        // Read response content as string
//                        // string json = await response.Content.ReadAsStringAsync();

//                        // Deserialize JSON to list of objects
//                        // List<CMSData> cmsDataList = JsonConvert.DeserializeObject<List<CMSData>>(json);

//                        List<CMSData> cmsDataList = await GetAllDataAsync();

//                        // Filter data based on selected values
//                        cmsDataList = cmsDataList.FindAll(data =>
//                            data.DRG_Desc == ddlDRG.SelectedValue &&
//                            data.Rndrng_Prvdr_State_Abrvtn == ddlState.SelectedValue);

//                        // Bind filtered data to GridView
//                        gvResults.DataSource = cmsDataList;
//                        gvResults.DataBind();

//                        totalRecords();

//                        // Display total records count
//                        TotalRecords.Text = cmsDataList.Count.ToString();
//                        lblTotalRecords.Visible = true;
//                    }
//                    //else
//                    //{
//                    //    // Handle unsuccessful response
//                    //    lblTotalRecords.Text = "Failed to retrieve data from API. Status Code: " + response.StatusCode;
//                    //    lblTotalRecords.Visible = true;
//                    //}
//                }
//            }
//            catch (HttpRequestException ex)
//            {
//                // Handle HTTP request exception
//                lblTotalRecords.Text = "HTTP Request Exception: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//            catch (Exception ex)
//            {
//                // Handle other exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        public void totalRecords()
//        {
//            // Display total records count
//            int totalRows = gvResults.Rows.Count;
//            TotalRecords.Text = totalRows.ToString();
//        }
//        protected async void ddlDRG_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            try
//            {
//                List<CMSData> cmsDataList = await GetAllDataAsync();

//                if (RadioButtonList1.SelectedValue == "Hospital-wise")
//                {
//                    // Filter provider names based on selected DRG
//                    var providerName = cmsDataList
//                        .Where(data => data.DRG_Desc == ddlDRG.SelectedValue)
//                        .Select(data => data.Rndrng_Prvdr_Org_Name)
//                        .Distinct()
//                        .ToList();

//                    // Bind Provider dropdown
//                    ddlProviderName.DataSource = providerName;
//                    ddlProviderName.DataBind();
//                    ddlProviderName.Items.Insert(0, new ListItem("Please Select", ""));
//                }
//                else if (RadioButtonList1.SelectedValue == "State-wise")
//                {
//                    var stateAbbreviation = cmsDataList
//                           .Where(data => data.DRG_Desc == ddlDRG.SelectedValue)
//                           .Select(data => data.Rndrng_Prvdr_State_Abrvtn)
//                           .Distinct()
//                           .ToList();

//                    // Bind State dropdown
//                    ddlState.DataSource = stateAbbreviation;
//                    ddlState.DataBind();
//                    ddlState.Items.Insert(0, new ListItem("Please Select", ""));
//                }

//            }
//            catch (HttpRequestException ex)
//            {
//                // Handle HTTP request exception
//                lblTotalRecords.Text = "HTTP Request Exception: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//            catch (Exception ex)
//            {
//                // Handle other exceptions
//                lblTotalRecords.Text = "Error: " + ex.Message;
//                lblTotalRecords.Visible = true;
//            }
//        }
//        //protected async void ddlProviderName_SelectedIndexChanged(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        //string apiUrl = "https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data";
//        //        // Create HttpClient instance
//        //        //using (HttpClient _client = new HttpClient())
//        //        {
//        //            // Send GET request to the API asynchronously
//        //            // HttpResponseMessage response = await _client.GetAsync("_client.BaseAddress");

//        //            //_client.BaseAddress = new Uri("https://data.cms.gov/data-api/v1/dataset/690ddc6c-2767-4618-b277-420ffb2bf27c/data");
//        //            //HttpResponseMessage response = await _client.GetAsync($"data?size={size}&offset={offSet}");

//        //            //// Check if the response is successful
//        //            //if (response.IsSuccessStatusCode)
//        //            {
//        //                // Read response content as string
//        //                //  string json = await response.Content.ReadAsStringAsync();

//        //                // Deserialize JSON to list of objects
//        //                //  List<CMSData> cmsDataList = JsonConvert.DeserializeObject<List<CMSData>>(json);

//        //                List<CMSData> cmsDataList = await GetAllDataAsync();

//        //                // Filter state abbreviations based on selected provider name
//        //                var stateAbbreviation = cmsDataList
//        //                    .Where(data => data.Rndrng_Prvdr_Org_Name == ddlProviderName.SelectedValue)
//        //                    .Select(data => data.Rndrng_Prvdr_State_Abrvtn)
//        //                    .Distinct()
//        //                    .ToList();

//        //                // Bind State dropdown
//        //                ddlState.DataSource = stateAbbreviation;
//        //                ddlState.DataBind();
//        //                ddlState.Items.Insert(0, new ListItem("Please Select", ""));
//        //            }
//        //            //else
//        //            //{
//        //            //    // Handle unsuccessful response
//        //            //    lblTotalRecords.Text = "Failed to retrieve data from API. Status Code: " + response.StatusCode;
//        //            //    lblTotalRecords.Visible = true;
//        //            //}
//        //        }
//        //    }
//        //    catch (HttpRequestException ex)
//        //    {
//        //        // Handle HTTP request exception
//        //        lblTotalRecords.Text = "HTTP Request Exception: " + ex.Message;
//        //        lblTotalRecords.Visible = true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // Handle other exceptions
//        //        lblTotalRecords.Text = "Error: " + ex.Message;
//        //        lblTotalRecords.Visible = true;
//        //    }
//        //}
//        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (RadioButtonList1.SelectedValue == "Hospital-wise")
//            {
//                lblProviderName.Visible = true;
//                ddlProviderName.Visible = true;
//                // Bind Provider dropdown
//                //await ddlDRGBind();
//                //await ddlProviderBind();
//            }
//            else
//            {
//                lblProviderName.Visible = false;
//                ddlProviderName.Visible = false;
//            }
//            if (RadioButtonList1.SelectedValue == "State-wise")
//            {
//                lblState.Visible = true;
//                ddlState.Visible = true;
//                // Bind State dropdown
//                // await ddlDRGBind();
//                //await ddlStateBind();
//            }
//            else
//            {
//                lblState.Visible = false;
//                ddlState.Visible = false;
//            }
//        }
//    }
//    public class CMSData
//    {
//        // Define properties matching the JSON structure
//        public string DRG_Desc { get; set; }
//        public string Rndrng_Prvdr_Org_Name { get; set; }
//        public string Rndrng_Prvdr_State_Abrvtn { get; set; }
//        public string DRG_Cd { get; set; }
//        public string Rndrng_Prvdr_St { get; set; }
//        public string Rndrng_Prvdr_State_FIPS { get; set; }
//        public string Rndrng_Prvdr_Zip5 { get; set; }
//        public string Rndrng_Prvdr_RUCA { get; set; }
//        public string Rndrng_Prvdr_RUCA_Desc { get; set; }
//        public string Rndrng_Prvdr_City { get; set; }
//        public double Avg_Submtd_Cvrd_Chrg { get; set; }
//        public double Avg_Mdcr_Pymt_Amt { get; set; }
//        public double Avg_Tot_Pymt_Amt { get; set; }
//    }
//} 
#endregion