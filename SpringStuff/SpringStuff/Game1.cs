using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Spring s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
    Rectangle r;
    Texture2D SpringPic;
    Spring[] allSpring;
    Rectangle[] allRectangle;


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        allSpring = new Spring[12];
        allRectangle = new Rectangle[12];
        s1 = new Spring(new Vector2(100, 50), new Vector2(100, 200), 150, 20, 0.0f, 1f, 20, 0f);
        allSpring[0] = s1;
        s2 = new Spring(new Vector2(200, 50), new Vector2(200, 200), 150, 20, 0.0f, 1f, 20, 0.1f);
        allSpring[1] = s2;
        s3 = new Spring(new Vector2(300, 50), new Vector2(300, 200), 150, 20, 0.0f, 1f, 20, 0.2f);
        allSpring[2] = s3;
        s4 = new Spring(new Vector2(400, 50), new Vector2(400, 200), 150, 20, 0.0f, 1f, 20, 0.3f);
        allSpring[3] = s4;
        s5 = new Spring(new Vector2(500, 50), new Vector2(500, 200), 150, 20, 0.0f, 1f, 20, 0.4f);
        allSpring[4] = s5;
        s6 = new Spring(new Vector2(600, 50), new Vector2(600, 200), 150, 20, 0.0f, 1f, 20, 0.5f);
        allSpring[5] = s6;
        s7 = new Spring(new Vector2(100, 250), new Vector2(100, 400), 150, 20, 0.0f, 1f, 20, 0.6f);
        allSpring[6] = s7;
        s8 = new Spring(new Vector2(200, 250), new Vector2(200, 400), 150, 20, 0.0f, 1f, 20, 0.7f);
        allSpring[7] = s8;
        s9 = new Spring(new Vector2(300, 250), new Vector2(300, 400), 150, 20, 0.0f, 1f, 20, 0.8f);
        allSpring[8] = s9;
        s10 = new Spring(new Vector2(400, 250), new Vector2(400, 400), 150, 20, 0.0f, 1f, 20, 0.9f);
        allSpring[9] = s10;
        s11 = new Spring(new Vector2(500, 250), new Vector2(500, 400), 150, 20, 0.0f, 1f, 20, 1f);
        allSpring[10] = s11;
        s12 = new Spring(new Vector2(600, 250), new Vector2(600, 400), 150, 20, 0.0f, 1f, 20, 1.1f);
        allSpring[11] = s12;
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
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (Spring s in allSpring)
        {
            //s.SLS(gameTime);
            s.SLSMkII(gameTime);
            //s.VertMove();
        }

        for (int i = 0; i < allSpring.Length; i++)
        {
            r = new Rectangle((int)allSpring[i].beginPointX, (int)allSpring[i].beginPointY, (int)allSpring[i].radius, (int)(allSpring[i].stretch + allSpring[i].height));
            allRectangle[i] = r;
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