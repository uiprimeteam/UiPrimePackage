using System;
using System.Activities;
using System.ComponentModel;
using SAPGui = UiPrime.SAPCore.SAPGui;
using sapfewse;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Container_Objects.GuiFrameWindow
{
    [Description("Emulates sending a virtual key to the window. The Vkeys are defined in the menu painter.")]
    public sealed class SendVKey : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the FrameWindow component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiFrameWindow: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiFrameWindow> GuiFrameWindow { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("Int: The vkey code")]
        public InArgument<int> Key { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SendVKey(this.Id.Get(context), (this.GuiFrameWindow.Get(context) as sapfewse.GuiFrameWindow), (this.Session.Get(context) as GuiSession), this.Key.Get(context));
        }
    }

    [Description("Maximizes the SAPGui window")]
	public sealed class Maximize : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the FrameWindow component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiFrameWindow: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiFrameWindow> GuiFrameWindow { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.Maximize(this.Id.Get(context), (this.GuiFrameWindow.Get(context) as sapfewse.GuiFrameWindow), (this.Session.Get(context) as GuiSession));
        }
    }
}