using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace AIPProject01.Models.ViewModel
{
    public class LoginViewModel : IValidatableObject
    {

        //返回位置
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ReturnUrl { get; set; }


        //帳號
        [Display(Name = "帳號:")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required]
        public string Account { get; set; }

        // 密碼
        [Display(Name = "密碼:")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required]
        public string Password { get; set; }

        // 密碼
        [Display(Name = "記住我")]
        public Boolean Remember { get; set; }

        //判斷是否有效
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //這邊看各組自己當初是用什麼名稱就改什麼
            AIPEntities18 db = new AIPEntities18();

            //從第一組的資料表中把會員資料都撈出來
            var list = db.G1_User_Account.ToList();

            //對密碼進行加密(因為當初註冊有加密過，所以需要在加密比對)
            //如果資料庫裡密碼是沒加密的，則不用使用這段
            MD5 md5 = MD5.Create();
            byte[] source = Encoding.Default.GetBytes(Account + Password);//將欲加密字串轉成Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            Password = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串

            //從資料庫比較是否有 使用者登入的帳號 存在
            G1_User_Account FindUser = list.Find(x => x.email.Equals(Account));


            if (FindUser == null)//若找不到這個帳號就回傳無此帳號
                yield return new ValidationResult("無此帳號", new string[] { "Account" });
            else//找到此帳號
            {
                if (!(FindUser.passwd.Equals(Password)))//若密碼不相同則回傳錯誤
                    yield return new ValidationResult("密碼錯誤", new string[] { "Password" }); ;
            }
        }
    }
}