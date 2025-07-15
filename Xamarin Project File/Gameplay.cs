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
    class Gameplay
    {
        public void OnePlayer_generateQuestions(TextView question, Button op1, Button op2, Button op3, Button op4, int counter, string[,] arr )
        {
                question.Text = (arr[counter, 0]).ToString();
                op1.Text = (arr[counter, 1]).ToString();
                op2.Text = (arr[counter, 2]).ToString();
                op3.Text = (arr[counter, 3]).ToString();
                op4.Text = (arr[counter, 4]).ToString();
        }

        public void TwoAndThreePlayer_generateQuestions(TextView question, TextView choices, int counter, string[,] arr)
        {
            question.Text = (arr[counter, 0]).ToString();
            choices.Text = "1. "+ (arr[counter, 1]).ToString() +
            "\n2. " + (arr[counter, 2]).ToString() +
            "\n3. " + (arr[counter, 3]).ToString() +
            "\n4. " + (arr[counter, 4]).ToString();
        }

        public bool checkAnswer(Button option, string[,] arr, int counter)
        {
            if (option.Text == arr[counter, 5])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTied(int player1_score, int player2_score)
        {
            if(player1_score == player2_score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string[] Determine_Winner(int player1_score, int player2_score)
        {
            string winner;
            int score;
            string[] result = new string[2];
            if (player1_score > player2_score)
            {
                winner = "Player 1";
                score = player1_score;
            }
            else
            {
                winner = "Player 2";
                score = player2_score;
            }
            result[0] = winner;
            result[1] = score.ToString();

            return result;
        }

        /*public void processGame(Context thiss, Type typee, string question, string op1, string op2, string op3, string op4, int question_num, string answer, string p1name,
                                int p1score, string p2name, int p2score)
        {
            Toast.MakeText(Application.Context, "Player 2 pressed first!", ToastLength.Short).Show();
            Intent x = new Intent(thiss, typee);
            string PassingData = question + "*" + op1 + "*" + op2 + "*" + op3 + "*" +
                                 op4 + "*" +answer + "*" + question_num + "*" + p1name + "*" +
                                 p1score + "*" + p2name + "*" + p2score ;
            x.PutExtra("LongString", PassingData);
            Start
        }*/
    }
}