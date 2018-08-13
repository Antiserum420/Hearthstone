using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Shared.Resources
{
    public sealed class ResourceManager
    {
        private static readonly Lazy<ResourceManager> lazy = new Lazy<ResourceManager>(() => new ResourceManager());

        private Dictionary<string, Texture> _textures;

        private const string TEXTURE_PATH = "shared/Resources/Textures";

        static ResourceManager()
        {
            
        }

        private ResourceManager()
        {
            _textures = new Dictionary<string, Texture>();
        }

        public static ResourceManager Instance => lazy.Value;

        public void Cleanup()
        {
            foreach(var texture in _textures)
            {
                texture.Value.Dispose();
            }
        }

        public Texture GetTexture(string key)
        {
            if(_textures.ContainsKey(key))
            {
                return _textures[key];
            }
            else
            {
                Texture texture = null;
                try
                {
                    var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

                    texture = new Texture(Path.Combine(solutionDirectory, TEXTURE_PATH, $"{key}.png"));
                }
                catch(Exception ex)
                {
                    return null;
                }

                _textures.Add(key, texture);
                return _textures[key];
            }
        }
    }
}
