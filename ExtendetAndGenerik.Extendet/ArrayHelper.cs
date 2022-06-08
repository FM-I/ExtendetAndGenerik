namespace ExtendetAndGenerik.Extendet
{
    public static class ArrayHelper
    {
        public static int CountIn<T>(this T[] array, T element)
        {
            return array.Count(e => e.Equals(element));
        }

        public static T[] DeleteDublicate<T>(this T[] array)
        {
            var res = array.ToHashSet();

            return res.ToArray();
        }

    }
}
