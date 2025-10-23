// See https://aka.ms/new-console-template for more information
int[] a = { 10, 50, 30 };
int[,] b = { { 1, 2, 3 }, { 4, 5, 6 } };

int d1 = a.Rank;
int d2 = b.Rank;

Console.WriteLine(" > 차원 수 : " + d1);
Console.WriteLine(" > 차원 수 : " + d2);