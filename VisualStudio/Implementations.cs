using CampingTools;
using CampingTools.TanningRackActions;
using MelonLoader;

namespace ModNamespace;
internal sealed class Implementations : MelonMod
{
	internal static Implementations Instance { get; private set; }
	public override void OnInitializeMelon()
	{
		Instance = this;
        ExamineActionsAPI.ExamineActionsAPI.Register(new TanningRackActions1());
        ExamineActionsAPI.ExamineActionsAPI.Register(new TanningRackActions2());
        ExamineActionsAPI.ExamineActionsAPI.Register(new TanningRackActions3());
        ExamineActionsAPI.ExamineActionsAPI.Register(new TanningRackActions4());
        MelonLoader.MelonLogger.Msg("Camping Tools Loaded!");
	}
}
