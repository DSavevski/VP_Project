using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Milionarie
{
    enum AnswerSongMode
    {
        Wrong,
        Right,
        Select
    }
    public partial class Game : Form
    {
        
        /// <summary>
        /// Shows which question we are currently on
        /// </summary>
        public static int CURRENT_Q = 1;
        /// <summary>
        /// Background music player
        /// </summary>
        public WMPLib.WindowsMediaPlayer bg = new WMPLib.WindowsMediaPlayer();
        /// <summary>
        /// answer music
        /// </summary>
        public WMPLib.WindowsMediaPlayer answer = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer audFriend = new WMPLib.WindowsMediaPlayer();
        /// <summary>
        /// list of easy questions
        /// </summary>
        List<Question> easylist;
        /// <summary>
        /// medium list questions
        /// </summary>
        List<Question> mediumlist;
        /// <summary>
        /// hard list questions
        /// </summary>
        List<Question> hardlist;
        
       bool blink = true; //za trepkanje zeleno pri tocen odgvoor
       int counter; //counter za trepkanje vo timer
       int whichBlink; //koe prasanje da trepka
       bool nextQ = true;//ako tocen odgovorot da se premine na sledno prasanje
       public static int JOCKER5050_1;
       public static int JOCKER5050_2;
       int idx;
       int counterTick;

        /// <summary>
        /// Current questions, the question currently displayed
        /// </summary>
        Question currentQuestion;

        public Game(List<Question> l1,List<Question>l2,List<Question> l3)
        {
            InitializeComponent();
            richTextBox1.Hide();
            chart1.Hide();
            audFriend.settings.setMode("loop", true);

            playBackgroundSong(1);

            easylist = new List<Question>(l1);
            mediumlist = new List<Question>(l2);
            hardlist = new List<Question>(l3);
         
            listBox1.SelectedIndex = 16 - CURRENT_Q;

            //idx = Question.rand.Next(0, l1.Count);
            //currentQuestion = easylist.ElementAt(idx);
            currentQuestion = getQuestion();
            shuffleAnswers();
            currentQuestion.joker5050();
        }

        private void playBackgroundSong(int level)
        {
            bg.settings.setMode("loop", true);

                if (level == 1) 
                bg.URL = "stufe_1.mp3";
                else if(level == 2)
                bg.URL = "stufe_2.mp3";
                else if(level == 3)
                bg.URL = "stufe_3.mp3";
              
        }

        private void playAnswerSong(AnswerSongMode mode,int level)
        {
            answer.settings.setMode("loop", false);

            if (mode == AnswerSongMode.Right)
            {
                if(level == 1)
                    answer.URL = "rightanswer.mp3";
                else if (level == 4)             
                    answer.URL = "50_50.mp3";
                else
                    answer.URL = "rightanswer2.mp3";
            }
            else if(mode == AnswerSongMode.Wrong)
            {
                answer.URL = "falsch.mp3";
            }else if(mode == AnswerSongMode.Select)
            {
                answer.URL = "select.mp3";
            }
            

        }

        public void shuffleAnswers()
        {
            button22.Text = currentQuestion.questionText;
            button1.Text = currentQuestion.getAnswerNumber(1);
            button2.Text = currentQuestion.getAnswerNumber(2);
            button3.Text = currentQuestion.getAnswerNumber(3);
            button4.Text = currentQuestion.getAnswerNumber(4);
            currentQuestion.passed = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile("SelectedVsNot - Copy.jpg");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == DialogResult.OK)
            {
                string text = button1.Text;
                checkAnswer(text,1);
            }
            else
            {
                button1.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile("SelectedVsNot - Copy.jpg");

            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == DialogResult.OK)
            {
                string text = button2.Text;
                playAnswerSong(AnswerSongMode.Select, currentQuestion.level);
                checkAnswer(text,2);
            }
            else
            {
                button2.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackgroundImage = Image.FromFile("SelectedVsNot - Copy.jpg");
            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == DialogResult.OK)
            {
                string text = button3.Text;
                checkAnswer(text,3);
            }
            else
            {
                button3.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackgroundImage = Image.FromFile("SelectedVsNot - Copy.jpg");
            FinalAnswer finalANswer = new FinalAnswer();
            
            if (finalANswer.ShowDialog() == DialogResult.OK)
            {
                string text = button4.Text;
                checkAnswer(text,4);
            }
            else
            {
                button4.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
            }
        }

        /// <summary>
        /// Gets the next question.
        /// </summary>
        /// <returns>Question
        /// </returns>
        public Question getQuestion()
        {   
            if (CURRENT_Q <= 5)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, easylist.Count);
                    currentQuestion = easylist.ElementAt(idx);
                    currentQuestion.level = 1;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }
            else if (CURRENT_Q > 5 && CURRENT_Q <= 10)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, mediumlist.Count);
                    
                    currentQuestion = mediumlist.ElementAt(idx);
                    currentQuestion.level = 2;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }
            else
            {
                while (true)
                {
                    idx = Question.rand.Next(0, hardlist.Count);
                    
                    currentQuestion = hardlist.ElementAt(idx);
                    currentQuestion.level = 3;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }

        }

       
        public void checkAnswer(string buttonText,int whichButton)
        {
            currentQuestion.chosenAnswer = new ChosenAnswer(buttonText);
           
            if (currentQuestion.IsAnswerRight())
            {
                whichBlink = whichButton;
                playAnswerSong(AnswerSongMode.Right, currentQuestion.level);             
            }
            
            else { //ako ne e tocen selektiraniot odgovor da pocne da trepka (zeleno) tocniot odgovor

                if (button1.Text == currentQuestion.correctAnswer.correctAnswer) {
                    whichBlink = 1;

                }
                else
                if (button2.Text == currentQuestion.correctAnswer.correctAnswer)
                {
                    whichBlink = 2;

                }
                else
                if(button3.Text == currentQuestion.correctAnswer.correctAnswer) {

                    whichBlink = 3;
                }
                else
                    if (button4.Text == currentQuestion.correctAnswer.correctAnswer)
                {

                    whichBlink = 4;
                }

                
                nextQ = false;
                playAnswerSong(AnswerSongMode.Wrong, currentQuestion.level);
            }

            counter = 0;
            timer1.Start();
            timer1.Enabled = true;

        }

        public void checkAnswerAfterTimer()
        {
            chart1.Hide();
            richTextBox1.Hide();
            string money = "";
            if (nextQ)
            {
                button1.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                button2.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                button3.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                button4.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");

                CURRENT_Q++;
                if(CURRENT_Q == 16)
                {
                    money = "Вие сте милионер !!!";
                    GameOver gameover = new GameOver(money);
                    bg.URL = "winner.mp3";
                    gameover.ShowDialog();
                    
                    return;
                }

                if(CURRENT_Q == 6)
                {
                    answer.URL = "transition.mp3";
                    bg.controls.stop();
                    MessageBox.Show("Освоивте 5000 $");
                }
                if(CURRENT_Q == 11)
                {
                    answer.URL = "transition.mp3";
                    bg.controls.stop();
                    MessageBox.Show("Браво, освоивте 32000 $");
                }

                currentQuestion = getQuestion();
                shuffleAnswers();
                currentQuestion.joker5050();
                listBox1.SelectedIndex = 16 - CURRENT_Q;
            }
            
            else { //da ostane zeleno tocnoto prasanje
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("Green3.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("Green3.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("Green3.jpg");
                else
                    button4.BackgroundImage = Image.FromFile("Green3.jpg");

               

                if (listBox1.SelectedIndex + 1 <= 15)
                {
                    int idx = listBox1.SelectedIndex;
                    idx += 1;
                    if (CURRENT_Q < 6)
                    {
                        money += "Sorry, You won nothing";
                    }
                    else if (CURRENT_Q > 5 && CURRENT_Q < 11)
                    {
                        money += "Congratz, You won 1000 $";


                    }
                    else if (CURRENT_Q <= 15) {
                        money += "Congratz, You won 32000 $";
                    }
                        
                }
                else if(listBox1.SelectedIndex == 15) {
                    money = null;
                    money = "Sorry, You won nothing";
                }
                
                GameOver gameover = new GameOver(money);
                bg.controls.stop();
                gameover.ShowDialog();
            }
        }

        private void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 16 - CURRENT_Q;
            enableButtons();
            
            if(CURRENT_Q == 6)
            {
                playBackgroundSong(2);
                timer2.Interval = 1200;
            }
            if(CURRENT_Q == 11)
            {
                playBackgroundSong(3);
                timer2.Interval = 1200;
            }
            
        }

        //zolto selektiranje
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Orange);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        //50-50 joker
        private void button11_Click_1(object sender, EventArgs e)
        {
           
 
            if ( (int)char.GetNumericValue(button1.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button1.Name[6]) == JOCKER5050_2)
            {
                button1.Text = "";
                button1.Enabled = false;
                currentQuestion.answerA.hideFor5050 = true;
            }

            if ((int)char.GetNumericValue(button2.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button2.Name[6]) == JOCKER5050_2)
            {
                button2.Enabled = false;
                button2.Text = "";
                currentQuestion.answerB.hideFor5050 = true;
            }

            if ((int)char.GetNumericValue(button3.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button3.Name[6]) == JOCKER5050_2)
            {
                button3.Text = "";
                button3.Enabled = false;
                currentQuestion.answerC.hideFor5050 = true;
            }

            if ((int)char.GetNumericValue(button4.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button4.Name[6]) == JOCKER5050_2)
            {
                button4.Text = "";
                button4.Enabled = false;
                currentQuestion.answerD.hideFor5050 = true;

            }
            playAnswerSong(AnswerSongMode.Right, 4);
            button11.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (blink)
            {
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("Green3.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("Green3.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("Green3.jpg");
                else if (whichBlink == 4)
                    button4.BackgroundImage = Image.FromFile("Green3.jpg");
            }else
            {
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");
                else if (whichBlink == 4)
                    button4.BackgroundImage = Image.FromFile("SelectedVsNot.jpg");              
            }

            blink = !blink;
            if (counter == 5)
            {
              
                timer1.Stop();
                checkAnswerAfterTimer();
               
            }
            counter++;
        }

        //povikaj publika
        private void button13_Click(object sender, EventArgs e)
        {
            audFriend.settings.setMode("loop", false);
            audFriend.URL = "aud.mp3";
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            richTextBox1.Hide();
            currentQuestion.audience();
            if(!currentQuestion.answerA.hideFor5050)
                chart1.Series["Audience"].Points.AddXY("A",Question.votes[0]);
            if (!currentQuestion.answerB.hideFor5050)
                chart1.Series["Audience"].Points.AddXY("B",Question.votes[1]);
            if (!currentQuestion.answerC.hideFor5050)
                chart1.Series["Audience"].Points.AddXY("C",Question.votes[2]);
            if (!currentQuestion.answerD.hideFor5050)
                chart1.Series["Audience"].Points.AddXY("D",Question.votes[3]);
            chart1.Show();

            button13.Hide();
        }
        //povikaj prijatel
        private void button12_Click(object sender, EventArgs e)
        {
            counterTick = -5;
            richTextBox1.Text = "Ѕвони на пријател \n";
            richTextBox1.Show();
            chart1.Hide();
            timer2.Start();
            audFriend.settings.setMode("loop", true);
            audFriend.URL = "friend.mp3";
            timer2.Enabled = true;
            button12.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (counterTick == -4)
            {
                richTextBox1.Text = "Ѕвони на пријател . \n";
            }

            if (counterTick == -3)
            {
                richTextBox1.Text = "Ѕвони на пријател .. \n";
            }
            if (counterTick == -2)
            {
                richTextBox1.Text = "Ѕвони на пријател ...\n";
            }

            if (counterTick == -1)
            {
                richTextBox1.Text = "Ѕвони на пријател \n";
            }


            if (counterTick == 0)
            {
                richTextBox1.Text = "Ѕвони на пријател . \n";
            }

            if (counterTick == 1)
            {
                richTextBox1.Text = "Ѕвони на пријател .. \n";
            }
            if (counterTick == 2)
            {
                richTextBox1.Text = "Ѕвони на пријател ...\n";
            }

            if (counterTick == 3)
            {
                richTextBox1.Text = "Ѕвони на пријател \n";
            }
          
            if (counterTick == 4)
            {
                String a = String.Format("\nИмам прашање и 30 секунди, слушај добро\n");
                richTextBox1.Text += a;

            }

            if (counterTick == 8)
            {
                String a = String.Format("\n{0}\n\n", currentQuestion.questionText);
                richTextBox1.Text += a;

            }
            if(counterTick == 10)
            {
                String a = String.Format("{0}\n",button1.Text);
                richTextBox1.Text += a;


            }
            if (counterTick == 12)
            {
                String a = String.Format("{0}\n", button2.Text);
                richTextBox1.Text += a;

            }
            if (counterTick == 14)
            {

                String a = String.Format("{0}\n", button3.Text);
                richTextBox1.Text += a;
            }

                if (counterTick == 16)
                {
                    String a = String.Format("{0}\n\n", button4.Text);
                    richTextBox1.Text += a;
                }
            if (counterTick == 22) {
                String a = currentQuestion.callingFriend();
                richTextBox1.Text += a;
                audFriend.controls.stop();
                timer2.Stop();
            }
            else counterTick++;

        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
