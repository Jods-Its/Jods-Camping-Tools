using Il2Cpp;
using UnityEngine;
using MelonLoader;
using ExamineActionsAPI;

namespace CampingTools
{
    internal class TanningRackActions2 : IExamineAction, IExamineActionProduceItems, IExamineActionRequireItems
    {
        public TanningRackActions2() { }
        IExamineActionPanel? IExamineAction.CustomPanel => null;

        string IExamineAction.Id => nameof(TanningRackActions2);

        string IExamineAction.MenuItemLocalizationKey => "GAMEPLAY_CT_TRackWolfS";

        string IExamineAction.MenuItemSpriteName => null;

        LocalizedString IExamineAction.ActionButtonLocalizedString { get; } = new LocalizedString() { m_LocalizationID = "GAMEPLAY_CT_TRackButton" };

        bool IExamineAction.IsActionAvailable(GearItem item)
        {
            return item.name == "GEAR_TanningRack";

        }
        void IExamineActionRequireItems.GetMaterialItems(ExamineActionState state, List<MaterialOrProductItemConf> items)
        {
            items.Add(new("GEAR_WolfPelt", 1, 100));
        }
        bool IExamineAction.CanPerform(ExamineActionState state) => true;
        void IExamineAction.OnPerforming(ExamineActionState state) { }

        int IExamineAction.GetDurationMinutes(ExamineActionState state)
        {
            return 15;
        }

        float IExamineAction.GetProgressSeconds(ExamineActionState state)
        {
            return 5;
        }
        string IExamineAction.GetAudioName(ExamineActionsAPI.ExamineActionState state) => "Play_CraftingLeatherHide";
        void IExamineAction.OnSuccess(ExamineActionState state) { }

        void IExamineAction.OnActionSelected(ExamineActionState state) { }

        void IExamineAction.OnActionDeselected(ExamineActionState state) { }

        bool IExamineAction.ShouldConsumeOnSuccess(ExamineActionState state) => true;
        int IExamineAction.GetConsumingUnits(ExamineActionState state) =>  1;

        int IExamineAction.GetSubActionCount(ExamineActionState state) => 1;
        void IExamineActionProduceItems.GetProducts(ExamineActionState state, List<MaterialOrProductItemConf> products)
        {
            products.Add(state.SubActionId switch
            {
                0 => new("GEAR_TanningRackWPS2", 1, 100)
            });
        }

        void IExamineAction.OnActionInterruptedBySystem(ExamineActionState state) { }
    }
}
