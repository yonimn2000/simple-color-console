namespace YonatanMankovich.SimpleColorConsole
{
    public partial class ColorCharacter
    {
        public ColorCharacter ColorText(ConsoleColor textColor)
        {
            TextColor = textColor;
            return this;
        }

        public ColorCharacter ColorBack(ConsoleColor backColor)
        {
            BackColor = backColor;
            return this;
        }

        public ColorCharacter Color(ConsoleColor textColor, ConsoleColor backColor)
            => ColorText(textColor).ColorBack(backColor);

        public ColorCharacter TextBlack() => ColorText(ConsoleColor.Black);
        public ColorCharacter TextDarkBlue() => ColorText(ConsoleColor.DarkBlue);
        public ColorCharacter TextDarkGreen() => ColorText(ConsoleColor.DarkGreen);
        public ColorCharacter TextDarkCyan() => ColorText(ConsoleColor.DarkCyan);
        public ColorCharacter TextDarkRed() => ColorText(ConsoleColor.DarkRed);
        public ColorCharacter TextDarkMagenta() => ColorText(ConsoleColor.DarkMagenta);
        public ColorCharacter TextDarkYellow() => ColorText(ConsoleColor.DarkYellow);
        public ColorCharacter TextGray() => ColorText(ConsoleColor.Gray);
        public ColorCharacter TextDarkGray() => ColorText(ConsoleColor.DarkGray);
        public ColorCharacter TextBlue() => ColorText(ConsoleColor.Blue);
        public ColorCharacter TextGreen() => ColorText(ConsoleColor.Green);
        public ColorCharacter TextCyan() => ColorText(ConsoleColor.Cyan);
        public ColorCharacter TextRed() => ColorText(ConsoleColor.Red);
        public ColorCharacter TextMagenta() => ColorText(ConsoleColor.Magenta);
        public ColorCharacter TextYellow() => ColorText(ConsoleColor.Yellow);
        public ColorCharacter TextWhite() => ColorText(ConsoleColor.White);

        public ColorCharacter BackBlack() => ColorBack(ConsoleColor.Black);
        public ColorCharacter BackDarkBlue() => ColorBack(ConsoleColor.DarkBlue);
        public ColorCharacter BackDarkGreen() => ColorBack(ConsoleColor.DarkGreen);
        public ColorCharacter BackDarkCyan() => ColorBack(ConsoleColor.DarkCyan);
        public ColorCharacter BackDarkRed() => ColorBack(ConsoleColor.DarkRed);
        public ColorCharacter BackDarkMagenta() => ColorBack(ConsoleColor.DarkMagenta);
        public ColorCharacter BackDarkYellow() => ColorBack(ConsoleColor.DarkYellow);
        public ColorCharacter BackGray() => ColorBack(ConsoleColor.Gray);
        public ColorCharacter BackDarkGray() => ColorBack(ConsoleColor.DarkGray);
        public ColorCharacter BackBlue() => ColorBack(ConsoleColor.Blue);
        public ColorCharacter BackGreen() => ColorBack(ConsoleColor.Green);
        public ColorCharacter BackCyan() => ColorBack(ConsoleColor.Cyan);
        public ColorCharacter BackRed() => ColorBack(ConsoleColor.Red);
        public ColorCharacter BackMagenta() => ColorBack(ConsoleColor.Magenta);
        public ColorCharacter BackYellow() => ColorBack(ConsoleColor.Yellow);
        public ColorCharacter BackWhite() => ColorBack(ConsoleColor.White);
    }
}