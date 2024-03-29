﻿namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Represents a structure that helps writing <see cref="ColorChar"/>s more efficiently.
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
        /// Writes the given <see cref="ColorChar"/> without moving the cursor position or changing
        /// the console colors unless needed based on the previously written <see cref="ColorChar"/>.
        /// </summary>
        /// <param name="character">The <see cref="ColorChar"/>.</param>
        protected internal void Write(ColorChar character)
        {
            bool needToChangeColor = NeedToChangeColor(character);
            if (needToChangeColor)
            {
                if (character.BackColor.HasValue)
                    Console.BackgroundColor = character.BackColor.Value;
                else
                    Console.BackgroundColor = InitialBackColor;

                if (character.TextColor.HasValue)
                    Console.ForegroundColor = character.TextColor.Value;
                else
                    Console.ForegroundColor = InitialTextColor;
            }

            Console.Write(character.Character);

            if (needToChangeColor)
            {
                LastTextColor = character.TextColor;
                LastBackColor = character.BackColor;
            }
        }

        private bool NeedToChangeColor(ColorChar newChar)
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