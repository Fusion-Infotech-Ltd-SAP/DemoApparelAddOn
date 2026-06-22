using Apparel_AddOn.Helper;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.DownPayment", "Resources/DownPayment.b1f")]
    class DownPayment : UserFormBase
    {
        public DownPayment()
        {
        }

        private SAPbouiCOM.StaticText   STBPLID, STCARDCD, STPIREF, STLCNO, STINCTRM, STCURR, STPAYTRM, STCINVNO, STNO, STSTATUS,
                                        STPOSTDT, STDUEDT, STDOCDT, ETDPM, STREMRK, STITMVAL, STFRGHT, STDPMAMT, STDOCTOT;
        private SAPbouiCOM.EditText     ETCARDCD, ETPIREF, ETCARDNM, ETCINVNO, ETLCNO, ETDOCNUM, ETSTATUS,
                                        ETPOSTDT, ETDUEDT, ETDOCDT, ETDPDOCN, ETDPDOCE, EETREMRK,                                       
                                        ETDOCTRY, ETITMVAL, ETFRGHT, ETDPMPER, ETDPAMT, ETDOCTOT;

        private SAPbouiCOM.ComboBox     CBBPLID, CBPAYTRM , CBCURR, CBINCTRM;
        private SAPbouiCOM.Folder       FOLDER1, FOLDER2;
        private SAPbouiCOM.Matrix       MTX_ITM, MTXATTCH;
        private SAPbouiCOM.Button       BTNADD, BTNCANCL, BTNCOPY, BTNPOST, BRWSBTN, DISPBTN, DELBTN;
        private SAPbouiCOM.LinkedButton LINKCUST, LINKDPM;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.CBBPLID = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBPLID").Specific));
            this.ETCARDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCARDCD").Specific));
            this.ETCARDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETCARDCD_ChooseFromListBefore);
            this.ETCARDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCARDCD_ChooseFromListAfter);
            this.ETPIREF = ((SAPbouiCOM.EditText)(this.GetItem("ETPIREF").Specific));
            this.ETCARDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCARDNM").Specific));
            this.CBPAYTRM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPAYTRM").Specific));
            this.CBCURR = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCURR").Specific));
            this.ETCINVNO = ((SAPbouiCOM.EditText)(this.GetItem("ETCINVNO").Specific));
            this.STBPLID = ((SAPbouiCOM.StaticText)(this.GetItem("STBPLID").Specific));
            this.STCARDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STCARDCD").Specific));
            this.STPIREF = ((SAPbouiCOM.StaticText)(this.GetItem("STPIREF").Specific));
            this.STLCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STLCNO").Specific));
            this.STINCTRM = ((SAPbouiCOM.StaticText)(this.GetItem("STINCTRM").Specific));
            this.ETLCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETLCNO").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STPAYTRM = ((SAPbouiCOM.StaticText)(this.GetItem("STPAYTRM").Specific));
            this.STCINVNO = ((SAPbouiCOM.StaticText)(this.GetItem("STCINVNO").Specific));
            this.STNO = ((SAPbouiCOM.StaticText)(this.GetItem("STNO").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.ETSTATUS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATUS").Specific));
            this.ETPOSTDT = ((SAPbouiCOM.EditText)(this.GetItem("ETPOSTDT").Specific));
            this.ETDUEDT = ((SAPbouiCOM.EditText)(this.GetItem("ETDUEDT").Specific));
            this.ETDOCDT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDT").Specific));
            this.ETDPDOCN = ((SAPbouiCOM.EditText)(this.GetItem("ETDPDOCN").Specific));
            this.ETDPDOCE = ((SAPbouiCOM.EditText)(this.GetItem("ETDPDOCE").Specific));
            this.STPOSTDT = ((SAPbouiCOM.StaticText)(this.GetItem("STPOSTDT").Specific));
            this.STDUEDT = ((SAPbouiCOM.StaticText)(this.GetItem("STDUEDT").Specific));
            this.STDOCDT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDT").Specific));
            this.ETDPM = ((SAPbouiCOM.StaticText)(this.GetItem("ETDPM").Specific));
            this.CBINCTRM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINCTRM").Specific));
            this.FOLDER1 = ((SAPbouiCOM.Folder)(this.GetItem("FOLDER1").Specific));
            this.FOLDER2 = ((SAPbouiCOM.Folder)(this.GetItem("FOLDER2").Specific));
            this.MTX_ITM = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_ITM").Specific));
            this.EETREMRK = ((SAPbouiCOM.EditText)(this.GetItem("EETREMRK").Specific));
            this.BTNADD = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.BTNADD.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNADD_PressedBefore);
            this.BTNCANCL = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNCOPY = ((SAPbouiCOM.Button)(this.GetItem("BTNCOPY").Specific));
            this.BTNCOPY.ChooseFromListBefore += new SAPbouiCOM._IButtonEvents_ChooseFromListBeforeEventHandler(this.BTNCOPY_ChooseFromListBefore);
            this.BTNCOPY.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.BTNCOPY_ChooseFromListAfter);
            this.BTNPOST = ((SAPbouiCOM.Button)(this.GetItem("BTNPOST").Specific));
            this.BTNPOST.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNADD_PressedBefore);
            this.BTNPOST.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNPOST_PressedAfter);
            this.STREMRK = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRK").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETITMVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETITMVAL").Specific));
            this.ETFRGHT = ((SAPbouiCOM.EditText)(this.GetItem("ETFRGHT").Specific));
            this.ETDPMPER = ((SAPbouiCOM.EditText)(this.GetItem("ETDPMPER").Specific));
            this.ETDPAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETDPAMT").Specific));
            this.ETDOCTOT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTOT").Specific));
            this.STITMVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STITMVAL").Specific));
            this.STFRGHT = ((SAPbouiCOM.StaticText)(this.GetItem("STFRGHT").Specific));
            this.STDPMAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STDPMAMT").Specific));
            this.STDOCTOT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCTOT").Specific));
            this.LINKCUST = ((SAPbouiCOM.LinkedButton)(this.GetItem("LINKCUST").Specific));
            this.LINKDPM = ((SAPbouiCOM.LinkedButton)(this.GetItem("LINKDPM").Specific));
            this.LINKDPM.ClickAfter += new SAPbouiCOM._ILinkedButtonEvents_ClickAfterEventHandler(this.LINKDPM_ClickAfter);
            this.LINKDPM.ClickBefore += new SAPbouiCOM._ILinkedButtonEvents_ClickBeforeEventHandler(this.LINKDPM_ClickBefore);
            this.MTXATTCH = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.BRWSBTN_ClickAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DISPBTN_ClickAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.DELBTN_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {
        }

        private void BTNADD_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                //Validation Start

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE ||
                    oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                {
                    var validations = new List<(string ItemUID, string FieldName)>
            {
             ("CBBPLID",  "Company"),
             ("ETCARDCD", "Supplier Code"),
             ("ETPIREF",  "PI Reference"),
             ("ETPOSTDT", "Posting Date"),
             ("ETDUEDT",  "Due Date"),
             ("ETDOCDT",  "Document Date")
            };

                    foreach (var v in validations)
                    {
                        SAPbouiCOM.Item item = oForm.Items.Item(v.ItemUID);

                        string value = string.Empty;

                        if (item.Specific is SAPbouiCOM.EditText)
                            value = ((SAPbouiCOM.EditText)item.Specific).Value.Trim();

                        else if (item.Specific is SAPbouiCOM.ComboBox)
                            value = ((SAPbouiCOM.ComboBox)item.Specific).Value.Trim();

                        if (string.IsNullOrEmpty(value))
                        {
                            Application.SBO_Application.StatusBar.SetText(
                                $"Fill out {v.FieldName} !",
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            oForm.Items.Item(v.ItemUID).Click();
                            BubbleEvent = false;
                            return;
                        }
                    }

                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_ITM").Specific;
                    if (BubbleEvent == true)
                    {
                        if (oMatrix.RowCount == 0)
                        {
                            Application.SBO_Application.StatusBar.SetText(
                            $"No Item Details Found !",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            BubbleEvent = false;
                        }
                    }
                    //Validation End
                }
            }
        }

        private void LINKDPM_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Items.Item("ETDPDOCE").Enabled = true;
        }

        private void LINKDPM_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Items.Item("ETDPDOCE").Enabled = false;
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Items.Item("ETDOCNUM").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Find, SAPbouiCOM.BoModeVisualBehavior.mvb_True);
            oForm.Items.Item("ETDOCNUM").SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, (int)SAPbouiCOM.BoAutoFormMode.afm_Add, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

        }

        private void ETCARDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Freeze(true);

            // Get the ChooseFromList object for the button clicked
            SAPbouiCOM.ChooseFromList oCfl = oForm.ChooseFromLists.Item(((SAPbouiCOM.EditText)oForm.Items.Item(pVal.ItemUID).Specific).ChooseFromListUID);

            // Create conditions for filtering the CFL
            SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
            SAPbouiCOM.Condition oCon;

            oCon = oCons.Add();
            oCon.Alias = "CardType";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "S";

            oCfl.SetConditions(oCons);

            oForm.Freeze(false);
        }

        private void ETCARDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CardCode", 0).ToString().Trim();
            string Name = dt.GetValue("CardName", 0).ToString().Trim();

            ETCARDCD.Value = Code; //issue
            ETCARDNM.Value = Name;
        }

        private void BTNCOPY_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form  oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Freeze(true);

            SAPbouiCOM.ChooseFromList oCfl = oForm.ChooseFromLists.Item(((SAPbouiCOM.Button)oForm.Items.Item(pVal.ItemUID).Specific).ChooseFromListUID);

            SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
            SAPbouiCOM.Condition oCon;

            // DocStatus = Open
            oCon = oCons.Add();
            oCon.Alias = "DocStatus";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "O";

            // CardCode = selected BP
            string cardCode = ETCARDCD.Value == null ? "" : ETCARDCD.Value.Trim();
            if (!string.IsNullOrEmpty(cardCode))
            {
                oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                oCon = oCons.Add();
                oCon.Alias = "CardCode";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = cardCode;
            }

            oCfl.SetConditions(oCons);

            oForm.Freeze(false);
        }

        private void BTNCOPY_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflEvent = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string Uid = cflEvent.ChooseFromListUID;

                SAPbouiCOM.DataTable oDataTable = cflEvent.SelectedObjects;

                if (oDataTable != null)
                {
                    string strDocEntry = "";
                    for (int i = 0; i < oDataTable.Rows.Count; i++)
                    {
                        if (strDocEntry != "")
                            strDocEntry = strDocEntry + "," + oDataTable.GetValue("DocEntry", i).ToString();
                        else
                            strDocEntry = oDataTable.GetValue("DocEntry", i).ToString();
                    }
                    Form_No_POList SoList = new Form_No_POList();
                    SoList.Show();
                    SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_NO_POLIST");

                    Form_No_POList.LoadPOList(ref cForm, strDocEntry);
                }
            }
            catch (Exception ex) { }
        }

        internal static void ItemList(List<(string DocEntry, string BaseType, int BaseLine, string PONumber, string ItemCode,
                                            string ItemDescription, double Quantity, double UnitPrice, string TaxCode, double TaxValue, double GTotal)> data)
        {
            SAPbouiCOM.Form oForm     = Application.SBO_Application.Forms.Item("FIL_FRM_DOWNPAYMT");
            SAPbouiCOM.Matrix MTX_ITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_ITM").Specific;
            SAPbouiCOM.DBDataSource 
                          ODataSource = oForm.DataSources.DBDataSources.Item("@FIL_DR_DPMRQST");

            oForm.Freeze(true);

            try
            {
                ODataSource.Clear();

                HashSet<string> uniqueDocNums = new HashSet<string>();

                    for (int i = 0; i < data.Count; i++)
                {
                    ODataSource.InsertRecord(ODataSource.Size);
                    ODataSource.SetValue("LineId",     ODataSource.Size - 1, (i + 1).ToString());
                    ODataSource.SetValue("U_BASENTRY", ODataSource.Size - 1, data[i].DocEntry.ToString());
                    ODataSource.SetValue("U_BASETYPE", ODataSource.Size - 1, data[i].BaseType.ToString());
                    ODataSource.SetValue("U_BASEREF",  ODataSource.Size - 1, data[i].PONumber.ToString());
                    ODataSource.SetValue("U_BASELINE", ODataSource.Size - 1, data[i].BaseLine.ToString());
                    ODataSource.SetValue("U_ITEMCODE", ODataSource.Size - 1, data[i].ItemCode);
                    ODataSource.SetValue("U_ITEMNAME", ODataSource.Size - 1, data[i].ItemDescription);
                    ODataSource.SetValue("U_QUANTITY", ODataSource.Size - 1, data[i].Quantity.ToString());
                    ODataSource.SetValue("U_PRICE",    ODataSource.Size - 1, data[i].UnitPrice.ToString());
                    ODataSource.SetValue("U_TAXCODE",  ODataSource.Size - 1, data[i].TaxCode.ToString());
                    ODataSource.SetValue("U_TAXVAL",   ODataSource.Size - 1, data[i].TaxValue.ToString());
                    ODataSource.SetValue("U_LINETOTAL",ODataSource.Size - 1, data[i].GTotal.ToString());
                }
                MTX_ITM.LoadFromDataSource();
                MTX_ITM.AutoResizeColumns();

                double total = 0;
                for (int i = 1; i <= MTX_ITM.VisualRowCount; i++)
                {
                    var cell = (SAPbouiCOM.EditText)MTX_ITM.Columns.Item("CLLINETOT").Cells.Item(i).Specific; // column UID
                    double.TryParse(cell.Value, out double value);
                    total += value;
                }

                SAPbouiCOM.EditText oEditETITMVAL = (SAPbouiCOM.EditText)oForm.Items.Item("ETITMVAL").Specific;
                oEditETITMVAL.Value = total.ToString();
                SAPbouiCOM.EditText oEditETDPMPER = (SAPbouiCOM.EditText)oForm.Items.Item("ETDPMPER").Specific;
                oEditETDPMPER.Value = "100.00";
                SAPbouiCOM.EditText oEditETDPAMT = (SAPbouiCOM.EditText)oForm.Items.Item("ETDPAMT").Specific;
                oEditETDPAMT.Value  = total.ToString();
                SAPbouiCOM.EditText oEditETDOCTOT = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTOT").Specific;
                oEditETDOCTOT.Value = total.ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void BTNPOST_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string DPMEntry;
            string Errormsg;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            try
            {
                oForm.Freeze(true);
                // Create A/P Down Payment Request object
                SAPbobsCOM.Documents apDp =
                    (SAPbobsCOM.Documents)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDownPayments);

                apDp.DocDate     = DateTime.ParseExact(ETPOSTDT.Value, "yyyyMMdd", null); //Posting Date
                apDp.DocDueDate  = DateTime.ParseExact(ETDUEDT.Value,  "yyyyMMdd", null); //Due Date
                apDp.TaxDate     = DateTime.ParseExact(ETDOCDT.Value,  "yyyyMMdd", null); //Documnet date
                apDp.Comments    = EETREMRK.Value;

                if (!string.IsNullOrEmpty(CBPAYTRM.Value))
                   { apDp.GroupNumber = Convert.ToInt32(CBPAYTRM.Value);} //Payment Terms

                apDp.NumAtCard = ETPIREF.Value; //PI REF

                //////
                apDp.CardCode = ETCARDCD.Value;
                apDp.DocObjectCode = SAPbobsCOM.BoObjectTypes.oPurchaseDownPayments;
                apDp.BPL_IDAssignedToInvoice = Convert.ToInt32(CBBPLID.Value);
                apDp.DownPaymentType = SAPbobsCOM.DownPaymentTypeEnum.dptRequest;
                apDp.DocCurrency = CBCURR.Value;
                //////

                apDp.UserFields.Fields.Item("U_LC_NUM").Value = ETLCNO.Value;     //LC no
                apDp.UserFields.Fields.Item("U_INCOTRMS").Value = CBINCTRM.Value; //Inco Terms
                apDp.UserFields.Fields.Item("U_COMNO").Value = ETCINVNO.Value;    //Com Inv No

                string formattedDate = ETDOCDT.Value.Substring(0, 4) + "-" +
                                       ETDOCDT.Value.Substring(4, 2) + "-" +
                                       ETDOCDT.Value.Substring(6, 2);

                int lcSeries = (Convert.ToInt32(CBBPLID.Value) > 0)
                                ? GetSeriesForBranch("204", Convert.ToInt32(CBBPLID.Value), formattedDate) //Down Payment Object Code is 204
                                : 0;

                if (lcSeries > 0)
                    apDp.Series = lcSeries;

                SAPbouiCOM.DBDataSource pDataSource =
                oForm.DataSources.DBDataSources.Item("@FIL_DR_DPMRQST");

                for (int i = pDataSource.Size - 1; i >= 0; i--)
                {
                    apDp.Lines.BaseType = 22;
                    apDp.Lines.BaseEntry = Convert.ToInt32(pDataSource.GetValue("U_BASENTRY", i));
                    apDp.Lines.BaseLine  = Convert.ToInt32(pDataSource.GetValue("U_BASELINE", i));
                    apDp.Lines.Add();
                }

                int lRetCode = apDp.Add();

                if (lRetCode != 0)
                {
                    int errCode;
                    string sErrMsg;
                    Global.oComp.GetLastError(out errCode, out sErrMsg);
                    Errormsg = sErrMsg;
                    Application.SBO_Application.SetStatusBarMessage("Error - " + Errormsg, SAPbouiCOM.BoMessageTime.bmt_Medium, true);
                }
                else
                {
                    string ObjType = Global.oComp.GetNewObjectType().ToString().TrimEnd();
                    DPMEntry = Global.oComp.GetNewObjectKey().Trim();
                    ETDPDOCE.Value = DPMEntry;

                    if (!string.IsNullOrEmpty(DPMEntry))
                    {
                        SAPbobsCOM.Recordset rs =
                        (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string q = $@" SELECT  ""DocNum"" FROM ""ODPO"" WHERE ""DocEntry"" = '{DPMEntry}'";
                        rs.DoQuery(q);

                        if (rs.RecordCount > 0)
                        {
                            ETDPDOCN.Value = rs.Fields.Item("DocNum").Value.ToString();
                        }

                        //Update mode
                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                        // Click the Update button programmatically
                        SAPbouiCOM.Button oBtnUpdate = (SAPbouiCOM.Button)oForm.Items.Item("1").Specific; // "1" is usually the standard Update button
                        oBtnUpdate.Item.Click();
                        oForm.Items.Item("BTNPOST").Visible = false; 
                        
                        Application.SBO_Application.SetStatusBarMessage("Success - " + ETDPDOCN.Value + " : Down Payment Created Successfully",SAPbouiCOM.BoMessageTime.bmt_Medium,false);
                    }
                }
            }
            catch (Exception ex)
            {
                Errormsg = ex.Message;
                Application.SBO_Application.SetStatusBarMessage("Error - " + Errormsg, SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private int GetSeriesForBranch(string objectCode, int bplId , string docDate)
        {
            SAPbobsCOM.Recordset rs =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string q = $@"
                            SELECT TOP 1 
                            N.""Series"",
                            B.""BPLId"",
                            TO_CHAR(NOW(),'YYYYMMDD') AS ""DocDate""
                        FROM ""NNM1"" N
                        INNER JOIN ""OFPR"" O ON O.""Indicator"" = N.""Indicator""
                        INNER JOIN ""OBPL"" B ON B.""BPLId"" = N.""BPLId""
                        WHERE N.""ObjectCode"" = '{objectCode}'
                        AND O.""PeriodStat""  IN ('N','C')
                        AND N.""Locked""      = 'N'
                        AND B.""BPLId""       = {bplId}
                        AND TO_DATE('{docDate}','YYYY-MM-DD')
                        BETWEEN O.""F_RefDate"" AND O.""T_RefDate"" ";

            rs.DoQuery(q);

            if (rs.RecordCount > 0)
                return Convert.ToInt32(rs.Fields.Item("Series").Value);

            return 0;
        }


        private void BRWSBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_DPMRATCH");
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

            string filePath = FileDialogHelper.ShowFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                int lastRow = MTXATTCH.VisualRowCount;
                bool needNewRow = (lastRow == 0) ||
                                  !string.IsNullOrEmpty(((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value);
                if (needNewRow)
                {
                    Global.GFunc.SetNewLine(MTXATTCH, DBDataSourceLine, 1, "");
                    lastRow = MTXATTCH.VisualRowCount;
                }

                ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value = filePath;
                MTXATTCH.FlushToDataSource();

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
            }
        }

        private void DISPBTN_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

            for (int i = 1; i <= MTXATTCH.RowCount; i++)
            {
                if (MTXATTCH.IsRowSelected(i))
                {
                    string filePath = ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(i).Specific).Value;
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
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_DPMRATCH");
            SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;


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
                        Application.SBO_Application.MessageBox("Invalid row index.");
                    }

                    break;
                }
            }
        }

    }
}
