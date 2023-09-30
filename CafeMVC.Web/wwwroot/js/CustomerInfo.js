function FillShippingAddress() {
    var checkBox = document.getElementById("check-address");
    var streetBil = document.getElementById("streetB");
    var streetDel = document.getElementById("streetD");
    var buildingNoBil = document.getElementById("buildingNumberB");
    var buildingNoDel = document.getElementById("buildingNumberD");
    var flatNumberBil = document.getElementById("flatNumberB");
    var flatNumberDel = document.getElementById("flatNumberD");
    var zipCodeBil = document.getElementById("zipCodeB");
    var zipCodeDel = document.getElementById("zipCodeD");
    var cityBil = document.getElementById("cityB");
    var cityDel = document.getElementById("cityD");
    var countryDel = document.getElementById("countryD");
    var countryBil = document.getElementById("countryB");


    if (checkBox.checked == true) {
        streetDel.value = streetBil.value;
        buildingNoDel.value = buildingNoBil.value;
        flatNumberDel.value = flatNumberBil.value;
        zipCodeBil.value = zipCodeDel.value;
        cityBil.value = cityDel.value;
        countryBil.value = countryDel.value;
        PutTicksIntoSpanUnderFilledTextboxes();

    } else {
        streetDel.value = "";
        buildingNoDel.value = "";
        flatNumberDel.value = "";
        zipCodeBil.value = "";
        cityBil.value = "";
        countryBil.value = "";
        RemoveTicksFromSpansUnderTextboxes();
    }
};


var billingTypeId = document.getElementById("billingTypeId");
if (billingTypeId != null) {
    billingTypeId.value = "1";

}

var emailTypeId = document.getElementById("emailTypeId");
if (emailTypeId != null) {
    emailTypeId.value = "1";
}
var mobileTypeId = document.getElementById("mobileTypeId");
if (mobileTypeId != null) {
    mobileTypeId.value = "2";
}


function phoneNumber() {
    var mobileNumberRegex = /^(?:(?:00)?44|0)7(?:[45789]\d{2}|624)\d{6}$/;
    var phoneNumberBox = document.getElementById("phoneBox");
    var textboxMessage = document.getElementById("phoneAlert");
    var submit = document.getElementById("submitButton");

    if (phoneNumberBox.value.replace(/\D/g, '').match(mobileNumberRegex)) {
        textboxMessage.style.color = "green";
        textboxMessage.innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>';
        submit.disabled = false;
    }
    else {
        textboxMessage.style.color = "red";
        textboxMessage.innerHTML = '<i class="fa-solid fa-circle-exclamation"></i> Enter correct phone number';
        submit.disabled = true;
    }
}


var phone = document.getElementById("phoneBox");
if (phone != null) {
phone.addEventListener("change", phoneNumber);
}

function CheckField(traget) {
    const div = document.getElementById(traget);
    var input = div.getElementsByTagName('input');
    var span = div.getElementsByTagName('span');
    var submit = document.getElementById("submitButton");

    if (input[0].value.length > 2 && input[0].value.length < 50) {
        span[0].style.color = "green";
        span[0].innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>';
        submit.disabled = false;
    }
    else {
        span[0].style.color = "red";
        span[0].innerHTML = '<i class="fa-solid fa-circle-exclamation"></i> It needs to between 2 and 50 characters';
        submit.disabled = true;
    }
}

function CheckNumber(traget) {
    const div = document.getElementById(traget);
    var input = div.getElementsByTagName('input');
    var span = div.getElementsByTagName('span');
    var submit = document.getElementById("submitButton");

    if (input[0].value.length >= 1 && input[0].value.length < 50) {
        span[0].style.color = "green";
        span[0].innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>';
        submit.disabled = false;
    }
    else {
        span[0].style.color = "red";
        span[0].innerHTML = '<i class="fa-solid fa-circle-exclamation"></i> It needs to between 1 and 50 characters';
        submit.disabled = true;
    }
}

function PutTicksIntoSpanUnderFilledTextboxes() {
    const billingSpans = document.querySelectorAll("div#billingAddress div.columnTwo span");
    const deliverySpans = document.querySelectorAll("div#deliveryAddress div.columnOne span");
    for (let i = 0; i < billingSpans.length; i++) {
        billingSpans[i].innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>';
        deliverySpans[i].innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>';
    }

}

function RemoveTicksFromSpansUnderTextboxes() {
    const billingSpans = document.querySelectorAll("div#billingAddress div.columnTwo span");
    const deliverySpans = document.querySelectorAll("div#deliveryAddress div.columnOne span");
    for (let i = 0; i < billingSpans.length; i++) {
        billingSpans[i].innerHTML = "";
        deliverySpans[i].innerHTML = "";
    }
}
