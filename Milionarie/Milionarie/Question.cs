using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionarie
{
    public class Question
    {
        public string questionText { get; set; }
        public AnswerA answerA { get; set; }
        public AnswerB answerB { get; set; }
        public AnswerC answerC { get; set; }
        public AnswerD answerD { get; set; }
        public CorrectAnswer correctAnswer { get; set; }
        public ChosenAnswer chosenAnswer { get; set; }

        public bool passed;

        public static Random rand = new Random();

        public Question(string qt,string aa,string ab,string ac,string ad,string ca)
        {
            questionText = qt;
            answerA = new AnswerA(aa);
            answerB = new AnswerB(ab);
            answerC = new AnswerC(ac);
            answerD = new AnswerD(ad);
            correctAnswer = new CorrectAnswer(ca);

            passed = false;

            answerA.NUMBER = rand.Next(1, 5);

            do {
                answerB.NUMBER = rand.Next(1, 5);
               } while (answerB.NUMBER == answerA.NUMBER);

            do
            {
                answerC.NUMBER = rand.Next(1, 5);
            } while (answerC.NUMBER == answerB.NUMBER || answerC.NUMBER == answerA.NUMBER);

            do
            {
                answerD.NUMBER = rand.Next(1, 5);
            } while (answerD.NUMBER == answerC.NUMBER || answerD.NUMBER == answerB.NUMBER || answerD.NUMBER == answerA.NUMBER);


            if (correctAnswer.correctAnswer == answerA.answerA)
                correctAnswer.NUMBER = answerA.NUMBER;
            else if (correctAnswer.correctAnswer == answerB.answerB)
                correctAnswer.NUMBER = answerB.NUMBER;
            else  if (correctAnswer.correctAnswer == answerC.answerC)
                correctAnswer.NUMBER = answerC.NUMBER;
            else if (correctAnswer.correctAnswer == answerD.answerD)
                correctAnswer.NUMBER = answerD.NUMBER;

        }

        public string getAnswerNumber(int number)
        {
            if (answerA.NUMBER == number)
                return answerA.answerA;
            else if (answerB.NUMBER == number)
                return answerB.answerB;
            else if (answerC.NUMBER == number)
                return answerC.answerC;
            else return answerD.answerD;
        }

        public bool IsAnswerRight()
        {
            return chosenAnswer.chosenAnswer == correctAnswer.correctAnswer;
        }

        public void joker5050()
        {
            while ((Game.JOCKER5050_1 = rand.Next(1, 5)) == correctAnswer.NUMBER || 
                (Game.JOCKER5050_2 = rand.Next(1, 5)) == correctAnswer.NUMBER || Game.JOCKER5050_2 == Game.JOCKER5050_1);
        }




    }
}
