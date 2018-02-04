using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TT_Mobile
{
    public class NumberValidation:Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;

            bool isValid = int.TryParse(args.NewTextValue, out result);
            if (((Entry)sender).ClassId=="phone")
            ((Entry)sender).FindByName<Label>("phone_error_msg").Text = isValid ? "" : "Pleasr Enter only numbers";
            else if (((Entry)sender).ClassId=="mobile")
                ((Entry)sender).FindByName<Label>("mobile_error_msg").Text = isValid ? "" : "Pleasr Enter only numbers";

        }
    }
}

