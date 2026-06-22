using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SalesContract", "Resources/SalesContract.b1f")]
    class SalesContract : UserFormBase
    {
        public SalesContract()
        {
        }

        private SAPbouiCOM.StaticText STCOMPNY, STCUSCOD, STBRNDCD, STSCNO, STSCDESC, STREFRNC, STVAL, STSCVAL, STDOCNUM, STBPBNK1,
                            STDOCDAT, STBPBNK2, STHSBNK, STCURR, STISUDAT, STSTATUS, STEXPDAT, STSHPDAT, STMMODE, STCMODE, STB2B, STAMDNO, STAMMODE, STACMODE, STINTRMS, STRMSPAY, STDAYS, STMODSHP, STPTLDNG,
                            STCNDEST, STPDCHRG, STPTSHIP, STSHPTOL, STHSCODE, STDOCREQ, STRMSCON, STINRNCE, STNOTPTY, STREMARK;



        private SAPbouiCOM.EditText ETCUSCOD, ETCUSNAM, ETBRNDNM, ETBRNDCD, ETSCNO, ETSCVAL, ETDOCNUM, ETDOCDAT, ETBPBNK1, ETBPBNK2,
                    ETSTATUS, ETDOCTRY, ETHSBNK, ETFULL, ETSCDESC, ETREFRNC, ETCURR, ETISUDAT, ETSHPDAT, ETBBKNM1, ETBBKNM2, ETHBNKNM,
                    ETEXPDAT, ETVAL, ETAMDNO, ETPTLDNG, ETPDCHRG, ETINRNCE, ETCNDEST, ETDAYS, ETPTSHIP, ETSHPTOL,
                    ETHSCODE, ETRMSCON, ETDOCREQ, ETNOTPTY, ETREMARK;



        private SAPbouiCOM.ComboBox CBCNTRY1, CBCNTRY2, CBBRNCH, CBCOMPNY, CBMMODE, CBCMODE, CBAMMODE, CBACMODE, CBINTRMS, CBRMSPAY, CBMODSHP;

        private SAPbouiCOM.Folder FOLSTYLE, FOLAMEND, FOLATTAC, FOLOTHDL, FOLDRFT;

        private SAPbouiCOM.LinkedButton LKBTN3;

        private SAPbouiCOM.Matrix MTXSTLYD, MTXATTAC, MTXDRAFT;

        private SAPbouiCOM.Grid GRDAMDMT;

        private SAPbouiCOM.Button ADDButton, CancelButton, BRWSBTN, DISPBTN, DELBTN;

        private static bool commercialFlag = false;
        private static bool ZeroFlag = true;


        public override void OnInitializeComponent()
        {
            this.STCOMPNY = ((SAPbouiCOM.StaticText)(this.GetItem("STCOMPNY").Specific));
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STSCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STSCNO").Specific));
            this.STSCDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STSCDESC").Specific));
            this.STREFRNC = ((SAPbouiCOM.StaticText)(this.GetItem("STREFRNC").Specific));
            this.STVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STVAL").Specific));
            this.STSCVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STSCVAL").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STBPBNK1 = ((SAPbouiCOM.StaticText)(this.GetItem("STBPBNK1").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETSCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNO").Specific));
            this.ETSCVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETSCVAL").Specific));
            this.ETSCVAL.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETSCVAL_LostFocusAfter);
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETBPBNK1 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNK1").Specific));
            this.ETBPBNK1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBPBNK1_ChooseFromListAfter);
            this.ETBPBNK2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBPBNK2").Specific));
            this.ETBPBNK2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBPBNK2_ChooseFromListAfter);
            this.ETSTATUS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATUS").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETHSBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETHSBNK").Specific));
            this.ETHSBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETHSBNK_ChooseFromListAfter);
            this.CBCNTRY1 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCNTRY1").Specific));
            this.CBCNTRY2 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCNTRY2").Specific));
            this.CBBRNCH = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBRNCH").Specific));
            this.CBCOMPNY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCOMPNY").Specific));
            this.CBMMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBMMODE").Specific));
            this.CBMMODE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBMMODE_ComboSelectAfter);
            this.CBCMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCMODE").Specific));
            this.CBCMODE.LostFocusAfter += new SAPbouiCOM._IComboBoxEvents_LostFocusAfterEventHandler(this.CBCMODE_LostFocusAfter);
            this.CBCMODE.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBCMODE_ComboSelectAfter);
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STBPBNK2 = ((SAPbouiCOM.StaticText)(this.GetItem("STBPBNK2").Specific));
            this.STHSBNK = ((SAPbouiCOM.StaticText)(this.GetItem("STHSBNK").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STISUDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STISUDAT").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.ETFULL = ((SAPbouiCOM.EditText)(this.GetItem("ETFULL").Specific));
            this.ETSCDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETSCDESC").Specific));
            this.ETREFRNC = ((SAPbouiCOM.EditText)(this.GetItem("ETREFRNC").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETISUDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.ETSHPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPDAT").Specific));
            this.ETBBKNM1 = ((SAPbouiCOM.EditText)(this.GetItem("ETBBKNM1").Specific));
            this.ETBBKNM2 = ((SAPbouiCOM.EditText)(this.GetItem("ETBBKNM2").Specific));
            this.ETHBNKNM = ((SAPbouiCOM.EditText)(this.GetItem("ETHBNKNM").Specific));
            this.ETEXPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPDAT").Specific));
            this.STEXPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STEXPDAT").Specific));
            this.STSHPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPDAT").Specific));
            this.STMMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STMMODE").Specific));
            this.STCMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCMODE").Specific));
            this.ETVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETVAL").Specific));
            this.FOLSTYLE = ((SAPbouiCOM.Folder)(this.GetItem("FOLSTYLE").Specific));
            this.FOLAMEND = ((SAPbouiCOM.Folder)(this.GetItem("FOLAMEND").Specific));
            this.FOLATTAC = ((SAPbouiCOM.Folder)(this.GetItem("FOLATTAC").Specific));
            this.FOLOTHDL = ((SAPbouiCOM.Folder)(this.GetItem("FOLOTHDL").Specific));
            this.STB2B = ((SAPbouiCOM.StaticText)(this.GetItem("STB2B").Specific));
            this.LKBTN3 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKBTN3").Specific));
            this.STAMDNO = ((SAPbouiCOM.StaticText)(this.GetItem("STAMDNO").Specific));
            this.ETAMDNO = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDNO").Specific));
            this.STAMMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STAMMODE").Specific));
            this.CBAMMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBAMMODE").Specific));
            this.STACMODE = ((SAPbouiCOM.StaticText)(this.GetItem("STACMODE").Specific));
            this.CBACMODE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBACMODE").Specific));
            this.MTXSTLYD = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSTLYD").Specific));
            this.MTXSTLYD.ValidateBefore += new SAPbouiCOM._IMatrixEvents_ValidateBeforeEventHandler(this.MTXSTLYD_ValidateBefore);
            this.MTXSTLYD.ValidateAfter += new SAPbouiCOM._IMatrixEvents_ValidateAfterEventHandler(this.MTXSTLYD_ValidateAfter);
            this.MTXSTLYD.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.MTXSTLYD_LinkPressedBefore);
            this.MTXSTLYD.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXSTLYD_ChooseFromListBefore);
            this.MTXSTLYD.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXSTLYD_ChooseFromListAfter);
            this.STINTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STINTRMS").Specific));
            this.STRMSPAY = ((SAPbouiCOM.StaticText)(this.GetItem("STRMSPAY").Specific));
            this.STDAYS = ((SAPbouiCOM.StaticText)(this.GetItem("STDAYS").Specific));
            this.STMODSHP = ((SAPbouiCOM.StaticText)(this.GetItem("STMODSHP").Specific));
            this.STPTLDNG = ((SAPbouiCOM.StaticText)(this.GetItem("STPTLDNG").Specific));
            this.STCNDEST = ((SAPbouiCOM.StaticText)(this.GetItem("STCNDEST").Specific));
            this.STPDCHRG = ((SAPbouiCOM.StaticText)(this.GetItem("STPDCHRG").Specific));
            this.STPTSHIP = ((SAPbouiCOM.StaticText)(this.GetItem("STPTSHIP").Specific));
            this.STSHPTOL = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPTOL").Specific));
            this.STHSCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STHSCODE").Specific));
            this.STDOCREQ = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCREQ").Specific));
            this.STRMSCON = ((SAPbouiCOM.StaticText)(this.GetItem("STRMSCON").Specific));
            this.STINRNCE = ((SAPbouiCOM.StaticText)(this.GetItem("STINRNCE").Specific));
            this.CBINTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINTRMS").Specific));
            this.CBRMSPAY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBRMSPAY").Specific));
            this.CBMODSHP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBMODSHP").Specific));
            this.ETPTLDNG = ((SAPbouiCOM.EditText)(this.GetItem("ETPTLDNG").Specific));
            this.ETPDCHRG = ((SAPbouiCOM.EditText)(this.GetItem("ETPDCHRG").Specific));
            this.ETINRNCE = ((SAPbouiCOM.EditText)(this.GetItem("ETINRNCE").Specific));
            this.ETCNDEST = ((SAPbouiCOM.EditText)(this.GetItem("ETCNDEST").Specific));
            this.ETDAYS = ((SAPbouiCOM.EditText)(this.GetItem("ETDAYS").Specific));
            this.ETPTSHIP = ((SAPbouiCOM.EditText)(this.GetItem("ETPTSHIP").Specific));
            this.ETSHPTOL = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPTOL").Specific));
            this.ETHSCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETHSCODE").Specific));
            this.ETRMSCON = ((SAPbouiCOM.EditText)(this.GetItem("ETRMSCON").Specific));
            this.ETDOCREQ = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCREQ").Specific));
            this.ETNOTPTY = ((SAPbouiCOM.EditText)(this.GetItem("ETNOTPTY").Specific));
            this.STNOTPTY = ((SAPbouiCOM.StaticText)(this.GetItem("STNOTPTY").Specific));
            this.STREMARK = ((SAPbouiCOM.StaticText)(this.GetItem("STREMARK").Specific));
            this.ETREMARK = ((SAPbouiCOM.EditText)(this.GetItem("ETREMARK").Specific));
            this.FOLDRFT = ((SAPbouiCOM.Folder)(this.GetItem("FOLDRFT").Specific));
            this.MTXATTAC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTAC").Specific));
            this.GRDAMDMT = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDMT").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.MTXDRAFT = ((SAPbouiCOM.Matrix)(this.GetItem("MTXDRAFT").Specific));
            this.MTXDRAFT.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.MTXDRAFT_ClickAfter);
            this.MTXDRAFT.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.MTXDRAFT_LinkPressedBefore);
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.BRWSBTN_ClickAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DISPBTN_ClickAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DELBTN_ClickAfter);
            this.OnCustomInitialize();

        }


        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);


        }



        private void OnCustomInitialize()
        {

        }
        private string _deletedStyleCode = "";

        private void MTXSTLYD_ValidateBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.ColUID != "CLSTYLCD") return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource dsStyle = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM1");

                int row = pVal.Row;
                if (row <= 0) return;

                // datasource index is row - 1
                _deletedStyleCode = (dsStyle.GetValue("U_STYLENO", row - 1) ?? "")
                                        .Replace("\0", "")
                                        .Trim();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "ValidateBefore Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void MTXSTLYD_ValidateAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLSTYLCD") return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMtxStyle = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                SAPbouiCOM.Matrix oMtxDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

                int row = pVal.Row;
                if (row <= 0) return;

                oForm.Freeze(true);
                try
                {
                    string currentCode = ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLSTYLCD").Cells.Item(row).Specific).Value
                                            .Replace("\0", "").Trim();

                    if (string.IsNullOrEmpty(currentCode))
                    {
                        ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLSTYLNM").Cells.Item(row).Specific).Value = "";
                        ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLBYCODE").Cells.Item(row).Specific).Value = "";
                        ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLBYNAME").Cells.Item(row).Specific).Value = "";
                        ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLQUAN").Cells.Item(row).Specific).Value = "";
                        ((SAPbouiCOM.EditText)oMtxStyle.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value = "";

                        RemoveStyleAndDraftRows(
                            oForm,
                            oMtxStyle,
                            oMtxDraft,
                            "@FIL_DR_SCM1",
                            "@FIL_DR_SCM2",   // change if needed
                            "U_STYLENO",
                            "U_STYLENO",      // change if draft table field is different
                            _deletedStyleCode
                        );

                        EnsureLine(oForm, "MTXSTLYD", "@FIL_DR_SCM1");
                        AddLineIfLastRowHasValue(oForm, "MTXSTLYD", "@FIL_DR_SCM1", "U_STYLENO");
                    }

                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
                finally
                {
                    oForm.Freeze(false);
                    _deletedStyleCode = "";
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Validation Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void RemoveStyleAndDraftRows(
      SAPbouiCOM.Form oForm,
      SAPbouiCOM.Matrix styleMatrix,
      SAPbouiCOM.Matrix draftMatrix,
      string styleDsUid,
      string draftDsUid,
      string styleFieldInStyleDs,
      string styleFieldInDraftDs,
      string deletedStyleCode)
        {
            styleMatrix.FlushToDataSource();
            draftMatrix.FlushToDataSource();

            SAPbouiCOM.DBDataSource dsStyle = oForm.DataSources.DBDataSources.Item(styleDsUid);
            SAPbouiCOM.DBDataSource dsDraft = oForm.DataSources.DBDataSources.Item(draftDsUid);

            // remove empty style rows
            for (int i = dsStyle.Size - 1; i >= 0; i--)
            {
                string styleCode = (dsStyle.GetValue(styleFieldInStyleDs, i) ?? "").Replace("\0", "").Trim();

                if (string.IsNullOrEmpty(styleCode))
                    dsStyle.RemoveRecord(i);
            }

            // remove all draft rows for deleted style
            if (!string.IsNullOrEmpty(deletedStyleCode))
            {
                for (int i = dsDraft.Size - 1; i >= 0; i--)
                {
                    string draftStyleCode = (dsDraft.GetValue(styleFieldInDraftDs, i) ?? "").Replace("\0", "").Trim();

                    if (draftStyleCode == deletedStyleCode)
                        dsDraft.RemoveRecord(i);
                }
            }

            ResequenceLineId(dsStyle);
            ResequenceLineId(dsDraft);

            styleMatrix.LoadFromDataSource();
            draftMatrix.LoadFromDataSource();

            RecalculateStyleTotal(oForm);

        }

        private void RecalculateStyleTotal(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;

            double totalValue = 0;

            for (int i = 1; i <= oMatrix.RowCount; i++)
            {
                string valueText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(i).Specific).Value.Trim();

                if (double.TryParse(valueText, out double val))
                    totalValue += val;
            }

            SAPbouiCOM.EditText oEditTotal = (SAPbouiCOM.EditText)oForm.Items.Item("ETVAL").Specific;
            oEditTotal.Value = totalValue.ToString("N2");
        }
        private void ResequenceLineId(SAPbouiCOM.DBDataSource ds)
        {
            for (int i = 0; i < ds.Size; i++)
            {
                ds.SetValue("LineId", i, (i + 1).ToString());
            }
        }

        private void MTXDRAFT_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLACTIVE" || pVal.Row <= 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                RecalculateDraftTotals(oForm);

                // Optional: check against SC value again
                double totalValue = ToDoubleSafe(((SAPbouiCOM.EditText)oForm.Items.Item("ETVAL").Specific).Value);
                double scValue = ToDoubleSafe(((SAPbouiCOM.EditText)oForm.Items.Item("ETSCVAL").Specific).Value);

                if (totalValue > scValue)
                {
                    Application.SBO_Application.MessageBox("Total value exceeds SC value.");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void RecalculateDraftTotals(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
            SAPbouiCOM.Matrix oMatrixDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

            // 1) Reset all style rows in main matrix first
            for (int i = 1; i <= oMatrix.RowCount; i++)
            {
                string styleCode = GetEditTextValue(oMatrix, "CLSTYLCD", i);
                if (!string.IsNullOrWhiteSpace(styleCode))
                {
                    oMatrix.SetCellWithoutValidation(i, "CLQUAN", "0");
                    oMatrix.SetCellWithoutValidation(i, "CLVALUE", "0");
                }
            }

            // 2) Calculate totals from draft matrix
            double overallActiveValue = 0;

            for (int i = 1; i <= oMatrixDraft.RowCount; i++)
            {
                string draftStyleCode = GetEditTextValue(oMatrixDraft, "CLSTYLCD", i);
                if (string.IsNullOrWhiteSpace(draftStyleCode))
                    continue;

                bool isActive = ((SAPbouiCOM.CheckBox)oMatrixDraft.Columns.Item("CLACTIVE").Cells.Item(i).Specific).Checked;
                if (!isActive)
                    continue;

                double rowQty = ToDoubleSafe(GetEditTextValue(oMatrixDraft, "CLTOLQTY", i));
                double rowValue = ToDoubleSafe(GetEditTextValue(oMatrixDraft, "CLDOCTOL", i));

                overallActiveValue += rowValue;

                // style-wise update into main matrix
                for (int j = 1; j <= oMatrix.RowCount; j++)
                {
                    string mainStyleCode = GetEditTextValue(oMatrix, "CLSTYLCD", j);

                    if (mainStyleCode.Equals(draftStyleCode, StringComparison.OrdinalIgnoreCase))
                    {
                        double oldQty = ToDoubleSafe(GetEditTextValue(oMatrix, "CLQUAN", j));
                        double oldValue = ToDoubleSafe(GetEditTextValue(oMatrix, "CLVALUE", j));

                        oMatrix.SetCellWithoutValidation(j, "CLQUAN", (oldQty + rowQty).ToString("N2"));
                        oMatrix.SetCellWithoutValidation(j, "CLVALUE", (oldValue + rowValue).ToString("N2"));
                        break;
                    }
                }
            }

            oMatrix.FlushToDataSource();
            oMatrix.LoadFromDataSource();

            // 3) Set ETVAL = all active draft value total
            SAPbouiCOM.EditText oEditTotal = (SAPbouiCOM.EditText)oForm.Items.Item("ETVAL").Specific;
            oEditTotal.Value = overallActiveValue.ToString("N2");
        }


        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            //Status 
            SAPbouiCOM.ComboBox comcombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
            string comSelectedValue = comcombo.Selected.Value;
            SAPbouiCOM.ComboBox mercombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMMODE").Specific;
            string merSelectedValue = mercombo.Selected.Value;

            if (merSelectedValue == "D")
            {
                oForm.Items.Item("CBMMODE").Enabled = true;
                oForm.Items.Item("CBCMODE").Enabled = false;
            }
            else
            {
                oForm.Items.Item("CBMMODE").Enabled = false;
                oForm.Items.Item("CBCMODE").Enabled = true;
            }

            if (comSelectedValue == "D")
            {
                if (merSelectedValue == "C")
                {
                    oForm.Items.Item("CBCMODE").Enabled = true;
                }

                EnsureLine(oForm, "MTXSTLYD", "@FIL_DR_SCM1");
                EnsureLine(oForm, "MTXATTAC", "@FIL_DR_SCM3");
                AddLineIfLastRowHasValue(oForm, "MTXSTLYD", "@FIL_DR_SCM1", "U_STYLENO");
                AddLineIfLastRowHasValue(oForm, "MTXATTAC", "@FIL_DR_SCM3", "U_ATCHMENT");

            }
            else
            {
                oForm.Items.Item("CBCMODE").Enabled = false;
            }

            //combo load
            string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
            SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;
            Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

            //Load Bank Country Combobox
            string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
            SAPbouiCOM.ComboBox CBCNTRY1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY1").Specific;
            Global.GFunc.setComboBoxValue(CBCNTRY1, countrySql);

            SAPbouiCOM.ComboBox CBCNTRY2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY2").Specific;
            Global.GFunc.setComboBoxValue(CBCNTRY2, countrySql);

            //load Branch Combobox
            string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
            SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBRNCH").Specific;
            Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);

            string scNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific).Value.Trim();

            if (!string.IsNullOrEmpty(scNo))
            {
                LoadAmendmentHistory(oForm, scNo);
            }

            SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCMODE").Specific;
            string commerical = oCombo.Value;

            //Draft SO not update if Confirmerd
            if (commerical != "C")
            {
                LoadDraftDataIfNewExists(oForm);
            }
        }

        private void LoadAmendmentHistory(SAPbouiCOM.Form ofrm, string scNo)
        {
            try
            {
                string sqlQuery = $@"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY ""U_SCAMDNO"" DESC) AS ""#"",
                ""U_SCAMDNO"",
                ""CreateDate"",
                ""U_CardCode"" AS ""CardCode"",
                ""U_BRANDCD"" AS ""Brand"",
                ""U_SCNo"" AS ""SCNo"",
                ""U_SCVALUE"" AS ""SC Value"",
                ""U_Desc"" AS ""Desc"",
                ""U_DocDate"" AS ""DocDate"",
                ""U_IssueDate"" AS ""IssueDate"",
                ""U_ShipDate"" AS ""ShipDate"",
                ""U_ExpDate"" AS ""ExpDate"",
                ""U_Amt"" AS ""Amount"",
                ""U_Curr"" AS ""Currency"",
                ""U_IssueBank"" AS ""IssuBank"",
                ""U_NegBank"" AS ""NegoBank""
            FROM ""@FIL_DH_OSCM""
            WHERE ""U_SCNo"" = '{scNo}'
            ORDER BY ""U_SCAMDNO"" DESC";

                // Execute Query
                SAPbouiCOM.DataTable dt = ofrm.DataSources.DataTables.Item("DTSCAMND");
                dt.ExecuteQuery(sqlQuery);

                // Bind Grid
                SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)ofrm.Items.Item("GRDAMDMT").Specific;
                grid.DataTable = dt;

                Application.SBO_Application.StatusBar.SetText(
                    "Amendment History Loaded.",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void LoadDraftDataIfNewExists(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                SAPbouiCOM.Matrix oMatrixDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;
                SAPbouiCOM.DBDataSource dbDraft = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM2");
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                // ------------------------------------------------
                // 1) Collect style codes from MTXSTLYD
                // ------------------------------------------------
                List<string> styleCodes = new List<string>();

                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    string styleCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD").Cells.Item(i).Specific).Value.Trim();

                    if (!string.IsNullOrWhiteSpace(styleCode))
                    {
                        styleCode = styleCode.Replace("'", "''");

                        if (!styleCodes.Contains(styleCode))
                            styleCodes.Add(styleCode);
                    }
                }

                // No style code found
                if (styleCodes.Count == 0)
                    return;

                // ------------------------------------------------
                // 2) Query draft rows
                // ------------------------------------------------
                string inClause = string.Join(",", styleCodes.Select(x => $"'{x}'"));

                string query2 = $@"
            SELECT
                M.""Code""        AS ""StyleCode"",
                M.""Name""        AS ""StyleName"",
                M.""U_BUYRCODE""  AS ""BuyerCode"",
                M.""U_BURSNAME""  AS ""BuyerName"",
                Q.""DocEntry"",
                Q.""DocNum"",
                Q.""DocDate"",
                Q.""DocStatus"",
                Q.""CardCode"",
                Q.""CardName"",
                SUM(L.""Quantity"")  AS ""TotalQuantity"",
                SUM(L.""LineTotal"") AS ""TotalValue""
            FROM ""OQUT"" Q
            INNER JOIN ""QUT1"" L ON Q.""DocEntry"" = L.""DocEntry""
            INNER JOIN ""@FIL_MH_OPSM"" M ON L.""U_StyleCode"" = M.""Code""
            WHERE M.""Code"" IN ({inClause})
            GROUP BY
                Q.""DocEntry"", Q.""DocNum"", Q.""DocDate"", Q.""DocStatus"",
                Q.""CardCode"", Q.""CardName"", M.""Code"", M.""Name"",
                M.""U_BUYRCODE"", M.""U_BURSNAME""
            ORDER BY M.""Code"", Q.""DocDate"", Q.""DocNum""";

                oRS2.DoQuery(query2);

                List<DraftRow> draftList = new List<DraftRow>();

                while (!oRS2.EoF)
                {
                    draftList.Add(new DraftRow
                    {
                        StyleCode = oRS2.Fields.Item("StyleCode").Value.ToString().Trim(),
                        StyleName = oRS2.Fields.Item("StyleName").Value.ToString().Trim(),
                        BuyerCode = oRS2.Fields.Item("BuyerCode").Value.ToString().Trim(),
                        BuyerName = oRS2.Fields.Item("BuyerName").Value.ToString().Trim(),
                        DocEntry = oRS2.Fields.Item("DocEntry").Value.ToString().Trim(),
                        DocNum = oRS2.Fields.Item("DocNum").Value.ToString().Trim(),
                        DocDate = Convert.ToDateTime(oRS2.Fields.Item("DocDate").Value).ToString("yyyyMMdd"),
                        DocStatus = oRS2.Fields.Item("DocStatus").Value.ToString().Trim(),
                        CardCode = oRS2.Fields.Item("CardCode").Value.ToString().Trim(),
                        CardName = oRS2.Fields.Item("CardName").Value.ToString().Trim(),
                        TotalQuantity = ToDoubleSafe(oRS2.Fields.Item("TotalQuantity").Value.ToString()),
                        TotalValue = ToDoubleSafe(oRS2.Fields.Item("TotalValue").Value.ToString())
                    });

                    oRS2.MoveNext();
                }

                if (draftList.Count == 0)
                    return;

                // ------------------------------------------------
                // 3) Check if any NEW draft order exists
                // ------------------------------------------------
                bool hasNewDraftOrder = false;

                foreach (DraftRow draft in draftList)
                {
                    bool exists = false;

                    for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                    {
                        string existingCode = GetMatrixValue(oMatrixDraft, "CLSTYLCD", i);
                        string existingDocEntry = GetMatrixValue(oMatrixDraft, "CLDRNTRY", i);

                        if (existingCode.Equals(draft.StyleCode, StringComparison.OrdinalIgnoreCase) &&
                            existingDocEntry.Equals(draft.DocEntry, StringComparison.OrdinalIgnoreCase))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        hasNewDraftOrder = true;
                        break;
                    }
                }

                // If all already exist, do nothing
                if (!hasNewDraftOrder)
                    return;

                // ------------------------------------------------
                // 4) Add ONLY new rows, skip existing rows
                // ------------------------------------------------
                oMatrixDraft.FlushToDataSource();

                foreach (DraftRow draft in draftList)
                {
                    bool foundExisting = false;

                    for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                    {
                        string existingCode = GetMatrixValue(oMatrixDraft, "CLSTYLCD", i);
                        string existingDocEntry = GetMatrixValue(oMatrixDraft, "CLDRNTRY", i);

                        if (existingCode.Equals(draft.StyleCode, StringComparison.OrdinalIgnoreCase) &&
                            existingDocEntry.Equals(draft.DocEntry, StringComparison.OrdinalIgnoreCase))
                        {
                            foundExisting = true;
                            break;
                        }
                    }

                    // already exists -> skip
                    if (foundExisting)
                        continue;

                    int newRow = -1;

                    // find first empty row
                    for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                    {
                        string styleCd = GetMatrixValue(oMatrixDraft, "CLSTYLCD", i);
                        string docEntry = GetMatrixValue(oMatrixDraft, "CLDRNTRY", i);

                        if (string.IsNullOrWhiteSpace(styleCd) && string.IsNullOrWhiteSpace(docEntry))
                        {
                            newRow = i;
                            break;
                        }
                    }

                    // add row if no empty row found
                    if (newRow == -1)
                    {
                        Global.GFunc.SetNewLine(oMatrixDraft, dbDraft, 1, "");
                        newRow = oMatrixDraft.RowCount;
                    }

                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLSTYLCD", draft.StyleCode);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLSTYLNM", draft.StyleName);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLBYRSCD", draft.BuyerCode);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLBYRSNM", draft.BuyerName);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLDRNTRY", draft.DocEntry);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLDRNUM", draft.DocNum);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLDOCDAT", draft.DocDate);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLDCSTAT", draft.DocStatus);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLCRDCOD", draft.CardCode);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLCRDNAM", draft.CardName);
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLTOLQTY", draft.TotalQuantity.ToString());
                    oMatrixDraft.SetCellWithoutValidation(newRow, "CLDOCTOL", draft.TotalValue.ToString());
                }

                oMatrixDraft.FlushToDataSource();
                oMatrixDraft.LoadFromDataSource();
                oMatrixDraft.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

       

        private string GetMatrixValue(SAPbouiCOM.Matrix oMatrix, string colId, int row)
        {
            try
            {
                return ((SAPbouiCOM.EditText)oMatrix.Columns.Item(colId).Cells.Item(row).Specific).Value.Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);

            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
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
                matrix.FlushToDataSource();
                int dbRowCount = db.Size;
                if (dbRowCount == 0)
                {
                    Global.GFunc.SetNewLine(matrix, db, 1, "");
                    return;
                }
                int lastDbRow = dbRowCount - 1;
                string lastValue = db.GetValue(columnName, lastDbRow).Trim();
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
        private void ETSCVAL_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText oEditText = (SAPbouiCOM.EditText)oForm.Items.Item("ETSCVAL").Specific;

            double value = 0;
            if (!double.TryParse(oEditText.Value, out value))
                value = 0;

            if (value == 0)
            {
                oForm.Items.Item("ETBRNDCD").Enabled = false;
            }
            else
            {
                oForm.Items.Item("ETBRNDCD").Enabled = true;
                SAPbouiCOM.EditText oBrandEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific;
                oBrandEdit.ChooseFromListUID = "CFL_OBRM";
                oBrandEdit.ChooseFromListAlias = "Code";
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

                    int confirm = Application.SBO_Application.MessageBox("Are you sure you want to select 'Confirm'?", 1, "Yes", "No");

                    if (confirm == 1) // "Yes" was clicked
                    {

                        commercialFlag = true;

                    }
                }
            }

        }

        private void CBCMODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (commercialFlag == true)
            {
                oForm.Items.Item("CBCMODE").Enabled = false;
            }

        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oform.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                InitializeSalesContractForm(oform);
            }

        }
        private void InitializeSalesContractForm(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                // Status
                string stat = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTATUS").Specific).Value;
                if (stat == "O")
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETFULL").Specific).Value = "Open";
                }

                //Default amendment no
                SAPbouiCOM.EditText ETAMDNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific;
                ETAMDNO.Value = "0";

                // Branch combo
                string sqlQuerybpl = @"SELECT ""BPLId"", ""BPLName"" FROM ""OBPL""";
                SAPbouiCOM.ComboBox CBCOMPNY = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;
                Global.GFunc.setComboBoxValue(CBCOMPNY, sqlQuerybpl);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    string db = "@FIL_DH_OSCM";
                    int num = Global.GFunc.GetCodeGeneration(db) + 1000;
                    String docnum = num.ToString();
                    SAPbouiCOM.EditText ETDOCNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                    ETDOCNO.Value = docnum;

                    SAPbouiCOM.EditText ETDOCDAT = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific;
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    ETDOCDAT.Value = currentDate;
                }

                //Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" ";
                SAPbouiCOM.ComboBox CBCNTRY1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY1").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY1, countrySql);

                SAPbouiCOM.ComboBox CBCNTRY2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY2").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY2, countrySql);

                //load Branch Combobox
                string branchSql = @"SELECT DISTINCT ""Branch"", ""Branch"" FROM ""DSC1""  ";
                SAPbouiCOM.ComboBox CBNEGBNK = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBRNCH").Specific;
                Global.GFunc.setComboBoxValue(CBNEGBNK, branchSql);

                // Payment terms
                string sqlQueryptrms = @"SELECT ""FldValue"", ""Descr"" FROM ""UFD1"" WHERE ""TableID"" = '@FIL_DH_OLCB' AND ""FieldID"" = 24";
                SAPbouiCOM.ComboBox CBPTRMS1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBRMSPAY").Specific;
                Global.GFunc.setComboBoxValue(CBPTRMS1, sqlQueryptrms);

            }
            finally
            {
                oForm.Freeze(false);
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
            string customerCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_CardCode", 0);
            string brandCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_BRANDCD", 0);
            string scNo = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_SCNo", 0);
            string issuingBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_IssueBank", 0);
            string negBank = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_NegBank", 0);
            string scvalue = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_SCVALUE", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_Curr", 0);
            string docDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_DocDate", 0);
            string issueDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_IssueDate", 0);
            string shipmentDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_ShipDate", 0);
            string expiryDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_ExpDate", 0);
            string scMode = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("U_SCSTTS", 0);
            string dnum = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM").GetValue("DocNum", 0);

            if (customerCode == "")
            {
                Global.GFunc.ShowError("Select Customer Code");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;
            }
            else if (brandCode == "")
            {
                Global.GFunc.ShowError("Select Brand Code");
                oForm.ActiveItem = "ETBRNDCD";
                return BubbleEvent = false;
            }
            else if (scNo == "")
            {
                Global.GFunc.ShowError("Enter SC Number");
                oForm.ActiveItem = "ETSCNO";
                return BubbleEvent = false;
            }
            else if (scMode == "")
            {
                Global.GFunc.ShowError("Select LC Mode");
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
                oForm.ActiveItem = "ETHSBNK";
                return BubbleEvent = false;
            }
            else if (scvalue == "")
            {
                Global.GFunc.ShowError("Enter the Value");
                oForm.ActiveItem = "ETSCVAL";
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
                oForm.ActiveItem = "ETSHPDAT";
                return BubbleEvent = false;
            }
            else if (expiryDate == "")
            {
                Global.GFunc.ShowError("Select the Expiry Date");
                oForm.ActiveItem = "ETEXPDAT";
                return BubbleEvent = false;
            }

            // Preventing Empty Row to Add in the DB
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM1");
            int rowCount = MTXSTLYD.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_STYLENO", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXSTLYD.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB
            SAPbouiCOM.DBDataSource oDBDetail2 = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM3");
            int rowCount2 = MTXATTAC.VisualRowCount;
            if (rowCount2 > 0)
            {
                string lastdocentry = oDBDetail2.GetValue("U_ATCHMENT", rowCount2 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXATTAC.DeleteRow(rowCount2);
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
                string sqlQuery = $"SELECT \"U_SCAMDNO\",\"U_CSCSTTS\" FROM \"@FIL_DH_OSCM\" WHERE \"DocNum\" = {dnum}";
                oRec.DoQuery(sqlQuery);
                if (!oRec.EoF)
                {
                    mode = oRec.Fields.Item("U_CSCSTTS").Value.ToString();
                    amdNo = oRec.Fields.Item("U_SCAMDNO").Value.ToString();
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
                string db = "@FIL_DH_OSCM";
                int num = Global.GFunc.GetCodeGeneration(db) + 1000;
                string docnum = num.ToString();
                SAPbouiCOM.EditText ETDOCNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;
                ETDOCNO.Value = docnum;
            }
            return BubbleEvent;
        }

        private void MTXDRAFT_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true; SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

            if (pVal.ColUID == "CLSTYLCD")
            {
                int row = pVal.Row;
                string styleCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD").Cells.Item(row).Specific).Value.Trim();

                StyleMaster styleMaster = new StyleMaster();
                styleMaster.Show();
                //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
                SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
                try
                {
                    cForm.Freeze(true);
                    cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                    cForm.Items.Item("ETSTYLID").Enabled = true;
                    SAPbouiCOM.EditText cETSTYLID = (SAPbouiCOM.EditText)cForm.Items.Item("ETSTYLID").Specific;
                    cETSTYLID.Value = styleCode;
                    cForm.Items.Item("1").Click();
                    cForm.Items.Item("FOLSZTYP").Click();
                    cForm.Freeze(false);
                }
                catch (Exception ex)
                {
                    cForm.Freeze(false);
                }

            }

        }

        private void MTXSTLYD_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
            int row = pVal.Row;
            string styleCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD").Cells.Item(row).Specific).Value.Trim();

            StyleMaster styleMaster = new StyleMaster();
            styleMaster.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETSTYLID").Enabled = true;
                SAPbouiCOM.EditText cETSTYLID = (SAPbouiCOM.EditText)cForm.Items.Item("ETSTYLID").Specific;
                cETSTYLID.Value = styleCode;
                cForm.Items.Item("1").Click();
                cForm.Items.Item("FOLSZTYP").Click();
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }

        }

        private void CBMMODE_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_SALCON");
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

            }

        }
        private void DISPBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;

            for (int i = 1; i <= MTXATTCH.RowCount; i++)
            {
                if (MTXATTCH.IsRowSelected(i))
                {
                    string filePath = ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTAC").Cells.Item(i).Specific).Value;
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
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM3");
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;


            MTXATTCH.FlushToDataSource();
            for (int i = 1; i <= MTXATTCH.RowCount; i++)
            {
                if (MTXATTCH.IsRowSelected(i))
                {
                    int rowIndex = i - 1;

                    if (rowIndex >= 0 && rowIndex < DBDataSourceLine.Size)
                    {
                        DBDataSourceLine.RemoveRecord(rowIndex);
                        for (int j = 0; j < DBDataSourceLine.Size; j++)
                        {
                            DBDataSourceLine.Offset = j;
                            DBDataSourceLine.SetValue("LineId", j, (j + 1).ToString());
                        }
                        MTXATTCH.LoadFromDataSource();
                        Application.SBO_Application.MessageBox("Selected row deleted.");
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        {
                            oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                        }
                    }
                    else
                    {
                        Application.SBO_Application.MessageBox("Select a row .");
                    }

                    break;
                }
            }

        }

        private void BRWSBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM3");
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTAC").Specific;


            string filePath = FileDialogHelper.ShowFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                int lastRow = MTXATTCH.VisualRowCount;
                bool needNewRow = (lastRow == 0) ||
                                  !string.IsNullOrEmpty(((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTAC").Cells.Item(lastRow).Specific).Value);

                if (needNewRow)
                {
                    Global.GFunc.SetNewLine(MTXATTCH, DBDataSourceLine, 1, "");
                    lastRow = MTXATTCH.VisualRowCount;
                }

                ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTAC").Cells.Item(lastRow).Specific).Value = filePath;
                MTXATTCH.FlushToDataSource();

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
            }

        }

        private List<int> _rowsToRemove = new List<int>();
        private string _oldStyleCode = "";

        private void MTXSTLYD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            _rowsToRemove.Clear();
            _oldStyleCode = "";

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
            SAPbouiCOM.Matrix oMatrixDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

            int row = pVal.Row;
            string styleCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD").Cells.Item(row).Specific).Value.Trim();

            // Save for later use
            _oldStyleCode = styleCode;

            if (!string.IsNullOrWhiteSpace(styleCode))
            {
                for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                {
                    string styleCodedraft = ((SAPbouiCOM.EditText)oMatrixDraft.Columns.Item("CLSTYLCD").Cells.Item(i).Specific).Value.Trim();
                    if (styleCodedraft.Equals(styleCode, StringComparison.OrdinalIgnoreCase))
                    {
                        _rowsToRemove.Add(i);
                    }
                }
            }

            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            string cflUID = cflArg.ChooseFromListUID;

            if (cflUID == "CFL_STYL")
            {
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                SAPbouiCOM.EditText ETBRNDCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific;
                string brandValue = ETBRNDCD.Value;
                SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                SAPbouiCOM.Condition oCon1 = oCons.Add();
                oCon1.Alias = "U_Brand";
                oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon1.CondVal = brandValue.Trim();
                oCFL.SetConditions(oCons);
            }
        }


        private void MTXSTLYD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTLYD").Specific;
                SAPbouiCOM.Matrix oMatrixDraft = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDRAFT").Specific;

                SAPbouiCOM.DBDataSource dbMain = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM1");
                SAPbouiCOM.DBDataSource dbDraft = oForm.DataSources.DBDataSources.Item("@FIL_DR_SCM2");

                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                string styleCode = dt.GetValue("Code", 0).ToString().Trim();
                string styleName = dt.GetValue("Name", 0).ToString().Trim();
                string buyerCode = dt.GetValue("U_BUYRCODE", 0).ToString().Trim();
                string buyerName = dt.GetValue("U_BURSNAME", 0).ToString().Trim();

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                // ------------------------------------------------
                // 1) Fill selected row in main matrix
                // ------------------------------------------------
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLCD", styleCode);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLNM", styleName);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLBYCODE", buyerCode);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLBYNAME", buyerName);
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLQUAN", "");
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", "");

                oMatrix.FlushToDataSource();
                oMatrix.LoadFromDataSource();

                // ------------------------------------------------
                // 2) Query draft summary for selected style
                // ------------------------------------------------
                SAPbobsCOM.Recordset rs =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string safeStyleCode = styleCode.Replace("'", "''");

                string query = $@"
            SELECT
                M.""Code""        AS ""StyleCode"",
                M.""Name""        AS ""StyleName"",
                M.""U_BUYRCODE""  AS ""BuyerCode"",
                M.""U_BURSNAME""  AS ""BuyerName"",
                Q.""DocEntry"",
                Q.""DocNum"",
                Q.""DocDate"",
                Q.""DocStatus"",
                Q.""CardCode"",
                Q.""CardName"",
                SUM(L.""Quantity"")  AS ""TotalQuantity"",
                SUM(L.""LineTotal"") AS ""TotalValue""
            FROM ""OQUT"" Q
            INNER JOIN ""QUT1"" L ON Q.""DocEntry"" = L.""DocEntry""
            INNER JOIN ""@FIL_MH_OPSM"" M ON L.""U_StyleCode"" = M.""Code""
            WHERE M.""Code"" = '{safeStyleCode}'
            GROUP BY
                M.""Code"", M.""Name"", M.""U_BUYRCODE"", M.""U_BURSNAME"",
                Q.""DocEntry"", Q.""DocNum"", Q.""DocDate"", Q.""DocStatus"",
                Q.""CardCode"", Q.""CardName""";

                rs.DoQuery(query);

                List<DraftRow> draftList = new List<DraftRow>();
                while (!rs.EoF)
                {
                    draftList.Add(new DraftRow
                    {
                        StyleCode = rs.Fields.Item("StyleCode").Value.ToString().Trim(),
                        StyleName = rs.Fields.Item("StyleName").Value.ToString().Trim(),
                        BuyerCode = rs.Fields.Item("BuyerCode").Value.ToString().Trim(),
                        BuyerName = rs.Fields.Item("BuyerName").Value.ToString().Trim(),
                        DocEntry = rs.Fields.Item("DocEntry").Value.ToString().Trim(),
                        DocNum = rs.Fields.Item("DocNum").Value.ToString().Trim(),
                        DocDate = Convert.ToDateTime(rs.Fields.Item("DocDate").Value).ToString("yyyyMMdd"),
                        DocStatus = rs.Fields.Item("DocStatus").Value.ToString().Trim(),
                        CardCode = rs.Fields.Item("CardCode").Value.ToString().Trim(),
                        CardName = rs.Fields.Item("CardName").Value.ToString().Trim(),
                        TotalQuantity = ToDoubleSafe(rs.Fields.Item("TotalQuantity").Value.ToString()),
                        TotalValue = ToDoubleSafe(rs.Fields.Item("TotalValue").Value.ToString())
                    });

                    rs.MoveNext();
                }

                // ------------------------------------------------
                // 3) Insert/update draft rows and track affected rows
                // ------------------------------------------------
                oMatrixDraft.FlushToDataSource();

                List<int> affectedRows = new List<int>();
                List<bool> insertedRows = new List<bool>();

                foreach (DraftRow draft in draftList)
                {
                    int rowToUse = -1;
                    bool foundExisting = false;

                    // Find existing row by StyleCode + DocEntry
                    for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                    {
                        string existingStyle = GetEditTextValue(oMatrixDraft, "CLSTYLCD", i);
                        string existingDocEntry = GetEditTextValue(oMatrixDraft, "CLDRNTRY", i);

                        if (existingStyle.Equals(draft.StyleCode, StringComparison.OrdinalIgnoreCase) &&
                            existingDocEntry.Equals(draft.DocEntry, StringComparison.OrdinalIgnoreCase))
                        {
                            rowToUse = i;
                            foundExisting = true;
                            break;
                        }
                    }

                    // Otherwise find empty row
                    if (!foundExisting)
                    {
                        for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                        {
                            string existingStyle = GetEditTextValue(oMatrixDraft, "CLSTYLCD", i);
                            string existingDocEntry = GetEditTextValue(oMatrixDraft, "CLDRNTRY", i);

                            if (string.IsNullOrWhiteSpace(existingStyle) && string.IsNullOrWhiteSpace(existingDocEntry))
                            {
                                rowToUse = i;
                                break;
                            }
                        }

                        // Add new row if needed
                        if (rowToUse == -1)
                        {
                            Global.GFunc.SetNewLine(oMatrixDraft, dbDraft, 1, "");
                            rowToUse = oMatrixDraft.RowCount;
                        }
                    }

                    // Fill row
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLSTYLCD", draft.StyleCode);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLSTYLNM", draft.StyleName);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLBYRSCD", draft.BuyerCode);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLBYRSNM", draft.BuyerName);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLDRNTRY", draft.DocEntry);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLDRNUM", draft.DocNum);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLDOCDAT", draft.DocDate);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLDCSTAT", draft.DocStatus);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLCRDCOD", draft.CardCode);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLCRDNAM", draft.CardName);
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLTOLQTY", draft.TotalQuantity.ToString());
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLDOCTOL", draft.TotalValue.ToString());
                    oMatrixDraft.SetCellWithoutValidation(rowToUse, "CLACTIVE", "Y");

                    affectedRows.Add(rowToUse);
                    insertedRows.Add(!foundExisting);
                }

                oMatrixDraft.FlushToDataSource();
                oMatrixDraft.LoadFromDataSource();

                // ------------------------------------------------
                // 4) Calculate totals
                //    A) style-wise active qty/value for current main row
                //    B) all active value for ETVAL
                // ------------------------------------------------
                double styleWiseQty = 0;
                double styleWiseValue = 0;
                double overallActiveValue = 0;

                for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                {
                    bool isActive = ((SAPbouiCOM.CheckBox)oMatrixDraft.Columns.Item("CLACTIVE").Cells.Item(i).Specific).Checked;
                    if (!isActive)
                        continue;

                    string rowStyleCode = GetEditTextValue(oMatrixDraft, "CLSTYLCD", i);
                    double rowQty = ToDoubleSafe(GetEditTextValue(oMatrixDraft, "CLTOLQTY", i));
                    double rowValue = ToDoubleSafe(GetEditTextValue(oMatrixDraft, "CLDOCTOL", i));

                    overallActiveValue += rowValue;

                    if (rowStyleCode.Equals(styleCode, StringComparison.OrdinalIgnoreCase))
                    {
                        styleWiseQty += rowQty;
                        styleWiseValue += rowValue;
                    }
                }

                // Set style-wise totals into main matrix current row
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLQUAN", styleWiseQty.ToString("N2"));
                oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", styleWiseValue.ToString("N2"));
                oMatrix.FlushToDataSource();
                oMatrix.LoadFromDataSource();

                // Set overall active total into ETVAL
                SAPbouiCOM.EditText oEditTotal = (SAPbouiCOM.EditText)oForm.Items.Item("ETVAL").Specific;
                oEditTotal.Value = overallActiveValue.ToString("N2");

                // ------------------------------------------------
                // 5) Compare ETVAL with ETSCVAL
                // ------------------------------------------------
                double scValue = ToDoubleSafe(((SAPbouiCOM.EditText)oForm.Items.Item("ETSCVAL").Specific).Value);

                if (overallActiveValue > scValue)
                {
                    Application.SBO_Application.MessageBox("Total value exceeds SC value. Selected style will be removed.");

                    // ----------------------------------------
                    // 1) Clear current row from main matrix
                    // ----------------------------------------
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLCD", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLSTYLNM", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLBYCODE", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLBYNAME", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLQUAN", "");
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLVALUE", "");
                    oMatrix.FlushToDataSource();
                    oMatrix.LoadFromDataSource();

                    // ----------------------------------------
                    // 2) Remove all draft rows of this style
                    // ----------------------------------------
                    oMatrixDraft.FlushToDataSource();

                    for (int i = oMatrixDraft.RowCount; i >= 1; i--)
                    {
                        string rowStyleCode = GetEditTextValue(oMatrixDraft, "CLSTYLCD", i);

                        if (rowStyleCode.Equals(styleCode, StringComparison.OrdinalIgnoreCase))
                        {
                            dbDraft.RemoveRecord(i - 1);
                        }
                    }

                    oMatrixDraft.LoadFromDataSource();

                    // ----------------------------------------
                    // 3) Recalculate ETVAL after draft removal
                    // ----------------------------------------
                    double newOverallActiveValue = 0;

                    for (int i = 1; i <= oMatrixDraft.RowCount; i++)
                    {
                        bool isActive = ((SAPbouiCOM.CheckBox)oMatrixDraft.Columns.Item("CLACTIVE").Cells.Item(i).Specific).Checked;
                        if (!isActive)
                            continue;

                        newOverallActiveValue += ToDoubleSafe(GetEditTextValue(oMatrixDraft, "CLDOCTOL", i));
                    }

                    oEditTotal.Value = newOverallActiveValue.ToString("N2");

                    oMatrixDraft.AutoResizeColumns();
                    return;
                }

                // ------------------------------------------------
                // 6) Add new empty row in main matrix
                // ------------------------------------------------
                int lastRow = oMatrix.RowCount;
                bool lastRowHasData = !string.IsNullOrWhiteSpace(GetEditTextValue(oMatrix, "CLSTYLCD", lastRow));

                if (lastRowHasData)
                    Global.GFunc.SetNewLine(oMatrix, dbMain, 1, "");

                oMatrix.AutoResizeColumns();
                oMatrixDraft.AutoResizeColumns();
                oForm.Update();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private class DraftRow
        {
            public string StyleCode { get; set; }
            public string StyleName { get; set; }
            public string BuyerCode { get; set; }
            public string BuyerName { get; set; }
            public string DocEntry { get; set; }
            public string DocNum { get; set; }
            public string DocDate { get; set; }
            public string DocStatus { get; set; }
            public string CardCode { get; set; }
            public string CardName { get; set; }
            public double TotalQuantity { get; set; }
            public double TotalValue { get; set; }
        }

        private string GetEditTextValue(SAPbouiCOM.Matrix matrix, string colId, int row)
        {
            return ((SAPbouiCOM.EditText)matrix.Columns.Item(colId).Cells.Item(row).Specific).Value.Trim();
        }

        private double ToDoubleSafe(string value)
        {
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }



        private void ETHSBNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
                string sql = $"SELECT \"BankCode\",\"Branch\" FROM DSC1 WHERE \"Account\" = '{account.Replace("'", "''")}'";
                oRS.DoQuery(sql);

                string bankCode = "";
                if (!oRS.EoF)
                {
                    bankCode = oRS.Fields.Item("BankCode").Value.ToString();
                }
                // Example: set to an EditText on the form
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etNegBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETHSBNK").Specific;
                etNegBnk.Value = account;
                SAPbouiCOM.EditText etNegBNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETHBNKNM").Specific;
                etNegBNm.Value = bankCode;


                SAPbouiCOM.ComboBox CBBRNCH = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBBRNCH").Specific;
                Global.GFunc.setComboBoxValue(CBBRNCH, sql);
                CBBRNCH.Select(oRS.Fields.Item("Branch").Value.ToString(), SAPbouiCOM.BoSearchKey.psk_ByValue);

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
                string CountryCode = dt.GetValue("CountryCod", 0).ToString().Trim();


                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etIssBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNK2").Specific;
                etIssBnk.Value = bankCode;
                SAPbouiCOM.EditText etIBnkNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETBBKNM2").Specific;
                etIBnkNm.Value = bankName;

                ////Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" where ""Code"" = '" + CountryCode + "' ";
                SAPbouiCOM.ComboBox CBCNTRY2 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY2").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY2, countrySql);
                CBCNTRY2.Select(CountryCode, SAPbouiCOM.BoSearchKey.psk_ByValue);

            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
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
                string CountryCode = dt.GetValue("CountryCod", 0).ToString().Trim();

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.EditText etIssBnk = (SAPbouiCOM.EditText)oForm.Items.Item("ETBPBNK1").Specific;
                etIssBnk.Value = bankCode;
                SAPbouiCOM.EditText etIBnkNm = (SAPbouiCOM.EditText)oForm.Items.Item("ETBBKNM1").Specific;
                etIBnkNm.Value = bankName;


                ////Load Bank Country Combobox
                string countrySql = @"SELECT ""Code"", ""Name"" FROM ""OCRY"" where ""Code"" = '" + CountryCode + "' ";
                SAPbouiCOM.ComboBox CBCNTRY1 = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCNTRY1").Specific;
                Global.GFunc.setComboBoxValue(CBCNTRY1, countrySql);
                CBCNTRY1.Select(CountryCode, SAPbouiCOM.BoSearchKey.psk_ByValue);
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }


        private void ETBUNIT_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("PrcCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETBUNIT = (SAPbouiCOM.EditText)oForm.Items.Item("ETBUNIT").Specific;
            ETBUNIT.Value = Code;

        }

        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCURR = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETCURR.Value = Code;

        }

        private void ETBRNDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string Code = dt.GetValue("Code", 0).ToString().Trim();
                string Name = dt.GetValue("Name", 0).ToString().Trim();

                SAPbouiCOM.EditText ETBRNDCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific;
                ETBRNDCD.Value = Code;
                SAPbouiCOM.EditText ETBRNDNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDNM").Specific;
                ETBRNDNM.Value = Name;

                InitializeAllMatrices(oForm);


            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }
        private void InitializeMatrixIfEmpty(SAPbouiCOM.Form oForm, string matrixItemId, string dbDataSourceId)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixItemId).Specific;
            SAPbouiCOM.DBDataSource dbDataSource = oForm.DataSources.DBDataSources.Item(dbDataSourceId);
            int lastRow = oMatrix.RowCount;

            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, dbDataSource, 1, "");
            }
        }

        private void InitializeAllMatrices(SAPbouiCOM.Form oForm)
        {
            InitializeMatrixIfEmpty(oForm, "MTXSTLYD", "@FIL_DR_SCM1");   // Style Matrix
            //InitializeMatrixIfEmpty(oForm, "MTXDRAFT", "@FIL_DR_SCM2");   // Draft Matrix
            InitializeMatrixIfEmpty(oForm, "MTXATTAC", "@FIL_DR_SCM3");   // Attachment Matrix
        }

        private void ETCUSCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
                SAPbouiCOM.EditText etCusCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific;
                SAPbouiCOM.EditText etCusNam = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSNAM").Specific;

                etCusCode.Value = cardCode;
                etCusNam.Value = cardName;


            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox("Error in ChooseFromListAfter: " + e.Message);
            }

        }

        private SAPbouiCOM.Button Button0;
    }
}
