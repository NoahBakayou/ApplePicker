## Apple Picker (CS583)

A simple arcade-style Unity game where you move a basket to catch falling apples from one or more moving trees. Missed apples cost you a basket; lose them all and the game restarts. Score increases as you catch apples, and new trees spawn as you hit score milestones to ramp up difficulty.

### Gameplay Video
[![Watch the gameplay](https://img.youtube.com/vi/ChUpynp9sbI/0.jpg)](https://youtu.be/ChUpynp9sbI)

### Features
- **Basket control**: Move horizontally with the mouse to catch apples
- **Moving apple trees**: Trees sway left/right and drop apples at intervals
- **Staggered drops**: Trees can start dropping at offset times for variety
- **Score & High Score**: +100 per apple; high score tracked on-screen
- **Lives system**: Start with multiple baskets; lose one per missed apple
- **Dynamic difficulty**: A new tree is spawned every 1,000 points

### How to Play
- **Controls**: Move the mouse left/right to position the basket under falling apples
- **Goal**: Catch apples to score points and avoid losing baskets
- **Game Over**: When all baskets are lost, the scene restarts

### Project Structure (Key Scripts)
- `Assets/AppleTree.cs`: Tree movement and apple spawning
- `Assets/Apple.cs`: Apple behavior and missed-apple detection
- `Assets/Basket.cs`: Player basket control and apple catching
- `Assets/ScoreCounter.cs`: Score UI updates
- `Assets/HighScore.cs`: High score UI and persistence (for session)
- `Assets/ApplePicker.cs`: Game manager (baskets, missed logic, dynamic tree spawn)

### Requirements
- Unity (2021+ recommended)
- TextMesh Pro (included via Unity packages)

### Notes
- Assign `Apple Tree Prefab` to the `ApplePicker` component on the Main Camera
- Configure apple spawn offset and initial delays on each `AppleTree` for fine-tuning
