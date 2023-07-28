This is an overview of the project's entire development.

## Version 0.1.3
### In Progress
- Created a second VehicleController for user 

## Version 0.1.2
### Published July 27, 2023
![]("https://raw.githubusercontent.com/rvishwajith/Slipstream/main/Thumbnails/v0-1-2-hovering.png")
**Working spring suspension for hovering off the floor.**
- Added spring-based hovering to the vehicle controller:
  - Calculates compression ratio and adds force by multiplying compression ratio by an SO value.
  - Potential issues:
    - Wobbling in the air a lot and jumping in random directions (FIXED)
      - Compute force damping by multiplying the velocity at a Rigidbody point (on up axis only) by an SO damping value, then subtract this value from the net force being added.
    - Can flip if the SO values for spring compression or damping are high.
      - Potential fix: Set the center of mass to a point much lower than the actual center.
    - Slowly moves in the forward direction on its own.
      - Not a significant issue, but a possible fix is doing the ray casts in a random order. 
- Updated the gizmos.
- Added some standard classes from UnityUtilities repository to Utilities.
- Updated attributions.

## Version 0.1.1
### Published July 27, 2023
**Initial physics tests on a standard rigidbody.**
- Started working on the vehicle physics system:
  - Created the VehiclePhysics component class:
    - Added to an object with a rigidbody and a box collider.
    - Casts rays down from points on the bottom of the collider:
      - Planned ray action (rays do nothing yet): If a ray hits the ground within the spring length's distance:
        - Apply spring force based on the compression ratio * spring bounce strength (So value).
        - Compression ratio is difference of spring length and actual hit distance.
    - Uses a new ScriptableObject called VehiclePhysicsSettings:
      - Doesnt use mass or drag yet, only spring values.
  - Added test scene (VehiclePhysicsTests).
- Added triplanar checkerboard material and default material.
- Initial project setup/cleanup:
  - Scripts are either under namespace folders or utilities.
  - Removed tutorial extras and sample scene.
  - Rendering data is now under Rendering folder.
  - Camera and post processing/volume are now a prefab for reuse.
  - Added Resources folder.
  - Shaders/Materials under their own folder (Textures is under materials).
  - Added Thumbnails folder.

# Project Creation
### Repository Created July 27, 2023
- Created repository and an empty Unity project (2023.3 URP).
- Added README/Update Notes/Attributions/Ignores.