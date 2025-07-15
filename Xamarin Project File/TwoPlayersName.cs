using Android.App;
using Android.Content;
using Android.Icu.Number;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static Google.Apis.Admin.Directory.directory_v1.DirectoryService;
using static Google.Apis.Requests.BatchRequest;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "TwoPlayersName")]
    public class TwoPlayersName : Activity
    {
        Button btn2P;
        TextView Play1text, Play2text;
        String  player = "",player2="",PScore1,PScore2,res="";
        HttpWebRequest request, request2;
        HttpWebResponse response, response2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TwoPlayersName);
            // Create your application here
            btn2P = FindViewById<Button>(Resource.Id.button2P);
            btn2P.Click += btn2P_Click;
            Play1text = FindViewById<EditText>(Resource.Id.editText1);
            Play2text = FindViewById<EditText>(Resource.Id.editText2);
        }

        private void btn2P_Click(object sender, EventArgs e)
        {
            player = Play1text.Text;
            player2 = Play2text.Text;
            PScore1= Intent.GetStringExtra("isScore1");
            PScore2 = Intent.GetStringExtra("isScore2");
            request = (HttpWebRequest)WebRequest.Create("http://192.168.188.20/IT123P/REST2/add_Player.php?pname=" + player + "&Score=" + PScore1);
            request2 = (HttpWebRequest)WebRequest.Create("http://192.168.188.20/IT123P/REST2/add_Player.php?pname=" + player2 + "&Score=" + PScore2);
            response = (HttpWebResponse)request.GetResponse();
            response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            Toast.MakeText(this, res, ToastLength.Long).Show();
            
            Intent i = new Intent(this, typeof(Leaderboard));
            i.PutExtra("Player1", player);
            i.PutExtra("twoScore1", PScore1);
            i.PutExtra("Player2", player2);
            i.PutExtra("twoScore2", PScore2);
            StartActivity(i);
        }
    }
}