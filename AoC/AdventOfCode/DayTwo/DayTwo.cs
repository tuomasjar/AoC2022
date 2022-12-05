

namespace AdventOfCode {
    public class DayTwo {
        
        public void Solve1() {
            int score = 0;
            
            using(StreamReader inputFile = File.OpenText("D2InputText.txt")) {
                while(!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    if (line[2] == 'X') {
                        score += 1;
                        if (line[0] == 'A') {
                            score += 3;
                        }else if (line[0] == 'B') {

                        } else {
                            score += 6;
                        }
                    }else if (line[2] == 'Y') {
                        score += 2;
                        if (line[0] == 'A') {
                            score += 6;
                        } else if (line[0] == 'B') {
                            score += 3;
                        } else {
                            score += 0;
                        }
                    } else {
                        score += 3;
                        if (line[0] == 'A') {
                            score += 0;
                        } else if (line[0] == 'B') {
                            score += 6;
                        } else {
                            score += 3;
                        }
                    }
                }
            }

            Console.WriteLine(score.ToString());

        }
        public void Solve2() {
            int score = 0;

            using (StreamReader inputFile = File.OpenText("D2InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    char selected;
                    if (line[2] == 'X') {
                        if (line[0] == 'A') {
                            selected = 'Z';
                        }
                        else if (line[0] == 'B') {
                            selected = 'X';
                        } else {
                            selected = 'Y';
                        }
                    }else if (line[2] == 'Y') {
                        if (line[0] == 'A') {
                            selected = 'X';
                        } else if (line[0] == 'B') {
                            selected = 'Y';
                        } else {
                            selected = 'Z';
                        }
                    } else {
                        if (line[0] == 'A') {
                            selected = 'Y';
                        } else if (line[0] == 'B') {
                            selected = 'Z';
                        } else {
                            selected = 'X';
                        }
                    }


                    if (selected == 'X') {
                        score += 1;
                        if (line[0] == 'A') {
                            score += 3;
                        } else if (line[0] == 'B') {

                        } else {
                            score += 6;
                        }
                    } else if (selected == 'Y') {
                        score += 2;
                        if (line[0] == 'A') {
                            score += 6;
                        } else if (line[0] == 'B') {
                            score += 3;
                        } else {
                            score += 0;
                        }
                    } else {
                        score += 3;
                        if (line[0] == 'A') {
                            score += 0;
                        } else if (line[0] == 'B') {
                            score += 6;
                        } else {
                            score += 3;
                        }
                    }
                }
            }

            Console.WriteLine(score.ToString());
            ;
        }
    }
}