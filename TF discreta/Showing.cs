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
            var EnumMatriz = FindViewById<TextView>(Resource.Id.matrizenum);
            var Matriz = FindViewById<TextView>(Resource.Id.matriz);

            CantText.Text = myTextViews[Nelem];
            for (int i = 0; i < numcant; i++)
            {
                Elements.Text = Elements.Text + "\n" + myTextViews[i];
            }
            
            //EVENTO DE LA WEA
            ma = new MatrizQ(numcant);
            mat = ma.returnMa();
            CheckBox[] myRButtons = new CheckBox[1000];
            TextView[] myTextViews2 = new TextView[1000];
            View[] myAddViews = new View[100];

            void Evento(int Nelem)
            {
                for (int i = 0; i < numcant; i++)
                {
                    for (int j = 0; j < numcant; j++)
                    {
                        Matriz.Text = Matriz.Text + " " + mat[i][j].ToString();
                    }
                    Matriz.Text = Matriz.Text + "\n";
                }
                
                CantText.Text = myTextViews[Nelem];
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
                };
                }
            }

            Evento(Nelem);
            ButtonBack.Click += delegate
            {
                if (Nelem < numcant-1)
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
                    Matriz.Text = String.Empty;
                    cont++;
                    ButtonBack.Text = cont.ToString();

                    CantText.Text = String.Empty;

                    for (int j = Nelem + 1; j < numcant; j++)
                    {
                        myTextViews2[j].Visibility = ViewStates.Gone;
                        myRButtons[j].Visibility = ViewStates.Gone;
                        myAddViews[j].Visibility = ViewStates.Gone;
                    }
                    CantText.Text = String.Empty;
                    Nelem++;
                    Evento(Nelem);
                }
            };
            LayoutTransition trans = new LayoutTransition();
            container.LayoutTransition = trans;
        }
    }
}