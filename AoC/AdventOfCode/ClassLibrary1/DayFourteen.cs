
namespace AdventOfCode {
    public class DayFourteen {
        class Sand {
            public int x, y;
            public Sand() {
                x = 500 - startX;
                y = 0;
            }
        }
        const int startX = 0;
        const int endX= 1000;
        const int endY = 170;
        char[,] map = new char[endY, endX - startX];
        public void Solve1() {
            for(int x = 0; x< map.GetLength(0);x++) {
                for(int y = 0; y< map.GetLength(1); y++) {
                    map[x, y] = '.';
                }
            }
            using (StreamReader inputFile = File.OpenText("D14InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string inputLine = inputFile.ReadLine();
                    string[] parts = inputLine.Split("->");
                    int previousX = 0;
                    int previousY = 0;
                    int currentX = 0;
                    int currentY = 0;
                    for(int i=1;i<parts.Length;i++) {
                        previousX= Convert.ToInt32(parts[i - 1].Split(',')[0]) - startX;
                        previousY = Convert.ToInt32(parts[i-1].Split(',')[1]);
                        currentX = Convert.ToInt32(parts[i].Split(',')[0]) - startX;
                        currentY = Convert.ToInt32(parts[i].Split(',')[1]);
                        for(int x = previousX; previousX > currentX ? x >= currentX : x <= currentX ; x+= (previousX <= currentX ? 1 : -1)) {
                            for (int y = previousY; previousY > currentY ? y >= currentY : y <= currentY; y += (previousY <= currentY ? 1 : -1)) {
                                map[y, x] = '#';
                            }
                        }
                    }
                }
            }
            Sand hiekka = new Sand();
            int sum = 0;
            int maxY = 0;
            while (true) {
                if (hiekka.y + 1 == map.GetLength(0)) break;
                if (map[hiekka.y + 1, hiekka.x] == '.') {
                    hiekka.y++;
                }else if (hiekka.x>0 && map[hiekka.y + 1, hiekka.x - 1] == '.') {
                    hiekka.y++;
                    hiekka.x--;
                }else if(hiekka.x<map.GetLength(1) && map[hiekka.y+1, hiekka.x + 1] == '.') {
                    hiekka.y++;
                    hiekka.x++;
                } else {
                    map[hiekka.y, hiekka.x] = 'o';
                    hiekka = new Sand();
                    sum++;
                }
            }
            for(int y = 0;y< map.GetLength(0);y++) {
                for (int x = 0; x < map.GetLength(1); x++) {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);

        }
        public void Solve2() {
            for (int x = 0; x < map.GetLength(0); x++) {
                for (int y = 0; y < map.GetLength(1); y++) {
                    map[x, y] = '.';
                }
            }
            using (StreamReader inputFile = File.OpenText("D14InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string inputLine = inputFile.ReadLine();
                    string[] parts = inputLine.Split("->");
                    int previousX = 0;
                    int previousY = 0;
                    int currentX = 0;
                    int currentY = 0;
                    for (int i = 1; i < parts.Length; i++) {
                        previousX = Convert.ToInt32(parts[i - 1].Split(',')[0]) - startX;
                        previousY = Convert.ToInt32(parts[i - 1].Split(',')[1]);
                        currentX = Convert.ToInt32(parts[i].Split(',')[0]) - startX;
                        currentY = Convert.ToInt32(parts[i].Split(',')[1]);
                        for (int x = previousX; previousX > currentX ? x >= currentX : x <= currentX; x += (previousX <= currentX ? 1 : -1)) {
                            for (int y = previousY; previousY > currentY ? y >= currentY : y <= currentY; y += (previousY <= currentY ? 1 : -1)) {
                                map[y, x] = '#';
                            }
                        }
                    }
                }
            }
            for(int i = 0; i < map.GetLength(1); i++) {
                map[endY-1, i] = '#';
            }
            
            Sand hiekka = new Sand();
            int sum = 0;
            int maxX = 0;
            while (true) {
                if (map[hiekka.y + 1, hiekka.x] == '.') {
                    hiekka.y++;
                } else if (map[hiekka.y + 1, hiekka.x - 1] == '.') {
                    hiekka.y++;
                    hiekka.x--;
                } else if (map[hiekka.y + 1, hiekka.x + 1] == '.') {
                    hiekka.y++;
                    hiekka.x++;
                } else {
                    map[hiekka.y, hiekka.x] = 'o';
                    sum++;
                    if (hiekka.y == 0 && hiekka.x == 500) break;
                    hiekka = new Sand();
                }
                if(hiekka.x > maxX) {
                    maxX = hiekka.x;
                }
            }
            for (int y = 0; y <50; y++) {
                for (int x =450; x < 550; x++) {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);

        }
    }
}