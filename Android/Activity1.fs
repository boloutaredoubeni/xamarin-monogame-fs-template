namespace WalkingGame.Droid

open System

open Android.App
open Android.Content
open Android.Runtime
open Android.Content.PM
open Android.Views
open Android.Widget
open Android.OS

open Microsoft.Xna.Framework

[<Activity(Label = "WalkingGame.Droid",
    MainLauncher = true,
    Icon = "@drawable/icon",
    Theme = "@style/Theme.Splash",
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ConfigurationChanges = (ConfigChanges.Orientation |||
                            ConfigChanges.KeyboardHidden |||
                            ConfigChanges.Keyboard))>]
type Activity1() =
    inherit AndroidGameActivity()

    override this.OnCreate(bundle: Bundle) =
        base.OnCreate (bundle)

        let game = new Game1()
        SetContentView((View)game.Services.GetService(typeof<View>))
        game.Run()
