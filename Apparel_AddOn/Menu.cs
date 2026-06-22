using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Apparel_AddOn.Helper;
using Apparel_AddOn.Resources;
using System.Linq;
using System.Xml;
using System.IO;
namespace Apparel_AddOn
{
    class Menu
    {
        public void BasicStart()
        {
            string _AddonId = "2001";
            if (CompanyConnection(_AddonId))
            {
                //Main Module
                CreateMainMenu("43520", "APP", "Apparel", 18, 2, true);

                //Parent Section
                CreateMainMenu("APP", "APP_STP", "Setup", 0, 2, false);
                CreateMainMenu("APP", "APP_MST", "Master", 1, 2, false);
                CreateMainMenu("APP", "APP_TRN", "Transaction", 2, 2, false);

                //Apparel -> Setup
                CreateMainMenu("APP_STP", "APP_STP_BRNDMSTR", "Brand Master ", 1, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_CUSBRND", "Customer Brand MAP ", 2, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SZPRMSTR", "Size Parameter Master", 3, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_CLRMSTR", "Color Master ", 4, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_STYLDEPT", "Style Department ", 5, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PSTNMSTR", "Position Master ", 6, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODLN", "Product Line ", 7, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODGRP", "Product Group ", 8, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODCAT", "Product Category", 9, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODTYPE", "Product Type", 10, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SESNMSTR", "Season Master", 11, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SUBDIV", "Sub Division", 12, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_USETYPE", "Use Type", 13, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PORTMSTR", "Port Master", 14, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SZGRPMSTR", "Size Group Master", 15, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_FBNKMSTR", "First Bank Master", 16, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SBNKMSTR", "Second Bank Master", 17, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SLVTPMSTR", "Sleeve Type Master", 18, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_OTHCSTPRM", "Other Cost Param", 19, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_GENTYMSTR", "Gender Type Master", 20, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_GRMNTSTYMSTR", "Garments Type Master", 21, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SIZEMSTR", "Size Master", 22, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_ORDRQUNSEG", "Order Quantity Master", 23, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SMPLTYPE", "Sample Type", 24, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SMPLSTUS", "Sample Status", 25, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_COMSTGES", "Components Stages", 26, 1, false);

                //Apparel ->  Master
                CreateMainMenu("APP_MST", "APP_MST_SGMNTMSTR", "Segment Master ", 1, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_SZTYPMSTR", "Size Type Master", 2, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_ROUTNG", "Routing", 3, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_CPMSTR", "CPM Master", 4, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_OTHRCSTPRM", "Other Cost Template", 5, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_IESAM", "IE SAM Master", 5, 1, false);

                //Apparel -> Transcation
                CreateMainMenu("APP_TRN", "APP_TRN_COM", "Commercial ", 0, 2, false);
                CreateMainMenu("APP_TRN", "APP_TRN_SAM", "Sampling", 1, 2, false);
                CreateMainMenu("APP_TRN", "APP_TRN_MRD", "Merchandising ", 2, 2, false);

                //Apparel -> Transaction -> Commercial
                CreateMainMenu("APP_TRN_COM", "APP_TRN_COM_EXP", "Export LC ", 0, 2, false);
                CreateMainMenu("APP_TRN_COM", "APP_TRN_COM_IMP", "Import LC ", 1, 2, false);

                //Apparel -> Transaction -> Commercial -> Export LC
                CreateMainMenu("APP_TRN_COM_EXP", "APP_TRN_COM_EXP_MLC", "Master LC", 1, 1, false);
                CreateMainMenu("APP_TRN_COM_EXP", "APP_TRN_COM_EXP_AMD", "Master LC Amendment", 2, 1, false);

                //Apparel -> Transaction -> Commercial -> Import  LC
                CreateMainMenu("APP_TRN_COM_IMP", "APP_TRN_COM_IMP_B2B_LC", "Import LC/TT/RTGS LC(B2B)", 0, 1, false);
                CreateMainMenu("APP_TRN_COM_IMP", "APP_TRN_COM_IMP_B2B_AMD", "Import LC/TT/RTGS LC Ammendment (B2B)", 1, 1, false);

                //Apparel -> Transaction -> Sampling
                CreateMainMenu("APP_TRN_SAM", "APP_TRN_SAM_SM", "Sample Master", 1, 1, false);
                CreateMainMenu("APP_TRN_SAM", "APP_TRN_SAM_SPC", "Sample PreCositng",2, 1, false);

                //Apparel -> Transaction -> Merchandising 
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_SM", "Style Master", 1, 1, false);
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_SCON", "Sales Contract ", 2, 2, false);

                //Apparel -> Transaction -> Merchandising->Sales Contract
                CreateMainMenu("APP_TRN_MRD_SCON", "APP_TRN_MRD_SCON_SC", "Sales Contract", 1, 1, false);
                CreateMainMenu("APP_TRN_MRD_SCON", "APP_TRN_MRD_SCON_SC_AMD", "Sales Contract Ammendment", 2, 1, false);

                //Apparel -> Transaction -> Merchandising -> OTT
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_OTT", "OTT", 3, 1, false);

                //Apparel -> Transaction -> Merchandising -> Draft Order
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_DRO", "Draft Order", 4, 1, false);

                //Apparel -> Transaction -> Merchandising -> CAD Fabric Consuption - FHR
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_CAD", "CAD", 5, 1, false);

                //Apparel -> Transaction -> Merchandising -> Costing
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_CST", "Procurement Costing", 6, 1, false);

                //Apparel -> Transaction -> Merchandising -> Material requirements planning  - FHR
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_MRP", "MRP", 7, 1, false);

                //Apparel -> Transaction -> Merchandising -> Down Payment  - FHR
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_DP", "Down Payment", 8, 1, false);
              //  Global.GFunc.AddRPTUDO();


            }

        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                //MasterLC
                if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_COM_EXP_MLC")
                {
                    string formUID = "FIL_FRM_MLC"; // Unique ID for the form
                                                    // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    MasterLC activeForm = new MasterLC();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_MLC");
               
                    try
                    {
                        InitializeMasterLCForm(oForm);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }



                }
                //MasterLCAMENDMENT
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_COM_EXP_AMD")
                {
                    string formUID = "FIL_FRM_MLC_AMEND"; // Unique ID for the form
                                                          // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    MasterLCAmendment activeForm = new MasterLCAmendment();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_MLC_AMEND");

                    try
                    {
                        InitializeMLCAmmendmentForm(oForm);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //B2B_LC
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_COM_IMP_B2B_LC")
                {
                    string formUID = "FIL_FRM_B2BLC"; // Unique ID for the form
                                                      // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    B2BLC activeForm = new B2BLC();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC");
                   
                    try
                    {
                        InitializeB2BLCForm(oForm);
                        oForm.ReportType = "A004";
                       
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //B2B_LC_AMENDMENT
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_COM_IMP_B2B_AMD")
                {
                    string formUID = "FIL_FRM_B2BLC_AMEND"; // Unique ID for the form
                                                            // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    B2BLCAmendment activeForm = new B2BLCAmendment();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC_AMEND");

                    try
                    {
                        InitializeB2BLCAmendForm(oForm);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Sales Contract
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_SCON_SC")
                {
                    string formUID = "FIL_FRM_SALCON"; // Unique ID for the form
                                                       // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    SalesContract activeForm = new SalesContract();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SALCON");
                    try
                    {
                        InitializeSalesContractForm(oForm);

                        //SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                        //SAPbouiCOM.Column oQuanCol = oMatrix.Columns.Item("CLQUAN");
                        //oQuanCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                        //SAPbouiCOM.Column oValCol = oMatrix.Columns.Item("CLVALUE");
                        //oValCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                        //SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;
                        //SAPbouiCOM.Column oTotalCol = oMatrix2.Columns.Item("CLTOLQTY");
                        //oTotalCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                        //SAPbouiCOM.Column oDocCol = oMatrix2.Columns.Item("CLDOCTOL");
                        //oDocCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Sales Contract Amendment
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_SCON_SC_AMD")
                {
                    string formUID = "FIL_FRM_SCAMEND"; // Unique ID for the form
                                                        // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    SalesContractAmendment activeForm = new SalesContractAmendment();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SCAMEND");
                    try
                    {
                        IntSalesContractAmendForm(oForm);

                        //SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                        //SAPbouiCOM.Column oQuanCol = oMatrix.Columns.Item("CLQUAN");
                        //oQuanCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                        //SAPbouiCOM.Column oValCol = oMatrix.Columns.Item("CLVALUE");
                        //oValCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                        //SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;
                        //SAPbouiCOM.Column oTotalCol = oMatrix2.Columns.Item("CLTOLQTY");
                        //oTotalCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                        //SAPbouiCOM.Column oDocCol = oMatrix2.Columns.Item("CLDOCTOL");
                        //oDocCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Style Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_SM")
                {
                    string formUID = "FIL_FRM_STYLMSTR"; // Unique ID for the form
                                                         // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }


                    StyleMaster activeForm = new StyleMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
                    try
                    {
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            // Style Code
                            GenerateAndSetStyleCode(oForm);

                        }
                        //button 
                        SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                        SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                        oBtnItmCr.Enabled = false;
                        oBtnItmTx.Enabled = false;

                        // Price List combo
                        string sqlQuerybpl = @"SELECT ""ListNum"", ""ListName"" FROM ""OPLN""";
                        SAPbouiCOM.ComboBox CBPRCLST = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRCLST").Specific;
                        Global.GFunc.setComboBoxValue(CBPRCLST, sqlQuerybpl);

                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific).Value = "USD";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETUOM").Specific).Value = "Pcs";
                        //// auto currency set
                        //select "CurrCode" from "OCRN";
                        //ETCURR 


                        //Active auto select
                        SAPbouiCOM.CheckBox oCheck = (SAPbouiCOM.CheckBox)oForm.Items.Item("CKACTIVE").Specific;
                        oCheck.Checked = true;


                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //OTT - FHR
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_OTT")
                {
                    string formUID = "FIL_FRM_OTT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    OTT activeForm = new OTT();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_OTT");
                    try
                    {
                        GlobalFunction gf = new GlobalFunction();
                        int num = gf.GetDocNum("@FIL_DH_PLANOTT");

                        SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                        etDocNum.Value = num.ToString();

                        //Init Matrix
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                        SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");

                        //FHR~Column Sum 
                        SAPbouiCOM.Column oQty; oQty = (SAPbouiCOM.Column)oMatrix.Columns.Item("CLQTY"); oQty.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                        //New Line Add
                        int lastRow = oMatrix.RowCount;
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }

                }
                //CAD - FHR
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_CAD")
                {
                    string formUID = "FIL_FRM_CAD";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    CAD activeForm = new CAD();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
                    try
                    {
                        oForm.Freeze(true);
                        GlobalFunction gf = new GlobalFunction();
                        int num = gf.GetDocNum("@FIL_DH_CADFABCN");

                        SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                        etDocNum.Value = num.ToString();

                        //Init Matrix Colour
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                        SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                        //New Line Add
                        int lastRow = oMatrix.RowCount;
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");

                        //Init Matrix Size
                        SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                        //FHR~Column Sum 
                        SAPbouiCOM.Column oRatio; oRatio = (SAPbouiCOM.Column)oMatrix2.Columns.Item("CLRATIO"); oRatio.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                        oMatrix2.Clear();

                        ////Init Matrix Mercehndise Consumption
                        SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                        SAPbouiCOM.DBDataSource DBDataSourceLine3 = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                        //New Line Add
                        int lastRow3 = oMatrix3.RowCount;
                        Global.GFunc.SetNewLine(oMatrix3, DBDataSourceLine3, lastRow3 + 1, "");

                        ////Init Matrix CAD Consumptionm
                        SAPbouiCOM.Matrix oMatrix4 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                        oMatrix4.Clear();
                        oForm.Freeze(false);

                        ////UseType Combo Box Mercehndise Consumption
                        SAPbouiCOM.Column oColumn = oMatrix3.Columns.Item("CLUSETYP"); // ComboBox column
                        string sql = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_POSITION"" WHERE ""U_ACTIVE"" ='Y';";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS.DoQuery(sql);

                        while (!oRS.EoF)
                        {
                            oColumn.ValidValues.Add(
                                oRS.Fields.Item("Code").Value.ToString(),
                                oRS.Fields.Item("Name").Value.ToString()
                            );
                            oRS.MoveNext();
                        }

                        //////UseType Combo Box CAD Consumption
                        //SAPbouiCOM.Column oColumn2 = oMatrix4.Columns.Item("CLUSETYP"); // ComboBox column
                        //while (!oRS.EoF)
                        //{
                        //    oColumn2.ValidValues.Add(
                        //        oRS.Fields.Item("Code").Value.ToString(),
                        //        oRS.Fields.Item("Name").Value.ToString()
                        //    );
                        //    oRS.MoveNext();
                        //}


                    }
                    catch (Exception e)
                    {
                        oForm.Freeze(false);
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }

                }

                //Sales Quotation
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_DRO")
                {
                    try
                    {
                        string formType = "2049";
                        foreach (SAPbouiCOM.Form form in Application.SBO_Application.Forms)
                        {
                            if (form.TypeEx == formType)
                            {
                                form.Select();
                                Application.SBO_Application.StatusBar.SetText("Sales Order Draft form is already open.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                                return;
                            }
                        }

                        // Activate (open) the Sales Order Draft form
                        Application.SBO_Application.ActivateMenuItem("2049");
                        //SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;

                        //Application.SBO_Application.StatusBar.SetText("Sales Order Draft form opened successfully.",
                        //    SAPbouiCOM.BoMessageTime.bmt_Short,
                        //    SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error while opening Sales Order Draft form: " + ex.Message);
                    }
                }
                //Procurement Costing
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_CST")
                {
                   
                    string formUID = "FIL_FRM_COSTING"; // Unique ID for the form
                                                        // Check if the form is already open
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    Costing activeForm = new Costing();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_COSTING");


                   // Global.G_UI_Application.Menus.Item("519").Enabled = true;    
                  //  Global.G_UI_Application.Menus.Item("5895").Enabled = true; 
                  //  Global.G_UI_Application.ActivateMenuItem("521");
                    try
                    {
                        //Price List
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXFBRIC").Specific;
                        SAPbouiCOM.Column oColumn = oMatrix.Columns.Item("CLPRCLST"); // ComboBox column
                        string sqlQuerybpl = @"SELECT ""ListNum"", ""ListName"" FROM ""OPLN""";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS.DoQuery(sqlQuerybpl);

                        while (!oRS.EoF)
                        {
                            oColumn.ValidValues.Add(
                                oRS.Fields.Item("ListNum").Value.ToString(),
                                oRS.Fields.Item("ListName").Value.ToString()
                            );
                            oRS.MoveNext();
                        }

                        //Parameter
                        SAPbouiCOM.Matrix MTXOHCST = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOHCST").Specific;
                        SAPbouiCOM.Column oColumncst = MTXOHCST.Columns.Item("CLPARAM"); // ComboBox column
                        string sql = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OTHCPMST"" WHERE ""U_ACTIVE"" ='Y';";
                        SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS2.DoQuery(sql);

                        while (!oRS2.EoF)
                        {
                            oColumncst.ValidValues.Add(
                                oRS2.Fields.Item("Code").Value.ToString(),
                                oRS2.Fields.Item("Name").Value.ToString()
                            );
                            oRS2.MoveNext();
                        }
                        //Order Type
                        SAPbouiCOM.Matrix MTXROUTE = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
                        SAPbouiCOM.Column oColumnrut = MTXROUTE.Columns.Item("CLORDTYP"); // ComboBox column
                        string sqltype = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OQST"" ;";
                        SAPbobsCOM.Recordset oRS3 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS3.DoQuery(sqltype);

                        while (!oRS3.EoF)
                        {
                            oColumnrut.ValidValues.Add(
                                oRS3.Fields.Item("Code").Value.ToString(),
                                oRS3.Fields.Item("Name").Value.ToString()
                            );
                            oRS3.MoveNext();
                        }
                        oForm.ReportType = "A005";

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //MRP - FHR
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_MRP")
                {
                    string formUID = "FIL_FRM_MRP";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    MRP activeForm = new MRP();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_MRP");
                    try
                    {
                        oForm.Freeze(true);
                        InitFormAddMode(ref oForm);
                        SetAutoManagedAttribute(ref oForm);

                        //Payment Terms combobox
                        string rset = $"select \"GroupNum\",\"PymntGroup\" from \"OCTG\"";
                        SAPbouiCOM.ComboBox CBPAYTRM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPAYTRM").Specific;
                        Global.GFunc.setComboBoxValue(CBPAYTRM, rset);

                        //SHipping Type combobox
                        string rset1 = $"select \"TrnspCode\",\"TrnspName\" from \"OSHP\" Where \"Active\" = 'Y'";
                        SAPbouiCOM.ComboBox CBSHPTYP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSHPTYP").Specific;
                        Global.GFunc.setComboBoxValue(CBSHPTYP, rset1);

                        //Ship Form combobox
                        string rset2 = $"select \"Code\",\"Name\" from \"OCRY\"";
                        SAPbouiCOM.ComboBox CBSHPFRM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSHPFRM").Specific;
                        Global.GFunc.setComboBoxValue(CBSHPFRM, rset2);


                        //Purchase Order Series combobox
                        string rset3 = $"select \"Series\",\"SeriesName\" from \"NNM1\" where \"ObjectCode\" = '22' and \"Locked\" = 'N'";
                        SAPbouiCOM.ComboBox CBPOSRI = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPOSRI").Specific;
                        Global.GFunc.setComboBoxValue(CBPOSRI, rset3);

                        oForm.Freeze(false);

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }

                }

                //Down Payment - FHR
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_DP")
                {
                    string formUID = "FIL_FRM_DOWNPAYMT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    DownPayment activeForm = new DownPayment();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_DOWNPAYMT");
                    try
                    {
                        InitDP(formUID);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }



                //_____________________________________________________________________________________Setup ________________________________________________________
                //Brand Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_BRNDMSTR")
                {
                    string formUID = "FIL_FRM_BRND_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    BrandMaster activeForm = new BrandMaster();
                    activeForm.Show();

                }
                //Customer Brand Map
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_CUSBRND")
                {
                    string formUID = "FIL_FRM_CUSBRNDMAP";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    CustomerBrandRelation activeForm = new CustomerBrandRelation();
                    activeForm.Show();

                }
                //Size Param Master 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SZPRMSTR")
                {
                    string formUID = "FIL_FRM_SZPRMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SizeParamMaster activeForm = new SizeParamMaster();
                    activeForm.Show();

                }
                //Color Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_CLRMSTR")
                {
                    string formUID = "FIL_FRM_CLR_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ColorMaster activeForm = new ColorMaster();
                    activeForm.Show();
                }
                // Style Department
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_STYLDEPT")
                {
                    string formUID = "FIL_FRM_STYL_DEPT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    StyleDepartment activeForm = new StyleDepartment();
                    activeForm.Show();

                }
                // Positon Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PSTNMSTR")
                {
                    string formUID = "FIL_FRM_PSTN_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    PositionMaster activeForm = new PositionMaster();
                    activeForm.Show();
                }
                // Product Line Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODLN")
                {
                    string formUID = "FIL_FRM_PROD_LN";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductLine activeForm = new ProductLine();
                    activeForm.Show();
                }
                // Product Group Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODGRP")
                {
                    string formUID = "FIL_FRM_PROD_GRP";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductGroup activeForm = new ProductGroup();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_PROD_GRP");
                    try
                    {
                        //product Type combobox
                        string sqlQuerybpl = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_PRDTYPE"" where ""U_ACTIVE""='Y'";
                        SAPbouiCOM.ComboBox CBTYPE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBTYPE").Specific;
                        Global.GFunc.setComboBoxValue(CBTYPE, sqlQuerybpl);

                        //Product Line combobox
                        string sqlQuerybpl2 = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OPLM"" where ""U_ACTIVE""='Y' ";
                        SAPbouiCOM.ComboBox CBLINE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBLINE").Specific;
                        Global.GFunc.setComboBoxValue(CBLINE, sqlQuerybpl2);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                // Product Category Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODCAT")
                {
                    string formUID = "FIL_FRM_PROD_CAT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductCategory activeForm = new ProductCategory();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_PROD_CAT");
                    try
                    {
                        //Product group combobox
                        string sqlQuerybpl = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OPGM"" where ""U_ACTIVE""='Y'";
                        SAPbouiCOM.ComboBox CBGROUP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBGROUP").Specific;
                        Global.GFunc.setComboBoxValue(CBGROUP, sqlQuerybpl);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                // Product Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODTYPE")
                {
                    string formUID = "FIL_FRM_PROD_TYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductType activeForm = new ProductType();
                    activeForm.Show();
                }
                // Season Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SESNMSTR")
                {
                    string formUID = "FIL_FRM_SESN_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SeasonMaster activeForm = new SeasonMaster();
                    activeForm.Show();
                }
                // Sub Division Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SUBDIV")
                {
                    string formUID = "FIL_FRM_SUB_DIV";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SubDivision activeForm = new SubDivision();
                    activeForm.Show();
                }
                // Use Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_USETYPE")
                {
                    string formUID = "FIL_FRM_USETYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    UseType activeForm = new UseType();
                    activeForm.Show();
                }
                // Port Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PORTMSTR")
                {
                    string formUID = "FIL_FRM_PORTMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                        SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    PortMaster activeForm = new PortMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_PORTMSTR");
                    try
                    {
                        //Process Combo box
                        string sqlQuery = @"SELECT ""Code"", ""Name"" FROM ""OCRY""";
                        SAPbouiCOM.ComboBox CBCNTRY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY").Specific;   //object defining- Define a combo box
                        Global.GFunc.setComboBoxValue(CBCNTRY, sqlQuery);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                // Size Group Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SZGRPMSTR")
                {
                    string formUID = "FIL_FRM_SZGRPMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SizeGroupMaster activeForm = new SizeGroupMaster();
                    activeForm.Show();
                }
                // Sleeve Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SLVTPMSTR")
                {
                    string formUID = "FIL_FRM_SLVTPMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SleeveTypeMaster activeForm = new SleeveTypeMaster();
                    activeForm.Show();
                }
                // Other Cost Param Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_OTHCSTPRM")
                {
                    string formUID = "FIL_FRM_OTHCSTPRM";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    OtherCostParam activeForm = new OtherCostParam();
                    activeForm.Show();
                }
                // First Bank Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_FBNKMSTR")
                {
                    string formUID = "FIL_FRM_FBNKMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    FirstBankMaster activeForm = new FirstBankMaster();
                    activeForm.Show();
                }
                // Second Bank Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SBNKMSTR")
                {
                    string formUID = "FIL_FRM_SBNKMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SecondBankMaster activeForm = new SecondBankMaster();
                    activeForm.Show();
                }
                // Gender Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_GENTYMSTR")
                {
                    string formUID = "FIL_FRM_GENTYMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    GenderMasterType activeForm = new GenderMasterType();
                    activeForm.Show();
                }
                //// Garments Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_GRMNTSTYMSTR")
                {
                    string formUID = "FIL_FRM_GRMNTSTYMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    GarmentsTypeMaster activeForm = new GarmentsTypeMaster();
                    activeForm.Show();

                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_GRMNTSTYMSTR");
                    try
                    {
                        string sqlQuerybpl = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_PRDTYPE"" where ""U_ACTIVE""='Y'";
                        SAPbouiCOM.ComboBox CBCMPANY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCATGRY").Specific;
                        Global.GFunc.setComboBoxValue(CBCMPANY, sqlQuerybpl);
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }

                }
                //SIZEMSTR
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SIZEMSTR")
                {
                    string formUID = "FIL_FRM_SIZEMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SizeMaster activeForm = new SizeMaster();
                    activeForm.Show();
                }
                //ORDR QUANTITY
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_ORDRQUNSEG")
                {
                    string formUID = "FIL_FRM_ORDRQUNSEG";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ORDRQUANSEG activeForm = new ORDRQUANSEG();
                    activeForm.Show();
                }
                //-------------------------------------------------------------------------------------Master---------------------------------------------------
                // Segment Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_SGMNTMSTR")
                {
                    string formUID = "FIL_FRM_SGMNTMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SegmentMaster activeForm = new SegmentMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SGMNTMSTR");

                    try
                    {
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETMXLEN").Specific).Value = "50";
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Size Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_SZTYPMSTR")
                {
                    string formUID = "FIL_FRM_SZTYPMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SizeTypeMaster activeForm = new SizeTypeMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SZTYPMSTR");

                    try
                    {
                        //product Type combobox
                        string sqlQuerybpl = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_PRDTYPE"" where ""U_ACTIVE""='Y'";
                        SAPbouiCOM.ComboBox CBPRDTYP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDTYP").Specific;
                        Global.GFunc.setComboBoxValue(CBPRDTYP, sqlQuerybpl);

                        //gender combobox
                        string sqlQuerybpl2 = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OPLM"" where ""U_ACTIVE""='Y' ";
                        SAPbouiCOM.ComboBox CBGENTYP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDLN").Specific;
                        Global.GFunc.setComboBoxValue(CBGENTYP, sqlQuerybpl2);

                        //Country combobox
                        string sqlQuerybpl3 = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                        SAPbouiCOM.ComboBox CBCONTRY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCONTRY").Specific;
                        Global.GFunc.setComboBoxValue(CBCONTRY, sqlQuerybpl3);

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Routing
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_ROUTNG")
                {
                    string formUID = "FIL_FRM_ROUTNG";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Routing activeForm = new Routing();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_ROUTNG");
                    SAPbouiCOM.Item oRouteCode = oForm.Items.Item("ETCODE");
                    oRouteCode.Enabled = false;
                    GenerateRouteCode(oForm);

                    try
                    {
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
                        SAPbouiCOM.Column oColumn = oMatrix.Columns.Item("CLCODE"); // ComboBox column
                        string sqlQuery = @"SELECT ""Code"", ""Desc"" FROM ""ORST"" WHERE ""AbsEntry"" > 6;";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS.DoQuery(sqlQuery);

                        while (!oRS.EoF)
                        {
                            oColumn.ValidValues.Add(
                                oRS.Fields.Item("Code").Value.ToString(),
                                oRS.Fields.Item("Desc").Value.ToString()
                            );
                            oRS.MoveNext();
                        }
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //CPM Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_CPMSTR")
                {
                    string formUID = "FIL_FRM_CPMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    CPMMaster activeForm = new CPMMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_CPMSTR");
                    try
                    {

                        var oItem = oForm.Items.Item("STSAMLBL");
                        // Set bold text style
                        oItem.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;

                        //Process Combo box
                        string sqlQuery = @"SELECT ""Code"", ""Desc"" FROM ""ORST"" WHERE ""AbsEntry"" > 6;";
                        SAPbouiCOM.ComboBox CBPRCESS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRCESS").Specific;   //object defining- Define a combo box
                        Global.GFunc.setComboBoxValue(CBPRCESS, sqlQuery);

                        //Order Type 
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPMTR").Specific;
                        SAPbouiCOM.Column oColumn = oMatrix.Columns.Item("CLORDRTY"); // ComboBox column
                        string sql = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OQST"" WHERE ""U_ACTIVE"" ='Y';";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS.DoQuery(sql);

                        while (!oRS.EoF)
                        {
                            oColumn.ValidValues.Add(
                                oRS.Fields.Item("Code").Value.ToString(),
                                oRS.Fields.Item("Name").Value.ToString()
                            );
                            oRS.MoveNext();
                        }
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Other Cost Template
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_OTHRCSTPRM")
                {
                    string formUID = "FIL_FRM_OTHRCSTPRM";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    OtherCostTemplate activeForm = new OtherCostTemplate();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_OTHRCSTPRM");
                    try
                    {
                        //Parameter
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPARAM").Specific;
                        SAPbouiCOM.Column oColumn = oMatrix.Columns.Item("CLPARAM"); // ComboBox column
                        string sql = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_OTHCPMST"" WHERE ""U_ACTIVE"" ='Y';";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        oRS.DoQuery(sql);
                        oColumn.ValidValues.Add("", "");
                        while (!oRS.EoF)
                        {
                            oColumn.ValidValues.Add(
                                oRS.Fields.Item("Code").Value.ToString(),
                                oRS.Fields.Item("Name").Value.ToString()
                            );
                            oRS.MoveNext();
                        }
                        oMatrix.AutoResizeColumns();
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //IE SAM Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_IESAM")
                {
                    string formUID = "FIL_FRM_IESAM";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    IESamMaster activeForm = new IESamMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_IESAM");
                    try
                    {

                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
                        SAPbouiCOM.Column oAmountCol = oMatrix.Columns.Item("CLSAM");
                        oAmountCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }

                //____________________________________________________________________________Sample_____________________________________________________________
                //Sample Type
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SMPLTYPE")
                {
                    string formUID = "FIL_FRM_SMPLTYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SampleType activeForm = new SampleType();
                    activeForm.Show();
                }
                //Sample Status
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SMPLSTUS")
                {
                    string formUID = "FIL_FRM_SMPLSTAT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SampleStatus activeForm = new SampleStatus();
                    activeForm.Show();
                }
                //Component Stages
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_COMSTGES")
                {
                    string formUID = "FIL_FRM_COMSTG";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ComponentStages activeForm = new ComponentStages();
                    activeForm.Show();
                }
                //Sample Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_SAM_SM")
                {
                    string formUID = "FIL_FRM_SMPLMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SampleMaster activeForm = new SampleMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SMPLMSTR");
                    try
                    {
                        SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                        SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                        SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                        SAPbouiCOM.Matrix MTXBYRS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBUYER").Specific;
                        SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                        MTSZ.AutoResizeColumns();
                        MTXCLR.AutoResizeColumns();
                        MTXITM.AutoResizeColumns();
                        MTXBYRS.AutoResizeColumns();
                        MTXATTAC.AutoResizeColumns();

                        //Series Initialization
                        SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DH_SMPLMAST");   //DEFINE  DATASOURCES.
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;                                                                          
                            Global.GFunc.LoadComboBoxSeries(ocmb, "FIL_D_SMPLMAST");  //Object Type
                            string ocmbvalue = ocmb.Selected.Value;
                            long docno = oForm.BusinessObject.GetNextSerialNumber(ocmbvalue, "FIL_D_SMPLMAST"); 
                                                                                                              
                            oDBH.SetValue("DocNum", 0, docno.ToString()); // only set the value in string.
                        }
                        //Date
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCNDT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //Sample PreCositng
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_SAM_SPC")
                {
                    string formUID = "FIL_FRM_SMPLPCST";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SamplePreCosting activeForm = new SamplePreCosting();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SMPLPCST");
                    try
                    {
                        SAPbouiCOM.Matrix MTCMP = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
                        SAPbouiCOM.Matrix MTXOCST = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;


                        MTCMP.AutoResizeColumns();
                        MTXOCST.AutoResizeColumns();


                        //Series Initialization
                        SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;
                            Global.GFunc.LoadComboBoxSeries(ocmb, "FIL_D_PRECOSTING");  //Object Type
                            string ocmbvalue = ocmb.Selected.Value;
                            long docno = oForm.BusinessObject.GetNextSerialNumber(ocmbvalue, "FIL_D_PRECOSTING");

                            oDBH.SetValue("DocNum", 0, docno.ToString()); // only set the value in string.
                        }
                        //Date
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDATE").Specific).Value = DateTime.Now.ToString("yyyyMMdd");

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //------------------------------------------------------------------------------------------------------------------------------------------
                //Add Form Mode Menu
                else if (!pVal.BeforeAction && pVal.MenuUID == "1282")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                InitializeMasterLCForm(oForm);

                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                InitializeB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {
                                InitializeSalesContractForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SGMNTMSTR":
                            {

                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                GenerateAndSetStyleCode(oForm);

                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;

                                // Price List combo
                                string sqlQuerybpl = @"SELECT ""ListNum"", ""ListName"" FROM ""OPLN""";
                                SAPbouiCOM.ComboBox CBPRCLST = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRCLST").Specific;
                                Global.GFunc.setComboBoxValue(CBPRCLST, sqlQuerybpl);

                                //Active auto select
                                SAPbouiCOM.CheckBox oCheck = (SAPbouiCOM.CheckBox)oForm.Items.Item("CKACTIVE").Specific;
                                oCheck.Checked = true;

                                break;
                            }
                        case "FIL_FRM_ROUTNG":
                            {
                                SAPbouiCOM.Item oRouteCode = oForm.Items.Item("ETCODE");
                                oRouteCode.Enabled = false;
                                GenerateRouteCode(oForm);
                                break;
                            }
                        case "FIL_FRM_IESAM":
                            {
                                GenerateIESAMCode(oForm);
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
                                SAPbouiCOM.Column oAmountCol = oMatrix.Columns.Item("CLSAM");
                                oAmountCol.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                                break;
                            }

                        case "FIL_FRM_OTT": //FHR
                            {
                                GlobalFunction gf = new GlobalFunction();
                                int num = gf.GetDocNum("@FIL_DH_PLANOTT");

                                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                                etDocNum.Value = num.ToString();

                                //Init Matrix
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");

                                //FHR~Column Sum 
                                SAPbouiCOM.Column oQty; oQty = (SAPbouiCOM.Column)oMatrix.Columns.Item("CLQTY"); oQty.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                                //New Line Add
                                int lastRow = oMatrix.RowCount;
                                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");
                                oForm.Freeze(false);
                                break;
                            }

                        case "FIL_FRM_CAD": //FHR
                            {
                                try
                                {
                                    oForm.Freeze(true);
                                    GlobalFunction gf = new GlobalFunction();
                                    int num = gf.GetDocNum("@FIL_DH_CADFABCN");

                                    SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                                    etDocNum.Value = num.ToString();

                                    //Init Matrix Colour
                                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                                    SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                                    //New Line Add
                                    int lastRow = oMatrix.RowCount;
                                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");

                                    //Init Matrix Size
                                    SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                                    //FHR~Column Sum 
                                    SAPbouiCOM.Column oRatio; oRatio = (SAPbouiCOM.Column)oMatrix2.Columns.Item("CLRATIO"); oRatio.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                                    oMatrix2.Clear();

                                    //Init Matrix Mercehndise Consumption
                                    SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                                    SAPbouiCOM.DBDataSource DBDataSourceLine3 = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                                    //New Line Add
                                    int lastRow3 = oMatrix3.RowCount;
                                    Global.GFunc.SetNewLine(oMatrix3, DBDataSourceLine3, lastRow3 + 1, "");

                                    //Init Matrix CAD Consumptionm
                                    SAPbouiCOM.Matrix oMatrix4 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                                    oMatrix4.Clear();

                                    oForm.Freeze(false);
                                }
                                catch (Exception)
                                {
                                    oForm.Freeze(false);
                                }

                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR": 
                            {
                                //Initial State
                                SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                                SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                                SAPbouiCOM.Matrix MTXBYRS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBUYER").Specific;
                                SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                                MTSZ.AutoResizeColumns();
                                MTXCLR.AutoResizeColumns();
                                MTXITM.AutoResizeColumns();
                                MTXBYRS.AutoResizeColumns();
                                MTXATTAC.AutoResizeColumns();

                                //Series Initialization
                                SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DH_SMPLMAST");   //DEFINE  DATASOURCES.
                                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                {
                                    SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;
                                    Global.GFunc.LoadComboBoxSeries(ocmb, "FIL_D_SMPLMAST");  //Object Type
                                    string ocmbvalue = ocmb.Selected.Value;
                                    long docno = oForm.BusinessObject.GetNextSerialNumber(ocmbvalue, "FIL_D_SMPLMAST");

                                    oDBH.SetValue("DocNum", 0, docno.ToString()); // only set the value in string.
                                }
                                //Date
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCNDT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
                                //Sample Code Enable
                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = true;
                                //button disable 
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;

                                break;
                            }

                        case "FIL_FRM_MRP":
                            {
                                InitFormAddMode(ref oForm);
                                SetAutoManagedAttribute(ref oForm);

                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }

                    }
                }
                //Find Mode
                else if (!pVal.BeforeAction && pVal.MenuUID == "1281")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                //InitializeMasterLCForm(ofrm);

                                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                                oItem.Enabled = true;

                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                InitializeB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {
                                InitializeSalesContractForm(oForm);
                                break;
                            }
                        case "FIL_FRM_ROUTNG":
                            {
                                SAPbouiCOM.Item oRouteCode = oForm.Items.Item("ETCODE");
                                oRouteCode.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                SAPbouiCOM.Item oStyleId = oForm.Items.Item("ETSTYLID");
                                oStyleId.Enabled = true;
                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                StyleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_COSTING":
                            {

                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = true;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }

                    }
                }
                //First
                else if (!pVal.BeforeAction && pVal.MenuUID == "1288")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {
                                InitializeSalesContractForm(oForm);
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                                int lastRow = oMatrix.RowCount;

                                // If matrix has no rows, directly add a new one
                                if (lastRow == 0)
                                {
                                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                }
                                else
                                {
                                    // Safely check last row data
                                    SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific;
                                    bool lastRowHasData = !string.IsNullOrWhiteSpace(oCell.Value);

                                    if (lastRowHasData)
                                    {
                                        // Add new line if the last row has data
                                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                    }
                                }
                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                StyleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_CPMSTR":
                            {
                                CPMRange(oForm);
                                break;
                            }
                        case "FIL_FRM_COSTING":
                            {
                                CostMatrixSize(oForm);
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }

                    }
                }
                //Previous
                else if (!pVal.BeforeAction && pVal.MenuUID == "1289")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {
                                InitializeSalesContractForm(oForm);
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                                int lastRow = oMatrix.RowCount;

                                // If matrix has no rows, directly add a new one
                                if (lastRow == 0)
                                {
                                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                }
                                else
                                {
                                    // Safely check last row data
                                    SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific;
                                    bool lastRowHasData = !string.IsNullOrWhiteSpace(oCell.Value);

                                    if (lastRowHasData)
                                    {
                                        // Add new line if the last row has data
                                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                    }
                                }
                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                StyleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_COSTING":
                            {
                                CostMatrixSize(oForm);
                                break;
                            }


                        case "FIL_FRM_CPMSTR":
                            {
                                CPMRange(oForm);
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }
                    }
                }
                //Next
                else if (!pVal.BeforeAction && pVal.MenuUID == "1290")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {
                                InitializeSalesContractForm(oForm);
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                                int lastRow = oMatrix.RowCount;

                                // If matrix has no rows, directly add a new one
                                if (lastRow == 0)
                                {
                                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                }
                                else
                                {
                                    // Safely check last row data
                                    SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific;
                                    bool lastRowHasData = !string.IsNullOrWhiteSpace(oCell.Value);

                                    if (lastRowHasData)
                                    {
                                        // Add new line if the last row has data
                                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                    }
                                }
                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                StyleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_CPMSTR":
                            {
                                CPMRange(oForm);
                                break;
                            }
                        case "FIL_FRM_COSTING":
                            {
                                CostMatrixSize(oForm);
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }
                    }
                }
                //Last
                else if (!pVal.BeforeAction && pVal.MenuUID == "1291")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_MLC_AMEND":
                            {
                                LoadPrevLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                LoadPrevB2BLCForm(oForm);
                                break;
                            }
                        case "FIL_FRM_SALCON":
                            {

                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                                int lastRow = oMatrix.RowCount;

                                // If matrix has no rows, directly add a new one
                                if (lastRow == 0)
                                {
                                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                }
                                else
                                {
                                    // Safely check last row data
                                    SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific;
                                    bool lastRowHasData = !string.IsNullOrWhiteSpace(oCell.Value);

                                    if (lastRowHasData)
                                    {
                                        // Add new line if the last row has data
                                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                                    }
                                }
                                //button
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                StyleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_CPMSTR":
                            {
                                CPMRange(oForm);
                                break;
                            }
                        case "FIL_FRM_COSTING":
                            {
                                CostMatrixSize(oForm);
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                break;
                            }
                        case "FIL_FRM_DOWNPAYMT": //FHR
                            {
                                InitDP("FIL_FRM_DOWNPAYMT");
                                break;
                            }
                    }
                }
                //duplicate
                else if (!pVal.BeforeAction && pVal.MenuUID == "1287")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_MLC_AMEND":
                            {
                                InitializeMLCAmmendmentForm(oForm);

                                // Get the DocEntry from EditText (string to int)
                                int docentry = int.Parse(((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value);
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                string query = $@"SELECT ""U_LCAMDNO"" FROM ""@FIL_DH_OLCM"" WHERE ""DocEntry"" = {docentry}";
                                oRec.DoQuery(query);
                                int nextNumber = 1;

                                if (!oRec.EoF && !string.IsNullOrEmpty(oRec.Fields.Item("U_LCAMDNO").Value.ToString()))
                                {
                                    // Parse the existing U_LCAMDNO value (e.g., "1", "2")
                                    int currentVal;
                                    if (int.TryParse(oRec.Fields.Item("U_LCAMDNO").Value.ToString(), out currentVal))
                                    {
                                        nextNumber = currentVal + 1;
                                    }
                                }
                                // Set incremented value in ETLCNO EditText
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETADNTNO").Specific).Value = nextNumber.ToString();

                                SAPbouiCOM.ComboBox oCBCMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
                                oCBCMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                                SAPbouiCOM.ComboBox oCBMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
                                oCBMMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

                                oForm.Items.Item("CBDCTYPE").Enabled = false;
                                oForm.Items.Item("ETLCNO").Enabled = false;
                                oForm.Items.Item("ETSCNO").Enabled = false;
                                //oForm.Items.Item("CBMMODE").Enabled = false;

                                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
                                SAPbouiCOM.Matrix MTXCUSPO = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCUSPO").Specific;
                                Global.GFunc.SetNewLine(MTXCUSPO, DBDataSourceLine, 1, "");

                                break;
                            }
                        case "FIL_FRM_B2BLC_AMEND":
                            {
                                InitializeB2BLCAmendForm(oForm);
                                // Get the DocEntry from EditText (string to int)
                                int docentry = int.Parse(((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value);
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                string query = $@"SELECT ""U_BTBAMNO"" FROM ""@FIL_DH_OLCB"" WHERE ""DocEntry"" = {docentry}";
                                oRec.DoQuery(query);
                                int nextNumber = 1;

                                if (!oRec.EoF && !string.IsNullOrEmpty(oRec.Fields.Item("U_BTBAMNO").Value.ToString()))
                                {
                                    // Parse the existing U_LCAMDNO value (e.g., "1", "2")
                                    int currentVal;
                                    if (int.TryParse(oRec.Fields.Item("U_BTBAMNO").Value.ToString(), out currentVal))
                                    {
                                        nextNumber = currentVal + 1;
                                    }
                                }
                                // Set incremented value in ETLCNO EditText
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value = nextNumber.ToString();

                                SAPbouiCOM.ComboBox oCBCMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMMODE").Specific;
                                oCBCMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                                SAPbouiCOM.ComboBox oCBMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
                                oCBMMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

                                SAPbouiCOM.DBDataSource DBDataSourceLine1 = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB2");
                                SAPbouiCOM.Matrix MTXPIDAT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPIDAT").Specific;
                                Global.GFunc.SetNewLine(MTXPIDAT, DBDataSourceLine1, 1, "");

                                SAPbouiCOM.DBDataSource DBDataSourceLine2 = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB3");
                                SAPbouiCOM.Matrix MTXADTLS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXADTLS").Specific;
                                Global.GFunc.SetNewLine(MTXADTLS, DBDataSourceLine2, 1, "");

                                break;
                            }

                        case "FIL_FRM_SCAMEND":
                            {

                                int docentry = int.Parse(((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value);
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                string query = $@"SELECT ""U_SCAMDNO"" FROM ""@FIL_DH_OSCM"" WHERE ""DocEntry"" = {docentry}";
                                oRec.DoQuery(query);
                                int nextNumber = 1;

                                if (!oRec.EoF && !string.IsNullOrEmpty(oRec.Fields.Item("U_SCAMDNO").Value.ToString()))
                                {
                                    int currentVal;
                                    if (int.TryParse(oRec.Fields.Item("U_SCAMDNO").Value.ToString(), out currentVal))
                                    {
                                        nextNumber = currentVal + 1;
                                    }
                                }
                                // Set incremented value in ETLCNO EditText
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value = nextNumber.ToString();

                                SAPbouiCOM.ComboBox oCBAMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBAMMODE").Specific;
                                oCBAMMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                                SAPbouiCOM.ComboBox oCBACMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBACMODE").Specific;
                                oCBACMODE.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

                                oForm.Items.Item("CBAMMODE").Enabled = true;
                                oForm.Items.Item("CBACMODE").Enabled = false;

                                EnsureLine(oForm, "MTXSTLYD", "@FIL_DR_SCM1");
                                EnsureLine(oForm, "MTXATTAC", "@FIL_DR_SCM3");
                                AddLineIfLastRowHasValue(oForm, "MTXSTLYD", "@FIL_DR_SCM1", "U_STYLENO");
                                AddLineIfLastRowHasValue(oForm, "MTXATTAC", "@FIL_DR_SCM3", "U_ATCHMENT");
                                break;
                            }

                        case "FIL_FRM_COSTING":
                            {
                                GenerateCostCode(oForm);
                                GenerateCostVersion(oForm);

                                SAPbouiCOM.DBDataSource DBDataSourceLine1 = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSMTA");
                                SAPbouiCOM.Matrix MTXTRMAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMAC").Specific;
                                Global.GFunc.SetNewLine(MTXTRMAC, DBDataSourceLine1, 1, "");


                                break;
                            }

                    }
                }
                else if (pVal.BeforeAction && pVal.MenuUID == "FIL_DUPL")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_COSTING":
                            {
                                DuplicateCostingSameForm(oForm);
                                GenerateCostCode(oForm);
                                GenerateCostVersion(oForm);
                                UncheckMatrixCheckboxColumns(oForm, "MTXTRMAC", "CLSIZE", "CLCOLOUR");
                                break;
                            }
                    }
                }
                //Delete Row 
                else if (pVal.BeforeAction && pVal.MenuUID == "1293")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

        private void SetComStageEnable(SAPbouiCOM.Form oForm)
        {
            if (oForm == null)
                return;

            SAPbouiCOM.Item itmCode = oForm.Items.Item("ETCODE");
            SAPbouiCOM.Item itmUOM = oForm.Items.Item("ETUOM");
            SAPbouiCOM.ComboBox cbUOMApply =(SAPbouiCOM.ComboBox)oForm.Items.Item("CBUOMAPL").Specific;


            itmCode.Enabled = (oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE);

           
            string uomApplyVal = "";

            if (cbUOMApply.Selected != null)
                uomApplyVal = cbUOMApply.Selected.Value;

            if (uomApplyVal == "Y")
            {
                itmUOM.Enabled = true;
            }
            else
            {
                itmUOM.Enabled = false;
                ((SAPbouiCOM.EditText)itmUOM.Specific).Value = "";
            }
        }


        private void UncheckMatrixCheckboxColumns(
                                                    SAPbouiCOM.Form oForm,
                                                    string matrixId,
                                                    params string[] colIds)
        {
            SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

            int dataRows = GetBoundDataRows(oForm, mtx);
            if (dataRows <= 0) return;

           
            foreach (string colId in colIds)
            {
                SAPbouiCOM.Column col = mtx.Columns.Item(colId);

              
                string table = col.DataBind.TableName;   
                string alias = col.DataBind.Alias;      
                if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(alias))
                    continue;

                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item(table);
                for (int i = 0; i < dataRows; i++)   
                {
                    ds.SetValue(alias, i, "N");
                }
            }

            mtx.LoadFromDataSource();
        }

        
        private int GetBoundDataRows(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix mtx)
        {
            for (int c = 0; c < mtx.Columns.Count; c++)
            {
                SAPbouiCOM.Column col = mtx.Columns.Item(c);
                string table = col.DataBind.TableName;
                if (!string.IsNullOrWhiteSpace(table))
                {
                    try
                    {
                        return oForm.DataSources.DBDataSources.Item(table).Size;
                    }
                    catch { }
                }
            }
            return mtx.RowCount;
        }


        private void DuplicateCostingSameForm(SAPbouiCOM.Form oForm)
        {
            oForm.Freeze(true);
            try
            {
                // -----------------------------
                // 0) Flush ALL matrices to DS
                // -----------------------------
                // Add your matrix item IDs here (all matrices that write into your child tables)
                string[] matricesToFlush =
                {
                    "MTXTRMAC","MTXOHCST", "MTXFOB", "MTXCOLOR", "MTXFBRIC", "MTXROUTE", "MTXTRMFB", 
                };

                foreach (var mid in matricesToFlush)
                    TryFlushMatrix(oForm, mid);

                // -----------------------------
                // 1) Cache header (U_ only)
                // -----------------------------
                var srcH = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM");
                var headerCache = CacheUdfs(srcH, 0);

                // -----------------------------
                // ALL child tables
                // -----------------------------
                string[] childTables =
                {
                    "@FIL_MR_CSMTA",
                    "@FIL_MR_CSOTHRCS",
                    "@FIL_MR_CSMFOB",
                    "@FIL_MR_CSMCLR",
                    "@FIL_MR_CSMFAB",
                    "@FIL_MR_CSMRS",
                    "@FIL_MR_CSMCST",
                    
                };

                var childCache = new Dictionary<string, List<Dictionary<string, string>>>();

                foreach (var table in childTables)
                {
                    var ds = TryGetDS(oForm, table);
                    if (ds == null) continue;

                    childCache[table] = CacheChildUdfs(ds);
                }

                // -----------------------------
                // 3) Switch to ADD mode (clears form)
                // -----------------------------
                Application.SBO_Application.ActivateMenuItem("1282"); // Add

                // Re-grab DS after Add (important)
                var dstH = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM");

                // -----------------------------
                // 4) Restore header U_ fields
                // -----------------------------
                ApplyUdfs(dstH, 0, headerCache);

                // Clear header keys/system fields so SAP creates a NEW document
                ClearHeaderKeys(dstH);

                // -----------------------------
                // 5) Restore each child table
                // -----------------------------
                foreach (var kv in childCache)
                {
                    string table = kv.Key;
                    var rows = kv.Value;

                    var dstChild = TryGetDS(oForm, table);
                    if (dstChild == null) continue;

                    ReplaceChildRows(dstChild, rows);
                }

                // -----------------------------
                // 6) Reload matrices from DS
                // -----------------------------
                // Map each child table to the matrix item that displays it.
                // (If a table has no matrix, just omit it.)
                var tableToMatrix = new Dictionary<string, string>
                {
                    ["@FIL_MR_CSMTA"]    = "MTXTRMAC",
                    ["@FIL_MR_CSOTHRCS"] = "MTXOHCST",
                    ["@FIL_MR_CSMFOB"]   = "MTXFOB",
                    ["@FIL_MR_CSMCLR"]   = "MTXCOLOR",
                    ["@FIL_MR_CSMFAB"]   = "MTXFBRIC",
                    ["@FIL_MR_CSMRS"]    = "MTXROUTE",
                    ["@FIL_MR_CSMCST"]   = "MTXTRMFB",
                    
                };

                foreach (var map in tableToMatrix)
                    TryLoadMatrix(oForm, map.Value);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void ReplaceChildRows(SAPbouiCOM.DBDataSource dstC, List<Dictionary<string, string>> cachedRows)
        {
            // Clear destination table
            while (dstC.Size > 0)
                dstC.RemoveRecord(dstC.Size - 1);

            // Recreate rows
            for (int i = 0; i < cachedRows.Count; i++)
            {
                dstC.InsertRecord(i);
                ApplyUdfs(dstC, i, cachedRows[i]);

                // Clear system/line keys (prevents "already exists" / duplicate line issues)
                ClearChildSystemFields(dstC, i);
            }
        }

        private void ClearHeaderKeys(SAPbouiCOM.DBDataSource ds)
        {
            SafeClear(ds, "DocEntry");
            SafeClear(ds, "Code");
            SafeClear(ds, "Name");
            SafeClear(ds, "LogInst");
        }

        private void ClearChildSystemFields(SAPbouiCOM.DBDataSource ds, int row)
        {
            SafeClear(ds, "DocEntry", row);
            SafeClear(ds, "LineId", row);
            SafeClear(ds, "VisOrder", row);
            SafeClear(ds, "LogInst", row);

            // Sometimes exists in some UDO children (safe to try)
            SafeClear(ds, "Code", row);

        }

        private SAPbouiCOM.DBDataSource TryGetDS(SAPbouiCOM.Form oForm, string table)
        {
            try { return oForm.DataSources.DBDataSources.Item(table); }
            catch { return null; }
        }

        private void TryFlushMatrix(SAPbouiCOM.Form oForm, string matrixItemId)
        {
            try
            {
                var item = oForm.Items.Item(matrixItemId);
                if (item == null) return;

                var mtx = item.Specific as SAPbouiCOM.Matrix;
                mtx?.FlushToDataSource();
            }
            catch { /* ignore */ }
        }

        private void TryLoadMatrix(SAPbouiCOM.Form oForm, string matrixItemId)
        {
            try
            {
                var item = oForm.Items.Item(matrixItemId);
                if (item == null) return;

                var mtx = item.Specific as SAPbouiCOM.Matrix;
                mtx?.LoadFromDataSource();
            }
            catch { /* ignore */ }
        }

        // ---- Your existing helpers (unchanged) ----
        private Dictionary<string, string> CacheUdfs(SAPbouiCOM.DBDataSource ds, int row)
        {
            var dict = new Dictionary<string, string>();
            for (int f = 0; f < ds.Fields.Count; f++)
            {
                string name = ds.Fields.Item(f).Name;
                if (!name.StartsWith("U_")) continue;

                dict[name] = ds.GetValue(name, row).Trim();
            }
            return dict;
        }

        private List<Dictionary<string, string>> CacheChildUdfs(SAPbouiCOM.DBDataSource childDs)
        {
            var list = new List<Dictionary<string, string>>();
            for (int r = 0; r < childDs.Size; r++)
                list.Add(CacheUdfs(childDs, r));
            return list;
        }

        private void ApplyUdfs(SAPbouiCOM.DBDataSource ds, int row, Dictionary<string, string> values)
        {
            foreach (var kv in values)
                ds.SetValue(kv.Key, row, kv.Value ?? "");
        }

        private void SafeClear(SAPbouiCOM.DBDataSource ds, string field, int row = 0)
        {
            try { ds.GetValue(field, row); ds.SetValue(field, row, ""); }
            catch { /* field not present */ }
        }




        private void GenerateCostCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value.Trim();
                string draftCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDRFTSO").Specific).Value.Trim();
                string currdate = DateTime.Now.ToString("ddMMyyyy");

                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = $@"
                                SELECT LPAD(TO_NVARCHAR(COUNT(*) + 1), 2, '0') AS ""RESULT""
                                FROM ""@FIL_MH_OCSM""
                                WHERE ""U_STYLENO""  = '{styleCode}'
                                  AND ""U_DRFTNTRY"" = '{draftCode}';";

                oRS.DoQuery(sql);
                string result = oRS.EoF ? "" : (oRS.Fields.Item("RESULT").Value ?? "").ToString().Trim();

                string costSheetCode = $"{styleCode}-{currdate}-{draftCode}-{result}";
                if (oForm.Items.Item("ETCSHTCD") != null)
                {
                   var oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTCD").Specific;
                   oEdit.Value = costSheetCode;

                    var oEDITname = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTDS").Specific;
                    oEDITname.Value = "";
                }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Route Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }


        private void GenerateCostVersion(SAPbouiCOM.Form oForm)
        {
            try
            {
                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value;
                string draftCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDRFTSO").Specific).Value.Trim();
               
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = $@"
                    SELECT
                       LPAD(TO_NVARCHAR(COUNT(*) + 1), 2, '0') AS ""RESULT""
                    FROM ""@FIL_MH_OCSM""
                    WHERE ""U_STYLENO"" = '{styleCode}'
                    AND ""U_DRFTNTRY"" = '{draftCode}'; ";

                oRS2.DoQuery(sql);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("RESULT").Value.ToString();

                // --- Generate the Style Code ---
                string verCode = $"{styleCode}-{nextValue}";

                // --- Set Value to ETSTYLID ---
                if (oForm.Items.Item("ETSTYLCD") != null)
                {
                    SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific;
                    oEdit.Value = verCode;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Route Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }



        private void CPMRange(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMTXRNG = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXRANGE").Specific;
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR2");

                if (oMTXRNG.VisualRowCount==0)
                {
                    // Add 6 rows
                    for (int i = 0; i < 6; i++)
                    {
                        // Add new record to DBDataSource
                        ds.InsertRecord(i);
                        ds.Offset = i;

                        string rangeValue = $"Range{i + 1}";
                        ds.SetValue("LineId", i, (i + 1).ToString());
                        ds.SetValue("U_RANGE", i, rangeValue);
                    }

                    // Load the matrix from data source
                    oMTXRNG.LoadFromDataSource();
                    oMTXRNG.AutoResizeColumns();
                }
            }
            catch(Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                  ex.Message,
                  SAPbouiCOM.BoMessageTime.bmt_Short,
                  SAPbouiCOM.BoStatusBarMessageType.smt_Error
              );
            }
        }

        private void DeleteSelectedRowAndSyncDraft()
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
            SAPbouiCOM.Matrix oMatrixDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

            SAPbouiCOM.DBDataSource dsMain = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM1");
            SAPbouiCOM.DBDataSource dsDraft = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM2");

            try
            {
                oForm.Freeze(true);
                int selRow = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                if (selRow <= 0)
                {
                    Application.SBO_Application.MessageBox("Please select a row to delete.");
                    return;
                }

                string deletedStyle = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD")
                    .Cells.Item(selRow).Specific).Value.Trim();

                oMatrixDraft.FlushToDataSource();
                for (int i = oMatrixDraft.RowCount; i >= 1; i--)
                {
                    string draftStyle = ((SAPbouiCOM.EditText)oMatrixDraft.Columns.Item("CLSTYLCD")
                        .Cells.Item(i).Specific).Value.Trim();

                    if (draftStyle.Equals(deletedStyle, StringComparison.OrdinalIgnoreCase))
                    {
                        dsDraft.RemoveRecord(i - 1);
                        oMatrixDraft.DeleteRow(i);
                    }
                }

                oMatrixDraft.LoadFromDataSource();

                //Enable refresh button
                oForm.Items.Item("BTNREFRS").Enabled = true;

                oMatrixDraft.AutoResizeColumns();
                oForm.Update();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Delete Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }



        public bool IsFormOpen(string formUID)
        {
            try
            {
                foreach (SAPbouiCOM.Form form in Application.SBO_Application.Forms)
                {
                    if (form.UniqueID == formUID)
                    {
                        // Check if it's visible and not closed
                        if (form.Visible)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.G_UI_Application.StatusBar.SetText("Error checking form: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            return false; // Form is not open
        }

        //private void CompanyConnection()
        //{
        //    try
        //    {
        //        string sErrorMsg;
        //        string cookie;
        //        string connStr;
        //        // Global.ocomp.
        //        Global.oComp = new SAPbobsCOM.Company();
        //        cookie = Global.oComp.GetContextCookie();
        //        //    Global.oCompany = new SAPbobsCOM.Company();
        //        //   cookie =Global.oCompany.GetContextCookie();
        //        connStr = Application.SBO_Application.Company.GetConnectionContext(cookie);
        //        Global.oComp.SetSboLoginContext(connStr);
        //        ////   if (Global.CF.IsSAPHANA())
        //        ////  {
        //        ////   Global.oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
        //        //// }
        //        //// else
        //        //// {
        //        //Global.ocomp.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;
        //        // }
        //        // Global.oCompany.Connect();
        //        Global.G_UI_Application = Application.SBO_Application;
        //        Global.oComp = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany(); // Reassign the ocomp with the session we conencted with sap b1
        //                                                                                               // sErrorMsg = Global.oCompany.GetLastErrorDescription();
        //        Application.SBO_Application.StatusBar.SetText("Apparel Add-On Connected Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        //    }
        //    catch
        //    {
        //        Application.SBO_Application.MessageBox(Global.oComp.GetLastErrorDescription().ToString(), 1, "OK", "", "");
        //    }
        //}

        private bool CompanyConnection(string _AddonId)
        {

            try
            {
                string sErrorMsg;
                string cookie;
                string connStr;
                // Global.ocomp.
                Global.oComp = new SAPbobsCOM.Company();
                cookie = Global.oComp.GetContextCookie();
                //    Global.oCompany = new SAPbobsCOM.Company();
                //   cookie =Global.oCompany.GetContextCookie();
                connStr = Application.SBO_Application.Company.GetConnectionContext(cookie);
                Global.oComp.SetSboLoginContext(connStr);
                ////   if (Global.CF.IsSAPHANA())
                ////  {
                ////   Global.oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                //// }
                //// else
                //// {
                //Global.ocomp.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;
                // }
                // Global.oCompany.Connect();
                Global.G_UI_Application = Application.SBO_Application;
                Global.oComp = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany(); // Reassign the ocomp with the session we conencted with sap b1
                                                                                                       // sErrorMsg = Global.oCompany.GetLastErrorDescription();
                if (!ValidateLicense(_AddonId))
                {
                    Application.SBO_Application.StatusBar.SetText("License validation failed for Apparel Add-On", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    System.Windows.Forms.Application.Exit();
                    return false;
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("Apparel Add-On Connected Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    return true;
                }
            }
            catch
            {
                Application.SBO_Application.MessageBox(Global.oComp.GetLastErrorDescription().ToString(), 1, "OK", "", "");
                return false;
            }
        }

        private static bool ValidateLicense(string addonId)
        {
            try
            {
                // Example: license info stored in custom UDT [@MYADDON_LICENSE]
                // Fields: U_AddonId, U_CompanyDB, U_LicenseKey, U_ExpiryDate

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = string.Format("SELECT A.{0}U_LICSEKEY{0},A.{0}U_EXPIRDATE{0} from {0}@FIL_MH_LICENSE{0} A  Where A.{0}U_ADDONID{0}='" + addonId + "' AND A.{0}U_COMNYDB{0}='" + Global.oComp.CompanyDB.ToString() + "' ", '"');
                rs.DoQuery(sql);

                if (rs.RecordCount == 0)
                    return false;

                string licenseKey = rs.Fields.Item("U_LICSEKEY").Value.ToString();
                DateTime expiryDate = Convert.ToDateTime(rs.Fields.Item("U_EXPIRDATE").Value);

                // Validate Expiry
                if (DateTime.Now > expiryDate)
                    return false;

                // Validate Key (example check — implement your own hash/algorithm)
                string expectedKey = GenerateExpectedKey(Global.oComp.CompanyDB.ToString(), addonId);
                if (licenseKey != expectedKey)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GenerateExpectedKey(string companyDb, string addonId)
        {
            // Example license key algorithm (you can implement stronger encryption)
            return (companyDb + "_" + addonId + "_2025").ToUpper();
        }

        public void CreateMainMenu(string ParentMenuID, string MenuID, string MenuName, int Position, int imenutype, bool flgimg)
        {
            try
            {
                SAPbouiCOM.Menus oMenus = null;
                SAPbouiCOM.MenuItem oMenuItem = null;
                oMenus = Application.SBO_Application.Menus;
                // ✅ Skip if already exists
                if (oMenus.Exists(MenuID))
                {
                    return;
                }
                SAPbouiCOM.MenuCreationParams oCreationPackage = null;
                oCreationPackage = (SAPbouiCOM.MenuCreationParams)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);
                oMenuItem = Application.SBO_Application.Menus.Item(ParentMenuID);

                switch (imenutype)
                {
                    case 2:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                        break;
                    case 1:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                        break;
                    case 3:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_SEPERATOR;
                        break;
                }

                oCreationPackage.UniqueID = MenuID;
                oCreationPackage.String = MenuName;
                oCreationPackage.Enabled = true;
                oCreationPackage.Position = Position;

                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath).ToString(); 
                if (flgimg == true) 
                { 
                    string Apparel = string.Concat(path, @"AddFiles\Logo\test.jpg"); 
                    oCreationPackage.Image = Apparel; 
                }

                oMenus = oMenuItem.SubMenus;

                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch (Exception ex)
                {
                    Application.SBO_Application.MessageBox("Menu already Exists " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Unexpected error in CreateMainMenu: " + ex.Message);
            }
        }

        private void CostMatrixSize(SAPbouiCOM.Form oForm)
        {
            if (oForm == null) return;

            string[] matrixIds =
            {
                "MTXROUTE",
                "MTXOHCST",
                "MTXTRMAC",
                "MTXTRMFB",
                "MTXFBRIC",
                "MTXCOLOR",
                "MTXFOB"
                };

            try
            {
                oForm.Freeze(true);

                foreach (var id in matrixIds)
                {
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(id).Specific;
                    oMatrix.AutoResizeColumns();
                    
                }
            }
            finally
            {
                oForm.Freeze(false);
            }
        }


        private void InitializeMasterLCForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                // Status
                string status = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (status == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                //Default amendment no
                SAPbouiCOM.EditText ETADNTNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETADNTNO").Specific;
                ETADNTNO.Value = "0";

                //Commercial Status
                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                oItem.Enabled = false;

                SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
                oCombo.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCMPANY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMPANY").Specific;
                Global.GFunc.setComboBoxValue(CBCMPANY, sqlQuerybpl);
                CBCMPANY.Select("1", SAPbouiCOM.BoSearchKey.psk_ByValue);

                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS1").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);

                // Days terms
                string sqlQueryptrms2 = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 25";
                SAPbouiCOM.ComboBox CBPTRMS2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS2").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS2, sqlQueryptrms2);

                // Document number
                int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCM");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();

                // Document date
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBISSBNK").Specific;
                Global.GFunc.setComboBoxValue(CBISSBNK, countrySql);

                SAPbouiCOM.ComboBox CBBPBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBNK2").Specific;
                Global.GFunc.setComboBoxValue(CBBPBNK2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBNEGBNK").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);


            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void LoadPrevLCForm(SAPbouiCOM.Form oForm)
        {

            try
            {
                oForm.Freeze(true);

                // Status
                string status = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (status == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                // Merchandise Combo //Commercial Status

                SAPbouiCOM.ComboBox oCBCMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
                string csVal = oCBCMODE.Value;

                SAPbouiCOM.ComboBox oCBMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
                string msVal = oCBMMODE.Value;


                if (msVal == "D" || msVal == "")
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                    oItem.Enabled = false;
                    oForm.Items.Item("CBMMODE").Enabled = true;
                }
                if (msVal == "C")
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                    oItem.Enabled = true;
                }

                if (csVal == "C" && msVal == "C")
                {
                    oForm.Items.Item("CBCMODE").Enabled = false;
                    oForm.Items.Item("CBMMODE").Enabled = false;
                }



                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCMPANY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMPANY").Specific;
                Global.GFunc.setComboBoxValue(CBCMPANY, sqlQuerybpl);

                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS1").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);

                // Days terms
                string sqlQueryptrms2 = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 25";
                SAPbouiCOM.ComboBox CBPTRMS2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS2").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS2, sqlQueryptrms2);

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBISSBNK").Specific;
                Global.GFunc.setComboBoxValue(CBISSBNK, countrySql);

                SAPbouiCOM.ComboBox CBBPBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBNK2").Specific;
                Global.GFunc.setComboBoxValue(CBBPBNK2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBNEGBNK").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }
        private void InitializeMLCAmmendmentForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                // Status

                string stat = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (stat == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                // Merchandise Combo



                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCMPANY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMPANY").Specific;
                Global.GFunc.setComboBoxValue(CBCMPANY, sqlQuerybpl);


                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS1").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);

                // Days terms
                string sqlQueryptrms2 = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 25";
                SAPbouiCOM.ComboBox CBPTRMS2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS2").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS2, sqlQueryptrms2);


                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                    oItem.Enabled = false;

                    // Document number
                    int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCM");
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();

                    // Document date
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
                }

            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void IntSalesContractAmendForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                //MAtrix Resize
                SAPbouiCOM.Matrix MTXSTLYD = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                SAPbouiCOM.Matrix MTXDRAFT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;
                SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;
                MTXSTLYD.AutoResizeColumns();
                MTXDRAFT.AutoResizeColumns();
                MTXATTAC.AutoResizeColumns();
                // Status
                string stat = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (stat == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETFULL").Specific).Value = "Open";
                }
                
                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBCNTRY1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY1").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY1, countrySql);

                SAPbouiCOM.ComboBox CBCNTRY2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY2").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBRNCH").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);

                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBRMSPAY").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);


            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void InitializeSalesContractForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                //MAtrix Resize
                SAPbouiCOM.Matrix MTXSTLYD = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                SAPbouiCOM.Matrix MTXDRAFT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;
                SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;
                MTXSTLYD.AutoResizeColumns();
                MTXDRAFT.AutoResizeColumns();
                MTXATTAC.AutoResizeColumns();

                // Status
                string stat = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (stat == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETFULL").Specific).Value = "Open";
                }

                //Default amendment no
                SAPbouiCOM.EditText ETAMDNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific;
                ETAMDNO.Value = "0";

                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    string db = "@FIL_DH_OSCM";
                    int num = Global.GFunc.GetCodeGeneration(db) + 1000;
                    string docnum = num.ToString();
                    SAPbouiCOM.EditText ETDOCNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                    ETDOCNO.Value = docnum;

                    SAPbouiCOM.EditText ETDOCDAT = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific;
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    ETDOCDAT.Value = currentDate;
                }

                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBRMSPAY").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);


            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void InitializeB2BLCForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                // Status
                string status = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (status == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                //Default amendment no
                SAPbouiCOM.EditText ETAMDNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific;
                ETAMDNO.Value = "0";

                //Default Amendment date
                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                SAPbouiCOM.EditText ETAMDDT = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDDT").Specific;
                ETAMDDT.Value = currentDate;

                //Bank Charges Enable 
                SAPbouiCOM.Item ETBNKCHG = oForm.Items.Item("ETBNKCHG");
                ETBNKCHG.Enabled = false;

                //Branch Code Combo box
                string sqlQuerybpl = string.Format("SELECT {0}BPLId{0},{0}BPLName{0} FROM {0}OBPL{0}", '"');
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                //COuntry Combo box
                string sqlQuerycountry = string.Format("SELECT {0}Code{0},{0}Name{0} FROM {0}OCRY{0}", '"');
                SAPbouiCOM.ComboBox CBCONTRY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCONTRY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCONTRY, sqlQuerycountry);

                // Commercial Current  date
                SAPbouiCOM.EditText ETCOMKDT = (SAPbouiCOM.EditText)oForm.Items.Item("ETCOMKDT").Specific;
                ETCOMKDT.Value = currentDate;

                // Document number
                int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCB");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();


                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN1").Specific;
                Global.GFunc.setComboBoxValue(CBISSBNK, countrySql);

                SAPbouiCOM.ComboBox CBBPBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN2").Specific;
                Global.GFunc.setComboBoxValue(CBBPBNK2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBHBBRNC").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void InitializeB2BLCAmendForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                // Status
                string status = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (status == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                //Bank Charges Enable 
                SAPbouiCOM.Item ETBNKCHG = oForm.Items.Item("ETBNKCHG");
                ETBNKCHG.Enabled = false;

                //Branch Code Combo box
                string sqlQuerybpl = string.Format("SELECT {0}BPLId{0},{0}BPLName{0} FROM {0}OBPL{0}", '"');
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                //COuntry Combo box
                string sqlQuerycountry = string.Format("SELECT {0}Code{0},{0}Name{0} FROM {0}OCRY{0}", '"');
                SAPbouiCOM.ComboBox CBCONTRY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCONTRY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCONTRY, sqlQuerycountry);

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN1").Specific;
                Global.GFunc.setComboBoxValue(CBISSBNK, countrySql);

                SAPbouiCOM.ComboBox CBBPBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN2").Specific;
                Global.GFunc.setComboBoxValue(CBBPBNK2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBHBBRNC").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMMODE");
                    oItem.Enabled = false;

                    // Document number
                    int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCB");
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();

                    // Document date
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETCOMKDT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
                    //AMD Date
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDDT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
                }
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void GenerateIESAMCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                // --- Get Next Available DocEntry from @FIL_MH_ORSM
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlNext = @"SELECT COALESCE(MAX(""DocEntry""), 0) + 1001 AS MAXDOC FROM ""@FIL_MH_IESAMMST""";
                oRS2.DoQuery(sqlNext);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("MAXDOC").Value.ToString();

                // --- Generate the Style Code ---
                string samCode = $"IESAM{nextValue}";

                // --- Set Value to ETSTYLID ---
                if (oForm.Items.Item("ETCODE") != null)
                {
                    SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific;
                    oEdit.Value = samCode;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Route Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }

        private void GenerateRouteCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                // --- Get Next Available DocEntry from @FIL_MH_ORSM
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlNext = @"SELECT COALESCE(MAX(""DocEntry""), 0) + 1001 AS MAXDOC FROM ""@FIL_MH_ORSM""";
                oRS2.DoQuery(sqlNext);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("MAXDOC").Value.ToString();

                // --- Generate the Style Code ---
                string styleCode = $"RST{nextValue}";

                // --- Set Value to ETSTYLID ---
                if (oForm.Items.Item("ETCODE") != null)
                {
                    SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific;
                    oEdit.Value = styleCode;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Route Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }

        public static void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);

            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
            }
        }
        public static void AddLineIfLastRowHasValue(
           SAPbouiCOM.Form oForm,
           string matrixID,
           string dbTable,
           string columnName
           )
        {
            try
            {
                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);
                matrix.FlushToDataSource();
                int dbRowCount = db.Size;
                if (dbRowCount == 0)
                {
                    Global.GFunc.SetNewLine(matrix, db, 1, "");
                    return;
                }
                int lastDbRow = dbRowCount - 1;
                string lastValue = db.GetValue(columnName, lastDbRow).Trim();
                if (!string.IsNullOrEmpty(lastValue) && !lastValue.Equals("0.0"))
                {
                    Global.GFunc.SetNewLine(matrix, db, dbRowCount + 1, "");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("AddLineIfLastRowHasValue Error: " + ex.Message);
            }
        }
        private void GenerateAndSetStyleCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                // --- Get Current Financial Period Indicator ---
                string indicator = string.Empty;
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlIndicator = @"SELECT ""Indicator"" FROM OFPR WHERE ""AbsEntry"" = (SELECT MAX(""AbsEntry"") FROM OFPR)";
                oRS.DoQuery(sqlIndicator);

                if (!oRS.EoF)
                    indicator = oRS.Fields.Item("Indicator").Value.ToString();

                // --- Get Next Available DocEntry from @FIL_MH_OPSM ---
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlNext = @"SELECT COALESCE(MAX(""DocEntry""), 0) + 1000 AS MAXDOC FROM ""@FIL_MH_OPSM""";
                oRS2.DoQuery(sqlNext);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("MAXDOC").Value.ToString();

                // --- Generate the Style Code ---
                string styleCode = $"ST{indicator}/{nextValue}";

                // --- Set Value to ETSTYLID ---
                if (oForm.Items.Item("ETSTYLID") != null)
                {
                    SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLID").Specific;
                    oEdit.Value = styleCode;
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Style Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }
        private void SampleEnableButtons(SAPbouiCOM.Form oForm)
        {
            try
            {
                // Only run in VIEW or OK mode
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_VIEW_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                SAPbouiCOM.EditText oSampleId = (SAPbouiCOM.EditText)oForm.Items.Item("ETSLCODE").Specific;
                SAPbouiCOM.EditText oDocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific;
                string sampleId = oSampleId.Value.Trim();
                string docEntry = oDocEntry.Value.Trim();

                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");

                bool matrixEmpty = false;

                // --- Check if matrix is empty or has only 1 blank row ---
                if (oMatrix.RowCount == 0 || oMatrix.VisualRowCount == 0)
                {
                    matrixEmpty = true;
                }
                else if (oMatrix.RowCount == 1)
                {
                    SAPbouiCOM.EditText cell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCLRCOD").Cells.Item(1).Specific;
                    if (string.IsNullOrEmpty(cell.Value.Trim()))
                        matrixEmpty = true;
                }

                // --- Case 1: Matrix empty or one blank row ---
                if (matrixEmpty)
                {
                    oBtnItmTx.Enabled = !string.IsNullOrEmpty(sampleId);
                    oBtnItmCr.Enabled = false;
                    return;
                }

                // --- Case 2: Matrix has data ---
                oBtnItmTx.Enabled = false;
                bool enableBtnItmCr = false;

                // 1️⃣ Check DB only if StyleID is not empty //****need to verify****
                if (!string.IsNullOrEmpty(sampleId))
                {
                    SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    string query = $"SELECT 1 FROM \"@FIL_DR_SMPLITEM\" WHERE \"DocEntry\" = '{docEntry}'";
                    oRec.DoQuery(query);
                    enableBtnItmCr = !oRec.EoF; // True if record exists
                }

                // 2️⃣ Check if all checkboxes in CLCREAT column are checked
                bool allChecked = true;
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLCREAT").Cells.Item(i).Specific;
                    if (!chk.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Final decision for BTNITMCR
                oBtnItmCr.Enabled = enableBtnItmCr && !allChecked;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in StyleEnableButtons: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }

        private void StyleEnableButtons(SAPbouiCOM.Form oForm)
        {
            try
            {
                // Only run in VIEW or OK mode
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_VIEW_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                SAPbouiCOM.EditText oStyleId = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLID").Specific;
                string styleId = oStyleId.Value.Trim();

                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");

                bool matrixEmpty = false;

                // --- Check if matrix is empty or has only 1 blank row ---
                if (oMatrix.RowCount == 0 || oMatrix.VisualRowCount == 0)
                {
                    matrixEmpty = true;
                }
                else if (oMatrix.RowCount == 1)
                {
                    SAPbouiCOM.EditText cell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPDSYCD").Cells.Item(1).Specific;
                    if (string.IsNullOrEmpty(cell.Value.Trim()))
                        matrixEmpty = true;
                }

                // --- Case 1: Matrix empty or one blank row ---
                if (matrixEmpty)
                {
                    oBtnItmTx.Enabled = !string.IsNullOrEmpty(styleId);
                    oBtnItmCr.Enabled = false;
                    return;
                }

                // --- Case 2: Matrix has data ---
                oBtnItmTx.Enabled = false;

                bool enableBtnItmCr = false;

                // 1️⃣ Check DB only if StyleID is not empty
                if (!string.IsNullOrEmpty(styleId))
                {
                    SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    string query = $"SELECT 1 FROM \"@FIL_MR_PSMIP\" WHERE \"Code\" = '{styleId}'";
                    oRec.DoQuery(query);

                    enableBtnItmCr = !oRec.EoF; // True if record exists
                }

                // 2️⃣ Check if all checkboxes in CLCREAT column are checked
                bool allChecked = true;
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLCREAT").Cells.Item(i).Specific;
                    if (!chk.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Final decision for BTNITMCR
                oBtnItmCr.Enabled = enableBtnItmCr && !allChecked;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in StyleEnableButtons: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }







        private void LoadPrevB2BLCForm(SAPbouiCOM.Form oForm)
        {

            try
            {
                oForm.Freeze(true);
              
                string status = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (status == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTFULL").Specific).Value = "Open";
                }

                // Merchandise Combo //Commercial Status
                SAPbouiCOM.ComboBox oCBCMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMMODE").Specific;
                string csVal = oCBCMODE.Value;

                SAPbouiCOM.ComboBox oCBMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
                string msVal = oCBMMODE.Value;

                if (msVal == "D" || msVal == "")
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMMODE");
                    oItem.Enabled = false;
                    oForm.Items.Item("CBMMODE").Enabled = true;
                }
                if (msVal == "C")
                {
                    SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMMODE");
                    oItem.Enabled = true;
                }
                if (csVal == "C" && msVal == "C")
                {
                    oForm.Items.Item("CBCMMODE").Enabled = false;
                    oForm.Items.Item("CBMMODE").Enabled = false;
                }

                //Branch Code Combo box
                string sqlQuerybpl = string.Format("SELECT {0}BPLId{0},{0}BPLName{0} FROM {0}OBPL{0}", '"');
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                //COuntry Combo box
                string sqlQuerycountry = string.Format("SELECT {0}Code{0},{0}Name{0} FROM {0}OCRY{0}", '"');
                SAPbouiCOM.ComboBox CBCONTRY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCONTRY").Specific;   //object defining- Define a combo box
                Global.GFunc.setComboBoxValue(CBCONTRY, sqlQuerycountry);

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN1").Specific;
                Global.GFunc.setComboBoxValue(CBISSBNK, countrySql);

                SAPbouiCOM.ComboBox CBBPBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN2").Specific;
                Global.GFunc.setComboBoxValue(CBBPBNK2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBHBBRNC").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }


        //Series For MRP
        private void InitFormAddMode(ref SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Folder tab = (SAPbouiCOM.Folder)oForm.Items.Item("TAB_SO").Specific;
            tab.Select();

            GlobalFunction gf = new GlobalFunction();
            int num = gf.GetDocNum("@FIL_DH_OMRP") ;

            SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
            etDocNum.Value = num.ToString();
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDATE").Specific).Value = DateTime.Now.ToString("yyyyMMdd");


            //Branch Code Combo box
            string sqlQuerybpl = string.Format("SELECT {0}BPLId{0},{0}BPLName{0} FROM {0}OBPL{0}", '"');
            SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBUNIT").Specific;   //object defining- Define a combo box
            Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);
            oForm.ActiveItem = "ETCUSTCD";

            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;
            oMatrix.CommonSetting.FixedColumnsCount = 5;
        }

        //Init For Down payment FHR
        public void InitDP(string formUID)
        {
            SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(formUID);
            try
            {
                oForm.Freeze(true);

                //Payment Terms Combobox
                string rset = $"select \"GroupNum\",\"PymntGroup\" from \"OCTG\"";
                SAPbouiCOM.ComboBox CBPAYTRM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPAYTRM").Specific;
                Global.GFunc.setComboBoxValue(CBPAYTRM, rset);

                //Currency Combobox
                string rset2 = $"select \"CurrCode\",\"CurrName\" from \"OCRN\"";
                SAPbouiCOM.ComboBox CBCURR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCURR").Specific;
                Global.GFunc.setComboBoxValue(CBCURR, rset2);

                //Brach Combobox
                string rset3 = $"select \"BPLId\",\"BPLName\" from \"OBPL\"";
                SAPbouiCOM.ComboBox CBBRANCH = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPLID").Specific;
                Global.GFunc.setComboBoxValue(CBBRANCH, rset3);

                oForm.Items.Item("FOLDER1").Click();

                SAPbouiCOM.Matrix MTX_ITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_ITM").Specific;
                MTX_ITM.AutoResizeColumns();

                SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;
                MTXATTCH.AutoResizeColumns();

                //FHR~Column Sum 
                SAPbouiCOM.Column oQty; oQty = (SAPbouiCOM.Column)MTX_ITM.Columns.Item("CLQUANTITY"); oQty.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;
                SAPbouiCOM.Column oTotal; oTotal = (SAPbouiCOM.Column)MTX_ITM.Columns.Item("CLLINETOT"); oTotal.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

                //Docnum Initialization
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    GlobalFunction gf = new GlobalFunction();
                    int num = gf.GetDocNum("@FIL_DH_DPMRQST");

                    SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                    etDocNum.Value = num.ToString();

                    // show cpoy from PO button
                    oForm.Items.Item("BTNCOPY").Visible = true;
                    // hide post button
                    oForm.Items.Item("BTNPOST").Visible = false;
                }
                else
                {
                    SAPbouiCOM.EditText dpDocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("ETDPDOCE").Specific;

                    // hide cpoy from PO button
                    oForm.Items.Item("BTNCOPY").Visible = false;

                    if (!string.IsNullOrEmpty(dpDocEntry.Value) && dpDocEntry.Value.Trim() != "0")
                    {
                        // hide post button
                        oForm.Items.Item("BTNPOST").Visible = false;
                    }
                    else
                    {
                        // show post button
                        oForm.Items.Item("BTNPOST").Visible = true;
                    }
                }
                // Docnum Initialization

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                { oForm.Items.Item("ETDOCNUM").Enabled = true; }

                SAPbouiCOM.Folder oTab = (SAPbouiCOM.Folder)oForm.Items.Item("FOLDER1").Specific;
                oTab.Select();
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error Found : " + e.Message);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void SetAutoManagedAttribute(ref SAPbouiCOM.Form oForm)
        {
            oForm.Items.Item("ETDOCNUM").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Add, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            oForm.Items.Item("ETDOCNUM").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Find, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
            oForm.Items.Item("ETDOCNUM").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Ok, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
            oForm.Items.Item("ETDOCDATE").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Ok, SAPbouiCOM.BoModeVisualBehavior.mvb_False);
        }
    }
}
