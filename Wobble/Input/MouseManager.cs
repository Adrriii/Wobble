using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Wobble.Input
{
    public static class MouseManager
    {
        /// <summary>
        ///     The current mouse state.
        /// </summary>
        public static MouseState CurrentState { get; private set; }

        /// <summary>
        ///     The previous mouse state.
        /// </summary>
        public static MouseState PreviousState { get; private set; }

        /// <summary>
        ///     Updates the MouseManager and keeps track of the current and previous mouse states.
        /// </summary>
        public static void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();
        }

        /// <summary>
        ///     Returns if the given button was a unique click.
        ///     A unique click means that the mouse was pressed and then released.
        /// </summary>
        public static bool IsUniqueClick(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return CurrentState.LeftButton == ButtonState.Released  && PreviousState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return CurrentState.RightButton == ButtonState.Released  && PreviousState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return CurrentState.MiddleButton == ButtonState.Released  && PreviousState.MiddleButton == ButtonState.Pressed;
                case MouseButton.Thumb1:
                    return CurrentState.XButton1 == ButtonState.Released  && PreviousState.XButton1 == ButtonState.Pressed;
                case MouseButton.Thumb2:
                    return CurrentState.XButton2 == ButtonState.Released  && PreviousState.XButton2 == ButtonState.Pressed;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        /// <summary>
        ///     If the mouse button was uniquely pressed in this frame. NOT a click. Use <see cref="IsUniqueClick"/> for clicks.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsUniquePress(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return CurrentState.RightButton == ButtonState.Pressed  && PreviousState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return CurrentState.MiddleButton == ButtonState.Pressed  && PreviousState.MiddleButton == ButtonState.Released;
                case MouseButton.Thumb1:
                    return CurrentState.XButton1 == ButtonState.Pressed  && PreviousState.XButton1 == ButtonState.Released;
                case MouseButton.Thumb2:
                    return CurrentState.XButton2 == ButtonState.Pressed  && PreviousState.XButton2 == ButtonState.Released;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        /// <summary>
        ///     Shows the mouse cursor.
        /// </summary>
        public static void ShowCursor() => GameBase.Game.IsMouseVisible = true;

        /// <summary>
        ///     Hides the mouse cursor.
        /// </summary>
        public static void HideCursor() => GameBase.Game.IsMouseVisible = false;
    }
}