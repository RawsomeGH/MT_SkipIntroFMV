using BepInEx;
using HarmonyLib;
using MT_SkipIntroFMV.Config;

namespace MT_SkipIntroFMV
{
    [BepInPlugin("rawsome.modster-train.skip-intro-fmv", "Skip Intro FMV", "2.0.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    class MT_SkipIntroFMVPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            LoadConfig();

            // If disabled, don't patch at all.
            if (MT_SkipIntroFMVConfig.SkipIntroFMV.Value)
            {
                var harmony = new Harmony("rawsome.modster-train.skip-intro-fmv");
                harmony.PatchAll();
            }
        }

        void LoadConfig()
        {
            MT_SkipIntroFMVConfig.SkipIntroFMV = Config.Bind("General", "Enabled", true, $"Whether intro FMV should be skipped ('true' to skip, otherwise 'false')");
        }
    }
}
