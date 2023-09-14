using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class QuestionScreen : Screen
    {
        #region Поля
        public string question;
        private int xCenterCoordinate;
        private int yCenterCoordinate;
        #endregion

        #region Свойства
        #endregion

        #region Методы
        private void SetCenterCoordinate()
        {
            this.xCenterCoordinate = this.Width - this.question.Length / 2;
            this.yCenterCoordinate = this.Height / 2;
        }
        public string RenderQuestion()
        {
            Console.Clear();
            Console.SetCursorPosition(this.xCenterCoordinate, this.yCenterCoordinate);
            Console.Write(question + " ");
            return Console.ReadLine();
        }
        #endregion

        #region Конструкторы
        public QuestionScreen(string question) : base(0,0, 0, Console.WindowWidth, Console.WindowHeight)
        {
            this.question = question;
            SetCenterCoordinate();
        }
        #endregion
    }
}
