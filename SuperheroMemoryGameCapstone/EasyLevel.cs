using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace SuperheroMemoryGame_1_
{
    public partial class EasyLevel : Form
    {
        public EasyLevel()
        {
            InitializeComponent();
        }

        bool allowClick = false;
        PictureBox firstGuess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer { Interval = 1000 };
        double guessCount = 0;
        double correctGuessCount = 0;

        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    
                    Properties.Resources.imgBatman,
                    Properties.Resources.imgCaptainAmerica,
                    Properties.Resources.imgFlash,
                    Properties.Resources.imgGreenLantern,
                    Properties.Resources.imgIronMan,
                    Properties.Resources.imgRobin,
                    //Properties.Resources.imgSpiderman,
                    //Properties.Resources.imgSuperman

                };
            }
        }
        //Game timer function
        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Out of time");
                    ResetImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);

                label1.Text = "00: " + time.ToString();
            };
        }
        
        

        private void ResetImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
            
        }

        private void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.imgQuestionMark;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, pictureBoxes.Count());
            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }

        private void setRandomImages()
        {
                //do
               // {
                    foreach (var image in images)
                    {
                        getFreeSlot().Tag = image;
                        getFreeSlot().Tag = image;
                    }
               // } while (getFreeSlot().Tag == null);

            /*foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }*/
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        //endgame textbox
        private void MessageBoxEndGame()
        {
            
            string message = "Do you want to play again?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
            } else if (result == DialogResult.No)
            {

                EasyLevel.ActiveForm.Close();
                new mainMenu().Show(); 
            }
        }

        public void displayGuessCount()
        {
            double gCount = guessCount;
            if (gCount % 2 == 0)
            {
                gCount = gCount / 2;
                label2.Text = gCount.ToString();
            }
            else
            {
                return;
            }
           // label2.Text = guessCount.ToString(); 
        }

        private void displayAccuracy()
        {
            // NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            double cGCount = correctGuessCount;
            double gCount = guessCount /2;

            double accuracyOfPicks;

            //totalPicks = guessCount;
            // correctPicks = correctGuessCount;
            if (cGCount < 1 || gCount < 1)
            {
                accuracyOfPicks = 0;
            }
            else
            {
                accuracyOfPicks = cGCount / gCount;
            }
            label3.Text = accuracyOfPicks.ToString("P", CultureInfo.InvariantCulture);
            //return accuracyOfPicks;
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            guessCount++;
            var pic = (PictureBox)sender;
            displayGuessCount();
            displayAccuracy();
            
            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;
            
           
            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                correctGuessCount++;
                label4.Text = correctGuessCount.ToString();
                pic.Visible = firstGuess.Visible = false;
               
                {
                    firstGuess = pic;
                    
                }
   
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
                
            }

            
            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) { return; }
            else { timer.Stop(); MessageBoxEndGame(); }
            
            //UPdate message box to give options
            //MessageBox.Show("You Win! Now Try Again?");
            //MessageBoxEndGame();
            
            
            //ResetImages();
            
        }


        //Starts game
        private void startGame(object sender, EventArgs e)
        {
           
            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            // Accuracy();

            
            
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;

        }

        
    }
}
