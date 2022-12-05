
namespace AdventOfCode {
    public class DayFour {

        public void Solve1() {
            int sum  = 0;
            using (StreamReader inputFile = File.OpenText("D4InputText.txt")) {
                while(!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] elves = line.Split(",");
                    string[] elf1 = elves[0].Split("-");
                    string[] elf2 = elves[1].Split("-");
                    if (Convert.ToInt32(elf1[0]) >= Convert.ToInt32(elf2[0]) && Convert.ToInt32(elf1[1]) <= Convert.ToInt32(elf2[1])) {
                        sum++;
                    }
                    else if (Convert.ToInt32(elf2[0]) >= Convert.ToInt32(elf1[0]) && Convert.ToInt32(elf2[1]) <= Convert.ToInt32(elf1[1])) {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }
        public void Solve2() {
            int sum = 0;
            using (StreamReader inputFile = File.OpenText("D4InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] elves = line.Split(",");
                    string[] elf1 = elves[0].Split("-");
                    string[] elf2 = elves[1].Split("-");
                    if (Convert.ToInt32(elf1[0]) >= Convert.ToInt32(elf2[0]) && Convert.ToInt32(elf1[0]) <= Convert.ToInt32(elf2[1])) {
                        sum++;
                    } else if (Convert.ToInt32(elf2[0]) >= Convert.ToInt32(elf1[0]) && Convert.ToInt32(elf2[0]) <= Convert.ToInt32(elf1[1])) {
                        sum++;
                    } else if (Convert.ToInt32(elf1[1]) >= Convert.ToInt32(elf2[0]) && Convert.ToInt32(elf1[1]) <= Convert.ToInt32(elf2[1])) {
                        sum++;
                    } else if (Convert.ToInt32(elf2[1]) >= Convert.ToInt32(elf1[0]) && Convert.ToInt32(elf2[1]) <= Convert.ToInt32(elf1[1])) {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}