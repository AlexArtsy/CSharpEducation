using System;

namespace Task2
{
    public class Game
    {
        #region Поля и свойства
        private int resolution;
        private string gameState;
        private GameField gameField;
        private List<Combination> model;
        private Player player1;
        private Player player2;
        private bool gamerToggle;
        private IO io;

        private Player winner;

        public int Resolution { get => resolution; }
        public Figure[,] Field { get => gameField.GetField(); }
        public string State { get => gameState; }

        #endregion
        #region Конструктор
        public Game(int resolution, Player player1, Player player2)
        {
            this.resolution = resolution;
            this.player1 = player1;
            this.player2 = player2;
            this.gamerToggle = true;
            this.gameField = new GameField(resolution);
            this.model = this.gameField.Model;
            this.io = new IO(resolution);
            this.gameState = "started";
        }
        #endregion
        #region Методы
        public void Start()
        {
            this.gameState = "running";

            while (this.gameState == "running")
            {
                var player = SwitchPlayers();
                var figure = player.SelectFieldCell(this);
                ExecuteRound(player, figure);
                this.gameState = CheckGameState(player);
            }

            Console.WriteLine();
        }

        private Figure SelectFieldCell(Player player)
        {
            while (true)
            {
                this.io.Render(this, player);

                ConsoleKey key = Console.ReadKey(true).Key; //  Слушаем нажатие кнопки.
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        this.io.MoveCursor(key);
                        break;
                    case ConsoleKey.Enter:
                        if (!this.Field[this.io.UserCursor.GetX(), this.io.UserCursor.GetY()].IsInizialized)
                        {
                            return this.Field[this.io.UserCursor.GetX(), this.io.UserCursor.GetY()];
                        }
                        break;
                }
            }
        }
        private void ExecuteRound(Player player, Figure figure)
        {
            figure.Value = player.GameSymbol;
            figure.IsInizialized = true;
        }

        private string CheckGameState(Player player)
        {
            for(int i = 0; i < this.model.Count; i += 1)
            {
                if (this.model[i].IsStandoff())
                {
                    this.io.ChangeLineColor(model[i].Line, ConsoleColor.Red);
                    this.model.RemoveAt(i);
                }
                if (this.model[i].IsWinning(player.GameSymbol))
                {
                    this.io.ChangeLineColor(model[i].Line, ConsoleColor.Green);
                    player.IsPlayerWin = true;
                    return "completed";
                }
            }

            if (this.model.Count == 0)
            {
                return "standoff";
            }

            return "running";
        }

        private Player SwitchPlayers()
        {
            Player currentPlayer;
            if (this.gamerToggle)
            {
                currentPlayer = this.player1;
            }
            else
            {
                currentPlayer = this.player2;
            }
            this.gamerToggle = !this.gamerToggle;
            return currentPlayer;
        }
        #endregion
    }
}

