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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            FN.Text = AppData.user.firstname;
            LN.Text = AppData.user.lastname;
            phone.Text = AppData.user.phone;
            mobile.Text = AppData.user.mobile;
            address.Text = AppData.user.address;
            CourseName.Text = AppData.user.coursename;
		}
	}
}