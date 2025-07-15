using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Apis.Admin.Directory.directory_v1.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "OnePlayerName")]
    public class OnePlayerName : Activity
    {
        Button btn1P;
        TextView Play1text, Play2, Play3;
        String res = "", player = "";

        HttpWebRequest request;
        HttpWebResponse response;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OnePlayerName);
            // Create your application here
            btn1P = FindViewById<Button>(Resource.Id.button1P);
            btn1P.Click += btn1P_Click;
            
            Play1text = FindViewById<EditText>(Resource.Id.editText1);
        }
        private void btn1P_Click(object sender, EventArgs e)
        {
            player = Play1text.Text;
            Intent intent = new Intent(this, typeof(OnePlayer));
            intent.PutExtra("playerName", player);
            StartActivity(intent);
        }

       
    }
}