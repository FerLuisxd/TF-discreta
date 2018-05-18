
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
using Android.Animation;


namespace TF_discreta
{
    [Activity(Label = "Agregando Elementos")]
    public class Adding : Activity
    {
        int n = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TextView[] myTextViews = new TextView[100];
            View[] myAddViews = new View[100];
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Adding);
            var TextIn = FindViewById<EditText>(Resource.Id.textin);
            var ButtonAdd = FindViewById<Button>(Resource.Id.add);
            var container = FindViewById<LinearLayout>(Resource.Id.container);
            var ButtonNext = FindViewById<Button>(Resource.Id.buttonnext);

            ButtonAdd.Click += delegate
            {

                LayoutInflater inflate = (LayoutInflater)BaseContext.GetSystemService(Context.LayoutInflaterService);
                View addView = LayoutInflater.Inflate(Resource.Layout.fila, null);
                TextView textOut = addView.FindViewById<TextView>(Resource.Id.textout);
                textOut.Text = TextIn.Text;
                myTextViews[n] = textOut;
                myAddViews[n] = addView;
                Button ButtonRemove = addView.FindViewById<Button>(Resource.Id.remove);
                n++;
                ButtonRemove.Click += delegate
                {
                    ((LinearLayout)addView.Parent).RemoveView(addView);
                    for (int i = 0; i < n; i++)
                    {
                        if (addView == myAddViews[i])
                        {
                            for (int j = i; j < n; j++)
                            {
                                myAddViews[j] = myAddViews[j + 1];
                                myTextViews[j] = myTextViews[j + 1];
                            }
                        }
                    }
                    n--;
                };

                container.AddView(addView);
                TextIn.Text = string.Empty;
            };

            LayoutTransition trans = new LayoutTransition();
            container.LayoutTransition = trans;

            ButtonNext.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(Showing)); //CHANGE
                nextActivity.PutExtra("counter", n.ToString());
                for (int i = 0; i < n; i++)
                {
                    nextActivity.PutExtra($"element{i}", myTextViews[i].Text);
                }
                StartActivity(nextActivity);
            };
        }
    }
}