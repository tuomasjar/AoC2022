using System.Diagnostics.Metrics;
using System.Drawing;

namespace AdventOfCode {
    public class DayNine {

        public void Solve1() {
            Point head = new Point(0,0);
            Point tail = new Point(0, 0);
            HashSet<Point> visited = new HashSet<Point>();
            using (StreamReader inputFile = File.OpenText(@"D9InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    int repeats = Convert.ToInt32(parts[1]);
                    for (int i = 0; i < repeats; i++) {
                        if (parts[0] == "R") {
                            head.X++;
                        } else if (parts[0] == "L") {
                            head.X--;
                        } else if (parts[0] == "U") {
                            head.Y++;
                        } else if (parts[0] == "D") {
                            head.Y--;
                        }

                        if (Math.Abs(head.X - tail.X) == 2) {
                            tail.X += (head.X - tail.X) / 2;
                            if (head.Y != tail.Y) tail.Y = head.Y;
                        }
                        if (Math.Abs(head.Y - tail.Y) == 2) {
                            tail.Y += (head.Y - tail.Y) / 2;
                            if (head.X != tail.X) tail.X = head.X;
                        }
                        try {
                            visited.Add(tail);
                        } catch {

                        }
                    }
                }
            }
            Console.WriteLine("Result is: " + visited.Count);

        }
        public void Solve2() {
            Point[] snake = new Point[10];
            HashSet<Point> visited = new HashSet<Point>();
            bool xdir = false;
            bool ydir = false;
            using (StreamReader inputFile = File.OpenText(@"D9InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    int repeats = Convert.ToInt32(parts[1]);
                    for (int i = 0; i < repeats; i++) {
                        if (parts[0] == "R") {
                            snake[0].X++;
                        } else if (parts[0] == "L") {
                            snake[0].X--;
                        } else if (parts[0] == "U") {
                            snake[0].Y++;
                        } else if (parts[0] == "D") {
                            snake[0].Y--;
                        }
                        for (int j = 1; j < snake.Length; j++) {
                            if (Math.Abs(snake[j - 1].X - snake[j].X) == 2) {
                                if (Math.Abs(snake[j - 1].Y - snake[j].Y) == 2) {
                                    snake[j].X += (snake[j - 1].X - snake[j].X) / 2;
                                    snake[j].Y += (snake[j - 1].Y - snake[j].Y) / 2;
                                } else {
                                    snake[j].X += (snake[j - 1].X - snake[j].X) / 2;
                                    if (snake[j - 1].Y != snake[j].Y) snake[j].Y = snake[j - 1].Y;
                                }
                            }
                            if (Math.Abs(snake[j - 1].Y - snake[j].Y) == 2) {
                                if (Math.Abs(snake[j - 1].X - snake[j].X) == 2) {
                                    snake[j].X += (snake[j - 1].X - snake[j].X) / 2;
                                    snake[j].Y += (snake[j - 1].Y - snake[j].Y) / 2;
                                } else {
                                    snake[j].Y += (snake[j - 1].Y - snake[j].Y) / 2;
                                    if (snake[j - 1].X != snake[j].X) snake[j].X = snake[j - 1].X;
                                }
                            }
                        }
                        int counter = 0;
                        
                        try {
                            visited.Add(snake[9]);
                        } catch {

                        }
                       
                    }
                }
            }
            Console.WriteLine("Result is: " + visited.Count);
        }
    }
}