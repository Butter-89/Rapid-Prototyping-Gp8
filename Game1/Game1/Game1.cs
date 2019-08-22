using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //just for testing the mechanics here. Will change to player part later

        Texture2D ball1Texture;
        Vector2 ball1Position;
        Circle ball1Collider;

        Texture2D ball2Texture;
        Vector2 ball2Position;
        Circle ball2Collider;

        

        bool collided = false;

        float ballSpeed;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            ball1Position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);

            ball2Position = new Vector2(0, 0);


            ballSpeed = 300f;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball1Texture = Content.Load<Texture2D>("ball");
            ball1Collider = new Circle(new Vector2(ball1Texture.Width / 2, ball1Texture.Height / 2) + ball1Position, ball1Texture.Width / 2);
            ball2Texture = Content.Load<Texture2D>("ball");
            ball2Collider = new Circle(new Vector2(ball2Texture.Width / 2, ball2Texture.Height / 2) + ball2Position, ball2Texture.Width / 2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //Get the user input and apply movement
            var kstate1 = Keyboard.GetState();
            var kstate2 = Keyboard.GetState();

            if (kstate1.IsKeyDown(Keys.Up))
                ball1Position.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate1.IsKeyDown(Keys.Down))
                ball1Position.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate1.IsKeyDown(Keys.Left))
                ball1Position.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate1.IsKeyDown(Keys.Right))
                ball1Position.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate2.IsKeyDown(Keys.W))
                ball2Position.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate2.IsKeyDown(Keys.S))
                ball2Position.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate2.IsKeyDown(Keys.A))
                ball2Position.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate2.IsKeyDown(Keys.D))
                ball2Position.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //update the collider location and information
            ball1Collider.UpdateColliderPosition( ball1Position); //new Vector2(ball1Texture.Width / 2, ball1Texture.Height / 2) +
            ball2Collider.UpdateColliderPosition( ball2Position); //new Vector2(ball2Texture.Width / 2, ball2Texture.Height / 2) +

            Debug.WriteLine(ball1Collider.Center.ToString());

            //Check the location of each collider for collision detection
            if (ball1Collider.Intersects(ball2Collider))
            {
                Debug.WriteLine("Ball 1 position: " + ball1Position.ToString() + " Ball 2 position: " + ball2Position.ToString());
                Debug.WriteLine("Ball 1 Center: " + ball1Collider.Center.ToString() + " Ball 2 Center: " + ball2Collider.Center.ToString());
                Debug.WriteLine("Ball 1 Radius: " + ball1Collider.Radius.ToString() + " Ball 2 Radius: " + ball2Collider.Radius.ToString());
                collided = true;
            }
                
            else
                collided = false;

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //With this we are setting the origin to the center of the image. Now the image will get drawn to the center of the screen.
            if(!collided)
                spriteBatch.Draw(ball1Texture, ball1Position, null, Color.White, 0f, new Vector2(ball1Texture.Width / 2, ball1Texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);

            spriteBatch.Draw(ball2Texture, ball2Position, null, Color.White, 0f, new Vector2(ball2Texture.Width / 2, ball2Texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
