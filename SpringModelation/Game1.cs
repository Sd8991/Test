using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Spring s1, s2, s3;
    Rectangle r;
    Texture2D DatPic;
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
        allSpring = new Spring[3];
        allRectangle = new Rectangle[3];
        s1 = new Spring(new Vector2(50, 50), new Vector2(50, 100), 200.0f, 200.0f, 1, 50);
        allSpring[0] = s1;
        s2 = new Spring(new Vector2(200, 100), new Vector2(100, 200), 100.0f, 100.0f, 1, 25);
        allSpring[1] = s2;
        s3 = new Spring(new Vector2(400, 150), new Vector2(50, 100), 50.0f, 50.0f, 1, 100);
        allSpring[2] = s3;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        DatPic = Content.Load<Texture2D>("DatPic");
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
            s.Physics();

        for (int i = 0; i < 3; i++)
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
        foreach(Rectangle r in allRectangle)
            spriteBatch.Draw(DatPic, r, Color.AntiqueWhite);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}