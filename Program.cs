using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[,] array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

                Matrix matrix = new Matrix(array, 3);

                //Foreach in overrided ToString() method
                Console.WriteLine(matrix);
            }
            catch(ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
