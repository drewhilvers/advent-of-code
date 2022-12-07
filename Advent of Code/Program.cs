using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code {
  public class Program {
    public static void Main(string[] args) {
      string input = string.Empty;

      while(input.ToLower() != "q") {
        Console.WriteLine("What day would you like to run? (press q to quit)");
        input = Console.ReadLine();

        int day;
        if(int.TryParse(input, out day)) { 
          switch(day) {
            case 1:
              Console.WriteLine("output: " + (DayOne()[0].Sum + DayOne()[1].Sum + DayOne()[2].Sum));
              break;
          }
        }
      }
    }


    public class DayOneElf {
      public int Index = 0;
      public int Sum = 0;
      public List<int> Snacks = new List<int>();
    }

    public static List<DayOneElf> DayOne() {
      string path = @"C:\Repos\Advent of Code\Advent of Code\Input1.txt";
      string[] inputBlob = File.ReadAllLines(path);
      List<DayOneElf> elves = new List<DayOneElf>();

      DayOneElf currentElf = new DayOneElf();
      for(int i = 0; i < inputBlob.Length; i++) {
        int value;
        if(int.TryParse(inputBlob[i], out value)) {
          currentElf.Sum += value;
          currentElf.Snacks.Add(value);
        }
        else {
          InsertElfBySum(elves, currentElf);
          currentElf = new DayOneElf();
        }
      }

      return elves;
    }

    public static void InsertElfBySum(List<DayOneElf> elves, DayOneElf elf) {
      if(elves.Count == 0) {
        elves.Add(elf);
        return;
      }

      for(int i = 0; i < elves.Count; i++) {
        if(elf.Sum > elves[i].Sum) {
          elves.Insert(i, elf);
          return;
        }
      }
    }
  }
}
