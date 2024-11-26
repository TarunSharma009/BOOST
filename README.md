

# PAD Movement Script  

This repository contains a Unity script (`PAD.cs`) designed to create smooth oscillatory movement for a GameObject. By leveraging sine wave calculations, the script allows objects to move periodically along a specified direction vector.  

## Table of Contents  
- [Overview](#overview)  
- [Features](#features)  
- [Setup and Usage](#setup-and-usage)  
- [Parameters](#parameters)  
- [Code Explanation](#code-explanation)  
- [Contributing](#contributing)  
- [License](#license)  

## Overview  
The `PAD` script implements simple harmonic motion for a GameObject in Unity. It is particularly useful for creating dynamic and visually engaging animations such as floating platforms, pendulums, or any object that needs periodic movement.  

## Features  
- **Customizable Motion**: Adjust the movement range and period directly in the Unity Inspector.  
- **Smooth Oscillation**: Uses sine wave calculations for fluid and natural movement.  
- **Non-Disruptive**: Ensures the object starts at its initial position and moves relative to it.  
- **Easy Integration**: Plug-and-play functionality with Unity's component-based system.  
- **Safety Check**: Prevents issues when the period is set to zero using `Mathf.Epsilon`.  

## Setup and Usage  

1. **Add the Script to Your Project**:  
   - Copy the `PAD.cs` file into your Unity project's `Assets/Scripts` folder.  

2. **Attach to a GameObject**:  
   - Drag the script onto the GameObject you want to move.  

3. **Configure in Inspector**:  
   - **Period**: Set how long it takes for a complete oscillation (default: `2f`).  
   - **Movement Vector**: Define the direction and magnitude of movement (default: `(2, 0, 0)`).  
   - **Movement Factor**: [Read-only] Shows the current movement position as a normalized value (`0-1`).  

4. **Run the Game**:  
   - Hit play to see the object oscillate along the specified vector.  

## Parameters  

The script includes the following serialized fields for customization:  

| Parameter        | Description                                          | Default Value |  
|------------------|------------------------------------------------------|---------------|  
| `period`         | The time (in seconds) for a full oscillation cycle.  | `2f`          |  
| `movement_vector`| The direction and magnitude of the oscillation.      | `(2, 0, 0)`   |  
| `movementfactor` | Read-only: Tracks the normalized movement (0 to 1).  | Calculated    |  

## Code Explanation  

### Core Logic  

- **Sine Wave Calculation**:  
  ```csharp  
  float cycle = Time.time / period;  
  float rawsineewav = Mathf.Sin(cycle * Mathf.PI * 2f);  
  movementfactor = rawsineewav / 2f + 0.5f;

This converts the elapsed time into a normalized sine wave for periodic movement.

Position Adjustment:

Vector3 offset = movement_vector * movementfactor;  
transform.position = startingpos + offset;

Updates the object's position based on the calculated offset.

Safety Check:

if (period == Mathf.Epsilon) { return; }

Prevents division by zero errors.


Contributing

Contributions are welcome! Feel free to fork this repository, make changes, and submit a pull request.

1. Fork the repository.


2. Create a new branch: git checkout -b feature-name.


3. Commit your changes: git commit -m 'Add feature'.


4. Push to the branch: git push origin feature-name.


5. Submit a pull request.



License

This project is licensed under the MIT License. See the LICENSE file for details.


---

Enjoy building dynamic and interactive experiences with the PAD script!

This format provides clear, professional documentation for your repository, making it easy for users to understand and integrate your script.

