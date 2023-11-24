using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Node : ICloneable
    {
        public int[,]? A; // 1 trang thai
        public int Id = 0;//id trong list
        public int H; //Dinh gia tu Node hien tai toi dich(end)
        public int Step = 0; // buoc hien tai
        public Node Pa; // trang thai cha
        public virtual object Clone()
        {
            Node m = (Node)this.MemberwiseClone();
            m.A = (int[,])this.A.Clone();
            return m;
        }
        public Node(int[,] a)
        {
            A = a;
        }
        public Node()
        {

        }
        public void Input()
        {
            A = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Nhap phan tu thu {0} {1}", i, j);
                    A[i, j] = int.Parse(Console.ReadLine());
                }

        }
        public void Output()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Id = " + Id);
            Console.WriteLine("Step = " + Step);
            Console.WriteLine("H = " + H);
            Console.WriteLine("===============================");
        }
        public void Goal1() // trang thai dich
        {
            A = new int[3, 3];
            A[0, 0] = 0;
            A[0, 1] = 1;
            A[0, 2] = 2;
            A[1, 0] = 3;
            A[1, 1] = 4;
            A[1, 2] = 5;
            A[2, 0] = 6;
            A[2, 1] = 7;
            A[2, 2] = 8;
        }
        public void Goal2() // trang thai dich
        {
            A = new int[3, 3];
            A[0, 0] = 1;
            A[0, 1] = 2;
            A[0, 2] = 3;
            A[1, 0] = 8;
            A[1, 1] = 0;
            A[1, 2] = 4;
            A[2, 0] = 7;
            A[2, 1] = 6;
            A[2, 2] = 5;
        }
        public void RandomA()
        {
            A = new int[3, 3];
            A[0, 0] = 0;
            A[0, 1] = 1;
            A[0, 2] = 2;
            A[1, 0] = 3;
            A[1, 1] = 4;
            A[1, 2] = 5;
            A[2, 0] = 6;
            A[2, 1] = 7;
            A[2, 2] = 8;
            int i = 0, j = 0;
            Random x = new Random();
            for (int k = 0; k < 500; k++)
            {
                int z = x.Next(1, 5);
                if (z == 1 && i > 0)//Len
                {
                    int tg = A[i, j];
                    A[i, j] = A[i - 1, j];
                    A[i - 1, j] = tg;
                    i = i - 1;
                }
                if (z == 2 && i < 2)//Xuong
                {
                    int tg = A[i, j];
                    A[i, j] = A[i + 1, j];
                    A[i + 1, j] = tg;
                    i = i + 1;
                }
                if (z == 3 && j > 0)//Trai
                {
                    int tg = A[i, j];
                    A[i, j] = A[i, j - 1];
                    A[i, j - 1] = tg;
                    j = j - 1;
                }
                if (z == 4 && j < 2)//Phai
                {
                    int tg = A[i, j];
                    A[i, j] = A[i, j + 1];
                    A[i, j + 1] = tg;
                    j = j + 1;
                }
            }
        }
    }
}
