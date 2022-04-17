namespace YonatanMankovich.SimpleColorConsole
{
    public partial class ColorString
    {
        public ColorString ColorText(ConsoleColor textColor)
        {
            foreach (ColorCharacter character in Characters)
                character.TextColor = textColor;
            return this;
        }

        public ColorString ColorBack(ConsoleColor backColor)
        {
            foreach (ColorCharacter character in Characters)
                character.BackColor = backColor;
            return this;
        }

        public ColorString Color(ConsoleColor textColor, ConsoleColor backColor)
            => ColorText(textColor).ColorBack(backColor);

        public ColorString TextBlack() => ColorText(ConsoleColor.Black);
        public ColorString TextDarkBlue() => ColorText(ConsoleColor.DarkBlue);
        public ColorString TextDarkGreen() => ColorText(ConsoleColor.DarkGreen);
        public ColorString TextDarkCyan() => ColorText(ConsoleColor.DarkCyan);
        public ColorString TextDarkRed() => ColorText(ConsoleColor.DarkRed);
        public ColorString TextDarkMagenta() => ColorText(ConsoleColor.DarkMagenta);
        public ColorString TextDarkYellow() => ColorText(ConsoleColor.DarkYellow);
        public ColorString TextGray() => ColorText(ConsoleColor.Gray);
        public ColorString TextDarkGray() => ColorText(ConsoleColor.DarkGray);
        public ColorString TextBlue() => ColorText(ConsoleColor.Blue);
        public ColorString TextGreen() => ColorText(ConsoleColor.Green);
        public ColorString TextCyan() => ColorText(ConsoleColor.Cyan);
        public ColorString TextRed() => ColorText(ConsoleColor.Red);
        public ColorString TextMagenta() => ColorText(ConsoleColor.Magenta);
        public ColorString TextYellow() => ColorText(ConsoleColor.Yellow);
        public ColorString TextWhite() => ColorText(ConsoleColor.White);

        public ColorString BackBlack() => ColorBack(ConsoleColor.Black);
        public ColorString BackDarkBlue() => ColorBack(ConsoleColor.DarkBlue);
        public ColorString BackDarkGreen() => ColorBack(ConsoleColor.DarkGreen);
        public ColorString BackDarkCyan() => ColorBack(ConsoleColor.DarkCyan);
        public ColorString BackDarkRed() => ColorBack(ConsoleColor.DarkRed);
        public ColorString BackDarkMagenta() => ColorBack(ConsoleColor.DarkMagenta);
        public ColorString BackDarkYellow() => ColorBack(ConsoleColor.DarkYellow);
        public ColorString BackGray() => ColorBack(ConsoleColor.Gray);
        public ColorString BackDarkGray() => ColorBack(ConsoleColor.DarkGray);
        public ColorString BackBlue() => ColorBack(ConsoleColor.Blue);
        public ColorString BackGreen() => ColorBack(ConsoleColor.Green);
        public ColorString BackCyan() => ColorBack(ConsoleColor.Cyan);
        public ColorString BackRed() => ColorBack(ConsoleColor.Red);
        public ColorString BackMagenta() => ColorBack(ConsoleColor.Magenta);
        public ColorString BackYellow() => ColorBack(ConsoleColor.Yellow);
        public ColorString BackWhite() => ColorBack(ConsoleColor.White);
    }
}