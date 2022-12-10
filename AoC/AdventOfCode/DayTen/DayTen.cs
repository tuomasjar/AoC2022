
using System.Drawing;

namespace AdventOfCode {
    public class DayTen {

        public void Solve1() {
            int registerX = 1;
            List<int> values = new List<int>();
            bool wait = false;
            int counter = 1;
            int countValue = 20;
            string line = "noop";
            using (StreamReader inputFile = File.OpenText(@"D10InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    if(!wait)line = inputFile.ReadLine();
                    if(counter == countValue) {
                        values.Add(registerX * countValue);
                        countValue += 40;
                    }
                    if (line.Contains("noop")) {
                        wait = false;
                    } else {
                        if (wait) {
                            registerX += Convert.ToInt32(line.Split(" ")[1]);
                            wait = false;
                        } else {
                            wait = true;
                        }
                    }
                    counter++;
                }
            }
            int sum = 0;
            foreach(int i in values) {
                sum += i;
            }
            Console.WriteLine("Result is: " + sum);
        }
        public void Solve2() {
            char[,] crt = new char[40,6];

            int registerX = 1;
            bool wait = false;
            int counter = 1;
            int crtLine = 0;
            int crtIndex = 0;
            string line = "noop";
            using (StreamReader inputFile = File.OpenText(@"D10InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    if (!wait) line = inputFile.ReadLine();
                    crtIndex = counter % 40;
                    crtLine = counter / 40;
                    if(crtLine == 6) {
                        break;
                    }
                    Console.WriteLine("Index " + crtIndex + " Line: " + crtLine);
                    char current = '.';
                    if(crtIndex == registerX || crtIndex == registerX+1 || crtIndex == registerX+2) {
                        current = '#';
                    }
                    crt[crtIndex,counter/40] = current;
                    if (line.Contains("noop")) {
                        wait = false;
                    } else {
                        if (wait) {
                            registerX += Convert.ToInt32(line.Split(" ")[1]);
                            wait = false;
                        } else {
                            wait = true;
                        }
                    }
                    counter++;
                }
            }
            for(int i = 0; i < 6; i++) {
                for(int j=0; j < 40; j++) {
                    Console.Write(crt[j,i]);
                }
                Console.WriteLine();
            }
        }
    }
}