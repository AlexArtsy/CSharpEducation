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
        private Human player1;
        private Human player2;
        private bool gamerToggle;
        private RenderProcessor rendering;

        private Human winner;

        public int Resolution { get => resolution; }
        public Figure[,] Field { get => gameField.GetField(); }
        public string State { get => gameState; }

        #endregion
        #region Конструктор
        public Game(int resolution, Human player1, Human player2)
        {
            this.resolution = resolution;
            this.player1 = player1;
            this.player2 = player2;
            this.gamerToggle = true;
            this.gameField = new GameField(resolution);
            this.model = this.gameField.Model;
            this.rendering = new RenderProcessor(resolution);
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
                var figure = SelectFieldCell(player);
                ExecuteRound(player, figure);
                this.gameState = CheckGameState(player);
            }

            Console.WriteLine();
        }

        private Figure SelectFieldCell(Human player)
        {
            bool validation = false;
            while (true)
            {
                this.rendering.Render(this, player);
                if (validation)
                {
                    return player.SelectFieldCell(this.Field, out validation);
                }
            }
        }
        private void ExecuteRound(Human player, Figure figure)
        {
            figure.Value = player.GameSymbol;
            figure.IsInizialized = true;
        }

        private string CheckGameState(Human player)
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

        private Human SwitchPlayers()
        {
            Human currentPlayer;
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

