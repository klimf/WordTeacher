using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTeacher
{
    public class Session
    {
        Word word = new Word();
        Random rand = new Random();
        public int wrongAnswers;
        public int correctAnswers;
        public int correctIndex;
        public int correctId;
        public int userId;
        public Session(int id)
        {
            userId = id;
            wrongAnswers = 0;
            correctAnswers = 0;
            
        }
        public void Answer(bool correctOrNot)
        {
            if (correctOrNot == true)
                correctAnswers++;
            else
                wrongAnswers++;
        }
        public void Restart()
        {
            wrongAnswers = 0;
            correctAnswers = 0;
        }
        
        public string[] GetFourTranlations(int wordId)
        {
            correctIndex = rand.Next(0, 3);
            int[] arrayOfIndexes = new int[4] 
            {
                word.GetWrongId(wordId),
                word.GetWrongId(wordId),
                word.GetWrongId(wordId),
                word.GetWrongId(wordId)
            };
            arrayOfIndexes[correctIndex] = wordId;
            string[] arrayOfTranslations = new string[4]
            {
                word.GetTranslation(arrayOfIndexes[0]),
                word.GetTranslation(arrayOfIndexes[1]),
                word.GetTranslation(arrayOfIndexes[2]),
                word.GetTranslation(arrayOfIndexes[3])
            };
            return arrayOfTranslations;
        }
        public bool CheckAnswer(int index)
        {
            if (index == correctIndex)
            {
                User user = new User(userId);
                user.IncreaseWordsBlackListLevel(correctIndex);
                return true;
            }
            else
                return false;
        }
        public int Result(string type)
        {
            int all = correctAnswers + wrongAnswers;
            if (type == "wrong")
                return wrongAnswers;
            else if (type == "correct")
                return correctAnswers;
            else if (type == "all")
                return all;
            else if (type == "percent")
                return (correctAnswers * 100) / all;
            else
                return -1;
        }

    }
}
