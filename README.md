# John Lemon's Haunted Jaunt
Solo Team - Sterling Stewart
1. **Dot product gameplay element** - When the player is close enough within an enemy's radius, they will begin to flash red as long as they are not behind the enemy. The dot product is being used to calculate the player's relative position around the enemy (-1 for behind, 0 for perpendicular, 1 for in front).
2. **Linear interpolation gameplay element** - The afformentioned red flashing is implemented using Color.lerp and Mathf.PingPong.
3. **Particle effect** - The ghosts have a trail of dust particles following their movement.
