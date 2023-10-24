namespace RockPaperScissorsConsole.Classes.CustomExtensions
{
    public static class StringExtensions
    {
        public static string ToBannerString(this string str)
        {
            if (str == null)
            {
                return string.Empty;
            }

            string bannerTopAndBottom = new('#', (str.Length + 6));
            string bannerMiddle = $"#  {str}  #";
            return string.Join("\n", bannerTopAndBottom, bannerMiddle, bannerTopAndBottom);
        }
    }
}
