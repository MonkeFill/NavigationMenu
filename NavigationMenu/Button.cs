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
            StrokePixel = Input_StrokePixel;
            if (Input_StrokeColour == null)
            {
                Input_StrokeColour = Color.Black; //Default stroke colour
            }
            else
            {
                StrokeColour = (Color)Input_StrokeColour;
                StrokePixel.SetData(new[] { StrokeColour }); //Colouring the pixel
            }

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
                    //Drawing four separate boxes for the stroke sides
                    ActiveSpriteBatch.Draw(StrokePixel, new Rectangle(StrokeRectangle.X - Stroke, StrokeRectangle.Y - Stroke, StrokeRectangle.Width + (Stroke * 2), Stroke), StrokeColour); //Top
                    ActiveSpriteBatch.Draw(StrokePixel, new Rectangle(StrokeRectangle.X - Stroke, StrokeRectangle.Y + StrokeRectangle.Height, StrokeRectangle.Width + (Stroke * 2), Stroke), StrokeColour); //Bottom
                    ActiveSpriteBatch.Draw(StrokePixel, new Rectangle(StrokeRectangle.X - Stroke, StrokeRectangle.Y - Stroke, Stroke, StrokeRectangle.Height + (Stroke * 2)), StrokeColour); //Left
                    ActiveSpriteBatch.Draw(StrokePixel, new Rectangle(StrokeRectangle.X + StrokeRectangle.Width, StrokeRectangle.Y - Stroke, Stroke, StrokeRectangle.Height + (Stroke * 2)), StrokeColour); //Right
                }
            }

        }


    }
}
