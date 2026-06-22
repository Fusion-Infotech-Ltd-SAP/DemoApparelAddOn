using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Resources;
using Apparel_AddOn.Helper;
namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SubColor", "Resources/SubColor.b1f")]
    class SubColor : UserFormBase
    {
        public SubColor()
        {
        }
        private SAPbouiCOM.Matrix MTXSBCLR;
        private SAPbouiCOM.Button OKButton;
        private SAPbouiCOM.Button CancelButton;
        public override void OnInitializeComponent()
        {
            this.MTXSBCLR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSBCLR").Specific));
            this.MTXSBCLR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXSBCLR_ChooseFromListAfter);
            this.OKButton = ((SAPbouiCOM.Button)(this.GetItem("BTNOK").Specific));
            this.OKButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.OKButton_PressedBefore);
            this.OKButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.OKButton_PressedAfter);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.LoadBefore += new LoadBeforeHandler(this.Form_LoadBefore);

        }

        private void OnCustomInitialize()
        {

        }

        private void MTXSBCLR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSBCLR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_POS")
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string code = oDataTable.GetValue("Code", 0).ToString();
                        int row = pVal.Row; 
                        oMatrix.SetCellWithoutValidation(row, "CLPOSITN", code);
                        oMatrix.FlushToDataSource();

                        // Add new row if last row has data
                        int lastRow = oMatrix.RowCount;
                        bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific).Value);
                        if (pVal.Row == lastRow && lastRowHasData)
                        {
                            Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                        }
                    }
                }
                else if (cflUID == "CFL_OCOM")
                {
                    SAPbouiCOM.EditText ETBSLINE = (SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLBSLINE", 1);
                    string baseLine = ETBSLINE.Value;


                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string code = oDataTable.GetValue("Code", 0).ToString();
                        string name = oDataTable.GetValue("Name", 0).ToString();
                        string pantone = oDataTable.GetValue("U_PANTONE", 0).ToString();
                        
                        int row = pVal.Row; 
                        oMatrix.SetCellWithoutValidation(row, "CLCODE", code);
                        oMatrix.SetCellWithoutValidation(row, "CLNAME", name);
                        oMatrix.SetCellWithoutValidation(row, "CLPNTONE", pantone);
                        oMatrix.SetCellWithoutValidation(row, "CLBSLINE", baseLine);
                        oMatrix.FlushToDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("SIZE Matrix CFL Error: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short,
                   SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void OKButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oSubForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // --- Get parent form ID from UserDataSource ---
                string parentUID = oSubForm.DataSources.UserDataSources.Item("UDPARENT").ValueEx;
                if (string.IsNullOrEmpty(parentUID))
                    return;

                SAPbouiCOM.Form oParentForm = Application.SBO_Application.Forms.Item(parentUID);

                // --- Get both data sources ---
                SAPbouiCOM.Matrix subMatrix = (SAPbouiCOM.Matrix)oSubForm.Items.Item("MTXSBCLR").Specific;
                SAPbouiCOM.DBDataSource subDS = oSubForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
                subMatrix.FlushToDataSource();

                SAPbouiCOM.Matrix parentSubMatrix = (SAPbouiCOM.Matrix)oParentForm.Items.Item("MTXDSCLR").Specific;
                SAPbouiCOM.DBDataSource parentSubDS = oParentForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
                parentSubMatrix.FlushToDataSource();

                string baseLine = oSubForm.DataSources.UserDataSources.Item("UDBSLINE").ValueEx;

                // --- Remove existing records for this baseline ---
                for (int i = parentSubDS.Size - 1; i >= 0; i--)
                {
                    if (parentSubDS.GetValue("U_BASELINE", i).Trim() == baseLine)
                        parentSubDS.RemoveRecord(i);
                }

                // --- Determine max LineId across ALL parentSubDS rows ---
                int globalMaxLineId = 0;
                for (int i = 0; i < parentSubDS.Size; i++)
                {
                    string lineIdStr = parentSubDS.GetValue("LineId", i)?.Trim();
                    if (int.TryParse(lineIdStr, out int lineIdVal))
                        if (lineIdVal > globalMaxLineId)
                            globalMaxLineId = lineIdVal;
                }

                // --- Copy rows from subDS to parentSubDS ---
                for (int i = 0; i < subDS.Size; i++)
                {
                    string position = subDS.GetValue("U_POSITION", i)?.Trim() ?? "";
                    if (string.IsNullOrEmpty(position))
                        continue; // skip empty rows

                    int newRow = parentSubDS.Size - 1;
                    parentSubDS.InsertRecord(parentSubDS.Size);
                    

                    // --- Assign LineId globally ---
                    globalMaxLineId++;
                    parentSubDS.SetValue("LineId", newRow, globalMaxLineId.ToString());

                    // --- Copy other fields ---
                    parentSubDS.SetValue("U_BASELINE", newRow, subDS.GetValue("U_BASELINE", i));
                    parentSubDS.SetValue("U_CLRCODE", newRow, subDS.GetValue("U_CLRCODE", i));
                    parentSubDS.SetValue("U_CLRNAME", newRow, subDS.GetValue("U_CLRNAME", i));
                    parentSubDS.SetValue("U_POSITION", newRow, position);
                    parentSubDS.SetValue("U_PANTONE", newRow, subDS.GetValue("U_PANTONE", i));
                }

                // --- Reload parent matrix ---
                parentSubMatrix.LoadFromDataSource();

                // --- Put parent form into Update mode ---
                if (oParentForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oParentForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                oSubForm.Close();

                Application.SBO_Application.StatusBar.SetText("SubColor data passed to parent successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error in OKButton_PressedAfter: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }



        private void Form_LoadBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            // Create link fields
            oForm.DataSources.UserDataSources.Add("UDPARENT", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            oForm.DataSources.UserDataSources.Add("UDBSLINE", SAPbouiCOM.BoDataType.dt_LONG_NUMBER, 11);
            oForm.DataSources.UserDataSources.Add("UDCLCODE", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            oForm.DataSources.UserDataSources.Add("UDCLNAME", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            oForm.DataSources.UserDataSources.Add("UDCLPANT", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 254);
            
        }

        private void OKButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            // Preventing Empty Row to Add in the DB 
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
            int rowCount = MTXSBCLR.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_BASELINE", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXSBCLR.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

        }
    }
}
