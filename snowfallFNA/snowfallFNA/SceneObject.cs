using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snowfallFNA
{
    public class SceneObject
    {
        private readonly static Random random = new Random();
        protected Texture2D konoplya;
        public Vector2 position;
        private Color drawColor = Color.White;
        public float scale = float.Parse(random.NextDouble().ToString()), rotation = float.Parse(random.NextDouble().ToString());
        public float layerDepth = .5f;
        public bool active = true;
        protected Vector2 center;

        public Color DrawColor { get => drawColor; set => drawColor = value; }

        public virtual void Initialize()
        {

        }
        public virtual void Load(ContentManager content)
        {
            Center();//Ставим картинку по центру
        }
        public virtual void Update(List<SceneObject> objects)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (konoplya != null && active)
            {
                spriteBatch.Draw(konoplya, position, null, DrawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
            }
        }

        private void Center()
        {
            if (konoplya == null)
            {
                return;
            }
            center.X = konoplya.Width / 2;
            center.Y = konoplya.Height / 2;
        }
    }
}
