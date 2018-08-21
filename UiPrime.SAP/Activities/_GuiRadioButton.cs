using System.Activities;
using System.ComponentModel;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
namespace UiPrime.SAP.Visual_Objects.GuiRadioButton
{

    [Description("Emulates selecting a radio button option")]
    public sealed class Select : CodeActivity
    {
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the RadioButton component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiRadioButton: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiRadioButton> GuiRadioButton { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.RadioButtonSelect(this.Id.Get(context), (this.GuiRadioButton.Get(context) as sapfewse.GuiRadioButton), (this.Session.Get(context) as GuiSession));
        }
    }
}