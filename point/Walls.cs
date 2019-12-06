using System;
using System.Collections.Generic;
using System.Text;

namespace point
{
	// võime luua listi kuhu me salvestame need jooned
	class Walls
	{
		//selle listi sees salvestame figure
		List<Figure> wallList;

		//loome konstruktori, et seda üles ehitada

		public Walls (int mapWidth, int mapHeight)
		{
			//initsialiseerime seda listi
			wallList = new List<Figure>();
			
			//joonistame ainult jooned
			HorizontalLine topLine = new HorizontalLine(0, mapWidth - 2, 3, '#'); //0 on see kust alustab
			HorizontalLine bottomLine = new HorizontalLine(2, mapWidth - 2, mapHeight - 1, '#');

			VerticalLine leftLine = new VerticalLine(3, mapHeight - 1, 0, '#');
			VerticalLine rightLine = new VerticalLine(3, mapHeight - 1, mapWidth - 2, '#');

			//kuidas me lisame listi
			wallList.Add(topLine);
			wallList.Add(bottomLine);
			wallList.Add(leftLine);
			wallList.Add(rightLine);

			//kirjutame 2 meetodit- üks joonistab jooned
		}

		public void DrawWalls()
		{
			foreach (Figure wall in wallList)
			{
				wall.DrawFigure();
			}
		}
		//registreerime, et meie seinad võivad figuure lüüa
		public bool IsHitByFigure(Figure figure) // see on seinadele
		{
			foreach (Figure wall in wallList)
			{
				if(wall.IsHitByFigure(figure)) // see wall on tegelikult figure
				{
					return true;
				}
			}
			return false;
		}
	}
}
