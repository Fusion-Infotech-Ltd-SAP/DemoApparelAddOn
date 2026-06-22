using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SizeColorConsumption", "Resources/SizeColorConsumption.b1f")]
    class SizeColorConsumption : UserFormBase
    {
        private string _quantity = string.Empty;
        private int _baseline = int.MaxValue;
        public SizeColorConsumption()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.MTXSZCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSZCON").Specific));
            this.MTXSZCON.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXSZCON_ChooseFromListAfter);
            this.BTNOK = ((SAPbouiCOM.Button)(this.GetItem("BTNOK").Specific));
            this.BTNOK.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNOK_PressedAfter);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadBefore += new SAPbouiCOM.Framework.FormBase.LoadBeforeHandler(this.Form_LoadBefore);

        }

        private SAPbouiCOM.Matrix MTXSZCON;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button BTNOK, CancelButton;

        private void Form_LoadBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            // Create link fields
            oForm.DataSources.UserDataSources.Add("UDPARENT", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            oForm.DataSources.UserDataSources.Add("UDBSLINE", SAPbouiCOM.BoDataType.dt_LONG_NUMBER, 11);
            oForm.DataSources.UserDataSources.Add("UDSIZE", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            oForm.DataSources.UserDataSources.Add("UDCOLOR", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
           

        }

        private void BTNOK_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oSubForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // --- Read parent form ID ---
                string parentUID = oSubForm.DataSources.UserDataSources.Item("UDPARENT").ValueEx;
                if (string.IsNullOrEmpty(parentUID))
                    return;

                SAPbouiCOM.Form oParentForm = Application.SBO_Application.Forms.Item(parentUID);

                // --- Read data sources ---
                SAPbouiCOM.Matrix subMatrix = (SAPbouiCOM.Matrix)oSubForm.Items.Item("MTXSZCON").Specific;
              //  SAPbouiCOM.DBDataSource subDS = oSubForm.DataSources.DBDataSources.Item("@FIL_MR_SIZEDTLS");
                subMatrix.FlushToDataSource();

                SAPbouiCOM.Matrix parentSubMatrix = (SAPbouiCOM.Matrix)oParentForm.Items.Item("MTXSZCON").Specific;
                SAPbouiCOM.DBDataSource parentSubDS = oParentForm.DataSources.DBDataSources.Item("@FIL_MR_SIZEDTLS");
                parentSubMatrix.FlushToDataSource();

                SAPbouiCOM.DBDataSource subDS = oSubForm.DataSources.DBDataSources.Item("@FIL_MR_SIZEDTLS");
                SAPbouiCOM.Matrix MainMatrix = (SAPbouiCOM.Matrix)oParentForm.Items.Item("MTXTRMAC").Specific;
                string baseLine = oSubForm.DataSources.UserDataSources.Item("UDBSLINE").ValueEx;

              

                // --- Remove all old rows of this baseline ---
                for (int i = parentSubDS.Size - 1; i >= 0; i--)
                {
                    if (parentSubDS.GetValue("U_BASELINE", i).Trim() == baseLine)
                        parentSubDS.RemoveRecord(i);
                }

                // Remove blank records (do from end)
                for (int i = parentSubDS.Size - 1; i >= 0; i--)
                {
                    if (IsEmptyRow(parentSubDS, i))
                        parentSubDS.RemoveRecord(i);
                }

                // --- Determine max LineId across ALL parentSubDS rows ---
                int globalMaxLineId = 0;
                int indexRowWithOne = -1; // track index where LineId == 1 if any

                for (int i = 0; i < parentSubDS.Size; i++)
                {
                    string lineIdStr = parentSubDS.GetValue("LineId", i)?.Trim();
                    if (int.TryParse(lineIdStr, out int val))
                    {
                        if (val > globalMaxLineId)
                            globalMaxLineId = val;
                        if (val == 1)
                            indexRowWithOne = i;
                    }
                }

                // If no existing rows, globalMaxLineId stays 0.
                // We'll treat that case as normal: first new row becomes 1.
                // If there is a row with LineId==1 we will overwrite that first (only) row,
                // then append more rows starting at 2,3,...

                // --- Copy SubForm rows to Parent Form, obeying the special rule ---
                bool usedOverwriteForFirst = false;

                for (int i = 0; i < subDS.Size; i++)
                {
                    if (i == 0 && indexRowWithOne != -1 && globalMaxLineId == 1)
                    {
                        // Special case: overwrite the existing row that has LineId == 1
                        int targetRow = indexRowWithOne;

                        // overwrite fields on that existing row (do not insert)
                        parentSubDS.SetValue("LineId", targetRow, "1"); // ensure it's 1
                        parentSubDS.SetValue("U_BASELINE", targetRow, baseLine);

                        parentSubDS.SetValue("U_CLCODE", targetRow, subDS.GetValue("U_CLCODE", i));
                        parentSubDS.SetValue("U_CLRNAME", targetRow, subDS.GetValue("U_CLRNAME", i));
                        parentSubDS.SetValue("U_SIZECODE", targetRow, subDS.GetValue("U_SIZECODE", i));
                        parentSubDS.SetValue("U_SIZENAME", targetRow, subDS.GetValue("U_SIZENAME", i));
                        parentSubDS.SetValue("U_RMCLCODE", targetRow, subDS.GetValue("U_RMCLCODE", i));
                        parentSubDS.SetValue("U_RMClNAME", targetRow, subDS.GetValue("U_RMClNAME", i));
                        parentSubDS.SetValue("U_SIZEPARM", targetRow, subDS.GetValue("U_SIZEPARM", i));
                        parentSubDS.SetValue("U_QUANTITY", targetRow, subDS.GetValue("U_QUANTITY", i));
                        parentSubDS.SetValue("U_UOM", targetRow, subDS.GetValue("U_UOM", i));

                        usedOverwriteForFirst = true;

                        // globalMaxLineId currently equals 1, we will increment for subsequent rows
                        // so leave globalMaxLineId as 1 here.
                    }
                    else
                    {
                        // Normal path: insert new record and assign next LineId.
                        parentSubDS.InsertRecord(parentSubDS.Size);
                        int newRow = parentSubDS.Size - 1;

                        // If we have not used the overwrite scenario and parent had existing rows:
                        // make sure to start incrementing from the current global max.
                        // If globalMaxLineId == 0 (no existing rows) then increment to 1 for first inserted row.
                        if (globalMaxLineId == 0)
                        {
                            globalMaxLineId = 1;
                        }
                        else
                        {
                            // If we used overwrite for first then globalMaxLineId is still 1 and we want next = 2
                            // In all other normal cases globalMaxLineId is the current max so we increment.
                            globalMaxLineId++;
                        }

                        parentSubDS.SetValue("LineId", newRow, globalMaxLineId.ToString());
                        parentSubDS.SetValue("U_BASELINE", newRow, baseLine);

                        parentSubDS.SetValue("U_CLCODE", newRow, subDS.GetValue("U_CLCODE", i));
                        parentSubDS.SetValue("U_CLRNAME", newRow, subDS.GetValue("U_CLRNAME", i));
                        parentSubDS.SetValue("U_SIZECODE", newRow, subDS.GetValue("U_SIZECODE", i));
                        parentSubDS.SetValue("U_SIZENAME", newRow, subDS.GetValue("U_SIZENAME", i));
                        parentSubDS.SetValue("U_RMCLCODE", newRow, subDS.GetValue("U_RMCLCODE", i));
                        parentSubDS.SetValue("U_RMClNAME", newRow, subDS.GetValue("U_RMClNAME", i));
                        parentSubDS.SetValue("U_SIZEPARM", newRow, subDS.GetValue("U_SIZEPARM", i));
                        parentSubDS.SetValue("U_QUANTITY", newRow, subDS.GetValue("U_QUANTITY", i));
                        parentSubDS.SetValue("U_UOM", newRow, subDS.GetValue("U_UOM", i));
                    }
                }

                // Refresh parent matrix
                parentSubMatrix.LoadFromDataSource();

                string qty = "";
                if (subDS.Size > 0)
                {
                    _quantity = subDS.GetValue("U_QUANTITY", 0).Trim();
                    _baseline = Convert.ToInt32(baseLine);

                }

                if (oParentForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oParentForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                oSubForm.Close();

                //Start

                // Get first row quantity from child datasource
               // string qty = "";

               ((SAPbouiCOM.EditText)MainMatrix.Columns.Item("CLQUAN").Cells.Item(_baseline).Specific).Value = _quantity; 

                //END

                Application.SBO_Application.StatusBar.SetText(
                    "Data passed to parent successfully.",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in BTNOK_PressedAfter: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        bool IsEmptyRow(SAPbouiCOM.DBDataSource ds, int i)
        {
            string lineId = ds.GetValue("LineId", i).Trim();
            string baseline = ds.GetValue("U_BASELINE", i).Trim();
            string clcode = ds.GetValue("U_CLCODE", i).Trim();
            string sizecode = ds.GetValue("U_SIZECODE", i).Trim();

            // adjust fields if you want stronger check
            return string.IsNullOrEmpty(lineId)
                   && string.IsNullOrEmpty(baseline)
                   && string.IsNullOrEmpty(clcode)
                   && string.IsNullOrEmpty(sizecode);
        }

        private void MTXSZCON_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSZCON").Specific;

            try
            {
                if (pVal.ColUID == "CLRMCODE" && pVal.ItemUID == "MTXSZCON" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string clrCode = oDataTable.GetValue("Code", 0).ToString();
                        string clrName = oDataTable.GetValue("Name", 0).ToString();

                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLRMCODE", clrCode);
                        oMatrix.SetCellWithoutValidation(row, "CLRMNAME", clrName);
                        oMatrix.FlushToDataSource();
                        oMatrix.AutoResizeColumns();
                    }

                   
                }
                else if (pVal.ColUID == "CLSZPRAM" && pVal.ItemUID == "MTXSZCON" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string pCode = oDataTable.GetValue("Code", 0).ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLSZPRAM", pCode);
                        oMatrix.FlushToDataSource();
                    }

                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in CFL: " + ex.Message);
            }

        }
    }
}
