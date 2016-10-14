using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTeacher
{
    public class Word
    {
        IConnect save = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
        public string Add(string word, string translation)
        {
            throw new NotImplementedException();
        }
        
        public int GetActualWordId()
        {
            throw new NotImplementedException();
        }
        public int GetRandomId()
        {
            Random rand = new Random();
            return rand.Next(1, save.GetMaxId("Words"));
        }
        public string GetTranslation(int wordId)
        {
            return save.GetFieldValueById("Words", "translation", wordId);
        }
        public int GetWrongId(int wordId)
        {
            int countWords = save.GetMaxId("Words");
            if (countWords >= 2)
            {
                int randId = -1;
                for (int i = 0; i < countWords; i++)
                {
                    randId = GetRandomId();
                    if (randId != wordId)
                        break;
                }
                return randId;
            }
            else
                return -1;
        }
        public string GetWord(int wordId)
        {
            return save.GetFieldValueById("Words", "word", wordId);
        }
    }
}
