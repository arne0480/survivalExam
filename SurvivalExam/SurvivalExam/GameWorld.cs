using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Song backgroundMusic;


        static GameWorld instance;
        public float deltaTime;
        List<GameObject> gameObjectList = new List<GameObject>();
        List<Collider> colliders = new List<Collider>();
        public List<Collider> getColliders = new List<Collider>();

        GameObject gameObject = new GameObject();

        Rectangle playerRectangle;

        private Texture2D backgroundTexture;
        private Rectangle backgroundRectangle;

        public static GameWorld Instance //implementering af singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true; //Sætter spillet i fullscreen
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


            //Spilleren vises på skærmen
            GameObject go = new GameObject();
            go.AddComponet(new Collider(go));
            go.AddComponet(new SpriteRenderer(go, "AxeBanditFullSheetV2", 0, 2)); //Tilføjer billed via navn, hvilket lag den skal have og scalering den skal have
            go.AddComponet(new Animator(go));
            go.AddComponet(new Transform(go, Vector2.Zero));
            go.AddComponet(new Player(go));
            go.transform.position = new Vector2(100, 200);

            gameObjectList.Add(go);


            //fremkalder enemy
            GameObject goEnemy = new GameObject();
            goEnemy.AddComponet(new SpriteRenderer(goEnemy, "AxeBanditFullSheetV2", 0, 1));
            goEnemy.AddComponet(new Animator(goEnemy));
            goEnemy.AddComponet(new Enemy(goEnemy));
            goEnemy.AddComponet(new Collider(goEnemy));
            goEnemy.AddComponet(new Transform(goEnemy, Vector2.Zero));
            goEnemy.transform.position = new Vector2(300, 200);
            gameObjectList.Add(goEnemy);


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
            foreach (GameObject go in gameObjectList)
            {
                go.LoadContent(Content);
            }

            backgroundMusic = Content.Load<Song>("Cinematic Documentary - AShamaluevMusic");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;



            backgroundTexture = Content.Load<Texture2D>("FullbackgroundV2");
            backgroundRectangle = new Rectangle(0, -300, backgroundTexture.Width, backgroundTexture.Height);
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
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (GameObject go in gameObjectList)
            {
                go.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);

            foreach (GameObject go in gameObjectList) //Fremkalder spilleren
            {
                go.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
