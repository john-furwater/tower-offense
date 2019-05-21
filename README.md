# Tower Offense

[![Build Status](https://travis-ci.com/john-furwater/tower-offense.svg?branch=master)](https://travis-ci.com/john-furwater/tower-offense)

Tower Offense is a Tetris style game where players must build a tower out of
descending shapes, as well as move a sliding canon attached to a rail next to
their tower, attacking opponents towers and defending their own.  A notable
difference from Tetris is that blocks do NOT disappear when you complete a solid
line.

## Unity version:
2019.1.3f1

## Test Scenes:
### TowerBattleScene
Controls are as follows:

|   Axis               | Player 1 | Player 2 |
| -------------------- |:--------:|:--------:|
| Move Cannon Up       | w        | o        |
| Move Cannon Down     | s        | l        |
| Rotate Cannon Left   | a        | k        |
| Rotate Cannon Right  | d        | ;        |
| Fire Cannon          | e        | i        |
| Move Crate Left      | z        | ,        |
| Move Crate Right     | x        | .        |
| Rotate Crate 90&deg; | c        | m        |

The longer you hold the `Fire Cannon` button down, the more velocity the
`Cannonball` will get shot with.  Once the button gets released, you must wait
until the `Charge Bar` goes away before you can fire again.

You can move the `Cannon` up as far as the highest `Crate` from your side.
`Crates` fall every 5 seconds and a `Stone` falls between sides every 3 seconds.
Only a `Cannonball` can destroy the `Target`.  If the `Target` on your side gets
destroyed, your opponent wins.

### CannonScene
This is for testing out the `Cannon`.  You can `Fire`, `Move`, and `Rotate` the
`Cannon`.

Controls are as follows:

|   Axis               | Button |
| -------------------- |:------:|
| Move Cannon Up       | w      |
| Move Cannon Down     | s      |
| Rotate Cannon Left   | a      |
| Rotate Cannon Right  | d      |
| Fire Cannon          | e      |


### CannonScene
This is for testing out the `Blocks`.  You can `Move` and `Rotate` the `Blocks`
as they fall every five seconds.

Controls are as follows:

|   Axis               | Button |
| -------------------- |:------:|
| Move Crate Left      | z      |
| Move Crate Right     | x      |
| Rotate Crate 90&deg; | c      |

## CI Build Pipeline
Currently using Travis CI (https://travis-ci.com/john-furwater/tower-offense) to
do branch, pull request, and merge builds.

Current build targets are:
* Linux 64
* Mac OSX
* Windows 64

## Local Builds
Run ```./local_build.sh``` to produce the following builds:
* Linux 64
* Mac OSX
* Windows 64

Currently WebGL does not work from CLI, but the app will get generated if you
build from the Unity editor.
