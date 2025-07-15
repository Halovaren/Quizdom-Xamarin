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
using System.Text;
using System.Xml;
using Xamarin.Essentials;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "Quizdom")]
    public class CustomQnA : Activity
    {
        private EditText problem, correctAns, opt1, opt2, opt3, opt4;
        private Button submitbtn, clearbtn;
        private WriteXMLClass xmlClass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.customQnA);

            // Create your application here

            problem = FindViewById<EditText>(Resource.Id.editText1);
            correctAns = FindViewById<EditText>(Resource.Id.editText2);
            opt1 = FindViewById<EditText>(Resource.Id.editText3);
            opt2 = FindViewById<EditText>(Resource.Id.editText4);
            opt3 = FindViewById<EditText>(Resource.Id.editText5);
            opt4 = FindViewById<EditText>(Resource.Id.editText6);
            submitbtn = FindViewById<Button>(Resource.Id.button1);
            submitbtn.Click += this.Submitbtn_Click;
            clearbtn = FindViewById<Button>(Resource.Id.button2);
            clearbtn.Click += this.Clearbtn_Click;

            xmlClass = new WriteXMLClass("setOfQuestions.xml", "Gameplay");
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {

            string[] inputs = new string[6];
            inputs[0] = problem.Text;
            inputs[1] = correctAns.Text;
            inputs[2] = opt1.Text;
            inputs[3] = opt2.Text;
            inputs[4] = opt3.Text;
            inputs[5] = opt4.Text;

            string[] elementNames = new string[6];
            elementNames[0] = "Problem";
            elementNames[1] = "Option1";
            elementNames[2] = "Option2";
            elementNames[3] = "Option3";
            elementNames[4] = "Option4";
            elementNames[5] = "CorrectAnswer";

            // Create XML file
            xmlClass.CreateXMLFile(inputs, elementNames);

            int questionCount = xmlClass.GetQuestionCount();
            if (questionCount >= 10)
            {
                // Redirect to a new activity
                var intent = new Intent(this, typeof(ListOfQnA));
                StartActivity(intent);
            }
            else
            {
                problem.Text = "";
                correctAns.Text = "";
                opt1.Text = "";
                opt2.Text = "";
                opt3.Text = "";
                opt4.Text = "";

                Toast.MakeText(this, "Question and choices added successfully.", ToastLength.Short).Show();
            }

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            xmlClass = new WriteXMLClass("setOfQuestions.xml", "Question");
            xmlClass.ClearXMLFile();

            Intent intent = new Intent(this, typeof(CustomQnA));
            StartActivity(intent);

        }
    }
}