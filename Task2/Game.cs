using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task2
{
    internal class Game
    {
        #region Поля и свойства
        private readonly GameField gameField;
        private List<Combination> model;
        private readonly ITicTacToePlaying player1;
        private readonly ITicTacToePlaying player2;
        private bool gamerToggle;
        private readonly RenderProcessor rendering;

        public Figure[,] Field { get => gameField.Field; }

        public string State { get; set; }

        #endregion
        #region Конструктор
        public Game(int resolution, ITicTacToePlaying player1, ITicTacToePlaying player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            gamerToggle = false;
            gameField = new GameField(resolution);
            model = gameField.Model;
            rendering = new RenderProcessor(resolution);
            State = "started";
        }
        #endregion
        #region Методы
        public void Start()
        {
            State = "running";

            while (State == "running")
            {
                var player = SwitchPlayers();
                var figure = SelectFieldCell(player);
                ExecuteRound(player, figure);
                State = CheckGameState(player);
            }
            Console.WriteLine();
        }

        private Figure SelectFieldCell(ITicTacToePlaying player)
        {
            var validation = false;
            Figure selectedFigure = new (0,0, " ");
            while (!validation)
            {
                rendering.Render(this, player);
                selectedFigure = player.SelectFieldCell(Field, out validation);
            }
            return selectedFigure;
        }
        private void ExecuteRound(ITicTacToePlaying player, Figure figure)
        {
            figure.Value = player.GameSymbol;
            figure.Initialized = true;
        }

        private string CheckGameState(ITicTacToePlaying player)
        {
            model = DeleteStandOffLines();
            for (var i = 0; i < model.Count; i += 1)
            {
                if (model[i].IsWinning(player.GameSymbol))
                {
                    rendering.ChangeLineColor(model[i].Line, ConsoleColor.Green);
                    rendering.Render(this, player);
                    player.IsPlayerWin = true;
                    return "completed";
                }
            }

            return model.Count == 0 ? "standoff" : "running";
        }

        private List<Combination> DeleteStandOffLines()
        {
            var reducedModel = new List<Combination>();
            foreach (var combination in model)
            {
                if (combination.IsStandoff()) continue;

                reducedModel.Add(combination);
            }
            return reducedModel;
        }

        private ITicTacToePlaying SwitchPlayers()
        {
            gamerToggle = !gamerToggle;
            return gamerToggle ? player1 : player2;
        }
        #endregion
    }
}

