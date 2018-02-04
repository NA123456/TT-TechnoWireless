using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TT_Mobile
{
    public class MainPageCS
    {
        private AppService appServcies = new AppService();

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
               await appServcies.Login(UserName, Password)
                );
            }
        }

    

    }
}
