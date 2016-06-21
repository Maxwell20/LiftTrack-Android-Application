using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LiftTrack
{
    [Activity(Label = "LiftTrack", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button BMIcalButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            BMIcalButton = FindViewById<Button>(Resource.Id.BMIcalButton);
            //Event handler for BMIcalButton this is an anon function
            BMIcalButton.Click += (object sender, EventArgs args) =>
                {
                    //pull up dialog
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    dialog_BMIcal BMIcaldialog = new dialog_BMIcal();
                    BMIcaldialog.Show(transaction, "dialog fragment");
                };


        }

    }
}

