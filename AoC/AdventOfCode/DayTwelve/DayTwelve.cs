

namespace AdventOfCode {

    
    public class DayTwelve {
        private class Coord {
            public int x;
            public int y;
        }
        Coord endPos = new Coord();
        char[][] map;
        int[,] lenghts;
        List<string> visited = new List<string>();
        int minSteps = Int32.MaxValue;
        private void Search(Coord start) {
            Coord current = minDistance();
            while (true) {
                if (map[current.y][current.x] == 'E') {
                    endPos.x = current.x;
                    endPos.y = current.y;
                    break;
                }
                int currentLength = lenghts[current.y, current.x];
                if (        current.x > 0                   && map[current.y][current.x - 1] - map[current.y][current.x] < 2 && lenghts[current.y, current.x - 1] > currentLength + 1) {
                    lenghts[current.y, current.x - 1] = currentLength + 1;
                } 
                if ( current.x < map[0].Length - 1   && map[current.y][current.x + 1] - map[current.y][current.x] < 2 && lenghts[current.y, current.x + 1] > currentLength + 1) {
                    lenghts[current.y, current.x + 1] = currentLength + 1;
                } 
                if ( current.y > 0                   && map[current.y - 1][current.x] - map[current.y][current.x] < 2 && lenghts[current.y - 1, current.x] > currentLength + 1) {
                    lenghts[current.y-1, current.x] = currentLength + 1;
                } 
                if ( current.y < map.Length - 1      && map[current.y + 1][current.x] - map[current.y][current.x] < 2 && lenghts[current.y + 1, current.x] > currentLength + 1) {
                    lenghts[current.y+1, current.x] = currentLength + 1;
                }
                try {
                    current = minDistance();
                } catch (Exception e) {
                    for(int y = 0; y < lenghts.GetLength(0); y++) {
                        for(int x=0; x < lenghts.GetLength(1); x++) {
                            if (lenghts[y, x] < Int32.MaxValue) {
                                if (lenghts[y, x] >= 10) {
                                    Console.Write(lenghts[y, x] + " ");
                                } else {
                                    Console.Write("0" + lenghts[y, x] + " ");
                                }
                            } else {
                                Console.Write(".. ");
                            }
                        }
                        Console.WriteLine();
                    }
                    throw new Exception();
                }
            }
        }

        private Coord minDistance() {
            Coord result = new Coord();
            bool found = false;
            int min = Int32.MaxValue;
            for(int y = 0; y < lenghts.GetLength(0); y++) {
                for(int x = 0; x < lenghts.GetLength(1); x++) {
                    if (visited.Contains(x + " " + y)) continue;
                    if(lenghts[y, x] < min) {
                        min = lenghts[y, x];
                        result.x = x;
                        result.y = y;
                        found = true;
                    }
                }
            }
            if (!found) throw new Exception();
            visited.Add(result.x + " " + result.y);
            //Console.WriteLine("Visited " + result.x + " " + result.y);
            return result;
        }

        public void Solve1() {
            List<char[]> readLines = new List<char[]>();
            using (StreamReader inputFile = File.OpenText(@"D12InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string inputLine = inputFile.ReadLine();
                    readLines.Add(inputLine.ToCharArray());
                }
            }
            map = readLines.ToArray();
            lenghts = new int[map.Length, map[0].Length];
            for(int i=0;i<lenghts.GetLength(0); i++) {
                for(int j = 0; j <lenghts.GetLength(1); j++) {
                    lenghts[i, j] = Int32.MaxValue;
                }
            }
            Coord start = new Coord();
            bool found = false;
            for(int y=0;y<map.Length;y++) {
                for (int x = 0; x < map[y].Length;x++) {
                    if (map[y][x] == 'S') {
                        start.x = x;
                        start.y = y;
                        found = true;
                        break;
                    }
                    if (found) {
                        break;
                    }
                }
            }
           Console.WriteLine("Start: " + start.x + "," + start.y);
           lenghts[start.y, start.x] = 0;
           Search(start);
            Console.WriteLine(lenghts[endPos.y,endPos.x]);
        }
        public void Solve2() {
            List<char[]> readLines = new List<char[]>();
            using (StreamReader inputFile = File.OpenText(@"D12InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string inputLine = inputFile.ReadLine();
                    readLines.Add(inputLine.ToCharArray());
                }
            }
            map = readLines.ToArray();
            lenghts = new int[map.Length, map[0].Length];
            for (int i = 0; i < lenghts.GetLength(0); i++) {
                for (int j = 0; j < lenghts.GetLength(1); j++) {
                    lenghts[i, j] = Int32.MaxValue;
                }
            }
            Coord start = new Coord();
            bool found = false;
            for (int y = 0; y < map.Length; y++) {
                for (int x = 0; x < map[y].Length; x++) {
                    if (map[y][x] == 'S' || map[y][x] == 'a') {
                        lenghts[y, x] = 0;
                    }
                }
            }
            Console.WriteLine("Start: " + start.x + "," + start.y);
            lenghts[start.y, start.x] = 0;
            Search(start);
            Console.WriteLine(lenghts[endPos.y, endPos.x]);
        }
    }
}
    