using System.Activities;
using System.ComponentModel;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.GuiComboBox
{
    [Description("Emulates the Combobox press action")]
    public sealed class Press : CodeActivity
    {
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the combo component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiComboBox: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiComboBox> GuiComboBox { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SetKeySpace(this.Id.Get(context), (this.GuiComboBox.Get(context) as sapfewse.GuiComboBox), (this.Session.Get(context) as GuiSession));
        }
    }
}
