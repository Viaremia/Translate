using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Translate
{

    // Разработка классов перевода текста.
    // Класс содержит буфер с текстом и словарь. 
    // Методы класса реализуют ввод текста, его просмотр, проверку, исправление ошибок,
    // показ в тексте слов с ошибками сохранение в файле исправленного текста.

    // В работе обязательно реализовать наследование классов.

    public partial class Form1 : Form
    {
        private string connectingString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Dictionary.mdb";
        
        private OleDbConnection connection;
        public Form1()
        {
            InitializeComponent();

            FormLoad();
        }

        private void ButtonTrst_Click(object sender, EventArgs e)
        {
            string translatedText = null;

            richTextBoxRight.Clear();
            TranslateText translate = new TranslateText();
            translate.translateText(richTextBoxLeft.Text, ref translatedText, comboBoxLeft.Text, comboBoxRight.Text, connection);
            richTextBoxRight.Text = translatedText;
        }

        private void ErrorsFix_Click(object sender, EventArgs e)
        {
            string incorrectWords = null;
            string[] temp = richTextBoxLeft.Text.Split(',', '.', '(', ')', '!', '?', '[', ']', '{', '}', ':', ';', '"', '\'', ' ');
            for (int i = 0; i < temp.Length; i++)
            {
                string tempWord = null;
                using (OleDbCommand command = new OleDbCommand($"SELECT [{comboBoxLeft.Text}] FROM [Dictionary] WHERE [{comboBoxLeft.Text}] = '{temp[i]}'", connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        tempWord = reader[0].ToString();
                    
                    if (tempWord == null)
                            incorrectWords += temp[i] + " ";

                    reader.Close();
                }
            }

            temp = null;
            temp = incorrectWords.Split(' ');
            

            for (int i = 0; i < temp.Length; i++)
            {
                string tempWord = temp[i], findedWords = null;
                if (tempWord == "")
                    break;
                string[] findedArr;
                using (OleDbCommand command = new OleDbCommand($"SELECT [{comboBoxLeft.Text}] FROM [Dictionary] WHERE [{comboBoxLeft.Text}] LIKE '{tempWord[0]}%'", connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        findedWords += reader[0] + " ";
                    findedArr = findedWords.Split(' ');
                    reader.Close();
                }
                try
                {
                    SymbolsCheck(findedArr, ref tempWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void SymbolsCheck(string[] findedArr, ref string tempWord)
        {
            string temp;
            
            for (int i = 0; i < findedArr.Length; i++)
            {
                int errorCount = 0;
                temp = findedArr[i];
                if (temp.Length == tempWord.Length)
                {
                    for(int j = 0; j < tempWord.Length; j++)
                    {
                        if (temp[j] != tempWord[j])
                            errorCount++;
                    }

                    if (errorCount <= tempWord.Length / 2)
                    {
                        int pos = richTextBoxLeft.Text.IndexOf(tempWord);
                        int lenght = tempWord.Length;
                        richTextBoxLeft.Select(pos, lenght);
                        richTextBoxLeft.SelectedText = temp;
                        richTextBoxLeft.Select(richTextBoxLeft.Text.Length, richTextBoxLeft.SelectedText.Length);
                    }
                }
            }
        }

        private void LeftText_Chenge(object sender, EventArgs e)
        {
            string checkedWord;
            string[] temp = richTextBoxLeft.Text.Split(',', '.', '(', ')', '!', '?', '[', ']', '{', '}', ':', ';', '"', '\'', ' ');
            for (int i = 0; i < temp.Length; i++)
            {
                checkedWord = null;
                using (OleDbCommand command = new OleDbCommand($"SELECT [{comboBoxLeft.Text}] FROM [Dictionary] WHERE [{comboBoxLeft.Text}] = '{temp[i]}'", connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        checkedWord = reader[0].ToString();

                    int lenght = 0, pos = 0;
                    if (checkedWord == null)
                    {
                        lenght = temp[i].Length;

                        for (int j = 0; j < i; j++)
                            pos += temp[j].Length ;
                        pos += i;
                        richTextBoxLeft.Select(pos, lenght);
                        richTextBoxLeft.SelectionColor = Color.Red;
                    }
                    else
                    {
                        lenght = temp[i].Length;

                        for (int j = 0; j < i; j++)
                            pos += temp[j].Length;
                        pos += i;
                        richTextBoxLeft.Select(pos, lenght);
                        richTextBoxLeft.SelectionColor = Color.Black;
                    }
                    richTextBoxLeft.Select(richTextBoxLeft.Text.Length, richTextBoxLeft.Text.Length);
                    reader.Close();
                }
            }
        }

        private void CmbBoxLeft_Change(object sender, EventArgs e)
        {
            if (comboBoxLeft.Text == "Russian")
                comboBoxRight.Text = "English";
            else
                comboBoxRight.Text = "Russian";
        }

        private void CmbBoxRight_Change(object sender, EventArgs e)
        {
            if (comboBoxRight.Text == "Russian")
                comboBoxLeft.Text = "English";
            else
                comboBoxLeft.Text = "Russian";
        }

        private void FormLoad()
        {
            try
            {
                connection = new OleDbConnection(connectingString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void AboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Peremena Dmitry\nGroup: IPZ-18-2\nAbout programm: If you see red text, it mean:" +
                "\n1.You made a mistakes.\n2.Dictionary don't have this words", "About");
        }
    }
}
