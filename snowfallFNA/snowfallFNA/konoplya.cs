using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snowfallFNA
{
    public class konoplya : SceneObject
    {
        public konoplya(Vector2 inputPosition)
        {
            position = inputPosition;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Load(ContentManager content)
        {
            konoplya = TextureLoader.Load("konoplya", content);
            base.Load(content);
        }
        public override void Update(List<SceneObject> objects)
        {
            base.Update(objects);
        }
    }
}
