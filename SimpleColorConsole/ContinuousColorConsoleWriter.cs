namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a structure that helps writing <see cref="ConsoleCharacter"/>s more efficiently.
    /// </summary>
    public class ContinuousColorConsoleWriter : IDisposable
    {
        protected bool InitialCursorVisible { get; }
        protected ConsoleColor InitialTextColor { get; }
        protected ConsoleColor InitialBackColor { get; }

        protected ConsoleColor? LastTextColor { get; set; }
        protected ConsoleColor? LastBackColor { get; set; }

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
        /// Writes the given <see cref="ConsoleCharacter"/> without moving the cursor position or changing
        /// the console colors unless needed based on the previously written <see cref="ConsoleCharacter"/>.
        /// </summary>
        /// <param name="character">The <see cref="ConsoleCharacter"/>.</param>
        protected internal void Write(ConsoleCharacter character)
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

        private bool NeedToChangeColor(ConsoleCharacter newChar)
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