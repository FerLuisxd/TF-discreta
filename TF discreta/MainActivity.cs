using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace TF_discreta
{
    [Activity(Label = "App Matemática Discreta", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var but = FindViewById<Button>(Resource.Id.button1);
            but.Click += (s,e) => 
            {
              Intent nextActivity = new Intent(this, typeof(Adding)); //CHANGE
              StartActivity(nextActivity);                
            };


        }
    }
}