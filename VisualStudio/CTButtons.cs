using Il2Cpp;
using Il2CppProCore.Decals;
using Il2CppRewired;
using Il2CppTLD.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CampingTools
{
    internal class CTButtons
    {
        internal static string mapText;
        private static GameObject mapButton;
        internal static GearItem map;
        internal static string mapName;
        internal static string regionName;

        internal static string placeTRText;
        private static GameObject placeTRButton;
        internal static GearItem TRItem;

        internal static void InitializeCT(ItemDescriptionPage itemDescriptionPage)
        {
            mapText = Localization.Get("GAMEPLAY_CT_MapLabel");
            placeTRText = Localization.Get("GAMEPLAY_CT_PlaceLabel");

            GameObject equipButton = itemDescriptionPage.m_MouseButtonEquip;
            mapButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            Utils.GetComponentInChildren<UILabel>(mapButton).text = mapText;

            placeTRButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            Utils.GetComponentInChildren<UILabel>(placeTRButton).text = placeTRText;

            AddAction(mapButton, new System.Action(OnMapSurvey));
            AddAction(placeTRButton, new System.Action(OnPlaceTR));

            SetMapSurveyActive(false);
            SetPlaceTRActive(false);
        }
        private static void AddAction(GameObject button, System.Action action)
        {
            Il2CppSystem.Collections.Generic.List<EventDelegate> placeHolderList = new Il2CppSystem.Collections.Generic.List<EventDelegate>();
            placeHolderList.Add(new EventDelegate(action));
            Utils.GetComponentInChildren<UIButton>(button).onClick = placeHolderList;
        }
        internal static void SetMapSurveyActive(bool active)
        {
            NGUITools.SetActive(mapButton, active);
        }
        internal static void SetPlaceTRActive(bool active)
        {
            NGUITools.SetActive(placeTRButton, active);
        }
        private static void OnMapSurvey()
        {
            var thisGearItem = CTButtons.map;
            mapName = thisGearItem.name;
            regionName= GameManager.m_ActiveScene;


            if (thisGearItem == null) return;
            if (mapName == "GEAR_MapML" && regionName == "LakeRegion")
            {
                GameAudioManager.PlayGuiConfirm();
                uConsole.RunCommand("map_reveal");
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_CT_MapProgressBar"), 10f, 0f, 0f,
                                "PLAY_MAPCHARCOALWRITING", null, false, true, new System.Action<bool, bool, float>(OnMapSurveyFinished));
                GameManager.Destroy(thisGearItem);
            }
            else if (mapName == "GEAR_MapBI" && regionName == "CanneryRegion")
            {
                GameAudioManager.PlayGuiConfirm();
                uConsole.RunCommand("map_reveal");
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_CT_MapProgressBar"), 10f, 0f, 0f,
                                "PLAY_MAPCHARCOALWRITING", null, false, true, new System.Action<bool, bool, float>(OnMapSurveyFinished));
                GameManager.Destroy(thisGearItem);
            }
            else if (mapName == "GEAR_MapCH" && regionName == "CoastalRegion")
            {
                GameAudioManager.PlayGuiConfirm();
                uConsole.RunCommand("map_reveal");
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_CT_MapProgressBar"), 10f, 0f, 0f,
                                "PLAY_MAPCHARCOALWRITING", null, false, true, new System.Action<bool, bool, float>(OnMapSurveyFinished));
                GameManager.Destroy(thisGearItem);
            }
            else if (mapName == "GEAR_MapMT" && regionName == "MountainTownRegion")
            {
                GameAudioManager.PlayGuiConfirm();
                uConsole.RunCommand("map_reveal");
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_CT_MapProgressBar"), 10f, 0f, 0f,
                                "PLAY_MAPCHARCOALWRITING", null, false, true, new System.Action<bool, bool, float>(OnMapSurveyFinished));
                GameManager.Destroy(thisGearItem);
            }
            else if (mapName == "GEAR_MapPV" && regionName == "RuralRegion")
            {
                GameAudioManager.PlayGuiConfirm();
                uConsole.RunCommand("map_reveal");
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_CT_MapProgressBar"), 10f, 0f, 0f,
                                "PLAY_MAPCHARCOALWRITING", null, false, true, new System.Action<bool, bool, float>(OnMapSurveyFinished));
                GameManager.Destroy(thisGearItem);
            }
            else
            {
                CTUtils.MapErrorMsg(regionName);
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnMapSurveyFinished(bool success, bool playerCancel, float progress)
        {
            if (mapName == "GEAR_MapML")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(CTUtils.map1, 1);
            }
            else if (mapName == "GEAR_MapBI")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(CTUtils.map5, 1);
            }
            else if (mapName == "GEAR_MapCH")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(CTUtils.map4, 1);
            }
            else if (mapName == "GEAR_MapMT")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(CTUtils.map3, 1);
            }
            else if (mapName == "GEAR_MapPV")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(CTUtils.map2, 1);
            }
            GameObject player = CTUtils.GetPlayer();
            CTUtils.inventory.OnBack();
            CTUtils.map.Enable(true);
            if (player != null)
            {
                GameAudioManager.PlaySound("PLAY_MUSICMOOD_VISTA", player);
            }


        }

        private static void OnPlaceTR()
        {
            var toDrop = TRItem?.m_StackableItem?.m_UnitsPerItem ?? 1;
            toDrop = Mathf.Clamp(toDrop, 0, TRItem?.m_StackableItem?.m_Units ?? 1);
            var dropped = TRItem.Drop(toDrop);
            CTUtils.inventory.OnBack();
            dropped.PerformAlternativeInteraction();
        }
    }
}
