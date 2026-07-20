using Il2Cpp;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CampingTools
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Panel_Inventory), nameof(Panel_Inventory.Initialize))]
        internal class CTInitialization
        {
            private static void Postfix(Panel_Inventory __instance)
            {
                CTUtils.inventory = __instance;
                CTButtons.InitializeCT(__instance.m_ItemDescriptionPage);
            }
        }

        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdateMapSurveyButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;
                CTButtons.map = gi?.GetComponent<GearItem>();
                if (gi != null && CTUtils.IsMap(gi.name) == true)
                {
                    CTButtons.SetMapSurveyActive(true);
                }
                else
                {
                    CTButtons.SetMapSurveyActive(false);
                }
            }
        }

        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdatePlaceTRButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;
                CTButtons.TRItem = gi?.GetComponent<GearItem>();
                if (gi != null && gi.name.ToLowerInvariant().Contains("tanningrack"))
                {
                    CTButtons.SetPlaceTRActive(true);
                }
                else
                {
                    CTButtons.SetPlaceTRActive(false);
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Map), nameof(Panel_Map.Initialize))]
        internal class GetMapPanel
        {
            private static void Postfix(Panel_Map __instance)
            {
               CTUtils.map = __instance;
            }
        }

        [HarmonyPatch(typeof(Bed), nameof(Bed.GetWarmthBonusCelsius))]
        internal class UpdateCollisionsOnInteract
        {
            private static void Postfix(Bed __instance)
            {
                if (__instance.m_Bedroll ==  null) return;
                if (__instance != null && __instance.m_Bedroll.name.ToLowerInvariant().Contains("tent"))
                {
                    if (__instance.m_Bedroll.name.ToLowerInvariant() == "gear_tent")
                    {
                        GameObject collisionsParent = __instance.gameObject.transform.FindChild("Tent/Collisions").gameObject;

                        for (int i = 0; i <= 3; i++)
                        {
                            collisionsParent.transform.GetChild(i).gameObject.layer = 9;
                        }
                    }
                    else
                    {
                        GameObject collisionsParent = __instance.gameObject.transform.FindChild("TentUsed/Collisions").gameObject;

                        for (int i = 0; i <= 1; i++)
                        {
                            collisionsParent.transform.GetChild(i).gameObject.layer = 9;
                        }
                    }
                    
                }
            }
        }
    }
}
/*
[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
private static class DoThingsToJeremiahKnife
{
   private static void Postfix(GearItem __instance)
   {
       if (__instance != null && __instance.name == "GEAR_JeremiahKnife")
       {
           __instance.m_CanOpeningItem = CTUtils.GetOrCreateComponent<CanOpeningItem>(__instance.gameObject);

           __instance.m_CanOpeningItem.m_CanOpeningAudio = "Play_EatingSmashCan";
           __instance.m_CanOpeningItem.m_CanOpeningLengthSeconds = 4;
           __instance.m_CanOpeningItem.m_Type = CanOpeningItem.CanOpeningType.Knife;
       }
   }
}
[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
private static class AddOpenerToKnifeScrapMetal
{
   private static void Postfix(GearItem __instance)
   {
       if (__instance != null && __instance.name == "GEAR_KnifeScrapMetal")
       {
           __instance.m_CanOpeningItem = CTUtils.GetOrCreateComponent<CanOpeningItem>(__instance.gameObject);

           __instance.m_CanOpeningItem.m_CanOpeningAudio = "Play_EatingSmashCan";
           __instance.m_CanOpeningItem.m_CanOpeningLengthSeconds = 10;
           __instance.m_CanOpeningItem.m_Type = CanOpeningItem.CanOpeningType.KnifeImprovised;
       }
   }
}*/
/*[HarmonyPatch(typeof(Panel_CanOpening), nameof(Panel_CanOpening.SetupScrollList))]
internal static class SetupScrollList
{
    internal static void Prefix(Panel_CanOpening __instance)
    {
        List<GameObject> list = new List<GameObject>(__instance.m_UsableTools);
        bool addTool = true;
        foreach (GameObject go in list)
        {
            if (go != null && go.name == "GEAR_JeremiahKnife")
            {
                addTool = false;
            }
        }
        GearItem knifej = GameManager.GetInventoryComponent().GetHighestConditionGearThatMatchesName("GEAR_JeremiahKnife");
        if (addTool && knifej && knifej.m_CanOpeningItem)
        {
            list.Add(knifej.gameObject);
        }
        __instance.m_UsableTools = list.ToArray();
    }
}
*/
