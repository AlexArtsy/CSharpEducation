using System;

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

	public int GetX ()
	{
		return x;
	}

    public int GetY()
    {
        return y;
    }

	public void SetX (int x)
	{
		this.x = x;
	}

    public void SetY(int y)
    {
        this.x = y;
    }

    public void MoveXRight()
	{
		this.SetX(this.GetX() < resoluton - 1 ? (this.GetX() + 1) : 0);
    }

    public void MoveXLeft()
	{
		this.SetX(this.GetX() >= 1 ? (this.GetX() - 1) : resoluton - 1);
	}

    public void MoveYDown() => y < resoluton - 1 ? (y + 1) : 0;

    public void MoveYUp() => y >= 1 ? (y - 1) : resoluton - 1;
}
