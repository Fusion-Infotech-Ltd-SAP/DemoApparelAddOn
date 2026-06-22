using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
using Apparel_AddOn.Helper;
using Apparel_AddOn.Resources;

namespace Apparel_AddOn.Modules
{
    class SalesQuotation
    {
        public SalesQuotation()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(SBO_Application_FormDataEvent);
        }
        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {

            BubbleEvent = true;
            try
            {

                if (pVal.FormTypeEx == "149" && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)
                {

                    Global.G_Form = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == true)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            // ************** OTT **************
                            Global.G_Form.Items.Add("STOTTNTRY", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STOTTNTRY").Specific;
                            Global.oStatic.Caption = "OTT";

                            Global.G_Form.Items.Item("STOTTNTRY").Top = Global.G_Form.Items.Item("70").Top + 18;
                            Global.G_Form.Items.Item("STOTTNTRY").Left = Global.G_Form.Items.Item("70").Left;
                            Global.G_Form.Items.Item("STOTTNTRY").Width = Global.G_Form.Items.Item("70").Width;
                            Global.G_Form.Items.Item("STOTTNTRY").FromPane = 0;
                            Global.G_Form.Items.Item("STOTTNTRY").ToPane = 0;

                            // Linked Button
                            Global.G_Form.Items.Add("LNOTTNTRY", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);

                            // EditText (ETOTTNTRY)
                            Global.G_Form.Items.Add("ETOTTNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETOTTNTRY").Top = Global.G_Form.Items.Item("STOTTNTRY").Top;
                            Global.G_Form.Items.Item("ETOTTNTRY").Left = Global.G_Form.Items.Item("14").Left;
                            Global.G_Form.Items.Item("ETOTTNTRY").Width = (Global.G_Form.Items.Item("14").Width / 2) - 5;
                            Global.G_Form.Items.Item("ETOTTNTRY").FromPane = 0;
                            Global.G_Form.Items.Item("ETOTTNTRY").ToPane = 0;
                            Global.G_Form.Items.Item("ETOTTNTRY").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNTRY").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_OTTNTRY");
                            Global.G_Form.Items.Item("STOTTNTRY").LinkTo = "ETOTTNTRY";

                            // Linked Button setup
                            Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNOTTNTRY").Specific;
                            // Global.oLinkButton.LinkedObjectType = "ESPL_UDO_DD_GATENTRY";  // Uncomment if needed
                            Global.G_Form.Items.Item("LNOTTNTRY").Top = Global.G_Form.Items.Item("STOTTNTRY").Top;
                            Global.G_Form.Items.Item("LNOTTNTRY").Left = Global.G_Form.Items.Item("ETOTTNTRY").Left - 19;
                            Global.G_Form.Items.Item("LNOTTNTRY").Height = Global.G_Form.Items.Item("LNOTTNTRY").Height - 1;
                            Global.G_Form.Items.Item("LNOTTNTRY").LinkTo = "ETOTTNTRY";

                            // EditText (ETOTTNO)
                            Global.G_Form.Items.Add("ETOTTNO", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETOTTNO").Top = Global.G_Form.Items.Item("STOTTNTRY").Top;
                            Global.G_Form.Items.Item("ETOTTNO").Left = Global.G_Form.Items.Item("ETOTTNTRY").Left + Global.G_Form.Items.Item("ETOTTNTRY").Width + 5;
                            Global.G_Form.Items.Item("ETOTTNO").Width = (Global.G_Form.Items.Item("14").Width / 2) - 5;
                            Global.G_Form.Items.Item("ETOTTNO").FromPane = 0;
                            Global.G_Form.Items.Item("ETOTTNO").ToPane = 0;
                            Global.G_Form.Items.Item("ETOTTNO").Enabled = false;
                            Global.G_Form.Items.Item("ETOTTNO").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_OTTNO");
                            Global.G_Form.Items.Item("ETOTTNTRY").LinkTo = "ETOTTNO";

                            // Choose From List (CFL)
                            Global.oCfls = Global.G_Form.ChooseFromLists;
                            Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)
                                Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            Global.oCFLCreationParams.MultiSelection = false;
                            Global.oCFLCreationParams.ObjectType = "FIL_D_PLANOTT";
                            Global.oCFLCreationParams.UniqueID = "CFL_OTT";

                            Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNTRY").Specific;
                            Global.oEdit.ChooseFromListUID = "CFL_OTT";
                            Global.oEdit.ChooseFromListAlias = "DocEntry";
                            // ************** OTT **************

                            // ************** Style No. **************

                            Global.G_Form.Items.Add("STStyleNo", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STStyleNo").Specific;
                            Global.oStatic.Caption = "Style No.";

                            Global.G_Form.Items.Item("STStyleNo").Top = Global.G_Form.Items.Item("2002").Top + 18;
                            Global.G_Form.Items.Item("STStyleNo").Left = Global.G_Form.Items.Item("2002").Left;
                            Global.G_Form.Items.Item("STStyleNo").Width = Global.G_Form.Items.Item("2002").Width;
                            Global.G_Form.Items.Item("STStyleNo").Height = Global.G_Form.Items.Item("2002").Height;
                            Global.G_Form.Items.Item("STStyleNo").FromPane = 0;
                            Global.G_Form.Items.Item("STStyleNo").ToPane = 0;

                            // Linked Button
                            Global.G_Form.Items.Add("LNStyleNo", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);

                            // EditText (ETStyleNo)
                            Global.G_Form.Items.Add("ETStyleNo", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;
                            Global.G_Form.Items.Item("ETStyleNo").Left = Global.G_Form.Items.Item("2003").Left;
                            Global.G_Form.Items.Item("ETStyleNo").Width = (Global.G_Form.Items.Item("2003").Width / 2) - 5;
                            Global.G_Form.Items.Item("ETStyleNo").Height = Global.G_Form.Items.Item("2003").Height;
                            Global.G_Form.Items.Item("ETStyleNo").FromPane = 0;
                            Global.G_Form.Items.Item("ETStyleNo").ToPane = 0;
                            Global.G_Form.Items.Item("ETStyleNo").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETStyleNo").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_StyleNo");
                            Global.G_Form.Items.Item("STStyleNo").LinkTo = "ETStyleNo";

                            // Linked Button Setup
                            Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNStyleNo").Specific;
                            // Global.oLinkButton.LinkedObjectType = "ESPL_UDO_DD_GATENTRY"; // Optional
                            Global.G_Form.Items.Item("LNStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;
                            Global.G_Form.Items.Item("LNStyleNo").Left = Global.G_Form.Items.Item("ETStyleNo").Left - 19;
                            Global.G_Form.Items.Item("LNStyleNo").Height = Global.G_Form.Items.Item("LNStyleNo").Height - 1;
                            Global.G_Form.Items.Item("LNStyleNo").LinkTo = "ETStyleNo";

                            // Choose From List (CFL)
                            Global.oCfls = Global.G_Form.ChooseFromLists;
                            Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)
                                Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            Global.oCFLCreationParams.MultiSelection = false;
                            Global.oCFLCreationParams.ObjectType = "FIL_M_OPSM";
                            Global.oCFLCreationParams.UniqueID = "CFL_OPSM";

                            Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETStyleNo").Specific;
                            Global.oEdit.ChooseFromListUID = "CFL_OPSM";
                            Global.oEdit.ChooseFromListAlias = "Code";

                            // Button (BTStyleNo)
                            Global.G_Form.Items.Add("BTStyleNo", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                            Global.G_Form.Items.Item("BTStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;
                            Global.G_Form.Items.Item("BTStyleNo").Left = Global.G_Form.Items.Item("ETStyleNo").Left + Global.G_Form.Items.Item("ETStyleNo").Width + 5;
                            Global.G_Form.Items.Item("BTStyleNo").Width = (Global.G_Form.Items.Item("2003").Width / 2) - 5;
                            Global.G_Form.Items.Item("BTStyleNo").Height = Global.G_Form.Items.Item("ETStyleNo").Height;
                            Global.G_Form.Items.Item("BTStyleNo").FromPane = 0;
                            Global.G_Form.Items.Item("BTStyleNo").ToPane = 0;

                            Global.oButton = (SAPbouiCOM.Button)Global.G_Form.Items.Item("BTStyleNo").Specific;
                            Global.oButton.Caption = "Get Info";

                            Global.G_Form.Items.Item("BTStyleNo").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            // ************ BUYER'S STYLE NO ************
                            Global.G_Form.Items.Add("STBSTYLENO", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STBSTYLENO").Specific;
                            Global.oStatic.Caption = "Buyers Style No.";

                            Global.G_Form.Items.Item("STBSTYLENO").Top = Global.G_Form.Items.Item("STStyleNo").Top + 18; // - 2000 
                            Global.G_Form.Items.Item("STBSTYLENO").Left = Global.G_Form.Items.Item("STStyleNo").Left;
                            Global.G_Form.Items.Item("STBSTYLENO").Width = Global.G_Form.Items.Item("STStyleNo").Width;
                            Global.G_Form.Items.Item("STBSTYLENO").FromPane = 0;
                            Global.G_Form.Items.Item("STBSTYLENO").ToPane = 0;

                            // Add EditText for Buyer's Style No
                            Global.G_Form.Items.Add("ETBSTYLENO", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETBSTYLENO").Top = Global.G_Form.Items.Item("STBSTYLENO").Top;
                            Global.G_Form.Items.Item("ETBSTYLENO").Left = Global.G_Form.Items.Item("ETStyleNo").Left;
                            Global.G_Form.Items.Item("ETBSTYLENO").Width = Global.G_Form.Items.Item("ETStyleNo").Width;
                            Global.G_Form.Items.Item("ETBSTYLENO").Height = Global.G_Form.Items.Item("ETStyleNo").Height;
                            Global.G_Form.Items.Item("ETBSTYLENO").FromPane = 0;
                            Global.G_Form.Items.Item("ETBSTYLENO").ToPane = 0;
                            Global.G_Form.Items.Item("ETBSTYLENO").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );
                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETBSTYLENO").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_BSTYLENO");
                            Global.G_Form.Items.Item("STBSTYLENO").LinkTo = "ETBSTYLENO";

                            // Add EditText for Buyer's Style Name
                            Global.G_Form.Items.Add("ETBSTYLENM", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETBSTYLENM").Top = Global.G_Form.Items.Item("ETBSTYLENO").Top;
                            Global.G_Form.Items.Item("ETBSTYLENM").Left = Global.G_Form.Items.Item("ETBSTYLENO").Left + Global.G_Form.Items.Item("ETBSTYLENO").Width + 5;
                            Global.G_Form.Items.Item("ETBSTYLENM").Width = Global.G_Form.Items.Item("BTStyleNo").Width;
                            Global.G_Form.Items.Item("ETBSTYLENM").Height = Global.G_Form.Items.Item("BTStyleNo").Height;
                            Global.G_Form.Items.Item("ETBSTYLENM").FromPane = 0;
                            Global.G_Form.Items.Item("ETBSTYLENM").ToPane = 0;
                            Global.G_Form.Items.Item("ETBSTYLENM").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );
                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETBSTYLENM").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_BSTYLENM");
                            Global.G_Form.Items.Item("ETBSTYLENO").LinkTo = "ETBSTYLENM";
                            // ************ BUYER'S STYLE NO ************

                            // ************* TYPE ********************
                            Global.G_Form.Items.Add("STTYPE", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STTYPE").Specific;
                            Global.oStatic.Caption = "Order Type.";

                            Global.G_Form.Items.Item("STTYPE").Top = Global.G_Form.Items.Item("254000012").Top + 18;  // - 2000
                            Global.G_Form.Items.Item("STTYPE").Left = Global.G_Form.Items.Item("254000012").Left;
                            Global.G_Form.Items.Item("STTYPE").Width = Global.G_Form.Items.Item("254000012").Width;
                            Global.G_Form.Items.Item("STTYPE").FromPane = 0;
                            Global.G_Form.Items.Item("STTYPE").ToPane = 0;

                            // Add ComboBox for Type
                            Global.G_Form.Items.Add("CBTYPE", SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX);
                            Global.G_Form.Items.Item("CBTYPE").Top = Global.G_Form.Items.Item("STTYPE").Top;
                            Global.G_Form.Items.Item("CBTYPE").Left = Global.G_Form.Items.Item("254000015").Left;
                            Global.G_Form.Items.Item("CBTYPE").Width = Global.G_Form.Items.Item("254000015").Width;
                            Global.G_Form.Items.Item("CBTYPE").FromPane = 0;
                            Global.G_Form.Items.Item("CBTYPE").ToPane = 0;
                            Global.G_Form.Items.Item("CBTYPE").DisplayDesc = true;
                            Global.G_Form.Items.Item("CBTYPE").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );

                            Global.oCombo = (SAPbouiCOM.ComboBox)Global.G_Form.Items.Item("CBTYPE").Specific;
                            Global.oCombo.DataBind.SetBound(true, "OQUT", "U_TYPE");
                            Global.G_Form.Items.Item("STTYPE").LinkTo = "CBTYPE";
                            // ************* TYPE ********************
                            // ********** CREATE FOLDER TAB21 *************
                            Global.G_Form.Items.Add("TAB21", SAPbouiCOM.BoFormItemTypes.it_FOLDER);
                            SAPbouiCOM.Folder oFolder = (SAPbouiCOM.Folder)Global.G_Form.Items.Item("TAB21").Specific;
                            oFolder.Caption = "Size and Colour";
                            //G_Form.DataSources.UserDataSources.Add("FolderDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1);
                            try
                            {
                                oFolder.DataBind.SetBound(true, "", "FolderDS");
                            }
                            catch (Exception)
                            {
                            }
                            oFolder.AutoPaneSelection = false;
                            oFolder.Pane = 21;
                            oFolder.GroupWith("112");

                            Global.G_Form.Items.Item("112").Width = 80;
                            Global.G_Form.Items.Item("114").Width = 80;
                            Global.G_Form.Items.Item("138").Width = 80;
                            Global.G_Form.Items.Item("2013").Width = 150;
                            Global.G_Form.Items.Item("1320002137").Width = 80;
                            Global.G_Form.Items.Item("TAB21").Width = 80;

                            Global.G_Form.Items.Item("TAB21").Left = Global.G_Form.Items.Item("112").Left + Global.G_Form.Items.Item("112").Width;
                            Global.G_Form.Items.Item("TAB21").Top = Global.G_Form.Items.Item("112").Top;
                            Global.G_Form.Items.Item("TAB21").Visible = true;

                            Global.G_Form.Items.Item("114").Left = Global.G_Form.Items.Item("TAB21").Left + Global.G_Form.Items.Item("TAB21").Width;
                            Global.G_Form.Items.Item("138").Left = Global.G_Form.Items.Item("114").Left + Global.G_Form.Items.Item("114").Width;
                            Global.G_Form.Items.Item("2013").Left = Global.G_Form.Items.Item("138").Left + Global.G_Form.Items.Item("138").Width;
                            Global.G_Form.Items.Item("1320002137").Left = Global.G_Form.Items.Item("2013").Left + Global.G_Form.Items.Item("2013").Width;

                            // ********** GRID **********
                            Global.G_Form.Items.Add("SCGrid", SAPbouiCOM.BoFormItemTypes.it_GRID);
                            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)Global.G_Form.Items.Item("SCGrid").Specific;
                            Global.G_Form.Items.Item("SCGrid").Width = (Global.G_Form.Items.Item("118").Left - 10) - (Global.G_Form.Items.Item("117").Left + 10);
                            Global.G_Form.Items.Item("SCGrid").Top = Global.G_Form.Items.Item("44").Top;
                            Global.G_Form.Items.Item("SCGrid").Left = Global.G_Form.Items.Item("44").Left + 15;
                            Global.G_Form.Items.Item("SCGrid").Height = (Global.G_Form.Items.Item("116").Top - 10) - Global.G_Form.Items.Item("38").Top;
                            Global.G_Form.Items.Item("SCGrid").FromPane = 21;
                            Global.G_Form.Items.Item("SCGrid").ToPane = 21;

                            // Add DataTable
                            Global.G_Form.DataSources.DataTables.Add("DT_0");

                            // ********** Qty Static **********
                            Global.G_Form.Items.Add("STQty", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            SAPbouiCOM.StaticText oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STQty").Specific;
                            oStatic.Caption = "Qty.";

                            Global.G_Form.Items.Item("STQty").Top = Global.G_Form.Items.Item("38").Top + Global.G_Form.Items.Item("38").Height + 15;
                            Global.G_Form.Items.Item("STQty").Left = Global.G_Form.Items.Item("86").Left;
                            Global.G_Form.Items.Item("STQty").Width = Global.G_Form.Items.Item("86").Width;
                            Global.G_Form.Items.Item("STQty").FromPane = 1;
                            Global.G_Form.Items.Item("STQty").ToPane = 1;

                            // ********** Qty EditText **********
                            Global.G_Form.Items.Add("ETQty", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETQty").Top = Global.G_Form.Items.Item("STQty").Top;
                            Global.G_Form.Items.Item("ETQty").Left = Global.G_Form.Items.Item("46").Left;
                            Global.G_Form.Items.Item("ETQty").Width = Global.G_Form.Items.Item("ETStyleNo").Width;
                            Global.G_Form.Items.Item("ETQty").FromPane = 1;
                            Global.G_Form.Items.Item("ETQty").ToPane = 1;
                            Global.G_Form.Items.Item("ETQty").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );
                            SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETQty").Specific;
                            oEdit.DataBind.SetBound(true, "OQUT", "U_TotalQty");
                            Global.G_Form.Items.Item("STQty").LinkTo = "ETQty";

                            // ********** Get Item Button **********
                            Global.G_Form.Items.Add("BTQty", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                            Global.G_Form.Items.Item("BTQty").Top = Global.G_Form.Items.Item("ETQty").Top;
                            Global.G_Form.Items.Item("BTQty").Left = Global.G_Form.Items.Item("ETStyleNo").Left + Global.G_Form.Items.Item("ETStyleNo").Width + 5;
                            Global.G_Form.Items.Item("BTQty").Width = (Global.G_Form.Items.Item("46").Width / 2) - 5;
                            Global.G_Form.Items.Item("BTQty").Height = Global.G_Form.Items.Item("ETQty").Height;
                            Global.G_Form.Items.Item("BTQty").FromPane = 1;
                            Global.G_Form.Items.Item("BTQty").ToPane = 1;

                            SAPbouiCOM.Button oButton = (SAPbouiCOM.Button)Global.G_Form.Items.Item("BTQty").Specific;
                            oButton.Caption = "Get Item";
                            Global.G_Form.Items.Item("BTQty").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );

                            // ********** Size Colour ENTRY Hidden EditText **********
                            Global.G_Form.Items.Add("ETCRSZNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETCRSZNTRY").Top = -2000;
                            Global.G_Form.Items.Item("ETCRSZNTRY").Enabled = false;
                            oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific;
                            oEdit.DataBind.SetBound(true, "OQUT", "U_CRSZNTRY");

                            // Click to refresh form state
                            Global.G_Form.Items.Item("4").Click();


                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == false)
                    {
                        if (!string.IsNullOrWhiteSpace(Global.G_Form.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().Trim()))
                        {
                            LoadGrid(ref Global.G_Form, true);
                        }

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_RESIZE && pVal.BeforeAction == false)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            // Adjust Grid Size
                            Global.G_Form.Items.Item("SCGrid").Width =
                                    (Global.G_Form.Items.Item("118").Left - 10) - (Global.G_Form.Items.Item("117").Left + 10);
                            Global.G_Form.Items.Item("SCGrid").Height =
                                    (Global.G_Form.Items.Item("116").Top - 10) - Global.G_Form.Items.Item("38").Top;

                            // FILENTRY Row
                            //oForm.Items.Item("STFILENTRY").Top = oForm.Items.Item("86").Top + 18;
                            //oForm.Items.Item("ETFILENTRY").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("ETFILENO").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("LNFILENTRY").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("LNFILENTRY").Left = oForm.Items.Item("2003").Left - 20;

                            // Second Row
                            //Global.G_Form.Items.Item("2002").Top = Global.G_Form.Items.Item("STFILENTRY").Top + 18;
                            //Global.G_Form.Items.Item("2003").Top = Global.G_Form.Items.Item("2002").Top;

                            // Style No Row
                            Global.G_Form.Items.Item("STStyleNo").Top = Global.G_Form.Items.Item("2002").Top + 18;
                            Global.G_Form.Items.Item("ETStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;
                            Global.G_Form.Items.Item("BTStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;
                            Global.G_Form.Items.Item("LNStyleNo").Top = Global.G_Form.Items.Item("STStyleNo").Top;

                            // Buyer Style No Row
                            Global.G_Form.Items.Item("STBSTYLENO").Top = Global.G_Form.Items.Item("STStyleNo").Top + 18;
                            Global.G_Form.Items.Item("ETBSTYLENO").Top = Global.G_Form.Items.Item("STBSTYLENO").Top;
                            Global.G_Form.Items.Item("ETBSTYLENM").Top = Global.G_Form.Items.Item("STBSTYLENO").Top;
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText("Resize error: " + ex.Message,
                                 SAPbouiCOM.BoMessageTime.bmt_Short,
                                 SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }
                        finally
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                           && pVal.ItemUID == "TAB21" && pVal.BeforeAction == false)
                    {
                        Global.G_Form.PaneLevel = 21;

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                           && pVal.ItemUID == "LNStyleNo" && pVal.BeforeAction == true)
                    {
                        Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETStyleNo").Specific;
                        openStyleMaster(Global.oEdit.Value);
                        Global.G_Form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                        BubbleEvent = false;
                        return;
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                            && pVal.ItemUID == "LNOTTNTRY" && pVal.BeforeAction == true)
                    {
                        Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNTRY").Specific;
                        openOTT(Global.oEdit.Value);
                        Global.G_Form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                        BubbleEvent = false;
                        return;
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK && pVal.ItemUID == "SCGrid" && pVal.BeforeAction == false)
                    {
                        Global.oGrid = (SAPbouiCOM.Grid)Global.G_Form.Items.Item("SCGrid").Specific;
                        try
                        {
                            Global.G_Form.Freeze(true);
                            Global.oDataTable = Global.G_Form.DataSources.DataTables.Item("DT_0");
                            double Total = 0;

                            // Loop through columns starting from index 3
                            for (int j = 3; j <= Global.oDataTable.Columns.Count - 1; j++)
                            {
                                double cellValue = 0;
                                double.TryParse(Global.oDataTable.Columns.Item(j).Cells.Item(pVal.Row).Value.ToString(), out cellValue);
                                Total += cellValue;
                            }

                            // Update "Total" column for the clicked row
                            Global.oGrid.DataTable.Columns.Item("Total")
                                 .Cells.Item(Global.oGrid.GetDataTableRowIndex(pVal.Row))
                                 .Value = Total.ToString();

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                            Application.SBO_Application.StatusBar.SetText("Error in SCGrid Click: " + ex.Message,
                                 SAPbouiCOM.BoMessageTime.bmt_Short,
                                 SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }


                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_KEY_DOWN && pVal.ItemUID == "SCGrid" && pVal.BeforeAction == false && pVal.CharPressed == 9)
                    {
                        Global.oGrid = (SAPbouiCOM.Grid)Global.G_Form.Items.Item("SCGrid").Specific;
                        try
                        {
                            Global.G_Form.Freeze(true);
                            Global.oDataTable = Global.G_Form.DataSources.DataTables.Item("DT_0");
                            double Total = 0;

                            // Loop through columns starting from index 3
                            for (int j = 3; j <= Global.oDataTable.Columns.Count - 1; j++)
                            {
                                double cellValue = 0;
                                double.TryParse(Global.oDataTable.Columns.Item(j).Cells.Item(pVal.Row).Value.ToString(), out cellValue);
                                Total += cellValue;
                            }

                            // Update "Total" column for the clicked row
                            Global.oGrid.DataTable.Columns.Item("Total")
                                 .Cells.Item(Global.oGrid.GetDataTableRowIndex(pVal.Row))
                                 .Value = Total.ToString();

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                            Application.SBO_Application.StatusBar.SetText("Error in SCGrid Click: " + ex.Message,
                                 SAPbouiCOM.BoMessageTime.bmt_Short,
                                 SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }


                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNTRY" && pVal.BeforeAction == true)
                    {
                        SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                        SAPbouiCOM.DataTable oDataTable;
                        oDataTable = oCFLEvento.SelectedObjects;
                        SAPbouiCOM.ChooseFromList oCfl = Global.G_Form.ChooseFromLists.Item(oCFLEvento.ChooseFromListUID);
                        SAPbouiCOM.Conditions oCons = null;
                        SAPbouiCOM.Condition oCon = null;

                        oCons = new SAPbouiCOM.Conditions();

                        string qStr = @"SELECT DISTINCT A.""DocEntry"" 
                    FROM ""@FIL_DR_PLANOTT"" A 
                    WHERE  A.""U_STYLENO"" = '" + Global.G_Form.DataSources.DBDataSources.Item("OQUT").GetValue("U_StyleNo", 0).ToString().TrimEnd() + @"' 
                      AND A.""U_BUYRSTCD"" = '" + Global.G_Form.DataSources.DBDataSources.Item("OQUT").GetValue("U_BSTYLENO", 0).ToString().TrimEnd() + @"'";

                        SAPbobsCOM.Recordset POSSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        POSSet.DoQuery(qStr);

                        if (POSSet.RecordCount > 0)
                        {
                            while (!POSSet.EoF)
                            {
                                oCon = oCons.Add();
                                oCon.Alias = "DocEntry";
                                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCon.CondVal = POSSet.Fields.Item("DocEntry").Value.ToString();

                                POSSet.MoveNext();
                                if (!POSSet.EoF)
                                    oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            }
                        }
                        else
                        {
                            oCon = oCons.Add();
                            oCon.Alias = "DocEntry";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = "-1";
                        }

                        oCfl.SetConditions(oCons);
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNTRY" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            SAPbouiCOM.DataTable oDataTable;
                            oDataTable = oCFLEvento.SelectedObjects;

                            if (oDataTable != null)
                            {
                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item(pVal.ItemUID).Specific;
                                Global.oEdit.Value = oDataTable.GetValue(Global.oEdit.ChooseFromListAlias, 0).ToString().Trim();

                                try
                                {
                                    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                                    Global.oEdit.Value = oDataTable.GetValue("DocNum", 0).ToString().Trim();
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETStyleNo" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            SAPbouiCOM.DataTable oDataTable;
                            oDataTable = oCFLEvento.SelectedObjects;

                            if (oDataTable != null)
                            {
                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item(pVal.ItemUID).Specific;
                                Global.oEdit.Value = oDataTable.GetValue(Global.oEdit.ChooseFromListAlias, 0).ToString().Trim();


                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETBSTYLENO").Specific;
                                Global.oEdit.Value = oDataTable.GetValue("U_BUYRCODE", 0).ToString().Trim();

                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETBSTYLENM").Specific;
                                Global.oEdit.Value = oDataTable.GetValue("U_BURSNAME", 0).ToString().Trim();

                            }
                        }
                        catch { }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "BTStyleNo" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);
                            LoadGrid(ref Global.G_Form, false);
                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "BTQty" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);
                            LoadMatrix(ref Global.G_Form);
                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == true && Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            // ##### Insert Size
                            int SizeEntry = 0;
                            var oItem = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific;
                            if (!string.IsNullOrEmpty(oItem.Value))
                                SizeEntry = Convert.ToInt32(oItem.Value);

                            try
                            {
                                Global.oComp.StartTransaction();

                                InsertSizeDetails(Global.G_Form, "", "", SizeEntry);

                                Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                catch { }

                                try
                                {
                                    Global.oComp.StartTransaction();
                                    InsertSizeDetails(Global.G_Form, "", "", SizeEntry);
                                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                }
                                catch (Exception ex2)
                                {
                                    Global.G_UI_Application.StatusBar.SetText(ex2.Message, SAPbouiCOM.BoMessageTime.bmt_Short,
                                                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    try
                                    {
                                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                    }
                                    catch { }
                                }
                            }

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == false && Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);
                            LoadGrid(ref Global.G_Form, false);
                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in Draft Order for SAP Screen - " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }

        }

        public void openStyleMaster(string styleCode)
        {
            try
            {
                StyleMaster styleMaster = new StyleMaster();
                styleMaster.Show();
                Global.G_Form = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
                Global.G_Form.Freeze(true);
                Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                Global.G_Form.Items.Item("ETSTYLID").Enabled = true;
                SAPbouiCOM.EditText cETSTYLID = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLID").Specific;
                cETSTYLID.Value = styleCode;
                Global.G_Form.Items.Item("1").Click();
                Global.G_Form.Items.Item("FOLSZTYP").Click();
                Global.G_Form.Freeze(false);
            }
            catch (Exception ex)
            {
                Global.G_Form.Freeze(false);

                Application.SBO_Application.StatusBar.SetText("Error in openProductStyleMaster: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        public void openOTT(string OTTEntry)
        {
            try
            {
                OTT oTT = new OTT();
                oTT.Show();
                Global.G_Form = Application.SBO_Application.Forms.Item("FIL_FRM_OTT");
                Global.G_Form.Freeze(true);
                Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                Global.G_Form.Items.Item("ETDOCTRY").Enabled = true;
                SAPbouiCOM.EditText cETOTTID = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETDOCTRY").Specific;
                cETOTTID.Value = OTTEntry;
                Global.G_Form.Items.Item("1").Click();
                Global.G_Form.Freeze(false);
            }
            catch (Exception ex)
            {
                Global.G_Form.Freeze(false);

                Application.SBO_Application.StatusBar.SetText("Error in open OTT: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void LoadGrid(ref SAPbouiCOM.Form pform, bool FromDataEvent)
        {
            try
            {
                string qStr = string.Empty;
                if (FromDataEvent == false)
                {
                    SAPbouiCOM.EditText oETStyleNo = (SAPbouiCOM.EditText)pform.Items.Item("ETStyleNo").Specific;
                    qStr = " SELECT '\"'||STRING_AGG(\"U_SizeCode\",','ORDER BY \"U_ORDER\")||'\"' \"U_SizeCode\" " + Environment.NewLine +
                            " FROM ( SELECT  IFNULL(B.\"U_ORDER\",0) \"U_ORDER\",A.\"U_SizeCode\" " + Environment.NewLine +
                            "from \"@FIL_MR_PSMST\" A  " + Environment.NewLine +
                            "  INNER JOIN \"@FIL_MR_STM1\" B ON A.\"U_SizeType\"=B.\"Code\" AND B.\"U_SizeCode\"=A.\"U_SizeCode\" " + Environment.NewLine +
                            "     where A.\"Code\"='" + oETStyleNo.Value + "' And A.\"U_SizeAppl\"='Y' " + Environment.NewLine +
                            " group by IFNULL(B.\"U_ORDER\",0),A.\"U_SizeCode\" " + Environment.NewLine +
                            " order by IFNULL(B.\"U_ORDER\",0)  " + Environment.NewLine +
                            " )V1 ";

                    SAPbobsCOM.Recordset SizerSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    SizerSet.DoQuery(qStr);
                    string SizeString = SizerSet.Fields.Item("U_SizeCode").Value.ToString();

                    qStr = "SELECT \"U_ColourName\" \"Colour Name\",\"U_ColourCode\" \"Colour Code\", \"Total\" \"Total\",0 as " +
                            SizeString.Replace(",", "\",0 as \"") + " " + Environment.NewLine +
                            "FROM (" + Environment.NewLine +
                            " SELECT 0 as \"LineId\",	B.\"LineId\" as \"RCount\", \"U_ColourCode\",\"U_ColourName\",0 as \"Total\" " + Environment.NewLine +
                            " FROM \"@FIL_MR_PSMST\" A   " + Environment.NewLine +
                            "    INNER JOIN \"@FIL_MR_PSMCO\" B ON A.\"Code\"=B.\"Code\"  And B.\"U_ColourAppl\"='Y' " + Environment.NewLine +
                            "    And A.\"U_SizeAppl\"='Y' " + Environment.NewLine +
                            " where A.\"Code\"='" + oETStyleNo.Value + "'  " + Environment.NewLine +
                            " group by B.\"LineId\",\"U_ColourCode\",\"U_ColourName\" " + Environment.NewLine +
                            " )V1 ORDER BY V1.\"RCount\";";
                }
                else
                {
                    qStr = " select A.\"U_SizeCode\" " + Environment.NewLine +
                            "from \"@FIL_DR_OQUT\" A " + Environment.NewLine +
                            "    INNER JOIN \"OQUT\" B ON B.\"U_CRSZNTRY\"=A.\"DocEntry\"   " + Environment.NewLine +
                            "    INNER JOIN \"QUT1\" C ON C.\"DocEntry\"=B.\"DocEntry\" AND A.\"U_ColourCode\"=C.\"U_FGCOLOUR\" AND A.\"U_SizeCode\"=C.\"U_FGSIZE\"  " + Environment.NewLine +
                            "    INNER JOIN \"@FIL_MR_PSMST\" D ON D.\"Code\"=C.\"U_StyleCode\" AND D.\"U_SizeCode\"=C.\"U_FGSIZE\" AND D.\"U_SizeAppl\"='Y'  " + Environment.NewLine +
                            "    INNER JOIN \"@FIL_MR_STM1\" E ON D.\"U_SizeType\"=E.\"Code\" AND D.\"U_SizeCode\"=E.\"U_SizeCode\"   " + Environment.NewLine +
                            " where A.\"DocEntry\"='" + pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().TrimEnd() + "' " + Environment.NewLine +
                            "  group BY E.\"U_ORDER\",A.\"U_SizeCode\" " + Environment.NewLine +
                            "   order by E.\"U_ORDER\",A.\"U_SizeCode\"   ";

                    SAPbobsCOM.Recordset SizerSet1 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    SizerSet1.DoQuery(qStr);
                    string SizeString = "";

                    while (!SizerSet1.EoF)
                    {
                        SizeString += "sum(CASE WHEN A.\"U_SizeCode\"='" + SizerSet1.Fields.Item("U_SizeCode").Value.ToString() +
                                      "' THEN \"U_Qty\" ELSE 0 END) \"" + SizerSet1.Fields.Item("U_SizeCode").Value.ToString() + "\"";

                        SizerSet1.MoveNext();

                        if (!SizerSet1.EoF)
                        {
                            SizeString += ",";
                        }
                    }

                    qStr = "SELECT \"U_ColourName\" \"Colour Name\",\"U_ColourCode\" \"Colour Code\",\"U_TotalQty\" \"Total\"," + SizeString + " " + Environment.NewLine +
                           " FROM  \"@FIL_DR_OQUT\" A  " + Environment.NewLine +
                           "    where A.\"DocEntry\"='" + pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().TrimEnd() + "' " + Environment.NewLine +
                           " GROUP BY \"U_ColourName\",\"U_ColourCode\",\"U_TotalQty\" ;";
                }
                Global.oGrid = (SAPbouiCOM.Grid)pform.Items.Item("SCGrid").Specific;
                Global.oDataTable = pform.DataSources.DataTables.Item("DT_0");

                Global.oDataTable.ExecuteQuery(qStr);
                Global.oGrid.DataTable = Global.oDataTable;

                Global.oGridColumn = Global.oGrid.Columns.Item("Colour Name");
                Global.oGridColumn.Editable = false;
                Global.oGridColumn = Global.oGrid.Columns.Item("Colour Code");
                Global.oGridColumn.Editable = false;
                Global.oGridColumn = Global.oGrid.Columns.Item("Total");
                Global.oGridColumn.Editable = false;

                Global.oGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error in LoadGrid: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void LoadMatrix(ref SAPbouiCOM.Form pForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;
                SAPbouiCOM.DataTable oDataTable = pForm.DataSources.DataTables.Item("DT_0");
                double TotalQty = Convert.ToDouble(((SAPbouiCOM.EditText)pForm.Items.Item("ETQty").Specific).Value);
                Global.oEdit = (SAPbouiCOM.EditText)pForm.Items.Item("ETStyleNo").Specific;
                Global.oColumn = oMatrix.Columns.Item("U_FGCOLOUR");
                Global.oColumn.Editable = true;
                Global.oColumn = oMatrix.Columns.Item("U_FGSIZE");
                Global.oColumn.Editable = true;


                for (int j = 0; j <= oDataTable.Rows.Count - 1; j++)
                {
                    string qStr = @"Select A.""ItemCode"", A.""U_ColourCode"",B.""U_ColourName"", A.""U_SizeCode"",C.""U_SizeName""
                    From ""OITM"" A
                    Inner Join ""@FIL_MR_PSMCO"" B On A.""U_StyleNo""=B.""Code"" And A.""U_ColourCode""=B.""U_ColourCode""
                    Inner Join ""@FIL_MR_PSMST"" C On A.""U_StyleNo""=C.""Code"" And A.""U_SizeCode""=C.""U_SizeCode""
                    Where A.""U_StyleNo""='" + Global.oEdit.Value + @"'
                    And B.""U_ColourAppl""='Y' And C.""U_SizeAppl""='Y'
                    And A.""U_ColourCode""='" + oDataTable.Columns.Item("Colour Code").Cells.Item(j).Value + @"'
                    And A.""U_MAINFG""='Y'
                    Order by B.""LineId"", C.""LineId""";

                    SAPbobsCOM.Recordset ColourSizerSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    ColourSizerSet.DoQuery(qStr);
                    oMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;

                    while (!ColourSizerSet.EoF)
                    {
                        //object cellObj = oDataTable.Columns.Item(ColourSizerSet.Fields.Item("U_SizeCode").Value)
                        //      .Cells.Item(j).Value;
                        double cellValue = Convert.ToDouble(oDataTable.Columns.Item(ColourSizerSet.Fields.Item("U_SizeCode").Value).Cells.Item(j).Value.ToString());

                        if (cellValue > 0)
                        {
                            Global.G_UI_Application.StatusBar.SetText("Item Generation for " + ColourSizerSet.Fields.Item("ItemCode").Value,
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(oMatrix.RowCount).Specific).Value =
                             ColourSizerSet.Fields.Item("ItemCode").Value.ToString();

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLOUR").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                              ColourSizerSet.Fields.Item("U_ColourCode").Value.ToString();

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLRNM").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                            ColourSizerSet.Fields.Item("U_ColourName").Value.ToString();

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGSIZE").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                                ColourSizerSet.Fields.Item("U_SizeCode").Value.ToString();


                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_StyleCode").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                                pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_StyleNo", 0).Trim();

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_BUYRSTCD").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                                pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_BSTYLENO", 0).Trim();

                            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(oMatrix.RowCount - 1).Specific).Value =
                                oDataTable.Columns.Item(ColourSizerSet.Fields.Item("U_SizeCode").Value).Cells.Item(j).Value == null
                                    ? ""
                                    : oDataTable.Columns.Item(ColourSizerSet.Fields.Item("U_SizeCode").Value).Cells.Item(j).Value.ToString();

                            TotalQty += Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(oMatrix.RowCount - 1).Specific).Value);
                        }

                        ColourSizerSet.MoveNext();
                    }
                }

             ((SAPbouiCOM.EditText)pForm.Items.Item("ETQty").Specific).Value = TotalQty.ToString();


                Global.oColumn = oMatrix.Columns.Item("U_FGCOLOUR");
                Global.oColumn.Editable = false;
                Global.oColumn = oMatrix.Columns.Item("U_FGSIZE");
                Global.oColumn.Editable = false;

            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error in Load Matrix: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void InsertSizeDetails(SAPbouiCOM.Form pForm, string ObjType, string ObjEntry, int SizeEntry)
        {
            SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string qStr = string.Empty;

            // --- 1. Get next SizeEntry if 0 ---
            if (SizeEntry == 0)
            {
                qStr = "SELECT IFNULL(MAX(\"DocEntry\"),0)+1 \"SizeEntry\" FROM \"@FIL_DR_OQUT\"";
                rSet.DoQuery(qStr);
                SizeEntry = Convert.ToInt32(rSet.Fields.Item("SizeEntry").Value);
            }
            else
            {
                if (ObjType != "112")
                {
                    qStr = $"SELECT * FROM \"OQUT\" WHERE \"U_CRSZNTRY\"='{SizeEntry.ToString().TrimEnd()}'";
                    rSet.DoQuery(qStr);

                    if (rSet.RecordCount > 0)
                    {
                        qStr = "SELECT IFNULL(MAX(\"DocEntry\"),0)+1 \"SizeEntry\" FROM \"@FIL_DR_OQUT\"";
                        rSet.DoQuery(qStr);
                        SizeEntry = Convert.ToInt32(rSet.Fields.Item("SizeEntry").Value);
                    }
                }
            }

            // --- 2. Loop through DataTable rows ---
            Global.oEdit = (SAPbouiCOM.EditText)pForm.Items.Item("ETStyleNo").Specific;
            SAPbouiCOM.DataTable oDataTable = pForm.DataSources.DataTables.Item("DT_0");
            double TotalQty = 0;
            string qStr1 = string.Empty;
            int i = 1;

            for (int j = 0; j < oDataTable.Rows.Count; j++)
            {
                qStr =
                        "Select  A.\"ItemCode\", A.\"U_ColourCode\",B.\"U_ColourName\", A.\"U_SizeCode\" " + Environment.NewLine +
                        " From   \"OITM\" A   " + Environment.NewLine +
                        "    Inner Join \"@FIL_MR_PSMCO\" B On A.\"U_StyleNo\"=B.\"Code\" And A.\"U_ColourCode\"=B.\"U_ColourCode\"  " + Environment.NewLine +
                        "    Inner Join \"@FIL_MR_PSMST\" C On A.\"U_StyleNo\"=C.\"Code\" And A.\"U_SizeCode\"=C.\"U_SizeCode\"  " + Environment.NewLine +
                        $" Where   A.\"U_StyleNo\"='{Global.oEdit.Value}' And B.\"U_ColourAppl\"='Y' And C.\"U_SizeAppl\"='Y'  " + Environment.NewLine +
                        $"   AND A.\"U_ColourCode\"='{oDataTable.Columns.Item("Colour Code").Cells.Item(j).Value}' " + Environment.NewLine +
                        " Order by B.\"LineId\", C.\"LineId\" ";



                SAPbobsCOM.Recordset ColourSizerSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                ColourSizerSet.DoQuery(qStr);

                while (!ColourSizerSet.EoF)
                {
                    string colourCode = ColourSizerSet.Fields.Item("U_ColourCode").Value.ToString();
                    string colourName = ColourSizerSet.Fields.Item("U_ColourName").Value.ToString();
                    string sizeCode = ColourSizerSet.Fields.Item("U_SizeCode").Value.ToString();
                    //string colourName = oDataTable.Columns.Item("Colour Name").Cells.Item(j).Value?.ToString() ?? "";
                    string qty = oDataTable.Columns.Item(sizeCode).Cells.Item(j).Value?.ToString() ?? "0";
                    string totalQty = oDataTable.Columns.Item("Total").Cells.Item(j).Value?.ToString() ?? "0";


                    qStr1 += Environment.NewLine +
                                 $" INSERT INTO \"@FIL_DR_OQUT\"(\"DocEntry\", \"LineId\", \"Object\", \"U_ColourCode\", \"U_ColourName\", \"U_SizeCode\", \"U_Qty\", \"U_TotalQty\") " +
                                 $" SELECT '{SizeEntry}', '{i}', '23', '{colourCode}', '{colourName}', '{sizeCode}', '{qty}', '{totalQty}' FROM DUMMY; ";

                    i++;
                    ColourSizerSet.MoveNext();
                }
            }

            // --- 3. Update or cleanup records ---
            if (!string.IsNullOrEmpty(qStr1))
            {
                if (ObjType == "112")
                {
                    qStr1 += Environment.NewLine +
                             $"UPDATE {(ObjType == "112" ? "\"ODRF\"" : "\"OQUT\"")} SET \"U_CRSZNTRY\"='{SizeEntry}' WHERE \"DocEntry\"='{ObjEntry}'";
                }
            }

            if (ObjType != "112")
            {
                rSet.DoQuery($"SELECT * FROM \"OQUT\" WHERE \"U_CRSZNTRY\"='{SizeEntry.ToString().TrimEnd()}'");
                if (rSet.RecordCount == 0)
                {
                    rSet.DoQuery($"DELETE FROM \"@FIL_DR_OQUT\" WHERE \"DocEntry\"='{SizeEntry.ToString().TrimEnd()}'");
                }
            }

            if (ObjType == "112")
            {
                rSet.DoQuery($"SELECT * FROM \"ODRF\" WHERE \"DocEntry\"='{ObjEntry.ToString().TrimEnd()}'");
                if (rSet.RecordCount > 0)
                {
                    rSet.DoQuery($"SELECT * FROM \"OQUT\" WHERE \"U_CRSZNTRY\"='{SizeEntry.ToString().TrimEnd()}'");
                    if (rSet.RecordCount == 0)
                    {
                        rSet.DoQuery($"DELETE FROM \"@FIL_DR_OQUT\" WHERE \"DocEntry\"='{SizeEntry.ToString().TrimEnd()}'");
                    }
                }
            }

            // --- 4. Execute accumulated inserts ---
            if (!string.IsNullOrEmpty(qStr1))
            {
                SAPbobsCOM.Recordset execSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string qStr2 = "DO " + Environment.NewLine + "BEGIN ";
                qStr1 = qStr2 + qStr1 + Environment.NewLine + "END;";
                execSet.DoQuery(qStr1);


                ((SAPbouiCOM.EditText)pForm.Items.Item("ETCRSZNTRY").Specific).Value = SizeEntry.ToString();
            }
        }


        private void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (BusinessObjectInfo.BeforeAction == false && BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD)
            {
                Global.G_Form = Global.G_UI_Application.Forms.Item(BusinessObjectInfo.FormUID);
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "149":
                        {

                            try
                            {
                                Global.G_Form.Freeze(true);
                                LoadGrid(ref Global.G_Form, true);
                                Global.G_Form.Freeze(false);
                            }
                            catch (Exception ex)
                            {
                                Global.G_Form.Freeze(false);
                            }


                            break;
                        }
                }
            }
            else if (BusinessObjectInfo.BeforeAction == true && BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD)
            {
                Global.G_Form = Global.G_UI_Application.Forms.Item(BusinessObjectInfo.FormUID);
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "149":
                        {
                            try
                            {
                                Global.G_Form.Freeze(true);

                                string ObjectType = BusinessObjectInfo.Type;
                                //XmlDocument xmlobjEntry = new XmlDocument();
                                //xmlobjEntry.LoadXml(BusinessObjectInfo.ObjectKey);
                                //int ObjectEntry = Convert.ToInt32(xmlobjEntry.SelectSingleNode("//DocEntry").InnerText);

                                int SizeEntry = string.IsNullOrEmpty(((SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific).Value)
                                    ? 0
                                    : Convert.ToInt32(((SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific).Value);

                                try
                                {
                                    Global.oComp.StartTransaction();

                                    if (ObjectType == "112")
                                    {
                                        InsertSizeDetails(Global.G_Form, "", "", SizeEntry);
                                    }

                                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                }
                                catch (Exception ex)
                                {
                                    try
                                    {
                                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                    }
                                    catch { }

                                    try
                                    {
                                        Global.oComp.StartTransaction();

                                        if (ObjectType == "112")
                                        {
                                            InsertSizeDetails(Global.G_Form, "", "", SizeEntry);
                                        }

                                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                    }
                                    catch (Exception ex2)
                                    {
                                        Global.G_UI_Application.StatusBar.SetText(ex2.Message, SAPbouiCOM.BoMessageTime.bmt_Short,
                                             SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                        try
                                        {
                                            Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                        }
                                        catch { }
                                    }
                                }

                                Global.G_Form.Freeze(false);
                            }
                            catch (Exception ex)
                            {
                                Global.G_Form.Freeze(false);
                            }


                            break;
                        }
                }
            }

        }
    }
}
