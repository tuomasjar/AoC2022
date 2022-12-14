
using System.Text;

namespace AdventOfCode {


    public class DayThirteen {
        public enum Result {
            Correct,
            Incorrect,
            Undetermined
        }

        public class Lista {
            public Lista parent;
            public List<Lista> aliListat;
            public int value;
            public Lista(Lista parent) {
                this.aliListat = new List<Lista>();
                this.parent = parent;
                this.value = -1;
            }

            public bool isInteger() {
                return this.aliListat.Count == 0;
            }

            public static Lista parseFromString(String str, Lista parent) {
                Lista lista = new Lista(parent);
                if(str.Length == 0 ) {
                    return lista;
                }
                int level = 0;
                StringBuilder temp = new StringBuilder();
                for(int i = 0; i < str.Length; i++) {
                    if (str[i] == '[') {
                        if(level!=0)temp.Append(str[i]);
                        level++;
                        continue;
                    }
                    if (str[i] == ']' && i< str.Length-1) {
                        level--;
                        if(level!=0)temp.Append(str[i]);
                        continue;
                    }
                    if (str[i] == ',' && level == 0) {
                        lista.aliListat.Add(Lista.parseFromString(temp.ToString(), lista));
                        temp.Clear();
                        continue;
                    }
                    temp.Append(str[i]);
                }
                try {
                    lista.value = Convert.ToInt32(temp.ToString());
                }catch(Exception e) {
                    lista.aliListat.Add(Lista.parseFromString(temp.ToString().Remove(temp.ToString().Length-1), lista));
                }
                return lista;
            }

            public static Result compare(Lista left, Lista right) {
                Result result = Result.Undetermined;



                return result;
            }
        }

        public void Solve1() {
            Lista left = new Lista(null);
            Lista right = new Lista(null);

            using (StreamReader inputFile = File.OpenText(@"D13InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    Console.WriteLine();
                    string inputLine = inputFile.ReadLine();
                    Console.WriteLine(inputLine.Remove(inputLine.Length - 1));
                    left = Lista.parseFromString(inputLine.Substring(1,inputLine.Length-1),null);
                    
                    inputLine = inputFile.ReadLine();
                    Console.WriteLine(inputLine.Remove(inputLine.Length - 1));
                    right = Lista.parseFromString(inputLine.Substring(1, inputLine.Length - 1), null);
                    inputLine = inputFile.ReadLine();

                    Lista currentLeft = left;
                    Lista currentRight = right;
                    int sum = 0;
                    int index = 0;
                    
                }
            }

        }
        public void Solve2() {
           
            using (StreamReader inputFile = File.OpenText(@"D13InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string inputLine = inputFile.ReadLine();
                }
            }
        }
    }
}
