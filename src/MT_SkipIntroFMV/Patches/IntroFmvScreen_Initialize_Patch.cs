using HarmonyLib;

namespace MT_SkipIntroFMV.Patches
{
    /// <summary>
    /// Patches IntroFmvScreen.Initialize to not play the video (namespace: - [in Assembly-Csharp.dll])
    /// </summary>
    [HarmonyPatch(typeof(IntroFmvScreen), "Initialize")]
    class IntroFmvSkip
    {
        static bool Prefix(IntroFmvScreen __instance, SaveManager ___saveManager, GameStateManager ___gameStateManager)
        {
            if (___saveManager.GetHasSeenFtueScenario())
            {
                // _videoPlayer needs to be initialized for EndReached
                var videoPlayerField = AccessTools.Field(typeof(IntroFmvScreen), "_videoPlayer");

                videoPlayerField
                    .SetValue(__instance, __instance.gameObject.AddComponent<ShinyShoe.VideoPlayerUnity>());

                AccessTools.Method(typeof(IntroFmvScreen), "EndReached")
                    .Invoke(__instance, new object[] { null });
            }
            else if (___gameStateManager != null)
            {
                // If player has not seen Ftue, start a new run once GameStateManager has been injected
                ___gameStateManager.StartNewRun(RunType.Class, string.Empty, null, true);
            }
            
            // Prevent actual Initialize from happening
            return false;
        }
    }
}
