using System.Activities;
using System.ComponentModel;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.GuiButton
{
  
    [Description("Emulates the Button press")]
	public sealed class Press : CodeActivity
	{	
        [OverloadGroup("ButtonId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the button component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ButtonObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiButton: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiButton> GuiButton { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.Press(this.Id.Get(context), (this.GuiButton.Get(context) as sapfewse.GuiButton), (this.Session.Get(context) as GuiSession));
        }
    }
}