﻿
var cart = {
    init: function () {
        cart.regEvent();
    },
    regEvent: function () {
        $("#btnContinue").off("click").on("click", function () {
            window.location.href = "/";
        });

        $("#btnUpdate").off("click").on("click", function () {
            var listProduct = $(".txtQuantity");
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).val(),
                    product: {
                        id: $(item).data("id")
                    }
                });
            });

            $.ajax({
                url: "/Cart/Update",
                data: {cartModel:JSON.stringify(cartList)},
                dataType:"json",
                type:"POST",
                success: function(res){
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });

        var del = function(){$("#btnDeleteAll").off("click").on("click", function () {
            $.ajax({
                url: "/Cart/DeleteAll",
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });
        }

        $(".btn-delete").off("click").on("click", function (e) {
            e.preventDefault();
            $.ajax({
                data:{id: $(this).data("id")},
                url: "/Cart/Delete",
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });

        $("#btnPayment").off("click").on("click", function () {
            window.location.href = "/thanh-toan";
        });

    }
}
cart.init();