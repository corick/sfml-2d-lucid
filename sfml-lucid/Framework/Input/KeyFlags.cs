
namespace Lucid.Framework.Input
{
    /// <summary>
    /// The state of a given key as an enum.
    /// </summary>
    public enum KeyFlags
    {
        /// <summary>
        /// Whether or not the key is pressed.
        /// </summary>
        Down    = 1,
        /// <summary>
        /// If the key has been pressed since the last time we polled.
        /// </summary>
        New     = 2,
        /// <summary>
        /// If the shift key's held down.
        /// </summary>
        Shift = 4,

        Control = 8,

        Alt = 16
    }
}
