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
    [Activity(Label = "ListOfQnA")]
    public class ListOfQnA : Activity
    {
        private List<Question> questions;
        private WriteXMLClass xmlClass;
        private Button confirmBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listOfQnA);

            confirmBtn = FindViewById<Button>(Resource.Id.confirmbtn);
            confirmBtn.Click += confirmBtn_Click;

            // Initialize the list of questions
            questions = new List<Question>();

            // Initialize the WriteXMLClass
            xmlClass = new WriteXMLClass("setOfQuestions.xml", "Gameplay");

            // Read the XML file and populate the questions list
            int questionCount = xmlClass.GetQuestionCount();
            for (int i = 0; i < questionCount; i++)
            {
                string problem = xmlClass.ReadXMLFile("Problem", i);
                string correctAnswer = xmlClass.ReadXMLFile("CorrectAnswer", i);
                string option1 = xmlClass.ReadXMLFile("Option1", i);
                string option2 = xmlClass.ReadXMLFile("Option2", i);
                string option3 = xmlClass.ReadXMLFile("Option3", i);
                string option4 = xmlClass.ReadXMLFile("Option4", i);

                Question question = new Question(problem, correctAnswer, option1, option2, option3, option4);
                questions.Add(question);
            }

            // Display the questions
            DisplayQuestions();
        }

        private void DisplayQuestions()
        {
            LinearLayout container = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            LayoutInflater inflater = LayoutInflater.From(this);

            // Iterate over the questions list and create TextViews dynamically
            for (int i = 0; i < questions.Count; i++)
            {
                Question question = questions[i];
                View questionView = inflater.Inflate(Resource.Layout.listOfQnA, container, false);

                TextView questionText = questionView.FindViewById<TextView>(Resource.Id.textView1);
                TextView correctAnswerText = questionView.FindViewById<TextView>(Resource.Id.textView2);
                TextView choicesText = questionView.FindViewById<TextView>(Resource.Id.textView3);

                // Set the text values
                questionText.Text = $"Question {i + 1}: {question.Problem}";
                correctAnswerText.Text = $"Correct Answer: {question.CorrectAnswer}";
                choicesText.Text = $"Choices: {question.Option1}, {question.Option2}, {question.Option3}, {question.Option4}";


                questionText.Visibility = ViewStates.Visible;
                correctAnswerText.Visibility = ViewStates.Visible;
                choicesText.Visibility = ViewStates.Visible;

                // Add the questionView to the container
                container.AddView(questionView);
            }
        }
        private void confirmBtn_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }

    public class Question
    {
        public string Problem { get; }
        public string CorrectAnswer { get; }
        public string Option1 { get; }
        public string Option2 { get; }
        public string Option3 { get; }
        public string Option4 { get; }

        public Question(string problem, string correctAnswer, string option1, string option2, string option3, string option4)
        {
            Problem = problem;
            CorrectAnswer = correctAnswer;
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
        }
    }

    
}