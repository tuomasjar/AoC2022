
/*
 * 
 * [S]                 [T] [Q]        
 * [L]             [B] [M] [P]     [T]
 * [F]     [S]     [Z] [N] [S]     [R]
 * [Z] [R] [N]     [R] [D] [F]     [V]
 * [D] [Z] [H] [J] [W] [G] [W]     [G]
 * [B] [M] [C] [F] [H] [Z] [N] [R] [L]
 * [R] [B] [L] [C] [G] [J] [L] [Z] [C]
 * [H] [T] [Z] [S] [P] [V] [G] [M] [M]
 *  1   2   3   4   5   6   7   8   9 
 * 
 * 
 * 
 * 
 */


using System.Text;

namespace AdventOfCode {
    public class DayFive {
        private class CrateStack {
            private Stack<char> Cratelist = new Stack<char>();
            public CrateStack(int stackNr) {
                switch(stackNr) {
                    case 1:
                    Cratelist.Push('H');
                    Cratelist.Push('R');
                    Cratelist.Push('B');
                    Cratelist.Push('D');
                    Cratelist.Push('Z');
                    Cratelist.Push('F');
                    Cratelist.Push('L');
                    Cratelist.Push('S');
                    break;
                    case 2:
                    Cratelist.Push('T');
                    Cratelist.Push('B');
                    Cratelist.Push('M');
                    Cratelist.Push('Z');
                    Cratelist.Push('R');
                    break;
                    case 3:
                    Cratelist.Push('Z');
                    Cratelist.Push('L');
                    Cratelist.Push('C');
                    Cratelist.Push('H');
                    Cratelist.Push('N');
                    Cratelist.Push('S');
                    break;
                    case 4:
                    Cratelist.Push('S');
                    Cratelist.Push('C');
                    Cratelist.Push('F');
                    Cratelist.Push('J');
                    break;
                    case 5:
                    Cratelist.Push('P');
                    Cratelist.Push('G');
                    Cratelist.Push('H');
                    Cratelist.Push('W');
                    Cratelist.Push('R');
                    Cratelist.Push('Z');
                    Cratelist.Push('B');
                    break;
                    case 6:
                    Cratelist.Push('V');
                    Cratelist.Push('J');
                    Cratelist.Push('Z');
                    Cratelist.Push('G');
                    Cratelist.Push('D');
                    Cratelist.Push('N');
                    Cratelist.Push('M');
                    Cratelist.Push('T');
                    break;
                    case 7:
                    Cratelist.Push('G');
                    Cratelist.Push('L');
                    Cratelist.Push('N');
                    Cratelist.Push('W');
                    Cratelist.Push('F');
                    Cratelist.Push('S');
                    Cratelist.Push('P');
                    Cratelist.Push('Q');
                    break;
                    case 8:
                    Cratelist.Push('R');
                    Cratelist.Push('Z');
                    Cratelist.Push('M');
                    break;
                    case 9:
                    Cratelist.Push('M');
                    Cratelist.Push('C');
                    Cratelist.Push('L');
                    Cratelist.Push('G');
                    Cratelist.Push('V');
                    Cratelist.Push('R');
                    Cratelist.Push('T');
                    break;
                    default: throw new ArgumentException();
                }
            }
            public void Push(char c) {
                Cratelist.Push(c);
            }
            public char Pop() {
                return Cratelist.Pop();
            }
        }
        public void Solve1() {
            CrateStack[] crateStacks = new CrateStack[10];
            for(int i = 1; i < 10; i++) {
                crateStacks[i] = new CrateStack(i);
            }

            using (StreamReader inputFile = File.OpenText("D5InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    int repeats = Convert.ToInt32(parts[1]);
                    int source = Convert.ToInt32(parts[3]);
                    int destination = Convert.ToInt32(parts[5]);
                    for(int i=0;i<repeats;i++) {
                        crateStacks[destination].Push(crateStacks[source].Pop());
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            for(int i = 1; i <= 9; i++) {
                result.Append(crateStacks[i].Pop());
            }
            Console.WriteLine(result.ToString());
        }
        public void Solve2() {
            CrateStack[] crateStacks = new CrateStack[10];
            for (int i = 1; i < 10; i++) {
                crateStacks[i] = new CrateStack(i);
            }

            using (StreamReader inputFile = File.OpenText("D5InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    int repeats = Convert.ToInt32(parts[1]);
                    int source = Convert.ToInt32(parts[3]);
                    int destination = Convert.ToInt32(parts[5]);
                    Stack<char> tempStack = new Stack<char>();
                    for (int i = 0; i < repeats; i++) {
                        tempStack.Push(crateStacks[source].Pop());
                    }
                    for (int i = 0; i < repeats; i++) {
                        crateStacks[destination].Push(tempStack.Pop());
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= 9; i++) { 
                result.Append(crateStacks[i].Pop());
            }
            Console.WriteLine(result.ToString());
        }
    }
}