using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace NavigationMenu.Content
{
    public class Button
    {
        //Class Variables
        string Name;
        Vector2 Position;
        int Height;
        int Width;
        bool Active;
        string Category;
        Texture2D BackgroundTexture;
        int Stroke;
        Color StrokeColour;
        Texture2D StrokePixel;

        //Methods
        public Button(string Input_Name, Vector2 Input_Position, int Input_Height, int Input_Width, bool Input_Active = false, string Input_Category = null, Texture2D Input_Background = null, int Input_Stroke = 0, Color? Input_StrokeColour = null, Texture2D Input_StrokePixel = null) //Creating the button with optional parameters for details on the button
        {
            Name = Input_Name;
            Position = Input_Position;
            Height = Input_Height;
            Width = Input_Width;
            Active = Input_Active;
            Category = Input_Category;
            BackgroundTexture = Input_Background;
            Stroke = Input_Stroke;
            StrokeColour = (Color)Input_StrokeColour;
            StrokePixel = Input_StrokePixel;

        }

        public void Draw(SpriteBatch ActiveSpriteBatch)
        {
            if (Active == true) //If the button is being used
            {
                if (BackgroundTexture != null) //If there is a background, draw it
                {
                    int BackgroundStartX = (BackgroundTexture.Width / 2) - Width; //Getting the start points of the texture to make the button only show the middle bit if its too big
                    int BackgroundStartY = (BackgroundTexture.Height / 2) - Height;
                    Rectangle BackgroundBound = new Rectangle(BackgroundStartX, BackgroundStartY, Width, Height);
                    ActiveSpriteBatch.Draw(BackgroundTexture, Position, BackgroundBound, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }

                if (Stroke != 0) //If there is a stroke, add it
                {
                    Rectangle StrokeRectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height); //Default rectangle outline
                    for (int StrokeCount = 0; StrokeCount < Stroke; StrokeCount++)
                    {
                        Rectangle NewStrokeRectangle = new Rectangle(StrokeRectangle.X + StrokeCount, StrokeRectangle.Y + StrokeCount, StrokeRectangle.Width - StrokeCount, StrokeRectangle.Height - StrokeCount); //Making the rectangle go in to create stroke
                        ActiveSpriteBatch.Draw(StrokePixel, NewStrokeRectangle, StrokeColour);
                    }
                }
            }

        }


    }
}
