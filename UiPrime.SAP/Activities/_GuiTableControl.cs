using System;
using System.Activities;
using System.ComponentModel;
using System.Collections.Generic;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.GuiTableControl
{

    [Description("Returns the column index based on internal SAP column name.")]
    public sealed class FindColumnIndex : CodeActivity<int>
    {
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the table control component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiTableControl: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiTableControl> GuiTableControl { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<String> SAPColumnName { get; set; }

        protected override int Execute(CodeActivityContext context)
        {
            return SAPGui.FindColumnIndex(this.Id.Get(context), (this.GuiTableControl.Get(context) as sapfewse.GuiTableControl), (this.Session.Get(context) as GuiSession),this.SAPColumnName.Get(context));
        }
    }

    [Description("Returns the column index based on column visual title.")]
    public sealed class FindColumnIndexByName : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the table control component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiTableControl: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiTableControl> GuiTableControl { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Visual column title.")]
        public InArgument<String> ColumnTitle { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("int[]: An array of possible indexes of the column.")]
        public OutArgument<int[]> Output { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {		
			this.Output.Set(context,SAPGui.FindColumnIndexByName(this.Id.Get(context),(this.GuiTableControl.Get(context) as sapfewse.GuiTableControl), (this.Session.Get(context) as GuiSession), this.ColumnTitle.Get(context)));
        }
    }

    [Description("Perform a visual scroll down of all rows in a column.\nWhen a blank cell value is found it will return the current row count.\nInternal SAP column name is required.")]
    public sealed class ScrollDownAndCountRows : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the table control component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiTableControl: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiTableControl> GuiTableControl { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<String> SAPColumnName { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("int: The number of rows counted that have cells with values.")]
        public OutArgument<int> Output { get; set; }

        protected override void Execute(CodeActivityContext context)
        {		
			this.Output.Set(context,SAPGui.RowsCountBasedOnEmptyField(this.Id.Get(context),(this.GuiTableControl.Get(context) as sapfewse.GuiTableControl), this.Session.Get(context), this.Id.Get(context),this.SAPColumnName.Get(context)));
        }
    }

    [Description("Visualy scrolls the table control to a specific row index.\n(Data can be retrieved from a cell only when the cell row is visible.)")]
    public sealed class MoveScroll : CodeActivity
	{
        [OverloadGroup("ComponentId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the table control component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("ComponentObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiTableControl: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiTableControl> GuiTableControl { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("int: The row index where the table will be scrolled to.")]
        public InArgument<int> Position { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("GuiTableControl: The updated TableControl object. The id might be changed with the scroll.")]
        public OutArgument<sapfewse.GuiTableControl> Output { get; set; }

        protected override void Execute(CodeActivityContext context)
        {		
			this.Output.Set(context,SAPGui.MoveScroll(this.Id.Get(context),(this.GuiTableControl.Get(context) as sapfewse.GuiTableControl),(this.Session.Get(context) as GuiSession),this.Position.Get(context)));
        }
    }
		
	
}