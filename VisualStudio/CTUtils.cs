using Il2Cpp;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Il2CppRewired;


namespace CampingTools
{
    internal static class CTUtils
    {
        public static Panel_Map map;
        public static Panel_Inventory inventory;

        public static GearItem map1 = Addressables.LoadAssetAsync<GameObject>("GEAR_MapMLDeco").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem map2 = Addressables.LoadAssetAsync<GameObject>("GEAR_MapPVDeco").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem map3 = Addressables.LoadAssetAsync<GameObject>("GEAR_MapMTDeco").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem map4 = Addressables.LoadAssetAsync<GameObject>("GEAR_MapCHDeco").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem map5 = Addressables.LoadAssetAsync<GameObject>("GEAR_MapBIDeco").WaitForCompletion().GetComponent<GearItem>();
        public static T? GetComponentSafe<T>(this Component? component) where T : Component
        {
            return component == null ? default : GetComponentSafe<T>(component.GetGameObject());
        }
        public static T? GetComponentSafe<T>(this GameObject? gameObject) where T : Component
        {
            return gameObject == null ? default : gameObject.GetComponent<T>();
        }
        public static T? GetOrCreateComponent<T>(this Component? component) where T : Component
        {
            return component == null ? default : GetOrCreateComponent<T>(component.GetGameObject());
        }
        public static T? GetOrCreateComponent<T>(this GameObject? gameObject) where T : Component
        {
            if (gameObject == null)
            {
                return default;
            }

            T? result = GetComponentSafe<T>(gameObject);

            if (result == null)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
        internal static GameObject? GetGameObject(this Component? component)
        {
            try
            {
                return component == null ? default : component.gameObject;
            }
            catch (System.Exception exception)
            {
                MelonLoader.MelonLogger.Msg($"Returning null since this could not obtain a Game Object from the component. Stack trace:\n{exception.Message}");
            }
            return null;
        }
        public static GameObject GetPlayer()
        {
            return GameManager.GetPlayerObject();
        }
        public static bool IsMap(string gearItemName)
        {
            string[] maps = { "GEAR_MapBI", "GEAR_MapCH", "GEAR_MapMT", "GEAR_MapPV", "GEAR_MapML" };
            for (int i = 0; i < maps.Length; i++)
            {
                if (gearItemName == maps[i]) return true;
            }
            return false;
        }
        public static void MapErrorMsg(string region)
        {
            string[] regions = { "LakeRegion", "RuralRegion", "MountainTownRegion", "CanneryRegion", "CoastalRegion", "CrashMountainRegion", "RiverValleyRegion", "MarshRegion", "TracksRegion", "BlackrockRegion", "AshCanyonRegion", "WhalingStationRegion", "HubRegion", "AirfieldRegion" };
            for (int i = 0; i < regions.Length; i++)
            {
                if (regions[i] == region)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_CT_RegionError"));
                    return;
                }
            }
            HUDMessage.AddMessage(Localization.Get("GAMEPLAY_CT_InteriorError"));
        }
    }
}
