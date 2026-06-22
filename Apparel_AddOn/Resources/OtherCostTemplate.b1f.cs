using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.OtherCostTemplate", "Resources/OtherCostTemplate.b1f")]
    class OtherCostTemplate : UserFormBase
    {
        public OtherCostTemplate()
        {
        }
        private SAPbouiCOM.StaticText STCODE, STDESC, STCUSCOD, STACTIVE, STBRNNAM, STEFRMDT, STETODT, STBRNCOD;
        private SAPbouiCOM.EditText ETCODE, ETDESC, ETCUSCOD, ETCUSNAM, ETBRNCOD, ETBRNNAM, ETEFRMDT, ETETODT, ETDOCTRY;
        private SAPbouiCOM.CheckBox CKACTIVE;

        private SAPbouiCOM.Matrix MTXPARAM;


        private SAPbouiCOM.Button ADDButton, CancelButton;

      
        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STACTIVE = ((SAPbouiCOM.StaticText)(this.GetItem("STACTIVE").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.MTXPARAM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXPARAM").Specific));
            this.MTXPARAM.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.MTXPARAM_ComboSelectAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STBRNCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNCOD").Specific));
            this.ETBRNCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNCOD").Specific));
            this.ETBRNCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNCOD_ChooseFromListAfter);
            this.ETBRNCOD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNCOD_ChooseFromListBefore);
            this.STBRNNAM = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNNAM").Specific));
            this.ETBRNNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNNAM").Specific));
            this.STEFRMDT = ((SAPbouiCOM.StaticText)(this.GetItem("STEFRMDT").Specific));
            this.ETEFRMDT = ((SAPbouiCOM.EditText)(this.GetItem("ETEFRMDT").Specific));
            this.STETODT = ((SAPbouiCOM.StaticText)(this.GetItem("STETODT").Specific));
            this.ETETODT = ((SAPbouiCOM.EditText)(this.GetItem("ETETODT").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPARAM").Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHCST");
            Global.GFunc.SetNewLine(oMatrix, db, 1, "");
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

            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPARAM").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHCST");
            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }

        }
        private void MTXPARAM_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ItemUID != "MTXPARAM")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPARAM").Specific;

                // --- CASE 1: Add new line if last row selected in CLPARAM ---
                if (pVal.ColUID == "CLPARAM")
                {
                    SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHCST");
                    int lastRow = oMatrix.RowCount;

                    bool lastRowHasData =
                        !string.IsNullOrWhiteSpace(
                            ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLPARAM")
                            .Cells.Item(lastRow).Specific).Value);



                    for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                    {
                        if (i == pVal.Row)
                            continue;

                        string currentValue = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLPARAM").Cells.Item(pVal.Row).Specific).Value;

                        string rowValue = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLPARAM").Cells.Item(i).Specific).Value;

                        if (!string.IsNullOrEmpty(currentValue) &&
                            currentValue == rowValue)
                        {

                            SAPbouiCOM.Framework.Application.SBO_Application.StatusBar.SetText("Duplicate Parameter",SAPbouiCOM.BoMessageTime.bmt_Short,SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLPARAM").Cells.Item(pVal.Row).Specific).Select("", SAPbouiCOM.BoSearchKey.psk_ByValue);
                            return;
                        }
                    }


                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, db, 1, "");
                    }
                }

                // --- CASE 2: Enable/Disable PERC/VALUE based on CLBSDON selection ---
                if (pVal.ColUID == "CLBSDON")
                {
                    int row = pVal.Row;

                    try
                    {
                        string selectedValue = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLBSDON").Cells.Item(pVal.Row).Specific).Value;

                        EnableDisableColumns(oForm, oMatrix, pVal.Row, selectedValue);
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    }

                }


            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        private void EnableDisableColumns(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, int row, string value)
        {
            try
            {
                oForm.Freeze(true);

                bool enablePerc = value == "P";   // Percentage
                bool enableValue = value == "V";   // Value

                // ---- Shift focus away to avoid SAP focus errors ----
                //oMatrix.Columns.Item("CLPARAM").Cells.Item(row)
                       //.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                // ---- Get column indexes manually ----
                int colPercIndex = GetColumnIndex(oMatrix, "CLPERC");
                int colValueIndex = GetColumnIndex(oMatrix, "CLVALUE");

                // ---- Enable/Disable per cell ----
                oMatrix.CommonSetting.SetCellEditable(row, colPercIndex, enablePerc);
                oMatrix.CommonSetting.SetCellEditable(row, colValueIndex, enableValue);
                
                // ---- Optional clear ----
                if (enablePerc)
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value = "";
                else
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPERC").Cells.Item(row).Specific).Value = "";
            }
            finally
            {
                oForm.Freeze(false);
            }
        }



        private int GetColumnIndex(SAPbouiCOM.Matrix matrix, string columnId)
        {
            for (int i = 1; i <= matrix.Columns.Count; i++)
            {
                if (matrix.Columns.Item(i).UniqueID == columnId)
                {
                    return i;
                }
            }
            throw new Exception("Column not found: " + columnId);
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
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("Code", 0);
            string desc = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("Name", 0);
            string frmDate = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("U_FROMDATE", 0);
            string toDate = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("U_TODATE", 0);
            string customer = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("U_CARDCODE", 0);

            if (code == "")
            {
                Global.GFunc.ShowError("Enter Other Cost Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (desc == "")
            {
                Global.GFunc.ShowError("Enter Description");
                oForm.ActiveItem = "ETDESC";
                return BubbleEvent = false;
            }
            else if (customer == "")
            {
                Global.GFunc.ShowError("Enter Customer Code");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;
            }
            else if (frmDate == "")
            {
                Global.GFunc.ShowError("Enter From  Date");
                oForm.ActiveItem = "ETEFRMDT";
                return BubbleEvent = false;
            }
            else if (toDate == "")
            {
                Global.GFunc.ShowError("Enter To Date");
                oForm.ActiveItem = "ETETODT";
                return BubbleEvent = false;
            }

            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHCST");
            int rowCount = MTXPARAM.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_PRMCODE", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXPARAM.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            return BubbleEvent;
        }

        private void ETBRNCOD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_BRND");

                // Read Style Code
                string cusCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific).Value.Trim();
                if (string.IsNullOrEmpty(cusCode))
                    return;

                // SQL call
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = $@"
                            SELECT T0.""U_BRNDCODE""
                            FROM ""@FIL_MR_CUSTBRDMAP"" T0
                            INNER JOIN ""@FIL_MH_CUSTBRDMAP"" T1
                                ON T0.""Code"" = T1.""Code"" 
                            WHERE T1.""U_CUSTCODE"" = '{cusCode}'
                              AND T0.""U_ACTIVE"" = 'Y'";
                rs.DoQuery(sql);

                // Store allowed colour codes into list
                List<string> allowedBrands = new List<string>();
                while (!rs.EoF)
                {
                    string clr = rs.Fields.Item("U_BRNDCODE").Value.ToString();
                    if (!string.IsNullOrEmpty(clr))
                        allowedBrands.Add(clr);

                    rs.MoveNext();
                }

                if (allowedBrands.Count == 0)
                {
                    Application.SBO_Application.MessageBox("Please Map the Customer Brand Relation First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {
                  
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    if (allowedBrands.Count == 0)
                    {
                        SAPbouiCOM.Condition oCon = oCons.Add();
                        oCon.Alias = "Code";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = "-1";
                    }
                    else
                    {
                        for (int i = 0; i < allowedBrands.Count; i++)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "Code";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = allowedBrands[i];

                            // Relationship must be set on the previous condition
                            if (i > 0)
                                oCons.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                        }


                    }
                    oCFL.SetConditions(oCons);
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

        private void ETBRNCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string code = dt.GetValue("Code", 0).ToString().Trim();
            string name = dt.GetValue("Name", 0).ToString().Trim();


            ETBRNCOD.Value = code;
            ETBRNNAM.Value = name;

            string cusCode = ETCUSCOD.Value;
            
            GenerateVersion(oForm, cusCode, code);
        }


        private void GenerateVersion(SAPbouiCOM.Form oForm, string cusCode, string brandCode)
        {
            try
            {
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlNext = $@"SELECT COALESCE(MAX(""DocEntry""), 0) AS MAXDOC FROM ""@FIL_MH_CSOTHCST"" 
                                    WHERE ""U_CARDCODE""='{cusCode}' AND ""U_BRNDCODE""='{brandCode}'";
                oRS2.DoQuery(sqlNext);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("MAXDOC").Value.ToString();

  
                string costSheetCode =cusCode+"-"+brandCode+"-"+$"{nextValue}";
                SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific;
                oEdit.Value = costSheetCode;
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating OtherCost Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }
    }
}
