namespace MySimpleCalculatorWebAPI.Extensions
{
    using MySimpleCalculator;
    //using NDepend.Attributes;

    //[FullCovered]
    public static class MySimpleCalculatorEx
    {
        public static int Mod(this ICalculator calculator, int? n1, int? n2)
        {
            if (calculator is null)
                throw new ArgumentNullException(nameof(calculator));

            if (!n1.HasValue || !n2.HasValue)
                throw new ArgumentNullException();

            if (n2.Value == 0)
                throw new DivideByZeroException(nameof(n2));

            return n1.Value % n2.Value;
        }
    }
}
