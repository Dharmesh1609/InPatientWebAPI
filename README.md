This application is a web-based interface built in ASP.NET that fetches and displays healthcare data from the CMS (Centers for Medicare & Medicaid Services) API. It provides an interactive platform for users to explore inpatient payment data based on Diagnosis Related Group (DRG) descriptions, provider information, and state data.

Key Features:
Data Fetching and Display: The application retrieves data in pages from the CMS API, deserializes it into a list of CMSData objects, and displays it in a grid format (GridView) based on user-selected filters.

Search Filters: Users can filter results by DRG descriptions, provider name, or state abbreviation. The app dynamically loads filter options into dropdowns based on user selection and mode (Hospital-wise or State-wise).

Filter Modes:

Hospital-wise: Displays provider-specific data based on the selected DRG and provider.
State-wise: Displays state-specific data based on the selected DRG and state abbreviation.
Dynamic UI Controls: The interface dynamically updates dropdown options based on the selected DRG, showing only relevant options for providers or states, depending on the chosen search mode.

Error Handling: Displays messages for potential errors, such as API fetch failures or invalid selections, ensuring users receive feedback for issues during data loading or search execution.

The CMSData class defines the structure of the data items, which includes various provider details, geographic identifiers, and financial metrics like average submitted charges and Medicare payments. This project could be valuable for users needing insights into hospital billing trends, costs associated with specific treatments, and regional cost comparisons.
