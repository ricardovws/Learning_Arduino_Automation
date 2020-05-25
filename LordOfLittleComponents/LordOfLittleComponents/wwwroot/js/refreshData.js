
window.setInterval(function () {
    
    $("#dataFromSensors").load("/Home/RefreshTemperatureAndHumidityData");
}, 5000);


