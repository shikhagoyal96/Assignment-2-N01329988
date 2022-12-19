# Assignment-2-N01329988


```
<form name = “customerform” onsubmit="saveCustomerInfo()" >
<label for="fname">First name:</label><br>
<input type="text" id="fname" name="fname" required><br>
<label for="lname">Last name:</label><br>
<input type="text" id="lname" name="lname" required><br>
<label for="phone">Phone:</label><br>
<input type="tel" id="phone" name="phone" required><br><br>
<input type="submit" value="Submit">
</form>

```


Customerinfo.js


```
function saveCustomerInfo() {
    var customerInfo = new CustomerPersonalInfo();
    customerInfo.firstName = document.forms["customerform"]["fname"].value;
customerInfo.lastName = document.forms["customerform"]["lname"].value;
    customerInfo.phone = document.forms["customerform"]["phone"].value;
    validateInfo(customerInfo);
    var response = callthebackendapi(customerinfo);
    if (response) goToNextForm(response.data);
}

```
