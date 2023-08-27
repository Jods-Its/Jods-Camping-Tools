using Il2Cpp;
using UnityEngine;
using MelonLoader;
using ExamineActionsAPI;

namespace CampingTools.TanningRackActions
{
    internal class TanningRackActions1 : IExamineAction, IExamineActionProduceItems, IExamineActionRequireItems
    {
        public TanningRackActions1() { }
        IExamineActionPanel? IExamineAction.CustomPanel => null;

        string IExamineAction.Id => nameof(TanningRackActions1);

        string IExamineAction.MenuItemLocalizationKey => "GAMEPLAY_CT_TRackDeerS";

        string IExamineAction.MenuItemSpriteName => null;

        LocalizedString IExamineAction.ActionButtonLocalizedString { get; } = new LocalizedString() { m_LocalizationID = "GAMEPLAY_CT_TRackButton" };

        bool IExamineAction.IsActionAvailable(GearItem item)
        {
            return item.name == "GEAR_TanningRack";

        }
        void IExamineActionRequireItems.GetRequiredItems(ExamineActionState state, List<MaterialOrProductItemConf> items)
        {
            items.Add(new("GEAR_LeatherHide", 1, 100));
        }
        bool IExamineAction.CanPerform(ExamineActionState state) => true;
        void IExamineAction.OnPerform(ExamineActionState state) { }

        int IExamineAction.CalculateDurationMinutes(ExamineActionState state)
        {
            return 15;
        }

        float IExamineAction.CalculateProgressSeconds(ExamineActionState state)
        {
            return 5;
        }
        string IExamineAction.GetAudioName(ExamineActionsAPI.ExamineActionState state) => "Play_CraftingLeatherHide";
        void IExamineAction.OnSuccess(ExamineActionState state) { }

        void IExamineAction.OnActionSelected(ExamineActionState state) { }

        void IExamineAction.OnActionDeselected(ExamineActionState state) { }

        bool IExamineAction.ConsumeOnSuccess(ExamineActionState state) => true;

        int IExamineAction.GetSubActionCount(ExamineActionState state) => 1;
        void IExamineActionProduceItems.GetProducts(ExamineActionState state, List<MaterialOrProductItemConf> products)
        {
            products.Add(state.SubActionId switch
            {
                0 => new("GEAR_TanningRackDPS2", 1, 100),
            });
        }

        void IExamineAction.OnActionInterruptedBySystem(ExamineActionState state) { }

    }
}
