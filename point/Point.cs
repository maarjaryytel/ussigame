using System;

namespace point
{
	class Point
	{
		public int x;
		public int y;
		public char symbol;

		public Point(int _x, int _y, char _symbol)		
		{
			x = _x;
			y = _y;
			symbol = _symbol;
		}
		
		public Point(Point _p)
		{
			x = _p.x; //kasutan punkti koordinaate et luua uus punkt
			y = _p.y;
			symbol = _p.symbol;
		}
		
		public void Draw()  
		{
			Console.SetCursorPosition(x, y);
			Console.Write(symbol);
		}

	    public void Clear()
		{
			symbol = ' '; //joonistab tühiku
			Draw();
		}

		public void MovePoint(int offset, Direction direction)
		{
			if(direction == Direction.RIGHT) //kontrollime mis suunas hakkab uss liikuma
			{
				x = x + offset;
			}
			else if (direction == Direction.LEFT)
			{
				x = x - offset;
			}
			else if (direction == Direction.UP)
			{
				y = y - offset;
			}
			else if (direction == Direction.DOWN)
			{
				y = y + offset;
			}
 		}

		public bool IsHit(Point point)
		{
			//kas selle punkti x koord on võrdsed x, siis tagastab true, sama y-ga
			return point.x == x && point.y == y;
		}
	}
}

