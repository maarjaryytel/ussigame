using System;

namespace snake_draft
{
	class Point
	{
		public int x;
		public  int y;
		public char symbol;

		//teen konstruktori

		public Point(int _x, int _y, char _symbol)
		//kuidas ma ühendan üleval olevad andmed eelmise reaga
		{
			x = _x;
			y = _y;
			symbol = _symbol;
		}
		//joonistada draw meetod pointile
		
		public void Draw()  //see on meetod
		{
			Console.SetCursorPosition(x, y);
			Console.Write(symbol);
		}		
	}
	class Program
	{
		static void Main(string[] args)
		{
			//console on ka iseenesest klass
			//konsooli suurust saab muuta
			
			// kui ma tahan nendest kerimisribadest lahti saada, siis teen
			Console.SetBufferSize(80, 25);

			//joonistame oma ussi punktid

			Point p1 = new Point(10, 10, '*');
			p1.Draw();
			
			Point p2 = new Point(20, 20, '#');
			p2.Draw();//kuidas ma joonistan seda- tähendab see rida

			Console.ReadLine();
		}
		public static void Draw(int x, int y, char symbol) //mul on vaja koordinaate joonistamiseks
		{
			Console.SetCursorPosition(x, y);
			Console.Write(symbol);
		}
	}
}
