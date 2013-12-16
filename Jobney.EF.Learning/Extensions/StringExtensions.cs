namespace Jobney.EF.Learning.Extensions
{
    public static class StringExtensions
    {
        public static string slugify(this string str)
        {
            return string.Join("-", str.ToLower().Split(' '));
        }
    }
}