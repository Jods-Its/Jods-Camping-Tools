using Il2Cpp;
using ModSettings;

namespace CampingTools
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();
        [Section("Spawn Manager")]

        [Name("Disable Jeremiah's Knife")]
        [Description("Prevents Jeremiah's Knife from spawning. Needs game restart. Default = No.")]
        public bool noKnifeJ = false;

        [Name("Disable Scrap Metal Shard")]
        [Description("Prevents natural ocurring scrap metal shards from spawning. This does not disable its crafting recipe. Needs game restart. Default = No.")]
        public bool noKnifeS = false;

        [Name("Disable Survival Books")]
        [Description("Prevents Survival 101 books from spawning. Needs game restart. Default = No.")]
        public bool noBooks = false;

        [Name("Disable Maps")]
        [Description("Prevents region maps from spawning. Needs game restart. Default = No.")]
        public bool noMaps = false;

        [Name("Disable Lighter")]
        [Description("Prevents lighters from spawning. Needs game restart. Default = No.")]
        public bool noLighter = false;

        [Name("Disable Ranger Satchel")]
        [Description("Prevents ranger satchels from spawning. Needs game restart. Default = No.")]
        public bool noSatchel = false;
    }
}
