using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Onboarding.Feature
{
    public class OnboardingViewModel : MvvmHelpers.BaseViewModel
    {
        private ObservableCollection<OnboardingModel> items;
        private int position;
        private string skipButtonText;

        public OnboardingViewModel()
        {
            SetSkipButtonText("SKIP");
            InitializeOnBoarding();
            InitializeSkipCommand();
        }

        private void SetSkipButtonText(string skipButtonText)
                => SkipButtonText = skipButtonText;

        private void InitializeOnBoarding()
        {
            Items = new ObservableCollection<OnboardingModel>
            {
                new OnboardingModel
                {
                    Title = "Welcome to \n TABIA",
                    Content = "Tabia helps you build habits that stick.",
                    ImageUrl = "healthy_habits.svg"
                },
                new OnboardingModel
                {
                    Title = "Reminder",
                    Content = "Reminder helps you execute your habits each day.",
                    ImageUrl = "time.svg"
                },
                new OnboardingModel
                {
                    Title = "Track your progress",
                    Content = "Charts help you visualize your efforts over time.",
                    ImageUrl = "visual_data.svg"
                }
            };
        }

        private void InitializeSkipCommand()
        {
            SkipCommand = new Command(() =>
            {
                if (LastPositionReached())
                {
                    ExitOnBoarding();
                }
                else
                {
                    MoveToNextPosition();
                }
            });
        }

        private static void ExitOnBoarding()
            => Application.Current.MainPage.Navigation.PopModalAsync();

        private void MoveToNextPosition()
        {
            var nextPosition = ++Position;
            Position = nextPosition;
        }

        private bool LastPositionReached()
            => Position == Items.Count - 1;

        public ObservableCollection<OnboardingModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public string SkipButtonText
        {
            get => skipButtonText;
            set => SetProperty(ref skipButtonText, value);
        }

        public int Position
        {
            get => position;
            set
            {
                if (SetProperty(ref position, value))
                {
                    UpdateSkipButtonText();
                }
            }
        }

        private void UpdateSkipButtonText()
        {
            if (LastPositionReached())
            {
                SetSkipButtonText("GOT IT");
            }
            else
            {
                SetSkipButtonText("SKIP");
            }
        }

        public ICommand SkipCommand { get; private set; }
    }
}