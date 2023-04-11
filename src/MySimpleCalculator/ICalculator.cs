namespace MySimpleCalculator
{
    public interface ICalculator
    {
        int? N1 { get; set; }
        int? N2 { get; set; }

        int Add(int? N1, int? N2);
        double Divide(double? N1, double? N2);
        int Multiply(int? N1, int? N2);
        int Subtract(int? N1, int? N2);
    }
}