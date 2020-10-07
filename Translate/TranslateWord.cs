using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Translate
{
    class TranslateWord
    {
        protected void translateWord(string word, string langLeft, string langRight, ref string translatedWord, OleDbConnection connection)
        {
            char lastSymb = word[word.Length - 1];
            char firstSymb = word[0];
            bool firtCheck = false, lastCheck = false, upperCheck = false;

            GetSyntax(lastSymb, firstSymb, ref word, ref firtCheck, ref lastCheck);

            if (word[0] == char.ToUpper(word[0]))
                upperCheck = true;
                

            using (OleDbCommand command = new OleDbCommand($"SELECT [{langRight}] FROM [Dictionary] WHERE [{langLeft}] = '{word}' ", connection))
            {
                try
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        translatedWord = reader[0].ToString();

                    if (translatedWord == null)
                        translatedWord = word;

                    UpperControl(ref translatedWord, upperCheck);

                    SetSyntax(lastSymb, firstSymb, ref translatedWord, ref firtCheck, ref lastCheck);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning!");
                }

            }
        }

        private void UpperControl(ref string translatedWord, bool upperCheck)
        {
            if (upperCheck)
            {
                string temp = translatedWord;
                translatedWord = null;
                translatedWord += char.ToUpper(temp[0]);
                for (int i = 1; i < temp.Length; i++)
                    translatedWord += temp[i];
            } 
        }

        private void GetSyntax(char lastSymb, char firstSymb, ref string word, ref bool firtCheck, ref bool lastCheck)
        {
            if (
                firstSymb == Convert.ToChar(34) || firstSymb <= Convert.ToChar(39)
                || firstSymb == Convert.ToChar(40) || firstSymb == Convert.ToChar(91)
                || firstSymb == Convert.ToChar(123)
                )
                firtCheck = true;
            if (
                lastSymb == Convert.ToChar(33) || lastSymb == Convert.ToChar(34)
                || lastSymb == Convert.ToChar(39) || lastSymb == Convert.ToChar(41)
                || lastSymb == Convert.ToChar(44) || lastSymb == Convert.ToChar(46)
                || lastSymb == Convert.ToChar(58) || lastSymb == Convert.ToChar(59)
                || lastSymb == Convert.ToChar(63) || lastSymb == Convert.ToChar(93)
                || lastSymb == Convert.ToChar(125)
                )
                lastCheck = true;
            string[] temp = word.Split(',', '.', '(', ')', '!', '?', '[', ']', '{', '}', ':', ';', '"', '\'');
            if (firtCheck)
                word = temp[1];
            else
                word = temp[0];
        }

        private void SetSyntax(char lastSymb, char firstSymb, ref string translatedWord, ref bool firtCheck, ref bool lastCheck)
        {
            if (firtCheck)
            {
                string temp = translatedWord;
                translatedWord = null;
                translatedWord += firstSymb + temp;
            }

            if (lastCheck)
                translatedWord += lastSymb;
        }
    }
}
