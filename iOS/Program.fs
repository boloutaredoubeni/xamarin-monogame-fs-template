namespace WalkingGame.iOS

#if MONOGAME
open MonoMac.Appkit
open MonoMac.Foundation
#endif
#if __IOS__ || __TVOS__
open Foundation
open UIKit
#endif

module Program =

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

    // FIXME: this wont export
    let RunGame() =
        let game = new Game1()
        game.Run()

#if __IOS__ || __TVOS__
    [<Register("AppDelegate")>]
    type AppDelegate() =
        inherit UIApplicationDelegate()

        override this.FinishedLaunching(app: UIApplication) = RunGame()
#endif



#if MONOMAC
    type AppDelegate() =
        inherit NSApplicationDelegate()

        override this.FinishedLaunching (notification: NsObject) =
            AppDomain.CurrentDomain.AssemblyResolve <- (fun (sender: object) (a: ResolveEventArgs) ->
                if 
                    a.Name.StartsWith("MonoMac") 
                then
                    typeof<AppKit.AppKitFramework>.Assembly
                else
                    null
            )
            RunGame()

        override this.ApplicationShouldTerminateAfterLastWindowClosed (sender: NSApplication) = true
#endif
