using System;
using saprotwr.net;
using sapfewse;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
namespace UiPrime.SAPCore
{
    /// <summary>
    /// Contains implementation of every activity in the package.</summary>
    public class SAPGui{
        
        private int sapROTWrapper;
        
        public int SapROTWrapper
        {
            get { return sapROTWrapper;}
            set { sapROTWrapper = value;}
        }

        #region GuiGridView

        public static void SetCurrentCell(string id, GuiGridView gridView, GuiSession session, int row, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SetCurrentCell(row, column);
        }

        public static void SetColumnWidth(string id, GuiGridView gridView, GuiSession session, string column, int width)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SetColumnWidth(column, width);
        }

        public static void Click(string id, GuiGridView gridView, GuiSession session, int row, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.Click(row, column);
        }

        public static void SelectToolbarMenuItem(string id, GuiGridView gridView, GuiSession session, string menuId)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SelectToolbarMenuItem(menuId);
        }

        public static void SelectContextMenuItem(string id, GuiGridView gridView, GuiSession session, string functionCode)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SelectContextMenuItem(functionCode);
        }

        public static void DoubleClick(string id, GuiGridView gridView, GuiSession session, int row, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.DoubleClick(row, column);
        }

        public static string GetCellValue(string id, GuiGridView gridView, GuiSession session, int row, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            return gridView.GetCellValue(row, column);
        }

        public static bool GetCellChangeable(string id, GuiGridView gridView, GuiSession session, int row, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            return gridView.GetCellChangeable(row, column);
        }

        public static void ClearSelection(string id, GuiGridView gridView, GuiSession session)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.ClearSelection();
        }

        public static void PressToolbarContextButton(string id, GuiGridView gridView, GuiSession session, String ButtonId)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.PressToolbarContextButton(ButtonId);
        }

        public static string GetColumnTitles(string id, GuiGridView gridView, GuiSession session, String Column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            return (gridView.GetColumnTitles(Column) as GuiCollection).Item(0);
        }

        public static string GetDisplayedColumnTitle(string id, GuiGridView gridView, GuiSession session, String Column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            return gridView.GetDisplayedColumnTitle(Column);
        }

        public static void SelectAll(string id, GuiGridView gridView, GuiSession session)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SelectAll();
        }

        public static bool IsColumnFiltered(string id, GuiGridView gridView, GuiSession session, string column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            return gridView.IsColumnFiltered(column);
        }

        public static void SelectColumn(string id, GuiGridView gridView, GuiSession session, String Column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.SelectColumn(Column);
        }

        public static void DeselectColumn(string id, GuiGridView gridView, GuiSession session, String Column)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.DeselectColumn(Column);
        }

        public static void PressEnter(string id, GuiGridView gridView, GuiSession session)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.PressEnter();
        }

        public static void MoveRows(string id, GuiGridView gridView, GuiSession session, int fromrow, int torow, int destRow)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.MoveRows(fromrow, torow, destRow);
        }

        public static void ModifyCell(string id, GuiGridView gridView, GuiSession session, int row, string column, string value)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.ModifyCell(row, column, value);
        }

        public static void ContextMenu(string id, GuiGridView gridView, GuiSession session)
        {
            ValidateGridTarget.ValidateTarget(id, gridView, session);
            if (gridView == null)
            {
                gridView = (GuiGridView)(session).FindById(id);
            }
            gridView.ContextMenu();
        }

        #endregion

        #region GuiButton

        public static void Press(string id, GuiButton button, GuiSession session)
        {
            if (button == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiButton object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (button == null)
            {
                button = (GuiButton)(session).FindById(id);
            }
            button.SetFocus();
            button.Press();
        }

        #endregion

        #region GuiComboBox

        public static void SetKeySpace(string id, GuiComboBox combo, GuiSession session)
        {
            if (combo == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiComboBox object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (combo == null)
            {
                combo = (GuiComboBox)(session).FindById(id);
            }
            combo.SetKeySpace();
        }

        #endregion

        #region GuiStatusbar

        public static void StatusBarDoubleClick(string id, GuiStatusbar statusbar, GuiSession session)
        {
            if (statusbar == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiStatusbar object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (statusbar == null)
            {
                statusbar = (GuiStatusbar)(session).FindById(id);
            }
            statusbar.DoubleClick();
        }

        #endregion

        #region GuiRadioButton

        public static void RadioButtonSelect(string id, GuiRadioButton radiobutton, GuiSession session)
        {
            if (radiobutton == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiRadioButton object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (radiobutton == null)
            {
                radiobutton = (GuiRadioButton)(session).FindById(id);
            }
            radiobutton.SetFocus();
            radiobutton.Selected = true;
        }

        #endregion

        #region Session

        public static GuiSession GetObjSessionById(string id)
        {
            CSapROTWrapper sapROTWrapper = new CSapROTWrapper();
            object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
            object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod,
                null, SapGuilRot, null);

            GuiConnection connection = (engine as GuiApplication).Connections.ElementAt(0) as GuiConnection;
            GuiSession session = connection.FindById(id) as GuiSession;
            return session;
        }

        public static GuiSession GetCurrentSession()
        {
            GuiConnection connection = SAPGui.GetConnection();
            GuiSession session = connection.Children.ElementAt(0) as GuiSession;
            return session;
        }

        public static GuiSession NewSession(GuiSession currentSession)
        {

            if (currentSession == null)
            {
                currentSession = GetCurrentSession();
            }

            GuiConnection connection = SAPGui.GetConnection();
            int currNumSessions = connection.Children.Count;
            GuiSession session = currentSession;
            session.CreateSession();

            System.Threading.Thread.Sleep(500);

            int count = 0;

            while (connection.Children.Count <= currNumSessions && count < 20)
            {
                System.Threading.Thread.Sleep(500);
                count++;
                connection = SAPGui.GetConnection();
            }

            return connection.Children.ElementAt(connection.Children.Count - 1) as GuiSession;
        }



        public static void KeepOneSessionSAP()
        {
            GuiConnection connection = SAPGui.GetConnection();
            for (int count = connection.Sessions.Count - 1; count > 0; count--)
            {
                connection.CloseSession(connection.Sessions.ElementAt(count).Id);
            }
        }


        public static void DestroySession(object currentSession)
        {
            GuiConnection connection = SAPGui.GetConnection();
            connection.CloseSession((currentSession as GuiSession).Id);
        }

        #endregion

        #region GuiMenu

        public static void MenuSelect(string id, GuiMenu menu, GuiSession session)
        {
            if (menu == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiMenu object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (menu == null)
            {
                menu = (GuiMenu)(session).FindById(id);
            }
            menu.Select();
        }

        #endregion

        #region GuiTab

        public static void TabSelect(string id, GuiTab tab, GuiSession session)
        {
            if (tab == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiTab object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (tab == null)
            {
                tab = (GuiTab)(session).FindById(id);
            }
            tab.Select();
        }

        #endregion

        #region GuiTableControl

        public static int RowsCountBasedOnEmptyField(string id, GuiTableControl table, GuiSession session, string SAPColumnName, string columnNameToTest)
        {
            if (table == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiTableControl object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (table == null)
            {
                table = (GuiTableControl)(session).FindById(id);
            }

            string tableid = table.Id;
            int output = 0;
            GuiVComponent next;
            GuiVComponent current;

            table.VerticalScrollbar.Position = 0;
            table = (GuiTableControl)((GuiSession)session).FindById(tableid);

            bool aux = true;
            do
            {
                table.VerticalScrollbar.Position = output;
                table = (GuiTableControl)((GuiSession)session).FindById(tableid);

                current = (GuiVComponent)table.FindById(SAPColumnName.ToString() + "[" + FindColumnIndex(id, table, session, columnNameToTest).ToString() + ",0]", false);
                next = (GuiVComponent)table.FindById(SAPColumnName.ToString() + "[" + FindColumnIndex(id, table, session, columnNameToTest).ToString() + ",1]", false);

                if (current != null && !String.IsNullOrEmpty(current.Text.Trim()) && !(new Regex("^_+$").Match(current.Text).Success))
                    output = output + 1;

                if (next == null || String.IsNullOrEmpty(next.Text.Trim()) || new Regex("^_+$").Match(next.Text).Success)
                {
                    aux = false;
                }

            } while (aux);

            table.VerticalScrollbar.Position = 0;

            return output;
        }

        public static GuiTableControl MoveScroll(string id, GuiTableControl table, GuiSession session, int position)
        {
            if (table == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiTableControl object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (table == null)
            {
                table = (GuiTableControl)(session).FindById(id);
            }

            string tableid = table.Id;
            table.VerticalScrollbar.Position = position;
            return (GuiTableControl)((GuiSession)session).FindById(tableid);
        }

        public static int FindColumnIndex(string id, GuiTableControl table, GuiSession session, string columnName)
        {
            if (table == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiTableControl object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (table == null)
            {
                table = (GuiTableControl)(session).FindById(id);
            }

            IEnumerator<GuiTableColumn> cols = table.Columns.Cast<GuiTableColumn>().GetEnumerator();
            int counter = 0;
            string colname;
            while (cols.MoveNext())
            {
                colname = ((GuiComponent)cols.Current).Name;
                if (colname.ToUpper().Trim().Replace(" ", "").Equals(columnName.Trim().ToUpper().Replace(" ", "")))
                {
                    return counter;
                };
                counter++;
            }
            return -1;
        }

        public static int[] FindColumnIndexByName(string id, GuiTableControl table, GuiSession session, string columnTitle)
        {
            if (table == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiTableControl object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (table == null)
            {
                table = (GuiTableControl)(session).FindById(id);
            }

            List<int> output = new List<int>();
            int index = 0;

            foreach (GuiTableColumn c in table.Columns)
            {
                if (columnTitle.ToLower().Trim().Equals(c.Title.ToLower().Trim()))
                {
                    output.Add(index);
                }
                index++;
            }
            return output.ToArray();
        }


        #endregion

        #region Common

        public static List<TargetType> FindAllByNameCustom<SourceType, TargetType>(SourceType sourceObj, string name)
        {
            object[] args = { name, typeof(TargetType).Name };
            try
            {
                return ((GuiComponentCollection)typeof(SourceType)
                        .InvokeMember("findAllByName", BindingFlags.InvokeMethod, null, sourceObj, args))
                    .Cast<TargetType>().ToList<TargetType>();
            }
            catch (Exception e)
            {
                return default(List<TargetType>);
            }
        }

        private static GuiConnection GetConnection()
        {
            CSapROTWrapper sapROTWrapper = new CSapROTWrapper();
            object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
            object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod,
                null, SapGuilRot, null);

            return (engine as GuiApplication).Connections.ElementAt(0) as GuiConnection;
        }

        public static void AccessTransactionByID(object currentSession, string id)
        {
            if (currentSession == null)
            {
                currentSession = GetCurrentSession();
            }

            GuiSession session = currentSession as GuiSession;
            session.StartTransaction(id);
        }

        public static GuiConnection CreateConnection(string description, string user, string password, string language)
        {
            CSapROTWrapper sapROTWrapper = new CSapROTWrapper();
            object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
            object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod,
                null, SapGuilRot, null);

            GuiApplication app = (GuiApplication)engine;
            GuiConnection conn;

            if (app.Connections.Count == 0)
            {
                conn = app.OpenConnection(description);
                GuiSession session = conn.Children.ElementAt(0) as GuiSession;
                GuiTextField name = (GuiTextField)session.FindById("wnd[0]/usr/txtRSYST-BNAME");
                GuiPasswordField pass = (GuiPasswordField)session.FindById("wnd[0]/usr/pwdRSYST-BCODE");
                GuiTextField lang = (GuiTextField)session.FindById("wnd[0]/usr/txtRSYST-LANGU");
                GuiMainWindow mainWindows = (GuiMainWindow)session.FindById("wnd[0]");

                name.Text = user;
                pass.Text = password;
                lang.Text = language;
                mainWindows.SendVKey(0);
            }
            else
            {
                conn = (GuiConnection)app.Connections.ElementAt(0);
            }

            return conn;
        }

        #endregion

        #region GuiFrameWindow

        public static void SendVKey(string id, GuiFrameWindow window, GuiSession session, int key)
        {
            if (window == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiFrameWindow object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (window == null)
            {
                window = (GuiFrameWindow)(session).FindById(id);
            }
            window.SendVKey(key);
        }

        public static void Maximize(string id, GuiFrameWindow window, GuiSession session)
        {
            if (window == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiFrameWindow object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (window == null)
            {
                window = (GuiFrameWindow)(session).FindById(id);
            }
            window.Maximize();
        }

        #endregion

        #region vComponent
        public static void SetFocus(string id, GuiVComponent component, GuiSession session)
        {
            if (component == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiVComponent object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (component == null)
            {
                component = (GuiVComponent)(session).FindById(id);
            }

            component.SetFocus();
        }

        public static void SetText(string id, GuiVComponent component, GuiSession session, string text)
        {
            //string name = this.Name.Get(context);
            //object[] args = { name, typeof(TargetType).Name };
            //((GuiVComponent)(typeof(SourceType).InvokeMember("FindByName", BindingFlags.InvokeMethod, null, this.Source.Get(context), args))).Text = this.Text.Get(context);

            if (component == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiVComponent object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");

            if (component == null)
            {
                component = (GuiVComponent)(session).FindById(id);
            }

            component.Text = text;
        }
        #endregion

    }

    public static class ValidateGridTarget
    {
        public static void ValidateTarget(string id, GuiGridView gridView, GuiSession session)
        {
            if (gridView == null && string.IsNullOrEmpty(id))
                throw new Exception("Parameters for the Target object not provided: id or GuiGridView object");

            if (session == null)
                throw new Exception("SAP session parameter is required and was not provided.");
        }
    }

}