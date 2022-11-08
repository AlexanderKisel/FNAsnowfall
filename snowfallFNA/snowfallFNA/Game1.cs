using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace snowfallFNA
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private Texture2D sochi;
        Random random = new Random();
        public List<SceneObject> objects = new List<SceneObject>();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int check = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.Title = "Зелёный снег";
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }
        public void LoadLevel()
        {
            for (var i = 0; i < 1000; i++)//можно ставить любое число до 100 тысяч,
                                          //дальше пробовать не стал, но загрузтло
                                          //относительно быстро, буквально 20 секунд, не более
            {
                objects.Add(new konoplya(new Vector2(random.Next(0, 1280), random.Next(-780, -50))));
            }
            LoadObjects();
        }

        public void LoadObjects()
        {
            for (var i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize();
                objects[i].Load(Content);
            }
        }

        public void UpdateObjects()
        {
            if (check == 0)
            {
                for (var i = 0; i < objects.Count; i++)
                {
                    objects[i].Update(objects);
                    objects[i].position.Y += 1 + objects[i].scale * 5;
                    //Попытка сделать крутящиеся снежинки
                    //objects[i].rotation += float.Parse((random.NextDouble() * (-0.3 + 0.3) + 0.1).ToString());
                    //Крутящиеся снежинки, но только в одну сторону
                    objects[i].rotation += 0.01f; //Проблема заключается в том,
                                                  //что "снежики" крутятся не вокргу центра,
                                                  //а вокруг края и что с этим делать я не знаю,
                                                  //ответа в инете не нашел.
                    if (objects[i].position.Y <= 720)
                    {
                        continue;
                    }
                    objects[i].position.Y = -50;
                }
            }
        }

        public void DrawObjects()
        {
            for (var i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }

        private void StopStart()
        {
            if (Input.MouseLeftClicked())
            {
                check++;
                if (check == 2)
                {
                    check = 0;
                }
            }
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sochi = TextureLoader.Load("sochi", Content);
            LoadLevel();
        }
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            StopStart();
            UpdateObjects();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            DrawObjects();
            spriteBatch.Draw(sochi, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
