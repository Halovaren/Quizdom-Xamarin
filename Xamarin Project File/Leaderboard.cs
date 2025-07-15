using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Org.W3c.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "Quizdom", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]

    public class Leaderboard : Activity
    {
        String result = "",player1,score1,twoplayer1,twoplayer2,score2,score22;

        Button btn1P;
        
        HttpWebRequest request;
        HttpWebResponse response;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Leaderboard);

            // Create your application here
            btn1P = FindViewById<Button>(Resource.Id.button1);
            btn1P.Click += btn1P_Click;

            HttpWebRequest rqs = (HttpWebRequest)WebRequest.Create("http://192.168.47.20/IT123P/REST2/LeaderBoard.php");



            string[] PlayerName = new string[]
            {
               player1= Intent.GetStringExtra("Pname")
               //twoplayer1 = Intent.GetStringExtra("Player1"),
               //twoplayer2 = Intent.GetStringExtra("Player2"),
                };
            ListView ListScore = (ListView)FindViewById<ListView>(Resource.Id.listView1);
            ArrayAdapter<string>Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, PlayerName);
            ListScore.Adapter = Adapter;
            Toast.MakeText(this, result, ToastLength.Long).Show();

            string[] thisScore = new string[]
            {
               score1= Intent.GetStringExtra("isScore")
               //score2= Intent.GetStringExtra("twoScore1"),
               //score22= Intent.GetStringExtra("twoScore2")

                };
            ListView ListScore2 = (ListView)FindViewById<ListView>(Resource.Id.listView2);
            ArrayAdapter<string> Adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, thisScore);
            ListScore2.Adapter = Adapter2;
            Toast.MakeText(this, result, ToastLength.Long).Show();


        }

        private void btn1P_Click(object sender, EventArgs e)
        {   
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}