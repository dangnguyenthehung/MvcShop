
var id_first_Quan_of_city = 1;

// load Quận
var load_Quan = function (url, ID_ThanhPho) {
    
    $.getJSON(url, { ID_ThanhPho: ID_ThanhPho }, function (response) {
        $("#Quan").empty();
        //response = JSON.parse(response);
        $.each(response, function (index, value) {
            if (index === 0) {
                id_first_Quan_of_city = value.ID;
            }
            $("#Quan").append($('<option></option>').text(value.Name).val(value.Id));
        });
    });
};

$(function () {
    $("#ThanhPho").change(function () {

        var url = AppUrlSetting.Get_Quan;

        var ID_ThanhPho = $(this).val();
        load_Quan(url, ID_ThanhPho);
    });
});

//// get lat long from user address
//function initGeo() {
//    var geocoder = new google.maps.Geocoder();

//    var action = "create";

//    $(".post-submit #submit").bind('click', function () {
//        var action = "create";
//        geocodeAddress(geocoder, action);
//    });

//    $(".edit-post-submit #submit").bind('click', function () {
//        var action = "edit";
//        geocodeAddress(geocoder, action);
//    });
    
//}

//function geocodeAddress(geocoder, action) {

//    var ID_thanhpho = $("#ThanhPho").val();
//    var ID_quan = $("#Quan").val();
//    var ID_phuong = $("#Phuong").val();

//    var thanhpho = $("#ThanhPho").find("[value='" + ID_thanhpho + "']").html();
//    var quan = $("#Quan").find("[value='" + ID_quan + "']").html();
//    var phuong = $("#Phuong").find("[value='" + ID_phuong + "']").html();

//    var diachi = $("#DiaChi").val();

//    var address = diachi + ", " + phuong + ", " + quan + ", " + thanhpho;

//    geocoder.geocode({ 'address': address }, function (results, status) {
//        if (status === 'OK') {
//            var lat = results[0].geometry.location.lat();
//            var lng = results[0].geometry.location.lng();

//            console.log(lat + "," + lng);

//            $("#Latitude").val(lat);

//            $("#Longitude").val(lng);
//        } else {
//            console.log('Geocode was not successful for the following reason: ' + status);

//            $("#Latitude").val(0);
//            $("#Longitude").val(0);
//        }

//        if (action === "create")
//        {
//            $("form#DangBai #formsubmit").trigger("click");
//        }
//        else if (action === "edit")
//        {
//            $("form#EditBaiDang #formsubmit").trigger("click");
//        }
        
//    });
//}