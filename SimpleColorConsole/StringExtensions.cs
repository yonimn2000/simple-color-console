namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Provides <see cref="string"/> extension methods for creating <see cref="ColorString"/>s.
    /// </summary>
    public static class StringExtensions
    {
        public static ColorString Color(this string str, ConsoleColor textColor, ConsoleColor backColor)
            => new ColorString(str, textColor, backColor);

        public static ColorString ColorText(this string str, ConsoleColor textColor)
            => new ColorString(str, textColor: textColor);

        public static ColorString ColorBack(this string str, ConsoleColor backColor)
            => new ColorString(str, backColor: backColor);

        public static ColorString TextBlack(this string str) => str.ColorText(ConsoleColor.Black);
        public static ColorString TextDarkBlue(this string str) => str.ColorText(ConsoleColor.DarkBlue);
        public static ColorString TextDarkGreen(this string str) => str.ColorText(ConsoleColor.DarkGreen);
        public static ColorString TextDarkCyan(this string str) => str.ColorText(ConsoleColor.DarkCyan);
        public static ColorString TextDarkRed(this string str) => str.ColorText(ConsoleColor.DarkRed);
        public static ColorString TextDarkMagenta(this string str) => str.ColorText(ConsoleColor.DarkMagenta);
        public static ColorString TextDarkYellow(this string str) => str.ColorText(ConsoleColor.DarkYellow);
        public static ColorString TextGray(this string str) => str.ColorText(ConsoleColor.Gray);
        public static ColorString TextDarkGray(this string str) => str.ColorText(ConsoleColor.DarkGray);
        public static ColorString TextBlue(this string str) => str.ColorText(ConsoleColor.Blue);
        public static ColorString TextGreen(this string str) => str.ColorText(ConsoleColor.Green);
        public static ColorString TextCyan(this string str) => str.ColorText(ConsoleColor.Cyan);
        public static ColorString TextRed(this string str) => str.ColorText(ConsoleColor.Red);
        public static ColorString TextMagenta(this string str) => str.ColorText(ConsoleColor.Magenta);
        public static ColorString TextYellow(this string str) => str.ColorText(ConsoleColor.Yellow);
        public static ColorString TextWhite(this string str) => str.ColorText(ConsoleColor.White);

        public static ColorString BackBlack(this string str) => str.ColorBack(ConsoleColor.Black);
        public static ColorString BackDarkBlue(this string str) => str.ColorBack(ConsoleColor.DarkBlue);
        public static ColorString BackDarkGreen(this string str) => str.ColorBack(ConsoleColor.DarkGreen);
        public static ColorString BackDarkCyan(this string str) => str.ColorBack(ConsoleColor.DarkCyan);
        public static ColorString BackDarkRed(this string str) => str.ColorBack(ConsoleColor.DarkRed);
        public static ColorString BackDarkMagenta(this string str) => str.ColorBack(ConsoleColor.DarkMagenta);
        public static ColorString BackDarkYellow(this string str) => str.ColorBack(ConsoleColor.DarkYellow);
        public static ColorString BackGray(this string str) => str.ColorBack(ConsoleColor.Gray);
        public static ColorString BackDarkGray(this string str) => str.ColorBack(ConsoleColor.DarkGray);
        public static ColorString BackBlue(this string str) => str.ColorBack(ConsoleColor.Blue);
        public static ColorString BackGreen(this string str) => str.ColorBack(ConsoleColor.Green);
        public static ColorString BackCyan(this string str) => str.ColorBack(ConsoleColor.Cyan);
        public static ColorString BackRed(this string str) => str.ColorBack(ConsoleColor.Red);
        public static ColorString BackMagenta(this string str) => str.ColorBack(ConsoleColor.Magenta);
        public static ColorString BackYellow(this string str) => str.ColorBack(ConsoleColor.Yellow);
        public static ColorString BackWhite(this string str) => str.ColorBack(ConsoleColor.White);
    }
}