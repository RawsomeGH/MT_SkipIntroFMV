# MT_SkipIntroFMV
Monster Train Patch that skips the intro FMV

## Installing the plugin
Set up BepInEx for Monster Train as explained in [BepInex docs](https://bepinex.github.io/bepinex_docs/v5.0/articles/user_guide/installation.html).

Put MT_SkipIntroFMV.dll into `BepInEx\plugins`.

## Configuring the plugin
This plugin will create the config file `rawsome.modster-train.skip-intro-fmv.cfg` in `Bepinex\config` once you start the game after installing the plugin.

You can use it to activate/deactivate the FMV skip without removing the plugin.

## Notice regarding referenced libraries
In order to avoid distributing DLLs I shouldn't distribute, referenced DLLs in the lib folder are not checked into source.

If you want to modify this patch, you will need to find the following DLLs and put them there yourself:

* 0Harmony.dll
* Assembly-Csharp.dll
* BepInEx.dll
* UnityEngine.CoreModule.dll
* UnityEngine.dll

You can find all these files in either the BepInEx release you downloaded for the setup or Monster Train's MonsterTrain_Data folder.
