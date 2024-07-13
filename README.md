# Inventory-management-system

## Introduction

This system allows you to track the amount of goods left in the store and enables the cashier to generate bills for customers. The system provides numerous benefits to the shop owner. the project developed using c# an object-oriented programming concepts and the "bunifu" framework for styling.


## Login Page

- You can log in using your username and password.
- Field validation is implemented; if an incorrect username or password is entered, an error message will appear.
- Employees can access the cashier by selecting "Employee" as the authorization.
- Admins can access the admin panel by selecting "Admin" as the authorization.
- Usernames and passwords are stored in a database.
- Admins can add new users from the admin panel.
- Passwords can be shown by ticking the "Show Password" option.
- Click the "Login" button to go to the dashboard.

![login page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8KYqEiY5za5BVIlikeekEW_lQKT1R9juomRymB4MT04eOHFGatJMLYMu4VigQxBBgonP3JPgeSl0LyKkvXsZmYZD38ZS8MmZFvck_aEQo7vbJNywFVyZTsD7CsrOtGb-tehwdHKaokp2-TpdHPgm8A6sgyDqLg9qRJV9c6J3SUvxmGUHgNrt9VGG_a_jK/s16000/100.png)

## Dashboard Page

- The dashboard features 4 widgets and a chart:
  - **Total Sales**: Collection of bills issued by the cashier.
  - **Sold Items**: Number of items sold in at least one transaction.
  - **Critical Stock**: Number of products with stock levels below 10.
  - **In Stock**: Number of items currently in inventory.
- The chart shows the sales volume of the top 20 products in sales history.
- A navigation bar on the left side provides access to 7 sections: Dashboard, Inventory, Vendors, Purchase Orders, Category, Settings, and Logout. This bar is available on almost every page.
- Click on a section to navigate to it, or click "Logout" to return to the login page.
- The navigation bar can be collapsed if desired.

![dashboard page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjrq7fGbI_DnkvTUHa-D_Z3XiWRznWA2swZXL7-SnqZK0D-sDO3i3Bv_WUpyo6weHAV_8pqtbB1N3p2GVA-iX4GgvQk1GHB8Cdz0L2ulf1dUxMBl0vY9u9ciS__BbF0i8EmJIjMwq7x62EaprWWGAxC4qSvoK-tunJ4siI-fucolEd2BXlZVlDGNB9o125H/s16000/101.png)

## Inventory Page

- The inventory menu displays all products in the store in a table format.
- The table includes columns for product code, name, unit price, quantity, product notes, vendor, and category.
- A search bar in the top left corner helps filter products.
- Click the "Critical Item" button to filter products with stock levels below 10.
- Click the "All Items" button to display all products in the store.

  ![inventory page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEguwY-BSVNqCs-PjZ_Yup6X1VyWRlrO6A1MPEvTzUAL0Lsw9OD8cdFuaSberLvQrpJgkQ3I8_m846_vmMoBVdzFQLXKBCOVI6zLcdupIGrIcOxiM6piRR9tT0tvsGyrofUVhEdcI4D9fd-ECYGtrnqhD08qCmDPv84sroXH8tfIBQLVJxf6AAOucxgD6j6Y/s16000/102.png)

### Add New Products and Update Products

- Click the plus button in the top right corner to add new products. This opens a pop-up window with forms for adding new products or updating existing products.
- Fill in the required information and press the submit button to add or update the product.
- Refresh the window to see updated details in the table.
- A toggle button in the top right corner handles stock in and out operations. Select a product, toggle the button, enter the stock amount, and press the button to complete the operation.
- To delete a product, select it and press the delete button.

 ![Add New](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgDZtG0B9QUjYeWomB6QWd1AdMyu326fs4wtXE5VlhgnA9y08g5M6BnXGwfHZP6XkIaC9MbRWKJtOkdSc0p9vQRRA70G4LgdAzaIiPTHelOHnLOjNZHL3AEh2NRJW-ZrITvEZKmeA7yv1PO-f-5khTZra39Zo3pLNEa-nGN_Q6z3OcVMytbufHETpbeI2nT/s16000/103.png)

## Vendor Page

- Fill in the vendor ID, vendor name, contact details, address, and city under vendor information. Click the plus button to add the information.
- To update information, modify it under vendor information and click the update button.
- To delete information, select the line from the vendors list and click the delete button.
- Enter, update, and delete operations will be reflected in the vendors list.
- Use the search bar to filter vendors by name or ID. Click "Filter Vendors" to apply the filter.
- Click the refresh button to display all information again.

 ![Vendor Page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjXlTSxp4agSA8zvGPeFwOzv44ZIUcGWyo4eb00VCM8RiStvkn4JGJ9a4F8EA7lnBZpOJDylfnK68MXHTiG2xsq3zif24gZNkGDY2YrAkHdPS0mpsCBrB56a8MjfvKaJKmQJR_a40Q6s9l3F34klbjcg6kKwUWPMPulywpyV_W5IMSyYdwBEL4LKPD9ysNO/s16000/104.png)

