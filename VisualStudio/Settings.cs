using Il2Cpp;
using ModSettings;

namespace CampingTools
{
    internal class Settings : JsonModSettings
    {
        [Name("No Jeremiah's Knife")]
        [Description("Prevents Jeremiah's Knife from spawning. Warning: Can delete Jeremiah's Knife in other saves if you enter them with this option set to yes. Default = No.")]
        public bool noKnifeJ = false;
    }
}
