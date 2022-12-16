
using System;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode {
    public class DayFifteen {

        public class Sensor {

            public int x, y;
            public int closestX, closestY;
            public int distance;

            public Sensor(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public void addBeacon(int deltaX, int deltaY) {
                closestX = deltaX;
                closestY = deltaY;
                distance = Math.Abs(x-deltaX) + Math.Abs(y-deltaY);
                if (x - distance < minX) minX = x - distance;
                if (x + distance > maxX) maxX = x + distance;
            }

            public bool free(int x, int y) {
                if(x == closestX && y == closestY) {
                    return false;
                }
                if(x == this.x && y == this.y) {
                    return false;
                }
                return true;
            }
            
            public bool closeEnough(int x, int y) {
                return Math.Abs(this.x - x) + Math.Abs(this.y - y) <= distance;
            }
        }

        public class Beacon {
            public int x, y;
            public int distance;

            public Beacon(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public void addSensor(int sensorX, int sensorY) {
                int manhattan = Math.Abs(x - sensorX) + Math.Abs(y - sensorY);
                if (manhattan > this.distance) this.distance = manhattan;
            }
            public bool closeEnough(int x, int y) {
                return Math.Abs(this.x - x) + Math.Abs(this.y - y) <= distance;
            }
        }
        List<Beacon> beacons = new List<Beacon>();

        List<Sensor> sensors = new List<Sensor>();
        static int minX = Int32.MaxValue;
        static int maxX = Int32.MinValue;

        public void Solve1() {
            
            using (StreamReader inputFile = File.OpenText(@"D15InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string input = inputFile.ReadLine();
                    string[] parts = input.Split(" ");
                    int x = Convert.ToInt32(parts[2].Split("=")[1].Remove(parts[2].Split("=")[1].Length - 1));
                    int y = Convert.ToInt32(parts[3].Split("=")[1].Remove(parts[3].Split("=")[1].Length - 1));
                    int deltaX = Convert.ToInt32(parts[8].Split("=")[1].Remove(parts[8].Split("=")[1].Length - 1));
                    int deltaY = Convert.ToInt32(parts[9].Split("=")[1]);
                    Sensor sensor = new Sensor(x, y);
                    sensor.addBeacon(deltaX, deltaY);
                    sensors.Add(sensor);
                }
            }
            int targetY = 2000000;
            bool free = false;
            int sum = 0;
            for (int x = minX-2; x <= maxX+2; x++) {
                foreach(Sensor sensor in sensors) {
                    if (!sensor.free(x, targetY)) {
                        //Console.WriteLine("Beacon");
                        free = false;
                        break;
                    } else {
                        if (sensor.closeEnough(x, targetY)) {
                            free = true;
                        }
                    }
                }
                if (free) {
                    //Console.WriteLine("Free");
                    sum++;
                }
                free = false;
            }
            Console.WriteLine(sum + 2);
        }
        public void Solve2() {
            int limit = 4000000;
            ulong result = 0;
            using (StreamReader inputFile = File.OpenText(@"D15InputText.txt")) {
                while (!inputFile.EndOfStream) {
                    string input = inputFile.ReadLine();
                    string[] parts = input.Split(" ");
                    int x = Convert.ToInt32(parts[2].Split("=")[1].Remove(parts[2].Split("=")[1].Length - 1));
                    int y = Convert.ToInt32(parts[3].Split("=")[1].Remove(parts[3].Split("=")[1].Length - 1));
                    int deltaX = Convert.ToInt32(parts[8].Split("=")[1].Remove(parts[8].Split("=")[1].Length - 1));
                    int deltaY = Convert.ToInt32(parts[9].Split("=")[1]);
                    Sensor sensor = new Sensor(x, y);
                    sensor.addBeacon(deltaX, deltaY);
                    sensors.Add(sensor);
                }
            }
            foreach(Sensor sensor in sensors) {

                int currentX = sensor.x - (sensor.distance+1);
                int currentY = sensor.y;
                for(int i = 0; i < sensor.distance + 1; i++) {
                    if (currentX + i  < 0 || currentX + i > limit) continue;
                    if (currentY + i  < 0 || currentY + i > limit) continue;
                    bool found = false;
                    
                    foreach (Sensor sensor2 in sensors) {
                        if (sensor == sensor2) continue;
                        if(sensor2.closeEnough(currentX + i, currentY + i)){
                            found = true;
                            break;
                        }
                    }
                    
                    if (!found) {
                        Console.WriteLine((currentX + i) + " " + (currentY + i));
                        result = (ulong)(currentX + i) * 4000000UL + (ulong)(currentY + i);
                        Console.WriteLine(result);
                        return;
                    }
                }
                currentX = sensor.x;
                currentY = sensor.y + sensor.distance + 1;

                for (int i = 0; i < sensor.distance + 1; i++) {
                    if (currentX + i < 0 || currentX + i > limit) continue;
                    if (currentY - i < 0 || currentY - i > limit) continue;
                    bool found = false;
                    foreach (Sensor sensor2 in sensors) {
                        if (sensor == sensor2) continue;
                        if (sensor2.closeEnough(currentX + i, currentY - i)) {
                            found = true;
                            
                            break;
                        }
                    }
                    if (!found) {
                        Console.WriteLine((currentX + i) + " " + (currentY - i));
                        result = (ulong)(currentX + i) * 4000000UL + (ulong)(currentY - i);
                        Console.WriteLine(result);
                        return;
                    }
                }
                currentX = sensor.x + sensor.distance + 1;
                currentY = sensor.y - (sensor.distance + 1);

                for (int i = 0; i < sensor.distance + 1; i++) {
                    if (currentX - i < 0 || currentX - i > limit) continue;
                    if (currentY - i < 0 || currentY - i > limit) continue;
                    bool found = false;
                    
                    foreach (Sensor sensor2 in sensors) {
                        if (sensor == sensor2) continue;
                        if (sensor2.closeEnough(currentX - i, currentY - i)) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        Console.WriteLine((currentX - i) + " " + (currentY - i));
                        result = (ulong)(currentX - i) * 4000000UL + (ulong)(currentY - i);
                        Console.WriteLine(result);
                        return;
                    }
                }
                currentX = sensor.x;
                currentY = sensor.y - (sensor.distance + 1); 

                for (int i = 0; i < sensor.distance + 1; i++) {
                    if (currentX - i < 0 || currentX - i > limit) continue;
                    if (currentY - i < 0 || currentY + i > limit) continue;
                    bool found = false;
                    
                    foreach (Sensor sensor2 in sensors) {
                        if (sensor == sensor2) continue;
                        if (sensor2.closeEnough(currentX - i, currentY + i)) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        Console.WriteLine((currentX - i) + " " + (currentY + i));
                        result = (ulong)(currentX - i) * 4000000UL + (ulong)(currentY + i);
                        Console.WriteLine(result);
                        return;
                    }
                }
            }
        }
    }
}