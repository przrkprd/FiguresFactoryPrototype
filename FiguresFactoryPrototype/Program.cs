using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresFactoryPrototype
{
    abstract class Figure
    {
        public string Name;
        public int[,] Cells;

        // Конструктор фигуры.
        public Figure(string name, int[,] cells)
        {
            Name = name;
            Cells = cells;
        }

        // Выводим название фигуры и её клетки.
        public void Show()
        {
            Console.WriteLine("\nФигура: " + Name);
            Console.WriteLine("Количество клеток: " + Cells.GetLength(0));

            // Находим размеры поля, на котором расположена фигура.
            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);

            // Выводим фигуру в виде клеток.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Cells[i, j] == 1)
                        Console.Write("— ");
                    else
                        Console.Write(". ");
                }

                Console.WriteLine();
            }
        }

        // Абстрактный метод создания копии.
        public abstract Figure Clone();
    }

    // Обычная фигура — квадрат из четырёх клеток.
    class Square : Figure
    {
        public Square()
            : base("Квадрат", new int[,]
            {
            { 1, 1 },
            { 1, 1 }
            })
        {
        }

        // Создаём новую фигуру такого же типа.
        public override Figure Clone()
        {
            return new Square();
        }
    }

    // Обычная фигура — линия из четырёх клеток.
    class Line : Figure
    {
        public Line()
            : base("Линия", new int[,]
            {
            { 1, 1, 1, 1 }
            })
        {
        }

        public override Figure Clone()
        {
            return new Line();
        }
    }

    // Суперфигура из шести клеток.
    class SuperFigure : Figure
    {
        public SuperFigure()
            : base("Суперфигура", new int[,]
            {
            { 1, 1, 1 },
            { 1, 1, 1 }
            })
        {
        }

        public override Figure Clone()
        {
            return new SuperFigure();
        }
    }

    // Фабрика фигур.
    // Factory Method позволяет создавать фигуры через общий метод.
    class FigureFactory
    {
        private Random random = new Random();

        // Случайно выбираем одну из трёх фигур.
        public Figure CreateFigure()
        {
            int number = random.Next(0, 3);

            switch (number)
            {
                case 0:
                    return new Square();

                case 1:
                    return new Line();

                default:
                    return new SuperFigure();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FigureFactory factory = new FigureFactory();

            // Случайно создаём фигуру.
            Figure figure = factory.CreateFigure();

            Console.WriteLine("Случайно созданная фигура:");
            figure.Show();

            // Предлагаем создать копию.
            Console.WriteLine("\nСоздать копию фигуры? (1 - да, 0 - нет)");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                // Prototype: создаём копию через метод Clone().
                Figure copy = figure.Clone();

                Console.WriteLine("\nКопия фигуры:");
                copy.Show();
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
