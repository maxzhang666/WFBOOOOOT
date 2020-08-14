namespace WFBooooot.IOT.Extension
{
    public static class StringExtension
    {
        public static string Format(this string source)
        {
            return source.Replace(" ", "").ToLower().Trim();
        }
    }
}