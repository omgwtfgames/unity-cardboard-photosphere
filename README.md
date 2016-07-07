# Unity Google VR / Cardboard photosphere example

A simple Unity project template for viewing photospheres / 360-degree photos using Google VR (aka Cardboard) devices.

There are three methods demonstrated here:

  1. Use of a double sided unlit shader so that both sides of the sphere are visible.

  2. Use of a sphere mesh with the normals flipped so that the mesh is visible from inside the sphere.

  3. Use a standard Unity skybox with the photo imported as a "Latitude-Longitude Layout (Cylindrical)" mapped texture.

## Getting started

Download and import the [Unity package of this project](https://github.com/omgwtfgames/unity-cardboard-photosphere/raw/master/unity-cardboard-photosphere.unitypackage), or clone this git repo.

The [Google VR plugin for Unity](https://github.com/googlevr/gvr-unity-sdk) (v0.8.5) is included - if you want to update to different version, delete the `GoogleVR` and `Plugins` folders and import the new version.

The default Unity Sphere primitive is UV mapped with an equirectangular projection, so most common photospheres should work. When adding your own photosphere textures, make sure you set the import size of the image as high as possible (8192). Ensure that the Tiling X value is -1 on the Material, otherwise your image will be a horizontal mirror image.

There are also some examples of stereo 3D photospheres (eg two spheres, use Layers so left/right cameras only see one sphere).

## Some details

The Gvr prefabs used in these scenes have some small changes to the default settings:

  * On GvrHead, Track Position is turned off (we only want rotation)
  * On StereoController, we reduce Stereo Multiplier to zero (this makes both eyes see the same image for monoscopic photos, and for stereoscopic photos we don't want any eye separation in Unity's 3D space since the left and right image already have a stereo offset).
  * The Camera Far Clipping Plane is set to 1000, and the Sphere has a radius of 999 - this means that the inside of the sphere will be distant, so even if Stereo Multiplier is non-zero there should be no detectable stereo parallax.
  * A custom version of GvrEye.cs is included which allows a different skybox to be assigned to each eye.

## Changelog

**7-May-2016** - Updated to use Google VR plugin (v0.8.5), added stereo examples.

**3-Dec-2015** - Bugfix - material tiling x = -1 to prevent horizontal mirror image (thanks [/u/redskins78](https://www.reddit.com/user/redskins78) !)

**28-Nov-2015** - initial release, added skybox method (thanks [/u/cjdavies](https://www.reddit.com/user/cjdavies) !)

## License

The code is provided under the Apache License, Version 2.0.

The "Double Arch Photosphere" by Mark Doliner (https://www.flickr.com/photos/markdoliner/14094296347) is under a Creative Commons Attribution 2.0 Generic License [CC BY 2.0](https://creativecommons.org/licenses/by/2.0/).

The `LyonvilleSpring__AndrewPerry__PublicDomain` image is provided under a [CC0 license](https://creativecommons.org/publicdomain/zero/1.0/), and is dedicated to the public domain.
