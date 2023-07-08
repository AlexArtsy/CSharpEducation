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
        private List<Figure[]> model;

        public GameField(int resolution)
        {
            this.resolution = resolution;
            this.rows = new Figure[resolution][resolution];
            this.columns = new Figure[resolution][resolution];
            this.mainDiagonal = new Figure[resolution];
            this.sideDiagonal = new Figure[resolution];
            this.field = CreateField();
            this.model = CreateFieldModel();
        }

        public List<Figure[]> GetModel()
        {
            return this.model;
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
        }

        private List<Figure[]> CreateFieldModel()
        {
            int fieldDimension = 2;
            int amountOfDiagonal = 2;
            var gameModel = new List<int[][]>(resolution * fieldDimension + amountOfDiagonal);

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

        private Figure[] GetRow(int y)
        {
            var row = new Figure[resolution];
            for (int x = 0; x < resolution; x += 1)
            {
                row[x] = field[x, y];
            }
            return row;
        }

        private Figure[] GetColumn(int x)
        {
            var column = new Figure[resolution];
            for (int y = 0; y < resolution; y += 1)
            {
                column[y] = field[x, y];
            }
            return column;
        }

        private Figure[] GetMainDiagonal()
        {
            var diagonal = new Figure[resolution];
            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = field[i, i];
            }
            return diagonal;
        }

        private Figure[] GetSaidDiagonal()
        {
            var diagonal = new Figure[resolution];
            int y = resolution - 1;

            for (int i = 0; i < resolution; i += 1)
            {
                diagonal[i] = field[i, i];
                y -= 1;
            }
            return diagonal;
        }
    }
}
