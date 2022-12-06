namespace AdventOfCode {
    public class DaySix {

        public void Solve1() {
            int sum = 0;
            bool found = true;
            Dictionary<char, int> map = new Dictionary<char, int>();
            using (StreamReader inputFile = File.OpenText("D6InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string input = inputFile.ReadLine();
                    for (int i = 3; i < input.Length; i++) {
                        map.Clear();
                        found = true;
                        for (int j = 3; j >= 0; j--) {
                            if (!map.ContainsKey(input[i - j])) {
                                map.Add(input[i - j], j);
                            } else {
                                found = false;
                                break;
                            }
                        }
                        if (found) {
                            sum = i + 1;
                            break;
                        }
                    }
                    if (found) break;
                }
            }
            Console.WriteLine(sum);
        }
        public void Solve2() {
            int sum = 0;
            bool found = true;
            Dictionary<char, int> map = new Dictionary<char, int>();
            using (StreamReader inputFile = File.OpenText("D6InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string input = inputFile.ReadLine();
                    for (int i = 13; i < input.Length; i++) {
                        map.Clear();
                        found = true;
                        for (int j = 13; j >= 0; j--) {
                            if (!map.ContainsKey(input[i - j])) {
                                map.Add(input[i - j], j);
                            } else {
                                found = false;
                                break;
                            }
                        }
                        if (found) {
                            sum = i + 1;
                            break;
                        }
                    }
                    if (found) break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}