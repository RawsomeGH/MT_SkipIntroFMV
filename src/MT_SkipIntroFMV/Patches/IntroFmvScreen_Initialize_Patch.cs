using HarmonyLib;

namespace MT_SkipIntroFMV.Patches
{
    /// <summary>
    /// Patches IntroFmvScreen.Initialize to not play the video (namespace: - [in Assembly-Csharp.dll])
    /// </summary>
    [HarmonyPatch(typeof(IntroFmvScreen), "Initialize")]
    static class IntroFmvScreen_Initialize_Patch
    {
        static bool Prefix(ref IntroFmvScreen __instance)
        {
            // Before Initialize is executed, invoke the method that would be called once playback has ended.
            __instance.Invoke("GoToNextScreen", 0);

            // Return false to prevent the original Initialize method from being executed.
            return false;
        }
    }
}
