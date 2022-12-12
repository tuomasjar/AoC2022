
using System.Numerics;

namespace AdventOfCode {
    public class DayEleven {
        private static ulong sumValue = 1;
        public enum Operation {
            ADD,
            MULTIPLY
        }
        private class MonkeyPart1 {
            public MonkeyPart1(Operation oper,int amount, int test, int isT, int isF) {
                this.operation = oper;
                this.test = test;
                this.isTrue = isT;
                this.amount = amount;
                this.isFalse= isF;
                testList = new List<int>();
            }
           
            private Operation operation;
            private int amount;
            private int test;
            public int sum = 0;
            int isTrue = 0;
            int isFalse = 0;
            List<int> testList;

            public Vector2 inspect() {
                if(testList.Count == 0) { return new Vector2(-1,-1); }
                Vector2 result = new Vector2();
                if(operation == Operation.ADD) {
                    testList[0] = testList[0] + amount;
                } else {
                    if(amount < 0) {
                        testList[0] = testList[0] * testList[0];
                    } else {
                        testList[0] = testList[0] * amount;
                    }
                }
                testList[0] = testList[0] / 3;
                if (testList[0] % test == 0) {
                    result.X = isTrue;
                    result.Y = testList[0];
                }
                else{
                    result.X = isFalse;
                    result.Y = testList[0];
                }
                testList.RemoveAt(0);
                sum++;
                return result;
            }

            public void catchItem(int item) {
                testList.Add(item);
            }
        }
        public void Solve1() {
            sumValue = 1UL;
            List<MonkeyPart1> monkeys= new List<MonkeyPart1>();
            using (StreamReader inputFile = File.OpenText(@"D11InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    Operation oper;
                    string line = inputFile.ReadLine();
                    string starting = inputFile.ReadLine();
                    string operate = inputFile.ReadLine();
                    string tester = inputFile.ReadLine();
                    string tosi = inputFile.ReadLine();
                    string eitosi = inputFile.ReadLine();
                    inputFile.ReadLine();
                    string[] part = operate.Split(" ");
                    if (part[part.Length - 2] == "+") {
                        oper = Operation.ADD;
                    } else {
                        oper = Operation.MULTIPLY;
                    }
                    int amount = 0;
                    try {
                        amount = Convert.ToInt32(part[part.Length - 1]);
                    }catch(Exception ex) {
                        amount = -1;
                    }
                    int testeri = Convert.ToInt32(tester.Split(" ")[tester.Split(" ").Length - 1]);
                    int totta = Convert.ToInt32(tosi.Split(" ")[tosi.Split(" ").Length - 1]);
                    int eitotta = Convert.ToInt32(eitosi.Split(" ")[eitosi.Split(" ").Length - 1]);
                    MonkeyPart1 monkey = new MonkeyPart1(oper, amount, testeri, totta, eitotta);
                    string[] items = starting.Trim().Split(" ");
                    for(int i=2;i<items.Length;i++) {
                        if (items[i].Contains(",")) {
                            items[i] = items[i].Remove(items[i].Length- 1);
                        }
                        monkey.catchItem(Convert.ToInt32(items[i]));
                    }
                    monkeys.Add(monkey);
                }
            }
            for(int i = 0; i < 20; i++) {
                foreach(MonkeyPart1 monkey in monkeys) {
                    while (true) {
                        Vector2 round = monkey.inspect();
                        if (round.X < 0) break;
                        monkeys[(int)round.X].catchItem((int)round.Y);
                    }
                }
            }
            int[] max = new int[2];
            foreach(MonkeyPart1 monkey in monkeys) {
                if(max[0]<monkey.sum) {
                    max[1] = max[0];
                    max[0] = monkey.sum;
                }else if (max[1] < monkey.sum) {
                    max[1] = monkey.sum;
                }
            }
            Console.WriteLine("Result is "+ max[0] * max[1]);
        }
        private class Fling {
            public Fling() {

            }
            public Fling(int monkey, ulong item) {
                this.monkey = monkey;
                this.item = item;
            }

            public int monkey;
            public ulong item;
        }
        private class Monkey {
            public Monkey(Operation oper, int amount, int test, int isT, int isF) {
                this.operation = oper;
                this.test = test;
                this.isTrue = isT;
                this.amount = amount;
                this.isFalse = isF;
                testList = new List<ulong>();
            }

            private Operation operation;
            private int amount;
            private int test;
            public ulong sum = 0;
            int isTrue = 0;
            int isFalse = 0;
            List<ulong> testList;
            

            public Fling inspect() {
                if (testList.Count == 0) { return new Fling(-1, 0); }
                Fling result = new Fling();
                if (operation == Operation.ADD) {
                    testList[0] = testList[0] + (ulong)amount;
                } else {
                    if (amount < 0) {
                        testList[0] = testList[0] * testList[0];
                    } else {
                        testList[0] = testList[0] * (ulong)amount;
                    }
                }
               
                testList[0] = testList[0] % sumValue;
                if (testList[0] % (ulong)test == 0) {
                    result.monkey = isTrue;
                    result.item = testList[0];
                } else {
                    result.monkey = isFalse;
                    result.item = testList[0];
                }
                testList.RemoveAt(0);
                sum++;
                return result;
            }

            public void catchItem(ulong item) {
                testList.Add(item);
            }
        }

        public void Solve2() {
            sumValue = 1UL;
            List<Monkey> monkeys = new List<Monkey>();
            using (StreamReader inputFile = File.OpenText(@"D11InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    Operation oper;
                    string line = inputFile.ReadLine();
                    string starting = inputFile.ReadLine();
                    string operate = inputFile.ReadLine();
                    string tester = inputFile.ReadLine();
                    string tosi = inputFile.ReadLine();
                    string eitosi = inputFile.ReadLine();
                    inputFile.ReadLine();
                    string[] part = operate.Split(" ");
                    if (part[part.Length - 2] == "+") {
                        oper = Operation.ADD;
                    } else {
                        oper = Operation.MULTIPLY;
                    }
                    int amount = 0;
                    try {
                        amount = Convert.ToInt32(part[part.Length - 1]);
                    } catch (Exception ex) {
                        amount = -1;
                    }
                    int testeri = Convert.ToInt32(tester.Split(" ")[tester.Split(" ").Length - 1]);
                    sumValue *= (ulong)testeri;
                    int totta = Convert.ToInt32(tosi.Split(" ")[tosi.Split(" ").Length - 1]);
                    int eitotta = Convert.ToInt32(eitosi.Split(" ")[eitosi.Split(" ").Length - 1]);
                    Monkey monkey = new Monkey(oper, amount, testeri, totta, eitotta);
                    string[] items = starting.Trim().Split(" ");
                    for (int i = 2; i < items.Length; i++) {
                        if (items[i].Contains(",")) {
                            items[i] = items[i].Remove(items[i].Length - 1);
                        }
                        monkey.catchItem(Convert.ToUInt64(items[i]));
                    }
                    monkeys.Add(monkey);
                }
            }
            for (int i = 0; i < 10000; i++) {
                foreach (Monkey monkey in monkeys) {
                    while (true) {
                        Fling round = monkey.inspect();
                        if (round.monkey < 0) break;
                        monkeys[round.monkey].catchItem(round.item);
                    }
                }
            }
            ulong[] max = new ulong[2];
            foreach (Monkey monkey in monkeys) {
                if (max[0] < monkey.sum) {
                    max[1] = max[0];
                    max[0] = monkey.sum;
                } else if (max[1] < monkey.sum) {
                    max[1] = monkey.sum;
                }
            }
            Console.WriteLine("Result is " + max[0] * max[1]);
        }
    }
}