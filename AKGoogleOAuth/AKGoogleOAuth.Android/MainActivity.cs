
using AKGoogleOAuth.Services;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using System.Threading;

namespace AKGoogleOAuth.Droid
{
    [Activity(Label = "AKGoogleOAuth", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , IAuthenticatorService
    {
        public static AuthenticatorVM Auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Auth = new AuthenticatorVM(this);

            var authenticator = Auth.GetAuthenticator();
            var authenticatorUI = authenticator.GetUI(this);
            StartActivity(authenticatorUI);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnAuthenticateCompleted(string tokenType, string accessToken)
        {
            // could retrive some user information such as Name and etc.
            throw new System.NotImplementedException();
        }

        public void OnAuthenticateFailed()
        {
            // decide to display either alert box or something else.
            throw new System.NotImplementedException();
        }
    }
}