function SyncResult() {
    var address = GetJSon.SyncResult;

    $.get(address, function (data) {
        for (var i = 0; i < data.length; i++);
        showResult(data);
    });

}
$(function () {
    setInterval("SyncResult()", 1000 * 30); // 30s gửi request một lần
});

function showResult(data) {
    $.each(data, function (i, item) {
        if (item === "normal") {
            // do nothing
        }
        else {
            show_notification(item);
            play_sound();
            console.log(item);
        }

    });
}

function play_sound() {
    var baseUrl = "Assets/Audio/";
    var audio = ["new-message.mp3"];

    new Audio(baseUrl + audio[0]).play();

};
// notification style
$.notify.addStyle('addSuccess', {
    html: "<div><span data-notify-text/></div>",
    classes: {
        base: {
            "white-space": "nowrap",
            "background-color": "#1abc9c",
            "padding": "10px 15px",
            "color": "#fff",
            "border-radius": "5px",
            "font-size": "16px"
        }
    }
});
$.notify.addStyle('addError', {
    html: "<div><span data-notify-text/></div>",
    classes: {
        base: {
            "white-space": "nowrap",
            "background-color": "#e74c3c",
            "padding": "10px 15px",
            "color": "#fff",
            "border-radius": "5px",
            "font-size": "16px"
        }
    }
});
function show_notification(noti) {
    // new noti
    $.notify(noti, { style: 'addSuccess' });

    // old noti
    //$.bootstrapGrowl(noti, {
    //    type: 'success',
    //    offset: {
    //        from: "bottom",
    //        amount: 20
    //    },
    //    width: 400,
    //    delay: 20000, // 20s
    //});
};
$(function () {
    $(".increase-order").click(function () {
        var address = $(this).attr("data-url");
        var id = $(this).attr("data-id");

        $.get(address, { id : id}, function (data) {
            show_notification(data);
        });
    })
});
$(function () {
    $(".update-status").click(function () {
        var address = $(this).attr("data-url");
        var id = $(this).attr("data-id");
        var status = $(this).attr("data-status");
        // nếu == 0 -> hết hàng, update thành còn hàng
        // nếu == 0 -> còn hàng, update thành hết hàng
        if (status == 0) {
            status = 1;
            $(this).attr("data-status", status);
            $(this).removeClass("btn-danger");
            $(this).addClass("btn-success");
            $(this).html("Còn hàng");
        }
        else {
            status = 0;
            $(this).attr("data-status", status);
            $(this).removeClass("btn-success");
            $(this).addClass("btn-danger");
            $(this).html("Hết hàng");
        }

        $.get(address, { id: id, status: status }, function (data) {
            show_notification(data);
        });
    })
});