## Purchase Order Page

- Filter purchase orders by entering the order ID in the search bar and clicking the filter order button.
- Filter orders within a date range by entering the dates and clicking the filter order button.
- Click the refresh button to display all purchase orders again.
- Navigate to the cashier by clicking the cashier picture in the top right corner.

 ![Purchase Order Page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjnN1S-ZstpSqVIznO4y2GbzCC5IGT2GCzA26GLDgAX7a2dlreaANvPRGJtvt4eqYKgDxRVcibuECWE7ZKQHaE2ZJrWIHjrsDXZk0yhqKPuGD2PYPA7FLMXcYPRP_oBl_mLrcmHey5SlrN02W_fB5YNubrdcrlq9FVDKo2gJjBMHNItgAhLb3VExwc4a_9g/s16000/105.png)

## Cashier Page

- Fill in the information under the customer, order, and payment sections.
- The "Order Date" and "Issued By" fields are automatically filled.
- Select the payment method.
- Double-click on the desired product to add it to the cart.
- Enter the quantity to calculate the total price.
- The total amount of the bill is displayed on the "Cart Total."
- The billing date and time are displayed in the top right corner.
- Click the print button to print the bill.

 ![Cashier Page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgyeTngNXAJVHvPLKmFSPgE1nZ4MRFmQ4fl5w6zuVKxJC045TIFWgm0EYILbP8m7-YTdYqkv0OCTC-paGQ7jsvPckaSSMyP3o_hwlDYZHp0YFgpzUadMQKq2M9QypfkmnLloRHvmfCkzPg6Hh50BVXcXXnOnipbsDFTY_kzQmWVj1ke_rBPRfM1S-hOG4Qj/s16000/108.png)

## Category Page

- The category page allows you to add, update, delete, filter, and refresh information, similar to other pages.

 ![Category Page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjHomutIJcPRUQ-qi52g7NJZxPP3axK8lQloPhiogegM96ERd8oxGczSxYkQ7ickfoWesAORxqCD48il6ivspU-uQJZSP3dj_Ga-KlKLttx8pZuF-avwNho3D3alK7sh3TxnOryj8Js-zm6a2G8czu6fbydO5eruzU0HAKw_43Dl1ayfph6CGy5mHn8Fwov/s16000/106.png)

## Settings Page

- Grant user access by filling in the admin ID/employee ID, username, password, and confirming the password. Click "Give Access" to grant access.
- Tick "Show Password" to display the password.
- Select "Admin" or "Employee" as the authorization.
- Granted access information will appear.
- Select and delete the required user information to block access.

 ![Settings Page](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhlIHpmT_9KsOuIMWJnuqEzg_2gIkf-ZnNOMBBvKRKBf0i4b_xrcbYjgebNFgDMWKO0KCOwJw3xw9hgGYbNrRpRMvB2Eojxsm5viwIlPF65_mT2PToaHbArE42JnCh3DI3Gdyl8kbLGrAWGDVk7oB__bd8bRxSynEPzgDHFIuZrR-QvheK5ZxjuX8LxMIiJ/s16000/107.png)

## Diagrams

### ER Diagram

![ER Diagram](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiP68fVIk7MzwAQqH4I2loFkgPbSBHT64geUaEYuUX7I9j1F3yn1T6-tE9XsKZKbj1uLld6dXe4QQLP4wucqw_XBPHj8R2L576i1Y1pD5eC8fDZZURUPUr0lhiA53gJln1y8Tan_AQ_wnGtSLjJz7A3mGvz31Y2al9fCvqQTEzxxo3G_uUrIeRzAXunxKzZ/s16000/er-01.png)

### Class Diagram

![Class Diagram](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgavUvLcl6zeh-ecyjwKPYD6VpXvijEwAXbz0VeZ5flyhyphenhyphenDOCCgsqQEuhL-kEKMNwmBZ6RlrZ17jXonaKEcozwkcdMDo379aVQfmKH_Bs2ItGHQT08hr-QZ5NNEZJ78loRl4XeRvGXfJHwEEsysNAFNKd-WLWdT1kK4kPw9BrMEmxsjEf2U-nmzjK1qdIJy/s16000/class-01.png)

### Use Case Diagram

![Use Case Diagram](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgLJy4HY4GMLOZnqEqdWxWIZTL6m18CPVBYpBcwCcb-ILQuIXVYBr84Oh9mKE8bn9fGLYTwP9zRRhcQ_iuSNSukYp5jqtTbSsX2zAXgA6VI2LpCQBnONvVln4EAfUsxtaIupySJ4mfDoxnWCAas2Xz5Hqc-sy_bwzoLMD8I5HiQq4wH0twqQ6qlDUt-oF5d/s16000/useCase-01.png)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

