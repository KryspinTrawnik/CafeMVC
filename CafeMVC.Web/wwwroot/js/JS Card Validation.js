const submitButton = document.getElementById("submitButton");

function TestCreditCard() {
    var inputValue = document.getElementById("cardNumberTxtBox").value;
    var information = checkCreditCard(inputValue);
    if (information.success != true) {
        const cardAlertSpan = document.getElementById("CardAlert");
        cardAlertSpan.style.color = "red";
        cardAlertSpan.innerHTML = information.message;
    }
    else {
        const cardAlertSpan = document.getElementById("CardAlert");
        cardAlertSpan.style.color = "green";
        cardAlertSpan.innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i>'+ information.type;
    }

}
const checkCreditCard = cardnumber => {


    const ccErrors = [];
    ccErrors[0] = "Unknown card type";
    ccErrors[1] = "No card number provided";
    ccErrors[2] = "Credit card number is in invalid format";
    ccErrors[3] = "Credit card number is invalid";
    ccErrors[4] = "Credit card number has an inappropriate number of digits";
    ccErrors[5] = "Warning! This credit card number is associated with a scam attempt";


    const response = (success, message = null, type = null) => ({
        message,
        success,
        type
    });


    const cards = [];
    cards[0] = {
        name: "Visa",
        length: "13,16",
        prefixes: "4",
        checkdigit: true
    };
    cards[1] = {
        name: "MasterCard",
        length: "16",
        prefixes: "51,52,53,54,55",
        checkdigit: true
    };
    cards[2] = {
        name: "DinersClub",
        length: "14,16",
        prefixes: "36,38,54,55",
        checkdigit: true
    };
    cards[3] = {
        name: "CarteBlanche",
        length: "14",
        prefixes: "300,301,302,303,304,305",
        checkdigit: true
    };
    cards[4] = {
        name: "AmEx",
        length: "15",
        prefixes: "34,37",
        checkdigit: true
    };
    cards[5] = {
        name: "Discover",
        length: "16",
        prefixes: "6011,622,64,65",
        checkdigit: true
    };
    cards[6] = {
        name: "JCB",
        length: "16",
        prefixes: "35",
        checkdigit: true
    };
    cards[7] = {
        name: "enRoute",
        length: "15",
        prefixes: "2014,2149",
        checkdigit: true
    };
    cards[8] = {
        name: "Solo",
        length: "16,18,19",
        prefixes: "6334,6767",
        checkdigit: true
    };
    cards[9] = {
        name: "Switch",
        length: "16,18,19",
        prefixes: "4903,4905,4911,4936,564182,633110,6333,6759",
        checkdigit: true
    };
    cards[10] = {
        name: "Maestro",
        length: "12,13,14,15,16,18,19",
        prefixes: "5018,5020,5038,6304,6759,6761,6762,6763",
        checkdigit: true
    };
    cards[11] = {
        name: "VisaElectron",
        length: "16",
        prefixes: "4026,417500,4508,4844,4913,4917",
        checkdigit: true
    };
    cards[12] = {
        name: "LaserCard",
        length: "16,17,18,19",
        prefixes: "6304,6706,6771,6709",
        checkdigit: true
    };

    // Ensure that the user has provided a credit card number
    if (cardnumber.length == 0) {
        return response(false, ccErrors[1]);
    }

    // Now remove any spaces from the credit card number
    // Update this if there are any other special characters like -
    cardnumber = cardnumber.replace(/\s/g, "");

    // Validate the format of the credit card
    // luhn's algorithm
    if (!validateCardNumber(cardnumber)) {
        return response(false, ccErrors[2]);
    }

    // Check it's not a spam number
    if (cardnumber == '5490997771092064') {
        return response(false, ccErrors[5]);
    }

    // The following are the card-specific checks we undertake.
    let lengthValid = false;
    let prefixValid = false;
    let cardCompany = "";

    // Check if card belongs to any organization
    for (let i = 0; i < cards.length; i++) {
        const prefix = cards[i].prefixes.split(",");

        for (let j = 0; j < prefix.length; j++) {
            const exp = new RegExp("^" + prefix[j]);
            if (exp.test(cardnumber)) {
                prefixValid = true;
            }
        }

        if (prefixValid) {
            const lengths = cards[i].length.split(",");
            // Now see if its of valid length;
            for (let j = 0; j < lengths.length; j++) {
                if (cardnumber.length == lengths[j]) {
                    lengthValid = true;
                }
            }
        }

        if (lengthValid && prefixValid) {
            cardCompany = cards[i].name;
            return response(true, null, cardCompany);
        }
    }

    // If it isn't a valid prefix there's no point at looking at the length
    if (!prefixValid) {
        return response(false, ccErrors[3]);
    }

    // See if all is OK by seeing if the length was valid
    if (!lengthValid) {
        return response(false, ccErrors[4]);
    };

    // The credit card is in the required format.
    return response(true, null, cardCompany);
}

