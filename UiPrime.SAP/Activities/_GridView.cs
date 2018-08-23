using System;
using System.Activities;
using System.ComponentModel;
using sapfewse;
using SAPGui = UiPrime.SAPCore.SAPGui;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.GuiGridView
{
    [Description("Deselect all selected columns, rows or cells in the grid view.")]
    public sealed class ClearSelection : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.ClearSelection(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession));
        }
    }

    [Description("Performs a double click in a specific cell.")]
    public sealed class CellDoubleClick : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("int: Row index of the cell")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.DoubleClick(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context));
        }
    }

    [Description("Performs a single click in a specific cell.")]
    public sealed class CellClick : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Inp ut")]
        [Description("int: Row index of the cell")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.Click(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context));
        }
    }

    [Description("Selects an item from an expanded control's context menu.")]
    public sealed class SelectContextMenuItem : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("SAP function code or key")]
        public InArgument<string> FunctionCode { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SelectContextMenuItem(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.FunctionCode.Get(context));
        }
    }

    [Description("Emulates opening the context menu of the grid view's toolbar.")]
    public sealed class PressToolbarContextButton : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The SAP unique id for the Button item")]
        public InArgument<string> ButtonId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.PressToolbarContextButton(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.ButtonId.Get(context));
        }
    }

    [Description("Emulates the selection of an item from the context menu of the grid view's toolbar.\nThe parameter should be the function code of the item.")]
    public sealed class SelectToolbarMenuItem : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: The SAP unique ID for the menu item")]
        public InArgument<string> MenuId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SelectToolbarMenuItem(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.MenuId.Get(context));
        }
    }

    [Description("Emulates pressing the Enter Key.\nUse this to apply data and functions.")]
    public sealed class PressEnter : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.PressEnter(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession));
        }
    }

    [Description("Changes a column width in a grid view component.\nThe width is given in characters.\nFor proportional fonts this refers to the width of an average character.\nException is raised if invalid parameters are supplied.")]
    public sealed class SetColumnWidth : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("int: Column width in characters.\n(Be mindful that the visible column title is used when exporting)")]
        public InArgument<int> Width { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SetColumnWidth(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.SAPColumnName.Get(context), this.Width.Get(context));
        }
    }

    [Description("If Row and Column properties are valid, the cell becomes the current cell.\nException is raised if invalid parameters are supplied.")]
    public sealed class SetCurrentCell : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("int: Row index of the cell.")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SetCurrentCell(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context));
        }
    }

    [Description("If Row and Column properties identify a valid editable cell\nthen the value of the cell is changed.\nException is raised if invalid parameters are supplied.")]
    public sealed class ModifyCellValue : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input"), Description("int")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: New cell value")]
        public InArgument<string> Value { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.ModifyCell(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context), this.Value.Get(context));
        }
    }

    [Description("The rows with an index greater than or equal to FromRow\nup to an index less than or equal to ToRow are moved to the position of DestRow.\nException is raised if invalid indexes are supplied.")]
    public sealed class MoveRows : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Range")]
        [Description("int: Index of the first row to be moved.")]
        public InArgument<int> FromRow { get; set; }

        [RequiredArgument, Category("Range")]
        [Description("int: Index of the last row to be moved.")]
        public InArgument<int> ToRow { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("int: Index of the destination where the row range will be placed.")]
        public InArgument<int> TargetRow { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.MoveRows(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.FromRow.Get(context), this.ToRow.Get(context), this.TargetRow.Get(context));
        }
    }

    [Description("Returns the value of a specified cell")]
    public sealed class GetCellValue : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input"), Description("int")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("string: The resulting cell content.")]
        public OutArgument<string> CellValue { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            this.CellValue.Set(context, SAPGui.GetCellValue(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context)));
        }
    }

    [Description("Returns True if the specified cell is changeable.")]
    public sealed class GetCellChangeable : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input"), Description("int")]
        public InArgument<int> Row { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("bool: Returns True if the specified cell is changeable.")]
        public OutArgument<bool> CellChangeable { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            this.CellChangeable.Set(context, SAPGui.GetCellChangeable(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Row.Get(context), this.SAPColumnName.Get(context)));
        }
    }

    [Description("Returns the title of the column that is currently displayed.\nSAP chooses the appropriate title according to the width of the column.")]
    public sealed class GetDisplayedColumnTitle : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("string: Result of the column visible title.")]
        public OutArgument<string> DisplayedColumnTitle { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            this.DisplayedColumnTitle.Set(context, SAPGui.GetDisplayedColumnTitle(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.SAPColumnName.Get(context)));
        }
    }

    [Description("Selects the whole grid content (all rows and columns)")]
    public sealed class SelectAll : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SelectAll(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession));
        }
    }

    [Description("Adds an specified column to the collection of selected columns")]
    public sealed class SelectColumn : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.SelectColumn(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.SAPColumnName.Get(context));
        }
    }

    [Description("Removes an specified column from the collection of selected columns")]
    public sealed class DeselectColumn : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> SAPColumnName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.DeselectColumn(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.SAPColumnName.Get(context));
        }
    }

    [Description("Returns if a specified column is with an active filter")]
    public sealed class IsColumnFiltered : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument, Category("Input")]
        [Description("string: Internal SAP column name.\n(Not the column title)")]
        public InArgument<string> Column { get; set; }

        [RequiredArgument, Category("Output")]
        [Description("bool: Returns True if column is filtered.")]
        public OutArgument<bool> IsFiltered { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            this.IsFiltered.Set(context, SAPGui.IsColumnFiltered(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession), this.Column.Get(context)));
        }
    }

    [Description("Emulates the context menu request for the grid view control")]
    public sealed class ContextMenu : CodeActivity
    {
        [OverloadGroup("GridId")]
        [RequiredArgument, Category("Target")]
        [Description("string: The SAP unique id for the grid view component.")]
        public InArgument<string> Id { get; set; }

        [OverloadGroup("GridObject")]
        [RequiredArgument, Category("Target")]
        [Description("GuiGridView: If the property ID is not provided, inform here the object got previously.\n(Use FindById activity or FindByName activity to get the object)")]
        public InArgument<sapfewse.GuiGridView> GuiGridView { get; set; }

        [RequiredArgument, Category("Target")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            SAPGui.ContextMenu(this.Id.Get(context), (this.GuiGridView.Get(context) as sapfewse.GuiGridView), (this.Session.Get(context) as GuiSession));
        }
    }

}