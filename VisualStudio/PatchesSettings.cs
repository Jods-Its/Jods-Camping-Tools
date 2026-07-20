using MelonLoader;
using Il2Cpp;
using Il2CppTLD.Gear;
using HarmonyLib;
using MelonLoader;

namespace CampingTools
{
    internal class PatchesSettings
    {
        [HarmonyPatch] // ModComponent patch of gear spawns
        class ManageSpawnsGreenery
        {
            public static System.Reflection.MethodBase TargetMethod()
            {
                var type = AccessTools.TypeByName("ModComponent.Mapper.ZipFileLoader");
                return AccessTools.FirstMethod(type, method => method.Name.Contains("TryHandleTxt"));
            }
            public static bool Prefix(string zipFilePath, string internalPath, ref string text, ref bool __result)
            {
                if (zipFilePath.EndsWith("CampingTools.modcomponent"))
                {
                    string fileName = internalPath.Replace("gear-spawns/", "").Replace(".txt", "");

                    if (Settings.instance.noBooks && fileName == "Books")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noKnifeJ && fileName == "JKnife")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noMaps && fileName == "Maps")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noLighter && fileName == "MetalLighter")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noSatchel && fileName == "RangerSatchel")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }

                    if (Settings.instance.noKnifeS && fileName == "SKnife")
                    {
                        MelonLogger.Msg(ConsoleColor.DarkYellow, "Skipping based on settings: " + fileName);
                        text = "";
                    }
                }

                return true;
            }
        }
    }
}
