using System.Drawing;

namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a colored console character.
    /// </summary>
    public class ColorCharacter : IConsoleWritable, IEquatable<ColorCharacter?>
    {
        private char character;
        private static HashSet<char> InvalidCharacters { get; } = new HashSet<char> { '\n', '\r', '\t' };

        /// <summary>
        /// The character.
        /// </summary>
        public char Character
        {
            get => character;
            set
            {
                if (InvalidCharacters.Contains(value))
                    throw new ArgumentException("Invalid character given. " +
                        "Character cannot be a new line, carriage return, or tab character.", nameof(value));

                character = value;
            }
        }

        /// <summary>
        /// The text color of the character as displayed in the console.
        /// </summary>
        public ConsoleColor? TextColor { get; set; }

        /// <summary>
        /// The background color of the character as displayed in the console.
        /// </summary>
        public ConsoleColor? BackColor { get; set; }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorCharacter"/> class with a <see cref="char"/> and colors.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="textColor">The text color of the character as will be displayed in the console.</param>
        /// <param name="backColor">The background color of the character as will be displayed in the console.</param>
        public ColorCharacter(char character, ConsoleColor? textColor = null, ConsoleColor? backColor = null)
        {
            Character = character;
            TextColor = textColor;
            BackColor = backColor;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ColorCharacter"/> class with 
        /// a blank (space) character and a background color.
        /// </summary>
        /// <param name="backColor">The background color of the character as will be displayed in the console.</param>
        public ColorCharacter(ConsoleColor? backColor = null)
        {
            Character = ' ';
            BackColor = backColor;
        }

        /// <summary>
        /// Writes the current <see cref="ColorCharacter"/> to the console.
        /// </summary>
        public void Write()
        {
            // Save current console colors.
            ConsoleColor prevBgColor = Console.BackgroundColor;
            ConsoleColor prevFgColor = Console.ForegroundColor;

            // Change the writing colors only if they are given.
            if (BackColor.HasValue)
                Console.BackgroundColor = BackColor.Value;

            if (TextColor.HasValue)
                Console.ForegroundColor = TextColor.Value;

            Console.Write(Character);

            // Restore the saved console colors.
            Console.BackgroundColor = prevBgColor;
            Console.ForegroundColor = prevFgColor;
        }

        /// <summary>
        /// Writes the current <see cref="ColorCharacter"/> to the console and adds a line terminator.
        /// </summary>
        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the current <see cref="ColorCharacter"/> to the console at a given point.
        /// </summary>
        /// <param name="point">The position in the console to write the current <see cref="ColorCharacter"/> to.</param>
        public void WriteAtPoint(Point point)
        {
            // Save current cursor coordinates.
            Point prevPoint = new Point(Console.CursorLeft, Console.CursorTop);

            // Write at the given position.
            Console.SetCursorPosition(point.X, point.Y);
            Write();

            // Restore saved cursor coordinates.
            Console.SetCursorPosition(prevPoint.X, prevPoint.Y);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as ColorCharacter);

        /// <inheritdoc/>
        public bool Equals(ColorCharacter? other)
        {
            return other != null &&
                   Character == other.Character &&
                   (TextColor == other.TextColor || Character == ' ') &&
                   BackColor == other.BackColor;
        }

        /// <inheritdoc/>
        public override string? ToString() => Character.ToString();

        /// <inheritdoc/>
        public override int GetHashCode()
            => (Character.ToString() + TextColor.ToString() + BackColor.ToString()).GetHashCode();
    }
}