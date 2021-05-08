
//var category = {
//    init: function () {
//        category.registerEvent();
//    },

//    registerEvent: function () {
//        $("#cateRemove").off("click").on("click", function () {
//            category.removeCate();
//        });
        
//    },

//    removeCate: function Delele(id) {
//        var ans = confirm("Bạn có chắc muốn xóa bảng ghi này?");
//        if (ans) {
//            $.ajax({
//                url: "/Category/Delete/" + id,
//                type: "POST",
//                contentType: "application/json;charset=UTF-8",
//                data: {id: id},
//                dataType: "json",
//                success: function (result) {
//                    if (result.status == true)
//                        window.location.href = "/Category/Index";
//                },
//                error: function (errormessage) {
//                    alert(errormessage.responseText);
//                }
//            });
//        }
//    }

//}

//category.init();