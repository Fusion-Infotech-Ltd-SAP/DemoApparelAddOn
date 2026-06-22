using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.CustomerBrandRelation", "Resources/CustomerBrandRelation.b1f")]
    class CustomerBrandRelation : UserFormBase
    {
        public CustomerBrandRelation()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.STCSCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCSCODE").Specific));
            this.STCSNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STCSNAME").Specific));
            this.MTXBRND = ((SAPbouiCOM.Matrix)(this.GetItem("MTXBRND").Specific));
            this.MTXBRND.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXBRND_ChooseFromListBefore);
            this.MTXBRND.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXBRND_ChooseFromListAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETCSNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETCSNAME").Specific));
            this.ETCSCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCSCODE").Specific));
            this.ETCSCODE.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCSCODE_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText STNAME, STCSCODE, STCSNAME;
        private SAPbouiCOM.Matrix MTXBRND;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.EditText ETNAME, ETDOCTRY, ETCSNAME, ETCSCODE;



        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                oForm.Freeze(true);
                ValidateForm(ref oForm, ref BubbleEvent);
                string qstr = "SELECT IFNULL(MAX(TO_INTEGER(\"Code\")) + 1, 1) AS \"Code\" FROM \"@FIL_MH_CUSTBRDMAP\"";
                rSet.DoQuery(qstr);
                oForm.DataSources.DBDataSources.Item("@FIL_MH_CUSTBRDMAP").SetValue("Code", 0, rSet.Fields.Item("Code").Value.ToString());
                oForm.Freeze(false);
            }
            else if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                oForm.Freeze(true);
                ValidateForm(ref oForm, ref BubbleEvent);
                oForm.Freeze(false);
            }



        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string cusCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_CUSTBRDMAP").GetValue("U_CUSTCODE", 0);
            string name = oForm.DataSources.DBDataSources.Item("@FIL_MH_CUSTBRDMAP").GetValue("Name", 0);


            if (cusCode == "")
            {
                Global.GFunc.ShowError("Enter Customer Code");
                oForm.ActiveItem = "ETCSCODE";
                return BubbleEvent = false;
            }
            else if (name == "")
            {
                Global.GFunc.ShowError("Enter Description");
                oForm.ActiveItem = "ETNAME";
                return BubbleEvent = false;
            }


            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_CUSTBRDMAP");
            int rowCount = MTXBRND.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_BRNDCODE", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXBRND.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }
            return BubbleEvent;
        }

        private void ETCSCODE_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string code = dt.GetValue("CardCode", 0).ToString().Trim();
            string name = dt.GetValue("CardName", 0).ToString().Trim();


            ETCSCODE.Value = code;
            ETCSNAME.Value = name;

           // ETCODE.Value =code ;

            AddLineIfLastRowHasValue(oForm, "MTXBRND", "@FIL_MR_CUSTBRDMAP", "U_BRNDCODE");

        }

        private void MTXBRND_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBRND").Specific;

            try
            {
                
                if (pVal.ColUID == "CLBRNDCD" && pVal.ItemUID == "MTXBRND" && pVal.ActionSuccess)
                {
                    oForm.Freeze(true);
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string cCode = oDataTable.GetValue("Code", 0).ToString();
                        string cName = oDataTable.GetValue("Name", 0).ToString();
                        
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLBRNDCD", cCode);
                        oMatrix.SetCellWithoutValidation(row, "CLBRNDNM", cName);
                        oMatrix.FlushToDataSource();
                        oMatrix.AutoResizeColumns();
                    }
                    AddLineIfLastRowHasValue(oForm, "MTXBRND", "@FIL_MR_CUSTBRDMAP", "U_BRNDCODE");
                    oForm.Freeze(false);

                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in CFL: " + ex.Message);
                oForm.Freeze(false);
            }

        }

        private void MTXBRND_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            string cflUID = cflArg.ChooseFromListUID;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBRND").Specific;   // your matrix ID

                // CFL object
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                // ---- RESET Existing Conditions ----
                SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                // Collect all selected Brand Codes from matrix column CLBRNDCD
                List<string> selectedBrandCodes = new List<string>();

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string val = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLBRNDCD").Cells.Item(i).Specific).Value.Trim();
                    if (!string.IsNullOrEmpty(val))
                        selectedBrandCodes.Add(val);
                }

                // ---- If there are selected brands, add NOT EQUAL conditions ----
                if (selectedBrandCodes.Count > 0)
                {
                    for (int i = 0; i < selectedBrandCodes.Count; i++)
                    {
                        SAPbouiCOM.Condition oCon = oCons.Add();
                        oCon.Alias = "Code";     // <-- FIELD IN YOUR CFL TABLE
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_NOT_EQUAL;
                        oCon.CondVal = selectedBrandCodes[i];

                        if (i < selectedBrandCodes.Count - 1)
                            oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;
                    }
                }

                oCFL.SetConditions(oCons);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(ex.Message);
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

                // Sync UI to DB first
                matrix.FlushToDataSource();

                int dbRowCount = db.Size;
                int rowcheck = matrix.VisualRowCount;
                // If no rows exist in DB → add first row
                if (rowcheck == 0)
                {
                    Global.GFunc.SetNewLine(matrix, db, 1, "");
                    return;
                }

                // Last DB row index (0 based)
                int lastDbRow = dbRowCount - 1;

                // Last value
                string lastValue = db.GetValue(columnName, lastDbRow).Trim();

                // If last row has value and not "0.0" → add new line
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

    }
}
