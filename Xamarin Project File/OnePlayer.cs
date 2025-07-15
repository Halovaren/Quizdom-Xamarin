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
using static Xamarin.Essentials.Platform;
using Intent = Android.Content.Intent;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "Quizdom", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Landscape)]
    public class OnePlayer : Activity
    {
        Button op1_btn, op2_btn, op3_btn, op4_btn,skip_btn;
        TextView question_tv, points_tv,Play1text;
        int counter = 0;
        String Score = "",res="",player="",pname;
        

        string[,] XMLarray;
        XMLclass xml = new XMLclass("setOfQuestions.xml", "Question");
        Gameplay game = new Gameplay();
        HttpWebRequest request;
        HttpWebResponse response;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.onePlayer);

            op1_btn = FindViewById<Button>(Resource.Id.button1);
            op2_btn = FindViewById<Button>(Resource.Id.button2);
            op3_btn = FindViewById<Button>(Resource.Id.button3);
            op4_btn = FindViewById<Button>(Resource.Id.button4);
            //skip_btn = FindViewById<Button>(Resource.Id.button5);
            question_tv = FindViewById<TextView>(Resource.Id.textView1);
            points_tv = FindViewById<TextView>(Resource.Id.textView3);
            
            

            xml.ConnectXML();
            XMLarray = xml.ExtractXMLData();
            game.OnePlayer_generateQuestions(question_tv, op1_btn, op2_btn, op3_btn, op4_btn, counter, XMLarray);

            op1_btn.Click += this.SelectedAnswer;
            op2_btn.Click += this.SelectedAnswer;
            op3_btn.Click += this.SelectedAnswer;
            op4_btn.Click += this.SelectedAnswer;
            //skip_btn.Click += this.SkipQuestion;
        }

        public void SkipQuestion(object sender, EventArgs e)
        {
            Toast.MakeText(Application.Context, "Skipped Answer.\nCorrect Answer is "+ XMLarray[counter, 5], ToastLength.Short).Show();
            counter++;
            game.OnePlayer_generateQuestions(question_tv, op1_btn, op2_btn, op3_btn,
                              op4_btn, counter, XMLarray);
            
        }

        public void SelectedAnswer(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            bool IsAnswerCorrect = game.checkAnswer(button, XMLarray, counter);


            if (IsAnswerCorrect)
            {
                
                try
                {
                    Toast.MakeText(Application.Context, "Correct Answer!\nYou got +5 Points", ToastLength.Short).Show();
                    points_tv.Text = (int.Parse(points_tv.Text) + 5).ToString();
                    counter++;
                    game.OnePlayer_generateQuestions(question_tv, op1_btn, op2_btn, op3_btn,
                                      op4_btn, counter, XMLarray);

                
                 

                }
                catch
                {
                    Score = points_tv.Text;
                    pname = Intent.GetStringExtra("playerName");
                    request = (HttpWebRequest)WebRequest.Create("http://192.168.47.20//IT123P/REST2/add_Player.php?pname=" + pname + "&Score=" + Score);

                    response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    res = reader.ReadToEnd();
                    Toast.MakeText(this, res, ToastLength.Long).Show();

                    Toast.MakeText(Application.Context, "You have completed the quiz.\nYou earned a total of " + points_tv.Text+" points", ToastLength.Long).Show();
                    Intent i = new Intent(this, typeof(Leaderboard));
                    i.PutExtra("Pname", pname);
                    i.PutExtra("isScore", Score);
                    StartActivity(i);

                }

                
            }
            else
            {
                try
                {
                    Toast.MakeText(Application.Context, "Wrong Answer!\nCorrect Answer is " + XMLarray[counter,5], ToastLength.Short).Show();
                    counter++;
                    game.OnePlayer_generateQuestions(question_tv, op1_btn, op2_btn, op3_btn,
                                      op4_btn, counter, XMLarray);
                }
                catch
                {
                    Toast.MakeText(Application.Context, "Thanks for playing! Your score is " + points_tv.Text, ToastLength.Short).Show();
                    Intent i = new Intent(this, typeof(Leaderboard));
                    StartActivity(i);
                }
            }

            
        }


    }
}