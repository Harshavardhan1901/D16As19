using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Assignment19
//{
//    //Part 1
//    delegate int ArithmeticOperation(int a, int b);

//    class Program
//    {
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }

//        static int Subtract(int a, int b)
//        {
//            return a - b;
//        }

//        static int Multiply(int a, int b)
//        {
//            return a * b;
//        }

//        static int Divide(int a, int b)
//        {
//            if (b != 0)
//                return a / b;
//            else
//                throw new ArgumentException("Cannot divide by zero.");
//        }

//        static void Main(string[] args)
//        {
//            ArithmeticOperation addDelegate = new ArithmeticOperation(Add);
//            ArithmeticOperation subtractDelegate = new ArithmeticOperation(Subtract);
//            ArithmeticOperation multiplyDelegate = new ArithmeticOperation(Multiply);
//            ArithmeticOperation divideDelegate = new ArithmeticOperation(Divide);

//            while (true)
//            {
//                Console.WriteLine("Enter two integers:");
//                int num1 = int.Parse(Console.ReadLine());
//                int num2 = int.Parse(Console.ReadLine());

//                Console.WriteLine("Choose an arithmetic operation:");
//                Console.WriteLine("1 - Addition");
//                Console.WriteLine("2 - Subtraction");
//                Console.WriteLine("3 - Multiplication");
//                Console.WriteLine("4 - Division");

//                int choice = int.Parse(Console.ReadLine());

//                int result = 0;
//                switch (choice)
//                {
//                    case 1:
//                        result = addDelegate(num1, num2);
//                        break;
//                    case 2:
//                        result = subtractDelegate(num1, num2);
//                        break;
//                    case 3:
//                        result = multiplyDelegate(num1, num2);
//                        break;
//                    case 4:
//                        try
//                        {
//                            result = divideDelegate(num1, num2);
//                        }
//                        catch (ArgumentException ex)
//                        {
//                            Console.WriteLine(ex.Message);
//                            continue;
//                        }
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice.");
//                        continue;
//                }

//                Console.WriteLine("Result: " + result);

//                Console.WriteLine("Do you want to continue? (Y/N):");
//                string continueChoice = Console.ReadLine().Trim().ToUpper();
//                if (continueChoice != "Y")
//                    break;
//                Console.ReadKey();
//            }
            
//        }
//    }
//}



//Part 2
namespace Assignment19
{
    delegate T Operation<T>(T a, T b);

    internal class Program
    {
        static T Add<T>(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }

        static T Subtract<T>(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da - db;
        }

        static T Multiply<T>(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da * db;
        }

        static T Divide<T>(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;

            if (db != 0)
                return da / db;
            else
                throw new ArgumentException("Cannot divide by zero.");
        }

        static void Main(string[] args)
        {
            Operation<int> addDelegate = new Operation<int>(Add);
            Operation<int> subtractDelegate = new Operation<int>(Subtract);
            Operation<int> multiplyDelegate = new Operation<int>(Multiply);
            Operation<int> divideDelegate = new Operation<int>(Divide);

            while (true)
            {
                Console.WriteLine("Enter two values of the same data type:");
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();

                int choice;
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please choose a valid operation.");
                }

                int result = 0;
                try
                {
                    switch (choice)
                    {
                        case 1:
                            result = addDelegate(Convert.ToInt32(input1), Convert.ToInt32(input2));
                            break;
                        case 2:
                            result = subtractDelegate(Convert.ToInt32(input1), Convert.ToInt32(input2));
                            break;
                        case 3:
                            result = multiplyDelegate(Convert.ToInt32(input1), Convert.ToInt32(input2));
                            break;
                        case 4:
                            try
                            {
                                result = divideDelegate(Convert.ToInt32(input1), Convert.ToInt32(input2));
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                    }

                    Console.WriteLine("Result: " + result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter valid values of the same data type.");
                }

                Console.WriteLine("Do you want to continue? (Y/N):");
                string continueChoice = Console.ReadLine().Trim().ToUpper();
                if (continueChoice != "Y")
                    break;
                Console.ReadKey();
            }
        }
    }
}