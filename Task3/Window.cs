using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Window : Screen
    {
        #region Свойства
        public List<Menu> MenuList { get; set; }
        public Menu SelectedMenu { get; set; }
        public List<WindowArea> Areas { get; set; }
        public WindowArea SelectedWindowArea { get; set; }
        public List<InputArea> Inputs { get; set; }
        public InputArea SelectedInputArea { get; set; }
        #endregion

        #region Методы
        public void Render(State state)
        {
            UpdateSelectedElements();
            RenderMenu();
            RenderArea();
            RenderInput();

            while (this.isSelected)
            {
                KeyEventListener(state); 
            }
        }
        public void SetCursorPosition()
        {
            var selectedInput = this.Inputs.Find(i => i.isSelected);
            Console.SetCursorPosition(selectedInput.currentX, selectedInput.currentY);
        }
        public void UpdateSelectedElements()
        {
            this.SelectedMenu = this.MenuList.Find(m => m.isSelected);
            this.SelectedWindowArea = this.Areas.Find(a => a.isSelected);
            this.SelectedInputArea = this.Inputs.Find(i => i.isSelected);
        }
        public void RenderMenu()
        {
            UpdateMenu();
        }
        public void RenderArea()
        {
            this.Areas.ForEach(a => a.Render(this.XStartRenderingPosition, this.YStartRenderingPosition));
        }
        public void RenderInput()
        {
            UpdateInput();
        }
        public void UpdateMenu()
        {
            this.SelectedMenu.Render(this.XStartRenderingPosition, this.YStartRenderingPosition);
            SetCursorPosition();
        }
        public void UpdateArea()
        {
            this.SelectedWindowArea.Render(this.XStartRenderingPosition, this.YStartRenderingPosition);
            SetCursorPosition();
        }
        public void UpdateInput()
        {
            this.SelectedInputArea.Render(this.XStartRenderingPosition, this.YStartRenderingPosition);
            SetCursorPosition();
        }

        public void ShowMessage(string message)
        {
            ClearMessageArea();
            Console.SetCursorPosition(3, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(message + "!!!");
            Console.ResetColor();
            SetCursorPosition();
        }
        public void ClearMessageArea()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write(new String(' ', this.Width - 3));
        }

        public void KeyEventListener(State state)
        {
            var pressedKey = Console.ReadKey(true);
            var input = this.SelectedInputArea.Value;
            switch (pressedKey.Key)
            {
                case ConsoleKey.Tab:
                    TabPressed?.Invoke();
                    break;
                case ConsoleKey.LeftArrow:
                    this.SelectedMenu.SelectItemLeft();
                    RenderMenu();
                    break;
                case ConsoleKey.RightArrow:
                    this.SelectedMenu.SelectItemRight();
                    RenderMenu();
                    break;
                case ConsoleKey.UpArrow:
                    UpArrowPressed?.Invoke();
                    break;
                case ConsoleKey.DownArrow:
                    DownArrowPressed?.Invoke();
                    break;
                case ConsoleKey.Enter:
                    EnterPressed?.Invoke();
                    break;
                case ConsoleKey.Backspace:
                    this.SelectedInputArea.Value = input.Length == 0
                        ? ""
                        : input.Substring(0, input.Length - 1);
                    BackspacePressed?.Invoke();
                    UpdateInput();
                    break;
                default:
                    this.SelectedInputArea.Value += pressedKey.KeyChar;
                    EnyKeyPressed?.Invoke();
                    UpdateInput();
                    break;
            }
        }
        #endregion

        #region Делегаты и события
        public delegate void WindowsHandler();
        public event WindowsHandler BackspacePressed;
        public event WindowsHandler EnterPressed;
        public event WindowsHandler EnyKeyPressed;
        public event WindowsHandler LeftArrowPressed;
        public event WindowsHandler RightArrowPressed;
        public event WindowsHandler UpArrowPressed;
        public event WindowsHandler DownArrowPressed;
        public event WindowsHandler TabPressed;
        #endregion

        #region Конструкторы
        public Window(int id, int x, int y) : base(id, x, y, Console.WindowWidth, Console.WindowHeight)
        {
            this.MenuList = new List<Menu>();
            this.Areas = new List<WindowArea>();
            this.Inputs = new List<InputArea>();
        }
        #endregion
    }
}
