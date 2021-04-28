using AutiAssist_MobileApp.Models;
using AutiAssist_MobileApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutiAssist_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class puzzle_A01_L01 : ContentPage
    {
        ArrayList recentArray = new ArrayList();
        ArrayList newArray = new ArrayList();
        int clickIncrement = 0;
        string firstClick, currentImage;
        int previousChangeNumber = 0;
        int completness = 0;

        // Activity ID
        // Game Number = 202

        int activityID = 202;
        int activityResult;



        public puzzle_A01_L01()
        {
            InitializeComponent();

            //TrainData();
            Task.Run(() => TrainData());
            RandomImage();
        }



        #region
        // Function for train most frequent activity (POST)
        async Task TrainData()
        {
            int ActivityID = activityID;

            var activity = new Activity
            {
                ageCategory = Preferences.Get("userAgeCat", 1),
                selectedActivity = ActivityID
            };

            await ActivityService.TrainValues(activity);
        }
        #endregion




        public ArrayList RandomImage()
        {
            Random newRandom = new Random();
            int boxes = 6;
            int increment = 0;

            newArray.Clear();
            ArrayList imageArray = new ArrayList();

            imageArray.Add("Rone.png");
            imageArray.Add("Rtwo.png");
            imageArray.Add("Rthree.png");
            imageArray.Add("Rfour.png");
            imageArray.Add("Rfive.png");
            imageArray.Add("Rsix.png");

            do
            {
                var value = imageArray[newRandom.Next(6)].ToString();

                if (newArray.Contains(value))
                {
                    continue;
                }
                else
                {
                    newArray.Add(value);
                    increment++;
                }

            }
            while (increment != boxes);


            img01.Source = newArray[0].ToString();
            img02.Source = newArray[1].ToString();
            img03.Source = newArray[2].ToString();
            img04.Source = newArray[3].ToString();
            img05.Source = newArray[4].ToString();
            img06.Source = newArray[5].ToString();

            findComplete();

            return newArray;
        }




        #region Finish_Clicked
        private void Shuffle_Clicked(object sender, EventArgs e)
        {
            RandomImage();
        }
        #endregion



        #region Finish_Clicked
        private async void Finish_Clicked(object sender, EventArgs e)
        {
            await OnAlertYesNoClicked(9, completness, "WARNING!", "Would you like to finish the game?", "No", "Yes");

        }
        #endregion




        // Function for Animated Progress Bar
        void UpdateProgressBar(double Progress, uint time)
        {
            progressBar.ProgressTo(Progress, time, Easing.Linear);
        }



        #region findComplete
        async void findComplete()
        {
            completness = 0;

            if (img01.Source.ToString().Replace("File: ", "") == "Rone.png")
            {
                completness += 1;
            }

            if (img02.Source.ToString().Replace("File: ", "") == "Rtwo.png")
            {
                completness += 1;
            }

            if (img03.Source.ToString().Replace("File: ", "") == "Rthree.png")
            {
                completness += 1;
            }

            if (img04.Source.ToString().Replace("File: ", "") == "Rfour.png")
            {
                completness += 1;
            }

            if (img05.Source.ToString().Replace("File: ", "") == "Rfive.png")
            {
                completness += 1;
            }

            if (img06.Source.ToString().Replace("File: ", "") == "Rsix.png")
            {
                completness += 1;
            }

            // Update the Progress Bar (Current Progress)
            // [ 1 / 6 = 0.166 ]
            UpdateProgressBar(0.166 * completness, 1000);

            if (completness == 6)
            {
                // Update the Progress Bar (Full Progress)
                UpdateProgressBar(1, 1000);

                // Call Pop-UP yes no Alert (Message)
                await OnAlertYesNoClicked(6, completness, "LEVEL COMPLETED!", "Would you like to play again?", "Yes", "No");
            }
        }
        #endregion




        #region OnAlertYesNoClicked
        // Yes or No Pop-Up message (alert)
        async Task OnAlertYesNoClicked(int boxes, int complete, string title, string desc, string firstBtn, string secondBtn)
        {

            bool answer = await DisplayAlert(title, desc, firstBtn, secondBtn);

            // User clicked 'Yes'
            if (answer)
            {
                RandomImage();
            }

            // User Clicked 'No'
            else
            {
                // Get activity ID and Activity Results
                if (complete != boxes)
                {
                    // Convert integer value to float and calculate precentage value of the score (Completaion)
                    float score = ((float)complete / boxes) * 100;

                    // Use 'Math.Round' to remove decimal points 
                    decimal ProcessedScore = Math.Round((decimal)score, 0);

                    // Pass final processed score percentage to to the functon
                    PostResults((int)ProcessedScore);
                }
                else
                {
                    PostResults(100);
                }

                // Go to main menu page
                await Shell.Current.GoToAsync("..");
                //await Navigation.PushAsync(new game_menu());
            }
        }
        #endregion





        #region PostResults
        void PostResults(int complete)
        {
            activityResult = complete;
        }
        #endregion




        private void Tapped_img01(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 01-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[0].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 0;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[0].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[0] = firstClick;

                    img01.Source = newArray[0].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }

        private void Tapped_img02(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 02-----------");

            while (true)
            {

                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[1].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 1;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[1].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(1, firstClick);
                    newArray[1] = firstClick;

                    img02.Source = newArray[1].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }

        private void Tapped_img03(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;

            Console.WriteLine("----------IMAGE 03-----------");

            while (true)
            {

                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[2].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 2;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[2].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(2, firstClick);
                    newArray[2] = firstClick;

                    img03.Source = newArray[2].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }

        private void Tapped_img04(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 04-----------");


            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[3].ToString();

                    // Save this box array element position to a variable
                    previousChangeNumber = 3;

                    break;
                }

                if (clickIncrement == 2)
                {
                    // Save current image of this box
                    currentImage = newArray[3].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(3, firstClick);
                    newArray[3] = firstClick;

                    img04.Source = newArray[3].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }

        private void Tapped_img05(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 05-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[4].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 4;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[4].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[4] = firstClick;

                    img05.Source = newArray[4].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }

        private void Tapped_img06(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 06-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[5].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 5;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[5].ToString();

                    // Replace first click box image with this box image
                    // newArray.Insert(previousChangeNumber, currentImage);
                    newArray[previousChangeNumber] = currentImage;

                    // Assign updated elements of the ArryList to the interface (Puzzle Boxes)
                    if (previousChangeNumber == 0)
                    {
                        img01.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 1)
                    {
                        img02.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 2)
                    {
                        img03.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 3)
                    {
                        img04.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 4)
                    {
                        img05.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 5)
                    {
                        img06.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[5] = firstClick;

                    img06.Source = newArray[5].ToString();
                    clickIncrement = 0;

                    break;
                }

                if (clickIncrement > 2)
                {
                    clickIncrement = 1;
                    continue;
                }
            }
            findComplete();
        }
    }
}