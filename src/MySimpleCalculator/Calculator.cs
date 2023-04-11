namespace MySimpleCalculator
{
    using System;

    public class Calculator : ICalculator
    {
        public int? N1 { get; set; }
        public int? N2 { get; set; }
        public int Add(int? N1, int? N2)
        {
            CheckForNull(N1, N2);
            return N1.Value + N2.Value;
        }
        public int Subtract(int? N1, int? N2)
        {
            CheckForNull(N1, N2);
            return N1.Value - N2.Value;
        }
        public int Multiply(int? N1, int? N2)
        {
            CheckForNull(N1, N2);
            return N1.Value * N2.Value;
        }
        public double Divide(double? N1, double? N2)
        {
            CheckForNull(N1, N2);
            CheckDivisionZero(N2);
            return N1.Value / N2.Value;
        }
        private static void CheckForNull(int? N1, int? N2)
        {
            if (!N1.HasValue || !N2.HasValue)
                throw new ArgumentNullException();
        }
        private static void CheckForNull(double? N1, double? N2)
        {
            if (!N1.HasValue || !N2.HasValue)
                throw new ArgumentNullException();
        }
        private static void CheckDivisionZero(double? N2)
        {
            if (N2.Value == 0)
                throw new DivideByZeroException();
        }
    }
}