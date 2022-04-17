using System.Drawing;

namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Provides methods for writing <see cref="IConsoleWritable"/>.
    /// </summary>
    public static class ColorConsole
    {
        /// <summary>
        /// Writes the <see cref="IConsoleWritable"/> to the <see cref="Console"/>.
        /// </summary>
        /// <param name="writable">The <see cref="IConsoleWritable"/>.</param>
        public static void Write(IConsoleWritable writable) => writable.Write();

        /// <summary>
        /// Writes the <see cref="IConsoleWritable"/> to the <see cref="Console"/> and adds a line terminator.
        /// </summary>
        /// <param name="writable">The <see cref="IConsoleWritable"/>.</param>
        public static void WriteLine(IConsoleWritable writable) => writable.WriteLine();

        /// <summary>
        /// Writes the <see cref="IConsoleWritable"/> to the <see cref="Console"/> at a given <see cref="Point"/>.
        /// </summary>
        /// <param name="writable">The <see cref="IConsoleWritable"/>.</param>
        /// <param name="point">The <paramref name="point"/> at which to write the <see cref="IConsoleWritable"/>.</param>
        public static void WriteAtPoint(IConsoleWritable writable, Point point) => writable.WriteAtPoint(point);

        /// <summary>
        /// Writes a <see cref="string"/> of the specified <paramref name="textColor"/> and 
        /// <paramref name="backColor"/> to the <see cref="Console"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/>.</param>
        /// <param name="textColor">The text color.</param>
        /// <param name="backColor">The background color.</param>
        public static void Write(string str, ConsoleColor? textColor = null, ConsoleColor? backColor = null)
            => new ColorString(str, textColor, backColor).Write();

        /// <summary>
        /// Writes a <see cref="string"/> of the specified <paramref name="textColor"/> and 
        /// <paramref name="backColor"/> to the <see cref="Console"/> and adds a line terminator at the end.
        /// </summary>
        /// <param name="str">The <see cref="string"/>.</param>
        /// <param name="textColor">The text color.</param>
        /// <param name="backColor">The background color.</param>
        public static void WriteLine(string str, ConsoleColor? textColor = null, ConsoleColor? backColor = null)
            => new ColorString(str, textColor, backColor).WriteLine();
    }
}