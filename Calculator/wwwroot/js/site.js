// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = 'api/calculator';

function addItem() {
    const addTextbox = document.getElementById('add-name');

    fetch(uri + '/add/' + addTextbox.value, {
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

function subtractItem() {
    const subtractTextbox = document.getElementById('subtract-name');

    fetch(uri + '/subtract/' + subtractTextbox.value, {
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

function multiplyItem() {
    const multiplyTextbox = document.getElementById('multiply-name');

    fetch(uri + '/multiply/' + multiplyTextbox.value, {
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

function divideItem() {
    const divideTextbox = document.getElementById('divide-name');

    fetch(uri + '/divide/' + divideTextbox.value, {
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
    //document.getElementById("p1").innerHTML = "New text!";
    document.getElementById("p1").innerHTML = data.result;
    document.getElementById('add-name').value = "";
    document.getElementById('subtract-name').value = "";
    document.getElementById('multiply-name').value = "";
    document.getElementById('divide-name').value = "";
}