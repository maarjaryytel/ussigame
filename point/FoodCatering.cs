using System;
using System.Collections.Generic;
using System.Text;

namespace point
{
	class FoodCatering
	{
		//hakkame toitu serveerima randomiga
		//selleks, et serveeriks õigesse kohta, peame parameetrid määrama, et ikka toit püsiks mängus
		int MapWidth;
		int MapHeight;
		char Symbol;

		Random rnd = new Random();

		//oleks vaja konstr

		public FoodCatering(int _MapWidth, int _MapHeight, char _symbol)
		{
			MapWidth = _MapWidth; //salvestame need väärtused objekti omaduste sisse
			MapHeight = _MapHeight;
			Symbol = _symbol;

			//nüüd ma tahan et objektist saaks punkt, loon meetodi selleks et saaks punkt
		}

		public Point CaterFood()  //see on pointi objekti klass
		{
			int x = rnd.Next(4, MapWidth - 2);
			int y = rnd.Next(4, MapHeight - 2);
			return new Point(x, y, Symbol);
		}
	}
}

