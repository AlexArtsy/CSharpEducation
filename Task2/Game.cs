using System;

namespace Task2
{
    public class Game
    {
        #region Поля и свойства
        private int resolution;
        private Figure[,] fieldState;
        private string gameState;
        private GameField field;
        private Player player1;
        private Player player2;
        private bool gamerToggle;
        private IO io;
        private bool isGameEnded;

        public int Resolution { get => resolution; }
        #endregion
        #region Конструктор
        public Game(int resolution, Player player1, Player player2)
        {
            this.resolution = resolution;
            this.player1 = player1;
            this.player2 = player2;
            this.gamerToggle = true;
            this.field = new GameField(resolution);
            this.fieldState = field.GetField();
            this.io = new IO(resolution);
            this.isGameEnded = false;
            this.gameState = "started";
        }
        #endregion
        #region Методы
        public void Start()
        {
            this.gameState = "running";

            while (this.gameState == "running")
            {
                this.io.Render(this.field, this.field.GetModel());
                var player = SwitchPlayers();
                var figure = SelectFieldCell(player);
                ExecuteRound(player, figure);
                this.gameState = CheckGameState(player);
            }

            Console.WriteLine(this.gameState);
        }

        private Figure SelectFieldCell(Player player)
        {
            while (true)
            {
                this.io.Render(this.field, this.field.GetModel());
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        this.io.MoveCursor(key);
                        break;
                    case ConsoleKey.UpArrow:
                        this.io.MoveCursor(key);
                        break;
                    case ConsoleKey.RightArrow:
                        this.io.MoveCursor(key);
                        break;
                    case ConsoleKey.LeftArrow:
                        this.io.MoveCursor(key);
                        break;
                    case ConsoleKey.Enter:
                        if (this.fieldState[this.io.UserCursor.GetX(), this.io.UserCursor.GetY()].Value == " ")
                        {
                            return this.fieldState[this.io.UserCursor.GetX(), this.io.UserCursor.GetY()];
                        }
                        break;
                }
            }
        }
        private void ExecuteRound(Player player, Figure figure)
        {
            figure.Value = player.GameSymbol;
        }

        private string CheckGameState(Player player)
        {
            List<Combination> model = this.field.GetModel();

            for(int i = 0; i < model.Count; i += 1)
            {
                if (model[0].IsWinning(player.GameSymbol))
                {
                    this.isGameEnded = true;
                    player.IsPlayerWin = true;
                    return "completed";
                }
                if (model[0].IsStandoff())
                {
                    model.RemoveAt(i);
                }
            }

            if (model.Count == 0)
            {
                this.isGameEnded = true;
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

