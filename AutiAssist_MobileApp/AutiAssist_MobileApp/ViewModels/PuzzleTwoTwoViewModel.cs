using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using AutiAssist_MobileApp.Views;

namespace AutiAssist_MobileApp.ViewModels
{
    public class PuzzleTwoTwoViewModel : BaseViewModel
    {
        #region Global Variables
        Random random;
        List<string> coloursList;
        List<Color> coloursListHex;
        public List<string> ColoursList
        {
            get
            {
                return coloursList;
            }
            set { SetProperty(ref coloursList, value); }
        }
        public List<Color> ColoursListHex
        {
            get { return coloursListHex; }
            set { SetProperty(ref coloursListHex, value); }
        }
        #endregion

        #region Colors Binding Objects
        Color circleOneColourOne;
        Color circleTwoColourOne;
        Color circleThreeColourOne;
        Color circleOneColourTwo;
        Color circleTwoColourTwo;
        Color circleThreeColourTwo;
        public Color CircleOneColourOne
        {
            get { return circleOneColourOne; }
            set { SetProperty(ref circleOneColourOne, value); }
        }

        public Color CircleTwoColourOne
        {
            get { return circleTwoColourOne; }
            set { SetProperty(ref circleTwoColourOne, value); }
        }

        public Color CircleThreeColourOne
        {
            get { return circleThreeColourOne; }
            set { SetProperty(ref circleThreeColourOne, value); }
        }
        public Color CircleOneColourTwo
        {
            get { return circleOneColourTwo; }
            set { SetProperty(ref circleOneColourTwo, value); }
        }

        public Color CircleTwoColourTwo
        {
            get { return circleTwoColourTwo; }
            set { SetProperty(ref circleTwoColourTwo, value); }
        }

        public Color CircleThreeColourTwo
        {
            get { return circleThreeColourTwo; }
            set { SetProperty(ref circleThreeColourTwo, value); }
        }
        #endregion

        #region Colours SelectedString Binding Objects
        string circleOneColourOneSelectedString;
        string circleOneColourTwoSelectedString;
        string circleTwoColourOneSelectedString;
        string circleTwoColourTwoSelectedString;
        string circleThreeColourOneSelectedString;
        string circleThreeColourTwoSelectedString;
        public string CircleOneColourOneSelectedString
        {
            get { return circleOneColourOneSelectedString; }
            set { SetProperty(ref circleOneColourOneSelectedString, value); }

        }
        public string CircleOneColourTwoSelectedString
        {
            get { return circleOneColourTwoSelectedString; }
            set { SetProperty(ref circleOneColourTwoSelectedString, value); }

        }
        public string CircleTwoColourOneSelectedString
        {
            get { return circleTwoColourOneSelectedString; }
            set { SetProperty(ref circleTwoColourOneSelectedString, value); }

        }
        public string CircleTwoColourTwoSelectedString
        {
            get { return circleTwoColourTwoSelectedString; }
            set { SetProperty(ref circleTwoColourTwoSelectedString, value); }

        }
        public string CircleThreeColourOneSelectedString
        {
            get { return circleThreeColourOneSelectedString; }
            set { SetProperty(ref circleThreeColourOneSelectedString, value); }

        }
        public string CircleThreeColourTwoSelectedString
        {
            get { return circleThreeColourTwoSelectedString; }
            set { SetProperty(ref circleThreeColourTwoSelectedString, value); }

        }
        #endregion

        #region Circle Tik Binding Objects

        public bool CircleOneTikSwitch => CircleOneColourOneAnswer && CircleOneColourTwoAnswer;
        public bool CircleTwoTikSwitch => CircleTwoColourOneAnswer && CircleTwoColourTwoAnswer;
        public bool CircleThreeTikSwitch => CircleThreeColourOneAnswer && CircleThreeColourTwoAnswer;

        //bool circleOneTikSwitch;
        //bool circleTwoTikSwitch;
        //bool circleThreeTikSwitch;

        //public bool CircleOneTikSwitch
        //{
        //    get { return CircleOneColourOneAnswer && CircleOneColourTwoAnswer; }
        //    set { SetProperty(ref circleOneTikSwitch, value); OnPropertyChanged(nameof(CircleOneCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        //}

