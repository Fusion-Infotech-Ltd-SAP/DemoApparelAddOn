using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;
using System.Globalization;


namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.MasterLC", "Resources/MasterLC.b1f")]
    class MasterLC : UserFormBase
    {
        public MasterLC()
        {
        }

        private SAPbouiCOM.StaticText STCMPANY, STBPBNK2, STLCVAL, STRSCAMT, STCUSTMR, STSCNO, STLCNO, STDESC, STADNTNO, STISSBNK, STNEGBNK, STVALUE, STSTATUS, STSCVAL, STCURR, STDOCNUM, STDOCDAT, STSHIPDT, STEXDATE, STB2BLCP, STCONVAL, STPTRMS1, STPTRMS2, STIOTRMS, STMMODE, STCMODE, STISUDAT, STDCTYPE, STREMRKS;
        private SAPbouiCOM.ComboBox CBMMODE, CBBPBNK2, CBISSBNK, CBNEGBNK, CBCMPANY, CBCMODE, CBPTRMS1, CBPTRMS2, CBIOTRMS, CBDCTYPE;
        private SAPbouiCOM.EditText ETCUSTMR, ETBPBNK2, ETBPBNM2, ETLCVAL, ETSTFULL, ETRSCAMT, ETSTATUS, ETCDNAME, ETSCVAL, ETSCNO, ETSCNTRY, ETLCNO, ETDESC, ETADNTNO, ETISSBNK, ETIBNKNM, ETNEGBNK, ETNGBNAM, ETVALUE, ETCURR, ETDOCNUM, ETDOCDAT, ETSHIPDT, ETEXDATE, ETB2BLCP, ETCONVAL, ETISUDAT, ETREMRKS, ETDOCTRY;



        private SAPbouiCOM.Folder FOLCUSPO, FOLAMDHS, FOLATTAC;
        private SAPbouiCOM.Matrix MTXCUSPO, MTXATTAC;
        private SAPbouiCOM.Grid GRIDADNT;
        private SAPbouiCOM.Button ADDButton, CancelButton, BRWSBTN, DISPBTN, DELBTN;


      
       

       


        public static bool cflFlag = false;
        public static bool commercialFlag = false;
        //public static double remain = 0.0;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.STCMPANY = ((SAPbouiCOM.StaticText)(this.GetItem("STCMPANY").Specific));
            this.STCUSTMR = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTMR").Specific));
            this.STSCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STSCNO").Specific));
            this.STLCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STLCNO").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.STADNTNO = ((SAPbouiCOM.StaticText)(this.GetItem("STADNTNO").Specific));
            this.STISSBNK = ((SAPbouiCOM.StaticText)(this.GetItem("STISSBNK").Specific));
            this.STNEGBNK = ((SAPbouiCOM.StaticText)(this.GetItem("STNEGBNK").Specific));
            this.STVALUE = ((SAPbouiCOM.StaticText)(this.GetItem("STVALUE").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STSCVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STSCVAL").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STSHIPDT = ((SAPbouiCOM.StaticText)(this.GetItem("STSHIPDT").Specific));
            this.STEXDATE = ((SAPbouiCOM.StaticText)(this.GetItem("STEXDATE").Specific));
            this.STB2BLCP = ((SAPbouiCOM.StaticText)(this.GetItem("STB2BLCP").Specific));
            this.STCONVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STCONVAL").Specific));
            this.STPTRMS1 = ((SAPbouiCOM.StaticText)(this.GetItem("STPTRMS1").Specific));
            this.STPTRMS2 = ((SAPbouiCOM.StaticText)(this.GetItem("STPTRMS2").Specific));
            this.STIOTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STIOTRMS").Specific));
            this.CBCMPANY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCMPANY").Specific));
            this.ETCUSTMR = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTMR").Specific));
            this.ETCUSTMR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSTMR_ChooseFromListAfter);
            this.ETSTATUS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATUS").Specific));
            this.ETCDNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETCDNAME").Specific));
            this.ETSCVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETSCVAL").Specific));
            this.ETSCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNO").Specific));
            this.ETSCNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSCNO_ChooseFromListAfter);
            this.ETSCNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNTRY").Specific));
            this.ETLCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETLCNO").Specific));
            this.ETLCNO.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETLCNO_LostFocusAfter);
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.ETADNTNO = ((SAPbouiCOM.EditText)(this.GetItem("ETADNTNO").Specific));
            this.ETISSBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETISSBNK").Specific));
            this.ETISSBNK.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETISSBNK_ClickAfter);
            this.ETISSBNK.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETISSBNK_ChooseFromListBefore);
            this.ETISSBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETISSBNK_ChooseFromListAfter);
            this.ETIBNKNM = ((SAPbouiCOM.EditText)(this.GetItem("ETIBNKNM").Specific));
            this.ETNEGBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETNEGBNK").Specific));
            this.ETNEGBNK.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETNEGBNK_ClickAfter);
            this.ETNEGBNK.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETNEGBNK_ChooseFromListBefore);
            this.ETNEGBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETNEGBNK_ChooseFromListAfter);
            this.ETNGBNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETNGBNAM").Specific));
            this.ETVALUE = ((SAPbouiCOM.EditText)(this.GetItem("ETVALUE").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETSHIPDT = ((SAPbouiCOM.EditText)(this.GetItem("ETSHIPDT").Specific));
            this.ETEXDATE = ((SAPbouiCOM.EditText)(this.GetItem("ETEXDATE").Specific));
            this.ETB2BLCP = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BLCP").Specific));
            this.ETB2BLCP.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETB2BLCP_LostFocusAfter);
            this.ETCONVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETCONVAL").Specific));
            this.CBPTRMS1 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPTRMS1").Specific));
            this.CBPTRMS1.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPTRMS1_ComboSelectAfter);
            this.CBPTRMS2 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPTRMS2").Specific));
            this.CBIOTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBIOTRMS").Specific));
            this.FOLCUSPO = ((SAPbouiCOM.Folder)(this.GetItem("FOLCUSPO").Specific));
            this.FOLAMDHS = ((SAPbouiCOM.Folder)(this.GetItem("FOLAMDHS").Specific));
            this.FOLATTAC = ((SAPbouiCOM.Folder)(this.GetItem("FOLATTAC").Specific));
            this.MTXCUSPO = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCUSPO").Specific));
            this.MTXCUSPO.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCUSPO_ChooseFromListAfter);
            this.GRIDADNT = ((SAPbouiCOM.Grid)(this.GetItem("GRIDADNT").Specific));
            this.ETISUDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.STISUDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STISUDAT").Specific));
            this.STDCTYPE = ((SAPbouiCOM.StaticText)(this.GetItem("STDCTYPE").Specific));
            this.CBDCTYPE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBDCTYPE").Specific));
            this.CBDCTYPE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBDCTYPE_ComboSelectAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STRSCAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STRSCAMT").Specific));
            this.ETRSCAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETRSCAMT").Specific));
            this.ETSTFULL = ((SAPbouiCOM.EditText)(this.GetItem("ETSTFULL").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.BRWSBTN_ClickAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DISPBTN_ClickAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DELBTN_ClickAfter);
            this.MTXATTAC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTAC").Specific));
            this.STMMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STMMODE").Specific));
            this.CBMMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBMMODE").Specific));
            this.CBMMODE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBMMODE_ComboSelectAfter);
            this.STCMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCMODE").Specific));
            this.CBCMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCMODE").Specific));
            this.CBCMODE.LostFocusAfter += new SAPbouiCOM._IComboBoxEvents_LostFocusAfterEventHandler(this.CBCMODE_LostFocusAfter);
            this.CBCMODE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBCMODE_ComboSelectAfter);
            this.STLCVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STLCVAL").Specific));
            this.ETLCVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETLCVAL").Specific));
            this.ETLCVAL.GotFocusAfter += new SAPbouiCOM._IEditTextEvents_GotFocusAfterEventHandler(this.ETLCVAL_GotFocusAfter);
            this.ETLCVAL.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETLCVAL_LostFocusAfter);
            this.STBPBNK2 = ((SAPbouiCOM.StaticText)(this.GetItem("STBPBNK2").Specific));
            this.CBBPBNK2 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBPBNK2").Specific));
            this.CBISSBNK = ((SAPbouiCOM.ComboBox)(this.GetItem("CBISSBNK").Specific));
            this.CBNEGBNK = ((SAPbouiCOM.ComboBox)(this.GetItem("CBNEGBNK").Specific));
            this.ETBPBNK2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNK2").Specific));
            this.ETBPBNK2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETBPBNK2_ClickAfter);
            this.ETBPBNK2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBPBNK2_ChooseFromListAfter);
            this.ETBPBNK2.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBPBNK2_ChooseFromListBefore);
            this.ETBPBNM2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNM2").Specific));
            this.OnCustomInitialize();

        }





        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickBefore += new RightClickBeforeHandler(this.Form_RightClickBefore);

        }
        private void OnCustomInitialize()
        {

        }
        private void ETCUSTMR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string cardCode = dt.GetValue("CardCode", 0).ToString();
                string cardName = dt.GetValue("CardName", 0).ToString();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etCusCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTMR").Specific;
                SAPbouiCOM.EditText etCusNam = (SAPbouiCOM.EditText)oForm.Items.Item("ETCDNAME").Specific;

                etCusCode.Value = cardCode;
                etCusNam.Value = cardName;

                cflFlag = true;

                //MAtrix Load
                SAPbouiCOM.DBDataSource DBDataSourceLine = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
                SAPbouiCOM.Matrix MTXCUSPO = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCUSPO").Specific;
                if (MTXCUSPO.VisualRowCount == 0 && cflFlag == true)
                {
                    Global.GFunc.SetNewLine(MTXCUSPO, DBDataSourceLine, 1, "");// added the line for matrix 1
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }
        }

        private void ETISSBNK_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                // Cast to the ChooseFromList event interface
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                // Now you can get the CFL UID
                string cflUID = cflArg.ChooseFromListUID; // e.g. "CFL_OSCM"

                if (cflUID == "CFL_ODSC")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBISSBNK").Specific;
                    string selectedValue = CBISSBNK.Value;

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();
                    oCon.Alias = "CountryCod";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = selectedValue;
                    oCFL.SetConditions(oCons);
                }
            }
            catch (InvalidCastException)
            {
                // If cast fails, you can still try to apply filter by CFL UID directly (see Option B)
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error filtering CFL: " + ex.Message);
                BubbleEvent = false;
            }
        }

        private void ETISSBNK_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBISSBNK").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBISSBNK").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }
        }

        private void ETNEGBNK_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBNEGBNK").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBNEGBNK").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }
        }

        private void ETBPBNK2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBNK2").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBBPBNK2").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }
        }

        private void ETISSBNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string bankCode = dt.GetValue("BankCode", 0).ToString().Trim();
                string bankName = dt.GetValue("BankName", 0).ToString().Trim();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etIssBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETISSBNK").Specific;
                etIssBnk.Value = bankCode;
                SAPbouiCOM.EditText etIBnkNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETIBNKNM").Specific;
                etIBnkNm.Value = bankName;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }

        private void ETBPBNK2_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                // Cast to the ChooseFromList event interface
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                // Now you can get the CFL UID
                string cflUID = cflArg.ChooseFromListUID; // e.g. "CFL_OSCM"

                if (cflUID == "CFL_ODSC2")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.ComboBox CBISSBNK2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBNK2").Specific;
                    string selectedValue = CBISSBNK2.Value;

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();
                    oCon.Alias = "CountryCod";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = selectedValue;
                    oCFL.SetConditions(oCons);
                }
            }
            catch (InvalidCastException)
            {
                // If cast fails, you can still try to apply filter by CFL UID directly (see Option B)
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error filtering CFL: " + ex.Message);
                BubbleEvent = false;
            }

        }

        private void ETBPBNK2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string bankCode = dt.GetValue("BankCode", 0).ToString().Trim();
                string bankName = dt.GetValue("BankName", 0).ToString().Trim();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText ETBPBNK2 = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNK2").Specific;
                ETBPBNK2.Value = bankCode;
                SAPbouiCOM.EditText ETBPBNM2 = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNM2").Specific;
                ETBPBNM2.Value = bankName;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }
        private void ETNEGBNK_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                // Cast to the ChooseFromList event interface
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                // Now you can get the CFL UID
                string cflUID = cflArg.ChooseFromListUID; // e.g. "CFL_OSCM"

                if (cflUID == "CFL_DSC1")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBNEGBNK").Specific;
                    string selectedValue = CBNEGBNK.Value;

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();
                    oCon.Alias = "Branch";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = selectedValue;
                    oCFL.SetConditions(oCons);
                }
            }
            catch (InvalidCastException)
            {
                // If cast fails, you can still try to apply filter by CFL UID directly (see Option B)
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error filtering CFL: " + ex.Message);
                BubbleEvent = false;
            }

        }

        private void ETNEGBNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string account = dt.GetValue("Account", 0).ToString();

                //// Run query to get BankCode from DSC1
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = $"SELECT \"BankCode\" FROM DSC1 WHERE \"Account\" = '{account.Replace("'", "''")}'";
                oRS.DoQuery(sql);

                string bankCode = "";
                if (!oRS.EoF)
                {
                    bankCode = oRS.Fields.Item("BankCode").Value.ToString();
                }
                // Example: set to an EditText on the form
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etNegBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETNEGBNK").Specific;
                etNegBnk.Value = account;
                SAPbouiCOM.EditText etNegBNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETNGBNAM").Specific;
                etNegBNm.Value = bankCode;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }
        }

        
        private void ETLCVAL_GotFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox cbDocType = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDCTYPE").Specific;
                string selectedValue = cbDocType.Selected == null ? "" : cbDocType.Selected.Value;
                if (string.IsNullOrEmpty(selectedValue))
                {
                    // No selection → set focus to combo box
                    oForm.Items.Item("CBDCTYPE").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in ETLCVAL_GotFocusAfter: " + ex.Message);
            }
        }

        private void ETLCVAL_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDCTYPE").Specific;
            SAPbouiCOM.EditText ETAmt = (SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific;
            string selectedValue = oCombo.Value;
            string amt = ETAmt.Value;
            double rVal = 0.0;
            if (selectedValue == "LC" && amt == "0.0")
            {
                SAPbouiCOM.EditText LCval = (SAPbouiCOM.EditText)oForm.Items.Item("ETLCVAL").Specific;
                if (!string.IsNullOrWhiteSpace(LCval.Value))
                {
                    double.TryParse(LCval.Value, out rVal);
                }
                SAPbouiCOM.EditText RemainValue = (SAPbouiCOM.EditText)oForm.Items.Item("ETRSCAMT").Specific;
                string val=rVal.ToString();
                //remain = rVal;
                RemainValue.Value = val;
            }
        }
        
        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string currCode = dt.GetValue("CurrCode", 0).ToString();
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etCurr = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
                etCurr.Value = currCode;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
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
            string companyCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_BranchCode", 0);
            string docType = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_DocType", 0);
            string lcNo = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_LCNo", 0);
            string issuingBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_IssueBank", 0);
            string negBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_NegBank", 0);
            string value = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_Amt", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_Curr", 0);
            string docDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_DocDate", 0);
            string issueDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_IssueDate", 0);
            string shipmentDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_ShipDate", 0);
            string expiryDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_ExpDate", 0);
            string lcMode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("U_MLCTTS", 0);
            string dnum = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM").GetValue("DocNum", 0);

            if (companyCode == "")
            {
                Global.GFunc.ShowError("Select Company Code");
                oForm.ActiveItem = "CBCMPANY";
                return BubbleEvent = false;
            }
            else if (docType == "")
            {
                Global.GFunc.ShowError("Select Document Type");
                oForm.ActiveItem = "CBDCTYPE";
                return BubbleEvent = false;
            }
            else if (lcNo == "")
            {
                Global.GFunc.ShowError("Enter LC Number");
                oForm.ActiveItem = "ETLCNO";
                return BubbleEvent = false;
            }
            else if (lcMode == "")
            {
                Global.GFunc.ShowError("Select LC Mode");
                oForm.ActiveItem = "CBLCMODE";
                return BubbleEvent = false;
            }
            else if (issuingBank == "")
            {
                Global.GFunc.ShowError("Select the Issuing Bank");
                oForm.ActiveItem = "ETISSBNK";
                return BubbleEvent = false;
            }
            else if (negBank == "")
            {
                Global.GFunc.ShowError("Select The Negotiation Bank ");
                oForm.ActiveItem = "ETNEGBNK";
                return BubbleEvent = false;
            }
            else if (value == "")
            {
                Global.GFunc.ShowError("Enter the Value");
                oForm.ActiveItem = "ETVALUE";
                return BubbleEvent = false;
            }
            else if (curr == "")
            {
                Global.GFunc.ShowError("Select the Currency ");
                oForm.ActiveItem = "ETCURR";
                return BubbleEvent = false;
            }
            else if (docDate == "")
            {
                Global.GFunc.ShowError("Select the Document Date");
                oForm.ActiveItem = "ETDOCDAT";
                return BubbleEvent = false;
            }
            else if (issueDate == "")
            {
                Global.GFunc.ShowError("Select the Issuing Date");
                oForm.ActiveItem = "ETISUDAT";
                return BubbleEvent = false;
            }
            else if (shipmentDate == "")
            {
                Global.GFunc.ShowError("Select the Shipment Date");
                oForm.ActiveItem = "ETSHIPDT";
                return BubbleEvent = false;
            }
            else if (expiryDate == "")
            {
                Global.GFunc.ShowError("Select the Expiry Date");
                oForm.ActiveItem = "ETEXDATE";
                return BubbleEvent = false;
            }
            // Preventing Empty Row to Add in the DB
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
            int rowCount = MTXCUSPO.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_SODocEntry", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXCUSPO.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                string mode = "";
                string amdNo = "";
                // Create Recordset object
                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                // Assuming dnum is already declared and holds your DocNum (as int or string)
                string sqlQuery = $"SELECT \"U_LCAMDNO\",\"U_CLCTTS\" FROM \"@FIL_DH_OLCM\" WHERE \"DocNum\" = {dnum}";
                oRec.DoQuery(sqlQuery);
                if (!oRec.EoF)
                {
                    mode = oRec.Fields.Item("U_CLCTTS").Value.ToString();
                    amdNo = oRec.Fields.Item("U_LCAMDNO").Value.ToString();
                }
                int val = int.TryParse(amdNo, out var result) ? result : 0;
                if (mode == "C" || val != 0)
                {
                    Application.SBO_Application.MessageBox("Access Denied !!!!Go to Amendment Form ");
                    BubbleEvent = false;
                    return BubbleEvent;
                }
            }

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                //Document number
                int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCM");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();
            }
            return BubbleEvent;
        }

        private void ETSCNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string sCNo = dt.GetValue("U_SCNo", 0).ToString();
                string scVal = dt.GetValue("U_Amt", 0).ToString();
                //string val = dt.GetValue("U_Amt", 0).ToString();
                string conAmt = dt.GetValue("U_ConAmt", 0).ToString();
                string issBnk = dt.GetValue("U_IssueBank", 0).ToString();
                string issBkNam = dt.GetValue("U_IssBName", 0).ToString();
                string negBnk = dt.GetValue("U_NegBank", 0).ToString();
                string negBkNm = dt.GetValue("U_NegBName", 0).ToString();
                string issuDate = dt.GetValue("U_IssueDate", 0).ToString();
                string shipDate = dt.GetValue("U_ShipDate", 0).ToString();
                string expDate = dt.GetValue("U_ExpDate", 0).ToString();
                string scEntry = dt.GetValue("DocEntry", 0).ToString();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Items.Item("ETISSBNK").Enabled = false;
                oForm.Items.Item("ETNEGBNK").Enabled = false;

                ETSCNO.Value = sCNo;
                ETSCVAL.Value = scVal;
                ETVALUE.Value = scVal;
                ETCONVAL.Value = conAmt;
                ETISSBNK.Value = issBnk;
                ETIBNKNM.Value = issBkNam;
                ETNEGBNK.Value = negBnk;
                ETNGBNAM.Value = negBkNm;
                ETSCNTRY.Value = scEntry;

                // Safely get and format the date values
                DateTime issueDt = Convert.ToDateTime(issuDate);
                DateTime shipDt = Convert.ToDateTime(shipDate);
                DateTime expDt = Convert.ToDateTime(expDate);

                // Format as yyyyMMdd or yyyy-MM-dd depending on your requirement
                ETISUDAT.Value = issueDt.ToString("yyyyMMdd");
                ETSHIPDT.Value = shipDt.ToString("yyyyMMdd");
                ETEXDATE.Value = expDt.ToString("yyyyMMdd");

                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = string.Format(@"SELECT IFNULL(SUM(""U_Amt""), 0) AS ""TotalAmt"" 
                 FROM ""@FIL_DH_OLCM"" 
                 WHERE ""U_SCNTRY"" = {0}", scEntry);
                oRS.DoQuery(query);

                double totalAmt = 0.0;
                if (!oRS.EoF)
                {
                    totalAmt = Convert.ToDouble(oRS.Fields.Item("TotalAmt").Value);
                    // You can now use totalAmt as needed
                }

                //double baseAmt = Convert.ToDouble(scVal);
                //remain = baseAmt - totalAmt;
                //string remainAmt = Convert.ToString(remain);
                //ETRSCAMT.Value = remainAmt;

                oForm.Items.Item("ETISSBNK").Enabled = true;
                oForm.Items.Item("ETNEGBNK").Enabled = true;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }

        private void CBDCTYPE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ItemUID == "CBDCTYPE")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDCTYPE").Specific;
                    string selectedValue = oCombo.Value;
                    if (selectedValue == "LC")
                    {
                        oForm.Freeze(true);
                        oForm.Items.Item("ETSCNO").Enabled = false;
                      //  oForm.Items.Item("ETLCVAL").Enabled = false;
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETSCVAL").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDESC").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETISSBNK").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETIBNKNM").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETNEGBNK").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETNGBNAM").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETISUDAT").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETSHIPDT").Specific).Value = "";
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETEXDATE").Specific).Value = "";
                        SAPbouiCOM.DBDataSource DBDataSourceLine = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
                        SAPbouiCOM.Matrix MTXCUSPO = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCUSPO").Specific;
                        if (MTXCUSPO.VisualRowCount == 0)
                        {
                            Global.GFunc.SetNewLine(MTXCUSPO, DBDataSourceLine, 1, "");// added the line for matrix 1
                        }
                        oForm.Freeze(false);
                    }
                    else
                    {
                        oForm.Freeze(true);
                        oForm.Items.Item("ETSCNO").Enabled = true;
                      //  oForm.Items.Item("ETLCVAL").Enabled = false;

                        //SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCUSPO").Specific;

                        //for (int i = oMatrix.RowCount; i >= 1; i--)
                        //{
                        //    oMatrix.DeleteRow(i);
                        //}
                        oForm.Freeze(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            //SAPbouiCOM.ComboBox oCBCMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
            //string csVal = oCBCMODE.Value;

            //SAPbouiCOM.ComboBox oCBMMODE = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
            //string msVal = oCBMMODE.Value;

            //if (csVal=="C" && msVal=="C")
            //{
            //    oForm.Items.Item("CBCMODE").Enabled = false;
            //    oForm.Items.Item("CBMMODE").Enabled = false;
            //}


        }

        private void MTXCUSPO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // if (pVal.BeforeAction) return;

            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCUSPO").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                string docEntry = dt.GetValue("DocEntry", 0).ToString();
                string docNum = dt.GetValue("DocNum", 0).ToString();
                string contactNo = dt.GetValue("NumAtCard", 0).ToString();
                //string styleno = dt.GetValue("U_StyleNo", 0).ToString();

               //Get quantity and open sum from RDR1
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = $@"SELECT SUM(""Quantity"") AS ""TotalQty"", SUM(""OpenSum"") AS ""TotalOpenSum"" FROM ""RDR1"" WHERE ""DocEntry"" = {docEntry}";
                oRS.DoQuery(query);

                string quantity = Convert.ToString(oRS.Fields.Item("TotalQty").Value);
                string openSum = Convert.ToString(oRS.Fields.Item("TotalOpenSum").Value);

                //Amendment no
                SAPbouiCOM.EditText ETADNTNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETADNTNO").Specific;
                string amdno = ETADNTNO.Value;

                // Set matrix values for the selected row
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLSENTY", docEntry);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLSORDR", docNum);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLCPONO", contactNo);
                //oMatrix.SetCellWithoutValidation(pVal.Row, "CLSCODE", styleno);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLQTY", quantity);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", openSum);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLBSADNO", amdno);

                // Commit to DBDataSource
                oMatrix.FlushToDataSource();

                // Now calculate totalValue from all rows
                double totalValue = 0;
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    //if (i == pVal.Row) continue; // skip the just-added row
                    string val = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(i).Specific).Value;
                    if (double.TryParse(val, out double amt))
                    {
                        totalValue += amt;
                    }
                }

                //// Add the newly added value
                //if (double.TryParse(openSum, out double newVal))
                //{
                //    totalValue += newVal;
                //}

                SAPbouiCOM.EditText ETREMAMT = (SAPbouiCOM.EditText)oForm.Items.Item("ETLCVAL").Specific;
                string remStr = ETREMAMT.Value;
                double remain = 0.0;

                if (!double.TryParse(remStr, out remain))
                {
                    remain = 0.0;
                }

                double remAmt = remain - totalValue;

                if (remAmt < 0)
                {
                    Application.SBO_Application.StatusBar.SetText("Total value cannot exceed remaining amount!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                    // Optionally clear the row values
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLSENTY", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLSORDR", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLCPONO", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLSCODE", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLQTY", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", "");
                    oMatrix.FlushToDataSource();

                    return;
                }

                // Show updated total and remaining amount
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value = totalValue.ToString("0.00");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETRSCAMT").Specific).Value = remAmt.ToString("0.00");

                // Add new row if last row has data
                int lastRow = oMatrix.RowCount;
                bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSENTY").Cells.Item(lastRow).Specific).Value);

                if (pVal.Row == lastRow && lastRowHasData)
                {
                  Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }


        private void ETB2BLCP_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // Get percentage value
                SAPbouiCOM.EditText etPercent = (SAPbouiCOM.EditText)oForm.Items.Item("ETB2BLCP").Specific;
                string percentText = etPercent.Value.Trim();
                double percentage = 0;
                double.TryParse(percentText, out percentage);

                double val = 0.0;
                SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDCTYPE").Specific;
                string selectedValue = oCombo.Value;

                if (selectedValue == "LC")
                {
                    SAPbouiCOM.EditText ETLCValue = (SAPbouiCOM.EditText)oForm.Items.Item("ETLCVAL").Specific;
                    double.TryParse(ETLCValue.Value, out val);
                }
                else
                {
                    SAPbouiCOM.EditText ETSCVALUE = (SAPbouiCOM.EditText)oForm.Items.Item("ETSCVAL").Specific;
                    double.TryParse(ETSCVALUE.Value, out val);
                }

                // Calculate remaining value
                double remainingValue = val - (val * percentage / 100);

                // Set remaining value in ETCONVAL
                SAPbouiCOM.EditText etResult = (SAPbouiCOM.EditText)oForm.Items.Item("ETCONVAL").Specific;
                etResult.Value = remainingValue.ToString("0.00"); // Format to 2 decimals
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
        }

        private void CBCMODE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (pVal.ActionSuccess)
            {
                SAPbouiCOM.ComboBox combo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
                string selectedValue = combo.Selected.Value;

                if (selectedValue == "C")
                {
                    // Show confirmation message
                    int confirm = Application.SBO_Application.MessageBox("Are you sure you want to select 'Confirm'?", 1, "Yes", "No");

                    if (confirm == 1) // "Yes" was clicked
                    {
                        // Disable the combo box
                        commercialFlag = true;
                        
                    }
                }
            }
        }

        private void CBCMODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (commercialFlag==true) 
            {
                oForm.Items.Item("CBCMODE").Enabled = false;
            }
        }

        private void ETLCNO_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // Get the entered LC No
                string lcNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();

                if (!string.IsNullOrEmpty(lcNo))
                {
                    // Create recordset
                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    // Just check for existence
                    string query = $@"SELECT 1 FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNo"" = '{lcNo.Replace("'", "''")}'";

                    oRS.DoQuery(query);

                    if (!oRS.EoF)
                    {
                        Application.SBO_Application.StatusBar.SetText("LC No already exists!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value = "";

                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void CBPTRMS1_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // Get selected value from CBPTRMS1
                SAPbouiCOM.ComboBox cb1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS1").Specific;
                string selectedValue = cb1.Selected == null ? "" : cb1.Selected.Value;

                // If selected value is "A", then set CBPTRMS2 to "A"
                if (selectedValue == "A")
                {
                    SAPbouiCOM.ComboBox cb2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS2").Specific;
                    cb2.Select("H", SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
                if (selectedValue == "V")
                {
                    SAPbouiCOM.ComboBox cb2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPTRMS2").Specific;
                    cb2.Select("O", SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        

        private void BRWSBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oFrom = Application.SBO_Application.Forms.Item("FIL_FRM_MLC");
            SAPbouiCOM.DBDataSource DBDataSourceLine = oFrom.DataSources.DBDataSources.Item("@FIL_DR_LCM2");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oFrom.Items.Item("MTXATTAC").Specific;

            // Call file dialog helper
            string filePath = FileDialogHelper.ShowFileDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                int lastRow = MTXATTAC.VisualRowCount;

                // Check if matrix has no rows or the last row's COLATTAC is filled
                bool needNewRow = (lastRow == 0) ||
                                  !string.IsNullOrEmpty(((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTAC").Cells.Item(lastRow).Specific).Value);

                if (needNewRow)
                {
                    // Add new line only if needed
                    Global.GFunc.SetNewLine(MTXATTAC, DBDataSourceLine, 1, "");
                    lastRow = MTXATTAC.VisualRowCount; // Update to new last row
                }

                // Set the file path in the appropriate row
                ((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTAC").Cells.Item(lastRow).Specific).Value = filePath;
                MTXATTAC.FlushToDataSource();
            }
        }



        private void DISPBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_MLC");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;

            for (int i = 1; i <= MTXATTAC.RowCount; i++)
            {
                if (MTXATTAC.IsRowSelected(i))
                {
                    string filePath = ((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTAC").Cells.Item(i).Specific).Value;

                    if (!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath))
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                    else
                    {
                        Application.SBO_Application.MessageBox("File does not exist or path is empty.");
                    }
                    break;
                }
            }
        }


        private void DELBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_MLC");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM2");

            // 💾 Make sure any edits in UI are pushed to DBDataSource first
            MTXATTAC.FlushToDataSource();

            for (int i = 1; i <= MTXATTAC.RowCount; i++)
            {
                if (MTXATTAC.IsRowSelected(i))
                {
                    int rowIndex = i - 1;

                    if (rowIndex >= 0 && rowIndex < DBDataSourceLine.Size)
                    {
                        // ✅ Remove record safely from DBDataSource
                        DBDataSourceLine.RemoveRecord(rowIndex);

                        // 🔁 Reassign LineId to remaining records
                        for (int j = 0; j < DBDataSourceLine.Size; j++)
                        {
                            DBDataSourceLine.Offset = j;
                            DBDataSourceLine.SetValue("LineId", j, (j + 1).ToString());
                        }

                        // ♻️ Reload matrix from the updated data
                        MTXATTAC.LoadFromDataSource();
                        Application.SBO_Application.MessageBox("Selected row deleted.");
                    }
                    else
                    {
                        Application.SBO_Application.MessageBox("Invalid row index.");
                    }

                    break; // stop after deleting one selected row
                }
            }
        }

        private void CBMMODE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_MLC");

            // Merchandise Combo
            SAPbouiCOM.ComboBox oComboMerchant = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
            string selectedValue = oComboMerchant.Value;

            if (selectedValue == "C")
            {
                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                oItem.Enabled = true;
            }
            else
            {
                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMODE");
                oItem.Enabled = false;

                SAPbouiCOM.ComboBox oComboCommercial = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
                oComboCommercial.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

            }

        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form ofrom = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(eventInfo.FormUID);

            if (eventInfo.ItemUID == "MTXCUSPO")
            {
                ofrom.EnableMenu("1293", true);
            }
            else
            {
                ofrom.EnableMenu("1293", false);
            }

        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oform.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                InitializeMasterLCForm(oform);
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



            }
            finally
            {
                oForm.Freeze(false);
            }
        }

    }
}
