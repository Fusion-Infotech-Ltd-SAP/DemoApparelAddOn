using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.OTT", "Resources/OTT.b1f")]
    class OTT : UserFormBase
    {
        public OTT()
        {
        }

        private SAPbouiCOM.StaticText STDATE, STSTATUS, STBRAND, STDOCNUM, STDDATE,
                                      STMERCH, STPLNQTY, STREMRK;

        private SAPbouiCOM.EditText ETDOCTRY, ETPLNQTY, ETDOCNUM,
                                      ETDDATE, ETMERCHC, ETMERCHN, ETBRANDC, EXTREMRK;

        private SAPbouiCOM.Button ADDButton, CancelButton;

        private SAPbouiCOM.Matrix MTXOTT;

        private SAPbouiCOM.ComboBox CBSTATUS;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            //                          ------> Static Text <------\\
            this.STDATE = ((SAPbouiCOM.StaticText)(this.GetItem("STDATE").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STBRAND = ((SAPbouiCOM.StaticText)(this.GetItem("STBRAND").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDDATE = ((SAPbouiCOM.StaticText)(this.GetItem("STDDATE").Specific));
            this.STMERCH = ((SAPbouiCOM.StaticText)(this.GetItem("STMERCH").Specific));
            this.STPLNQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STPLNQTY").Specific));
            this.STREMRK = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRK").Specific));
            //                          ------> Edit Text <------\\
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETBRANDC = ((SAPbouiCOM.EditText)(this.GetItem("ETBRANDC").Specific));
            this.ETPLNQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETPLNQTY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDDATE = ((SAPbouiCOM.EditText)(this.GetItem("ETDDATE").Specific));
            this.ETMERCHC = ((SAPbouiCOM.EditText)(this.GetItem("ETMERCHC").Specific));
            this.ETMERCHN = ((SAPbouiCOM.EditText)(this.GetItem("ETMERCHN").Specific));
            this.EXTREMRK = ((SAPbouiCOM.EditText)(this.GetItem("EXTREMRK").Specific));
            //                          ------> Matrix <------\\
            this.MTXOTT = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOTT").Specific));
            //                          ------> Combo Box <------\\
            this.CBSTATUS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATUS").Specific));
            //                          ------> Button <------\\
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            //                          ------> CFL Event <------\\
            this.ETBRANDC.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRANDC_ChooseFromListBefore);
            this.ETBRANDC.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRANDC_ChooseFromListAfter);
            this.MTXOTT.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXOTT_ChooseFromListAfter);
            this.MTXOTT.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.MTXOTT_LinkPressedBefore);
            this.ETMERCHC.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETMERCHC_ChooseFromListAfter);
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            //          ------> Validation <------\\
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            //          ------> Lost Focus (Date Picker) <------\\
            this.MTXOTT.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXOTT_LostFocusAfter);
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
        { }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                oForm.Freeze(true);
                //Init Matrix
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");
                //New Line Add
                int lastRow = oMatrix.RowCount;
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");
                oForm.Freeze(false);
            }
            catch (Exception e)
            {
                oForm.Freeze(false);
            }
        }

        private void MTXOTT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;

            if (pVal.ItemUID == "MTXOTT" && pVal.ColUID == "CLSHIPDT")
            {
                // Get the cell value (date) from the current row
                SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSHIPDT").Cells.Item(pVal.Row).Specific;
                string dateValue = oCell.Value; // Format: YYYYMMDD

                if (!string.IsNullOrEmpty(dateValue))
                {
                    DateTime selectedDate = DateTime.ParseExact(dateValue, "yyyyMMdd", null);
                    // Subtract 3 days
                    DateTime newDate = selectedDate.AddDays(-3);
                    string formattedNewDate = newDate.ToString("yyyyMMdd");
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXFDT").Cells.Item(pVal.Row).Specific).Value = formattedNewDate;
                }
            }
        }

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {

                oForm.Freeze(true);
                SAPbouiCOM.EditText etOttDate = (SAPbouiCOM.EditText)oForm.Items.Item("ETDATE").Specific;
                SAPbouiCOM.EditText etBrandCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRANDC").Specific;
                SAPbouiCOM.EditText etDocumentDate = (SAPbouiCOM.EditText)oForm.Items.Item("ETDDATE").Specific;
                SAPbouiCOM.EditText etMerchrCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHC").Specific;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                int AccLastRow = oMatrix.RowCount;
                int lastRow = oMatrix.RowCount;
                if (lastRow > 1)
                { lastRow = lastRow - 1; }

                int count1 = 0;  //Style No Count
                int count2 = 0;  //EX Factory Date Count
                int count3 = 0;  //Ship DAte
                int count4 = 0;  //Quantity
                int count5 = 0;  //Extra Order%
                int count6 = 0;  //Wastage%
                for (int i = 1; i <= lastRow; i++)
                {
                    string CLStylNo = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLNO").Cells.Item(i).Specific).Value;
                    if (CLStylNo == "")
                    {
                        count1 = +1;
                    }

                    string ExFactDate = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXFDT").Cells.Item(i).Specific).Value;
                    if (ExFactDate == "")
                    {
                        count2 = +1;
                    }

                    string ShipDate = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSHIPDT").Cells.Item(i).Specific).Value;
                    if (ShipDate == "")
                    {
                        count3 = +1;
                    }

                    string Quantity = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLQTY").Cells.Item(i).Specific).Value;
                    if (Quantity == "0.0")
                    {
                        count4 = +1;
                    }

                    string ExtraOrder = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CEXTORDR").Cells.Item(i).Specific).Value;
                    if (ExtraOrder == "0.0")
                    {
                        count5 = +1;
                    }

                    string Wastage = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLWASTG").Cells.Item(i).Specific).Value;
                    if (Wastage == "0.0")
                    {
                        count6 = +1;
                    }
                }

                if (etOttDate.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout OTT Date!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (etBrandCode.Value == "")
                {
                    //Application.SBO_Application.MessageBox("Fillout Brand!");

                    Application.SBO_Application.StatusBar.SetText("Fillout Brand!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (etDocumentDate.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout Document Date!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (etMerchrCode.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout Merchadiser!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count1 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Style No Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count2 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("EX Factory Date Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count3 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Ship Date Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count4 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Quantity Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count5 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Extra Order(%) Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (count6 > 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Wastage(%) Can't be Initial!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else
                {
                    //Last Empty Row Delete
                    if (AccLastRow > 0)
                    {
                        SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLNO").Cells.Item(AccLastRow).Specific;
                        string itemCode = oCell.Value.Trim();

                        if (string.IsNullOrEmpty(itemCode))
                        {
                            oMatrix.DeleteRow(AccLastRow);
                        }
                    }

                }
                oForm.Freeze(false);
            }
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                oForm.Freeze(true);
                GlobalFunction gf = new GlobalFunction();
                int num = gf.GetDocNum("@FIL_DH_PLANOTT");

                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                etDocNum.Value = num.ToString();

                //Init Matrix
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");

                //New Line Add
                int lastRow = oMatrix.RowCount;
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");
                oForm.Freeze(false);
            }
        }

        private void ETBRANDC_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFLBRAND");

            SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

            SAPbouiCOM.Condition oCon = oCons.Add();
            oCon.Alias = "U_ACTIVE";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "Y";

            oCFL.SetConditions(oCons);
        }

        private void ETBRANDC_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string Code = dt.GetValue("Code", 0).ToString().Trim();
                string Name = dt.GetValue("Name", 0).ToString().Trim();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etBrandCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRANDC").Specific;
                SAPbouiCOM.EditText etBrandName = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRANDN").Specific;

                etBrandCode.Value = Code;
                etBrandName.Value = Name;

                oForm.Freeze(true);
                //////-----------------------Other Activities---------------------////
                //Clear Matrix fOR Reselect
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                int rowCount = oMatrix.RowCount;
                for (int i = rowCount; i >= 1; i--)  // Remove from bottom to top
                { oMatrix.DeleteRow(i); }

                //Init Matrix
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");
                //New Line Add
                int lastRow = oMatrix.RowCount;
                if (lastRow == 0)
                {
                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                }
                oForm.Freeze(false);

                //Band wise Style
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFLSTYLE");
                SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                // First condition: U_BRAND = Code
                SAPbouiCOM.Condition oCon1 = oCons.Add();
                oCon1.Alias = "U_BRAND";
                oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon1.CondVal = Code;

                //  Second condition: U_ACTIVE = 'Y'
                SAPbouiCOM.Condition oCon2 = oCons.Add();
                oCon2.Alias = "U_ACTIVE";
                oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon2.CondVal = "Y";
                oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                oCFL.SetConditions(oCons);
            }
            catch (Exception e)
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(false);
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }
        }

        private void ETMERCHC_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string Code = dt.GetValue("empID", 0).ToString().Trim();
                string Name = dt.GetValue("U_FNAME", 0).ToString().Trim();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etBrandCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHC").Specific;
                SAPbouiCOM.EditText etBrandName = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHN").Specific;

                etBrandCode.Value = Code;
                etBrandName.Value = Name;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }
        }

        private void MTXOTT_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;


            try
            {
                // Get the form
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;

                // Get the value from the clicked row/column
                SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLNO").Cells.Item(pVal.Row).Specific;
                string styleCode = oCell.Value?.Trim();

                if (string.IsNullOrEmpty(styleCode))
                {
                    Application.SBO_Application.StatusBar.SetText("No Style Code in this row.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    return;
                }

                // Open Style Master form
                StyleMaster styleMaster = new StyleMaster();
                styleMaster.Show();

                // Wait shortly to let the form load
                System.Threading.Thread.Sleep(200);

                // Find the newly opened form
                SAPbouiCOM.Form cForm = null;
                foreach (SAPbouiCOM.Form frm in Application.SBO_Application.Forms)
                {
                    if (frm.UniqueID == "FIL_FRM_STYLMSTR")
                    {
                        cForm = frm;
                        break;
                    }
                }

                if (cForm != null)
                {
                    cForm.Freeze(true);

                    // Put the form in Find mode
                    cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;

                    // Enable the field and prefill value
                    cForm.Items.Item("ETSTYLID").Enabled = true;
                    SAPbouiCOM.EditText cETSTYLID = (SAPbouiCOM.EditText)cForm.Items.Item("ETSTYLID").Specific;
                    cETSTYLID.Value = styleCode;

                    // Optional: simulate clicks if required
                    cForm.Items.Item("1").Click();
                    cForm.Items.Item("FOLSZTYP").Click();

                    cForm.Freeze(false);
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("Style Master form not found.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error opening Style Master: " + ex.Message,
                 SAPbouiCOM.BoMessageTime.bmt_Short,
                 SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void MTXOTT_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                    return;
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTT").Specific;
                    SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                    if (cflArg.ItemUID == "MTXOTT" && cflArg.SelectedObjects.UniqueID == "CFLSTYLE")
                    {

                        string Code = dt.GetValue("Code", 0).ToString().Trim();
                        string Name = dt.GetValue("Name", 0).ToString().Trim();

                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLNO", Code);
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLNM", Name);

                        string CustStyNo = dt.GetValue("U_BUYRCODE", 0).ToString().Trim();
                        string CustStyNAM = dt.GetValue("U_BURSNAME", 0).ToString().Trim();

                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCSTYLC", CustStyNo);
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCSTYLN", CustStyNAM);

                        oForm.Freeze(true);
                        ////initialization
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRCD", "");
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRNAM", "");
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSIZECD", "");
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSIZENM", "");

                        // Add new row if last row has data
                        SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PLANOTT");
                        int lastRow = oMatrix.RowCount;
                        bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLNO").Cells.Item(lastRow).Specific).Value);

                        if (pVal.Row == lastRow && lastRowHasData)
                        {
                            Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                        }
                        oForm.Freeze(false);

                        //////Style wise Colour--start
                        SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFLCOLOUR");

                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string sql = $"Select DISTINCT(A.\"U_ColourCode\") As \"Code\" FROM \"@FIL_MR_PSMCO\" A LEFT OUTER JOIN \"@FIL_MH_OCOM\" B ON A.\"U_ColourCode\" = B.\"Code\" WHERE B.\"U_ACTIVE\" = 'Y' AND A.\"Code\" = '" + Code + "'";
                        oRS.DoQuery(sql);

                        List<string> allowedCodes = new List<string> { };

                        // Loop through all rows
                        while (!oRS.EoF)
                        {
                            string colourCode = oRS.Fields.Item("Code").Value.ToString();

                            // ✅ Add each colour code to the list
                            allowedCodes.Add(colourCode);

                            // move to next record
                            oRS.MoveNext();
                        }

                        SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                        if (allowedCodes.Count == 0)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "Code";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = "-1";
                        }
                        else
                        {

                            for (int i = 0; i < allowedCodes.Count; i++)
                            {
                                SAPbouiCOM.Condition oCon = oCons.Add();
                                oCon.Alias = "Code";
                                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCon.CondVal = allowedCodes[i];

                                // Relationship must be set on the previous condition
                                if (i > 0)
                                    oCons.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            }
                        }
                        oCFL.SetConditions(oCons);
                        //////Style wise Colour--End


                        //////Style wise Size--start
                        SAPbouiCOM.ChooseFromList oCFL_STYLE = oForm.ChooseFromLists.Item("CFLSIZE");

                        SAPbobsCOM.Recordset oRS_STYLE = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string sql_STYLE = $"Select DISTINCT(A.\"U_SizeCode\") As \"Code\" FROM \"@FIL_MR_PSMST\" A LEFT OUTER JOIN \"@FIL_MH_SIZEMSTR\" B ON A.\"U_SizeCode\" = B.\"Code\" WHERE B.\"U_ACTIVE\" = 'Y' AND A.\"Code\" = '" + Code + "'";
                        oRS_STYLE.DoQuery(sql_STYLE);

                        List<string> allowedCodes_STYLE = new List<string> { };

                        // Loop through all rows
                        while (!oRS_STYLE.EoF)
                        {
                            string colourCode_STYLE = oRS_STYLE.Fields.Item("Code").Value.ToString();

                            // ✅ Add each Size code to the list
                            allowedCodes_STYLE.Add(colourCode_STYLE);

                            // move to next record
                            oRS_STYLE.MoveNext();
                        }

                        SAPbouiCOM.Conditions oCons_STYLE = new SAPbouiCOM.Conditions();

                        if (allowedCodes_STYLE.Count == 0)
                        {
                            SAPbouiCOM.Condition oCon_STYLE = oCons_STYLE.Add();
                            oCon_STYLE.Alias = "Code";
                            oCon_STYLE.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon_STYLE.CondVal = "-1";
                        }
                        else
                        {
                            for (int i = 0; i < allowedCodes_STYLE.Count; i++)
                            {
                                SAPbouiCOM.Condition oCon_STYLE = oCons_STYLE.Add();
                                oCon_STYLE.Alias = "Code";
                                oCon_STYLE.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCon_STYLE.CondVal = allowedCodes_STYLE[i];

                                // Relationship must be set on the previous condition
                                if (i > 0)
                                    oCons_STYLE.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            }
                        }
                        oCFL_STYLE.SetConditions(oCons_STYLE);
                        //////Style wise Size--End

                    }
                    else if (cflArg.ItemUID == "MTXOTT" && cflArg.SelectedObjects.UniqueID == "CFLCOLOUR")
                    {
                        string Code = dt.GetValue("Code", 0).ToString().Trim();
                        string Name = dt.GetValue("Name", 0).ToString().Trim();

                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRCD", Code);
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRNAM", Name);
                    }
                    else if (cflArg.ItemUID == "MTXOTT" && cflArg.SelectedObjects.UniqueID == "CFLSIZE")
                    {
                        string Code = dt.GetValue("Code", 0).ToString().Trim();
                        string Name = dt.GetValue("Name", 0).ToString().Trim();

                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSIZECD", Code);
                        oMatrix.SetCellWithoutValidation(pVal.Row, "CLSIZENM", Name);
                    }

                }
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(false);
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
    }
}
