<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Inpatient.aspx.cs" Inherits="InPatientWebAPI.Inpatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Medicare Inpatient Utilization Data</title>

    <!-- Favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" type="image/x-icon" />

    <!-- Font awesome -->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Bootstrap -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- Slick slider -->
    <link rel="stylesheet" type="text/css" href="assets/css/slick.css" />
    <!-- Theme color -->
    <link id="switcher" href="assets/css/theme-color/default-theme.css" rel="stylesheet" />

    <!-- Main style sheet -->
    <link href="assets/css/style.css" rel="stylesheet" />


    <!-- Google Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,400italic,300,300italic,500,700' rel='stylesheet' type='text/css' />


    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>

            <!--START SCROLL TOP BUTTON -->
            <a class="scrollToTop" href="#">
                <i class="fa fa-angle-up"></i>
            </a>
            <!-- END SCROLL TOP BUTTON -->
            <!-- Start header  -->
            <header id="mu-header">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="mu-header-area">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <div class="mu-header-top-left">
                                            <div class="mu-top-email">
                                                <i class="fa fa-envelope"></i>
                                                <span>chavdadharmesh398@gmail.com</span>
                                            </div>
                                            <div class="mu-top-phone">
                                                <i class="fa fa-phone"></i>
                                                <span>+919313889768 </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <div class="mu-header-top-right">
                                            <nav>
                                                <ul class="mu-top-social-nav">
                                                    <li><a href="https://www.instagram.com/mr_dc_officiall/" target="_blank"><span class="fa fa-instagram"></span></a></li>
                                                    <li><a href="https://www.linkedin.com/in/dharmesh-chavda-940290201/" target="_blank"><span class="fa fa-linkedin"></span></a></li>
                                                    <li><a href="https://dharmeshchavdaportfolio.netlify.app/" target="_blank"><span class="fas fa-portfolio-icon"></span></a></li>
                                                    <li><a href="https://github.com/Dharmesh1609" target="_blank"><span class="bi bi-github"></span></a></li>
                                                    <%--<li><a href="#"><span class="fa fa-youtube"></span></a></li>--%>
                                                </ul>
                                            </nav>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <!-- End header  -->
            <!-- Start menu -->
            <section id="mu-menu">
                <nav class="navbar navbar-default" role="navigation">
                    <div class="container">
                        <div class="navbar-header">
                            <!-- FOR MOBILE VIEW COLLAPSED BUTTON -->
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <!-- LOGO -->
                            <!-- TEXT BASED LOGO -->
                            <%--<a class="navbar-brand" href="index.html"><i class="fa fa-university"></i><span>Varsity</span></a>--%>
                            <!-- IMG BASED LOGO  -->
                            <a class="navbar-brand" href="default.aspx">
                                <img src="assets/image/e2.png" alt="logo" style="margin-top: -10px;" /></a>
                        </div>
                        <br />
                        <div id="navbar" class="navbar-collapse collapse">
                            <ul id="top-menu" class="nav navbar-nav navbar-right main-nav">
                                <%--<li><a href="index.html">Home</a></li>
                                <li><a href="WhoWeAre.aspx">Who we are</a></li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Services <span class="fa fa-angle-down"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="MemberManagement.aspx">Member Management</a></li>
                                        <li><a href="SmartInteractiveAnalytics.aspx">Smart Interactive Analytics</a></li>
                                        <li><a href="CensusTracking.aspx">Census Tracking</a></li>
                                        <li><a href="CaseManagement.aspx">Case Management</a></li>
                                        <li><a href="DiseaseManagement.aspx">Disease Management</a></li>
                                        <li><a href="PopulationHealthManagement.aspx">Population Health Management</a></li>
                                        <li><a href="CareGap360.aspx">Care Gaps 360</a></li>
                                        <li><a href="ProviderManagement.aspx">Provider Management</a></li>
                                        <li><a href="RiskManagement.aspx">Risk Management</a></li>
                                    </ul>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Tools <span class="fa fa-angle-down"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="Articles.aspx">Articles</a></li>
                                        <li><a href="HealthTopics.aspx">Health Topics</a></li>
                                        <li><a href="#">Medicare Inpatient Utilization Data</a></li>
                                    </ul>
                                </li>
                                <li><a href="ContactUs.aspx">Contact</a></li>
                                <li><a href="CustomerLogin.aspx">Customer</a></li>
                                <%--<li><a href="#" id="mu-search-icon"><i class="fa fa-search"></i></a></li>--%>
                            </ul>
                        </div>
                        <!--/.nav-collapse -->
                    </div>
                </nav>
            </section>
            <!-- End menu -->
            <!-- Start search box -->
            <div id="mu-search">
                <div class="mu-search-area">
                    <button class="mu-search-close"><span class="fa fa-close"></span></button>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <form class="mu-search-form">
                                    <input type="search" placeholder="Type Your Keyword(s) & Hit Enter" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Remove the nested form and integrate its input field within the existing ASP.NET form --%>
            <%--<div id="mu-search">  
            <div class="mu-search-area">
                <button class="mu-search-close"><span class="fa fa-close"></span></button>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <input type="search" id="txtSearch" runat="server" placeholder="Type Your Keyword(s) & Hit Enter" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- End search box -->
            <!-- Page breadcrumb -->
            <section id="mu-page-breadcrumb">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mu-page-breadcrumb-area">
                                <h2>Medicare Inpatient Utilization Data</h2>
                                <ol class="breadcrumb">
                                    <li><a href="#">Home</a></li>
                                    <li><a href="#">Tools</a></li>
                                    <li class="active">Medicare Inpatient Utilization Data</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- End breadcrumb -->
            <!-- Start from Health Topic Search -->
            <div class="mu-title">

                <%--Search Functionality Start--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="text-align: center; margin-left: 380px; margin-top: 30px;">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="Hospital-wise">Hospital-wise</asp:ListItem>
                                <asp:ListItem Value="State-wise" style="margin-left: 10px!important;">State-wise</asp:ListItem>
                            </asp:RadioButtonList>

                            <div style="margin-top: -40px; margin-right: -60px; font-style: italic;">
                                <a href="http://www.cms.gov/Research-Statistics-Data-and-Systems/Statistics-Trends-and-Reports/Medicare-Provider-Charge-Data/Downloads/Inpatient_Methodology.pdf " style="font-size: 9px; text-decoration: underline;" target="_blank">Medicare Inpatient PUF Methodology</a>
                            </div>

                        </div>
                        <br />
                        <br />
                        <div style="text-align: center;">
                            <h6>DRG:&nbsp;<asp:DropDownList ID="ddlDRG" runat="server" CssClass="confirmddl" Width="250" OnSelectedIndexChanged="ddlDRG_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>&nbsp;
                                            <asp:Label ID="lblProviderName" runat="server" Text="Hospital:" Visible="false"></asp:Label>
                                &nbsp;<asp:DropDownList ID="ddlProviderName" runat="server" CssClass="confirmddl" Width="250" AutoPostBack="true" Visible="false">
                                </asp:DropDownList>&nbsp;
                                            <asp:Label ID="lblState" runat="server" Text="State:" Visible="false"></asp:Label>
                                &nbsp;<asp:DropDownList ID="ddlState" runat="server" CssClass="confirmddl" Width="65" AutoPostBack="true" Visible="false">
                                </asp:DropDownList>&nbsp;
                                               <%-- Zipcode:&nbsp;<asp:DropDownList ID="ddlZipcode" runat="server" CssClass="confirmddl" Width="80">
                                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click1" />
                                <%--<div style=" margin-top: -45px; margin-left:850px;">
                                            <a href="http://www.cms.gov/Research-Statistics-Data-and-Systems/Statistics-Trends-and-Reports/Medicare-Provider-Charge-Data/Downloads/Inpatient_Methodology.pdf " style="font-size: 10px;" target="_blank">Medicare Inpatient PUF Methodology</a>
                                            
                                        </div>--%><%--&nbsp; &nbsp;
                                            <a href="http://www.cms.gov/Research-Statistics-Data-and-Systems/Statistics-Trends-and-Reports/Medicare-Provider-Charge-Data/Downloads/Inpatient_Methodology.pdf " style="font-size: 10px;" target="_blank">Medicare Inpatient PUF Methodology</a>--%>
                            </h6>

                            <%--Total Number of Records Start--%>
                            <div style="font-size: 11px; text-align: left;">
                                <asp:Label ID="lblTotalRecords" runat="server" Text="Total Records:" Visible="false"></asp:Label>
                                <asp:Label ID="TotalRecords" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblSourceCMS" runat="server" Visible="false" Text="(CMS Inpatient Charge Data FY 2024.)" Font-Italic="true"></asp:Label>
                            </div>
                            <%--Total Number of Records End--%>
                            <br />
                            <%--GridView Start--%>
                            <div style="text-align: center;">
                                <asp:GridView ID="gvResults" runat="server" Font-Size="Smaller" AutoGenerateColumns="False" HorizontalAlign="Center" CssClass="th">

                                    <HeaderStyle HorizontalAlign="Center" BackColor="#DCDCDC" />
                                    <Columns>
                                        <asp:BoundField DataField="DRG_Desc" HeaderText="DRG Definition" SortExpression="DRGDefinition" />
                                        <%--<asp:BoundField DataField="ProviderName" HeaderText="Provider" SortExpression="ProviderName" />--%>
                                        <asp:TemplateField HeaderText="Provider">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Rndrng_Prvdr_Org_Name") %>' ToolTip='<%# Bind("Rndrng_Prvdr_City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Rndrng_Prvdr_Zip5" HeaderText="Zipcode" SortExpression="ProviderZipCode" />
                                        <asp:BoundField DataField="Rndrng_Prvdr_State_Abrvtn" HeaderText="State" SortExpression="ProviderState" />
                                        <asp:BoundField DataField="Avg_Submtd_Cvrd_Chrg" HeaderText="Average Covered Charges" SortExpression="AverageCoveredCharges" DataFormatString="{0:C2}" />
                                        <asp:BoundField DataField="Avg_Tot_Pymt_Amt" HeaderText="Average Total Payments" SortExpression="AverageTotalPayments" DataFormatString="{0:C2}" />
                                        <asp:BoundField DataField="Avg_Mdcr_Pymt_Amt" HeaderText="Average Medicare Payments" SortExpression="AverageMedicarePayments" DataFormatString="{0:C2}" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </div>
                            <%--GridView End--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%--Search Functionality End--%>
            </div>
            <!-- End from Health Topic Search -->

            <!-- Start footer -->
            <footer id="mu-footer">
                <!-- start footer top -->
                <div class="mu-footer-top">
                    <div class="container">
                        <div class="mu-footer-top-area">
                            <div class="row">
                                <%--<div class="col-lg-3 col-md-3 col-sm-3">
                                    <div class="mu-footer-widget">
                                        <h4>Information</h4>
                                        <ul>
                                            <li><a href="WhoWeAre.aspx">Who we are</a></li>
                                            <li><a href="MemberManagement.aspx">Services</a></li>
                                            <li><a href="Articles.aspx">Tools</a></li>
                                            <li><a href="CustomerLogin.aspx">Customer</a></li>
                                            <li><a href="ContactUs.aspx">Contact</a></li>
                                        </ul>
                                    </div>
                                </div>--%>
                                <div class="col-lg-3 col-md-3 col-sm-3">
                                    <div class="mu-footer-widget">
                                        <%--                                        <img alt="Location" src="assets/image/company.jpg" width="250" />--%>
                                        <div style="color: whitesmoke;">
                                            E-mail: <a href="#" style="color: whitesmoke;">chavdadharmesh398@gmail.com</a>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-lg-3 col-md-3 col-sm-3">
                                    <div class="mu-footer-widget">
                                        <a class="twitter-timeline" href="https://twitter.com/devalvshah" data-widget-id="527110570537803776">Tweets by @devalvshah</a>
                                        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-3">
                                    <div class="mu-footer-widget">
                                        <a class="twitter-timeline" href="https://twitter.com/eHealthcareReg" data-widget-id="533548876150493185">Tweets by @eHealthcareReg</a>
                                        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end footer top -->
                <!-- start footer bottom -->
                <div class="mu-footer-bottom">
                    <div class="container">
                        <div class="mu-footer-bottom-area">
                            <p>&copy; Dharmesh Chavda- All Rights Reserved.</p>
                        </div>
                    </div>
                </div>
                <!-- end footer bottom -->
            </footer>
            <!-- End footer -->
            <!-- jQuery library -->
            <script src="assets/js/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="assets/js/bootstrap.js"></script>
            <!-- Slick slider -->
            <script type="text/javascript" src="assets/js/slick.js"></script>
            <!-- Counter -->
            <script type="text/javascript" src="assets/js/waypoints.js"></script>
            <script type="text/javascript" src="assets/js/jquery.counterup.js"></script>

            <!-- Custom js -->
            <script src="assets/js/custom.js"></script>

        </div>
    </form>
</body>
</html>
