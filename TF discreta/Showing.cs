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
    [Activity(Label = "Showing")]
    public class Showing : Activity
    {
        MatrizQ ma;//matriz
                   //
        int numcant;
        int cont;
        int Nelem = 0;
        int[][] mat;
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
            var container = FindViewById<LinearLayout>(Resource.Id.madre);

            CantText.Text = numcant.ToString();

            for (int i = 0; i < numcant; i++)
            {
                Elements.Text = Elements.Text + "\n" + myTextViews[i];
            }

            //EVENTO DE LA WEA
            ma = new MatrizQ(numcant);
            CheckBox[] myRButtons = new CheckBox[1000];
            TextView[] myTextViews2 = new TextView[1000];
            View[] myAddViews = new View[100];

            for (int j = Nelem + 1; j < numcant; j++)
            {
                LayoutInflater inflate = (LayoutInflater)BaseContext.GetSystemService(Context.LayoutInflaterService);
                View addView2 = LayoutInflater.Inflate(Resource.Layout.buttons, null);
                TextView nombreE = addView2.FindViewById<TextView>(Resource.Id.nombre2);
                nombreE.Text = myTextViews[j];
                CheckBox compE = addView2.FindViewById<CheckBox>(Resource.Id.comp);
                myRButtons[j] = compE;
                myTextViews2[j] = nombreE;
                myAddViews[j] = addView2;
                container.AddView(addView2);
                compE.CheckedChange += delegate
                {
                   
                    //if (true == compE.Checked)
                    //{
                    //    ma.setP(Nelem, j, 1);
                    //}
                    //else if (false == compE.Checked)
                    //{
                    //    ma.setP(Nelem, j, 0);
                    //}
                };
            }

                //Button
                //i++
                mat = ma.returnMa();



            ButtonBack.Click += delegate
            {
                for (int j = Nelem + 1; j < numcant; j++)
                {
                    if (true == myRButtons[j].Checked)
                    {
                        ma.setP(Nelem, j, 1);
                    }
                    else
                    {
                        ma.setP(Nelem, j, 0);
                    }
                }

                //this.Finish();
                cont++;
                ButtonBack.Text = cont.ToString();
                //Nelem++;
                for (int i = 0; i < numcant; i++)
                {
                    for (int j = 0; j < numcant; j++)
                    {

                        CantText.Text = CantText.Text+ " " + mat[i][j].ToString();
                    }
                    CantText.Text = CantText.Text + "--";
                }
                
                //reshesh
            };
            LayoutTransition trans = new LayoutTransition();
            container.LayoutTransition = trans;
        }
    }
}