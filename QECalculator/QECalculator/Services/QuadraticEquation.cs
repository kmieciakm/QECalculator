using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace QECalculator
{
    public static class QuadraticEquation
    {
        public static QuadraticEquationResult Calculate(float a, float b, float c) {
            if (a == 0 && b == 0)
            {
                throw new QuadraticEquationException("This is not quardratic nor linear equation");
            }
            if (a == 0)
            {
                throw new QuadraticEquationException("Equation is linear");
            }

            var delta = (b * b) - (4 * a * c);
            if (delta > 0)
            {
                var x1 = float.Parse(((-b + Math.Sqrt(delta)) / (2 * a)).ToString());
                var x2 = float.Parse(((-b - Math.Sqrt(delta)) / (2 * a)).ToString());
                return new QuadraticEquationResult(x1, x2);
            }
            else if (delta == 0)
            {
                var x = (-b) / 2 * a;
                return new QuadraticEquationResult(x, x);
            }
            else
            {
                return new QuadraticEquationResult(null, null);
            }
        }
    }

    public class QuadraticEquationResult
    {
        public QuadraticEquationResult(float? x1, float? x2) {
            X1 = x1;
            X2 = x2;
        }

        public float? X1 { get; }
        public float? X2 { get; }
        public int RootsAmount {
            get {
                if (X1 == null && X2 == null) return 0;
                if (X1 == X2) return 1;
                return 2;
            }
        }
    }

    public class QuadraticEquationException : Exception
    {
        public QuadraticEquationException()
        {
        }

        public QuadraticEquationException(string message)
            : base(message)
        {
        }

        public QuadraticEquationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
