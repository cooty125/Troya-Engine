/* 
 * Input
 * ===============================================================
 * FileName: input.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * ===============================================================
 * 
 * Troya Engine - Common Library
 */

using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Troya
{
    public static class Input
    {
        public static KeyboardState Keyboard {
            get { return Microsoft.Xna.Framework.Input.Keyboard.GetState( ); }
        }
        public static MouseState Mouse {
            get { return Microsoft.Xna.Framework.Input.Mouse.GetState( ); }
        }
        public static Keys[ ] GetPressedKeys( ) {
            return Keyboard.GetPressedKeys( );
        }
        public static bool IsKeyDown( Keys key ) {
            return Keyboard.IsKeyDown( key );
        }
        public static Vector2 GetMousePosition( ) {
            int x = Mouse.X;
            int y = Mouse.Y;

            return new Vector2( x, y );
        }
        public static int MouseScroll {
            get { return Mouse.ScrollWheelValue; }
        }
    }
}