# Unity Space Shooter Game

A 2D space shooter game built with Unity where you control a player ship, shoot enemies, and try to survive as long as possible while scoring points.

## 🎮 Game Features

- **Player Movement**: Control your ship with WASD
- **Shooting**: Press Spacebar to shoot bullets at enemies
- **Enemy Types**: Two different enemy types with unique movement patterns
- **Lives System**: Start with 3 lives, represented by heart icons
- **Score System**: Earn points by destroying enemies
- **Visual Effects**: Explosion animations when enemies are destroyed
- **Cloud Background**: Animated clouds that fall and loop
- **Game Over Screen**: Displays final score and allows restart

## 🎯 How to Play

### Controls
- **WASD**: Move your ship
- **Spacebar**: Shoot bullets
- **R** (on Game Over screen): Restart the game

### Objective
- Survive as long as possible
- Destroy enemies to earn points
- Avoid colliding with enemies (you lose a life)
- Game ends when you run out of all 3 lives

### Scoring
- Destroying enemies awards points
- Your final score is displayed on the Game Over screen

## 📁 Project Structure

```
Assets/
├── Prefabs/          # Game object prefabs
│   ├── Player.prefab
│   ├── Enemy.prefab
│   ├── Enemy2.prefab
│   ├── Bullet.prefab
│   ├── Cloud.prefab
│   └── explosian.prefab
├── Scripts/          # C# scripts
│   ├── GameManager.cs          # Main game logic, spawning, lives, score
│   ├── PlayerController.cs      # Player movement and shooting
│   ├── Enemy.cs                 # First enemy type behavior
│   ├── Enemy2.cs                # Second enemy type behavior
│   ├── Bullet.cs                # Bullet movement
│   ├── Cloud.cs                 # Cloud movement and looping
│   ├── GameOverManager.cs       # Game over screen logic
│   ├── Barrier.cs               # Barrier collision handling
│   └── Explosion.cs             # Explosion effect management
└── Scenes/          # Unity scenes
    ├── MainScene.unity          # Main game scene
    └── GameOver.unity           # Game over scene
```

## 🔧 Setup Instructions

### Prerequisites
- Unity Editor (version compatible with the project)
- TextMeshPro package (for UI text)

### Installation
1. Clone or download this repository
2. Open the project in Unity Editor
3. Ensure all scenes are added to Build Settings:
   - Go to `File > Build Settings`
   - Add `MainScene` and `GameOver` scenes if not already present

### Scene Setup

#### MainScene Setup
1. Create a GameManager GameObject:
   - Add the `GameManager` component
   - Assign prefabs in Inspector:
     - Player prefab
     - Enemy prefab
     - Enemy2 prefab
     - Cloud prefab
   - Assign heart UI GameObjects (heart1, heart2, heart3)

2. Create UI Canvas for hearts:
   - Create 3 Image GameObjects for hearts
   - Position them in the top-left corner
   - Assign them to GameManager's heart1, heart2, heart3 fields

#### GameOver Scene Setup
1. Create a GameOverManager GameObject:
   - Add the `GameOverManager` component
   - Assign the score TextMeshProUGUI component

## 📝 Scripts Overview

### GameManager.cs
- Manages game state (score, lives)
- Handles enemy and cloud spawning
- Controls game over logic
- Updates heart UI display

### PlayerController.cs
- Handles player movement
- Manages shooting mechanics
- Screen boundary constraints
- Life loss communication with GameManager

### Enemy.cs
- First enemy type with horizontal bouncing movement
- Collision detection with bullets and player
- Explosion spawning on death

### Enemy2.cs
- Second enemy type with square path movement
- Collision detection with bullets

### Cloud.cs
- Cloud movement (falling)
- Automatic respawn at top when reaching bottom
- Random size and opacity

### GameOverManager.cs
- Displays final score from PlayerPrefs
- Handles restart functionality (R key)

## 🎨 Game Mechanics

### Enemy Spawning
- **Enemy Type 1**: Spawns every 1 second at random positions
- **Enemy Type 2**: Spawns every 5 seconds (starting after 5 seconds delay)
- **Clouds**: Spawn every 5 seconds

### Lives System
- Player starts with 3 lives
- Each collision with an enemy reduces lives by 1
- Heart icons disappear as lives are lost
- Game over triggers when lives reach 0

### Score System
- Points awarded for destroying enemies
- Score persists to Game Over screen via PlayerPrefs

## Youtube Link
https://youtube.com/shorts/ZyArnDNma9U

## Group Members
Ethan Handler(just me)


---

**Enjoy the game!** 🚀

