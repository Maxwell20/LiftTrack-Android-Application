using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LiftTrack
{
    public class OnBMIcalEventArgs : EventArgs
    {
        private string mWeight;
        private string mHeight;
        private string mGender;
        public double BMI;

        public string Weight
        {
            get { return mWeight; }
            set { mWeight = value; }
        }

        public string Height
        {
            get { return mHeight; }
            set { mHeight = value; }
        }

        public string Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }

        public OnBMIcalEventArgs(string weight, string height, string gender) : base()
        {
            string Weight = weight;
            string Height = weight;
            string Gender = gender;

        }
        
    }

    class dialog_BMIcal : DialogFragment
    {
        private EditText mTxtWeight;
        private EditText mTxtHeight;
        private EditText mTxtGender;
        private EditText mBMI;
        private Button mBtnBMIcal;
        public double BMI = 0 ;
        

        public event EventHandler<OnBMIcalEventArgs> mOnBMIcalComplete;

        public double calc(string a, string b)
        {
            double weight = Convert.ToDouble(a);
            double height = Convert.ToDouble(b);
            BMI = 703 * (weight / (height*height));
            return BMI;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_BMIcal, container, false);

            mTxtWeight = view.FindViewById<EditText>(Resource.Id.txtWeight);
            mTxtHeight = view.FindViewById<EditText>(Resource.Id.txtHeight);
            mTxtGender = view.FindViewById<EditText>(Resource.Id.txtGender);
            mBMI = view.FindViewById<EditText>(Resource.Id.txtBMI);
            mBtnBMIcal = view.FindViewById<Button>(Resource.Id.btnDialogBMIcal);

            //this is an anonymous function fires wh
            mBtnBMIcal.Click += delegate { calc(mTxtWeight.Text, mTxtHeight.Text); mBMI.Text = string.Format("{0} % BodyFat", BMI); };

            return view;
        }
        //to use this need mbntBMIcal += mBtnBMIcal_click or just use anon funciton
        void mBtnBMIcal_Click(object sender, EventArgs e)
        {
            //User has clicked the calculate button
            mOnBMIcalComplete.Invoke(this, new OnBMIcalEventArgs(mTxtWeight.Text, mTxtHeight.Text, mTxtGender.Text));
           // this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
           // Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}