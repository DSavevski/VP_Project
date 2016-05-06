using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionarie
{
    public class AnswerA
    {
        public int NUMBER = 1;
        public bool hideFor5050;

        public string answerA { get; set; }

        public AnswerA(string a)
        {
            answerA = a;
            hideFor5050 = false;
        }
        

    }

    public class AnswerB
    {
        public int NUMBER = 2;
        public bool hideFor5050;

        public string answerB { get; set; }

        public AnswerB(string b)
        {
            answerB = b;
            hideFor5050 = false;
        }

    }

    public class AnswerC
    {

        public int NUMBER = 3;
        public bool hideFor5050;

        public string answerC { get; set; }

        public AnswerC(string c)
        {
            answerC = c;
            hideFor5050 = false;
        }

    }

    public class AnswerD
    {
        public bool hideFor5050;
        public int NUMBER = 4;

        public string answerD { get; set; }

        public AnswerD(string d)
        {
            answerD = d;
            hideFor5050 = false;
        }

    }

    public class CorrectAnswer
    {
        public int NUMBER;

        public string correctAnswer { get; set; }

        public CorrectAnswer(string ca)
        {
            correctAnswer = ca;
        }
    }

    public class ChosenAnswer
    {
        public string chosenAnswer { get; set; }

        public ChosenAnswer(string ca)
        {
            chosenAnswer = ca;
        }
    }
}
