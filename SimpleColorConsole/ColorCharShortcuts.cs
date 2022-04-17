namespace YonatanMankovich.SimpleColorConsole
{
    public partial class ColorChar
    {
        public ColorChar ColorText(ConsoleColor textColor)
        {
            TextColor = textColor;
            return this;
        }

        public ColorChar ColorBack(ConsoleColor backColor)
        {
            BackColor = backColor;
            return this;
        }

        public ColorChar Color(ConsoleColor textColor, ConsoleColor backColor)
            => ColorText(textColor).ColorBack(backColor);

        public ColorChar TextBlack() => ColorText(ConsoleColor.Black);
        public ColorChar TextDarkBlue() => ColorText(ConsoleColor.DarkBlue);
        public ColorChar TextDarkGreen() => ColorText(ConsoleColor.DarkGreen);
        public ColorChar TextDarkCyan() => ColorText(ConsoleColor.DarkCyan);
        public ColorChar TextDarkRed() => ColorText(ConsoleColor.DarkRed);
        public ColorChar TextDarkMagenta() => ColorText(ConsoleColor.DarkMagenta);
        public ColorChar TextDarkYellow() => ColorText(ConsoleColor.DarkYellow);
        public ColorChar TextGray() => ColorText(ConsoleColor.Gray);
        public ColorChar TextDarkGray() => ColorText(ConsoleColor.DarkGray);
        public ColorChar TextBlue() => ColorText(ConsoleColor.Blue);
        public ColorChar TextGreen() => ColorText(ConsoleColor.Green);
        public ColorChar TextCyan() => ColorText(ConsoleColor.Cyan);
        public ColorChar TextRed() => ColorText(ConsoleColor.Red);
        public ColorChar TextMagenta() => ColorText(ConsoleColor.Magenta);
        public ColorChar TextYellow() => ColorText(ConsoleColor.Yellow);
        public ColorChar TextWhite() => ColorText(ConsoleColor.White);

        public ColorChar BackBlack() => ColorBack(ConsoleColor.Black);
        public ColorChar BackDarkBlue() => ColorBack(ConsoleColor.DarkBlue);
        public ColorChar BackDarkGreen() => ColorBack(ConsoleColor.DarkGreen);
        public ColorChar BackDarkCyan() => ColorBack(ConsoleColor.DarkCyan);
        public ColorChar BackDarkRed() => ColorBack(ConsoleColor.DarkRed);
        public ColorChar BackDarkMagenta() => ColorBack(ConsoleColor.DarkMagenta);
        public ColorChar BackDarkYellow() => ColorBack(ConsoleColor.DarkYellow);
        public ColorChar BackGray() => ColorBack(ConsoleColor.Gray);
        public ColorChar BackDarkGray() => ColorBack(ConsoleColor.DarkGray);
        public ColorChar BackBlue() => ColorBack(ConsoleColor.Blue);
        public ColorChar BackGreen() => ColorBack(ConsoleColor.Green);
        public ColorChar BackCyan() => ColorBack(ConsoleColor.Cyan);
        public ColorChar BackRed() => ColorBack(ConsoleColor.Red);
        public ColorChar BackMagenta() => ColorBack(ConsoleColor.Magenta);
        public ColorChar BackYellow() => ColorBack(ConsoleColor.Yellow);
        public ColorChar BackWhite() => ColorBack(ConsoleColor.White);
    }
}