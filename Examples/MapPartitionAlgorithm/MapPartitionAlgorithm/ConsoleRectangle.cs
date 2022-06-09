using System.Drawing;


public static class ConsoleRectangle
{
	public static void Draw(int width, int height, Point location, ConsoleColor borderColor)
	{
		string s = "╔";
		string space = "";
		string temp = "";
		for (int i = 0; i < width; i++)
		{
			space += " ";
			s += "═";
		}

		for (int j = 0; j < location.X; j++)
			temp += " ";

		s += "╗" + "\n";

		for (int i = 0; i < height; i++)
			s += temp + "║" + space + "║" + "\n";

		s += temp + "╚";
		for (int i = 0; i < width; i++)
			s += "═";

		s += "╝" + "\n";

		Console.ForegroundColor = borderColor;
		Console.CursorTop = location.Y;
		Console.CursorLeft = location.X;
		Console.Write(s);
		Console.ResetColor();
	}
}

