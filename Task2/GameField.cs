using System;

namespace Task2
{
    public class GameField
    {
        private int resolution;
        private Figure[][] rows;
        private Figure[][] columns;
        private Figure[] mainDiagonal;
        private Figure[] sideDiagonal;
        private Figure[,] field;
        private List<Combination> model;

        public List<Combination> Model { get { return model; } }

        public GameField(int resolution)
        {
            this.resolution = resolution;
            this.rows = new Figure[resolution][];
            this.columns = new Figure[resolution][];
            this.mainDiagonal = new Figure[resolution];
            this.sideDiagonal = new Figure[resolution];
            this.field = CreateField();
            this.model = CreateFieldModel();
        }

        public Figure[,] GetField()
        {
            return this.field;
        }

        private Figure[,] CreateField()
        {
            Figure[,] field = new Figure[resolution, resolution];

            for (int y = 0; y < resolution; y += 1)
            {
                for (int x = 0; x < resolution; x += 1)
                {
                    field[x, y] = new Figure(x, y, " ");
                }
            }
            return field;
        }

        private List<Combination> CreateFieldModel()
        {
            int fieldDimension = 2;
            int amountOfDiagonal = 2;
            var gameModel = new List<Combination>(resolution * fieldDimension + amountOfDiagonal);

            for (int y = 0; y < resolution; y += 1)
            {
                gameModel.Add(GetRow(y));
            }
            for (int x = 0; x < resolution; x += 1)
            {
                gameModel.Add(GetColumn(x));
            }
            gameModel.Add(GetMainDiagonal());
            gameModel.Add(GetSaidDiagonal());

            return gameModel;
        }

        private Combination GetRow(int y)
        {
            var row = new Figure[resolution];
            for (int x = 0; x < resolution; x += 1)
            {
                row[x] = field[x, y];
            }
            return new Combination(row);
        }

        private Combination GetColumn(int x)
        {
            var column = new Figure[resolution];
            for (int y = 0; y < resolution; y += 1)
            {
                column[y] = field[x, y];
            }
            return new Combination(column);
        }

        private Combination GetMainDiagonal()
        {
            var diagonal = new Figure[resolution];
            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = field[i, i];
            }
            return new Combination(diagonal);
        }

        private Combination GetSaidDiagonal()
        {
            var diagonal = new Figure[resolution];
            int y = resolution - 1;

            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = field[i, i];
                y -= 1;
            }
            return new Combination(diagonal);
        }
    }
}
