using Il2Cpp;
using UnityEngine;
using MelonLoader;
using ExamineActionsAPI;

namespace CampingTools
{
    internal class TanningRackActions3 : IExamineAction, IExamineActionProduceItems, IExamineActionRequireItems
    {
        public TanningRackActions3() { }
        IExamineActionPanel? IExamineAction.CustomPanel => null;

        string IExamineAction.Id => nameof(TanningRackActions3);

        string IExamineAction.MenuItemLocalizationKey => "GAMEPLAY_CT_TRackBear";

        string IExamineAction.MenuItemSpriteName => null;

        LocalizedString IExamineAction.ActionButtonLocalizedString { get; } = new LocalizedString() { m_LocalizationID = "GAMEPLAY_CT_TRackButton" };

        bool IExamineAction.IsActionAvailable(GearItem item)
        {
            return item.name == "GEAR_TanningRack";

        }
        void IExamineActionRequireItems.GetRequiredItems(ExamineActionState state, List<MaterialOrProductItemConf> items)
        {
            items.Add(new("GEAR_BearHide", 1, 100));
        }
        bool IExamineAction.CanPerform(ExamineActionState state) => true;
        void IExamineAction.OnPerform(ExamineActionState state) { }

        int IExamineAction.CalculateDurationMinutes(ExamineActionState state)
        {
            return 40;
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
        int IExamineAction.OverrideConsumingUnits(ExamineActionState state) =>  1;

        int IExamineAction.GetSubActionCount(ExamineActionState state) => 1;
        void IExamineActionProduceItems.GetProducts(ExamineActionState state, List<MaterialOrProductItemConf> products)
        {
            products.Add(state.SubActionId switch
            {
                0 => new("GEAR_TanningRackBP2", 1, 100),
            });
        }

        void IExamineAction.OnActionInterruptedBySystem(ExamineActionState state) { }
    }
}
