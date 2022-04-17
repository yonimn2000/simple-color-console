using System.Collections;
using System.Drawing;

namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a colored console string of characters.
    /// </summary>
    public partial class ColorString : IConsoleWritable, IEnumerable<ColorCharacter>
    {
        private IList<ColorCharacter> Characters { get; set; }

        /// <summary>
        /// Gets the number of characters in the current <see cref="ColorString"/> object.
        /// </summary>
        public int Length => Characters.Count;

        /// <summary>
        /// Initializes an instance of the <see cref="ColorString"/> class with an empty string.
        /// </summary>
        public ColorString()
        {
            Characters = new List<ColorCharacter>();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorString"/> class with a <see cref="string"/> and colors.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="textColor">The text color of the string as will be displayed in the console.</param>
        /// <param name="backColor">The background color of the string as will be displayed in the console.</param>
        public ColorString(string str, ConsoleColor? textColor = null, ConsoleColor? backColor = null)
        {
            Characters = str.Select(c => new ColorCharacter(c, textColor, backColor)).ToList();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorString"/> class 
        /// with the value of another <see cref="ColorString"/>.
        /// </summary>
        public ColorString(ColorString str) : this(str.Characters) { }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorString"/> class 
        /// with the <see cref="IEnumerable{T}"/> of <see cref="ColorCharacter"/>s.
        /// </summary>
        public ColorString(IEnumerable<ColorCharacter> characters)
        {
            Characters = new List<ColorCharacter>(characters);
        }

        /// <summary>
        /// Gets or sets the <see cref="ColorCharacter"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="ColorCharacter"/> at the specified index.</returns>
        public ColorCharacter this[int index] { get => Characters[index]; set => Characters[index] = value; }

        /// <summary>
        /// Adds a <see cref="ColorCharacter"/> to the end of the current <see cref="ColorString"/>.
        /// </summary>
        /// <param name="character">The <see cref="ColorCharacter"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorString AddToEnd(ColorCharacter character)
        {
            Characters.Add(character);
            return this;
        }

        /// <summary>
        /// Adds a <see cref="char"/> to the end of the current <see cref="ColorString"/>.
        /// </summary>
        /// <param name="character">The <see cref="char"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorString AddToEnd(char character)
        {
            return AddToEnd(new ColorCharacter(character));
        }

        /// <summary>
        /// Adds a <see cref="ColorString"/> to the end of the current <see cref="ColorString"/>.
        /// </summary>
        /// <param name="str">The <see cref="ColorString"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorString AddToEnd(ColorString str)
        {
            foreach (ColorCharacter character in str)
                Characters.Add(character);
            return this;
        }

        /// <summary>
        /// Adds a <see cref="string"/> to the end of the current <see cref="ColorString"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to add.</param>
        /// <returns>The updated self.</returns>
        public ColorString AddToEnd(string str)
        {
            return AddToEnd(new ColorString(str));
        }

        /// <summary>
        /// Writes the current <see cref="ColorString"/> to the console.
        /// </summary>
        public void Write()
        {
            using (ContinuousColorConsoleWriter writer = new ContinuousColorConsoleWriter())
                foreach (ColorCharacter character in Characters)
                    writer.Write(character);
        }

        /// <summary>
        /// Writes the current <see cref="ColorString"/> to the console and adds a line terminator.
        /// </summary>
        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the current <see cref="ColorString"/> to the console at a given point.
        /// </summary>
        /// <param name="point">The position in the console to write the current <see cref="ColorString"/> to.</param>
        public void WriteAtPoint(Point point)
        {
            // Save current cursor coordinates.
            Point prevPoint = new Point(Console.CursorLeft, Console.CursorTop);

            // Write.
            Console.SetCursorPosition(point.X, point.Y);
            Write();

            // Restore the saved cursor coordinates.
            Console.SetCursorPosition(prevPoint.X, prevPoint.Y);
        }

        /// <summary>
        /// Concatenates one <see cref="ColorString"/> to another.
        /// </summary>
        /// <param name="left">The left <see cref="ColorString"/>.</param>
        /// <param name="right">The right <see cref="ColorString"/>.</param>
        /// <returns>
        /// A new <see cref="ColorString"/> that is a combination of 
        /// the left and right <see cref="ColorString"/>s.
        /// </returns>
        public static ColorString operator +(ColorString left, ColorString right)
        {
            return new ColorString(left.Characters).AddToEnd(right);
        }

        /// <summary>
        /// Concatenates a <see cref="string"/> to a <see cref="ColorString"/>.
        /// </summary>
        /// <param name="left">The left <see cref="ColorString"/>.</param>
        /// <param name="right">The right <see cref="string"/>.</param>
        /// <returns>
        /// A new <see cref="ColorString"/> that is a combination of 
        /// the left <see cref="ColorString"/> and right <see cref="string"/>.
        /// </returns>
        public static ColorString operator +(ColorString left, string right)
        {
            return new ColorString(left.Characters).AddToEnd(right);
        }

        /// <summary>
        /// Concatenates a <see cref="ColorCharacter"/> to a <see cref="ColorString"/>.
        /// </summary>
        /// <param name="str">The <see cref="ColorString"/>.</param>
        /// <param name="character">The <see cref="ColorCharacter"/>.</param>
        /// <returns>
        /// A new <see cref="ColorString"/> that is a combination of 
        /// the left <see cref="ColorString"/> and the right <see cref="ColorCharacter"/>s.
        /// </returns>
        public static ColorString operator +(ColorString str, ColorCharacter character)
        {
            return new ColorString(str.Characters).AddToEnd(character);
        }

        /// <summary>
        /// Concatenates a <see cref="char"/> to a <see cref="ColorString"/>.
        /// </summary>
        /// <param name="str">The <see cref="ColorString"/>.</param>
        /// <param name="character">The <see cref="char"/>.</param>
        /// <returns>
        /// A new <see cref="ColorString"/> that is a combination of 
        /// the left <see cref="ColorString"/> and the right <see cref="char"/>s.
        /// </returns>
        public static ColorString operator +(ColorString str, char character)
        {
            return new ColorString(str.Characters).AddToEnd(character);
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return new string(Characters.Select(c => c.Character).ToArray());
        }

        /// <summary>
        /// Returns an enumerator the iterates through the collection of 
        /// <see cref="ColorCharacter"/>s of the current <see cref="ColorString"/>.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ColorString"/>.</returns>
        public IEnumerator<ColorCharacter> GetEnumerator()
        {
            return Characters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Characters).GetEnumerator();
        }
    }
}