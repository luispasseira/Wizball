using BusinessLogic.BLL;
using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Web.UI;

namespace FrontOffice.Pages
{
    public partial class ViewRegistration : System.Web.UI.Page
    {
        Globals globals;
        BLL bll;

        protected void Page_Load(object sender, EventArgs e)
        {          
            if (IsPostBack)
            {
                globals = new Globals();
                bll = globals.CreateBll();

               
                if(!UsernameValidation())
                {
                    return;
                }
                else if(!EmailValidation())
                {
                    return;  
                }
                else if (!PasswordValidation())
                {
                    return;
                }
                else
                {
                    User newUser = new User                     // Creates new user object.
                    {
                        Username    = txtUsername.Text,
                        Email       = txtEmail.Text,
                        Password    = txtPassword.Text
                    };

                    if(bll.InsertUser(newUser))                 // Insert the user object into the database.
                    {
                        txtUsername.Text    = string.Empty;     // Clear form.
                        txtEmail.Text       = string.Empty;
                        txtPassword.Text    = string.Empty;

                        bll.SendEmailUserRegistration(newUser);

                        // Calls JS function registrationConfirmation() which will display a successful message to the user.
                        Page.ClientScript.RegisterStartupScript(GetType(), "recoverPasswordConfirmation", "recoverPasswordConfirmation()", true);
                    }
                }
            }
        }

        private bool UsernameValidation()
        {
            string username = txtUsername.Text;

            if (string.IsNullOrWhiteSpace(username))        // Validates if null or empty.
                return false;
            else if (username.Length > 50)                  // Validates if length > 50.
                return false;
            else if (bll.UsernameExists(username))          // Validates if this username is already taken.
                return false;

            return true;
        }
        private bool EmailValidation()
        {
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(email))           // Validates if null or empty.
                return false;
            else if (email.Length > 100)                    // Validates if length > 100.
                return false;
            else if (!globals.IsValidEmail(email))          // Validates if valid email format.
                return false;
            else if (bll.UserMailExists(email))             // Validates if this email is already in usage.
                return false;

            return true;
        }
        private bool PasswordValidation()
        {
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))                // Validates if null or empty.
                return false;
            else if (password.Length < 6 || password.Length > 100)  // Validates if length < 6 or > 100.
                return false;

            return true;
        }
    }
}