using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using System.IO;
using System.Xml;
using Xamarin.Essentials;
using Android.Content;

namespace IT123P_Final_Course_Assessment_MP
{
    [Activity(Label = "Quizdom", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnPlay, btnSettings;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btnPlay = FindViewById<Button>(Resource.Id.button1);
            btnPlay.Click += btnPlay_Click;
            btnSettings = FindViewById<Button>(Resource.Id.button2);
            btnSettings.Click += btnSettings_Click;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(HowManyPlayers));
            StartActivity(intent);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(CustomQnA));
            StartActivity(intent);
        }

        private void btnDevs_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(Developers));
            StartActivity(intent);
        }
    }
}