using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Content.PM;
using Java.Util;
using Android.Util;
using System;

namespace Android.Localization
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.Locale)]
    public class MainActivity : AppCompatActivity
    {
        Button btnTranslate;
        TextView txtMessage;
        Spinner spinner;
        Android.Content.Res.Resources res;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnTranslate = FindViewById<Button>(Resource.Id.btnTranslate);
            txtMessage = FindViewById<TextView>(Resource.Id.textMessage);
            spinner = FindViewById<Spinner>(Resource.Id.select_language);

            


            btnTranslate.Click += BtnTranslate_Click;

         
            Context context = this; // Get the Resources object from our context
            res = context.Resources; // Get the string 
            Content.Res.Configuration conf = res.Configuration;
            DisplayMetrics dm = res.DisplayMetrics;
            conf.SetLocale(new Locale("ak")); //Set local to Akan ak
        
            res.UpdateConfiguration(conf, dm);

            var lang = Resources.Configuration.Locale;
            var country = lang.GetDisplayCountry(lang);
            Toast.MakeText(this, "Your current locale is " + lang, ToastLength.Long).Show();
            Toast.MakeText(this, "Country " + country, ToastLength.Long).Show();
            Toast.MakeText(this, "Display Name " + lang.DisplayName, ToastLength.Long).Show();
            Toast.MakeText(this, "Language " + lang.Language, ToastLength.Long).Show();
        }

        //
        private void BtnTranslate_Click(object sender, System.EventArgs e)
        {
            string greet = res.GetString(Resource.String.greet_message);
            txtMessage.Text = greet;          
        }
    }
}