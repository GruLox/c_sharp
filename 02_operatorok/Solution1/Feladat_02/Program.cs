﻿Console.Write("Please enter the first number: ");
int n1 = int.Parse(Console.ReadLine());

Console.Write("Please enter the second number: ");
int n2 = int.Parse(Console.ReadLine());

Console.Write("Please enter the third number: ");
int n3 = int.Parse(Console.ReadLine());

int eredmeny = n1 + n2 - n3;

Console.WriteLine($"Az eredmény: {eredmeny}");

Console.ReadKey();