namespace AdventOfCode {
    public class DayOne {

        public void Solve1() {
            int max = 0;
            int[] topThree = new int[3];
            using (StreamReader inputFile = File.OpenText(@"D1InputText.txt")) {
                int sum = 0;
                string nextLine = inputFile.ReadLine();
                while (nextLine != null) {
                    try {
                        int currentValue = Convert.ToInt32(nextLine);
                        sum += currentValue;
                    } catch {
                        if(sum > max) { max = sum; }
                        sum = 0;
                    }
                    nextLine = inputFile.ReadLine();
                }

            }

            Console.WriteLine(max.ToString());

        }
        public void Solve2() {
            int max = 0;
            int[] topThree = new int[3];
            using (StreamReader inputFile = File.OpenText(@"D1InputText.txt")) {
                int sum = 0;
                string nextLine = inputFile.ReadLine();
                while (nextLine != null) {
                    try {
                        int currentValue = Convert.ToInt32(nextLine);
                        sum += currentValue;
                    } catch {
                        if (sum > topThree[0]) {
                            int temp = topThree[0];
                            topThree[0] = sum;
                            int temp2 = topThree[1];
                            topThree[1] = temp;
                            topThree[2] = temp2;
                        } else if (sum > topThree[1]) {
                            int temp = topThree[1];
                            topThree[1] = sum;
                            topThree[2] = temp;
                        }else if(sum > topThree[2]) {
                            topThree[2] = sum;
                        }
                        sum = 0;
                    }   
                    nextLine = inputFile.ReadLine();
                }

            }
            int answer = topThree[0] + topThree[1] + topThree[2];
            Console.WriteLine(answer.ToString());

        }
    }
}