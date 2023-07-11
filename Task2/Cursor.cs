
namespace Task2
{
    public class Cursor
    {
        private int x;
        private int y;
        private int resolution;

        public Cursor(int resolution)
        {
            this.x = 0;
            this.y = 0;
            this.resolution = resolution;
        }

        public int GetX() => this.x;

        public int GetY() => this.y;

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void MoveXRight()
        {
            this.SetX(this.GetX() < this.resolution - 1 ? (this.GetX() + 1) : 0);
        }

        public void MoveXLeft()
        {
            this.SetX(this.GetX() >= 1 ? (this.GetX() - 1) : this.resolution - 1);
        }

        public void MoveYDown()
        {
            this.SetY(this.GetY() < this.resolution - 1 ? (this.GetY() + 1) : 0);
        }

        public void MoveYUp()
        {
            this.SetY(this.GetY() >= 1 ? (this.GetY() - 1) : this.resolution - 1);
        }
    }
}
