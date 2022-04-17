using System.Collections;
using System.Drawing;

namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a collection of colored console string lines.
    /// </summary>
    public class ColorLines : IConsoleWritable, IEnumerable<ColorString>
    {
        private IList<ColorString> Lines { get; set; }

        /// <summary>
        /// Gets the number of lines in the current <see cref="ColorLines"/> object.
        /// </summary>
        public int Count => Lines.Count;

        /// <summary>
        /// Initializes an instance of the <see cref="ColorLines"/> class without any lines.
        /// </summary>
        public ColorLines()
        {
            Lines = new List<ColorString>();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorLines"/> class 
        /// with the <see cref="IEnumerable{T}"/> of <see cref="ColorString"/> lines.
        /// </summary>
        public ColorLines(IEnumerable<ColorString> lines)
        {
            Lines = new List<ColorString>(lines);
        }

        /// <summary>
        /// Gets or sets the <see cref="ColorString"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="ColorString"/> at the specified index.</returns>
        public ColorString this[int index] { get => Lines[index]; set => Lines[index] = value; }

        /// <summary>
        /// Adds a <see cref="ColorString"/> to the end of the current <see cref="ColorLines"/> structure.
        /// </summary>
        /// <param name="line">The <see cref="ColorString"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorLines AddLine(ColorString line)
        {
            Lines.Add(line);
            return this;
        }

        /// <summary>
        /// Adds a blank line to the end of the current <see cref="ColorLines"/> structure.
        /// </summary>
        /// <returns>The updated self.</returns>
        public ColorLines AddLine()
        {
            Lines.Add(new ColorString());
            return this;
        }

        /// <summary>
        /// Adds a the given <see cref="ColorLines"/> to the end of the current <see cref="ColorLines"/> structure.
        /// </summary>
        /// <param name="lines">The <see cref="ColorLines"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorLines AddLines(ColorLines lines)
        {
            foreach (ColorString line in lines)
                AddLine(line);
            return this;
        }

        /// <summary>
        /// Adds a <see cref="ColorChar"/> to the end of the last line
        /// of the current <see cref="ColorLines"/> structure.
        /// </summary>
        /// <param name="character">The <see cref="ColorString"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorLines AddToEndOfLastLine(ColorChar character)
        {
            GetLastLine().AddToEnd(character);
            return this;
        }

        /// <summary>
        /// Adds a <see cref="ColorString"/> to the end of the last line
        /// of the current <see cref="ColorLines"/> structure.
        /// </summary>
        /// <param name="str">The <see cref="ColorString"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorLines AddToEndOfLastLine(ColorString str)
        {
            GetLastLine().AddToEnd(str);
            return this;
        }

        /// <summary>
        /// Gets the last <see cref="ColorString"/> line of the current <see cref="ColorLines"/> structure. 
        /// </summary>
        /// <returns>The last <see cref="ColorString"/> line of the current <see cref="ColorLines"/> structure.</returns>
        public ColorString GetLastLine()
        {
            if (Count == 0)
                AddLine();
            return Lines[Lines.Count - 1];
        }

        /// <summary>
        /// Writes the current <see cref="ColorLines"/> to the console.
        /// </summary>
        public void Write()
        {
            foreach (ColorString str in Lines)
                str.WriteLine();
        }

        /// <summary>
        /// Same as <see cref="Write"/>.
        /// </summary>
        public void WriteLine() => Write(); // For the interface implementation.

        /// <summary>
        /// Writes the current <see cref="ColorLines"/> to the console at a given point.
        /// </summary>
        /// <param name="point">The position in the console to write the current <see cref="ColorLines"/> to.</param>
        public void WriteAtPoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            for (int y = 0; y < Lines.Count; y++)
            {
                Console.CursorLeft = point.X;
                ColorString str = Lines[y];
                str.WriteLine();
            }
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return string.Join(Environment.NewLine, Lines.Select(l => l.ToString()));
        }

        /// <summary>
        /// Returns an enumerator the iterates through the collection of 
        /// <see cref="ColorString"/> lines of the current <see cref="ColorLines"/>.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ColorLines"/>.</returns>
        public IEnumerator<ColorString> GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Lines).GetEnumerator();
        }

        /// <summary>
        /// Concatenates one <see cref="ColorLines"/> to another.
        /// </summary>
        /// <param name="lines1">The top <see cref="ColorLines"/>.</param>
        /// <param name="lines2">The bottom <see cref="ColorLines"/>.</param>
        /// <returns>
        /// A new <see cref="ColorLines"/> that is a combination of 
        /// the top and bottom <see cref="ColorLines"/>s.
        /// </returns>
        public static ColorLines operator +(ColorLines lines1, ColorLines lines2)
        {
            return new ColorLines(lines1).AddLines(lines2);
        }
    }
}