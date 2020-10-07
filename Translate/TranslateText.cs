using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Translate
{
    class TranslateText : TranslateWord
    {
        private string[] temp;
        private string translatedWord;

        public void translateText(string text, ref string translatedText, string langLeft, string langRight,  OleDbConnection connection)
        {
            temp = text.Split(' ');

            for (int i = 0; i < temp.Length; i++)
            {
                translatedWord = null;
                translateWord(temp[i], langLeft, langRight, ref translatedWord, connection);
                translatedText += translatedWord + " ";
            }
                
        }
    }
}
