using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace point
{	
	class HorizontalLine: Figure
	//koostame horisontaalline (vasakult paremale) nendest pointidest
    //nende omaduseks on list
	{
		//mida meil oleks vaja et luua joont- x, y, * ja length
		public HorizontalLine(int xLeft, int xRight, int y, char symbol ) //need on koordinaadid- algus, lõpp
		{
			//kuidas ma lisan- neid koord kasutades hakkan looma punkte ja lisama neid listi
			for (int i = xLeft; i < xRight; i++)
			{
				Point newPoint = new Point(i, y, symbol); //oleme objekti loonud
														  //ja nüüd ma tahan seda punkti lisada
				pointList.Add(newPoint);
			}			
		}		
	}
}
