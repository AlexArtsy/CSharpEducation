using System;

public class Figure
{
	private int x;
	private int y;
	private string value;
    private ConsoleColor bgColor;
    private bool isInizialized;

    public ConsoleColor BGColor
    {
        get { return bgColor; }
        set { bgColor = value; }
    }

    public bool IsInizialized
    {
        get { return isInizialized; }
        set { isInizialized = value; }
    }

    public int X 
	{
		get { return x; }
		set {this.x = value; }
	}

    public int Y
    {
        get { return y; }
        set { this.y = value; }
    }

    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public Figure(int x, int y, string value)
    {
        this.x = x;
        this.y = y;
		this.value = value;
        this.bgColor = ConsoleColor.Black;
        this.isInizialized = false;
    }
}
