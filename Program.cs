using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_123
{
    class node
    {
        //Deklarasi variabel node
        public int noBuku;
        public string judul;
        public string namaPengarang;
        public int tahun;
        public node next;
    }

    class CircularLinkedList
    {
        node LAST;
        public CircularLinkedList()
        {
            LAST = null;
        }

        //add node 
        public void addnode()
        {
            int number;
            string nm;
            string nmbr;
            int thn;

            //deklarasi element
            Console.WriteLine("\nMasukkan No Buku : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Judul Buku : ");
            nm = Console.ReadLine();
            Console.WriteLine("\nMasukkan  nama Pengarang : ");
            nmbr = Console.ReadLine();
            Console.WriteLine("\nMasukkan Tahun Terbit : ");
            thn = Convert.ToInt32(Console.ReadLine());

            node newnode = new node();

            //membuat penyimpanan
            newnode.noBuku = number;
            newnode.judul = nm;
            newnode.namaPengarang = nmbr;
            newnode.tahun = thn;

            //if list empty
            if (listempty())
            {
                newnode.next = newnode;
                LAST = newnode;
            }
            //mulai proses pengurutan proses pengurutan data
            else if (number < LAST.next.noBuku)//node dari kiri
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
            }
            else if (number > LAST.noBuku)//node dari kanan
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
                LAST = newnode;
            }
            //menambahkan node ditengah-tengah
            else
            {
                node current, previous;
                current = previous = LAST.next;

                int i = 0;
                while (i < number - 1)
                {
                    previous = current;
                    current = current.next;
                    i++;
                }
                newnode.next = current;
                previous.next = newnode;
            }
        }
        //menambahkan method mencari data
        public bool Search(int thn, ref node previous, ref node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (thn == current.tahun)
                    return true;//return true if the node is found
            }
            if (thn == LAST.tahun)
                return true;
            else
                return (false);
        }
        //menambahkan method delete
        public bool delNode(int number)
        {
            node previous, current;
            previous = current = LAST.next;

            //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
            if (Search(number, ref previous, ref current) == false)
                return false;
            previous.next = current.next;

            //proses mendelete data
            if (LAST.next.noBuku == LAST.noBuku)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (number == LAST.noBuku)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
        }
        //mendisplay atau traverse semua node di list
        public void display()
        {
            //if list empty
            if (listempty())
                Console.WriteLine("\nDaftar buku kosong : ");
            //menampilkan data
            else
            {
                Console.WriteLine("\nDaftar Buku yang ada : ");
                node currentNode;

                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.noBuku + " " + currentNode.judul + " " + currentNode.namaPengarang + " " +
                        currentNode.tahun + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.noBuku + " " + LAST.judul + " " + LAST.namaPengarang + " " + LAST.tahun + "\n");
            }
        }
        public bool listempty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        public void Demo()
        {
            Console.WriteLine("========================");
            Console.WriteLine("----DATA PERPUSTAKAAN----");
            Console.WriteLine("========================");
            Console.WriteLine("1. Tambahkan Data");
            Console.WriteLine("2. Delete ");
            Console.WriteLine("3. Menampilkan");
            Console.WriteLine("4. Mencari berdasarkan tahun");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine("Enter your choice (1-6): ");
        }
        static void Main(string[] args)
        {
            Program menu = new Program();
            CircularLinkedList data = new CircularLinkedList();
            node a = new node();

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    menu.Demo();
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        //add data
                        case '1':
                            {
                                data.addnode();
                            }
                            break;
                        //del node
                        case '2':
                            {
                                if (data.listempty())
                                {
                                    Console.WriteLine("\nlist is empty");
                                    break;
                                }
                                //pencarian node list yang akan didelete
                                Console.Write("\nMasukkan No.Barang yang akan dihapus : ");
                                int value = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //output data yang didelete node
                                if (data.delNode(value) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                    Console.WriteLine("Data Barang dengan No" + value + "dihapus dari list");
                            }
                            break;
                        //display
                        case '3':
                            {
                                data.display();
                            }
                            break;
                        case '4':
                            {
                                //if list empyty
                                if (data.listempty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }

                                //proses pencarian
                                node previous, current;
                                previous = current = null;

                                Console.Write("\nMasukkan tahun : ");
                                int value = Convert.ToInt32(Console.ReadLine());

                                //memulai pencarian
                                if (data.Search(value, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else//mencari output
                                {
                                    Console.WriteLine("\n====================");
                                    Console.WriteLine("----Data ditemukan----");
                                    Console.WriteLine("====================\n");
                                    Console.WriteLine("No.Buku       : " + current.noBuku);
                                    Console.WriteLine("Judul     : " + current.judul);
                                    Console.WriteLine("Nama Pengarang   : " + current.namaPengarang);
                                    Console.WriteLine("Tahun Terbit : " + current.tahun);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\ninvalid Option");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        
    }
}





/*
 
 2. dengan Circularlinklist
 3.POP dan PUSH
 4.REAR dan FRONT
 5. a.kedalaman yang ada yaitu 5
    b.postorder yaitu dimulai dari kanan

 */
