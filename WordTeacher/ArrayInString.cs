using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTeacher
{
    public class ArrayInString
    {
        public int maxElems = 100;
        public int GetIndexOfElement(int[] intArray, int element)
        {
            if (intArray.Contains(element))
            {
                int i;
                for (i = 0; intArray[i] != element; i++) { }
                return i;
            }
            else
                return -1;
        }
        public int[] GetIntArrayFromString(string parseString)
        {
            string[] stringArray = new string[maxElems];
            int[] intArray = new int[maxElems];
            string[] separators = { "," };
            stringArray = parseString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }
            return intArray;
        }
        public string SetIntArrayToString(int[] intArray)
        {
            string combinedString = "";
            int i;
            for (i = 0; i < intArray.Length - 1; i++)
            {
                combinedString += intArray[i] + ",";
            }
            combinedString += intArray[i];
            return combinedString;
        }
    }
}
