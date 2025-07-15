using Android.App;
using Android.Content;
using Android.Content.PM;
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
    [Activity(Label = "TwoPlayerQuestionSet")]
    
    public class PtwoQuestions : Activity
    {
        Button op1_btn, op2_btn, op3_btn, op4_btn;
        TextView question_tv;
        public int question_num, head_player_score, tail_player_score;
        string correct_answer;
        string head_player,tail_player;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PtwoQuestion);

            op1_btn = FindViewById<Button>(Resource.Id.button1);
            op2_btn = FindViewById<Button>(Resource.Id.button2);
            op3_btn = FindViewById<Button>(Resource.Id.button3);
            op4_btn = FindViewById<Button>(Resource.Id.button4);
            question_tv = FindViewById<TextView>(Resource.Id.textView1);

            string longstring = Intent.GetStringExtra("LongString");
            string[] arr = longstring.Split("*");
            question_tv.Text = arr[0];
            op1_btn.Text = arr[1];
            op2_btn.Text = arr[2];
            op3_btn.Text = arr[3];
            op4_btn.Text = arr[4];
            correct_answer = arr[5];
            question_num = int.Parse(arr[6]);
            head_player = arr[7];
            head_player_score = int.Parse(arr[8]);
            tail_player = arr[9];
            tail_player_score = int.Parse(arr[10]);
            op1_btn.Click += this.OptionSelected;
            op2_btn.Click += this.OptionSelected;
            op3_btn.Click += this.OptionSelected;
            op4_btn.Click += this.OptionSelected;

        }

        public void OptionSelected(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            
            if (button.Text == correct_answer)
            {
                head_player_score += 5;
                SendData("Correct Answer!\n+5 Points");
            }
            else
            {
                SendData("Wrong Answer!");
            }
           
        }

        public void SendData(string message)
        {
            Toast.MakeText(Application.Context,message, ToastLength.Short).Show();
            Intent x = new Intent(this, typeof(TwoPlayers));
            int something = question_num + 1;
            string longstring = something + "*" + head_player + "*" + head_player_score + "*" + tail_player + "*" + tail_player_score;
            x.PutExtra("question_num", longstring.ToString());
            StartActivity(x);
        }
    }
}