using System.ComponentModel;
using Onboarding.Feature;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Onboarding
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (VersionTracking.IsFirstLaunchEver)
            {
                Navigation.PushModalAsync(new OnboardingPage());
            }
        }
    }
}
