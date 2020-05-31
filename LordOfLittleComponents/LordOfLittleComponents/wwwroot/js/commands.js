//Check if the button color is right.
$(window).on("load", function () {

    if ($("#btn_w").text() == "On") {
        $("#btn_w").addClass("on");
    }
    if ($("#btn_y").text() == "On") {
        $("#btn_y").addClass("on");
    }
    if ($("#btn_r").text() == "On") {
        $("#btn_r").addClass("on");
    }
    if ($("#btn_g").text() == "On") {
        $("#btn_g").addClass("on");
    }
});

//Function to call a method in controller
//Obs: I really dont know why whis function is always called when the webpage is loaded.
//Because of this problem I had to repeat this function 4x below :(
//I know that repeat code is not good and must be avoided but I couldnt do anything different to
//make all of this work without repeat code :/


//****
//function sendCommand(Id) {
//    var ID = Id;

//    if ($(this).hasClass("on")) {
//        $(this).removeClass("on");

//        $(this).load("/Home/SendCommand",
//            { id: ID, command: "Off" }
//        );

//    }
//    else {
//        $(this).addClass("on");

//        $(this).load("/Home/SendCommand",
//            { id: ID, command: "On" }
//        );
//    }
//}
//****


//Each button sends an on/off command to "sendCommand" function

$("#btn_w").click(function () {
    var ID = 1;

    //Function that I tell you some lines above.
    if ($(this).hasClass("on")) {
        $(this).removeClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Off" }
        );

    }
    else {
        $(this).addClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "On" }
        );
    }
});

$("#btn_y").click(function () {
    var ID = 2;

    //Function that I tell you some lines above.
    if ($(this).hasClass("on")) {
        $(this).removeClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Off" }
        );

    }
    else {
        $(this).addClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "On" }
        );
    }
});

$("#btn_r").click(function () {
    var ID = 3;

    //Function that I tell you some lines above.
    if ($(this).hasClass("on")) {
        $(this).removeClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Off" }
        );

    }
    else {
        $(this).addClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "On" }
        );
    }
});

$("#btn_g").click(function () {
    var ID = 4;

    //Function that I tell you some lines above.
    if ($(this).hasClass("on")) {
        $(this).removeClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Off" }
        );

    }
    else {
        $(this).addClass("on");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "On" }
        );
    }
});


