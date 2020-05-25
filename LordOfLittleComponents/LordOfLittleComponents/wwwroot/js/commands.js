
$("#btn_w").click(function () {
    var ID = 1;
    if ($(this).hasClass("on")) {
        $(this).removeClass("on").html("Ligar");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Desligar" }
        );

    }
    else {
        $(this).addClass("on").html("Desligar");

        $(this).load("/Home/SendCommand",
            { id: ID, command: "Ligar" }
        );
    }
    
});



