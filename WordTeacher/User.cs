using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTeacher
{
    public class User
    {
        IConnect save = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
        ArrayInString ais = new ArrayInString();
        public int userId;
        public int maxElems = 100;
        public User(int id)
        {
            userId = id;
        }
        public int IncreaseWordsBlackListLevel(int wordId)
        {
            int[] idsArray = ais.GetIntArrayFromString(save.GetFieldValueById("Users", "wordIds", userId));
            int[] levelsArray = ais.GetIntArrayFromString(save.GetFieldValueById("Users", "wordLevels", userId));
            int[] newIdsArray = new int[idsArray.Length+1];
            int[] newLevelsArray = new int[levelsArray.Length+1];
            if (GetWordsBlackList().Contains(wordId))
            {
                int levelOfWord = levelsArray[ais.GetIndexOfElement(idsArray, wordId)]++;
                save.SetFieldValueById("Users", userId, "wordIds", ais.SetIntArrayToString(idsArray));
                save.SetFieldValueById("Users", userId, "wordLevels", ais.SetIntArrayToString(levelsArray));
                return levelOfWord;
            }
            else
            {
                newIdsArray[idsArray.Length] = wordId;
                newLevelsArray[levelsArray.Length] = 1;
                save.SetFieldValueById("Users", userId, "wordIds", ais.SetIntArrayToString(newIdsArray));
                save.SetFieldValueById("Users", userId, "wordLevels", ais.SetIntArrayToString(newLevelsArray));
                return 1;
            }
        }
        public int[] GetWordsBlackList()
        {
            int[] idsArray = ais.GetIntArrayFromString(save.GetFieldValueById("Users", "wordIds", userId));
            int[] levelsArray = ais.GetIntArrayFromString(save.GetFieldValueById("Users", "wordLevels", userId));
            int[] blacklistArray = new int[maxElems];
            if (idsArray.Length == levelsArray.Length)
            {
                int j = 0;
                for (int i = 0; i < levelsArray.Length; i++)
                {
                    if(levelsArray[i]>=3)
                    {
                        blacklistArray[j] = idsArray[i];
                        j++;
                    }
                }
                return blacklistArray;
            }
            else return null;
        }
        public void Add(string nick, string mail, string name, string surname)
        {
            var table = "Users";
            var userId = save.GetMaxId("Users") + 1;
            save.Connect("INSERT INTO " + table + " (id, nick, mail, name, surname ) VALUES('" + userId + "', '" + nick + "', '" + mail + "', '" + name + "', '" + surname + "')", "set");
        }
        public void Remove()
        {
            save.Connect("DELETE FROM Variations WHERE id = '" + userId + "'", "set");
        }
        public int GetLastId()
        {
            return save.GetMaxId("Users");
        }
        
        public bool ContainInArrays(string[] firstArray, string[] secondArray)
        {
            bool isTrue = false;
            for (int i = 0; i < secondArray.Length; i++)
                if (firstArray.Contains(secondArray[i])) isTrue = true;
            return isTrue;
        }
    }
}
