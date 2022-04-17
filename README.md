# Simple Color Console

An easier way to create, edit, and write colorful text to the console.

![All Colors](media/all-colors.png)

## Getting Started Examples

Multiple ways to do the same thing:

```cs
using YonatanMankovich.SimpleColorConsole;

"Hello world!".TextBlack().BackYellow().WriteLine();
"Hello world!".Color(ConsoleColor.Black, ConsoleColor.Yellow).WriteLine();
"Hello world!".ColorText(ConsoleColor.Black).ColorBack(ConsoleColor.Yellow).WriteLine();
ColorConsole.WriteLine("Hello world!".TextBlack().BackYellow());
ColorConsole.WriteLine("Hello world!", ConsoleColor.Black, ConsoleColor.Yellow);
new ColorString("Hello world!", ConsoleColor.Black, ConsoleColor.Yellow).WriteLine();
```

See a list of available colors at the [end](#available-colors).

## `ColorString` Features

```cs
using YonatanMankovich.SimpleColorConsole;

ColorString cs = "Hello world!".TextBlack().BackYellow();

cs.Write(); // Write the ConsoleString to the console.
cs.WriteLine(); // Write the ConsoleString to the console and adds a new line.
cs.WriteAtPoint(new Point(6, 9)); // Write the ConsoleString to the console at the specified point.
ColorChar cc = cs[5]; // Get the ColorChar at an index.
cs[4].BackYellow(); // Set the ColorChar at an index.
cs.AddToEnd(new ConsoleChar('!', ConsoleColor.Blue, ConsoleColor.Green)); // Add a ConsoleChar to end.
cs.AddToEnd(' '); // Add a plain char to end.
cs.AddToEnd(new ConsoleString("Yo! ", ConsoleColor.Blue, ConsoleColor.Magenta)); // Add a ConsoleString to end.
cs.AddToEnd("Boom!"); // Add a plain string to end.
cs.AddToEnd("Very".BackBlue()).AddToEnd(' '.BackYellow()).AddToEnd("nice!"); // Chain calls.
ColorString concat1 = cs + " Cool!"; // Concatenate a plain string (or char).
ColorString concat2 = cs + " Cool!".TextYellow(); // Concatenate a ColorString string (or ColorChar).
foreach (ColorChar c in cs) c.Write(); // Enumerate the ColorChars of a ColorString.
```

## `ColorLines` for Multi-Line `ColorString`s

`ColorLines` is a collection of lines of type `ColorString`. It generally has the same [features](#colorstring-features) as `ConsoleString`s. The following are the only additions:

```cs
using YonatanMankovich.SimpleColorConsole;

ColorLines cl = new ColorLines();

cl.AddLine("Hello!".TextGreen()); // Add a ColorString/string/ColorChar/char line.
cl.AddLine(); // Add a blank line.
cl.AddLine().AddLine("Hello!".TextCyan()); // Chain calls.
cl.AddToEndOfLastLine("OK".BackRed()); // Add a ColorString/string/ColorChar/char to the end of the last line.
```

## Behavioral Notes

* `'/n'`, `'/r'`, `'/t'` are not allowed. If a multi-line string is needed, use [`ColorLines`](#colorlines-for-multi-line-colorstrings).
* If the background color is not specified, the current `Console.BackgroundColor` is used.
* If the text color is not specified, the current `Console.ForegroundColor` is used.

## Available Colors

* Black
* DarkBlue
* DarkGreen
* DarkCyan
* DarkRed
* DarkMagenta
* DarkYellow
* Gray
* DarkGray
* Blue
* Green
* Cyan
* Red
* Magenta
* Yellow
* White

(List from [here](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor?view=net-6.0))

## My Other Projects That Use This Library

[Console Diff Writer](https://github.com/yonimn2000/console-diff-writer)

[Command Line Minesweeper](https://github.com/yonimn2000/command-line-minesweeper)
