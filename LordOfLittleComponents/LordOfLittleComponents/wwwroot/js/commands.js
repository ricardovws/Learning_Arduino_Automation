
function refreshButtonStatus() {

    if ($("#btn_w").text() == "Off") {
        $(this).addClass("on");
    }
}



$("#btn_w").click(function () {
    var ID = 1;
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


