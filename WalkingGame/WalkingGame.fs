namespace WalkingGame

open System

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Game1() as game =
    inherit Game()

    do
        game.Content.RootDirectory <- "Content"

    let graphics = new GraphicsDeviceManager(game)

    let mutable spriteBatch = null

    override game.Initialize() =
        base.Initialize()

    override game.LoadContent() =
        spriteBatch <- new SpriteBatch(game.GraphicsDevice)

    override game.Update(gameTime: GameTime) =
#if !__IOS__ && !__TVOS__
        if
            GamePad.GetState(PlayerIndex.One).Button.Back  ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        then
            Exit()
#endif
        base.Update gameTime

    override game.Draw(gameTime: GameTime) =
        graphics.GraphicsDevice.Clear Color.CornflowerBlue
        base.Draw gameTime