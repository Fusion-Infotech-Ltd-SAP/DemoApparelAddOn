using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.Routing", "Resources/Routing.b1f")]
    class Routing : UserFormBase
    {
        public Routing()
        {
        }
        private SAPbouiCOM.StaticText STCODE, STDESC, STCURR;
        private SAPbouiCOM.EditText ETCODE, ETDESC, ETCURR, ETDOCTRY;
        private SAPbouiCOM.Matrix MTXROUTE;
        private SAPbouiCOM.Button ADDButton, CancelButton;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.MTXROUTE = ((SAPbouiCOM.Matrix)(this.GetItem("MTXROUTE").Specific));
            this.MTXROUTE.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXROUTE_ChooseFromListAfter);
            this.MTXROUTE.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.MTXROUTE_ComboSelectAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }



        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }



        private void OnCustomInitialize()
        {

        }



        private void ETCODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                {
                    // Get the enterer Code
                    string code = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value.Trim();
                    if (!string.IsNullOrEmpty(code))
                    {
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string query = $@"SELECT 1 FROM ""@FIL_MH_ORSM"" WHERE ""Code"" = '{code.Replace("'", "''")}'";
                        oRS.DoQuery(query);
                        if (!oRS.EoF)
                        {
                            Application.SBO_Application.StatusBar.SetText("Code already exists!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
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
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_ORSM").GetValue("Code", 0);
            string name = oForm.DataSources.DBDataSources.Item("@FIL_MH_ORSM").GetValue("Name", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_MH_ORSM").GetValue("U_CURRENCY", 0);
   
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Routing Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (name == "")
            {
                Global.GFunc.ShowError("Enter Routing Name");
                oForm.ActiveItem = "ETDESC";
                return BubbleEvent = false;
            }
            else if (curr == "")
            {
                Global.GFunc.ShowError("Select Currency");
                oForm.ActiveItem = "ETCURR";
                return BubbleEvent = false;
            }
            
            // Preventing Empty Row to Add in the DB 
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_RSM1");
            int rowCount = MTXROUTE.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("Code", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXROUTE.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }
            return BubbleEvent;
        }
        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_RSM1");
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string currCode = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCURR = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETCURR.Value = currCode;

            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }

        }

        private void MTXROUTE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "CLCODE" && pVal.ItemUID == "MTXROUTE" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
                    SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_RSM1");
                    SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLCODE").Cells.Item(pVal.Row).Specific;
                    SAPbouiCOM.EditText oName = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLNAME").Cells.Item(pVal.Row).Specific;
                   
                    if (!string.IsNullOrEmpty(oCombo.Value))
                    {
                        string desc = oCombo.Selected.Description;
                        oName.Value = desc;
                    }

                    int lastRow = oMatrix.RowCount;
                    if (pVal.Row ==lastRow)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                    }  
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in ComboSelectAfter: " + ex.Message);
            }

        }
        private void MTXROUTE_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_RSM1");
           

            try
            {
                if (pVal.ColUID == "CLIMTCOD" && pVal.ItemUID == "MTXROUTE" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string itemCode = oDataTable.GetValue("ItemCode", 0).ToString();
                        int row = pVal.Row; 
                        oMatrix.SetCellWithoutValidation(row, "CLIMTCOD", itemCode);
                        oMatrix.FlushToDataSource();
                    }
                }
                else if (pVal.ColUID == "CLWRHUS" && pVal.ItemUID == "MTXROUTE" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string whsCode = oDataTable.GetValue("WhsCode", 0).ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLWRHUS", whsCode);
                        oMatrix.FlushToDataSource();
                    }
                }
                else if (pVal.ColUID == "CLUOM" && pVal.ItemUID == "MTXROUTE" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string uomCode = oDataTable.GetValue("UomCode", 0).ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLUOM", uomCode);
                        oMatrix.FlushToDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in CFL: " + ex.Message);
            }

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_ROUTNG");
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_RSM1");
            int lastRow = oMatrix.RowCount;
            if (lastRow > 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }

        }
    }
}
