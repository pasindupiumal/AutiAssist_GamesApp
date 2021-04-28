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
    public partial class puzzle_A01_L03 : ContentPage
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



        public puzzle_A01_L03()
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
                ageCategory = Preferences.Get("userAgeCat", 3),
                selectedActivity = ActivityID
            };

            await ActivityService.TrainValues(activity);
        }
        #endregion




        #region RandomImage
        public ArrayList RandomImage()
        {
            Random newRandom = new Random();
            int boxes = 16;
            int increment = 0;

            newArray.Clear();
            ArrayList imageArray = new ArrayList();

            imageArray.Add("hse01.png");
            imageArray.Add("hse02.png");
            imageArray.Add("hse03.png");
            imageArray.Add("hse04.png");
            imageArray.Add("hse05.png");
            imageArray.Add("hse06.png");
            imageArray.Add("hse07.png");
            imageArray.Add("hse08.png");
            imageArray.Add("hse09.png");
            imageArray.Add("hse10.png");
            imageArray.Add("hse11.png");
            imageArray.Add("hse12.png");
            imageArray.Add("hse13.png");
            imageArray.Add("hse14.png");
            imageArray.Add("hse15.png");
            imageArray.Add("hse16.png");

            do
            {
                var value = imageArray[newRandom.Next(16)].ToString();

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
            img07.Source = newArray[6].ToString();
            img08.Source = newArray[7].ToString();
            img09.Source = newArray[8].ToString();
            img10.Source = newArray[9].ToString();
            img11.Source = newArray[10].ToString();
            img12.Source = newArray[11].ToString();
            img13.Source = newArray[12].ToString();
            img14.Source = newArray[13].ToString();
            img15.Source = newArray[14].ToString();
            img16.Source = newArray[15].ToString();

            // recentArray = newArray;

            return newArray;
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

            if (img01.Source.ToString().Replace("File: ", "") == "hse01.png")
            {
                completness += 1;
            }

            if (img02.Source.ToString().Replace("File: ", "") == "hse02.png")
            {
                completness += 1;
            }

            if (img03.Source.ToString().Replace("File: ", "") == "hse03.png")
            {
                completness += 1;
            }

            if (img04.Source.ToString().Replace("File: ", "") == "hse04.png")
            {
                completness += 1;
            }

            if (img05.Source.ToString().Replace("File: ", "") == "hse05.png")
            {
                completness += 1;
            }

            if (img06.Source.ToString().Replace("File: ", "") == "hse06.png")
            {
                completness += 1;
            }

            if (img07.Source.ToString().Replace("File: ", "") == "hse07.png")
            {
                completness += 1;
            }

            if (img08.Source.ToString().Replace("File: ", "") == "hse08.png")
            {
                completness += 1;
            }

            if (img09.Source.ToString().Replace("File: ", "") == "hse09.png")
            {
                completness += 1;
            }

            if (img10.Source.ToString().Replace("File: ", "") == "hse10.png")
            {
                completness += 1;
            }

            if (img11.Source.ToString().Replace("File: ", "") == "hse11.png")
            {
                completness += 1;
            }

            if (img12.Source.ToString().Replace("File: ", "") == "hse12.png")
            {
                completness += 1;
            }

            if (img13.Source.ToString().Replace("File: ", "") == "hse13.png")
            {
                completness += 1;
            }

            if (img14.Source.ToString().Replace("File: ", "") == "hse14.png")
            {
                completness += 1;
            }

            if (img15.Source.ToString().Replace("File: ", "") == "hse15.png")
            {
                completness += 1;
            }

            if (img16.Source.ToString().Replace("File: ", "") == "hse16.png")
            {
                completness += 1;
            }

            // Update the Progress Bar (Current Progress)
            // [ 1 / 16 = 0.0625 ]
            UpdateProgressBar(0.0625 * completness, 1000);

            if (completness == 16)
            {
                // Update the Progress Bar (Full Progress)
                UpdateProgressBar(1, 1000);

                // Call Pop-UP yes no Alert (Message)
                await OnAlertYesNoClicked(16, completness, "LEVEL COMPLETED!", "Would you like to play again?", "Yes", "No");
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
                //await Navigation.PushAsync(new game_menu());
                await Shell.Current.GoToAsync("..");
            }
        }
        #endregion




        #region PostResults
        void PostResults(int complete)
        {
            activityResult = complete;
        }
        #endregion




        #region Shuffle_Clicked
        private void Shuffle_Clicked(object sender, EventArgs e)
        {
            RandomImage();
            findComplete();
        }
        #endregion




        #region Finish_Clicked
        private async void Finish_Clicked(object sender, EventArgs e)
        {

            await OnAlertYesNoClicked(9, completness, "WARNING!", "Would you like to finish the game?", "No", "Yes");
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
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

        private void Tapped_img07(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 07-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[6].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 6;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[6].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[6] = firstClick;

                    img07.Source = newArray[6].ToString();
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

        private void Tapped_img08(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 08-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[7].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 7;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[7].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[7] = firstClick;

                    img08.Source = newArray[7].ToString();
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

        private void Tapped_img09(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 09-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[8].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 8;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[8].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[8] = firstClick;

                    img09.Source = newArray[8].ToString();
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

        private void Tapped_img10(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 10-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[9].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 9;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[9].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[9] = firstClick;

                    img10.Source = newArray[9].ToString();
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

        private void Tapped_img11(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 11-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[10].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 10;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[10].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[10] = firstClick;

                    img11.Source = newArray[10].ToString();
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

        private void Tapped_img12(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 12-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[11].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 11;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[11].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[11] = firstClick;

                    img12.Source = newArray[11].ToString();
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

        private void Tapped_img13(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 13-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[12].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 12;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[12].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[12] = firstClick;

                    img13.Source = newArray[12].ToString();
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

        private void Tapped_img14(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 14-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[13].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 13;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[13].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[13] = firstClick;

                    img14.Source = newArray[13].ToString();
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

        private void Tapped_img15(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 15-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[14].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 14;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[14].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[14] = firstClick;

                    img15.Source = newArray[14].ToString();
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

        private void Tapped_img16(object sender, EventArgs e)
        {
            // Increment click
            clickIncrement++;
            Console.WriteLine("----------IMAGE 16-----------");

            while (true)
            {
                if (clickIncrement == 1)
                {
                    // Save this box image to a varaible
                    firstClick = newArray[15].ToString();

                    // Save this boc array element position to a variable
                    previousChangeNumber = 15;

                    break;
                }

                if (clickIncrement == 2)
                {

                    // Save current image of this box
                    currentImage = newArray[15].ToString();

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
                    if (previousChangeNumber == 6)
                    {
                        img07.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 7)
                    {
                        img08.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 8)
                    {
                        img09.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 9)
                    {
                        img10.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 10)
                    {
                        img11.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 11)
                    {
                        img12.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 12)
                    {
                        img13.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 13)
                    {
                        img14.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 14)
                    {
                        img15.Source = newArray[previousChangeNumber].ToString();
                    }
                    if (previousChangeNumber == 15)
                    {
                        img16.Source = newArray[previousChangeNumber].ToString();
                    }

                    // Replace this current box image with first click image
                    // newArray.Insert(0, firstClick);
                    newArray[15] = firstClick;

                    img16.Source = newArray[15].ToString();
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