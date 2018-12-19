# The Wheels of Redemption

Mobile Game prototype made with Unity based on the popular flash game [Wheels of Salvation](https://www.miniclip.com/games/wheels-of-salvation/).

**THIS CODE IS RELEASED UNDER THE GPL LICENSE, IF YOU WANT TO USE IT FOR ANYTHING THAT IS NOT OPEN-SOURCE CONTACT ME FIRST.**

## Download
The app is not officially released on any store, but here is the latest unofficial build:
- Android: [Download](https://github.com/Sytten/WheelsRedemption/releases/download/v0.1.0/The.Wheels.of.Redemptions.0.1.0.android.apk)

## Setup
This was developed with [Unity 5.4.0f3](https://unity3d.com/get-unity/download/archive) and **will not** work on more recent versions. I also had trouble running this Unity version in Windows 10 (Windows 7 was used at the time of development).

This limitation is due to the fact that Unity updated the C# and Mono versions later on and that caused some issues with templates (more precisely the introduction of the [covariant](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-generic-modifier) and [contravariant](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-generic-modifier) concepts).

A refactor was started in one of the branches, but was never finished.

## Gameplay
![levels](https://raw.githubusercontent.com/Sytten/WheelsRedemption/master/levels.png) 

On the image above we can see the main elements of the game:
1. `Standard Wheel`: Wheels are separated in four quadrants. For a standard wheel all four are "sticky", meaning that the player attach to them. The size of the wheel dictates how fast it rotates. A wheel can be slowed down by the player if ne presses it for some time. I will slowly regain speed when he releases the pression. 
2. `Starting platform`: This is where the player starts. He goes from left to right automatically. He cannot stop that movement. He must jump to the first wheel by clicking anywhere on the screen except on a wheel.
3. `End platform`: This is the platform the player must reach to win the level. He wins as soon as he touches it.
4. `Wooden Wheel`: This type of wheel has one or more quadrant that is not "sticky". The player will bounce against them.
5. `Wall`: This is the limit of the level, the player will bounce a little bit against them.
6. `Lava`: The lava rises all the time, the player must reach the `end platform` before it touches him. He loses the level otherwise.

## Future
You can look at the issues to see a bit what remains to do, but here are some ideas and priorities:
- Finish the refactor of the communication engine that causes trouble with templates
- Add real assets
- Add fragile wheels that break after the player went once on them
- Add coins and perfs to buy with them
- Add some upgrades for the player
  - Double jump
  - Big jump
  - Rocket boots
  - Spiky boots (to be able to use `wooden wheels`)
  - Light boots (to not break the fragile wheels)
- Add an infinite map, procedurally generated
