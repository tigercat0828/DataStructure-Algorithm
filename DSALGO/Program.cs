using static DSALGO.Utility;
using DSALGO.DataStructure.Graph;
using DSALGO.Algorithm.Sorting;

int[] array = { 9, 1, 8, 2, 7, 3, 6, 4, 5 };

array.Print();
QuickSort<int>.Run(array);

array.Print();