        //public bool CircleTwoTikSwitch
        //{
        //    get { return CircleTwoColourOneAnswer && CircleTwoColourTwoAnswer; }
        //    set { SetProperty(ref circleTwoTikSwitch, value); OnPropertyChanged(nameof(CircleTwoCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        //}
        //public bool CircleThreeTikSwitch
        //{
        //    get { return CircleThreeColourOneAnswer && CircleThreeColourTwoAnswer; }
        //    set { SetProperty(ref circleThreeTikSwitch, value); OnPropertyChanged(nameof(CircleThreeCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        //}
        #endregion

        #region Circle Cross Binding Objects
        public bool CircleOneCrossSwitch => !CircleOneTikSwitch;
        public bool CircleTwoCrossSwitch => !CircleTwoTikSwitch;
        public bool CircleThreeCrossSwitch => !CircleThreeTikSwitch;
        #endregion

        #region Buttons Bindings
        public bool NextButtonSwitch => CircleOneTikSwitch && CircleTwoTikSwitch && CircleThreeTikSwitch;
        #endregion

        #region Commands-Declarations
        public Command<int> CircleOneColourOneSelectedCommand { get; }
        public Command<int> CircleOneColourTwoSelectedCommand { get; }
        public Command<int> CircleTwoColourOneSelectedCommand { get; }
        public Command<int> CircleTwoColourTwoSelectedCommand { get; }
        public Command<int> CircleThreeColourOneSelectedCommand { get; }
        public Command<int> CircleThreeColourTwoSelectedCommand { get; }
        public Command ShuffleCommand { get; }
        public Command NextLevelCommand { get; }
        #endregion

        #region Circle Individual Colours Answer Bindings
        bool circleOneColourOneAnswer = false;
        bool circleOneColourTwoAnswer = false;
        bool circleTwoColourOneAnswer = false;
        bool circleTwoColourTwoAnswer = false;
        bool circleThreeColourOneAnswer = false;
        bool circleThreeColourTwoAnswer = false;

