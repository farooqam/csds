namespace CsdsLib
{
    public static class NumericExtensions
    {
        public static int Fibbonacci(this int n)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < n; i++)
            {
                var save = a;
                a = b;
                b = b + save;
            }

            return a;
        }
    }
}