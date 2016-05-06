using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milionarie
{
    public partial class Settings : Form
    {
        public Initial initial;

        public Settings()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        public Settings(Initial initial)
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            this.initial = initial;
            textBox7.Text = initial.easylist.Count.ToString();
            textBox8.Text = initial.mediumlist.Count.ToString();
            textBox9.Text = initial.hardlist.Count.ToString();
        }





        public void init()
        {
            listBox1.Items.Clear();
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "easy")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;

                    for (int i = 0; i < initial.easylist.Count; i++)
                        listBox1.Items.Add(initial.easylist.ElementAt(i));
                }
                if (comboBox1.SelectedItem.ToString() == "medium")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;


                    for (int i = 0; i < initial.mediumlist.Count; i++)
                        listBox1.Items.Add(initial.mediumlist.ElementAt(i));
                }

                if (comboBox1.SelectedItem.ToString() == "hard")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;


                    for (int i = 0; i < initial.hardlist.Count; i++)
                        listBox1.Items.Add(initial.hardlist.ElementAt(i));
                }
                textBox1.Clear();

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

               
            }

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Question a = listBox1.SelectedItem as Question;
            textBox1.Text = a.questionText;
            textBox2.Text = a.answerA.answerA;
            textBox3.Text = a.answerB.answerB;
            textBox4.Text = a.answerC.answerC;
            textBox5.Text = a.answerD.answerD;

            textBox6.Text = a.correctAnswer.correctAnswer;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Question a = listBox1.SelectedItem as Question;
            if (a != null)
            {
                textBox1.Text = a.questionText;
                textBox2.Text = a.answerA.answerA;
                textBox3.Text = a.answerB.answerB;
                textBox4.Text = a.answerC.answerC;
                textBox5.Text = a.answerD.answerD;

                textBox6.Text = a.correctAnswer.correctAnswer;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            init();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Question a = listBox1.SelectedItem as Question;
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "easy")
                {
                    initial.easylist.Remove(a);

                }
                if (comboBox1.SelectedItem.ToString() == "medium")
                {
                    initial.mediumlist.Remove(a);
                }

                if (comboBox1.SelectedItem.ToString() == "hard")
                {
                    initial.hardlist.Remove(a);
                }
                textBox1.Clear();
                init();
                initial.write();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DodadiPrasanje newQ = new DodadiPrasanje();
            if (newQ.ShowDialog() == DialogResult.OK)
            {
                if (comboBox1.SelectedItem != null) {
                    Question a = newQ.a;
                    if (comboBox1.SelectedItem.ToString() == "easy")
                    {
                        initial.easylist.Add(a);
                    }
                    if (comboBox1.SelectedItem.ToString() == "medium")
                    {
                        initial.mediumlist.Add(a);
                    }

                    if (comboBox1.SelectedItem.ToString() == "hard")
                    {
                        initial.hardlist.Add(a);
                    }
                    init();
                    initial.write();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initial.Show();
            Hide();
        }
    }
}
