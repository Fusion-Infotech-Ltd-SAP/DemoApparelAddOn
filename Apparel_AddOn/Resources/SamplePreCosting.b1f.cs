using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SamplePreCosting", "Resources/SamplePreCosting.b1f")]
    class SamplePreCosting : UserFormBase
    {
        public SamplePreCosting()
        {
        }

        private SAPbouiCOM.StaticText STSMPLCD, STCURR, STTCNAMT, STNO, STDOCNUM, STDATE, STVERSON, STBUYER;

        private SAPbouiCOM.ComboBox CBNO;

        private SAPbouiCOM.EditText ETSMPLCD, ETCURR, ETTCNAMT, ETNO, ETBYRNM, ETSMPLNM, ETDOCNUM, ETDATE, ETVERSON, ETBUYER, ETDOCTRY;



        private SAPbouiCOM.Folder FOLCMPNT, FOLOTCST, FOLVERSN;

        private SAPbouiCOM.Button ADDButton, CancelButton, BTNVRNUP, BTNLCSTH;

        private SAPbouiCOM.Matrix MTXCMPNT, MTXOTCST;

        private SAPbouiCOM.LinkedButton LKBUYER, LKSMPLCD;

        private SAPbouiCOM.Grid GRDVERSN;

        public override void OnInitializeComponent()
        {
            this.STSMPLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSMPLCD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STTCNAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STTCNAMT").Specific));
            this.STNO = ((SAPbouiCOM.StaticText)(this.GetItem("STNO").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDATE = ((SAPbouiCOM.StaticText)(this.GetItem("STDATE").Specific));
            this.STVERSON = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.STBUYER = ((SAPbouiCOM.StaticText)(this.GetItem("STBUYER").Specific));
            this.CBNO = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.ETSMPLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSMPLCD").Specific));
            this.ETSMPLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSMPLCD_ChooseFromListAfter);
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETTCNAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETTCNAMT").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETDATE = ((SAPbouiCOM.EditText)(this.GetItem("ETDATE").Specific));
            this.ETVERSON = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.ETBUYER = ((SAPbouiCOM.EditText)(this.GetItem("ETBUYER").Specific));
            this.ETBUYER.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBUYER_ChooseFromListAfter);
            this.FOLCMPNT = ((SAPbouiCOM.Folder)(this.GetItem("FOLCMPNT").Specific));
            this.FOLOTCST = ((SAPbouiCOM.Folder)(this.GetItem("FOLOTCST").Specific));
            this.FOLVERSN = ((SAPbouiCOM.Folder)(this.GetItem("FOLVERSN").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNVRNUP = ((SAPbouiCOM.Button)(this.GetItem("BTNVRNUP").Specific));
            this.MTXCMPNT = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCMPNT").Specific));
            this.MTXOTCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOTCST").Specific));
            this.LKBUYER = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKBUYER").Specific));
            this.LKSMPLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSMPLCD").Specific));
            this.ETSMPLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSMPLNM").Specific));
            this.ETBYRNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBYRNM").Specific));
            this.GRDVERSN = ((SAPbouiCOM.Grid)(this.GetItem("GRDVERSN").Specific));
            this.BTNLCSTH = ((SAPbouiCOM.Button)(this.GetItem("BTNLCSTH").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }


        private void OnCustomInitialize()
        {

        }

        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETBCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETBCD.Value = Code;

        }

        private void ETBUYER_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

           
            string buyCode = dt.GetValue("CardCode", 0).ToString().Trim();
            string buyName = dt.GetValue("CardName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETBCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBUYER").Specific;
            ETBCD.Value = buyCode;
            SAPbouiCOM.EditText ETBNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBYRNM").Specific;
            ETBNM.Value = buyName;

        }

        private void ETSMPLCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("U_SMPLCODE", 0).ToString().Trim();
            string Name = dt.GetValue("U_SMPLDESC", 0).ToString().Trim();
            string buyCode = dt.GetValue("U_CARDCODE", 0).ToString().Trim();
            string buyName = dt.GetValue("U_CARDNAME", 0).ToString().Trim();
            string route = dt.GetValue("U_ROUTSTAG", 0).ToString().Trim();

            try
            {
                SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLCD").Specific;
                ETCD.Value = Code;
                SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLNM").Specific;
                ETNM.Value = Name;

                SAPbouiCOM.EditText ETBCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBUYER").Specific;
                ETBCD.Value = buyCode;
                SAPbouiCOM.EditText ETBNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBYRNM").Specific;
                ETBNM.Value = buyName;

                EnsureLine(oForm, "MTXCMPNT", "@FIL_DH_PRECOSTING");
                EnsureLine(oForm, "MTXOTCST", "@FIL_DR_PRECOSTOTHR");

                string query =$"";
            }
            catch (Exception)
            {

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
    }
}
