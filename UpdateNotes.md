This is an overview of the project's entire development.

## Version 0.1.2
- Added some standard classes from UnityUtilities repository to Utilities.

## Version 0.1.1
### Published on July 27, 2023.
![]("/Thumbnails/v0-1-1-physics-tests.png)
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
### Project created on July 27, 2023.
- Created repository and an empty Unity project (2023.3 URP).
- Added README/Update Notes/Attributions/Ignores.