using System;
using System.Activities;
using System.ComponentModel;
using saprotwr.net;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
namespace UiPrime.SAP.Visual_Objects.GuiMenu
{
    [Description("Selects a menu in the SAPGui")]
    public sealed class Select : CodeActivity
	{	
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the Menu component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [Description("GuiMenu: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiMenu> GuiMenu { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.MenuSelect(this.Id.Get(context), (this.GuiMenu.Get(context) as sapfewse.GuiMenu), (this.Session.Get(context) as GuiSession));
        }
    }
}