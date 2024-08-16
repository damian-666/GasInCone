using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private const string WindowStateFile = "windowstate.txt";
        private bool _disposed = false;

        public Game1()
        {
            _graphics=new GraphicsDeviceManager(this);
            Content.RootDirectory="Content";
            IsMouseVisible=true;

            LoadWindowState();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch=new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back==ButtonState.Pressed||Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            SaveWindowState();
            base.OnExiting(sender, args);
        }

        private void LoadWindowState()
        {
            if (File.Exists(WindowStateFile))
            {
                var lines = File.ReadAllLines(WindowStateFile);
                if (lines.Length==4&&
                    int.TryParse(lines[0], out int x)&&
                    int.TryParse(lines[1], out int y)&&
                    int.TryParse(lines[2], out int width)&&
                    int.TryParse(lines[3], out int height))
                {
                    Window.Position=new Point(x, y);
                    _graphics.PreferredBackBufferWidth=width;
                    _graphics.PreferredBackBufferHeight=height;
                    _graphics.ApplyChanges();
                }
            }
        }

        private void SaveWindowState()
        {
            var position = Window.Position;
            var width = _graphics.PreferredBackBufferWidth;
            var height = _graphics.PreferredBackBufferHeight;
            File.WriteAllLines(WindowStateFile, new string[]
            {
                    position.X.ToString(),
                    position.Y.ToString(),
                    width.ToString(),
                    height.ToString()
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _spriteBatch?.Dispose();
                    _graphics?.Dispose();
                }

                // Dispose unmanaged resources

                _disposed=true;
            }

            base.Dispose(disposing);
        }
    }
}

