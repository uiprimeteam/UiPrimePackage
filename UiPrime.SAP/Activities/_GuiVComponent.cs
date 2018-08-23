using System;
using System.Activities;
using System.ComponentModel;
using System.Reflection;
using SAPGui = UiPrime.SAPCore.SAPGui;
using sapfewse;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.Component
{
    [Description("Sets the focus in the specified component.\nUse this activity for all available Gui controls in SAP.")]
    public sealed class SetFocus : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiVComponent: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiVComponent> Component { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SetFocus(this.Id.Get(context), (this.Component.Get(context) as GuiVComponent), (this.Session.Get(context) as GuiSession));
        }
    }

    [Description("Sets a text value in the specified component.\nUse this activity for all available Gui controls in SAP.")]
    public sealed class SetText :  CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiVComponent: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiVComponent> Component { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The text to be inputed")]
        public InArgument<String> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SetText(this.Id.Get(context), (this.Component.Get(context) as GuiVComponent), (this.Session.Get(context) as GuiSession), this.Text.Get(context));
        }
    }

}