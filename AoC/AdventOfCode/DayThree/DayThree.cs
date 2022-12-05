


namespace AdventOfCode {
    public class DayThree {

        public void Solve1() {
            int sum = 0;
           using(StreamReader inputFile = File.OpenText("D3InputText.txt")) {
                while(!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string line1 = line.Substring(0, line.Length / 2);
                    string line2 = line.Substring(line.Length / 2 , line.Length/2);
                    foreach(char c in line1) {
                        if (line2.Contains(c)) {
                            if(c < 96) {
                                sum += 27 + (c - 'A');
                            } else {
                                sum += 1 + (c - 'a');
                            }
                            break;
                        }
                    }
                }
            }
           Console.WriteLine(sum);
        }
        public void Solve2() {
            int sum = 0;
            using (StreamReader inputFile = File.OpenText("D3InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line1 = inputFile.ReadLine();
                    string line2 = inputFile.ReadLine();
                    string line3 = inputFile.ReadLine();
                    foreach (char c in line1) {
                        if (line2.Contains(c) && line3.Contains(c)) {
                            if (c < 96) {
                                sum += 27 + (c - 'A');
                            } else {
                                sum += 1 + (c - 'a');
                            }
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}