using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SizeTypeMaster", "Resources/SizeTypeMaster.b1f")]
    class SizeTypeMaster : UserFormBase
    {
        public SizeTypeMaster()
        {
        }
        private SAPbouiCOM.StaticText STTYPE, STDESC, STPRDTYP, STPRDLN, STPRDGRP, STCONTRY, STPRDCAT;
        private SAPbouiCOM.EditText ETTYPE, ETDESC, ETDOCTRY;
        private SAPbouiCOM.Matrix MTXTMSTR;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.ComboBox CBPRDGRP, CBPRDLN, CBPRDTYP, CBCONTRY, CBPRDCAT;

        

        public override void OnInitializeComponent()
        {
            this.STTYPE = ((SAPbouiCOM.StaticText)(this.GetItem("STTYPE").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.ETTYPE = ((SAPbouiCOM.EditText)(this.GetItem("ETTYPE").Specific));
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.MTXTMSTR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTMSTR").Specific));
            this.MTXTMSTR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXTMSTR_ChooseFromListAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.CBPRDGRP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRDGRP").Specific));
            this.CBPRDGRP.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPRDGRP_ComboSelectAfter);
            this.CBPRDLN = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRDLN").Specific));
            this.CBPRDLN.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPRDLN_ComboSelectAfter);
            this.CBPRDTYP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRDTYP").Specific));
            this.CBPRDTYP.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPRDTYP_ComboSelectAfter);
            this.STPRDTYP = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDTYP").Specific));
            this.STPRDLN = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDLN").Specific));
            this.STPRDGRP = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDGRP").Specific));
            this.STCONTRY = ((SAPbouiCOM.StaticText)(this.GetItem("STCONTRY").Specific));
            this.CBCONTRY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCONTRY").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STPRDCAT = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDCAT").Specific));
            this.CBPRDCAT = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRDCAT").Specific));
            this.CBPRDCAT.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPRDCAT_ComboSelectAfter);
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }


        private void OnCustomInitialize()
        {

        }

        private void CBPRDTYP_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Item oItem = oForm.Items.Item("CBPRDLN");
            oItem.Enabled = true;
        }

        private void CBPRDLN_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Item oItem = oForm.Items.Item("CBPRDGRP");
            oItem.Enabled = true;

            //product select value
            SAPbouiCOM.ComboBox CBPRDTYP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDTYP").Specific;
            string pdVal = CBPRDTYP.Value;
            //product line select value
            SAPbouiCOM.ComboBox CBPRDLN = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDLN").Specific;
            string codeVal = CBPRDLN.Value;

            string genVal = "";
            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string query = $@"SELECT ""U_Gender"" FROM ""@FIL_MH_OPLM"" WHERE ""Code"" = '{codeVal}'";
            oRS.DoQuery(query);

            if (!oRS.EoF)
            {
                genVal = oRS.Fields.Item("U_Gender").Value.ToString();
            }

            string sql = "";
            if (genVal == "M")
            {
                //sql = $@" SELECT A.""Code"", A.""Name"" FROM ""@FIL_MH_OPGM"" A INNER JOIN ""@FIL_MH_OPLM"" B ON A.""U_PRDLINE"" = B.""Code"" WHERE A.""U_PRDTYPE"" = '{pdVal}' AND B.""U_Gender"" = '{genVal}'";
                if (pdVal == "Tops")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                }
                else if (pdVal == "Bottoms")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                }
            }
            else if (genVal == "F")
            {
                //sql = $@"SELECT * FROM ""@FIL_MH_OGTM"" WHERE ""U_FEMLACTIVE"" = 'Y' AND ""U_CATEGORY"" = '{pdVal}'";
                if (pdVal == "Tops")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                }
                else if (pdVal == "Bottoms")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                }
            }
            else if (genVal == "U")
            {
                //sql = $@"SELECT * FROM ""@FIL_MH_OGTM"" WHERE ""U_KIDSACTIVE"" = 'Y' AND ""U_CATEGORY"" = '{pdVal}'";
                if (pdVal == "Tops")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                }
                else if (pdVal == "Bottoms")
                {
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;
                    ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                }
            }
              sql = $@" SELECT A.""Code"", A.""Name"" FROM ""@FIL_MH_OPGM"" A INNER JOIN ""@FIL_MH_OPLM"" B ON A.""U_PRDLINE"" = B.""Code"" WHERE A.""U_PRDTYPE"" = '{pdVal}' AND B.""U_Gender"" = '{genVal}'";
              SAPbouiCOM.ComboBox CBPRDGRP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDGRP").Specific;
              Global.GFunc.setComboBoxValue(CBPRDGRP, sql);
        }

        private void CBPRDGRP_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Item oItem = oForm.Items.Item("CBPRDCAT");
            oItem.Enabled = true;

            SAPbouiCOM.ComboBox CBPRDGRP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDGRP").Specific;
            string grpVal = CBPRDGRP.Value;
            string sql = $@" SELECT ""Code"",""Name"" FROM ""@FIL_MH_OPCG"" WHERE ""U_PRDGRP""='{grpVal}'";
            SAPbouiCOM.ComboBox CBPRDCAT = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDCAT").Specific;
            Global.GFunc.setComboBoxValue(CBPRDCAT, sql);
        }

        private void CBPRDCAT_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_STM1");
            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }
        }

        private void MTXTMSTR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_STM1");
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string code = oDataTable.GetValue("Code", 0).ToString();
                    string name = oDataTable.GetValue("Name", 0).ToString();
                    int row = pVal.Row; // matrix row where CFL triggered
                    //Set Values
                    oMatrix.SetCellWithoutValidation(row, "CLSZCODE", code);
                    oMatrix.SetCellWithoutValidation(row, "CLSZNAME", name);
                    oMatrix.FlushToDataSource();
                    // Add new row if last row has data
                    int lastRow = oMatrix.RowCount;
                    bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSZCODE").Cells.Item(lastRow).Specific).Value);

                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
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

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

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
                        string query = $@"SELECT 1 FROM ""@FIL_MH_OSTM"" WHERE ""Code"" = '{code.Replace("'", "''")}'";
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

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("Code", 0);
            string name = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("Name", 0);
            string product = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("U_PRDTYPE", 0);
            string line = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("U_PRDLINE", 0);
            string country = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("U_COUNTRY", 0);
            string group = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("U_PRDGRP", 0);
            string cateogry = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSTM").GetValue("U_CATEGORY", 0);
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Size Type Code");
                oForm.ActiveItem = "ETTYPE";
                return BubbleEvent = false;
            }
            else if (name == "")
            {
                Global.GFunc.ShowError("Enter Size Type Name");
                oForm.ActiveItem = "ETDESC";
                return BubbleEvent = false;
            }
            else if (product == "")
            {
                Global.GFunc.ShowError("Select Product Type");
                oForm.ActiveItem = "CBPRDTYP";
                return BubbleEvent = false;
            }
            else if (line == "")
            {
                Global.GFunc.ShowError("Select Product Line");
                oForm.ActiveItem = "CBPRDLN";
                return BubbleEvent = false;
            }
            else if (country == "")
            {
                Global.GFunc.ShowError("Select The Country");
                oForm.ActiveItem = "CBCONTRY";
                return BubbleEvent = false;
            }
            else if (group == "")
            {
                Global.GFunc.ShowError("Select Product Group");
                oForm.ActiveItem = "CBPRDGRP";
                return BubbleEvent = false;
            }
            else if (cateogry == "")
            {
                Global.GFunc.ShowError("Select Product Category");
                oForm.ActiveItem = "CBPRDGRP";
                return BubbleEvent = false;
            }
            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_STM1");
            int rowCount = MTXTMSTR.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_SizeCode", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXTMSTR.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            return BubbleEvent;
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode==SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_STM1");
                if (oMatrix.RowCount > 0)
                {
                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                }

                //product select value
                SAPbouiCOM.ComboBox CBPRDTYP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDTYP").Specific;
                string pdVal = CBPRDTYP.Value;
                //product line select value
                SAPbouiCOM.ComboBox CBPRDLN = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPRDLN").Specific;
                string codeVal = CBPRDLN.Value;

                string genVal = "";
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = $@"SELECT ""U_Gender"" FROM ""@FIL_MH_OPLM"" WHERE ""Code"" = '{codeVal}'";
                oRS.DoQuery(query);

                if (!oRS.EoF)
                {
                    genVal = oRS.Fields.Item("U_Gender").Value.ToString();
                }

                if (genVal == "M")
                {
                   
                    if (pdVal == "Tops")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                    }
                    else if (pdVal == "Bottoms")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                    }
                }
                else if (genVal == "F")
                {
                    if (pdVal == "Tops")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                    }
                    else if (pdVal == "Bottoms")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                    }
                }
                else if (genVal == "U")
                {
                    if (pdVal == "Tops")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;

                    }
                    else if (pdVal == "Bottoms")
                    {
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLWAIST").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLHIP").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLINSEAM").Editable = true;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLCHEST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLSHULDR").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLLENGTH").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLBUST").Editable = false;
                        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXTMSTR").Specific).Columns.Item("CLRISE").Editable = false;
                    }
                }

            }
            
        }
    }
}
