using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace Exercise_3
{
    class Program
    {
        public static void Message<T>(object sender, TreeEventArgs<T> e)
        {
            Console.WriteLine($"{e.Item} {e.Message}\n");
        }

        static void Main(string[] args)
        {

            ExamTest studValue1 = new ExamTest("Христич", "Математика", 100, new DateTime(2018, 10, 10));
            ExamTest studValue2 = new ExamTest("Бартов", "Математика", 70, new DateTime(2017, 4, 12));
            ExamTest studValue3 = new ExamTest("Пасечник", "Математика", 80, new DateTime(2016, 2, 3));
            ExamTest studValue4 = new ExamTest("Стратила", "Математика", 90, new DateTime(2017, 5, 10));
            ExamTest studValue5 = new ExamTest("Черепанцева", "Математика", 85, new DateTime(2018, 10, 1));

            BinaryTree<ExamTest> treeExam = new BinaryTree<ExamTest>(studValue3);
            int numValue1 = 4;
            int numValue2 = 2;
            int numValue3 = 5;
            int numValue4 = 1;
            int numValue5 = 3;
            int numValue6 = 7;
            int numValue7 = 8;
            int numValue8 = 6;

            BinaryTree<int> treeInteger = new BinaryTree<int>(numValue1);
            treeInteger.Added += Message;
            
            treeInteger.Add(numValue2);
            treeInteger.Add(numValue3);
            treeInteger.Add(numValue4);
            treeInteger.Add(numValue5);
            treeInteger.Add(numValue6);
            treeInteger.Add(numValue7);
            treeInteger.Add(numValue8);
           
            treeExam.Add(studValue1);
            treeExam.Add(studValue2);
            treeExam.Add(studValue4);
            treeExam.Add(studValue5);

            foreach (var i in treeInteger)
                Console.WriteLine(i);

            foreach (var i in treeExam.PreOrderTraversal())
                Console.WriteLine(i);

            Console.Read();
        }
    }
}
