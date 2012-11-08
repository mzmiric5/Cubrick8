using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cubrick
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CubrickGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Cube cube;

        public CubrickGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
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
            TargetElapsedTime = TimeSpan.FromTicks(666666);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cube = new Cube(new Vector3(1, 1, 1), Vector3.Zero, GraphicsDevice);
            //aspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload all content.
        /// </summary>
        protected override void UnloadContent() {}

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) this.Exit();

            cube.rotationY += 2.5f;
            cube.rotationZ += 1.5f;
            cube.rotationY += 0.5f;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            cube.RenderToDevice(GraphicsDevice);

            //GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            base.Draw(gameTime);

        }
    }
}
