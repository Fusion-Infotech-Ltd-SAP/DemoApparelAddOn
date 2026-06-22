using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;
using Apparel_AddOn.Modules;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.StyleMaster", "Resources/StyleMaster.b1f")]
    class StyleMaster : UserFormBase
    {
        public StyleMaster()
        {
        }
        private SAPbouiCOM.StaticText STSTYLID, STSTYLNO, STSTYLNM, STCSYLNO, STPDLNCD, STPDGPCD, STBRNDCD, STPDCYCD,
                                      STDEPTCD, STRTSGCD, STHSCODE, STPDTYCD, STSLTYCD, STMRCDCD, STCURR, STSTATUS, STPRDSAM, STPDLDDY, STSGRPCD,
                                      STPRICE, STPRCLST, STUOM, STWEGTDZ, STMINS, STSYIMG2, STSYIMG3, STMFBRIC, STSZTYCD, STSYIMG1, STSLDESC;



        private SAPbouiCOM.EditText ETSTYLID, ETSTYLNO, ETSTYLNM, ETCSYLNO, ETBRNDCD, ETPDCYCD, ETSLTYCD, ETDEPTCD, ETPDLNCD,
                                    ETRTSGCD, ETPDGPCD, ETHSCODE, ETPDTYCD, ETBRNDNM, ETDEPTNM, ETPDLNNM, ETPDGPNM, ETPDCYNM, ETPDTYNM, ETSLTYNM,
                                    ETRTSGNM, ETMRCDCD, ETCURR, ETPRDSAM, ETPDLDDY, ETMRCDNM, ETPRICE, ETSGRPNM, ETDOCTRY, ETSGRPCD, ETUOM,
                                    ETWEGTDZ, ETSZTYCD, ETMFBRIC, ETSLDESC;



        private SAPbouiCOM.ComboBox ETSTATUS, CBPRCLST;

        private SAPbouiCOM.CheckBox CKACTIVE, CKPURITM, CKSLSITM, CKINVITM;

        private SAPbouiCOM.Folder FOLSZTYP, FOLCOLOR, FOLITMTX, FOLCSTSH, FOLCSTMR, FOLIMAGE, FOLRMRKS;

        private SAPbouiCOM.Matrix MTXSZTYP, MTXCOLOR, MTXITEM, MTXDSCLR, MTXCOST, MTXBSCD;

        private SAPbouiCOM.PictureBox PBSYIMG1, PBSYIMG2, PBSYIMG3;

        private SAPbouiCOM.Button ADDButton, CancelButton, BTNITMTX, BTNITMCR;
       
        private SAPbouiCOM.LinkedButton LKMRCDCD;

        private string styleCode="";

       


        public override void OnInitializeComponent()
        {
            //                             🔹 StaticText
            this.STSTYLID = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLID").Specific));
            this.STSTYLNO = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLNO").Specific));
            this.STSTYLNM = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLNM").Specific));
            this.STCSYLNO = ((SAPbouiCOM.StaticText)(this.GetItem("STCSYLNO").Specific));
            this.STPDLNCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDLNCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPDCYCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDCYCD").Specific));
            this.STDEPTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STDEPTCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STHSCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STHSCODE").Specific));
            this.STPDTYCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDTYCD").Specific));
            this.STSLTYCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSLTYCD").Specific));
            this.STMRCDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STMRCDCD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STPRDSAM = ((SAPbouiCOM.StaticText)(this.GetItem("STPRDSAM").Specific));
            this.STPDLDDY = ((SAPbouiCOM.StaticText)(this.GetItem("STPDLDDY").Specific));
            this.STSGRPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSGRPCD").Specific));
            this.STPRICE = ((SAPbouiCOM.StaticText)(this.GetItem("STPRICE").Specific));
            this.STPRCLST = ((SAPbouiCOM.StaticText)(this.GetItem("STPRCLST").Specific));
            this.STUOM = ((SAPbouiCOM.StaticText)(this.GetItem("STUOM").Specific));
            this.STWEGTDZ = ((SAPbouiCOM.StaticText)(this.GetItem("STWEGTDZ").Specific));
            this.STMINS = ((SAPbouiCOM.StaticText)(this.GetItem("STMINS").Specific));
            this.STSYIMG2 = ((SAPbouiCOM.StaticText)(this.GetItem("STSYIMG2").Specific));
            this.STSYIMG3 = ((SAPbouiCOM.StaticText)(this.GetItem("STSYIMG3").Specific));
            this.STMFBRIC = ((SAPbouiCOM.StaticText)(this.GetItem("STMFBRIC").Specific));
            this.STSZTYCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSZTYCD").Specific));
            this.STSYIMG1 = ((SAPbouiCOM.StaticText)(this.GetItem("STSYIMG1").Specific));
            this.STSLDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STSLDESC").Specific));
            //                             🔹 EditText
            this.ETSTYLID = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLID").Specific));
            this.ETSTYLNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNO").Specific));
            this.ETSTYLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNM").Specific));
            this.ETCSYLNO = ((SAPbouiCOM.EditText)(this.GetItem("ETCSYLNO").Specific));
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNDCD_ChooseFromListBefore);
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETPDCYCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDCYCD").Specific));
            this.ETPDCYCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETPDCYCD_ChooseFromListBefore);
            this.ETPDCYCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPDCYCD_ChooseFromListAfter);
            this.ETSLTYCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSLTYCD").Specific));
            this.ETSLTYCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSLTYCD_ChooseFromListBefore);
            this.ETSLTYCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSLTYCD_ChooseFromListAfter);
            this.ETDEPTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETDEPTCD").Specific));
            this.ETDEPTCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETDEPTCD_ChooseFromListBefore);
            this.ETDEPTCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETDEPTCD_ChooseFromListAfter);
            this.ETPDLNCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDLNCD").Specific));
            this.ETPDLNCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETPDLNCD_ChooseFromListBefore);
            this.ETPDLNCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPDLNCD_ChooseFromListAfter);
            this.ETRTSGCD = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGCD").Specific));
            this.ETRTSGCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETRTSGCD_ChooseFromListAfter);
            this.ETPDGPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPCD").Specific));
            this.ETPDGPCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETPDGPCD_ChooseFromListBefore);
            this.ETPDGPCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPDGPCD_ChooseFromListAfter);
            this.ETHSCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETHSCODE").Specific));
            this.ETPDTYCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDTYCD").Specific));
            this.ETPDTYCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETPDTYCD_ChooseFromListBefore);
            this.ETPDTYCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPDTYCD_ChooseFromListAfter);
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETDEPTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETDEPTNM").Specific));
            this.ETPDLNNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDLNNM").Specific));
            this.ETPDGPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.ETPDCYNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDCYNM").Specific));
            this.ETPDTYNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDTYNM").Specific));
            this.ETSLTYNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSLTYNM").Specific));
            this.ETRTSGNM = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGNM").Specific));
            this.ETMRCDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETMRCDCD").Specific));
            this.ETMRCDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETMRCDCD_ChooseFromListAfter);
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETPRDSAM = ((SAPbouiCOM.EditText)(this.GetItem("ETPRDSAM").Specific));
            this.ETPDLDDY = ((SAPbouiCOM.EditText)(this.GetItem("ETPDLDDY").Specific));
            this.ETMRCDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETMRCDNM").Specific));
            this.ETPRICE = ((SAPbouiCOM.EditText)(this.GetItem("ETPRICE").Specific));
            this.ETSGRPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSGRPNM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETSGRPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSGRPCD").Specific));
            this.ETSGRPCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSGRPCD_ChooseFromListBefore);
            this.ETSGRPCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSGRPCD_ChooseFromListAfter);
            this.ETUOM = ((SAPbouiCOM.EditText)(this.GetItem("ETUOM").Specific));
            this.ETUOM.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETUOM_ChooseFromListAfter);
            this.ETWEGTDZ = ((SAPbouiCOM.EditText)(this.GetItem("ETWEGTDZ").Specific));
            this.ETSZTYCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSZTYCD").Specific));
            this.ETSZTYCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSZTYCD_ChooseFromListAfter);
            this.ETSZTYCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSZTYCD_ChooseFromListBefore);
            this.ETMFBRIC = ((SAPbouiCOM.EditText)(this.GetItem("ETMFBRIC").Specific));
            this.ETSLDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETSLDESC").Specific));
            //                             🔹 ComboBox
            this.ETSTATUS = ((SAPbouiCOM.ComboBox)(this.GetItem("ETSTATUS").Specific));
            this.CBPRCLST = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPRCLST").Specific));
            //                             🔹 CheckBox
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.CKPURITM = ((SAPbouiCOM.CheckBox)(this.GetItem("CKPURITM").Specific));
            this.CKSLSITM = ((SAPbouiCOM.CheckBox)(this.GetItem("CKSLSITM").Specific));
            this.CKINVITM = ((SAPbouiCOM.CheckBox)(this.GetItem("CKINVITM").Specific));
            //                             🔹 Folder
            this.FOLSZTYP = ((SAPbouiCOM.Folder)(this.GetItem("FOLSZTYP").Specific));
            this.FOLCOLOR = ((SAPbouiCOM.Folder)(this.GetItem("FOLCOLOR").Specific));
            this.FOLITMTX = ((SAPbouiCOM.Folder)(this.GetItem("FOLITMTX").Specific));
            this.FOLCSTSH = ((SAPbouiCOM.Folder)(this.GetItem("FOLCSTSH").Specific));
            this.FOLCSTMR = ((SAPbouiCOM.Folder)(this.GetItem("FOLCSTMR").Specific));
            this.FOLIMAGE = ((SAPbouiCOM.Folder)(this.GetItem("FOLIMAGE").Specific));
            this.FOLRMRKS = ((SAPbouiCOM.Folder)(this.GetItem("FOLRMRKS").Specific));
            //                             🔹 Matrix
            this.MTXSZTYP = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSZTYP").Specific));
            this.MTXCOLOR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOLOR").Specific));
            this.MTXCOLOR.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.MTXCOLOR_DoubleClickAfter);
            this.MTXCOLOR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCOLOR_ChooseFromListAfter);
            this.MTXITEM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXITEM").Specific));
            this.MTXDSCLR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXDSCLR").Specific));
            this.MTXCOST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOST").Specific));
            this.MTXCOST.LinkPressedAfter += new SAPbouiCOM._IMatrixEvents_LinkPressedAfterEventHandler(this.MTXCOST_LinkPressedAfter);
            this.MTXBSCD = ((SAPbouiCOM.Matrix)(this.GetItem("MTXBSCD").Specific));
            //                             🔹 PictureBox
            this.PBSYIMG1 = ((SAPbouiCOM.PictureBox)(this.GetItem("PBSYIMG1").Specific));
            this.PBSYIMG1.DoubleClickBefore += new SAPbouiCOM._IPictureBoxEvents_DoubleClickBeforeEventHandler(this.PBSYIMG1_DoubleClickBefore);
            this.PBSYIMG1.DoubleClickAfter += new SAPbouiCOM._IPictureBoxEvents_DoubleClickAfterEventHandler(this.PBSYIMG1_DoubleClickAfter);
            this.PBSYIMG2 = ((SAPbouiCOM.PictureBox)(this.GetItem("PBSYIMG2").Specific));
            this.PBSYIMG2.DoubleClickBefore += new SAPbouiCOM._IPictureBoxEvents_DoubleClickBeforeEventHandler(this.PBSYIMG2_DoubleClickBefore);
            this.PBSYIMG2.DoubleClickAfter += new SAPbouiCOM._IPictureBoxEvents_DoubleClickAfterEventHandler(this.PBSYIMG2_DoubleClickAfter);
            this.PBSYIMG3 = ((SAPbouiCOM.PictureBox)(this.GetItem("PBSYIMG3").Specific));
            this.PBSYIMG3.DoubleClickBefore += new SAPbouiCOM._IPictureBoxEvents_DoubleClickBeforeEventHandler(this.PBSYIMG3_DoubleClickBefore);
            this.PBSYIMG3.DoubleClickAfter += new SAPbouiCOM._IPictureBoxEvents_DoubleClickAfterEventHandler(this.PBSYIMG3_DoubleClickAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNITMTX = ((SAPbouiCOM.Button)(this.GetItem("BTNITMTX").Specific));
            this.BTNITMTX.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNITMTX_PressedAfter);
            this.BTNITMCR = ((SAPbouiCOM.Button)(this.GetItem("BTNITMCR").Specific));
            this.BTNITMCR.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNITMCR_PressedAfter);
            this.BTNITMCR.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNITMCR_PressedBefore);
            this.LKMRCDCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKMRCDCD").Specific));
            this.OnCustomInitialize();

        }
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {

        }
        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            // Capture checkbox states for all loaded matrices
            CaptureCheckboxStates(oForm, "MTXSZTYP", "CLAPPLI", prevSztTypeCheckboxStates);
            CaptureCheckboxStates(oForm, "MTXCOLOR", "CLAPPLI", prevColorCheckboxStates);

        }

        private void BTNITMCR_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                oForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                StyleEnableButtons(ref oForm);
            }

        }

        private void MTXCOST_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOST").Specific;

            // Read cell value from the row that lost focus
            var et = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(pVal.Row).Specific;
            string cstCode = et.Value.Trim();
           
            Costing cost = new Costing();
            cost.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_COSTING");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETCSHTCD").Enabled = true;
                SAPbouiCOM.EditText CSTETXT = (SAPbouiCOM.EditText)cForm.Items.Item("ETCSHTCD").Specific;
                CSTETXT.Value = cstCode;
                cForm.Items.Item("1").Click();
                cForm.Items.Item("ETCSHTCD").Enabled = false;
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }

        }

        private void BTNITMCR_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                SAPbouiCOM.ProgressBar oProgressBar = null;
                try
                {
                    oForm.Freeze(true);

                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                    oProgressBar = Global.G_UI_Application.StatusBar.CreateProgressBar("Processing...", oMatrix.RowCount + 1, true);
                    oProgressBar.Text = "Processing...";
                    oProgressBar.Value = 0;

                    SAPbouiCOM.DBDataSource pDataSource = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMIP");
                    pDataSource.Clear();
                    oMatrix.FlushToDataSource();

                    Global.oComp.StartTransaction();

                    for (int i = pDataSource.Size - 1; i >= 0; i--)
                    {
                        string createFlag = pDataSource.GetValue("U_CreateFlag", i).Trim();
                        string updateFlag = pDataSource.GetValue("U_UpdateFlag", i).Trim();
                        string itemCode = pDataSource.GetValue("U_ItemCode", i).Trim();

                        if (createFlag == "N" && !string.IsNullOrEmpty(itemCode))
                        {
                            oProgressBar.Text = "Item Creation for " + itemCode;

                            SAPbobsCOM.Items checkItem = (SAPbobsCOM.Items)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
                            if (checkItem.GetByKey(itemCode))
                            {
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(checkItem);
                                continue;
                            }
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(checkItem);

                            SAPbobsCOM.Items newItem = (SAPbobsCOM.Items)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
                            newItem.ItemCode = itemCode;
                            newItem.ItemName = pDataSource.GetValue("U_ItemName", i).Trim();
                            newItem.InventoryItem = SAPbobsCOM.BoYesNoEnum.tYES;
                            newItem.SalesItem = SAPbobsCOM.BoYesNoEnum.tYES;
                            newItem.PurchaseItem = SAPbobsCOM.BoYesNoEnum.tYES;

                            newItem.ItemsGroupCode = Convert.ToInt32(pDataSource.GetValue("U_ItemGroup", i).Trim());
                            newItem.PlanningSystem = SAPbobsCOM.BoPlanningSystem.bop_MRP;
                            newItem.ProcurementMethod = SAPbobsCOM.BoProcurementMethod.bom_Make;
                            newItem.IssueMethod = SAPbobsCOM.BoIssueMethod.im_Manual;
                            newItem.LeadTime = Convert.ToInt32(pDataSource.GetValue("U_LeadTime", i).Trim());

                            string uom = pDataSource.GetValue("U_UoM", i).Trim();
                            newItem.SalesUnit = uom;
                            newItem.InventoryUOM = uom;
                            newItem.PurchaseUnit = uom;

                            //string defaultWhs = oForm.DataSources.DBDataSources.Item("@DTS_OPSM").GetValue("U_WhsCode", 0).Trim();
                            //newItem.DefaultWarehouse = defaultWhs;

                            newItem.ManageBatchNumbers = SAPbobsCOM.BoYesNoEnum.tYES;
                            newItem.SRIAndBatchManageMethod = SAPbobsCOM.BoManageMethod.bomm_OnEveryTransaction;

                            // User-defined fields
                            newItem.UserFields.Fields.Item("U_StyleNo").Value = pDataSource.GetValue("U_ProdSCode", i).Trim();
                            newItem.UserFields.Fields.Item("U_SizeCode").Value = pDataSource.GetValue("U_SizeCode", i).Trim();
                            newItem.UserFields.Fields.Item("U_ColourCode").Value = pDataSource.GetValue("U_ColourCode", i).Trim();
                            newItem.UserFields.Fields.Item("U_BrandCode").Value = pDataSource.GetValue("U_BrandCode", i).Trim();
                            newItem.UserFields.Fields.Item("U_SeasonCode").Value = pDataSource.GetValue("U_SeasonCode", i).Trim();
                            //newItem.UserFields.Fields.Item("U_BOMReq").Value = pDataSource.GetValue("U_BOMReq", i).Trim();
                            //newItem.UserFields.Fields.Item("U_SizeGroup").Value = pDataSource.GetValue("U_SizeGroupCode", i).Trim();
                            newItem.UserFields.Fields.Item("U_MAINFG").Value = pDataSource.GetValue("U_MAINFG", i).Trim();

                            // Price list
                            //  int priceListId = Convert.ToInt32(pDataSource.GetValue("U_PListId", i).Trim());
                            int priceListId = Convert.ToInt32(pDataSource.GetValue("U_PListId", i).Trim() == "" ? null : pDataSource.GetValue("U_PListId", i));
                            double priceValue = Convert.ToDouble(pDataSource.GetValue("U_Price", i).Trim() == "0" ? "0.01" : pDataSource.GetValue("U_Price", i).Trim());

                            for (int j = 0; j < newItem.PriceList.Count; j++)
                            {
                                newItem.PriceList.SetCurrentLine(j);
                                if (newItem.PriceList.PriceList == priceListId)
                                {
                                    newItem.PriceList.Price = priceValue;
                                    break;
                                }
                            }

                            int lRetCode = newItem.Add();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(newItem);

                            if (lRetCode != 0)
                            {
                                int errCode;
                                string errMsg;
                                Global.oComp.GetLastError(out errCode, out errMsg);
                                Global.G_UI_Application.StatusBar.SetText(errMsg, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                if (Global.oComp.InTransaction)
                                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                break;
                            }
                        }
                        else if (createFlag == "Y" && updateFlag == "Y" && !string.IsNullOrEmpty(itemCode))
                        {
                            oProgressBar.Text = "Item Update for " + itemCode;

                            SAPbobsCOM.Items existingItem = (SAPbobsCOM.Items)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
                            if (existingItem.GetByKey(itemCode))
                            {
                                existingItem.ItemName = pDataSource.GetValue("U_ItemName", i).Trim();
                                existingItem.InventoryItem = SAPbobsCOM.BoYesNoEnum.tYES;
                                existingItem.SalesItem = SAPbobsCOM.BoYesNoEnum.tYES;
                                existingItem.PurchaseItem = SAPbobsCOM.BoYesNoEnum.tYES;

                                existingItem.ItemsGroupCode = Convert.ToInt32(pDataSource.GetValue("U_ItemGroup", i).Trim());
                                existingItem.PlanningSystem = SAPbobsCOM.BoPlanningSystem.bop_MRP;
                                existingItem.ProcurementMethod = SAPbobsCOM.BoProcurementMethod.bom_Make;
                                existingItem.IssueMethod = SAPbobsCOM.BoIssueMethod.im_Manual;
                                existingItem.LeadTime = Convert.ToInt32(pDataSource.GetValue("U_LeadTime", i).Trim());

                                string uom = pDataSource.GetValue("U_UoM", i).Trim();
                                existingItem.SalesUnit = uom;
                                existingItem.InventoryUOM = uom;
                                existingItem.PurchaseUnit = uom;

                                //existingItem.DefaultWarehouse = oForm.DataSources.DBDataSources.Item("@DTS_OPSM").GetValue("U_WhsCode", 0).Trim();
                                existingItem.ManageBatchNumbers = SAPbobsCOM.BoYesNoEnum.tYES;
                                existingItem.SRIAndBatchManageMethod = SAPbobsCOM.BoManageMethod.bomm_OnEveryTransaction;

                                existingItem.UserFields.Fields.Item("U_StyleNo").Value = pDataSource.GetValue("U_ProdSCode", i).Trim();
                                existingItem.UserFields.Fields.Item("U_SizeCode").Value = pDataSource.GetValue("U_SizeCode", i).Trim();
                                existingItem.UserFields.Fields.Item("U_ColourCode").Value = pDataSource.GetValue("U_ColourCode", i).Trim();
                                existingItem.UserFields.Fields.Item("U_BrandCode").Value = pDataSource.GetValue("U_BrandCode", i).Trim();
                                existingItem.UserFields.Fields.Item("U_SeasonCode").Value = pDataSource.GetValue("U_SeasonCode", i).Trim();
                                //existingItem.UserFields.Fields.Item("U_BOMReq").Value = pDataSource.GetValue("U_BOMReq", i).Trim();
                                //existingItem.UserFields.Fields.Item("U_SizeGroup").Value = pDataSource.GetValue("U_SizeGroupCode", i).Trim();
                                existingItem.UserFields.Fields.Item("U_MAINFG").Value = pDataSource.GetValue("U_MAINFG", i).Trim();

                                // int priceListId = Convert.ToInt32(pDataSource.GetValue("U_PListId", i).Trim());

                                int priceListId = Convert.ToInt32(pDataSource.GetValue("U_PListId", i).Trim() == "" ? null : pDataSource.GetValue("U_PListId", i));
                                double priceValue = Convert.ToDouble(pDataSource.GetValue("U_Price", i).Trim() == "0" ? "0.01" : pDataSource.GetValue("U_Price", i).Trim());

                                for (int j = 0; j < existingItem.PriceList.Count; j++)
                                {
                                    existingItem.PriceList.SetCurrentLine(j);
                                    if (existingItem.PriceList.PriceList == priceListId)
                                    {
                                        existingItem.PriceList.Price = priceValue;
                                        break;
                                    }
                                }

                                int lRetCode = existingItem.Update();
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(existingItem);

                                if (lRetCode != 0)
                                {
                                    int errCode;
                                    string errMsg;
                                    Global.oComp.GetLastError(out errCode, out errMsg);
                                    Global.G_UI_Application.StatusBar.SetText(errMsg, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                    if (Global.oComp.InTransaction)
                                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                    break;
                                }
                            }
                        }
                    }

                    string qStr;
                    if (Global.oComp.DbServerType == SAPbobsCOM.BoDataServerTypes.dst_HANADB)
                    {
                        qStr = $"UPDATE \"@FIL_MR_PSMIP\" SET \"U_CreateFlag\"='Y' WHERE \"Code\"='{oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("Code", 0).Trim()}'";
                    }
                    else
                    {
                        qStr = $"UPDATE [@FIL_MR_PSMIP] SET U_CreateFlag='Y' WHERE Code='{oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("Code", 0).Trim()}'";
                    }

                    SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rSet.DoQuery(qStr);

                    oProgressBar.Value++;
                    oProgressBar.Stop();

                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                    Global.G_UI_Application.StatusBar.SetText("Successful.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                    Global.G_UI_Application.ActivateMenuItem("1304");
                    oForm.Freeze(false);
                }
                catch (Exception ex)
                {
                    if (Global.oComp.InTransaction)
                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    Global.G_UI_Application.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                    try { oProgressBar.Stop(); } catch { }
                    oForm.Freeze(false);
                }
            }


        }

        private void BTNITMTX_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
            SAPbouiCOM.DBDataSource pDS = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMIP");

            //style code
            string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLID").Specific).Value.Trim();
            // --- Query aligned with new HANA structure ---
            string qStr = $@"
            SELECT 
                ""LineId"", ""CreatedFlag"", ""U_UoM"", ""U_InvItem"", ""U_SalItem"", ""U_PurItem"", ""ProductStyleCode"",
                ""U_SAPGroup"", ""U_Brand"", ""U_ColourCode"", ""U_ColourName"",""U_SizeType"", ""U_SizeCode"", ""U_SizeName"",
                ""ItemCode"", ""ItemName"", ""U_PList"", ""ListName"", ""U_Price"", ""U_WhsCode"", ""U_LeadTime"", ""MAINFG""
            FROM (
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY A.""Code"" ASC) AS ""LineId"",
                    CASE WHEN IFNULL(F.""ItemCode"", '') = '' THEN 'N' ELSE 'Y' END AS ""CreatedFlag"", 
                    A.""U_UoM"",
                    IFNULL(A.""U_InvItem"", 'N') AS ""U_InvItem"",
                    IFNULL(A.""U_SalItem"", 'N') AS ""U_SalItem"",
                    IFNULL(A.""U_PurItem"", 'N') AS ""U_PurItem"",
                    A.""Code"" AS ""ProductStyleCode"",
                    A.""U_SAPGroup"", A.""U_Brand"", 
                    C.""U_ColourCode"", C.""U_ColourName"", C.""U_OthName"",
                    D.""U_SizeCode"", D.""U_SizeName"",D.""U_SizeType"",
                    LEFT(A.""Code"", B.""U_PRODUCT"") ||
                        CASE WHEN IFNULL(B.""U_COLRACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(C.""U_ColourCode"", B.""U_COLOUR"") ELSE '' END ||
                        CASE WHEN IFNULL(B.""U_SIZEACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(D.""U_SizeCode"", B.""U_SIZE"") ELSE '' END AS ""ItemCode"",
                    A.""Name"" ||
                        CASE WHEN IFNULL(B.""U_COLRACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(C.""U_ColourName"", B.""U_COLOUR"") || IFNULL(B.""U_SEPARATOR"" || C.""U_OthName"", '') ELSE '' END ||
                        CASE WHEN IFNULL(B.""U_SIZEACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(D.""U_SizeName"", B.""U_SIZE"") END AS ""ItemName"",
                    A.""U_PList"", E.""ListName"", A.""U_Price"",
                    CASE 
                        WHEN IFNULL(A.""U_PurItem"", 'N') = 'Y' 
                             AND (IFNULL(A.""U_SalItem"", 'N') = 'N' OR IFNULL(A.""U_SalItem"", 'N') = '') 
                        THEN A.""U_WhsPrCode"" 
                        ELSE A.""U_WhsCode"" 
                    END AS ""U_WhsCode"",
                    A.""U_LeadTime"",
                    'Y' AS ""MAINFG""
                FROM ""@FIL_MH_OPSM"" A
                INNER JOIN ""@FIL_MH_OSGM"" B 
                    ON B.""Code"" = (SELECT ""Code"" FROM ""@FIL_MH_OSGM"" LIMIT 1)
                LEFT OUTER JOIN ""@FIL_MR_PSMCO"" C 
                    ON A.""Code"" = C.""Code"" 
                    AND IFNULL(B.""U_COLRACTE"", 'N') = 'Y' 
                    AND IFNULL(C.""U_ColourAppl"", 'N') = 'Y'
                LEFT OUTER JOIN ""@FIL_MR_PSMST"" D 
                    ON A.""Code"" = D.""Code"" 
                    AND IFNULL(B.""U_SIZEACTE"", 'N') = 'Y'  
                    AND IFNULL(D.""U_SizeAppl"", 'N') = 'Y'
                LEFT OUTER JOIN ""OITM"" F 
                    ON A.""Code"" = F.""U_StyleNo"" 
                    AND LEFT(A.""Code"", B.""U_PRODUCT"") ||
                        CASE WHEN IFNULL(B.""U_COLRACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(C.""U_ColourCode"", B.""U_COLOUR"") ELSE '' END ||
                        CASE WHEN IFNULL(B.""U_SIZEACTE"", 'N') = 'Y' THEN B.""U_SEPARATOR"" || LEFT(D.""U_SizeCode"", B.""U_SIZE"") ELSE '' END
                        = F.""ItemCode""
                LEFT JOIN ""OPLN"" E 
                    ON A.""U_PList"" = E.""ListNum""
                WHERE A.""Code"" = '{styleCode}'
            ) V1
            ORDER BY ""ItemCode""";

           

            oForm.Freeze(true);
            try
            {
                oRS.DoQuery(qStr);

                // --- Clear previous data ---
                pDS.Clear();
                oMatrix.Clear();
                oMatrix.LoadFromDataSource();

                // --- Populate from recordset ---
                while (!oRS.EoF)
                {
                    pDS.InsertRecord(pDS.Size);
                    pDS.Offset = pDS.Size - 1;

                    pDS.SetValue("LineId", pDS.Offset, (pDS.Offset + 1).ToString());
                    pDS.SetValue("U_CreateFlag", pDS.Offset, oRS.Fields.Item("CreatedFlag").Value.ToString());
                    pDS.SetValue("U_ProdSCode", pDS.Offset, oRS.Fields.Item("ProductStyleCode").Value.ToString());
                    pDS.SetValue("U_ItemGroup", pDS.Offset, oRS.Fields.Item("U_SAPGroup").Value.ToString());
                    pDS.SetValue("U_UoM", pDS.Offset, oRS.Fields.Item("U_UoM").Value.ToString());
                    pDS.SetValue("U_InvItem", pDS.Offset, oRS.Fields.Item("U_InvItem").Value.ToString());
                    pDS.SetValue("U_SalItem", pDS.Offset, oRS.Fields.Item("U_SalItem").Value.ToString());
                    pDS.SetValue("U_PurItem", pDS.Offset, oRS.Fields.Item("U_PurItem").Value.ToString());
                    pDS.SetValue("U_ColourCode", pDS.Offset, oRS.Fields.Item("U_ColourCode").Value.ToString());
                    pDS.SetValue("U_ColourName", pDS.Offset, oRS.Fields.Item("U_ColourName").Value.ToString());
                    pDS.SetValue("U_SizeType", pDS.Offset, oRS.Fields.Item("U_SizeType").Value.ToString());
                    pDS.SetValue("U_SizeCode", pDS.Offset, oRS.Fields.Item("U_SizeCode").Value.ToString());
                    pDS.SetValue("U_SizeName", pDS.Offset, oRS.Fields.Item("U_SizeName").Value.ToString());
                    pDS.SetValue("U_BrandCode", pDS.Offset, oRS.Fields.Item("U_Brand").Value.ToString());
                    pDS.SetValue("U_ItemCode", pDS.Offset, oRS.Fields.Item("ItemCode").Value.ToString());
                    pDS.SetValue("U_ItemName", pDS.Offset, oRS.Fields.Item("ItemName").Value.ToString());
                    pDS.SetValue("U_LeadTime", pDS.Offset, oRS.Fields.Item("U_LeadTime").Value.ToString());
                    // pDS.SetValue("U_WhsCode", pDS.Offset, oRS.Fields.Item("U_WhsCode").Value.ToString());
                    pDS.SetValue("U_PListId", pDS.Offset, oRS.Fields.Item("U_PList").Value.ToString());
                    pDS.SetValue("U_ListName", pDS.Offset, oRS.Fields.Item("ListName").Value.ToString());
                    pDS.SetValue("U_Price", pDS.Offset, oRS.Fields.Item("U_Price").Value.ToString());
                    pDS.SetValue("U_MAINFG", pDS.Offset, oRS.Fields.Item("MAINFG").Value.ToString());

                    oRS.MoveNext();
                }

                // --- Refresh matrix ---
                oMatrix.LoadFromDataSource();
                oMatrix.AutoResizeColumns();

                // --- Example: toggle editable state based on checkbox (if exists) ---
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLUPDATE").Cells.Item(i).Specific;
                    oMatrix.CommonSetting.SetCellEditable(i, 1, chk.Checked);
                }

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
                    
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }
        // 🔹 Global storage for both matrices’ previous checkbox states
        private Dictionary<int, bool> prevSztTypeCheckboxStates = new Dictionary<int, bool>();
        private Dictionary<int, bool> prevColorCheckboxStates = new Dictionary<int, bool>();




        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                oForm.Freeze(true);
                SAPbouiCOM.EditText oStyleId = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLID").Specific;
                oForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                oForm.Items.Item("ETSTYLID").Enabled = true;
                oStyleId.Value = styleCode;
                oForm.Items.Item("1").Click(); 
                oForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                StyleEnableButtons(ref oForm);

                // Add new row if last row has data
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                int lastRow = oMatrix.RowCount;
                bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific).Value);
                if (lastRowHasData)
                {
                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                }

                oForm.Freeze(false);


            }
            else if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE ||
                oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                // Switch to OK mode
                oForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;

                // Disable StyleId field
                SAPbouiCOM.Item oStyleId = oForm.Items.Item("ETSTYLID");
                if (oStyleId.Enabled)
                    oStyleId.Enabled = false;

                // Add new row if last row has data
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                int lastRow = oMatrix.RowCount;
                bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific).Value);
                if (lastRowHasData)
                {
                    Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                }

                // Enable/disable other buttons based on matrix
                StyleEnableButtons(ref oForm);


                // --- Only check for changes if we already had previous states ---
                bool newCheckedInSztType = false;
                bool newCheckedInColor = false;

                //prev  okay code
                //if (prevSztTypeCheckboxStates.Count > 0)
                //    newCheckedInSztType = HasNewCheckboxSelections(oForm, "MTXSZTYP", "CLAPPLI", prevSztTypeCheckboxStates);

                //if (prevColorCheckboxStates.Count > 0)
                //    newCheckedInColor = HasNewCheckboxSelections(oForm, "MTXCOLOR", "CLAPPLI", prevColorCheckboxStates);


                if (prevSztTypeCheckboxStates.Count > 0)
                    newCheckedInSztType = HasCheckboxChanges(oForm, "MTXSZTYP", "CLAPPLI", prevSztTypeCheckboxStates);

                if (prevColorCheckboxStates.Count > 0)
                    newCheckedInColor = HasCheckboxChanges(oForm, "MTXCOLOR", "CLAPPLI", prevColorCheckboxStates);

                if (newCheckedInSztType || newCheckedInColor)
                {
                    SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                    oBtnItmTx.Enabled = true;

                    Application.SBO_Application.StatusBar.SetText(
                        "Detected new checked rows in matrix — BTNITMTX enabled.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success
                    );
                }
                else
                {
                    // 🔒 Disable if no new checks
                    SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                    oBtnItmTx.Enabled = false;
                }

                // --- Always refresh states AFTER processing ---
                CaptureCheckboxStates(oForm, "MTXSZTYP", "CLAPPLI", prevSztTypeCheckboxStates);
                CaptureCheckboxStates(oForm, "MTXCOLOR", "CLAPPLI", prevColorCheckboxStates);
            }
        }


        // --- Generic reusable method to store checkbox states ---
        private void CaptureCheckboxStates(SAPbouiCOM.Form oForm, string matrixId, string columnId, Dictionary<int, bool> targetDict)
        {
            try
            {
                targetDict.Clear();
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item(columnId).Cells.Item(i).Specific;
                    targetDict[i] = chk.Checked;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText($"Error capturing states for {matrixId}: {ex.Message}",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        //prev okay code 
        //// --- Generic reusable method to detect new selections ---
        //private bool HasNewCheckboxSelections(SAPbouiCOM.Form oForm, string matrixId, string columnId, Dictionary<int, bool> prevStates)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

        //        for (int i = 1; i <= oMatrix.RowCount; i++)
        //        {
        //            SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item(columnId).Cells.Item(i).Specific;
        //            bool prevState = prevStates.ContainsKey(i) ? prevStates[i] : false;

        //            if (!prevState && chk.Checked)
        //                return true; // Found a new checked row
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            $"Error checking new selections for {matrixId}: {ex.Message}",
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }

        //    return false;
        //}

        // --- Generic reusable method to detect changes (check/uncheck) ---
        private bool HasCheckboxChanges(SAPbouiCOM.Form oForm, string matrixId, string columnId, Dictionary<int, bool> prevStates)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item(columnId).Cells.Item(i).Specific;
                    bool prevState = prevStates.ContainsKey(i) ? prevStates[i] : false;

                    // Detect any change: checked → unchecked OR unchecked → checked
                    if (chk.Checked != prevState)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    $"Error checking checkbox changes for {matrixId}: {ex.Message}",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

            return false;
        }



        private void StyleEnableButtons(ref SAPbouiCOM.Form oForm)
        {
            try
            {
                // Only run in VIEW or OK mode
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_VIEW_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                SAPbouiCOM.EditText oStyleId = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLID").Specific;
                string styleId = oStyleId.Value.Trim();

                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");

                bool matrixEmpty = false;

                // --- Check if matrix is empty or has only 1 blank row ---
                if (oMatrix.RowCount == 0 || oMatrix.VisualRowCount == 0)
                {
                    matrixEmpty = true;
                }
                else if (oMatrix.RowCount == 1)
                {
                    SAPbouiCOM.EditText cell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPDSYCD").Cells.Item(1).Specific;
                    if (string.IsNullOrEmpty(cell.Value.Trim()))
                        matrixEmpty = true;
                }

                // --- Case 1: Matrix empty or one blank row ---
                if (matrixEmpty)
                {
                    oBtnItmTx.Enabled = !string.IsNullOrEmpty(styleId);
                    oBtnItmCr.Enabled = false;
                    return;
                }

                // --- Case 2: Matrix has data ---
                oBtnItmTx.Enabled = false;

                bool enableBtnItmCr = false;

                // 1️⃣ Check DB only if StyleID is not empty
                if (!string.IsNullOrEmpty(styleId))
                {
                    SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    string query = $"SELECT 1 FROM \"@FIL_MR_PSMIP\" WHERE \"Code\" = '{styleId}'";
                    oRec.DoQuery(query);

                    enableBtnItmCr = !oRec.EoF; // True if record exists
                }

                // 2️⃣ Check if all checkboxes in CLCREAT column are checked
                bool allChecked = true;
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLCREAT").Cells.Item(i).Specific;
                    if (!chk.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Final decision for BTNITMCR
                oBtnItmCr.Enabled = enableBtnItmCr && !allChecked;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in StyleEnableButtons: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
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
            styleCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("Code", 0);
            string brand = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_Brand", 0);
            string type = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_PRDTPCD", 0);
            string line = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_PrdLine", 0);
            string grp = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_PrGroup", 0);
            string cat = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_PrCateg", 0);
            string sizeType = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_SizeType", 0); 
            string sapGroup = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_SAPGroup", 0); 
            string route = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_RSTemp", 0); 
            string plist = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM").GetValue("U_PList", 0); 
            if (brand == "")
            {
                Global.GFunc.ShowError("Enter Brand Code");
                oForm.ActiveItem = "ETBRNDCD";
                return BubbleEvent = false;
            }
            else if (type == "")
            {
                Global.GFunc.ShowError("Enter Product Type");
                oForm.ActiveItem = "ETPDTYCD";
                return BubbleEvent = false;
            }
            else if (line == "")
            {
                Global.GFunc.ShowError("Enter Product Line");
                oForm.ActiveItem = "ETPDLNCD";
                return BubbleEvent = false;
            }
            else if (grp == "")
            {
                Global.GFunc.ShowError("Enter Product Group");
                oForm.ActiveItem = "ETPDGPCD";
                return BubbleEvent = false;
            }
            else if (cat == "")
            {
                Global.GFunc.ShowError("Enter Product Category");
                oForm.ActiveItem = "ETPDCYCD";
                return BubbleEvent = false;
            }
            else if (sizeType == "")
            {
                Global.GFunc.ShowError("Enter Size Type");
                oForm.ActiveItem = "ETSZTYCD";
                return BubbleEvent = false;
            }
            //else if (plist == "")
            //{
            //    Global.GFunc.ShowError("Select Price List ");
            //    oForm.ActiveItem = "CBPRCLST";
            //    return BubbleEvent = false;
            //}
            else if (sapGroup == "")
            {
                Global.GFunc.ShowError("Enter SAP Group");
                oForm.ActiveItem = "ETSGRPCD";
                return BubbleEvent = false;
            }
            else if (route == "")
            {
                Global.GFunc.ShowError("Enter Route Stage");
                oForm.ActiveItem = "ETRTSGCD";
                return BubbleEvent = false;
            }
            // Preventing Empty Row to Add in the DB for MTXSZTYP (SizeType)
            SAPbouiCOM.DBDataSource oDBDetail = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMST");
            int rowCount = MTXSZTYP.VisualRowCount;
            if (rowCount > 0)
            {
                string lastdocentry = oDBDetail.GetValue("U_SizeType", rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXSZTYP.DeleteRow(rowCount);
                    oDBDetail.RemoveRecord(rowCount - 1);
                    rowCount--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXCOLOR (Colour)
            SAPbouiCOM.DBDataSource oDBDetail2 = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
            int rowCount2 = MTXCOLOR.VisualRowCount;
            if (rowCount2 > 0)
            {
                string lastdocentry = oDBDetail2.GetValue("U_ColourCode", rowCount2 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXCOLOR.DeleteRow(rowCount2);
                    oDBDetail2.RemoveRecord(rowCount2 - 1);
                    rowCount2--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXDSCLR (SubColour)
            SAPbouiCOM.DBDataSource oDBDetail3 = oForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
            int rowCount3 = MTXDSCLR.VisualRowCount;
            if (rowCount3 > 0)
            {
                string lastdocentry = oDBDetail3.GetValue("U_CLRCODE", rowCount3 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXDSCLR.DeleteRow(rowCount3);
                    oDBDetail3.RemoveRecord(rowCount3 - 1);
                    rowCount3--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXITEM (item Matrix)
            SAPbouiCOM.DBDataSource oDBDetail4 = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMIP");
            int rowCount4 = MTXITEM.VisualRowCount;
            if (rowCount4 > 0)
            {
                string lastdocentry = oDBDetail4.GetValue("U_ProdSCode", rowCount4 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXITEM.DeleteRow(rowCount4);
                    oDBDetail4.RemoveRecord(rowCount4 - 1);
                    rowCount4--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXCOST (cost sheet Matrix)
            SAPbouiCOM.DBDataSource oDBDetail5 = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCS");
            int rowCount5 = MTXCOST.VisualRowCount;
            if (rowCount5 > 0)
            {
                string lastdocentry = oDBDetail5.GetValue("U_Code", rowCount5 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXCOST.DeleteRow(rowCount5);
                    oDBDetail5.RemoveRecord(rowCount5 - 1);
                    rowCount5--;  // Adjust row count after deletion
                }
            }

            // Preventing Empty Row to Add in the DB for MTXCOST (cost sheet Matrix)
            SAPbouiCOM.DBDataSource oDBDetail6 = oForm.DataSources.DBDataSources.Item("@FIL_MR_BUYRSCD");
            int rowCount6 = MTXBSCD.VisualRowCount;
            if (rowCount6 > 0)
            {
                string lastdocentry = oDBDetail6.GetValue("U_BUYRSTCD", rowCount6 - 1).Trim();
                if (string.IsNullOrEmpty(lastdocentry))
                {
                    MTXBSCD.DeleteRow(rowCount6);
                    oDBDetail6.RemoveRecord(rowCount6 - 1);
                    rowCount6--;  // Adjust row count after deletion
                }
            }
            return BubbleEvent;
        }

        private void MTXCOLOR_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                // --- Ensure valid item and row ---
                if (pVal.ItemUID != "MTXCOLOR" || pVal.Row <= 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;

                // --- Get selected row values from parent matrix ---
                string lineId = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(pVal.Row).Specific).Value;
                string clCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(pVal.Row).Specific).Value;
                string clName = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLNAME").Cells.Item(pVal.Row).Specific).Value;
                string pantone = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPANTON").Cells.Item(pVal.Row).Specific).Value;

                // --- Open SubColor form ---
                SubColor subForm = new SubColor();
                subForm.Show();

                SAPbouiCOM.Form oSubForm = Application.SBO_Application.Forms.Item("FIL_FRM_SUBCLR");

                // --- Pass parent info to SubColor form ---
                oSubForm.DataSources.UserDataSources.Item("UDPARENT").ValueEx = pVal.FormUID;
                oSubForm.DataSources.UserDataSources.Item("UDBSLINE").ValueEx = lineId;
                oSubForm.DataSources.UserDataSources.Item("UDCLCODE").ValueEx = clCode;
                oSubForm.DataSources.UserDataSources.Item("UDCLNAME").ValueEx = clName;
                oSubForm.DataSources.UserDataSources.Item("UDCLPANT").ValueEx = pantone;

                oSubForm.Freeze(true);

                // --- Prepare subform matrix and datasource ---
                SAPbouiCOM.Matrix subMatrix = (SAPbouiCOM.Matrix)oSubForm.Items.Item("MTXSBCLR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oSubForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");

                // --- Get parent’s sub-detail datasource ---
                SAPbouiCOM.Matrix parentSubMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXDSCLR").Specific;
                SAPbouiCOM.DBDataSource parentSubDS = oForm.DataSources.DBDataSources.Item("@FIL_MR_SUBCLR");
                parentSubMatrix.FlushToDataSource();

                // --- Always clear subform datasource before reloading ---
                DBDataSourceLine.Clear();
                subMatrix.Clear();

                bool dataExists = false;

                // --- Check for existing sub-color data for this line ---
                for (int i = 0; i < parentSubDS.Size; i++)
                {
                    string baseLineVal = parentSubDS.GetValue("U_BASELINE", i).Trim();
                    string colorCode = parentSubDS.GetValue("U_CLRCODE", i).Trim();
                    string colorName = parentSubDS.GetValue("U_CLRNAME", i).Trim();
                    string posVal = parentSubDS.GetValue("U_POSITION", i).Trim();
                    string pantoneVal = parentSubDS.GetValue("U_PANTONE", i).Trim();
                    
                    if (baseLineVal == lineId)
                    {
                        int newRow = DBDataSourceLine.Size;
                        DBDataSourceLine.InsertRecord(newRow);
                        
                        DBDataSourceLine.SetValue("LineId", newRow, lineId);
                        DBDataSourceLine.SetValue("U_BASELINE", newRow, baseLineVal);
                        DBDataSourceLine.SetValue("U_CLRCODE", newRow, colorCode);
                        DBDataSourceLine.SetValue("U_CLRNAME", newRow, colorName);
                        DBDataSourceLine.SetValue("U_POSITION", newRow, posVal);
                        DBDataSourceLine.SetValue("U_PANTONE", newRow, pantoneVal);

                        dataExists = true;
                    }
                }

                // --- If no data exists, create a new sub-color line ---
                if (!dataExists)
                {
                    // --- Validation: ensure parent row is not blank ---
                    if (string.IsNullOrWhiteSpace(clCode) &&
                        string.IsNullOrWhiteSpace(clName) &&
                        string.IsNullOrWhiteSpace(pantone))
                    {
                        Application.SBO_Application.StatusBar.SetText(
                            "Parent row is blank — subcolor cannot be created.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    }
                    else
                    {
                        int newRow = DBDataSourceLine.Size;
                        DBDataSourceLine.InsertRecord(newRow);
                        DBDataSourceLine.SetValue("LineId", newRow, lineId);
                        DBDataSourceLine.SetValue("U_BASELINE", newRow, lineId);
                        DBDataSourceLine.SetValue("U_CLRCODE", newRow, clCode);
                        DBDataSourceLine.SetValue("U_CLRNAME", newRow, clName);
                        DBDataSourceLine.SetValue("U_PANTONE", newRow, pantone);
                    }
                }
                else
                {
                    // --- Add one blank row for new sub-color entry ---
                    int newRow = DBDataSourceLine.Size;
                    DBDataSourceLine.InsertRecord(newRow);
                    // Optional: initialize blank values
                    DBDataSourceLine.SetValue("U_BASELINE", newRow, lineId);
                    DBDataSourceLine.SetValue("U_CLRCODE", newRow, "");
                    DBDataSourceLine.SetValue("U_CLRNAME", newRow, "");
                    DBDataSourceLine.SetValue("U_PANTONE", newRow, "");
                }


                // --- Refresh sub-matrix ---
                subMatrix.LoadFromDataSource();
                subMatrix.AutoResizeColumns();
                oSubForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in MTXCOLOR_DoubleClickAfter: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }


        private void MTXCOLOR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                if (cflArg.SelectedObjects == null) return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                SAPbouiCOM.DBDataSource dBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count <= 0) return;

                string code = oDataTable.GetValue("Code", 0).ToString().Trim();
                string name = oDataTable.GetValue("Name", 0).ToString().Trim();
                string pantone = oDataTable.GetValue("U_PANTONE", 0).ToString().Trim();
                int row = pVal.Row;

                // Duplicate check
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    if (i == row) continue;

                    string existingCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(i).Specific).Value.Trim();

                    if (existingCode.Equals(code, StringComparison.OrdinalIgnoreCase))
                    {
                        // Current row clear
                        oMatrix.SetCellWithoutValidation(row, "CLCODE", "");
                        oMatrix.SetCellWithoutValidation(row, "CLNAME", "");
                        oMatrix.SetCellWithoutValidation(row, "CLPANTON", "");
                        oMatrix.FlushToDataSource();

                        Application.SBO_Application.StatusBar.SetText("Duplicate color code is not allowed.",SAPbouiCOM.BoMessageTime.bmt_Short,SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                        return;
                    }
                }

                // Set values
                oMatrix.SetCellWithoutValidation(row, "CLCODE", code);
                oMatrix.SetCellWithoutValidation(row, "CLNAME", name);
                oMatrix.SetCellWithoutValidation(row, "CLPANTON", pantone);
                oMatrix.FlushToDataSource();

                // Add new row if last row has data
                int lastRow = oMatrix.RowCount;
                bool lastRowHasData = !string.IsNullOrWhiteSpace(
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific).Value);

                if (row == lastRow && lastRowHasData)
                {
                    Global.GFunc.SetNewLine(oMatrix, dBDataSourceLine, 1, "");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Color Matrix CFL Error: " + ex.Message,SAPbouiCOM.BoMessageTime.bmt_Short,SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        //private void MTXCOLOR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
        //        SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
        //        SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

        //        if (oDataTable.Rows.Count > 0)
        //        {
        //            string code = oDataTable.GetValue("Code", 0).ToString();
        //            string name = oDataTable.GetValue("Name", 0).ToString();
        //            string pantone = oDataTable.GetValue("U_PANTONE", 0).ToString();
        //            int row = pVal.Row; // matrix row where CFL triggered
        //            //Set Values
        //            oMatrix.SetCellWithoutValidation(row, "CLCODE", code);
        //            oMatrix.SetCellWithoutValidation(row, "CLNAME", name);
        //            oMatrix.SetCellWithoutValidation(row, "CLPANTON", pantone);
        //            //oMatrix.SetCellWithoutValidation(row, "CLAPPLI", "Y"); //auto select
        //            oMatrix.FlushToDataSource();
        //            // Add new row if last row has data
        //            int lastRow = oMatrix.RowCount;
        //            bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(lastRow).Specific).Value);

        //            if (pVal.Row == lastRow && lastRowHasData)
        //            {
        //                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText("Color Matrix CFL Error: " + ex.Message,
        //           SAPbouiCOM.BoMessageTime.bmt_Short,
        //           SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }

        //}

        private void ETSZTYCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OSTM")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.EditText ETPDTYCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTYCD").Specific;
                    string typeValue = ETPDTYCD.Value;

                    SAPbouiCOM.EditText ETPDLNCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNCD").Specific;
                    string genValue = ETPDLNCD.Value;


                    SAPbouiCOM.EditText ETPDGPCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific;
                    string grpValue = ETPDGPCD.Value;

                    SAPbouiCOM.EditText ETPDCYCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDCYCD").Specific;
                    string catValue = ETPDCYCD.Value;


                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_CATEGORY";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = catValue.Trim();
                    oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon2 = oCons.Add();
                    oCon2.Alias = "U_PRDTYPE";
                    oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon2.CondVal = typeValue.Trim();
                    oCon2.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon3 = oCons.Add();
                    oCon3.Alias = "U_PRDLINE";
                    oCon3.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon3.CondVal = genValue.Trim();
                    oCon3.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;


                    SAPbouiCOM.Condition oCon4 = oCons.Add();
                    oCon4.Alias = "U_PRDGRP";
                    oCon4.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon4.CondVal = grpValue.Trim();
                   

                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }
        private void ETSZTYCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                string Code = dt.GetValue("Code", 0).ToString().Trim();

                // Set the selected code in EditText
                SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSZTYCD").Specific;
                ETCD.Value = Code;

                // Get matrix
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSZTYP").Specific;
                SAPbouiCOM.DBDataSource oDS = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMST");

                // Clear previous data
                oDS.Clear();
                oMatrix.Clear();

                // Fetch SQL data
                string sql = $"SELECT \"Code\", \"LineId\", \"U_SizeCode\", \"U_SizeName\" FROM \"@FIL_MR_STM1\" WHERE \"Code\" = '{Code}'";

                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRS.DoQuery(sql);

                int row = 0;
                while (!oRS.EoF)
                {
                    oDS.InsertRecord(row);

                    oDS.SetValue("LineId", row, oRS.Fields.Item("LineId").Value.ToString());
                    oDS.SetValue("U_SizeType", row, oRS.Fields.Item("Code").Value.ToString());
                    oDS.SetValue("U_SizeCode", row, oRS.Fields.Item("U_SizeCode").Value.ToString());
                    oDS.SetValue("U_SizeName", row, oRS.Fields.Item("U_SizeName").Value.ToString());
                    //oDS.SetValue("U_SizeAppl", row, "Y"); // Auto-select checkbox

                    row++;
                    oRS.MoveNext();
                }

                // Load to Matrix
                oMatrix.LoadFromDataSource();
                // Optional: Auto-resize columns
                oMatrix.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
        }





        private void ETRTSGCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETRTSGCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETRTSGNM").Specific;
            ETNM.Value = Name;
        }
        private void ETSGRPCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;
                
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
               
                SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                SAPbouiCOM.Condition oCon = oCons.Add();
                oCon.Alias = "U_ITMSGRPTP";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "FG";
                oCFL.SetConditions(oCons);
                
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

        private void ETSGRPCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("ItmsGrpCod", 0).ToString().Trim();
            string Name = dt.GetValue("ItmsGrpNam", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSGRPCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETSGRPNM").Specific;
            ETNM.Value = Name;

        }

        private void ETUOM_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("UomCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETUOM").Specific;
            ETCD.Value = Code;

        }

        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETCD.Value = Code;

        }

        private void ETMRCDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("empID", 0).ToString().Trim();
            string Name = dt.GetValue("U_FNAME", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETMRCDCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETMRCDNM").Specific;
            ETNM.Value = Name;


        }

        private void ETSLTYCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSLTYCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETSLTYNM").Specific;
            ETNM.Value = Name;

        }
        private void ETPDGPCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_GRP")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.EditText ETPDLNCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNCD").Specific;
                    string genValue = ETPDLNCD.Value;

                    SAPbouiCOM.EditText ETPDTYCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTYCD").Specific;
                    string typeValue = ETPDTYCD.Value;

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_PRDTYPE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = typeValue.Trim();
                    oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon2 = oCons.Add();
                    oCon2.Alias = "U_PRDLINE";
                    oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon2.CondVal = genValue.Trim();
                    oCon2.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon3 = oCons.Add();
                    oCon3.Alias = "U_ACTIVE";
                    oCon3.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon3.CondVal = "Y";
                    

                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }
        }


        private void ETPDTYCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTYCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTYNM").Specific;
            ETNM.Value = Name;

            SAPbouiCOM.Item oItem = oForm.Items.Item("ETPDLNCD");
            oItem.Enabled = true;

            //Reattach CFL after enabling
            SAPbouiCOM.EditText ETDLNCD = (SAPbouiCOM.EditText)oItem.Specific;
            ETDLNCD.ChooseFromListUID = "CFL_LINE";  // your CFL UID here
            ETDLNCD.ChooseFromListAlias = "Code";

        }
        private void ETPDCYCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_PCAT")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.EditText ETPDGPCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific;
                    string grpValue = ETPDGPCD.Value;


                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_PRDGRP";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = grpValue.Trim();
                    oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon2 = oCons.Add();
                    oCon2.Alias = "U_ACTIVE";
                    oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon2.CondVal = "Y";


                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETSLTYCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_STYPE")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETPDLNCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_LINE")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETPDTYCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_PTYPE")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETPDCYCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDCYCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDCYNM").Specific;
            ETNM.Value = Name;

        }

        private void ETPDGPCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPNM").Specific;
            ETNM.Value = Name;

            SAPbouiCOM.Item oItem = oForm.Items.Item("ETPDCYCD");
            oItem.Enabled = true;

            //Reattach CFL after enabling
            SAPbouiCOM.EditText ETDLNCD = (SAPbouiCOM.EditText)oItem.Specific;
            ETDLNCD.ChooseFromListUID = "CFL_PCAT";  // your CFL UID here
            ETDLNCD.ChooseFromListAlias = "Code";

        }

        private void ETPDLNCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNCD").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNNM").Specific;
            ETNM.Value = Name;

            SAPbouiCOM.Item oItem = oForm.Items.Item("ETPDGPCD");
            oItem.Enabled = true;

            //Reattach CFL after enabling
            SAPbouiCOM.EditText ETPDGPCD = (SAPbouiCOM.EditText)oItem.Specific;
            ETPDGPCD.ChooseFromListUID = "CFL_GRP";  // your CFL UID here
            ETPDGPCD.ChooseFromListAlias = "Code";

        }

        private void ETDEPTCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DEPT")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETDEPTCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            SAPbouiCOM.EditText ETDEPTCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETDEPTCD").Specific;
            ETDEPTCD.Value = Code;
            SAPbouiCOM.EditText ETDEPTNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETDEPTNM").Specific;
            ETDEPTNM.Value = Name;

        }
        private void ETBRNDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OBRM")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }

        private void ETBRNDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
            //Size Type Matrix On
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSZTYP").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMST");
            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
            }
            //Colour  Matrix On
            SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine2 = oForm.DataSources.DBDataSources.Item("@FIL_MR_PSMCO");
            int lastRow2 = oMatrix2.RowCount;
            if (lastRow2 == 0)
            {
                Global.GFunc.SetNewLine(oMatrix2, DBDataSourceLine2, 1, "");
            }
        }
        private void PBSYIMG1_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG1").Specific;

                // Clear current image so user can reselect
                ds.SetValue("U_Image", 0, "");
                pic.Picture = "";
                oForm.Update();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error before image browse: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void PBSYIMG1_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG1").Specific;

                string fileName = (ds.GetValue("U_Image", 0) ?? "").Trim();
                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string networkFolder = @"\\192.168.162.215\Shared\Attachment";
                string networkFilePath = System.IO.Path.Combine(networkFolder, fileName);

                // Connect to network share
                string username = @"Administrator";
                string password = "Fu1@#sion";
                NetworkShareHelper.ConnectToShare(networkFolder, username, password);

                // If file exists in network, show it
                if (System.IO.File.Exists(networkFilePath))
                {
                    // Clear first so same image can reload
                    pic.Picture = "";
                    System.Windows.Forms.Application.DoEvents();

                    pic.Picture = networkFilePath;

                    Application.SBO_Application.StatusBar.SetText(
                        "Image 1 displayed successfully.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Selected image 1 not found in network folder: " + networkFilePath,
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
        }

        private void PBSYIMG3_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG3").Specific;

                // Clear current image so user can reselect
                ds.SetValue("U_IMAGE3", 0, "");
                pic.Picture = "";
                oForm.Update();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error before Image 3 browse: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }


        private void PBSYIMG3_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG3").Specific;

                string fileName = (ds.GetValue("U_IMAGE3", 0) ?? "").Trim();
                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string networkFolder = @"\\192.168.162.215\Shared\Attachment";
                string networkFilePath = System.IO.Path.Combine(networkFolder, fileName);

                // Connect to network share
                string username = @"Administrator";
                string password = "Fu1@#sion";
                NetworkShareHelper.ConnectToShare(networkFolder, username, password);

                // If file exists in network, show it
                if (System.IO.File.Exists(networkFilePath))
                {
                    // Clear first so same image can reload
                    pic.Picture = "";
                    System.Windows.Forms.Application.DoEvents();

                    pic.Picture = networkFilePath;

                    Application.SBO_Application.StatusBar.SetText(
                        "Image 3 displayed successfully.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Selected image 3 not found in network folder: " + networkFilePath,
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }

        }

        private void PBSYIMG2_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG2").Specific;

                // Clear current image so user can reselect
                ds.SetValue("U_IMAGE2", 0, "");
                pic.Picture = "";
                oForm.Update();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error before Image 3 browse: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }
        private void PBSYIMG2_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_MH_OPSM");
                SAPbouiCOM.PictureBox pic = (SAPbouiCOM.PictureBox)oForm.Items.Item("PBSYIMG2").Specific;

                string fileName = (ds.GetValue("U_IMAGE2", 0) ?? "").Trim();
                if (string.IsNullOrWhiteSpace(fileName))
                    return;

                string networkFolder = @"\\192.168.162.215\Shared\Attachment";
                string networkFilePath = System.IO.Path.Combine(networkFolder, fileName);

                // Connect to network share
                string username = @"Administrator";
                string password = "Fu1@#sion";
                NetworkShareHelper.ConnectToShare(networkFolder, username, password);

                // If file exists in network, show it
                if (System.IO.File.Exists(networkFilePath))
                {
                    // Clear first so same image can reload
                    pic.Picture = "";
                    System.Windows.Forms.Application.DoEvents();

                    pic.Picture = networkFilePath;

                    Application.SBO_Application.StatusBar.SetText(
                        "Image 2 displayed successfully.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Selected Image 2 not found in network folder: " + networkFilePath,
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }

        }
    }
}
