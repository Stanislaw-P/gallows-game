using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gallows_game
{
    public partial class FormMain : Form
    {
        string[] words = new string[] { "СОБАКА", "БЕЛКА", "СЛОН", "КРОЛИК", "ЁЖ" };
        string currentWord = "";
        char[] displayWord;
        int numberAttempts = 1;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        // Метод запуска / сброса новой игры
        private void StartNewGame()
        {
            Random rnd = new Random();
            // 1. Выбираем случайное слово
            currentWord = words[rnd.Next(words.Length)];

            // 2. Создаем массив символов для маски такой же длины, как слово
            displayWord = new char[currentWord.Length];
            for (int i = 0; i < displayWord.Length; i++)
            {
                displayWord[i] = '_';
            }

            // 3. Сбрасываем попытки
            numberAttempts = 1;
            labelNumberAttempts.Text = "Осталось попыток: 6";

            // 4. Выводим маску на экран (разделяем пробелами для красоты)
            UpdateWordDisplay();
        }

        // Вспомогательный метод для обновления текста с маской на форме
        private void UpdateWordDisplay()
        {
            labelWord.Text = string.Join(" ", displayWord);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            // 1. Приводим sender к типу Button, чтобы узнать, какая именно кнопка была нажата
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            // 2. Получаем букву с этой кнопки (например, "А")
            char guessedChar = clickedButton.Text[0];

            // 3. Сразу делаем кнопку неактивной, чтобы нельзя было нажать повторно
            clickedButton.Enabled = false;

            // 4. Проверяем, есть ли эта буква в загаданном слове
            bool isHit = false;
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == guessedChar)
                {
                    displayWord[i] = guessedChar; // Открываем букву в маске
                    isHit = true;
                }
            }

            // 5. Если угадали - обновляем текст с маской на экране
            if (isHit)
            {
                UpdateWordDisplay();

                // Здесь позже добавим проверку на победу (Блок 5)
            }
            else
            {
                // Если не угадали — увеличиваем счетчик ошибок / попыток
                numberAttempts++;

                // Обновляем текст статуса
                labelNumberAttempts.Text = $"Осталось попыток: {7 - numberAttempts}";

                // Здесь позже добавим смену картинки виселицы (Блок 4)

                // Здесь позже добавим проверку на поражение (Блок 5)
            }
        }
    }
}
