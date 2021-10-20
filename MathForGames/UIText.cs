using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class UIText : Actor
    {
        public string Text;
        public int Width;
        public int Height;
        public int FontSize;
        public Font Font;
        
        public UIText(float x, float y, string name, Color color, int width, int height,int fontSize, string text = "")
            : base('\0', x, y, color, name)
        {
            Text = text;
            Width = width;
            Height = height;
            Font = Raylib.LoadFont("resources/fonts/alagard.png");
            FontSize = fontSize;
        }
      
        public override void Draw()
        {
            //Makes the Text Box
            Rectangle textBox = new Rectangle(Position.X, Position.Y, Width, Height);
            //Draws out Text Box
            Raylib.DrawTextRec(Font, Text, textBox, FontSize, 1, true, Icon.Color);
        }
    }
}
