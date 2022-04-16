using System.Drawing;

namespace YonatanMankovich.SimpleColorConsole
{
    /// <summary>
    /// Defines methods for writing to the <see cref="Console"/>.
    /// </summary>
    public interface IConsoleWritable
    {
        /// <summary>
        /// Write to the <see cref="Console"/>.
        /// </summary>
        void Write();

        /// <summary>
        /// Write to the <see cref="Console"/> and add a line terminator to the end.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Write to the <see cref="Console"/> at a given <see cref="Point"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point"/>.</param>
        void WriteAtPoint(Point point);
    }
}