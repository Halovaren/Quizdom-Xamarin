using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "HowManyPlayers")]
    public class HowManyPlayers : Activity
    {
        Button btn1P, btn2P, btn3P;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.numOfPlayers);

            btn1P = FindViewById<Button>(Resource.Id.button1);
            btn1P.Click += btn1P_Click;
            btn2P = FindViewById<Button>(Resource.Id.button2);
            btn2P.Click += btn2P_Click;
        }

        private void btn1P_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(OnePlayerName));
            StartActivity(intent);
        }

        private void btn2P_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(TwoPlayers));
            StartActivity(intent);
        }

      
    }
}