using System;

namespace NUnitTest.Demo
{
    public class Calculator : IDisposable
    {
        public int Addition (int first, int second)
        {
            return first + second;
        }

        public void Dispose()
        {
            //TODO
        }

        public int Substraction(int first, int second)
        {
            return first < second 
                ? throw new ArgumentException($"First number {first} is less than second number {second}")
                : first - second;
        }

        public int Divide(int first, int second)
        {
            return second == 0
                ? throw new DivideByZeroException($"Divide error. You can not divide by {second}")
                : first / second;
        }

        public bool IsPar(int number)
        {
            return number%2 == 0;
        }
    }
}
