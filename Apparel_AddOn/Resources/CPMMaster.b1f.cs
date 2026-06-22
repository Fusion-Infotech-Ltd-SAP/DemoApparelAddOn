using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.CPMMaster", "Resources/CPMMaster.b1f")]
    class CPMMaster : UserFormBase
    {
        public CPMMaster()
        {
        }
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix MTXCPMTR, MTXRANGE;
        private SAPbouiCOM.ComboBox CBPRCESS;
        private SAPbouiCOM.StaticText STCUSCOD, STCURR, STPSTNDT, STBRNDCD, STPRCESS, STPRDGRP;
        private SAPbouiCOM.EditText ETDOCTRY, ETPSTNDT, ETBRNDCD, ETBRNDNM,ETCUSCOD, ETPRDGRP, ETCUSNAM, ETCURR, ETPDGPNM;
        private SAPbouiCOM.Button ADDButton, CancelButton;



        public override void OnInitializeComponent()
        {
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STPSTNDT = ((SAPbouiCOM.StaticText)(this.GetItem("STPSTNDT").Specific));
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPRCESS = ((SAPbouiCOM.StaticText)(this.GetItem("STPRCESS").Specific));
            this.STPRDGRP = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDGRP").Specific));
            this.ETPSTNDT = ((SAPbouiCOM.EditText)(this.GetItem("ETPSTNDT").Specific));
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNDCD_ChooseFromListBefore);
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETPRDGRP = ((SAPbouiCOM.EditText)(this.GetItem("ETPRDGRP").Specific));
            this.ETPRDGRP.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPRDGRP_ChooseFromListAfter);
            this.ETPDGPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.CBPRCESS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRCESS").Specific));
            this.CBPRCESS.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPRCESS_ComboSelectAfter);
            this.MTXCPMTR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPMTR").Specific));
            this.MTXCPMTR.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.MTXCPMTR_ComboSelectAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STSAMLBL").Specific));
            this.MTXRANGE = ((SAPbouiCOM.Matrix)(this.GetItem("MTXRANGE").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.OnCustomInitialize();

        }


        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
           // this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }

        private void OnCustomInitialize()
        {

        }
        //private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //    // Baseline margins from your initial layout
        //    const int TOP_MARGIN_RANGE = 22;
        //    const int RIGHT_MARGIN = 19;

        //    const int RANGE_W = 327;
        //    const int RANGE_H = 137;

        //    const int LEFT_MARGIN_CPMTR = 14;
        //    const int GAP_UNDER_RANGE = 7;
        //    const int BOTTOM_MARGIN = 88;

        //    try
        //    {
        //        oForm.Freeze(true);

        //        var itRange = oForm.Items.Item("MTXRANGE");
        //        var itCpmtr = oForm.Items.Item("MTXCPMTR");

        //        int cw = oForm.ClientWidth;
        //        int ch = oForm.ClientHeight;

        //        // --- MTXRANGE: keep fixed size, anchored TOP-RIGHT ---
        //        itRange.Width = RANGE_W;
        //        itRange.Height = RANGE_H;
        //        itRange.Top = TOP_MARGIN_RANGE;
        //        itRange.Left = cw - RIGHT_MARGIN - RANGE_W;

        //        // --- MTXCPMTR: full width, below MTXRANGE, stretch height ---
        //        itCpmtr.Left = LEFT_MARGIN_CPMTR;
        //        itCpmtr.Width = cw - LEFT_MARGIN_CPMTR - RIGHT_MARGIN;

        //        itCpmtr.Top = itRange.Top + itRange.Height + GAP_UNDER_RANGE;

        //        int newHeight = ch - itCpmtr.Top - BOTTOM_MARGIN;
        //        if (newHeight < 50) newHeight = 50; // safety min height

        //        itCpmtr.Height = newHeight;

        //        // Now resize columns (optional)
        //        ((SAPbouiCOM.Matrix)itRange.Specific).AutoResizeColumns();
        //        ((SAPbouiCOM.Matrix)itCpmtr.Specific).AutoResizeColumns();
        //    }
        //    finally
        //    {

        //        oForm.Freeze(false);
        //    }
        //}


        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMTXRNG = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXRANGE").Specific;
            SAPbouiCOM.Matrix oMTXCPMTR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPMTR").Specific;
            oMTXRNG.AutoResizeColumns();
            oMTXCPMTR.AutoResizeColumns();


        }

        private void CBPRCESS_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox cb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRCESS").Specific;

            string select = cb.Selected.Value;   // store the selected value
            string code = ETPRDGRP.Value + select;

            string qstr = "SELECT IFNULL(MAX(TO_INTEGER(\"Code\")) + 1, 1) AS \"Code\" FROM \"@FIL_MH_CPMMSTR\"";
            rSet.DoQuery(qstr);
            SAPbouiCOM.EditText ETCODE = (SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific;
            ETCODE.Value = rSet.Fields.Item("Code").Value.ToString();
           
            //ETCODE.Value = code;
        }

        private void ETPRDGRP_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCUSCOD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPRDGRP").Specific;
            ETCUSCOD.Value = Code;
            SAPbouiCOM.EditText ETCUSNAM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPNM").Specific;
            ETCUSNAM.Value = Name;

        }

        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string currCode = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCURR = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETCURR.Value = currCode;



        }

        private void ETCUSCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string cardCode = dt.GetValue("CardCode", 0).ToString().Trim();
            string cardName = dt.GetValue("CardName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCUSCOD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific;
            ETCUSCOD.Value = cardCode;
            SAPbouiCOM.EditText ETCUSNAM = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSNAM").Specific;
            ETCUSNAM.Value = cardName;

        }

        private void ETBRNDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_OBRM");

                // Read Style Code
                string cusCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific).Value.Trim();
                if (string.IsNullOrEmpty(cusCode))
                {
                    Application.SBO_Application.MessageBox("Please Select Customer First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {
                    // SQL call
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string sql = $@"
                            SELECT T0.""U_BRNDCODE""
                            FROM ""@FIL_MR_CUSTBRDMAP"" T0
                            INNER JOIN ""@FIL_MH_CUSTBRDMAP"" T1 
                                ON T1.""Code"" = T0.""Code""
                            WHERE T1.""U_CUSTCODE"" = '{cusCode}'
                              AND T0.""U_ACTIVE"" = 'Y'";
                    rs.DoQuery(sql);

                    // Store allowed colour codes into list
                    List<string> allowedColors = new List<string>();
                    while (!rs.EoF)
                    {
                        string clr = rs.Fields.Item("U_BRNDCODE").Value.ToString();
                        if (!string.IsNullOrEmpty(clr))
                            allowedColors.Add(clr);

                        rs.MoveNext();
                    }

                    if (allowedColors.Count == 0)
                    {
                        Application.SBO_Application.MessageBox("Please Map the Customer Brand Relation First ", 1, "OK");
                        BubbleEvent = false;
                        return;
                    }
                    else
                    {

                        SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                        if (allowedColors.Count == 0)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "Code";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = "-1";
                        }
                        else
                        {
                            for (int i = 0; i < allowedColors.Count; i++)
                            {
                                SAPbouiCOM.Condition oCon = oCons.Add();
                                oCon.Alias = "Code";
                                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCon.CondVal = allowedColors[i];

                                // Relationship must be set on the previous condition
                                if (i > 0)
                                    oCons.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            }


                        }
                        oCFL.SetConditions(oCons);
                    }

                }




            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }

        }
        private void ETBRNDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCUSCOD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific;
            ETCUSCOD.Value = Code;
            SAPbouiCOM.EditText ETCUSNAM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDNM").Specific;
            ETCUSNAM.Value = Name;

            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPMTR").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR");
            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }

            SAPbouiCOM.Matrix oMTXRNG = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXRANGE").Specific;
            SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR2");

            // Clear existing rows (optional — remove if you want to keep old rows)
            while (ds.Size > 0)
                ds.RemoveRecord(0);

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

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("Code", 0);
            string postingDate = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_EFFEFROM", 0);
            string brand = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_BRAND", 0);
            string customer = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_CARDCODE", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_CURRENCY", 0);
            string productGrp = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_PRDGRP", 0);
            string process = oForm.DataSources.DBDataSources.Item("@FIL_MH_CPMMSTR").GetValue("U_PROCESS", 0);

            if (code == "")
            {
                Global.GFunc.ShowError("Enter CPM Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (postingDate == "")
            {
                Global.GFunc.ShowError("Enter Posting Date");
                oForm.ActiveItem = "ETPSTNDT";
                return BubbleEvent = false;
            }
            else if (brand == "")
            {
                Global.GFunc.ShowError("Enter Brand Code");
                oForm.ActiveItem = "ETBRNDCD";
                return BubbleEvent = false;
            }
            else if (customer == "")
            {
                Global.GFunc.ShowError("Enter Customer Code");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;

            }
            else if (curr == "")
            {
                Global.GFunc.ShowError("Enter Currency");
                oForm.ActiveItem = "ETCURR";
                return BubbleEvent = false;
            }
            else if (productGrp == "")
            {
                Global.GFunc.ShowError("Enter Product Group Code");
                oForm.ActiveItem = "ETPRDGRP";
                return BubbleEvent = false;
            }
            else if (process == "")
            {
                Global.GFunc.ShowError("Select Routing Stages ");
                oForm.ActiveItem = "CBPRCESS";
                return BubbleEvent = false;
            }
            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR");
            int rowCount = MTXCPMTR.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_ORDRTYPE", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXCPMTR.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail2 = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR2");
            int rowCount2 = MTXRANGE.VisualRowCount;
            if (rowCount2 > 0)
            {
                string lastdocentry = oDBDetail2.GetValue("U_RANGE", rowCount2 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXRANGE.DeleteRow(rowCount2);
                    oDBDetail2.RemoveRecord(rowCount2 - 1);
                    rowCount2--;  // Adjust row count after deletion
                }
            }

            return BubbleEvent;
        }

        private void MTXCPMTR_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ItemUID == "MTXCPMTR" && pVal.ColUID == "CLORDRTY" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPMTR").Specific;
                    SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLORDRTY").Cells.Item(pVal.Row).Specific;
                    SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_CPMMSTR");
                    string selectedCode = oCombo.Selected.Value;
                    string sql = $@"SELECT ""U_QTYFROM"", ""U_QTYTO"" 
                            FROM ""@FIL_MH_OQST"" 
                            WHERE ""U_ACTIVE""='Y' AND ""Code""='{selectedCode}'";

                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    oRS.DoQuery(sql);
                    if (!oRS.EoF)
                    {
                        string qtyFrom = oRS.Fields.Item("U_QTYFROM").Value.ToString();
                        string qtyTo = oRS.Fields.Item("U_QTYTO").Value.ToString();
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSZFRM", qtyFrom);
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSZTO", qtyTo);
                    }

                    oRS.MoveNext();

                    // Add new row if last row has data
                    int lastRow = oMatrix.RowCount;
                    bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLORDRTY").Cells.Item(lastRow).Specific).Value);
                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error in ComboSelectAfter: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }


    }
}
