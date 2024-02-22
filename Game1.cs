using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Gamepad_Testing
{
    public class Game1 : Game
    {
        // Steve Aldworth
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int health;

        string buttons, axes;

        GamePadState gamepadState;
        JoystickState joystickState;

        SpriteFont textFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textFont = Content.Load<SpriteFont>("TextFont");
        }

        protected override void Update(GameTime gameTime)
        {
            joystickState = Joystick.GetState(0);
            gamepadState = GamePad.GetState(PlayerIndex.One);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            this.Window.Title = joystickState.IsConnected.ToString();
            
            // TODO: Add your update logic here

            buttons = string.Join(", ", joystickState.Buttons);
            axes = string.Join(", ", joystickState.Axes);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(textFont, buttons, new Vector2(10, 10), Color.Black);
            _spriteBatch.DrawString(textFont, axes, new Vector2(10, 50), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}