using System;
using System.Activities;
using System.ComponentModel;
using saprotwr.net;
using sapfewse;
using UiPrime.SAPCore;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Administrative_Objects
{
    [Description("Closes a transaction in the SAP session.\nHas the same effect as 'SendCommand = /n'")]
    public sealed class EndTransaction : CodeActivity
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

            session.EndTransaction();
        }
    }

    [Description("Opens a Transaction in the SAP session given a transaction code.")]
    public sealed class AccessSAPTransaction : CodeActivity
    {
        [OverloadGroup("SessionId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the session.")]
        public InArgument<string> SessionId { get; set; }

        [OverloadGroup("SessionObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiSession: If the property ID is not provided, inform here the object for the active session.")]
        public InArgument<GuiSession> GuiSession { get; set; }

        [RequiredArgument]
        [Category("Input")]
        [Description("string: The transaction id or code")]
        public InArgument<string> TransactionID { get; set; }

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

            try
            {
                SAPGui.AccessTransactionByID(session, this.TransactionID.Get(context));
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Not able to access SAP transaction: {0}.", e.Message));
            }
        }
    }

    [Description("Inputs the SAP connection information in the SAPGui application.\nSAPGui must be executing in order to work.")]
    public sealed class CreateConnection : CodeActivity
    {
        [RequiredArgument, Category("Input")]
        [Description("string: The exact name of the SAP server/connection to be used")]
        public InArgument<String> Description { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The username of the credentials")]
        public InArgument<String> User { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The password of the credentials")]
        [PasswordPropertyText]
        public InArgument<String> Password { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The language code to be used")]
        public InArgument<String> Language { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("GuiConnection: The resulting SAP connection object")]
        public OutArgument<GuiConnection> Connection { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            this.Connection.Set(context, SAPGui.CreateConnection(this.Description.Get(context), this.User.Get(context), this.Password.Get(context), this.Language.Get(context)));
        }
    }
}
