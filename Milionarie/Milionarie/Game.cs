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
    public partial class Game : Form
    {
        public static int JOCKER5050_1;
        public static int JOCKER5050_2;

        //na koe prasanje se naogjame
        public static int CURRENT_Q = 1;


        List<Question> easylist;
        List<Question> mediumlist;
        List<Question> hardlist;
        
        //za trepkanje zeleno pri tocen odgvoor
        bool blink = true;
        //counter za trepkanje vo timer
        int counter;
        //koe prasanje da trepka
        int whichBlink;
        //ako tocen odgovorot da se premine na sledno prasanje
        bool nextQ = true;

        int idx;
        int counterTick;
        Question q;
        public Game(List<Question> l1,List<Question>l2,List<Question> l3)
        {
            InitializeComponent();
            richTextBox1.Hide();
            chart1.Hide();


            easylist = new List<Question>(l1);
            mediumlist = new List<Question>(l2);
            hardlist = new List<Question>(l3);
           /*
            Question q11 = new Question("Proizvod od pcela ?", "Otok", "Med", "Mleko", "Sirenje","Med");
            Question q12 = new Question("PRVI 5-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q13 = new Question("PRVI 5-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q14 = new Question("PRVI 5-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q15 = new Question("PRVI 5-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q21 = new Question("PRVI 10-1", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q22 = new Question("PRVI 10-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q23 = new Question("PRVI 10-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q24 = new Question("PRVI 10-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q25 = new Question("PRVI 10-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q31 = new Question("PRVI 15-1", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q32 = new Question("PRVI 15-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q33 = new Question("PRVI 15-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q34 = new Question("PRVI 15-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q35 = new Question("PRVI 15-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            easylist.Add(q11);
            easylist.Add(q12);
            easylist.Add(q13);
            easylist.Add(q14);
            easylist.Add(q15);
            mediumlist.Add(q21);
            mediumlist.Add(q22);
            mediumlist.Add(q23);
            mediumlist.Add(q24);
            mediumlist.Add(q25);
            hardlist.Add(q31);
            hardlist.Add(q32);
            hardlist.Add(q33);
            hardlist.Add(q34);
            hardlist.Add(q35);
            */
            listBox1.SelectedIndex = 16 - CURRENT_Q;

            idx = Question.rand.Next(0, 5);
            q = easylist.ElementAt(idx);
            shuffleAnswers();
            q.joker5050();


        }

        public void shuffleAnswers()
        {
            button22.Text = q.questionText;
            button1.Text = q.getAnswerNumber(1);
            button2.Text = q.getAnswerNumber(2);
            button3.Text = q.getAnswerNumber(3);
            button4.Text = q.getAnswerNumber(4);
            q.passed = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot - Copy.jpg");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string text = button1.Text;
                checkAnswer(text,1);
            }
            else
            {
                button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot - Copy.jpg");

            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string text = button2.Text;
                checkAnswer(text,2);
            }
            else
            {
                button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot - Copy.jpg");
            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string text = button3.Text;
                checkAnswer(text,3);
            }
            else
            {
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot - Copy.jpg");
            FinalAnswer finalANswer = new FinalAnswer();
            if (finalANswer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string text = button4.Text;
                checkAnswer(text,4);
            }
            else
            {
                button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
            }
        }

        //sledno prasanje
        public Question getQuestion()
        {   
            if (CURRENT_Q <= 5)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, easylist.Count);
                    q = easylist.ElementAt(idx);

                    if (q.passed == false)
                    {
                        return q;
                    }
                }

            }
            else if (CURRENT_Q > 5 && CURRENT_Q <= 10)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, 5);
                    q = mediumlist.ElementAt(idx);

                    if (q.passed == false)
                    {
                        return q;
                    }
                }

            }
            else
            {
                while (true)
                {
                    idx = Question.rand.Next(0, 5);
                    q = hardlist.ElementAt(idx);

                    if (q.passed == false)
                    {
                        return q;
                    }
                }

            }

        }

       
        public void checkAnswer(string buttonText,int whichButton)
        {
            q.chosenAnswer = new ChosenAnswer(buttonText);
           
            if (q.IsAnswerRight())
            {
                whichBlink = whichButton;             
            }
            //ako ne e tocen selektiraniot odgovor da pocne da trepka (zeleno) tocniot odgovor
            else {

                if (button1.Text == q.correctAnswer.correctAnswer) {
                    whichBlink = 1;

                }
                else
                if (button2.Text == q.correctAnswer.correctAnswer)
                {
                    whichBlink = 2;

                }
                else
                if(button3.Text == q.correctAnswer.correctAnswer) {

                    whichBlink = 3;
                }
                else
                    if (button4.Text == q.correctAnswer.correctAnswer)
                {

                    whichBlink = 4;
                }

                
                nextQ = false;
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
               // if (listBox1.SelectedIndex == 1)
                    //money = "you won 1 000 000 $";

                button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");

                CURRENT_Q++;
                if(CURRENT_Q == 16)
                {
                    money = "You won a million !";
                    GameOver gameover = new GameOver(money);
                    gameover.ShowDialog();
                    return;
                }
                q = getQuestion();
                shuffleAnswers();
                q.joker5050();
                listBox1.SelectedIndex = 16 - CURRENT_Q;
            }
            //da ostane zeleno tocnoto prasanje
            else {
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else
                    button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");

               

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
                        money += "             1000";


                    }
                    else if (CURRENT_Q <= 15) {
                        money += "           32000";
                    }
                        money += " $";
                }
                else if(listBox1.SelectedIndex == 15) {
                    money = null;
                    money = "Sorry, You won nothing";
                }
                
                GameOver gameover = new GameOver(money);
                gameover.ShowDialog();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 16 - CURRENT_Q;
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
            }

            if ((int)char.GetNumericValue(button2.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button2.Name[6]) == JOCKER5050_2)
            {
                button2.Text = "";
            }

            if ((int)char.GetNumericValue(button3.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button3.Name[6]) == JOCKER5050_2)
            {
                button3.Text = "";
            }

            if ((int)char.GetNumericValue(button4.Name[6]) == JOCKER5050_1 || (int)char.GetNumericValue(button4.Name[6]) == JOCKER5050_2)
            {
                button4.Text = "";
            }
            button11.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (blink)
            {
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
                else if (whichBlink == 4)
                    button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\Green3.jpg");
            }else
            {
                if (whichBlink == 1)
                    button1.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                else if (whichBlink == 2)
                    button2.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                else if (whichBlink == 3)
                    button3.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");
                else if (whichBlink == 4)
                    button4.BackgroundImage = Image.FromFile("C:\\Users\\Dragan\\Desktop\\SelectedVsNot.jpg");              
            }

            blink = !blink;
            if (counter == 1)
            {
              
                timer1.Stop();
                checkAnswerAfterTimer();
               
            }
            counter++;
        }

        //povikaj publika
        private void button13_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            q.audience();
           // int[] yValues = {25,50,75,100 }; // Here y values is related to display three month values
           // string[] xValues = { "A", "B", "C","D" };
           // chart1.Series["Audience"].Points.DataBindY(yValues);

            this.chart1.Series["Audience"].Points.AddXY("A",Question.votes[0]);
            this.chart1.Series["Audience"].Points.AddXY("B",Question.votes[1]);
            this.chart1.Series["Audience"].Points.AddXY("C",Question.votes[2]);
            this.chart1.Series["Audience"].Points.AddXY("D",Question.votes[3]);
            chart1.Show();
            button13.Hide();
        }
        //povikaj prijatel
        private void button12_Click(object sender, EventArgs e)
        {

             counterTick = -5;
           
            richTextBox1.Text = "Calling Friend \n";

            richTextBox1.Show();
            timer2.Start();
            timer2.Enabled = true;


            //String a = String.Format("{0}\n{1}\n{2}\n{3}\n{4}", q.questionText, q.answerA.answerA, q.answerB.answerB, q.answerC.answerC, q.answerD.answerD);
            //richTextBox1.Text += a;
           // richTextBox1.Show();
           button12.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (counterTick == -4)
            {
                richTextBox1.Text = "Calling Friend . \n";
            }

            if (counterTick == -3)
            {
                richTextBox1.Text = "Calling Friend .. \n";
            }
            if (counterTick == -2)
            {
                richTextBox1.Text = "Calling Friend ...\n";
            }

            if (counterTick == -1)
            {
                richTextBox1.Text = "Calling Friend \n";
            }


            if (counterTick == 0)
            {
                richTextBox1.Text = "Calling Friend . \n";
            }

            if (counterTick == 1)
            {
                richTextBox1.Text = "Calling Friend .. \n";
            }
            if (counterTick == 2)
            {
                richTextBox1.Text = "Calling Friend ...\n";
            }







            if (counterTick == 3)
            {
                richTextBox1.Text = "Calling Friend \n";
            }
          
            if (counterTick == 4)
            {
                String a = String.Format("\nI have a question for you and I have 30 seconds.\n");
                richTextBox1.Text += a;

            }

            if (counterTick == 8)
            {
                String a = String.Format("\n{0}\n\n", q.questionText);
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
                String a = q.callingFriend();
                richTextBox1.Text += a;


                timer2.Stop();           }



            else counterTick++;

        }
    }
}
