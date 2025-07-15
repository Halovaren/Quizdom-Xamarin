using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static Google.Apis.Requests.BatchRequest;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "Quizdom", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Landscape)]
    public class TwoPlayers : Activity
    {
         public int question_number = 0;
         string[] random_array = new string[6];
         string[,] XMLarray;
         int player1_score = 0;
         int player2_score = 0;
         XMLclass xml = new XMLclass("setOfQuestions.xml", "Question");
        Gameplay game = new Gameplay();
        ImageButton player1, player2;
        TextView questions, choices,player1_display_points, player2_display_points;
        String Score1 = "", Score2 = "", pname1 = "", pname2 = "",res="";
        HttpWebRequest request, request2;
        HttpWebResponse response, response2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.twoPlayers);

            player1 = FindViewById<ImageButton>(Resource.Id.player1);
            player2 = FindViewById<ImageButton>(Resource.Id.player2);
            questions = FindViewById<TextView>(Resource.Id.textView1);
            choices = FindViewById<TextView>(Resource.Id.textView3);
            player1_display_points = FindViewById<TextView>(Resource.Id.player1_points);
            player2_display_points = FindViewById<TextView>(Resource.Id.player2_points);

            if (Intent.Extras != null)
            {

                string longstring = Intent.GetStringExtra("question_num");
                string[] aray = longstring.Split("*");

                question_number = int.Parse(aray[0]);

                if (aray[1] == "PLAYER1")
                {
                    player1_score = int.Parse(aray[2]);
                    player1_display_points.Text = (int.Parse(aray[2])).ToString();
                    player2_score = int.Parse(aray[4]);
                    player2_display_points.Text = (int.Parse(aray[4])).ToString();
                }
                if (aray[1] == "PLAYER2")
                {
                    player2_score = int.Parse(aray[2]);
                    player2_display_points.Text = (int.Parse(aray[2])).ToString();
                    player1_score = int.Parse(aray[4]);
                    player1_display_points.Text = (int.Parse(aray[4])).ToString();
                }

            }
            
            xml.ConnectXML();
            XMLarray = xml.ExtractXMLData();
            try
            {
                questions.Text = XMLarray[question_number, 0].ToString();
                random_array[0] = XMLarray[question_number, 1].ToString();
                random_array[1] = XMLarray[question_number, 2].ToString();
                random_array[2] = XMLarray[question_number, 3].ToString();
                random_array[3] = XMLarray[question_number, 4].ToString();
                random_array[4] = XMLarray[question_number, 5].ToString();
                random_array[5] = question_number.ToString();
                choices.Text = "1. " + random_array[0] +
                               "\n2. " + random_array[1] +
                               "\n3. " + random_array[2] +
                               "\n4. " + random_array[3];
            }
            catch
            {
            //Execute if all questions are answered, show results, go back to main menu
            bool tied = game.IsTied(player1_score,player2_score);
            if (tied)
            {

                Toast.MakeText(Application.Context, "Both players got tied points.", ToastLength.Long).Show();
            }
            else
            {
                string[] winner = new string[1];
                winner = game.Determine_Winner(player1_score, player2_score);
                Toast.MakeText(Application.Context, "The winner is " + winner[0] + " with " + winner[1] + " points", ToastLength.Long).Show();
            }
                Score1 = player1_display_points.Text;
                Score2 = player2_display_points.Text;
               
    

                Intent intent = new Intent(this, typeof(TwoPlayersName));
                intent.PutExtra("isScore1", Score1);
                intent.PutExtra("isScore2", Score2);
                StartActivity(intent);
            }
            player1.Click += this.Player1_Click;
            player2.Click += this.Player2_Click;
        }

        public void Player1_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Application.Context, "Player 1 pressed first!", ToastLength.Short).Show();
            Intent intent = new Intent(this, typeof(PtwoQuestions));
            string PassingData = questions.Text + "*" + random_array[0] + "*" + random_array[1] + "*" + random_array[2] + "*" +
                                 random_array[3] + "*" + random_array[4] + "*" + random_array[5] + "*" + "PLAYER1" + "*" + player1_score 
                                 + "*" + "PLAYER2" + "*" + player2_score; ;
            intent.PutExtra("LongString", PassingData);

            /* Score1 = player1_display_points.Text;
             pname1 = Intent.GetStringExtra("playerName");
             request = (HttpWebRequest)WebRequest.Create("http://192.168.188.20//IT123P/REST2/add_Player.php?pname=" + pname1 + "&Score=" + Score1);
             response = (HttpWebResponse)request.GetResponse();
             StreamReader reader = new StreamReader(response.GetResponseStream());
             res = reader.ReadToEnd();
             Toast.MakeText(this, res, ToastLength.Long).Show();*/

            StartActivity(intent);
        }

        public void Player2_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Application.Context, "Player 2 pressed first!", ToastLength.Short).Show();
            Intent intent = new Intent(this, typeof(PtwoQuestions));
            string PassingData = questions.Text + "*" + random_array[0] + "*" + random_array[1] + "*" + random_array[2] + "*" +
                                 random_array[3] + "*" + random_array[4] + "*" + random_array[5] + "*" + "PLAYER2" + "*" + 
                                 player2_score + "*" + "PLAYER1" + "*" + player1_score; ;
            intent.PutExtra("LongString", PassingData);

            /* Score2 = player2_display_points.Text;
             pname2 = Intent.GetStringExtra("playerName2");
             request2 = (HttpWebRequest)WebRequest.Create("http://192.168.188.20/IT123P/REST2/add_Player.php?pname=" + pname2 + "&Score=" + Score2);
             response2 = (HttpWebResponse)request2.GetResponse();
             StreamReader reader = new StreamReader(response.GetResponseStream());
             res = reader.ReadToEnd();
             Toast.MakeText(this, res, ToastLength.Long).Show();*/

            StartActivity(intent);
        }


    }
}