using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace AIPProject01.Controllers
{
    public class AccountController : Controller
    {

        /*[AllowAnonymous]
        public ActionResult Login(G3_User User)
        {
            ViewBag.Message = "登入";

            using (AIPEntities3 db = new AIPEntities3())
            {
                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    if (User.NAME == item.NAME && User.PASSWORD == item.PASSWORD)
                    {
                        FormsAuthentication.RedirectFromLoginPage(User.NAME, true);
                        return View(User);
                    }
                }
            }
            return View();
        }*/


        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "已登入";
                //導向預設Url(Web.config裡的defaultUrl定義)或使用者原先Request的Url
                return Redirect(Url.Action("Index"));
            }

            //ReturnUrl字串是使用者在未登入情況下要求的的Url
            LoginViewModel vm = new LoginViewModel() { ReturnUrl = ReturnUrl };
            ViewBag.Message = "登入";
            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            //沒通過Model驗證(必填欄位沒填，DB無此帳密)
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "登入失敗";
                //將驗證失敗訊息傳回首頁
                return View(user);
            }

            //進行表單登入 
            this.LoginProcess(user);

            //導向預設Url(Web.config裡的defaultUrl定義)或使用者原先Request的Url
            ViewBag.Message = "登入成功";
            return Redirect(FormsAuthentication.GetRedirectUrl(user.Account, false));
        }

        private void LoginProcess(LoginViewModel user)
        {
            var now = DateTime.Now;
            //取得角色
            string roles = GetRole(user.Account);

            //設定表單票證
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: user.Account.ToString(),
                issueDate: now,
                expiration: now.AddMinutes(30),
                isPersistent: user.Remember,
                userData: roles,
                cookiePath: FormsAuthentication.FormsCookiePath);

            //建立表單票證
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //存成Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }

        private string GetRole(string Account)
        {

            //這邊去資料庫比對此帳號對應角色
            //因為資料庫還沒弄完,先暫時用讀到的帳號去強制給予身份
            List<string> list = new List<string>();

            string role = null;
            if (Account.Equals("g2"))
            {
                list.Add("Admin");
                list.Add("Elder");
                list.Add("Family");
            }
            else if (Account.Equals("g2_Elder"))
            {
                list.Add("Elder");
            }
            else if (Account.Equals("g2_Family"))
            {
                list.Add("Family");
            }
            else
                list.Add("Volunteer");

            role = string.Join(",", list.ToArray());
            return role;
        }

        public ActionResult Manage()
        {
            ViewBag.Message = "會員資料";

            G1_User_Account B = new G1_User_Account();

            String strLoginID = User.Identity.Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        B.id = item.id;
                        B.email = item.email;
                        B.passwd = item.passwd;
                    }
                }
            }
            return View(B);
        }

        public ActionResult LogOff()
        {
            //清除Session中的資料
            Session.Abandon();
            //登出表單驗證
            FormsAuthentication.SignOut();
            //導至登入頁
            return RedirectToAction("Login", "Account");
        }

        public ActionResult id()
        {
            G3_User B = new G3_User();

            String strLoginID = User.Identity.Name;

            using (AIPEntities3 db = new AIPEntities3())
            {
                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.NAME)
                    {
                        B.ID = item.ID;
                        B.NAME = item.NAME;
                        B.PASSWORD = item.PASSWORD;
                        B.SEX = item.SEX;
                    }
                }
            }

            ViewBag.Message = strLoginID;
            return View(B);
        }

        public ActionResult UserRegister()
        {
            ViewBag.Message = "註冊";
            return View();
        }

        [HttpPost]
        public ActionResult RegisterOutput(G3_User A)
        {
            ViewBag.Message = "註冊.結果";

            List<G3_User> list = new List<G3_User>();

            using (AIPEntities3 db = new AIPEntities3())
            {

                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    if (A.NAME == item.NAME)
                    {
                        return RedirectToAction("Register");
                    }
                }

                G3_User User = new G3_User();

                //User.ID = User.ID;
                User.NAME = A.NAME;
                User.PASSWORD = A.PASSWORD;
                User.SEX = A.SEX;

                db.G3_User.Add(User);
                db.SaveChanges();
            }

            return View(A);
        }

        public ActionResult Delete()
        {
            ViewBag.Message = "帳號刪除";
            List<G3_User> list = new List<G3_User>();

            using (AIPEntities3 db = new AIPEntities3())
            {
                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    G3_User user = new G3_User();
                    user.ID = item.ID;
                    user.NAME = item.NAME;
                    user.PASSWORD = item.PASSWORD;
                    user.SEX = item.SEX;

                    list.Add(user);
                }
            }
            return View(list);
        }

        public ActionResult DeleteOutput(G3_User A)
        {
            ViewBag.Message = "帳號刪除.結果";
            List<G3_User> list = new List<G3_User>();

            using (AIPEntities3 db = new AIPEntities3())
            {
                G3_User User = new G3_User();
                User = db.G3_User.Find(A.ID);

                if(User == null)
                {

                }
                else
                {
                    db.G3_User.Remove(User);
                    db.SaveChanges();
                }

                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    G3_User user = new G3_User();
                    user.ID = item.ID;
                    user.NAME = item.NAME;
                    user.PASSWORD = item.PASSWORD;
                    user.SEX = item.SEX;

                    list.Add(user);
                }
            }
            return View(list);
        }
    }
}
