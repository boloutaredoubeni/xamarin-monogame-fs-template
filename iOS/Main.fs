open WalkingGame
open WalkingGame.iOS

#if MONOGAME
open MonoMac.Appkit
open MonoMac.Foundation
#endif
#if __IOS__ || __TVOS__
open Foundation
open UIKit
#endif

// TODO: remove this
let RunGame() =
    let game = new Game1()
    game.Run()

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
#if !MONOMAC && !__IOS__ && !__TVOS__
[<STAThread>]
#endif
[<EntryPoint>]
let main (args: string[]) =
#if MONOMAC
    NSApplication.Init()
    use p = NSAutoreleasePool ()
    NSApplication.SharedApplication.Delegate = new AppDelegate()
    NSApplication.Main(args)
#endif

#if __IOS__ || __TVOS__
    UIApplication.Main(args, null, "AppDelegate")
#endif
    RunGame()
    0