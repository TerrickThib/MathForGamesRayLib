using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class UIText : Actor
    {
        private string _text;
        private int _width;
        private int _height;

        /// <summary>
        /// The text will appear inside the text box
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// The width of the text box. If the cursor is outside the max
        /// x position the text will wrap around
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// The height of the text box. If the cursor is outside the max
        /// y position the text is truncated.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Sets the starting vaules for the text box
        /// </summary>
        /// <param name="x">The x position of the text box</param>
        /// <param name="y">The y position of the text box</param>
        /// <param name="name">The name of the text box</param>
        /// <param name="color">The color of the text box</param>
        /// <param name="width">How wide the text box is</param>
        /// <param name="height">How tall the text box is</param>
        /// <param name="text">The text that will be displayed</param>
        public UIText(float x, float y, Color color, string name, int width, int height, string text = "")
            : base('\0', x, y, color, name)
        {
            Text = text;
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            //Store the position of the cursor
            int cursorPosX = (int)Position.X;
            int cursorPosY = (int)Position.Y;

            //Create a new icon to store the current character and color
            Icon currentLetter = new Icon { Color = icon.Color };

            //Convert the string for text into a character array
            char[] textChars = Text.ToCharArray();

            //Iterate through all characters in the string 
            for (int i = 0; i < textChars.Length; i++)
            {
                //Set the icon symbol to be the current character in the srray
                currentLetter.Symbol = textChars[i];

                if (currentLetter.Symbol == '\n')
                {
                    cursorPosX = (int)Position.X;
                    cursorPosY++;
                    continue;
                }
                //Add the current character to the buffer #
                Raylib.DrawText(icon.Symbol.ToString(), (int)Position.X, (int)Position.Y, 50, icon.Color);

                //Increment the cursor position so the letters are set side by side
                cursorPosX++;

                //Go to the next line if the cursor has reached the max position  
                if ((int)Position.X + Width < cursorPosX)
                {
                    //Reset the cursor x position and increase the y position
                    cursorPosX = (int)Position.X;
                    cursorPosY++;
                }
                //If the cursor has reached the maximum height...
                if (cursorPosY > (int)Position.Y + Height)
                    //...leave the loop
                    break;
            }
        }
    }
}
