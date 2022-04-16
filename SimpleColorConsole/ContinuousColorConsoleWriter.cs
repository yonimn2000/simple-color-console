namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a structure that helps writing <see cref="ColorCharacter"/>s more efficiently.
    /// </summary>
    public class ContinuousColorConsoleWriter : IDisposable
    {
        private bool InitialCursorVisible { get; }
        private ConsoleColor InitialTextColor { get; }
        private ConsoleColor InitialBackColor { get; }

        private ConsoleColor? LastTextColor { get; set; }
        private ConsoleColor? LastBackColor { get; set; }

        /// <summary>
        /// Initializes an instance of the <see cref="ContinuousColorConsoleWriter"/> class and saves the relevant <see cref="Console"/> properties.
        /// </summary>
        protected internal ContinuousColorConsoleWriter()
        {
            if (OperatingSystem.IsWindows())
                InitialCursorVisible = Console.CursorVisible;

            InitialTextColor = Console.ForegroundColor;
            InitialBackColor = Console.BackgroundColor;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// Writes the given <see cref="ColorCharacter"/> without moving the cursor position or changing
        /// the console colors unless needed based on the previously written <see cref="ColorCharacter"/>.
        /// </summary>
        /// <param name="character">The <see cref="ColorCharacter"/>.</param>
        protected internal void Write(ColorCharacter character)
        {
            bool needToChangeColor = NeedToChangeColor(character);
            if (needToChangeColor)
            {
                if (character.BackColor.HasValue)
                    Console.BackgroundColor = character.BackColor.Value;

                if (character.TextColor.HasValue)
                    Console.ForegroundColor = character.TextColor.Value;
            }

            Console.Write(character.Character);

            if (needToChangeColor)
            {
                LastTextColor = character.TextColor;
                LastBackColor = character.BackColor;
            }
        }

        private bool NeedToChangeColor(ColorCharacter newChar)
        {
            return (newChar.Character != ' ' && newChar.TextColor != LastTextColor) || newChar.BackColor != LastBackColor;
        }

        /// <summary>
        /// Reverts the <see cref="Console"/> properties to the saved ones from the current object initialization.
        /// </summary>
        public void RevertPreviousConsoleProperties()
        {
            if (OperatingSystem.IsWindows())
                Console.CursorVisible = InitialCursorVisible;

            Console.ForegroundColor = InitialTextColor;
            Console.BackgroundColor = InitialBackColor;
        }

        /// <summary>
        /// See <see cref="RevertPreviousConsoleProperties"/>
        /// </summary>
        public void Dispose() => RevertPreviousConsoleProperties();
    }
}