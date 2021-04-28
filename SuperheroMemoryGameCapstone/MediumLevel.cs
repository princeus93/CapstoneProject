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
    public partial class MediumLevel : Form
    {
        public MediumLevel()
        {
            InitializeComponent();
        }

        bool allowClick = false;
        PictureBox firstGuess;
        readonly Random rnd = new Random();
        readonly Timer clickTimer = new Timer();
        int time = 60;
        readonly Timer timer = new Timer { Interval = 1000 };
        double guessCount = 0;
        double correctGuessCount = 0;


        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.CaptainMarvelNew,
                    Properties.Resources.NewSuperman,
                    Properties.Resources.NewArrow,
                    Properties.Resources.NewDeadpool,
                    Properties.Resources.NewGhostRider,
                    Properties.Resources.NewHulk,
                    Properties.Resources.NewHumanTorch,
                    Properties.Resources.NewPepper,
                };
            }
        }
        private void MessageBoxLoseGame()
        {

            string message = "Out of time! You scored: " + scoreLabel.Text +" points \n Would you like to try again?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                accuracyLabel.ResetText();
                label2.ResetText();
                scoreLabel.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            { 
                MediumLevel.ActiveForm.Close();
                MainMenu.ActiveForm.Show();
            }
        }

        //endgame textbox
        private void MessageBoxWinGame()
        {

            string message = "You WIN! You scored: " + scoreLabel.Text + " points \n Do you want to play again?";
            string title = "Game Won";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                accuracyLabel.ResetText();
                label2.ResetText();
                scoreLabel.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            {
                
                MediumLevel.ActiveForm.Close();
                MainMenu.ActiveForm.Show();
            }
        }
        //Game timer function
        private void StartGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBoxLoseGame();
                }

                var ssTime = TimeSpan.FromSeconds(time);

                label1.Text = "00: " + time.ToString();
            };
        }

        private void ResetImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            SetRandomImages();
            time = 60;
            timer.Start();
        }

        private void HideImages()
        {
                foreach (var pic in PictureBoxes)
                {
                    pic.Image = Properties.Resources.NewQuestionMark;
                }        
        }

        private PictureBox GetFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, PictureBoxes.Count());
            }
            while (PictureBoxes[num].Tag != null);
            return PictureBoxes[num];
        }

        private void SetRandomImages()
        {
            foreach (var image in Images)
            {
                GetFreeSlot().Tag = image;
                GetFreeSlot().Tag = image;
            }
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        public void DisplayGuessCount()
        {

            if (guessCount % 2 == 0)
            {
                label2.Text = (guessCount / 2).ToString();
            }
            else
            {
                return;
            }
        }

        private void DisplayAccuracy()
        {
            float cGCount = Convert.ToInt32( correctGuessCount);
            float gCount = Convert.ToInt32(guessCount);

            float accuracyOfPicks;

            if (cGCount < 1 || gCount < 1)
            {
                accuracyOfPicks = 0;
            }
            else if(gCount % 2 == 0)
            {
                accuracyOfPicks = (cGCount / gCount) * 2;
            }
            else { return; }
            accuracyLabel.Text = accuracyOfPicks.ToString("P", CultureInfo.InvariantCulture);     
        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            guessCount++;
            var pic = (PictureBox)sender;
            DisplayGuessCount();
            DisplayAccuracy();

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
                scoreLabel.Text = (correctGuessCount * 100).ToString();
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
            if (PictureBoxes.Any(p => p.Visible)) { return; }
            else { timer.Stop(); MessageBoxWinGame(); }
        }
        //Starts game
        private void StartGame(object sender, EventArgs e)
        {
            allowClick = true;
            SetRandomImages();
            HideImages();
            StartGameTimer();

            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;
        }   
    }
}