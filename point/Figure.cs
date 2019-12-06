using System;
using System.Collections.Generic;
using System.Text;

namespace point
{
	class Figure

	// sinna kuuluvad kõik need elem mida hakkame looma. 
	{
		protected List<Point> pointList = new List<Point>();

		//lisame meetodid, mis joonistaksid meile jooned. For lopiga joonistame punktid
		public void DrawFigure()
		{
			foreach (Point point in pointList)
			{
				point.Draw();
			}
		}
		//kas meil on punkt või figuur, mis lööb takistust

		public bool IsHitByPoint(Point point) //kontrollime kas seda seina lõi punkt
		{
			foreach (Point p in pointList)
			{
				if(p.IsHit(point)) //kontrollme kas see punkt, mida kontrollime, kas selle
								   //punkti koordinaadid on samad
				{
					return true;
				}
			}
			return false;
		}

		//kontrollime kas takistuseks on üks punkt või terve figuur
		public bool IsHitByFigure(Figure figure)
		{
			foreach(Point point in pointList) //kirjutame figure jaoks selle meetodi
			{
				if(figure.IsHitByPoint(point))
				{
					return true;
				}				
			}
			return false;
		}
	}
}