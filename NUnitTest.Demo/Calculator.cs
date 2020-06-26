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
    }
}
