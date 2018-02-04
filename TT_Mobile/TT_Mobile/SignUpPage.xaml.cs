using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            //FN.Behaviors.Add(new SignUpBehavior());
        }

        public async void SignUp  (object sender, TextChangedEventArgs e)
         {
            if(string.IsNullOrEmpty( FN.Text))
            FN_error_msg.Text = "Please Enter your first name";
            if (string.IsNullOrEmpty(LN.Text))
                LN_error_msg.Text = "Please Enter your last name";
            if (string.IsNullOrEmpty(email.Text))
                email_error_msg.Text = "Please Enter your email";

            if (string.IsNullOrEmpty(pass.Text))
                pass_error_msg.Text = "Please Enter your password";

            AppService appservice = new AppService();
            bool success = false;
            if (string.IsNullOrEmpty(FN_error_msg.Text) && string.IsNullOrEmpty(LN_error_msg.Text) &&
                string.IsNullOrEmpty(mobile_error_msg.Text) && string.IsNullOrEmpty(phone_error_msg.Text) &&
                string.IsNullOrEmpty(email_error_msg.Text) && string.IsNullOrEmpty(pass_error_msg.Text))
                success = await appservice.SignUp(FN.Text, LN.Text, phone.Text, mobile.Text, address.Text, email.Text, pass.Text);

            if (success == true)
            {
                signup_error.Text = "wait until the account will be approved";

                signup_error.TextColor = Color.Green;
            }
            else
                signup_error.Text = "there is an error in your registration";


        }
    }
}