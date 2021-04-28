using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutiAssist_MobileApp.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace AutiAssist_MobileApp.ViewModels
{
    class PuzzleTwoOneViewModel : BaseViewModel
    {
        Color circleOne;

        Color circleTwo;

        Color circleThree;

        List<string> coloursList;

        List<Color> coloursListHex;

        string circleOneSelectedString;

        string circleTwoSelectedString;

        string circleThreeSelectedString;

        bool circleOneTikSwitch;

        bool circleTwoTikSwitch;

        bool circleThreeTikSwitch;

        Random random;
        public Command<int> CircleOneSelectedCommand { get; }
        public Command<int> CircleTwoSelectedCommand { get; }
        public Command<int> CircleThreeSelectedCommand { get; }
        public Command ShuffleCommand { get; }
        public Command NextLevelCommand { get; }
        public PuzzleTwoOneViewModel()
        {
            Title = "Puzzle 2.0";
            CircleOneSelectedCommand = new Command<int>(CircleOneSelected);
            CircleTwoSelectedCommand = new Command<int>(CircleTwoSelected);
            CircleThreeSelectedCommand = new Command<int>(CircleThreeSelected);
            ShuffleCommand = new Command(ShufflePuzzle);
            NextLevelCommand = new Command(OnNextLevelClicked);
            random = new Random();
            InitializeTikSwitches();
            InitializeColoursLists();
            PopulateCircles();
        }

        public List<string> ColoursList
        {
            get
            {
                return coloursList;
            }
            set { SetProperty(ref coloursList, value); }
        }

        public string CircleOneSelectedString
        {
            get { return circleOneSelectedString; }
            set { SetProperty(ref circleOneSelectedString, value); }

        }
        public string CircleTwoSelectedString
        {
            get { return circleTwoSelectedString; }
            set { SetProperty(ref circleTwoSelectedString, value); }

        }
        public string CircleThreeSelectedString
        {
            get { return circleThreeSelectedString; }
            set { SetProperty(ref circleThreeSelectedString, value); }

        }

        public List<Color> ColoursListHex
        {
            get { return coloursListHex; }
            set { SetProperty(ref coloursListHex, value); }
        }

        public bool CircleOneTikSwitch
        {
            get { return circleOneTikSwitch; }
            set { SetProperty(ref circleOneTikSwitch, value); OnPropertyChanged(nameof(CircleOneCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }

        public bool CircleTwoTikSwitch
        {
            get { return circleTwoTikSwitch; }
            set { SetProperty(ref circleTwoTikSwitch, value); OnPropertyChanged(nameof(CircleTwoCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleThreeTikSwitch
        {
            get { return circleThreeTikSwitch; }
            set { SetProperty(ref circleThreeTikSwitch, value); OnPropertyChanged(nameof(CircleThreeCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }

        public bool CircleOneCrossSwitch => !CircleOneTikSwitch;
        public bool CircleTwoCrossSwitch => !CircleTwoTikSwitch;
        public bool CircleThreeCrossSwitch => !CircleThreeTikSwitch;

        public bool NextButtonSwitch => CircleOneTikSwitch && CircleTwoTikSwitch && CircleThreeTikSwitch;
        public Color CircleOne
        {
            get { return circleOne; }
            set { SetProperty(ref circleOne, value); }
        }

        public Color CircleTwo
        {
            get { return circleTwo; }
            set { SetProperty(ref circleTwo, value); }
        }

        public Color CircleThree
        {
            get { return circleThree; }
            set { SetProperty(ref circleThree, value); }
        }

        void ShuffleColours()
        {
            coloursList.OrderBy(i => Guid.NewGuid()).ToList();
        }

        void CircleOneSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleOne))
                {
                    CircleOneTikSwitch = true;
                }
                else
                {
                    CircleOneTikSwitch = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleTwoSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleTwo))
                {
                    CircleTwoTikSwitch = true;
                }
                else
                {
                    CircleTwoTikSwitch = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleThreeSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleThree))
                {
                    CircleThreeTikSwitch = true;
                }
                else
                {
                    CircleThreeTikSwitch = false;
                }
            }
            else
            {
                return;
            }
        }

        void PopulateCircles()
        {
            //Get three random numbers for colours
            List<int> randomNumbers = new List<int>();

            int count = 0;
            randomNumbers.Clear();

            while (count != 3)
            {
                int number = random.Next(8);

                if (randomNumbers.Contains(number))
                {
                    continue;
                }
                else
                {
                    randomNumbers.Add(number);
                    count++;
                }
            }

            CircleOne = ColoursListHex[randomNumbers[0]];
            CircleTwo = ColoursListHex[randomNumbers[1]];
            CircleThree = ColoursListHex[randomNumbers[2]];

        }
        void InitializeTikSwitches()
        {
            circleOneTikSwitch = false;
            circleTwoTikSwitch = false;
            circleThreeTikSwitch = false;
        }

        void InitializeColoursLists()
        {
            coloursList = new List<string>()
            {
                "Red",
                "Black",
                "Green",
                "Orange",
                "Yellow",
                "Blue",
                "Brown",
                "Purple"
            };

            coloursListHex = new List<Color>()
            {
                Color.Red,
                Color.Black,
                Color.Green,
                Color.Orange,
                Color.Yellow,
                Color.Blue,
                Color.Brown,
                Color.Purple
            };
        }

        void ShufflePuzzle()
        {
            PopulateCircles();
            CircleOneSelectedString = null;
            CircleTwoSelectedString = null;
            CircleThreeSelectedString = null;
            CircleOneTikSwitch = false;
            CircleTwoTikSwitch = false;
            CircleThreeTikSwitch = false;

        }

        private async void OnNextLevelClicked(object obj)
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
