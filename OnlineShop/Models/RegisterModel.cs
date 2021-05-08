using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        //[Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string userName { get; set; }

        //[Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Độ dài tối thiểu 6 ký tự")]
        public string password { get; set; }

        //[Required(ErrorMessage = "Xác nhận mật khẩu")]
        [Compare("password", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string confirmPassword { get; set; }

        //[Required(ErrorMessage = "Nhập tên người dùng")]
        public string name { get; set; }

        public string phone { get; set; }

        //[Required(ErrorMessage = "Nhập email")]
        public string email { get; set; }

        public string province { get; set; }

        public string district { get; set; }

        public string village { get; set; }
    }
}