﻿using advent_of_code_2024.day01;
using advent_of_code_2024.day02;
using advent_of_code_2024.day03;
using advent_of_code_2024.day04;

//day01.Run();
//day02.Run();
//var day3 = new day03();
//day3.RunTestdata2();

var day4 = new day04();
day4.ReadInputFromFile();
day4.ParseInput();
Console.WriteLine(day4.ResultCounter);