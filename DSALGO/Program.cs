// See https://aka.ms/new-console-template for more information
using DSALGO;
using DSALGO.ManualTest;
using DSALGO.DataStructures;
using static System.Console;

Console.WriteLine("Hello World");

BinarySearchTree A = new ABinarySearchTree();
A.Insert(10);
A.Insert(5);
A.Insert(15);
A.Insert(3);
A.Insert(7);
A.Insert(13);
A.Insert(1);

WriteLine(A.MinHeight());
WriteLine(A.MaxHeight());

void PrintList(List<int> list) {
    string s = "";
    foreach (var item in list) {
        s += item + ", ";
    }
    Console.WriteLine(s);  
}
public class Node {
    public int data = 0;
    public Node next;
    public Node(int data, Node next) { 
        this.data = data;
        this.next = next;
    }
};
