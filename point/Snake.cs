using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace point
{
	//loome ussi, see snake on ka figure, ta pärineb meil figurest
	//uss ei ole tavaline element. Uss on nimekiri punktidest, mis hakkavad meil ringi liikuma 
	//ja see element hakkab mingis suunas liikuma
	//suuna tekitamiseks kasutame enumit- enumaration

	enum Direction //ma võiks hiljem nummerdada
	{
		LEFT, //need on tegelikult numbrid, meie jaoks sõnad
		RIGHT,
		UP,
		DOWN
	}

	class Snake : Figure
	{
		//meil oleks vaja konstr
		public Direction Direction; //omadused on hea kirjutada suure tähega

		//on vaja kohta kus uss algab ja kus lõpeb
		public Snake(Point tail, int length, Direction _direction) //need on param mida pakun obj loomiseks
		{
			Direction = _direction;
			for (int i = 0; i < length; i++)
			{
				Point newPoint = new Point(tail);
				newPoint.MovePoint(i, Direction);
				pointList.Add(newPoint);
			}
		}

		public void MoveSnake() //meetod move snake jaoks
		{
			Point tail = pointList.First();
			//meil on olemas list punktidest, sellest saab saba. Tail on list kohal 0.
			//joonistab pointi ära ja liigub edasi

			pointList.Remove(tail); //eemaldame eelmise punkti ja liigume edasi
			Point head = GetNextPoint();
			pointList.Add(head);
			tail.Clear(); //need meetodid kuuluvad punkti klassi juurde
			head.Draw();
		}

		public Point GetNextPoint()
		{
			Point head = pointList.Last();
			Point nextPoint = new Point(head);
			nextPoint.MovePoint(1, Direction); //ühe võrra liigutame
			return nextPoint;
		}

		public void ReadUserKey(ConsoleKey key) //õpetama ussi tuvastama klahvivajutust //kõik klassi sees on meetodid
		{
            if(key == ConsoleKey.LeftArrow)
			{
				Direction = Direction.LEFT;			
			}
		    else if (key == ConsoleKey.RightArrow)
			{
				Direction = Direction.RIGHT;
			}
		    else if (key == ConsoleKey.DownArrow)
			{
				Direction = Direction.DOWN;
			}
		    else if (key == ConsoleKey.UpArrow)
			{
				Direction = Direction.UP;
			}
		}
		//kinnitus, kas uss on midagi söönud või mitte- true or false

		public bool Eat(Point food) //sööb objekti Point, mida kutsume foodiks
		{
			//kui ta sööb peab pikemaks saama, peab olema koht, kuhu lisame/salvestame toidu
			//peame teadma kus on pea
			Point head = GetNextPoint();
			if(head.IsHit(food)) //kui head põrkub kokku toiduga, siis peame food sümbolit muutma head.symboliks
			{ //is hit meetodi lisan pointi
				food.symbol = head.symbol;
				pointList.Add(food);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
