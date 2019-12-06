using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;


namespace point
{

	class Program
	{
		static void Main(string[] args)
		{			
			Console.BackgroundColor = Color.OrangeRed;
			Console.ForegroundColor = Color.Black;
			Console.Clear();

			var currentDate = DateTime.Now;
			Console.WriteLine($"{currentDate.ToLongDateString()}", Color.DarkBlue);

			Console.WriteLine("GO, YOU CAN DO IT!",Color.White);

			Console.OutputEncoding = System.Text.Encoding.UTF8;
			string a = "\u263A";
			Console.WriteLine(a, Color.Black);
											
			Console.SetWindowSize(80, 25);
			Console.SetBufferSize(80, 25);
			 

			//loome objekti walls
			Walls walls = new Walls(80, 25);
			//kuidas joonistan seinad
			walls.DrawWalls();
			
			Point tail = new Point(6, 5, '*'); //see on see kust ussike hakkab elama, tema algus
			Snake snake = new Snake(tail, 4, Direction.RIGHT);
			
			snake.DrawFigure();
			

			//kutsume klassi välja
			FoodCatering foodCatered = new FoodCatering(80, 25, '$'); //dollarimärk on söök
			Point food = foodCatered.CaterFood();
			food.Draw();

			while (true)
			{
				//kontr kas on seina löönud või mitte

				if (walls.IsHitByFigure(snake)) //kui uss lööb seina
				{
					break;
				}
				//hakkame kontrollima klahvivajutusi
				//kui ussike on oma toitu söönud, siis joonistame

				if (snake.Eat(food))
				{
					food = foodCatered.CaterFood();
					Console.WriteLine("\a"); //kui uss saab söögi kätte, siis teeb häält
					                           //\a – Alert (character 7)					
					food.Draw();
				}
				else //kui ei ole midagi söönud liigu edasi
				{
					snake.MoveSnake();
				}

				Thread.Sleep(350);
				//ehitab üles objekti klahvivajutuses mida teen
				//readkey loeb seda klahvi mida vajutan
				if (Console.KeyAvailable) //see registreerib klahvi vajutust
										  //kontrollime esmalt kas üldse vajutati mingit klahvi
				{
                    ConsoleKeyInfo key = Console.ReadKey();//see loeb maha kas vajutati klahvi või mitte
					snake.ReadUserKey(key.Key);
				}
				
				 //uss hakkas jooksma, see thread sleep on liikumise kiirus, 200 millisekundit
   			}

			//kirjutame funktsiooni mängu lõppemise kohta

			WriteGameOver();
			Console.ReadLine();
		}

		public static void WriteGameOver()
		{
			//int xOffset = 35;
			//xoffset on koordinaat, kuhu ma panen selle message
			//int yOffset = 8;

			//Console.SetCursorPosition(xOffset, yOffset++);//kust peab alustama
			//ShowMessage("===========", xOffset, yOffset++);
			//ShowMessage("GAME OVER", xOffset, yOffset++);
			//ShowMessage("===========", xOffset, yOffset++);
				

			for (int a = 10; a >= 0; a--)
			{
				Console.SetCursorPosition(0, 2);
				Console.Write("Sinu tulemus kuvatakse {0} sekundi pärast: ", a);  
				System.Threading.Thread.Sleep(1000);
				Console.Clear();
			}
						
			int DA = 0;
			int V = 0;
			int ID = 0;
			for (int i = 0; i < 4; i++)
			{
				Console.WriteAscii("GAME OVER", Color.FromArgb(DA, V, ID));			
			}

			string Progresbar= "SEE ON KONSOOLI ANIMEERITUD PEALKIRI";			
			var title = "";
			while (true)
			{
				for (int i = 0; i < Progresbar.Length; i++)
				{
					title += Progresbar[i];
					Console.Title = title;
					Thread.Sleep(100);

				}
				title = "";
				
                for (int i = 237; i <= 32767; i += 20) // see on nö lõpumuusika 
			    {
				Console.Beep(i, 150);
			    }
			}			
		}

		//tahan kuskilt keskelt kirjutada, kust hakkab kirjutama

		public static void ShowMessage(string text, int xOffset, int yOffset) //see on see kuhu paneb kursori
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);			
		}

		public static void Draw(int x, int y, char symbol) 
		{
			Console.SetCursorPosition(x, y);
			Console.Write(symbol);
		}				
	}
}
	


