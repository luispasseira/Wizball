using BusinessLogic.BLL;
using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Web;
using System.Web.UI;

namespace FrontOffice.Pages
{
    public partial class ViewEditProfile : System.Web.UI.Page
    {
        private BLL bll;

        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn())
            {
                Page.Response.Redirect("/Pages/ViewHome.aspx");
            }

            bll = new Globals().CreateBll();

            if (!IsPostBack)
            {
                PrepareForm();
            }
            else
            {
                User user = Session["User"] as User;

                user.Username = txtUsername.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text.Length > 0 ? txtPassword.Text : user.Password;
                user.Newsletter = cbNewsLetter.Checked;           
                if (Request.Files[0] != null)
                {
                    HttpPostedFile userPic = Request.Files[0];

                    if (userPic.ContentLength > 0)
                    {      
                        if(userPic.ContentLength < 512001)
                        {
                            user.Picture = userPic.FileName;

                            string FileName = userPic.FileName;

                            int FileSize = userPic.ContentLength;

                            byte[] FileByteArray = new byte[FileSize];

                            userPic.InputStream.Read(FileByteArray, 0, FileSize);

                            string path = Server.MapPath("~") + Globals.USERS + FileName;

                            userPic.SaveAs(path);
                        }                      
                    }                  
                }


                bll.UpdateUser(user);

                imgUserPic.ImageUrl = Globals.USERS + user.Picture;

                Page.ClientScript.RegisterStartupScript(GetType(), "recoverPasswordConfirmation", "recoverPasswordConfirmation()", true);
            }
        }


        private void PrepareForm()
        {
            User user = Session["User"] as User;

            imgUserPic.ImageUrl = Globals.USERS + user.Picture;             // Set user picture.
            txtUsername.Text        = user.Username;
            txtEmail.Text           = user.Email;
            cbNewsLetter.Checked    = user.Newsletter;
            txtPassword.Text        = user.Password;
        }
    }
}