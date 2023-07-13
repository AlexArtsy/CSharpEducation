using System;

namespace Task2
{
    public class GameField
    {
        private readonly int resolution;
        public List<Combination> Model { get; set; }
        public Figure[,] Field { get; }

        public GameField(int resolution)
        {
            this.resolution = resolution;
            Field = CreateField();
            Model = CreateFieldModel();
        }

        private Figure[,] CreateField()
        {
            var newField = new Figure[resolution, resolution];

            for (var y = 0; y < resolution; y += 1)
            {
                for (var x = 0; x < resolution; x += 1)
                {
                    newField[x, y] = new Figure(x, y, " ");
                }
            }
            return newField;
        }

        private List<Combination> CreateFieldModel()
        {
            var fieldDimension = 2;
            var amountOfDiagonal = 2;
            var gameModel = new List<Combination>(resolution * fieldDimension + amountOfDiagonal);

            for (var y = 0; y < resolution; y += 1)
            {
                gameModel.Add(GetRow(y));
            }
            for (var x = 0; x < resolution; x += 1)
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
                row[x] = Field[x, y];
            }
            return new Combination(row);
        }

        private Combination GetColumn(int x)
        {
            var column = new Figure[resolution];
            for (int y = 0; y < resolution; y += 1)
            {
                column[y] = Field[x, y];
            }
            return new Combination(column);
        }

        private Combination GetMainDiagonal()
        {
            var diagonal = new Figure[resolution];
            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = Field[i, i];
            }
            return new Combination(diagonal);
        }

        private Combination GetSaidDiagonal()
        {
            var diagonal = new Figure[resolution];
            int y = resolution - 1;

            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = Field[i, i];
                y -= 1;
            }
            return new Combination(diagonal);
        }
    }
}
