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
    public partial class Game : Form
    {
        public static int JOCKER5050_1;
        public static int JOCKER5050_2;

        int curq;
        Question q;
        public Game()
        {
            InitializeComponent();
            curq = 1;
            q = new Question("Kolku e 2+2", "1", "2", "3", "4", "4");
            shuffleAnswers();
            q.joker5050();
            button22.Text = q.questionText;
            
        }

        public void shuffleAnswers()
        {
            button1.Text = q.getAnswerNumber(1);
            button2.Text = q.getAnswerNumber(2);
            button3.Text = q.getAnswerNumber(3);
            button4.Text = q.getAnswerNumber(4);
        }

        
        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

      
        private void button6_Click(object sender, EventArgs e)
        {
          
        }
        private void button7_Click(object sender, EventArgs e)
        {
            
        }

     

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 16 - curq;
        }

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
        }
    }
}
