using System;
using System.Collections.Generic;
using System.Text;

namespace point
{
	class VerticalLine: Figure
	{
		public VerticalLine(int yTop, int yBottom, int x, char symbol)
		{
			//kust ma alustan, kust lõpetan
			for (int i = yTop; i <= yBottom; i++)
			{
				Point newPoint = new Point(x, i, symbol);
				//lisame punkti listile
				pointList.Add(newPoint);				
			}
		}
        //kuidas ma seda joonistan
		public void DrawVertical()
		{
			foreach (Point point in pointList)
			{
				point.Draw();
			}
		}
	}
}
