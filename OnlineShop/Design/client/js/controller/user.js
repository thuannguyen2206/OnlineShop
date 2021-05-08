
var user = {
    init: function () {
        user.loadProvince();
        user.registerEvent();
    },

    registerEvent: function(){
        $("#dllProvince").off("change").on("change", function () {
            var value = $(this).val();
                if (value != "") {
                user.loadDistrict(value);
            } else {
                $("#dllDistrict").html("");
            }
        });

        $("#dllDistrict").off("change").on("change", function () {
            var value = $(this).val();
            if (value != "") {
                user.loadVillage(value);
            } else {
                $("#dllVillage").html("");
            }
        });
    },

    loadProvince: function () {
        $.ajax({
            url: "/User/LoadProvince",
            type: "POST",
            dataType: "json",
            success: function (res) {
                var html = '<option value="">--- Chọn tỉnh thành ---</option>';
                if (res.status == true) {
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.name + '">' + item.name + '</option>';
                    });

                    $("#dllProvince").html(html);
                }
            }
        });
    },

    loadDistrict: function (value) {
        $.ajax({
            url: "/User/LoadDistrict",
            type: "POST",
            data: {province: value},
            dataType: "json",
            success: function (res) {
                var html = '<option value="">--- Chọn quận/huyện ---</option>';
                if (res.status == true) {
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.name + '">' + item.name + '</option>';
                    });

                    $("#dllDistrict").html(html);
                }
            }
        });
    },

    loadVillage: function (value) {
        $.ajax({
            url: "/User/LoadVillage",
            type: "POST",
            data: { district: value },
            dataType: "json",
            success: function (res) {
                var html = '<option value="">--- Chọn phường/xã ---</option>';
                if (res.status == true) {
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.name + '">' + item.name + '</option>';
                    });

                    $("#dllVillage").html(html);
                }
            }
        });
    }
}
user.init();