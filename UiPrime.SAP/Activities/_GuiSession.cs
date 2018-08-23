using System;
using System.Activities;
using System.ComponentModel;
using sapfewse;
using UiPrime.SAPCore;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Administrative_Objects
{
    [Description("Returns a GuiSession object for the oldest running SAP Session")]
    public sealed class GetCurrentSession : CodeActivity
    {
        [RequiredArgument]
        [Category("Output")]
        [Description("GuiSession: the resulting SAP Session")]
        public OutArgument<GuiSession> Output { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                this.Output.Set(context, SAPGui.GetCurrentSession());
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to get the current SAP session: {0}.", e.Message));
            }
        }
    }

    [Description("Emulates the 'New Session' button in SAP.\n(The SAP system might now allow for new sessions if session limit is reached)")]
    public sealed class CreateNewSession : CodeActivity
    {

        [Category("Input")]
        [Description("GuiSession: current active SAP session object")]
        public InArgument<GuiSession> CurrentSession { get; set; }

        [RequiredArgument]
        [Category("Output")]
        [Description("GuiSession> the new SAP session created")]
        public OutArgument<GuiSession> Output { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                this.Output.Set(context, SAPGui.NewSession(this.CurrentSession.Get(context)));
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to create new SAP session: {0}.", e.Message));
            }
        }
    }

    [Description("Closes an active SAP session.")]
    public sealed class CloseSession : CodeActivity
    {

        [RequiredArgument]
        [Category("Input")]
        [Description("GuiSession: object for the current active session")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                SAPGui.DestroySession(this.Session.Get(context));
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to close SAP session: {0}.", e.Message));
            }
        }
    }

    [Description("Closes all SAP sessions except one.\nThe oldest session is kept alive.")]
    public sealed class KeepOneSession : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                SAPGui.KeepOneSessionSAP();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to close SAP session: {0}.", e.Message));
            }
        }
    }

    [Description("Returns a GuiSesion object for a specified session Id.\nUse this activity to send sessions across isolated invokes.")]
    public sealed class GetSessionById : CodeActivity
    {

        [RequiredArgument]
        [Category("Input")]
        [Description("string: The unique SAP session id")]
        public InArgument<string> Id { get; set; }

        [RequiredArgument]
        [Category("Output")]
        [Description("GuiSession: The session object for the specified id")]
        public OutArgument<GuiSession> GuiSessionOutput { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                this.GuiSessionOutput.Set(context, SAPGui.GetObjSessionById(this.Id.Get(context)));
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to find session: {0}.", e.Message));
            }
        }
    }

    [Description("Inputs and executes a command string in the top menu command box of the SAP session.")]
    public sealed class SendCommand : CodeActivity
    {
        [OverloadGroup("SessionId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the session.")]
        public InArgument<string> SessionId { get; set; }

        [OverloadGroup("SessionObject")]
        [RequiredArgument,Category("Target")]
        [Description("GuiSession: If the property ID is not provided, inform here the object for the active session.")]
        public InArgument<GuiSession> GuiSession { get; set; }

        [RequiredArgument,Category("Input")]
        [Description("string: The string command to be executed")]
        public InArgument<string> Command { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            sapfewse.GuiSession session = this.GuiSession.Get(context);
            if (session == null)
            {
                try
                {
                    session = SAPGui.GetObjSessionById(this.SessionId.Get(context));

                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Not able to find session: {0}.", e.Message));
                }
            }            

            session.SendCommand(this.Command.Get(context));
        }
    }

    [Description("Locks the session's User Interface not allowing for mouse/keyboard interaction.")]
    public sealed class LockSessionUI : CodeActivity
    {
        [OverloadGroup("SessionId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the session.")]
        public InArgument<string> SessionId { get; set; }

        [OverloadGroup("SessionObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiSession: If the property ID is not provided, inform here the object for the active session.")]
        public InArgument<GuiSession> GuiSession { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            sapfewse.GuiSession session = this.GuiSession.Get(context);
            if (session == null)
            {
                try
                {
                    session = SAPGui.GetObjSessionById(this.SessionId.Get(context));

                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Not able to find session: {0}.", e.Message));
                }
            }

            session.LockSessionUI();
        }
    }

    [Description("Unlocks the session's User Interface allowing for mouse/keyboard interaction.")]
    public sealed class UnLockSessionUI : CodeActivity
    {
        [OverloadGroup("SessionId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the session.")]
        public InArgument<string> SessionId { get; set; }

        [OverloadGroup("SessionObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiSession: If the property ID is not provided, inform here the object for the active session.")]
        public InArgument<GuiSession> GuiSession { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            sapfewse.GuiSession session = this.GuiSession.Get(context);
            if (session == null)
            {
                try
                {
                    session = SAPGui.GetObjSessionById(this.SessionId.Get(context));

                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Not able to find session: {0}.", e.Message));
                }
            }

            session.UnlockSessionUI();
        }
    }
}
