namespace ExtendetAndGenerik.Extendet
{
    public static class StringHelper
    {
        public static string Reverse(this string str)
        {
            var chars = str.ToCharArray();

            var res = chars.Reverse();

            str = string.Join("", res);

            return str;
        }

        public static int CountIn(this string str, char symbol)
        {
            var chars = str.ToCharArray();

            var res = chars.Count(c => c == symbol);

            return res;
        }
    }
}
