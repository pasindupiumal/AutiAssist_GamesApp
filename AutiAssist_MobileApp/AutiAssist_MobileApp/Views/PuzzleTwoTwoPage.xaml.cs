using AutiAssist_MobileApp.ViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutiAssist_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleTwoTwoPage : ContentPage
    {
        PuzzleTwoTwoViewModel puzzleTwoTwoViewModel;
        public PuzzleTwoTwoPage()
        {
            InitializeComponent();

            BindingContext = puzzleTwoTwoViewModel = new PuzzleTwoTwoViewModel();

            fillCircles();
        }

        void fillCircles()
        {
            ObservableRangeCollection<List<int>> randomNumbers = puzzleTwoTwoViewModel.PopulateCircles();
            List<int> randomNumbersOne = randomNumbers[0];
            List<int> randomNumbersTwo = randomNumbers[1];

            List<Color> coloursListHex = new List<Color>()
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

            Console.WriteLine("Random Numbers List One");

            foreach (int number in randomNumbersOne)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\n\nRandom Numbers List Two");

            foreach (int number in randomNumbersTwo)
            {
                Console.WriteLine(number);
            }

            GradientStop gradientStopOne = new GradientStop();
            gradientStopOne.Offset = 0.1F;
            gradientStopOne.Color = coloursListHex[randomNumbersOne[0]];
            GradientStop gradientStopTwo = new GradientStop();
            gradientStopTwo.Offset = 1.0F;
            gradientStopTwo.Color = coloursListHex[randomNumbersTwo[0]];
            GradientStopCollection gradientStopCollectionOne = new GradientStopCollection();
            gradientStopCollectionOne.Add(gradientStopOne);
            gradientStopCollectionOne.Add(gradientStopTwo);
            ColourCircleOne.GradientStops = gradientStopCollectionOne;

            GradientStop gradientStopThree = new GradientStop();
            gradientStopThree.Offset = 0.1F;
            gradientStopThree.Color = coloursListHex[randomNumbersOne[1]];
            GradientStop gradientStopFour = new GradientStop();
            gradientStopFour.Offset = 1.0F;
            gradientStopFour.Color = coloursListHex[randomNumbersTwo[1]];
            GradientStopCollection gradientStopCollectionTwo = new GradientStopCollection();
            gradientStopCollectionTwo.Add(gradientStopThree);
            gradientStopCollectionTwo.Add(gradientStopFour);
            ColourCircleTwo.GradientStops = gradientStopCollectionTwo;

            GradientStop gradientStopFive = new GradientStop();
            gradientStopFive.Offset = 0.1F;
            gradientStopFive.Color = coloursListHex[randomNumbersOne[2]];
            GradientStop gradientStopSix = new GradientStop();
            gradientStopSix.Offset = 1.0F;
            gradientStopSix.Color = coloursListHex[randomNumbersTwo[2]];
            GradientStopCollection gradientStopCollectionThree = new GradientStopCollection();
            gradientStopCollectionThree.Add(gradientStopFive);
            gradientStopCollectionThree.Add(gradientStopSix);
            ColourCircleThree.GradientStops = gradientStopCollectionThree;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            fillCircles();
            puzzleTwoTwoViewModel.ShuffleCommand.Execute(null);
        }
    }
}