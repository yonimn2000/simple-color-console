using System.Drawing;
using YonatanMankovich.SimpleColorConsole;

RunColorTests();
RunCharacterTests();
RunStringTests();
RunLinesTests();

static void RunColorTests()
{
    foreach (ConsoleColor backColor in Enum.GetValues<ConsoleColor>())
        foreach (ConsoleColor textColor in Enum.GetValues<ConsoleColor>())
            $"{textColor} text on {backColor} background ".Color(textColor, backColor).Write();
    Console.WriteLine();
}

static void RunCharacterTests()
{
    Console.WriteLine(nameof(ColorCharacter) + " Tests");
    Console.WriteLine(new string('-', 35));
    ColorCharacter character;

    Console.Write("Blank character: [");
    character = new ColorCharacter();
    character.Write();
    Console.WriteLine("]");

    Console.Write("Background character: [");
    character = new ColorCharacter(ConsoleColor.Blue);
    character.Write();
    Console.WriteLine("]");

    Console.Write("Text colored character: [");
    character = new ColorCharacter('#', textColor: ConsoleColor.Magenta);
    character.Write();
    Console.WriteLine("]");

    Console.Write("Background colored character: [");
    character = new ColorCharacter('#', backColor: ConsoleColor.Magenta);
    character.Write();
    Console.WriteLine("]");

    Console.Write("Fully colored character: [");
    character = new ColorCharacter('#', textColor: ConsoleColor.Magenta, backColor: ConsoleColor.Cyan);
    character.Write();
    Console.WriteLine("]");

    Console.Write("Write character at point: [ ]");
    character.WriteAtPoint(new Point(Console.CursorLeft - 2, Console.CursorTop));
    Console.WriteLine();

    Console.WriteLine("Character to string: [" + character.ToString() + "]");

    Console.Write("Invalid character: [");
    try
    {
        character = new ColorCharacter('\n');
    }
    catch (ArgumentException)
    {
        Console.Write("Caught exception");
    }
    Console.WriteLine("]");
    Console.WriteLine();
}

static void RunStringTests()
{
    Console.WriteLine(nameof(ColorString) + " Tests");
    Console.WriteLine(new string('-', 35));
    ColorString str;

    Console.Write("Blank string: [");
    str = new ColorString();
    str.Write();
    Console.WriteLine("]");

    Console.Write("Background string: [");
    str = new ColorString(new string(' ', 10), backColor: ConsoleColor.Blue);
    str.Write();
    Console.WriteLine("]");

    Console.Write("Text colored string: [");
    str = new ColorString("0123456789", textColor: ConsoleColor.Magenta);
    str.Write();
    Console.WriteLine("]");

    Console.Write("Background colored string: [");
    str = new ColorString("0123456789", backColor: ConsoleColor.Magenta);
    str.Write();
    Console.WriteLine("]");

    Console.Write("Fully colored string: [");
    str = new ColorString("0123456789", textColor: ConsoleColor.Magenta, backColor: ConsoleColor.Cyan);
    str.Write();
    Console.WriteLine("]");

    Console.WriteLine("String length (10): [" + str.Length + "]");

    Console.Write("Write string at point: [          ]");
    str.WriteAtPoint(new Point(Console.CursorLeft - str.Length - 1, Console.CursorTop));
    Console.WriteLine();

    Console.WriteLine(nameof(ColorString) + " to string: [" + str.ToString() + "]");

    Console.Write("Char at index 7: [");
    str[7].Write();
    Console.WriteLine("]");

    Console.Write("Add char to end: [");
    str.AddToEnd(new ColorCharacter('@', textColor: ConsoleColor.Blue, backColor: ConsoleColor.Red));
    str.Write();
    Console.WriteLine("]");

    Console.Write("Add string to end: [");
    str.AddToEnd(new ColorString("0123456789", textColor: ConsoleColor.Blue, backColor: ConsoleColor.Green));
    str.Write();
    Console.WriteLine("]");

    Console.WriteLine("Write line: [");
    str.WriteLine();
    Console.WriteLine("]");

    Console.Write("Concat char: [");
    str = new ColorString("0123456789", textColor: ConsoleColor.Yellow, backColor: ConsoleColor.Blue);
    ColorCharacter character = new ColorCharacter('$', textColor: ConsoleColor.Blue, backColor: ConsoleColor.Red);
    ColorString newString = str + character;
    newString.Write();
    Console.WriteLine("]");

    Console.Write("Concat string: [");
    ColorString str2 = new ColorString("0123456789", textColor: ConsoleColor.Blue, backColor: ConsoleColor.Red);
    newString = str + str2;
    newString.Write();
    Console.WriteLine("]");

    Console.WriteLine();
}

static void RunLinesTests()
{
    Console.WriteLine(nameof(ColorLines) + " Tests");
    Console.WriteLine(new string('-', 35));
    ColorLines lines;

    Console.Write("Blank lines: [");
    lines = new ColorLines();
    lines.Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.Write("Add line: [");
    lines = new ColorLines();
    ColorString line1 = new ColorString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", textColor: ConsoleColor.Cyan, backColor: ConsoleColor.Red);
    ColorString line2 = new ColorString("0123456789");
    ColorString line3 = new ColorString("!@#$%^&*()_+", textColor: ConsoleColor.DarkBlue, backColor: ConsoleColor.Yellow);
    lines.AddLine(line1).AddLine(line2).AddLine(line3).Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.Write("Add lines: [");
    new ColorLines(lines).AddLines(lines).Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.Write("Add blank line: [");
    new ColorLines(lines).AddLine().AddLines(lines).Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.Write("Add char to end of last line: [");
    new ColorLines(lines).AddToEndOfLastLine(new ColorCharacter('~', backColor: ConsoleColor.Magenta)).Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.Write("Add string to end of last line: [");
    new ColorLines().AddLine(line1).AddLine(line2).AddToEndOfLastLine(line1).Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.WriteLine("Write at point: [");
    lines.WriteAtPoint(new Point(4, Console.CursorTop));
    Console.WriteLine("]" + Environment.NewLine);

    Console.WriteLine("Write to string: [" + lines.ToString() + "]" + Environment.NewLine);

    Console.Write("Concat lines: [");
    ColorLines newLines = new ColorLines().AddLine(line1).AddLine(line2) + new ColorLines().AddLine(line3);
    newLines.Write();
    Console.WriteLine("]" + Environment.NewLine);

    Console.WriteLine();
}