const validateCardNumber = number => {
    //Check if the number contains only numeric value  
    //and is of between 13 to 19 digits
    const regex = new RegExp("^[0-9]{13,19}$");
    if (!regex.test(number)) {
        return false;
    }

    return luhnCheck(number);
}

const luhnCheck = val => {
    let checksum = 0; // running checksum total
    let j = 1; // takes value of 1 or 2

    // Process each digit one by one starting from the last
    for (let i = val.length - 1; i >= 0; i--) {
        let calc = 0;
        // Extract the next digit and multiply by 1 or 2 on alternative digits.
        calc = Number(val.charAt(i)) * j;

        // If the result is in two digits add 1 to the checksum total
        if (calc > 9) {
            checksum = checksum + 1;
            calc = calc - 10;
        }

        // Add the units element to the checksum total
        checksum = checksum + calc;

        // Switch the value of j
        if (j == 1) {
            j = 2;
        } else {
            j = 1;
        }
    }

    //Check if it is divisible by 10 or not.
    return (checksum % 10) == 0;
}

var selectYear = document.getElementById("expiryYear");
const currentYear = new Date().getFullYear();
const expiryDate = document.getElementById("ExpiryDateBox");

for (let i = 0; i < 10; i++) {
    const year = (currentYear + i).toString().slice(-2);
    const option = document.createElement("option");
    option.value = year;
    option.textContent = year;
    selectYear.appendChild(option);
}

const selectMonth = document.getElementById("expiryMonth");
for (let i = 1; i <= 12; i++) {
    const option = document.createElement("option");
    option.value = i;
    option.textContent = i;
    selectMonth.appendChild(option);
}

function validateExpiryDate(month, year) {
    // Get current date
    let currentDate = new Date();
    let currentMonth = currentDate.getMonth() + 1;
    let currentYear = currentDate.getFullYear().toString().substr(-2);

    // Convert input values to integers
    month = parseInt(month);
    year = parseInt(year);
    let currentYearInt = parseInt(currentYear);
    // Check if the input year is greater than the current year
    if (year > currentYearInt) {
        return true;
    } else if (year === currentYearInt) {
        // Check if the input month is greater than or equal to the current month
        if (month >= currentMonth) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}


function CheckIfCardIsValid() {
    let month = document.getElementById("expiryMonth").value;
    let year = document.getElementById("expiryYear").value;
    var expiryDateDiv = document.getElementById("expiryDate");
    var alertSpan = expiryDateDiv.getElementsByTagName('span');
    if (validateExpiryDate(month, year)) {
        alertSpan[0].style.color = "green";
        alertSpan[0].innerHTML = '<i class="fa-solid fa-circle-check" style="color:green"></i> Card is valid';
        submitButton.disabled = false;
    } else {
        alertSpan[0].style.color = "red";
        alertSpan[0].innerHTML = '<i class="fa-solid fa-circle-exclamation"></i> Card is expired';
        submitButton.disabled = true;
    }
}
function AssignValueToCrediCardExpiryDate() {
    let month = document.getElementById("expiryMonth").value;
    let year = document.getElementById("expiryYear").value;


    expiryDate.value = month + "/" + year;
}

function addSpaces(event) {
    var target = event.target;
    var cardNumber = target.value.replace(/\s/g, '');
    var split = 4;
    var spacedNumber = cardNumber.match(new RegExp('.{1,' + split + '}', 'g')).join(' ');
    target.value = spacedNumber;
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