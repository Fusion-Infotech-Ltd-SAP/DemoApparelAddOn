using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;
using Apparel_AddOn.Modules;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.B2BLC", "Resources/B2BLC.b1f")]
    class B2BLC : UserFormBase
    {
        public B2BLC()
        {
        }

        private SAPbouiCOM.Matrix MTXMLCDS, MTXADTLS, MTXATTAC, MTXPIDAT;
        private SAPbouiCOM.Grid GRIDAMDH;
        private SAPbouiCOM.Button DISPBTN, DELBTN, BRWSBTN, ADDButton, CancelButton;
        private SAPbouiCOM.Folder FOLPIDAT, FOLMLCDS, FOLAMDHS, FOLADTLS, FOLDTSHP, FOLATTAC;



        private SAPbouiCOM.StaticText STCOMPNY, STTYTRNS, STB2LCNO, STAMDNO, STDESC, STREFRNC, STITEMNO, STBPBNK2, STBPBNK1, STSUPCOD, STNEGBNK, STVALUE, STBNKCHG, STSUPBNK, STEXPCON, STCURR, STCONTRY, STSHPMNT, STSTATUS,
        STDOCNUM, STCOMKDT, STISUDAT, STSHPDAT, STEXPDAT, STPMTRMS, STDAY, STINCTRS, STPOL, STPOD, STHSCODE,
        STFCACCT, STBUNIT, STMMODE, STCMMODE, STREMRKS, STDESCRI, STTLRNCE, STAPRATH, STAMDCLS;

        private void Form_LayoutKeyBefore(ref SAPbouiCOM.LayoutKeyInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            switch (eventInfo.EventType)
            {
                case SAPbouiCOM.BoEventTypes.et_PRINT:
                case SAPbouiCOM.BoEventTypes.et_PRINT_DATA:
                case SAPbouiCOM.BoEventTypes.et_PRINT_LAYOUT_KEY:
                    SAPbouiCOM.Form ofrom = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(eventInfo.FormUID);
                    eventInfo.LayoutKey = ofrom.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("DocEntry", 0);
                    break;
            }

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix MTXPIDAT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPIDAT").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine2 = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB2");
            if (MTXPIDAT.VisualRowCount == 0)
            {
                Global.GFunc.SetNewLine(MTXPIDAT, DBDataSourceLine2, 1, "");// added the line for matrix 1
            }

        }

        private SAPbouiCOM.ComboBox CBCOMPNY, CBTYTRNS, CBCONTRY, CBMMODE, CBPMTRMS, CBDAY, CBINCTRS, CBCMMODE, CBBPBCN2, CBBPBCN1, CBSHPMNT, CBHBBRNC;
        private SAPbouiCOM.EditText ETB2LCNO, ETAMDNO, ETAMDDT, ETDESC, ETREFRNC, ETITEMNO, ETEXPCON, ETBPBNK1, ETBPBNM2,
        ETSUPCOD, ETCURR, ETNEGBNK, ETBNKNAM, ETVALUE, ETBNKCHG, ETSUPBNK, ETSUPNAM, ETSTFULL, ETSHPMNT, ETBPBNM1,
        ETDOCNUM, ETCOMKDT, ETISUDAT, ETSHPDAT, ETEXPDAT, ETPOL, ETPOD, ETHSCODE, ETFCACCT, ETBUNIT, ETDOCTRY, ETBPBNK2,
        ETSTATUS, ETREMRKS, ETDESCRI, ETTLRNCE, ETAPRATH, ETAMDCLS;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.STCOMPNY = ((SAPbouiCOM.StaticText)(this.GetItem("STCOMPNY").Specific));
            this.STTYTRNS = ((SAPbouiCOM.StaticText)(this.GetItem("STTYTRNS").Specific));
            this.STB2LCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STB2LCNO").Specific));
            this.STAMDNO = ((SAPbouiCOM.StaticText)(this.GetItem("STAMDNO").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.STREFRNC = ((SAPbouiCOM.StaticText)(this.GetItem("STREFRNC").Specific));
            this.STITEMNO = ((SAPbouiCOM.StaticText)(this.GetItem("STITEMNO").Specific));
            this.STSUPCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STSUPCOD").Specific));
            this.STNEGBNK = ((SAPbouiCOM.StaticText)(this.GetItem("STNEGBNK").Specific));
            this.STVALUE = ((SAPbouiCOM.StaticText)(this.GetItem("STVALUE").Specific));
            this.STBNKCHG = ((SAPbouiCOM.StaticText)(this.GetItem("STBNKCHG").Specific));
            this.STBPBNK1 = ((SAPbouiCOM.StaticText)(this.GetItem("STBPBNK1").Specific));
            this.STEXPCON = ((SAPbouiCOM.StaticText)(this.GetItem("STEXPCON").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STCONTRY = ((SAPbouiCOM.StaticText)(this.GetItem("STCONTRY").Specific));
            this.STSHPMNT = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPMNT").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STCOMKDT = ((SAPbouiCOM.StaticText)(this.GetItem("STCOMKDT").Specific));
            this.STISUDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STISUDAT").Specific));
            this.STSHPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPDAT").Specific));
            this.STEXPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STEXPDAT").Specific));
            this.STPMTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STPMTRMS").Specific));
            this.STDAY = ((SAPbouiCOM.StaticText)(this.GetItem("STDAY").Specific));
            this.STINCTRS = ((SAPbouiCOM.StaticText)(this.GetItem("STINCTRS").Specific));
            this.STPOL = ((SAPbouiCOM.StaticText)(this.GetItem("STPOL").Specific));
            this.STPOD = ((SAPbouiCOM.StaticText)(this.GetItem("STPOD").Specific));
            this.STHSCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STHSCODE").Specific));
            this.STFCACCT = ((SAPbouiCOM.StaticText)(this.GetItem("STFCACCT").Specific));
            this.STBUNIT = ((SAPbouiCOM.StaticText)(this.GetItem("STBUNIT").Specific));
            this.STMMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STMMODE").Specific));
            this.STCMMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCMMODE").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.CBCOMPNY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCOMPNY").Specific));
            this.CBTYTRNS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBTYTRNS").Specific));
            this.CBTYTRNS.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBTYTRNS_ComboSelectAfter);
            this.CBCONTRY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCONTRY").Specific));
            this.CBMMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBMMODE").Specific));
            this.CBMMODE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBMMODE_ComboSelectAfter);
            this.CBPMTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPMTRMS").Specific));
            this.CBPMTRMS.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBPMTRMS_ComboSelectAfter);
            this.CBDAY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBDAY").Specific));
            this.CBINCTRS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINCTRS").Specific));
            this.CBCMMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCMMODE").Specific));
            this.ETB2LCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETB2LCNO").Specific));
            this.ETB2LCNO.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETB2LCNO_LostFocusAfter);
            this.ETAMDNO = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDNO").Specific));
            this.ETAMDDT = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDDT").Specific));
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.ETREFRNC = ((SAPbouiCOM.EditText)(this.GetItem("ETREFRNC").Specific));
            this.ETITEMNO = ((SAPbouiCOM.EditText)(this.GetItem("ETITEMNO").Specific));
            this.ETEXPCON = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPCON").Specific));
            this.ETSUPCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETSUPCOD").Specific));
            this.ETSUPCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSUPCOD_ChooseFromListAfter);
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETNEGBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETNEGBNK").Specific));
            this.ETNEGBNK.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETNEGBNK_ClickAfter);
            this.ETNEGBNK.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETNEGBNK_ChooseFromListBefore);
            this.ETNEGBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETNEGBNK_ChooseFromListAfter);
            this.ETBNKNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETBNKNAM").Specific));
            this.ETVALUE = ((SAPbouiCOM.EditText)(this.GetItem("ETVALUE").Specific));
            this.ETBNKCHG = ((SAPbouiCOM.EditText)(this.GetItem("ETBNKCHG").Specific));
            this.ETBNKCHG.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETBNKCHG_LostFocusAfter);
            this.ETBPBNK1 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNK1").Specific));
            this.ETBPBNK1.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETBPBNK1_ClickAfter);
            this.ETBPBNK1.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBPBNK1_ChooseFromListBefore);
            this.ETBPBNK1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBPBNK1_ChooseFromListAfter);
            this.ETSUPNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETSUPNAM").Specific));
            this.ETSTFULL = ((SAPbouiCOM.EditText)(this.GetItem("ETSTFULL").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETCOMKDT = ((SAPbouiCOM.EditText)(this.GetItem("ETCOMKDT").Specific));
            this.ETISUDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.ETSHPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPDAT").Specific));
            this.ETEXPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPDAT").Specific));
            this.ETPOL = ((SAPbouiCOM.EditText)(this.GetItem("ETPOL").Specific));
            this.ETPOD = ((SAPbouiCOM.EditText)(this.GetItem("ETPOD").Specific));
            this.ETHSCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETHSCODE").Specific));
            this.ETFCACCT = ((SAPbouiCOM.EditText)(this.GetItem("ETFCACCT").Specific));
            this.ETBUNIT = ((SAPbouiCOM.EditText)(this.GetItem("ETBUNIT").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETSTATUS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATUS").Specific));
            this.CBSHPMNT = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSHPMNT").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.MTXMLCDS = ((SAPbouiCOM.Matrix)(this.GetItem("MTXMLCDS").Specific));
            this.MTXMLCDS.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXMLCDS_ChooseFromListAfter);
            this.MTXADTLS = ((SAPbouiCOM.Matrix)(this.GetItem("MTXADTLS").Specific));
            this.MTXADTLS.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXADTLS_ChooseFromListAfter);
            this.MTXATTAC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTAC").Specific));
            this.MTXPIDAT = ((SAPbouiCOM.Matrix)(this.GetItem("MTXPIDAT").Specific));
            this.MTXPIDAT.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXPIDAT_ChooseFromListAfter);
            this.GRIDAMDH = ((SAPbouiCOM.Grid)(this.GetItem("GRIDAMDH").Specific));
            this.STDESCRI = ((SAPbouiCOM.StaticText)(this.GetItem("STDESCRI").Specific));
            this.STTLRNCE = ((SAPbouiCOM.StaticText)(this.GetItem("STTLRNCE").Specific));
            this.STAPRATH = ((SAPbouiCOM.StaticText)(this.GetItem("STAPRATH").Specific));
            this.STAMDCLS = ((SAPbouiCOM.StaticText)(this.GetItem("STAMDCLS").Specific));
            this.ETDESCRI = ((SAPbouiCOM.EditText)(this.GetItem("ETDESCRI").Specific));
            this.ETTLRNCE = ((SAPbouiCOM.EditText)(this.GetItem("ETTLRNCE").Specific));
            this.ETAPRATH = ((SAPbouiCOM.EditText)(this.GetItem("ETAPRATH").Specific));
            this.ETAMDCLS = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDCLS").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.BRWSBTN_ClickAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DISPBTN_ClickAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DELBTN_ClickAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.FOLPIDAT = ((SAPbouiCOM.Folder)(this.GetItem("FOLPIDAT").Specific));
            this.FOLMLCDS = ((SAPbouiCOM.Folder)(this.GetItem("FOLMLCDS").Specific));
            this.FOLAMDHS = ((SAPbouiCOM.Folder)(this.GetItem("FOLAMDHS").Specific));
            this.FOLADTLS = ((SAPbouiCOM.Folder)(this.GetItem("FOLADTLS").Specific));
            this.FOLDTSHP = ((SAPbouiCOM.Folder)(this.GetItem("FOLDTSHP").Specific));
            this.FOLATTAC = ((SAPbouiCOM.Folder)(this.GetItem("FOLATTAC").Specific));
            this.CBBPBCN1 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBPBCN1").Specific));
            this.STBPBNK2 = ((SAPbouiCOM.StaticText)(this.GetItem("STBPBNK2").Specific));
            this.ETBPBNK2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNK2").Specific));
            this.ETBPBNK2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.ETBPBNK2_ClickAfter);
            this.ETBPBNK2.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBPBNK2_ChooseFromListBefore);
            this.ETBPBNK2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBPBNK2_ChooseFromListAfter);
            this.CBBPBCN2 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBPBCN2").Specific));
            this.ETBPBNM1 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNM1").Specific));
            this.ETBPBNM2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNM2").Specific));
            this.CBHBBRNC = ((SAPbouiCOM.ComboBox)(this.GetItem("CBHBBRNC").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.LayoutKeyBefore += new LayoutKeyBeforeHandler(this.Form_LayoutKeyBefore);

        }

        //private SAPbouiCOM.Matrix Matrix0;

        private void OnCustomInitialize()
        {

        }
        private void ETBNKCHG_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            double value = double.TryParse(((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value.Trim(),out double temp) ? temp : 0;
            double bCharges = double.TryParse(((SAPbouiCOM.EditText)oForm.Items.Item("ETBNKCHG").Specific).Value.Trim(),out double temp2) ? temp2 : 0;
            if (value > 0 && bCharges > 0)
            {
                double result= value - ((value * bCharges) / 100);
                SAPbouiCOM.EditText ETVALUE = (SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific;
                ETVALUE.Value =result.ToString();
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

                    SAPbouiCOM.ComboBox CBBPBCN1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBHBBRNC").Specific;
                    string selectedValue = CBBPBCN1.Value;

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
        private void ETNEGBNK_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBHBBRNC").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBHBBRNC").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
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
                SAPbouiCOM.EditText etNegBNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETBNKNAM").Specific;
                etNegBNm.Value = bankCode;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
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

        private void ETBPBNK2_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                // Cast to the ChooseFromList event interface
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID; // e.g. "CFL_OSCM"

                if (cflUID == "CFL_ODSC2")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.ComboBox CBBPBCN2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN2").Specific;
                    string selectedValue = CBBPBCN2.Value;

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

        private void ETBPBNK2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN2").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBBPBCN2").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }

        }

       

        private void ETBPBNK1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ComboBox CBISSBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN1").Specific;
            string selectedValue = CBISSBNK.Value;
            if (string.IsNullOrEmpty(selectedValue))
            {
                // Focus back to the combo box
                oForm.Items.Item("CBBPBCN1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }

        }

        private void ETBPBNK1_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

                    SAPbouiCOM.ComboBox CBBPBCN1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBPBCN1").Specific;
                    string selectedValue = CBBPBCN1.Value;

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

        private void ETBPBNK1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
                SAPbouiCOM.EditText etIssBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNK1").Specific;
                etIssBnk.Value = bankCode;
                SAPbouiCOM.EditText etIBnkNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNM1").Specific;
                etIBnkNm.Value = bankName;
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
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

        private void ETSUPCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
                SAPbouiCOM.EditText etCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETSUPCOD").Specific;
                SAPbouiCOM.EditText etName = (SAPbouiCOM.EditText)oForm.Items.Item("ETSUPNAM").Specific;
                etCode.Value = cardCode;
                etName.Value = cardName;
            }
            catch (Exception e)
            {
                //Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }

        private void BRWSBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oFrom = Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC");
            SAPbouiCOM.DBDataSource DBDataSourceLine = oFrom.DataSources.DBDataSources.Item("@FIL_DR_LCB4");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oFrom.Items.Item("MTXATTAC").Specific;

            // Call file dialog helper
            string filePath = FileDialogHelper.ShowFileDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                int lastRow = MTXATTAC.VisualRowCount;

                // Check if matrix has no rows or the last row's COLATTAC is filled
                bool needNewRow = (lastRow == 0) ||
                                  !string.IsNullOrEmpty(((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value);

                if (needNewRow)
                {
                    // Add new line only if needed
                    Global.GFunc.SetNewLine(MTXATTAC, DBDataSourceLine, 1, "");
                    lastRow = MTXATTAC.VisualRowCount; // Update to new last row
                }

                // Set the file path in the appropriate row
                ((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value = filePath;
                MTXATTAC.FlushToDataSource();
            }
        }



        private void DISPBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;

            for (int i = 1; i <= MTXATTAC.RowCount; i++)
            {
                if (MTXATTAC.IsRowSelected(i))
                {
                    string filePath = ((SAPbouiCOM.EditText)MTXATTAC.Columns.Item("CLATTACH").Cells.Item(i).Specific).Value;

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
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC");
            SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB4");

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

        private void CBTYTRNS_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBTYTRNS").Specific;

                string selectedValue = oCombo.Value;  // you can also use oCombo.Selected.Value

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    //Master LC MAtrix Load
                    SAPbouiCOM.DBDataSource DBDataSourceLine1 = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB1");
                    SAPbouiCOM.Matrix MTXMLCDS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMLCDS").Specific;
                    if (MTXMLCDS.VisualRowCount == 0 )
                    {
                        Global.GFunc.SetNewLine(MTXMLCDS, DBDataSourceLine1, 1, "");// added the line for matrix 1
                    }
                    //PI Details MAtrix Load
                    SAPbouiCOM.Matrix MTXPIDAT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPIDAT").Specific;
                    SAPbouiCOM.DBDataSource DBDataSourceLine2 = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB2");
                    if (MTXPIDAT.VisualRowCount == 0)
                    {
                        Global.GFunc.SetNewLine(MTXPIDAT, DBDataSourceLine2, 1, "");// added the line for matrix 1
                    }
                    //Additional Details MAtrix Load
                    SAPbouiCOM.DBDataSource DBDataSourceLine3 = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB3");
                    SAPbouiCOM.Matrix MTXADTLS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXADTLS").Specific;
                    if (MTXADTLS.VisualRowCount == 0)
                    {
                        Global.GFunc.SetNewLine(MTXADTLS, DBDataSourceLine3, 1, "");// added the line for matrix 1
                    }
                }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }
        private void MTXADTLS_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXADTLS").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB3");

                // get the selected row from OCRD
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string cardCode = oDataTable.GetValue("CardCode", 0).ToString();
                    string cardName = oDataTable.GetValue("CardName", 0).ToString();

                    int row = pVal.Row; // matrix row where CFL triggered

                    // set values
                    oMatrix.SetCellWithoutValidation(row, "CLVENCOD", cardCode);
                    oMatrix.SetCellWithoutValidation(row, "CLVENNAM", cardName);

                    oMatrix.FlushToDataSource();

                    // Add new row if last row has data
                    int lastRow = oMatrix.RowCount;
                    bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVENCOD").Cells.Item(lastRow).Specific).Value);

                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("CFL Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void MTXMLCDS_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMLCDS").Specific;

                // get the selected row from OCRD
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string lcNo = oDataTable.GetValue("U_LCNo", 0).ToString();
                    string scNo = oDataTable.GetValue("U_SCNo", 0).ToString();
                    string lcDesc = oDataTable.GetValue("U_Desc", 0).ToString();
                    string appPerc = oDataTable.GetValue("U_BToBLCPer", 0).ToString();
                    string appValue = oDataTable.GetValue("U_RemAmt", 0).ToString();

                    string issueDate = oDataTable.GetValue("U_IssueDate", 0).ToString();
                    string shipDate = oDataTable.GetValue("U_ShipDate", 0).ToString();
                    string expDate = oDataTable.GetValue("U_ExpDate", 0).ToString();

                    string issuBank = oDataTable.GetValue("U_IssueBank", 0).ToString();
                    string negoBank = oDataTable.GetValue("U_NegBank", 0).ToString();
                    
                    string mlcValue = "";
                    if (!string.IsNullOrEmpty(scNo))
                    {
                        mlcValue = oDataTable.GetValue("U_SCValue", 0).ToString();
                    }
                    else
                    {
                        mlcValue = oDataTable.GetValue("U_TotalValue", 0).ToString();
                    }

                    // Safely get and format the date values
                    DateTime issueDt = Convert.ToDateTime(issueDate);
                    DateTime shipDt = Convert.ToDateTime(shipDate);
                    DateTime expDt = Convert.ToDateTime(expDate);


                    // query here
                    string query = $@"SELECT IFNULL(SUM(""U_CONAMT""),0) AS ""TotalAmt"" FROM ""@FIL_DR_LCB1"" 
                    WHERE ""U_LCCODE"" = '{lcNo}'";

                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rs.DoQuery(query);

                    string sumStr = rs.Fields.Item("TotalAmt").Value.ToString();





                    int row = pVal.Row; // matrix row where CFL triggered

                    // set values
                    oMatrix.SetCellWithoutValidation(row, "CLLCCODE", lcNo);
                    oMatrix.SetCellWithoutValidation(row, "CLSCCODE", scNo);
                    oMatrix.SetCellWithoutValidation(row, "CLLCDESC", lcDesc);
                    oMatrix.SetCellWithoutValidation(row, "CLAPLPER", appPerc);
                    oMatrix.SetCellWithoutValidation(row, "CLAPLVAL", appValue);
                    oMatrix.SetCellWithoutValidation(row, "CLISDATE", issueDt.ToString("yyyyMMdd"));
                    oMatrix.SetCellWithoutValidation(row, "CLSHDATE", shipDt.ToString("yyyyMMdd"));
                    oMatrix.SetCellWithoutValidation(row, "CLEXDATE", expDt.ToString("yyyyMMdd"));
                    oMatrix.SetCellWithoutValidation(row, "CLISUBNK", issuBank);
                    oMatrix.SetCellWithoutValidation(row, "CLNEGBNK", negoBank);
                    oMatrix.SetCellWithoutValidation(row, "CLMLCVLU", mlcValue);

                    double sumValue = 0.0, remAmt = 0.0, limitVal = 0.0;
                    if (!string.IsNullOrEmpty(sumStr) && sumStr != "0")
                    {
                        double.TryParse(sumStr, out sumValue);
                        double.TryParse(appValue,out limitVal);
                        remAmt  = limitVal - sumValue;

                        oMatrix.SetCellWithoutValidation(row, "CLPCONVL", sumValue.ToString());
                        oMatrix.SetCellWithoutValidation(row, "CLREMAMT", remAmt.ToString());

                    }
                    else
                    {
                        oMatrix.SetCellWithoutValidation(row, "CLPCONVL", sumStr);
                        oMatrix.SetCellWithoutValidation(row, "CLREMAMT", appValue);
                    }



                    oMatrix.FlushToDataSource();
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("MLC Matrix CFL Error: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short,
                   SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void MTXPIDAT_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXPIDAT").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB2");
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string docEntry = oDataTable.GetValue("DocEntry", 0).ToString();
                    string docNum = oDataTable.GetValue("DocNum", 0).ToString();
                    string postDate = oDataTable.GetValue("DocDueDate", 0).ToString();
                    string docDate = oDataTable.GetValue("DocDate", 0).ToString();
                    string reference = oDataTable.GetValue("Comments", 0).ToString();
                    string value = oDataTable.GetValue("DocTotal", 0).ToString();
                    DateTime postDt = Convert.ToDateTime(postDate);
                    DateTime docDt = Convert.ToDateTime(docDate);

                    SAPbouiCOM.EditText oETAMDNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific;
                    string amdNo = oETAMDNO.Value;
                    int row = pVal.Row; // matrix row where CFL triggered

                    // set values
                    oMatrix.SetCellWithoutValidation(row, "CLDCNTRY", docEntry);
                    oMatrix.SetCellWithoutValidation(row, "CLDOCNUM", docNum);
                    oMatrix.SetCellWithoutValidation(row, "CLPSDATE", postDt.ToString("yyyyMMdd"));
                    oMatrix.SetCellWithoutValidation(row, "CLDCDATE", docDt.ToString("yyyyMMdd"));
                    oMatrix.SetCellWithoutValidation(row, "CLREFNO", reference);
                    oMatrix.SetCellWithoutValidation(row, "CLVALUE", value);
                    oMatrix.SetCellWithoutValidation(row, "CLAMDNO", amdNo);

                    oMatrix.FlushToDataSource();

                    //Sum of the value 
                    double totalValue = 0;
                    for (int i = 1; i <= oMatrix.RowCount; i++)
                    {
                        string val = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(i).Specific).Value;
                        if (double.TryParse(val, out double amt))
                        {
                            totalValue += amt;
                        }
                    }
                    
                    //Bank Charge Field enable
                    if (totalValue > 0)
                    {
                        SAPbouiCOM.Item ETBNKCHG = oForm.Items.Item("ETBNKCHG");
                        ETBNKCHG.Enabled = true;
                    }

                    // Retrieve data from another matrix (MTXMLCDS)
                    SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMLCDS").Specific;
                    string remAmtVal = ((SAPbouiCOM.EditText)oMatrix2.Columns.Item("CLREMAMT").Cells.Item(1).Specific).Value;

                    double remAmt = 0;
                    if (double.TryParse(remAmtVal, out double parsedRemAmt))
                    {
                        remAmt = parsedRemAmt;
                    }

                    //if (remAmt < totalValue)
                    //{
                    //    Application.SBO_Application.StatusBar.SetText("Total value cannot exceed remaining amount!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                    //    // Optionally clear the row values
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLDCNTRY", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLDOCNUM", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLPSDATE", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLDCDATE", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLREFNO", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", "");
                    //    oMatrix.SetCellWithoutValidation(pVal.Row, "CLAMDNO", "");
                    //    oMatrix.FlushToDataSource();

                    //    return;
                    //}

                    // Show updated total and remaining amount
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value = totalValue.ToString("0.00");

                    // Add new row if last row has data
                    int lastRow = oMatrix.RowCount;
                    bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLDCNTRY").Cells.Item(lastRow).Specific).Value);

                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                        if(oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        {
                            oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("PI Matrix CFL Error: " + ex.Message,
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

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string companyCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_BranchCode", 0);
            string transcationType = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_TrnsType", 0);
            string b2blcNo = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_LCNo", 0);
            string issuingBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_IssueBank", 0);
            string negBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_SUPPBANK", 0);
            string value = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_Amt", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_Curr", 0);
            string country = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_VENDCNTR", 0);
            string issueDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_IssueDate", 0);
            string shipmentDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_ShipDate", 0);
            string expiryDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_ExpDate", 0);
            string lcMode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("U_BLCSTTS", 0);
            string dnum = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCB").GetValue("DocNum", 0);

            if (companyCode == "")
            {
                Global.GFunc.ShowError("Select Company Code");
                oForm.ActiveItem = "CBCOMPNY";
                return BubbleEvent = false;
            }
            else if (transcationType == "")
            {
                Global.GFunc.ShowError("Select Transaction Type");
                oForm.ActiveItem = "CBTYTRNS";
                return BubbleEvent = false;
            }
            else if (b2blcNo == "")
            {
                Global.GFunc.ShowError("Enter LC Number");
                oForm.ActiveItem = "ETB2LCNO";
                return BubbleEvent = false;
            }
            else if (lcMode == "")
            {
                Global.GFunc.ShowError("Select Commercial Mode");
                oForm.ActiveItem = "CBMMODE";
                return BubbleEvent = false;
            }
            else if (issuingBank == "")
            {
                Global.GFunc.ShowError("Select the Issuing Bank");
                oForm.ActiveItem = "ETBPBNK1";
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
            else if (country == "")
            {
                Global.GFunc.ShowError("Select the Country");
                oForm.ActiveItem = "CBCONTRY";
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
                oForm.ActiveItem = "ETSHPDAT";
                return BubbleEvent = false;
            }
            else if (expiryDate == "")
            {
                Global.GFunc.ShowError("Select the Expiry Date");
                oForm.ActiveItem = "ETEXPDAT";
                return BubbleEvent = false;
            }
            // Preventing Empty Row to Add in the DB for MTXPIDAT
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB2");
            int rowCount = MTXPIDAT.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_BASDOENTRY", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXPIDAT.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXADTLS
            SAPbouiCOM.DBDataSource oDBDetail2 = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCB3");
            int rowCount2 = MTXADTLS.VisualRowCount;
            if (rowCount2 > 0)
            {
                string lastdocentry = oDBDetail2.GetValue("U_TYPE", rowCount2 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXADTLS.DeleteRow(rowCount2);
                    oDBDetail2.RemoveRecord(rowCount2 - 1);
                    rowCount2--;  // Adjust row count after deletion
                }
            }

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                string mode = "";
                string amdNo = "";
                // Create Recordset object
                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                // Assuming dnum is already declared and holds your DocNum (as int or string)
                string sqlQuery = $"SELECT \"U_BTBAMNO\",\"U_AMDSTTS\" FROM \"@FIL_DH_OLCB\" WHERE \"DocNum\" = {dnum}";
                oRec.DoQuery(sqlQuery);
                if (!oRec.EoF)
                {
                    mode = oRec.Fields.Item("U_AMDSTTS").Value.ToString();
                    amdNo = oRec.Fields.Item("U_BTBAMNO").Value.ToString();
                }
                int val = int.TryParse(amdNo, out var result) ? result : 0;
                if (mode == "C" || val != 0)
                {
                    Application.SBO_Application.MessageBox("Access Denied !!!!Go to Amendment Form ");
                    BubbleEvent = false;
                    return BubbleEvent;
                }
                else
                {
                    // Current Previous Consume Value 
                    string etValue = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value;
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMLCDS").Specific;
                    oMatrix.SetCellWithoutValidation(1, "CLPCONVL", etValue);
                    oMatrix.FlushToDataSource();
                }
            }

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                //Document number
                int num = Global.GFunc.GetCodeGeneration("@FIL_DH_OLCB");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = num.ToString();

                // Current Previous Consume Value 
                string etValue = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVALUE").Specific).Value;
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMLCDS").Specific;
                oMatrix.SetCellWithoutValidation(1, "CLPCONVL", etValue);
                oMatrix.FlushToDataSource();
            }
            return BubbleEvent;
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oform.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                InitializeB2BLCForm(oform);
            }

        }

        private void CBPMTRMS_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            // Get selected value from CBPTRMS1
            SAPbouiCOM.ComboBox cb1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPMTRMS").Specific;
            string selectedValue = cb1.Selected == null ? "" : cb1.Selected.Value;

            // If selected value is "A", then set CBPTRMS2 to "A"
            if (selectedValue == "A")
            {
                SAPbouiCOM.ComboBox cb2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDAY").Specific;
                cb2.Select("H", SAPbouiCOM.BoSearchKey.psk_ByValue);
            }
            if (selectedValue == "V")
            {
                SAPbouiCOM.ComboBox cb2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBDAY").Specific;
                cb2.Select("O", SAPbouiCOM.BoSearchKey.psk_ByValue);
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

        private void CBMMODE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_B2BLC");

            // Merchandise Combo
            SAPbouiCOM.ComboBox oComboMerchant = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
            string selectedValue = oComboMerchant.Value;

            if (selectedValue == "C")
            {
                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMMODE");
                oItem.Enabled = true;
            }
            else
            {
                SAPbouiCOM.Item oItem = oForm.Items.Item("CBCMMODE");
                oItem.Enabled = false;

                SAPbouiCOM.ComboBox oComboCommercial = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMMODE").Specific;
                oComboCommercial.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

            }

        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form ofrom = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(eventInfo.FormUID);

            if (eventInfo.ItemUID == "MTXMLCDS" || eventInfo.ItemUID == "MTXPIDAT")
            {
                ofrom.EnableMenu("1293", true);
            }
            else
            {
                ofrom.EnableMenu("1293", false);
            }

        }

        private void ETB2LCNO_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // Get the entered LC No
                string lcNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2LCNO").Specific).Value.Trim();

                if (!string.IsNullOrEmpty(lcNo))
                {
                    // Create recordset
                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    // Just check for existence
                    string query = $@"SELECT 1 FROM ""@FIL_DH_OLCB"" WHERE ""U_LCNo"" = '{lcNo.Replace("'", "''")}'";

                    oRS.DoQuery(query);

                    if (!oRS.EoF)
                    {
                        Application.SBO_Application.StatusBar.SetText("B2BLC No already exists!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2LCNO").Specific).Value = "";

                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

       
    }
}
