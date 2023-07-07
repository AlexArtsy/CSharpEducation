using System;

public class Figure
{
	private int x;
	private int y;
	private string value;

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public string getValue()
	{
		return value;
	}

    public Figure(int x, int y, string value)
    {
        this.x = x;
        this.y = y;
		this.value = value;
    }
}
