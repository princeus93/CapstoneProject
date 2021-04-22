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
                    Properties.Resources.AntManNew,
                    Properties.Resources.CaptainAmericaNew,
                    Properties.Resources.CaptainMarvelNew,
                    Properties.Resources.ArrowNew,
                    Properties.Resources.IronmanNew,
                    Properties.Resources.DoctorStrangeNew,
                    Properties.Resources.BlackPantherNew,
                    Properties.Resources.NewVision
                };
            }
        }
        private void MessageBoxLoseGame()
        {

            string message = "Out of time! \n Would you like to try again?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                label3.ResetText();
                label2.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            {
                EasyLevel.ActiveForm.Close();
                new MainMenu().Show();
            }
        }

        //endgame textbox
        private void MessageBoxWinGame()
        {

            string message = "You WIN! \n Do you want to play again?";
            string title = "Game Won";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                label3.ResetText();
                label2.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            {
                EasyLevel.ActiveForm.Close();
                new MainMenu().Show();
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
                pic.Image = Properties.Resources.imgQuestionMark;
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
            label2.Text = (guessCount / 2).ToString();
        }

        private void DisplayAccuracy()
        {
            // NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            double cGCount = correctGuessCount;
            double gCount = guessCount;

            double accuracyOfPicks;

            if (cGCount < 1 || gCount < 1)
            {
                accuracyOfPicks = 0;
            }
            else
            {
                accuracyOfPicks = (cGCount / gCount) * 2;
            }
            label3.Text = accuracyOfPicks.ToString("P", CultureInfo.InvariantCulture);
            
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}