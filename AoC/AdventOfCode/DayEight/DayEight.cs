
namespace AdventOfCode {
    public class DayEight {

        public void Solve1() {
            int score = 0;
            HashSet<string> visible = new HashSet<string>();
            List<int[]> trees = new List<int[]>();
            using (StreamReader inputFile = File.OpenText("D8InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    int[] treeLine = Array.ConvertAll<char, int>(line.ToCharArray(), c => (int)Char.GetNumericValue(c));
                    trees.Add(treeLine);
                }
                int[][] forest = trees.ToArray();
                int previous = -1;
                for (int x = 0; x < forest[0].Length; x++) {
                    for (int y = 0; y < forest.Length; y++) {
                        try {
                            if (y == 0) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (x == 0) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (forest[x][y] == 9) {
                                visible.Add(x.ToString() + " " + y.ToString());
                                break;
                            }
                            if (forest[x][y] > previous) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                        } catch (Exception e) {
                            continue;
                        }
                    }
                    previous = -1;
                }
                for (int y = 0; y < forest.Length; y++) {
                    for (int x = 0; x < forest[0].Length; x++) {
                        try {
                            if (y == 0) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (x == 0) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (forest[x][y] == 9) {
                                visible.Add(x.ToString() + " " + y.ToString());
                                break;
                            }
                            if (forest[x][y] > previous) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                        } catch (Exception e) {
                            continue;
                        }
                    }
                    previous = -1;
                }
                for (int y = forest.Length; y >= 0; y--) {
                    for (int x = forest[0].Length; x >= 0 ; x--) {
                        try {
                            if (y == forest.Length) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (x == forest[0].Length) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (forest[x][y] == 9) {
                                visible.Add(x.ToString() + " " + y.ToString());
                                break;
                            }
                            if (forest[x][y] > previous) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                        } catch (Exception e) {
                            continue;
                        }
                    }
                    previous = -1;
                }
                for (int x = forest[0].Length; x >= 0; x--) {
                    for (int y = forest.Length; y >= 0; y--) {
                        try {
                            if (y == forest.Length) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (x == forest[0].Length) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                            if (forest[x][y] == 9) {
                                visible.Add(x.ToString() + " " + y.ToString());
                                break;
                            }
                            if (forest[x][y] > previous) {
                                previous = forest[x][y];
                                visible.Add(x.ToString() + " " + y.ToString());
                            }
                        } catch (Exception e) {
                            continue;
                        }
                    }
                    previous = -1;
                }
            }
            Console.WriteLine(visible.Count.ToString());
        }
        public void Solve2() {
            Dictionary<string,int> visible = new Dictionary<string, int>();
            List<int[]> trees = new List<int[]>();
            using (StreamReader inputFile = File.OpenText("D8InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    while (!inputFile.EndOfStream) {
                        string line = inputFile.ReadLine();
                        int[] treeLine = Array.ConvertAll<char, int>(line.ToCharArray(), c => (int)Char.GetNumericValue(c));
                        trees.Add(treeLine);
                    }
                    int[][] forest = trees.ToArray();
                    for(int x = 1; x < forest.Length-1; x++) {
                        for(int y = 1; y < forest[0].Length-1; y++) {
                            int currentHeight = forest[x][y];
                            int scenic = 1;
                            int counter = 0;
                            for (int x1 = x + 1; x1 < forest.Length; x1++) {
                                if (forest[x1][y] < currentHeight) {
                                    counter++;
                                } else {
                                    counter++;
                                   
                                    break;
                                }
                            }
                            scenic *= counter;
                            counter = 0;
                            for(int x1 = x-1; x1 >= 0; x1--) {
                                if (forest[x1][y] < currentHeight) {
                                    counter++;
                                } else {
                                    counter++;
                                    break;
                                }
                            }
                            scenic *= counter;
                            counter = 0;
                            for (int y1 = y+1; y1 < forest[0].Length; y1++) {
                                if (forest[x][y1] < currentHeight) {
                                    counter++;
                                } else {
                                    counter++;
                                    break;
                                }
                            }
                            scenic *= counter;
                            counter = 0;
                            for (int y1 = y-1; y1 >= 0; y1--) {
                                if (forest[x][y1] < currentHeight) {
                                    counter++;
                                } else {
                                    counter++;
                                    break;
                                }
                            }
                            scenic *= counter;
                            visible.Add(x.ToString() + " " + y.ToString(), scenic);
                        }
                    }
                }
                int max = 0;
                foreach(var item in visible) {
                    if(item.Value > max) max = item.Value;
                }
                Console.WriteLine(max.ToString());
                
            }
        }
    }
}