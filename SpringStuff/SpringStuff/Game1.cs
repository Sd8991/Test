using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    SpringOperations sO;
    Spring s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
    Rectangle r;
    Texture2D SpringPic;
    Spring[] allSpring;
    Rectangle[] allRectangle;
    double thyme;


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        allSpring = new Spring[2];
        allRectangle = new Rectangle[2];
        s1 = new Spring(new Vector2(100, 50), new Vector2(100, 200), 100, 40, 0.0f, 1f, 20, 1.0f);
        allSpring[0] = s1;
        s2 = new Spring(new Vector2(100, 200), new Vector2(100, 300), 50, 20, 0.0f, 1f, 20, 0.0f);
        allSpring[1] = s2;
        /*s3 = new Spring(new Vector2(300, 50), new Vector2(300, 200), 50, 20, 0.0f, 1f, 20, 0.2f);
        allSpring[2] = s3;
        s4 = new Spring(new Vector2(400, 50), new Vector2(400, 200), 50, 20, 0.0f, 1f, 20, 0.3f);
        allSpring[3] = s4;
        s5 = new Spring(new Vector2(500, 50), new Vector2(500, 200), 50, 20, 0.0f, 1f, 20, 0.4f);
        allSpring[4] = s5;
        s6 = new Spring(new Vector2(600, 50), new Vector2(600, 200), 50, 20, 0.0f, 1f, 20, 0.5f);
        allSpring[5] = s6;*/
        sO = new SpringOperations();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        SpringPic = Content.Load<Texture2D>("Spring_Mk_II");
    }

    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    protected override void Update(GameTime gameTime)
    {
        thyme = (double)gameTime.ElapsedGameTime.Milliseconds / 1000;

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (Spring s in allSpring)
        {
            //s.SLS(gameTime);
            //s.SLSMkII(gameTime);
        }
        sO.MultiSpring(thyme, s1, s2);


        for (int i = 0; i < allSpring.Length; i++)
        {
            try
            {
                r = new Rectangle((int)allSpring[i].beginPointX, (int)allSpring[i - 1].endPointY, (int)allSpring[i].radius, (int)(allSpring[i].stretch + allSpring[i].height));
                allRectangle[i] = r;
            }
            catch
            {
                r = new Rectangle((int)allSpring[i].beginPointX, (int)allSpring[i].beginPointY, (int)allSpring[i].radius, (int)(allSpring[i].stretch + allSpring[i].height));
                allRectangle[i] = r;
            }

        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here
        spriteBatch.Begin();
        foreach (Rectangle r in allRectangle)
            spriteBatch.Draw(SpringPic, r, Color.AntiqueWhite);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}