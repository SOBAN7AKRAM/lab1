using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // lilyTask();
            // sumTask();
            // write();
            //read();
            //mainFunction();
            pizzaOrderTask();
            Console.ReadKey();
        }
        static void lilyTask()
        {
            int age;
            float washingPrice, unitPrice;
            Console.Write("Enter Lily age:");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Washing machine price:");
            washingPrice = float.Parse(Console.ReadLine());
            Console.Write("Enter Unit price of each toy:");
            unitPrice = float.Parse(Console.ReadLine());
            int toys = 0;
            float priceSaved = 0;
            int count = 1;
            float left = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    priceSaved = priceSaved + ((10 * count) - 1);
                    count++;
                }
                else if (i % 2 == 1)
                {
                    toys++;
                }
            }
            float toysTotalPrice = unitPrice * toys;
            float totalPrice = toysTotalPrice + priceSaved;
            if (totalPrice > washingPrice)
            {
                left = totalPrice - washingPrice;
                Console.WriteLine("Yess! {0}", left);
            }
            else if (totalPrice < washingPrice)
            {
                left = washingPrice - totalPrice;
                Console.WriteLine("No! {0}", left);
            }
            Console.ReadKey();
        }
        static void sumTask()
        {
            int number1, number2;
            Console.Write("Enter first number:");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number:");
            number2 = int.Parse(Console.ReadLine());
            int result = add(number1, number2);
            Console.WriteLine("Sum is: {0}", result);
            Console.ReadKey();
        }
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        static void write()
        {
            string path = "D:\\OOP\\lab1\\test.txt";
            if (File.Exists(path))
            {
                StreamWriter filevariable = new StreamWriter(path, true);
                filevariable.WriteLine("Hello");
                filevariable.Flush();
                filevariable.Close();
            }
        }
        static void read()
        {
            string path = "D:\\OOP\\lab1\\test.txt";
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                filevariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option:");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
        }
        static void signIn(string n, string p, string[] names, string[] password)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (n == names[i] && p == password[i])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        static void mainFunction()
        {
            string path = "D:\\OOP\\lab1\\signUp.txt";
            string[] names = new string[5];
            string[] password = new string[5];
            int option;
            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.Write("Enter name:");
                    string n = Console.ReadLine();
                    Console.Write("Enter password:");
                    string p = Console.ReadLine();
                    signIn(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.Write("Enter new name:");
                    string n = Console.ReadLine();
                    Console.Write("Enter new password:");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.Read();
        }
        static void pizzaOrderTask()
        {
            int[] sPrice = new int[10];
            int[] bPrice = new int[8];
            int sOrder=0, bOrder = 0;
            string name1="", name2="";
            int count = 1;
            Console.Write("Enter the orders of pizza:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the price of pizz:");
            int p = int.Parse(Console.ReadLine());
            string path = "D:\\OOP\\lab1\\customers.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    if (count == 1)
                    {
                        name1 = parseD(record, 1);
                        bOrder = int.Parse(parseD(record, 2));
                        for (int i = 0; i < bOrder; i++)
                        {
                            bPrice[i] = int.Parse(readComma(record, i+1));
                        }
                    }
                    else if (count == 2)
                    {
                        name2 = parseD(record, 1);
                        sOrder = int.Parse(parseD(record, 2));
                        for (int i = 0; i < sOrder; i++)
                        {
                            sPrice[i] = int.Parse(readComma(record, i+1));
                        }
                    }
                    count++;
                }
            }
            int count1 = 0;
            int count2 = 0;
            if (n <= bOrder)
            {
                for (int i=0;i<bOrder;i++)
                {
                    if (p<bPrice[i])
                    {
                        count1++;
                    }
                }
            }
            if (n <= sOrder)
            {
                for (int i = 0; i < sOrder; i++)
                {
                    if (p < sPrice[i])
                    {
                        count2++;
                    }
                }
            }
            
            if (count1>=n)
            {
                Console.WriteLine(name1);
            }
            if (count2>=n)
            {
                Console.WriteLine(name2);
            }
            
        }
        static string parseD(string record, int field)
        {
            int space = 1;
            string data = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    space++;
                }
                else if (field == space)
                {

                    if (record[i] != '[' || record[i] != ']')
                    {
                        data = data + record[i];
                    }

                }
            }
            return data;
        }


        static string readComma(string record, int field)
        {
            bool flag = false;
            int comma = 1;
            string data = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == '[')
                {
                    flag = true;
                }
                if (record[i] == ']')
                {
                    flag = false;
                }
                if (flag == true)
                {
                    if (record[i] != '[')
                    {
                        if (record[i] == ',')
                        {
                            comma++;
                        }
                        else if (field == comma)
                        {
                            data = data + record[i];
                        }
                    }
                }
            }
            return data;
        }
    }
}
    

