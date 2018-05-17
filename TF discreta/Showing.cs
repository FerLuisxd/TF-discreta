using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TF_discreta
{
    [Activity(Label = "Showing")]
    public class Showing : Activity
    {
        int numcant;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Showing);

            string cant = Intent.GetStringExtra("counter" ?? "error");
            int.TryParse(cant, out numcant);
            string[] myTextViews = new string[numcant];
            for (int i = 0; i < numcant; i++)
            {
                myTextViews[i] = Intent.GetStringExtra($"element{i}" ?? "error");
            }
      
      
            var EnumText = FindViewById<TextView>(Resource.Id.enumtext);
            var EnumElements = FindViewById<TextView>(Resource.Id.TextElement);
            var Elements = FindViewById<TextView>(Resource.Id.Elements);
            var CantText = FindViewById<TextView>(Resource.Id.TextCant);
            var ButtonBack = FindViewById<Button>(Resource.Id.GoBack);

            CantText.Text = numcant.ToString();
            for (int i = 0; i < numcant; i++)
            {
               Elements.Text = Elements.Text + "\n" + myTextViews[i]; 
            }
           
          ButtonBack.Click += delegate
            {
                this.Finish();
            };

        }
    }
}