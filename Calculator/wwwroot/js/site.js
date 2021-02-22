// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = 'api/calculator';

function addItem(calculation) {

    console.log("Test 2");

    if (calculation === "") {
        calculation = document.getElementById('add-name').value;
        console.log("Calculation in test 2 is: " + calculation);
    }

    fetch(uri + '/add/' + calculation, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    })
        .then(response => response.json())
        .then(data => _display(data))
        .catch(error => console.error('Unable to add item.', error));
}

function subtractItem(calculation) {

    if (calculation === "") {
        calculation = document.getElementById('subtract-name').value;
        console.log("Calculation in test 2 is: " + calculation);
    }

    fetch(uri + '/subtract/' + calculation, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        .then(response => response.json())
        .then(data => _display(data))
        .catch(error => console.error('Unable to subtract item.', error));
}

function multiplyItem(calculation) {

    if (calculation === "") {
        calculation = document.getElementById('multiply-name').value;
        console.log("Calculation in test 2 is: " + calculation);
    }

    fetch(uri + '/multiply/' + calculation, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        .then(response => response.json())
        .then(data => _display(data))
        .catch(error => console.error('Unable to multiply item.', error));
}

function divideItem(calculation) {

    if (calculation === "") {
        calculation = document.getElementById('divide-name').value;
        console.log("Calculation in test 2 is: " + calculation);
    }

    fetch(uri + '/divide/' + calculation, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        .then(response => response.json())
        .then(data => _display(data))
        .catch(error => console.error('Unable to divide item.', error));
}

function _display(data) {
    console.log("Here in display data " + data.result);
    //document.getElementById("p1").innerHTML = "New text!";
    document.getElementById("p1").innerHTML = data.result;
    document.getElementById('add-name').value = "";
    document.getElementById('subtract-name').value = "";
    document.getElementById('multiply-name').value = "";
    document.getElementById('divide-name').value = "";
    document.getElementById('leftOperand').value = data.result;
}

function clearItems() {
    document.getElementById("p1").innerHTML = "0";
    document.getElementById("leftOperand").value = "";
    document.getElementById("operator").value = "";
    document.getElementById("rightOperand").value = "";
}

function placeOperand(value) {
    var operator = document.getElementById("operator");
    var leftOperand = document.getElementById("leftOperand");
    var rightOperand = document.getElementById("rightOperand");


    if (operator.value === "") {
        if (leftOperand.value === "0") {
            leftOperand.value = value;
        } else {
            leftOperand.value += value;
        }

        display("left");
    } else {
        if (rightOperand.value === "0") {
            rightOperand.value = value;
        } else {
            rightOperand.value += value;
        }

        display("right");
    }

    console.log(`THe value is: ${value}`);
}

function display(operand) {
    if (operand === "left") {
        document.getElementById("p1").innerHTML = document.getElementById("leftOperand").value;
    } else {
        document.getElementById("p1").innerHTML = document.getElementById("rightOperand").value;
    }
}

function placeOperator(value) {

    var operator = document.getElementById("operator").value;

    if (operator !== "") {
        equals();
    }

    document.getElementById("operator").value = value;
    document.getElementById("rightOperand").value = "0";

}

function equals() {
    var operator = document.getElementById("operator").value;
    var leftOperand = document.getElementById("leftOperand").value;
    var rightOperand = document.getElementById("rightOperand").value;

    if (operator === "+") {
        addItem(leftOperand + "," + rightOperand);
    }
    else if (operator === "-") {
        subtractItem(leftOperand + "," + rightOperand);
    } else if (operator === "/") {
        divideItem(leftOperand + "," + rightOperand);
    }
    else if (operator === "*") {
        multiplyItem(leftOperand + "*" + rightOperand);
    }
}