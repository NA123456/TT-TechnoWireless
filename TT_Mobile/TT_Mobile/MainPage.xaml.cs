using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TT_Mobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        public async void SignUp(object sender, EventArgs args)
        {
        
           await Navigation.PushModalAsync(new SignUpPage());
        }

        public async void SignIn(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(email.Text))
                email_error_msg.Text = "Please Enter your email";
            else
                email_error_msg.Text = "";
            if (string.IsNullOrEmpty(pass.Text))
                pass_error_msg.Text = "Please Enter your password";
            else
                pass_error_msg.Text = "";

            AppService appService = new AppService();
            bool res = false;
            if (string.IsNullOrEmpty(email_error_msg.Text) && string.IsNullOrEmpty(pass_error_msg.Text))
               res=  await appService.Login(email.Text, pass.Text);
            if (res == false)
                login_error.Text = "Your email or password is incorrect";
            else
                await Navigation.PushModalAsync(new HomePage());



        }

    }
}
