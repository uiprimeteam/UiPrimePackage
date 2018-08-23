using System;
using System.Activities;
using System.ComponentModel;
using saprotwr.net;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.GuiTab
{
  
    [Description("Sets the tab strip to select the especified tab.\nChanging the tab of a tab strip may cause server communication.")]
	public sealed class Select : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the Tab component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiTab: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiTab> GuiTab { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.TabSelect(this.Id.Get(context), (this.GuiTab.Get(context) as sapfewse.GuiTab), (this.Session.Get(context) as GuiSession));
        }
    }
}