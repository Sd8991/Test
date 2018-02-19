using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Spring s1, s2, s3, s4, s5;
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
        allSpring = new Spring[5];
        allRectangle = new Rectangle[5];
        s1 = new Spring(new Vector2(50, 50), new Vector2(50, 100), 45, 10, 0.0f, 1f);
        allSpring[0] = s1;
        s2 = new Spring(new Vector2(200, 50), new Vector2(100, 200), 90, 10, 0.0f, 1f);
        allSpring[1] = s2;
        s3 = new Spring(new Vector2(350, 50), new Vector2(50, 100), 180, 10, 0.0f, 1f);
        allSpring[2] = s3;
        s4 = new Spring(new Vector2(500, 50), new Vector2(100, 200), 90, 20, 0.0f, 1f);
        allSpring[3] = s4;
        s5 = new Spring(new Vector2(650, 50), new Vector2(50, 100), 180, 20, 0.0f, 1f);
        allSpring[4] = s5;
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
            s.SLS(gameTime);

        for (int i = 0; i < allSpring.Length; i++)
        {
            r = new Rectangle((int)allSpring[i].beginPoint.X, (int)allSpring[i].beginPoint.Y, (int)allSpring[i].radius, (int)allSpring[i].newLength);
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