        public bool CircleOneColourOneAnswer
        {
            get { return circleOneColourOneAnswer; }
            set { SetProperty(ref circleOneColourOneAnswer, value); OnPropertyChanged(nameof(CircleOneTikSwitch)); OnPropertyChanged(nameof(CircleOneCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleOneColourTwoAnswer
        {
            get { return circleOneColourTwoAnswer; }
            set { SetProperty(ref circleOneColourTwoAnswer, value); OnPropertyChanged(nameof(CircleOneTikSwitch)); OnPropertyChanged(nameof(CircleOneCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleTwoColourOneAnswer
        {
            get { return circleTwoColourOneAnswer; }
            set { SetProperty(ref circleTwoColourOneAnswer, value); OnPropertyChanged(nameof(CircleTwoTikSwitch)); OnPropertyChanged(nameof(CircleTwoCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleTwoColourTwoAnswer
        {
            get { return circleTwoColourTwoAnswer; }
            set { SetProperty(ref circleTwoColourTwoAnswer, value); OnPropertyChanged(nameof(CircleTwoTikSwitch)); OnPropertyChanged(nameof(CircleTwoCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleThreeColourOneAnswer
        {
            get { return circleThreeColourOneAnswer; }
            set { SetProperty(ref circleThreeColourOneAnswer, value); OnPropertyChanged(nameof(CircleThreeTikSwitch)); OnPropertyChanged(nameof(CircleThreeCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        public bool CircleThreeColourTwoAnswer
        {
            get { return circleThreeColourTwoAnswer; }
            set { SetProperty(ref circleThreeColourTwoAnswer, value); OnPropertyChanged(nameof(CircleThreeTikSwitch)); OnPropertyChanged(nameof(CircleThreeCrossSwitch)); OnPropertyChanged(nameof(NextButtonSwitch)); }
        }
        #endregion

        #region Constructor
        public PuzzleTwoTwoViewModel()
        {
            Title = "Puzzle 2.0 - Level 2";
            CircleOneColourOneSelectedCommand = new Command<int>(CircleOneColourOneSelected);
            CircleOneColourTwoSelectedCommand = new Command<int>(CircleOneColourTwoSelected);
            CircleTwoColourOneSelectedCommand = new Command<int>(CircleTwoColourOneSelected);
            CircleTwoColourTwoSelectedCommand = new Command<int>(CircleTwoColourTwoSelected);
            CircleThreeColourOneSelectedCommand = new Command<int>(CircleThreeColourOneSelected);
            CircleThreeColourTwoSelectedCommand = new Command<int>(CircleThreeColourTwoSelected);
            ShuffleCommand = new Command(ShufflePuzzle);
            NextLevelCommand = new Command(OnNextLevelClicked);
            random = new Random();
            InitializeTikSwitches();
            InitializeColoursLists();
            PopulateCircles();
        }
        #endregion

        #region Circle Selected Command Call Methods
        void CircleOneColourOneSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleOneColourOne))
                {
                    CircleOneColourOneAnswer = true;
                }
                else
                {
                    CircleOneColourOneAnswer = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleOneColourTwoSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleOneColourTwo))
                {
                    CircleOneColourTwoAnswer = true;
                }
                else
                {
                    CircleOneColourTwoAnswer = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleTwoColourOneSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleTwoColourOne))
                {
                    CircleTwoColourOneAnswer = true;
                }
                else
                {
                    CircleTwoColourOneAnswer = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleTwoColourTwoSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleTwoColourTwo))
                {
                    CircleTwoColourTwoAnswer = true;
                }
                else
                {
                    CircleTwoColourTwoAnswer = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleThreeColourOneSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleThreeColourOne))
                {
                    CircleThreeColourOneAnswer = true;
                }
                else
                {
                    CircleThreeColourOneAnswer = false;
                }
            }
            else
            {
                return;
            }
        }
        void CircleThreeColourTwoSelected(int selectedColourIndex)
        {
            if (selectedColourIndex != -1)
            {
                if (ColoursListHex[selectedColourIndex].Equals(CircleThreeColourTwo))
                {
                    CircleThreeColourTwoAnswer = true;
                }
                else
                {
                    CircleThreeColourTwoAnswer = false;
                }
            }
            else
            {
                return;
            }
        }

        #endregion



        #region Supplementary Methods
        void ShuffleColours()
        {
            coloursList.OrderBy(i => Guid.NewGuid()).ToList();
        }

        public ObservableRangeCollection<List<int>> PopulateCircles()
        {
            //Get to lists of three random numbers for colours
            List<int> randomNumbersOne = new List<int>();
            List<int> randomNumbersTwo = new List<int>();

            int count = 0;
            randomNumbersOne.Clear();
            randomNumbersTwo.Clear();

            while (count != 3)
            {
                int number = random.Next(8);

                if (randomNumbersOne.Contains(number))
                {
                    continue;
                }
                else
                {
                    randomNumbersOne.Add(number);
                    count++;
                }
            }

            count = 0;

            while (count != 3)
            {
                int number = random.Next(8);

                if (randomNumbersOne.Contains(number) || randomNumbersTwo.Contains(number))
                {
                    continue;
                }
                else
                {
                    randomNumbersTwo.Add(number);
                    count++;
                }
            }

            CircleOneColourOne = ColoursListHex[randomNumbersOne[0]];
            CircleOneColourTwo = coloursListHex[randomNumbersTwo[0]];
            CircleTwoColourOne = ColoursListHex[randomNumbersOne[1]];
            CircleTwoColourTwo = ColoursListHex[randomNumbersTwo[1]];
            CircleThreeColourOne = ColoursListHex[randomNumbersOne[2]];
            CircleThreeColourTwo = ColoursListHex[randomNumbersTwo[2]];

            ObservableRangeCollection<List<int>> randomNumberLists = new ObservableRangeCollection<List<int>>();
            randomNumberLists.Add(randomNumbersOne);
            randomNumberLists.Add(randomNumbersTwo);

            return randomNumberLists;
        }

        void InitializeTikSwitches()
        {
            CircleOneColourOneAnswer = false;
            CircleOneColourTwoAnswer = false;
            CircleTwoColourOneAnswer = false;
            CircleTwoColourTwoAnswer = false;
            CircleThreeColourOneAnswer = false;
            CircleThreeColourTwoAnswer = false;
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
            CircleOneColourOneSelectedString = null;
            CircleOneColourTwoSelectedString = null;
            CircleTwoColourOneSelectedString = null;
            CircleTwoColourTwoSelectedString = null;
            CircleThreeColourOneSelectedString = null;
            CircleThreeColourTwoSelectedString = null;
            CircleOneColourOneAnswer = false;
            CircleTwoColourOneAnswer = false;
            CircleThreeColourOneAnswer = false;
            CircleOneColourTwoAnswer = false;
            CircleTwoColourTwoAnswer = false;
            CircleThreeColourTwoAnswer = false;
        }

        private async void OnNextLevelClicked(object obj)
        {
            await Shell.Current.GoToAsync($"..");
        }
        #endregion
    }
}
