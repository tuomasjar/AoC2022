
namespace AdventOfCode {
    public class DaySeven {
        public static List<int> folderSizes = new List<int>();
        private class Kansio {
            public string name;
            Kansio parent;
            List<Kansio> kansiot;
            List<int> fileSizes;
            public Kansio(string name, Kansio parent) {
                this.name = name;
                this.parent = parent;
                kansiot = new List<Kansio>();
                fileSizes = new List<int>();
            }

            public void addKansio(Kansio kansio) {
                kansiot.Add(kansio);
            }

            public int getFilesizes() {
                int retval = 0;
                foreach(Kansio kansio in kansiot) {
                    retval += kansio.getFilesizes();
                }
                foreach(int i in fileSizes) {
                    retval += i;
                }
                folderSizes.Add(retval);
                return retval;
            }

            public void addFile(int i) {
                fileSizes.Add(i);
            }

            public Kansio getParent() {
                return parent;
            }

            public Kansio getNextKansiot(string name) {
                
                foreach (Kansio kansio in kansiot) {
                    if (kansio.name == name) return kansio;
                }
                return null;
            }

        }


        public void Solve1() {
            int sum = 0;
            bool found = true;
            Kansio currentKansio = new Kansio("root",null);
            Dictionary<char, int> map = new Dictionary<char, int>();
            using (StreamReader inputFile = File.OpenText("D7InputText.txt")) {
                inputFile.ReadLine();
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    if (parts[0] == "$") {
                        if (line.Contains("ls")) continue;
                        if (line.Contains("cd")) {
                            if (line.Contains("..")) {
                                if (currentKansio.getParent() == null) {
                                    continue;
                                }
                                currentKansio = currentKansio.getParent();
                            } else if (parts[2]=="/") {
                                while(currentKansio.getParent() != null) {
                                    currentKansio = currentKansio.getParent();
                                }
                            } else {
                                currentKansio = currentKansio.getNextKansiot(parts[2]);
                            }
                        }
                    } else {
                        if (parts[0]=="dir") {
                            Kansio nextKansio = new Kansio(parts[1], currentKansio);
                            currentKansio.addKansio(nextKansio);
                        } else {
                            currentKansio.addFile(Convert.ToInt32(parts[0]));
                        }
                    }
                }
                while(currentKansio.getParent() != null) {
                    currentKansio= currentKansio.getParent();
                }
                currentKansio.getFilesizes();
                foreach (var item in folderSizes) {
                    if(item <= 100000) {
                        sum += item;
                    }
                }
            }
            Console.WriteLine(sum);
        }
        public void Solve2() {
            folderSizes.Clear();
            int sum = 0;
            bool found = true;
            Kansio currentKansio = new Kansio("root", null);
            Dictionary<char, int> map = new Dictionary<char, int>();
            using (StreamReader inputFile = File.OpenText("D7InputText.txt")) {
                inputFile.ReadLine();
                while (!inputFile.EndOfStream) {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(" ");
                    if (parts[0] == "$") {
                        if (line.Contains("ls")) continue;
                        if (line.Contains("cd")) {
                            if (line.Contains("..")) {
                                if (currentKansio.getParent() == null) {
                                    continue;
                                }
                                currentKansio = currentKansio.getParent();
                            } else if (parts[2] == "/") {
                                while (currentKansio.getParent() != null) {
                                    currentKansio = currentKansio.getParent();
                                }
                            } else {
                                currentKansio = currentKansio.getNextKansiot(parts[2]);
                            }
                        }
                    } else {
                        if (parts[0] == "dir") {
                            Kansio nextKansio = new Kansio(parts[1], currentKansio);
                            currentKansio.addKansio(nextKansio);
                        } else {
                            currentKansio.addFile(Convert.ToInt32(parts[0]));
                        }
                    }
                }
                while (currentKansio.getParent() != null) {
                    currentKansio = currentKansio.getParent();
                }
                currentKansio.getFilesizes();
                int max = 0;
                foreach(int i in folderSizes) {
                    if (i > max) max = i;
                }
                int wholeSize = 70000000;
                int sizeNeeded = 30000000;
                int sizeRemaining = wholeSize - max;
                int sizeWanted = sizeNeeded - sizeRemaining;
                List<int> bigEnough = new List<int>();
                foreach(int i in folderSizes) {
                    if (i > sizeWanted) {
                        bigEnough.Add(i);
                    }
                }
                int min = wholeSize;
                foreach(int i in bigEnough) {
                    if (i < min) min = i;
                }
                Console.WriteLine(min);
            }
            
        }
    }
}