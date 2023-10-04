namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(2, 3);
            ComplexNumber b = new ComplexNumber(-1, 1);
            ComplexNumber c = new ComplexNumber(2, 4);
            ComplexNumber d = new ComplexNumber(-1, 3);

            ComplexNumber R = a.RootByPower(3)-(b+c)/a+b*d;

            try
            {
                Console.WriteLine(R);
                Console.WriteLine(R.Abs());
                Console.WriteLine(R++);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}