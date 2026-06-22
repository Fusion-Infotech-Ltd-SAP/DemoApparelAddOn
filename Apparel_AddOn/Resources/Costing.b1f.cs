using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;
using System.Globalization;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.Costing", "Resources/Costing.b1f")]
    class Costing : UserFormBase
    {
        public Costing()
        {
        }
        // StaticText
        private SAPbouiCOM.StaticText STSTYLCD, STSTYLDS, STCUSCOD, STCURR, STCSHTCD, STCSHTDS,
            STCADNO, STDRFTSO, STUOM, STOTLQTY, STVERSON, STITMGRP, STOHCSCD, STRTSGCD, STRUTCST,
            STOTLPRC, STFABCST, STTRMCST, STPRICST, STOVHCST, STCALCM, STOTHCST, STOTLCST, STACPFPR,
            STOFRFOB, STCLPRFT, STSLPRIC, STCPRFTP, STNDPRFT;




        // EditText
        private SAPbouiCOM.EditText ETSTYLCD, ETSTYLDS, ETCUSCOD, ETCUSNAM, ETCURR, ETVERSON, ETCSHTCD,
            ETCSHTDS, ETCADNO, ETCADNM, ETDRFTSO, ETDRFTNM, ETUOM, ETOTLQTY, ETOHCSCD, ETRTSGCD, ETRUTCST,
            ETOTLPRC, ETFABCST, ETTRMCST, ETPRICST, ETOVHCST, ETCALCM, ETOTHCST, ETOTLCST, ETACPFPR,
            ETOFRFOB, ETCLPRFT, ETSLPRIC, ETCPRFTP, ETNDPRFT, ETDOCTRY;















        // ComboBox
        private SAPbouiCOM.ComboBox CBITMGRP;

        

        // Button
        private SAPbouiCOM.Button BTNRTSTG, BTNFBRIC, BTNCALCU, BTNPRINT, BTNAPROV, ADDButton, CancelButton;




        // Folder
        private SAPbouiCOM.Folder FOLOHCST, FOLFBCLR, FOLRTSTG, FOLTEMP, FOLTRACC;

        // Matrix
        private SAPbouiCOM.Matrix MTXOHCST, MTXTRMAC, MTXROUTE, MTXFOB, MTXCOLOR, MTXFBRIC, MTXTRMFB, MTXSZCON;

      


        // LinkedButton
        private SAPbouiCOM.LinkedButton LBSTYLCD, LBCADNO, LBDRFTSO, LBCUSCOD;

        private string cardCode;
        private int lastFocusedLineIdMTXFOB = -1;
        private int lastFocusedLineIdMTXCOLOR = -1;
        private bool fobdelete = false;
        private string brandCode = "";

        public override void OnInitializeComponent()
        {
            //                             StaticText
            this.STSTYLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.STSTYLDS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLDS").Specific));
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STCSHTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STCSHTCD").Specific));
            this.STCSHTDS = ((SAPbouiCOM.StaticText)(this.GetItem("STCSHTDS").Specific));
            this.STCADNO = ((SAPbouiCOM.StaticText)(this.GetItem("STCADNO").Specific));
            this.STDRFTSO = ((SAPbouiCOM.StaticText)(this.GetItem("STDRFTSO").Specific));
            this.STUOM = ((SAPbouiCOM.StaticText)(this.GetItem("STUOM").Specific));
            this.STOTLQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STOTLQTY").Specific));
            this.STVERSON = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.STITMGRP = ((SAPbouiCOM.StaticText)(this.GetItem("STITMGRP").Specific));
            this.STOHCSCD = ((SAPbouiCOM.StaticText)(this.GetItem("STOHCSCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STOTLPRC = ((SAPbouiCOM.StaticText)(this.GetItem("STOTLPRC").Specific));
            this.STFABCST = ((SAPbouiCOM.StaticText)(this.GetItem("STFABCST").Specific));
            this.STTRMCST = ((SAPbouiCOM.StaticText)(this.GetItem("STTRMCST").Specific));
            this.STPRICST = ((SAPbouiCOM.StaticText)(this.GetItem("STPRICST").Specific));
            this.STOVHCST = ((SAPbouiCOM.StaticText)(this.GetItem("STOVHCST").Specific));
            this.STCALCM = ((SAPbouiCOM.StaticText)(this.GetItem("STCALCM").Specific));
            this.STOTHCST = ((SAPbouiCOM.StaticText)(this.GetItem("STOTHCST").Specific));
            this.STOTLCST = ((SAPbouiCOM.StaticText)(this.GetItem("STOTLCST").Specific));
            this.STOFRFOB = ((SAPbouiCOM.StaticText)(this.GetItem("STOFRFOB").Specific));
            this.STCLPRFT = ((SAPbouiCOM.StaticText)(this.GetItem("STCLPRFT").Specific));
            this.STSLPRIC = ((SAPbouiCOM.StaticText)(this.GetItem("STSLPRIC").Specific));
            this.STCPRFTP = ((SAPbouiCOM.StaticText)(this.GetItem("STCPRFTP").Specific));
            this.STNDPRFT = ((SAPbouiCOM.StaticText)(this.GetItem("STNDPRFT").Specific));
            //                             EditText
            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETSTYLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLCD_ChooseFromListAfter);
            this.ETSTYLDS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLDS").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETVERSON = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.ETCSHTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCSHTCD").Specific));
            this.ETCSHTDS = ((SAPbouiCOM.EditText)(this.GetItem("ETCSHTDS").Specific));
            this.ETCADNO = ((SAPbouiCOM.EditText)(this.GetItem("ETCADNO").Specific));
            this.ETCADNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCADNO_ChooseFromListAfter);
            this.ETCADNO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETCADNO_ChooseFromListBefore);
            this.ETCADNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCADNM").Specific));
            this.ETDRFTSO = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTSO").Specific));
            this.ETDRFTSO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETDRFTSO_ChooseFromListAfter);
            this.ETDRFTSO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETDRFTSO_ChooseFromListBefore);
            this.ETDRFTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNM").Specific));
            this.ETUOM = ((SAPbouiCOM.EditText)(this.GetItem("ETUOM").Specific));
            this.ETOTLQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETOTLQTY").Specific));
            this.ETOHCSCD = ((SAPbouiCOM.EditText)(this.GetItem("ETOHCSCD").Specific));
            this.ETOHCSCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETOHCSCD_ChooseFromListAfter);
            this.ETOHCSCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETOHCSCD_ChooseFromListBefore);
            this.ETRTSGCD = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGCD").Specific));
            this.ETOTLPRC = ((SAPbouiCOM.EditText)(this.GetItem("ETOTLPRC").Specific));
            this.ETFABCST = ((SAPbouiCOM.EditText)(this.GetItem("ETFABCST").Specific));
            this.ETTRMCST = ((SAPbouiCOM.EditText)(this.GetItem("ETTRMCST").Specific));
            this.ETPRICST = ((SAPbouiCOM.EditText)(this.GetItem("ETPRICST").Specific));
            this.ETOVHCST = ((SAPbouiCOM.EditText)(this.GetItem("ETOVHCST").Specific));
            this.ETCALCM = ((SAPbouiCOM.EditText)(this.GetItem("ETCALCM").Specific));
            this.ETOTHCST = ((SAPbouiCOM.EditText)(this.GetItem("ETOTHCST").Specific));
            this.ETOTLCST = ((SAPbouiCOM.EditText)(this.GetItem("ETOTLCST").Specific));
            this.ETOFRFOB = ((SAPbouiCOM.EditText)(this.GetItem("ETOFRFOB").Specific));
            this.ETCLPRFT = ((SAPbouiCOM.EditText)(this.GetItem("ETCLPRFT").Specific));
            this.ETSLPRIC = ((SAPbouiCOM.EditText)(this.GetItem("ETSLPRIC").Specific));
            this.ETCPRFTP = ((SAPbouiCOM.EditText)(this.GetItem("ETCPRFTP").Specific));
            this.ETNDPRFT = ((SAPbouiCOM.EditText)(this.GetItem("ETNDPRFT").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            //                             ComboBox
            this.CBITMGRP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBITMGRP").Specific));
            //                             Button
            this.BTNRTSTG = ((SAPbouiCOM.Button)(this.GetItem("BTNRTSTG").Specific));
            this.BTNRTSTG.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNRTSTG_PressedAfter);
            this.BTNFBRIC = ((SAPbouiCOM.Button)(this.GetItem("BTNFBRIC").Specific));
            this.BTNFBRIC.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNFBRIC_PressedBefore);
            this.BTNCALCU = ((SAPbouiCOM.Button)(this.GetItem("BTNCALCU").Specific));
            this.BTNCALCU.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNCALCU_PressedAfter);
            this.BTNCALCU.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNCALCU_PressedBefore);
            this.BTNPRINT = ((SAPbouiCOM.Button)(this.GetItem("BTNPRINT").Specific));
            this.BTNAPROV = ((SAPbouiCOM.Button)(this.GetItem("BTNAPROV").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            //                             Folder
            this.FOLOHCST = ((SAPbouiCOM.Folder)(this.GetItem("FOLOHCST").Specific));
            this.FOLFBCLR = ((SAPbouiCOM.Folder)(this.GetItem("FOLFBCLR").Specific));
            this.FOLRTSTG = ((SAPbouiCOM.Folder)(this.GetItem("FOLRTSTG").Specific));
            this.FOLTRACC = ((SAPbouiCOM.Folder)(this.GetItem("FOLTRACC").Specific));
            //                             Matrix
            this.MTXOHCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOHCST").Specific));
            this.MTXTRMAC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTRMAC").Specific));
            this.MTXTRMAC.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.MTXTRMAC_DoubleClickAfter);
            this.MTXTRMAC.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXTRMAC_LostFocusAfter);
            this.MTXTRMAC.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXTRMAC_ChooseFromListAfter);
            this.MTXTRMAC.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXTRMAC_ChooseFromListBefore);
            this.MTXROUTE = ((SAPbouiCOM.Matrix)(this.GetItem("MTXROUTE").Specific));
            this.MTXFOB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXFOB").Specific));
            this.MTXFOB.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXFOB_LostFocusAfter);
            this.MTXCOLOR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOLOR").Specific));
            this.MTXCOLOR.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXCOLOR_LostFocusAfter);
            this.MTXCOLOR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCOLOR_ChooseFromListAfter);
            this.MTXCOLOR.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXCOLOR_ChooseFromListBefore);
            this.MTXFBRIC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXFBRIC").Specific));
            this.MTXFBRIC.KeyDownAfter += new SAPbouiCOM._IMatrixEvents_KeyDownAfterEventHandler(this.MTXFBRIC_KeyDownAfter);
            this.MTXFBRIC.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXFBRIC_LostFocusAfter);
            this.MTXFBRIC.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXFBRIC_ChooseFromListAfter);
            this.MTXFBRIC.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXFBRIC_ChooseFromListBefore);
            this.MTXTRMFB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTRMFB").Specific));
            this.MTXTRMFB.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXTRMFB_LostFocusAfter);
            //                             LinkedButton
            this.LBSTYLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBSTYLCD").Specific));
            this.LBSTYLCD.ClickBefore += new SAPbouiCOM._ILinkedButtonEvents_ClickBeforeEventHandler(this.LBSTYLCD_ClickBefore);
            this.LBCADNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBCADNO").Specific));
            this.LBCADNO.ClickBefore += new SAPbouiCOM._ILinkedButtonEvents_ClickBeforeEventHandler(this.LBCADNO_ClickBefore);
            this.LBDRFTSO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBDRFTSO").Specific));
            this.LBCUSCOD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBCUSCOD").Specific));
            this.FOLTEMP = ((SAPbouiCOM.Folder)(this.GetItem("FOLTEMP").Specific));
            this.MTXSZCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSZCON").Specific));
            this.STRUTCST = ((SAPbouiCOM.StaticText)(this.GetItem("STRUTCST").Specific));
            this.ETRUTCST = ((SAPbouiCOM.EditText)(this.GetItem("ETRUTCST").Specific));
            this.ETACPFPR = ((SAPbouiCOM.EditText)(this.GetItem("ETACPFPR").Specific));
            this.STACPFPR = ((SAPbouiCOM.StaticText)(this.GetItem("STACPFPR").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataAddAfter += new SAPbouiCOM.Framework.FormBase.DataAddAfterHandler(this.Form_DataAddAfter);
            this.DataUpdateAfter += new SAPbouiCOM.Framework.FormBase.DataUpdateAfterHandler(this.Form_DataUpdateAfter);
            this.RightClickAfter += new SAPbouiCOM.Framework.FormBase.RightClickAfterHandler(this.Form_RightClickAfter);
            this.LayoutKeyBefore += new LayoutKeyBeforeHandler(this.Form_LayoutKeyBefore);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }
        // Create global variables so you can use them later anywhere in the form

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           

        }

        private void Form_LayoutKeyBefore(ref SAPbouiCOM.LayoutKeyInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            switch (eventInfo.EventType)
            {
                case SAPbouiCOM.BoEventTypes.et_PRINT:
                case SAPbouiCOM.BoEventTypes.et_PRINT_DATA:
                case SAPbouiCOM.BoEventTypes.et_PRINT_LAYOUT_KEY:
                    SAPbouiCOM.Form ofrom = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(eventInfo.FormUID);
                    eventInfo.LayoutKey = ofrom.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("DocEntry", 0);
                    break;
            }

        }

        private void MTXFBRIC_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {

                if (pVal.ColUID == "CLPRICE")
                {
                    MoveMatrixRow(pVal, "MTXFBRIC", pVal.ColUID);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "You are already in the last row.",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
            }

        }

        private void MoveMatrixRow(SAPbouiCOM.SBOItemEventArg pVal, string matrixID, string colUID)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;

            int row = pVal.Row;

            // Down Arrow
            if (pVal.CharPressed == 40)
            {

                oMatrix.Columns.Item(colUID).Cells.Item(row + 1).Click();
            }

            // Up Arrow
            if (pVal.CharPressed == 38 && row > 1)
            {
                oMatrix.Columns.Item(colUID).Cells.Item(row - 1).Click();
            }
        }

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string styleCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_STYLENO", 0).Trim();
                string Code = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Code", 0).Trim();

                string qStr = $@"
                                SELECT * FROM ""@FIL_MR_PSMCS""
                                    WHERE ""Code"" = '{styleCode}'
                                    AND ""U_Code"" = '{Code}'";

                SAPbobsCOM.Recordset rs =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(qStr);

                if (rs.RecordCount == 0)
                {
                    UpdateProductMaster(oForm);
                }
                else if (rs.RecordCount > 0)
                {
                    UpdateProductMasterExisting(oForm);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Update After Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                string qStr = "";

                string styleCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM")
                                    .GetValue("U_STYLENO", 0).Trim();
                string Code = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM")
                                    .GetValue("Code", 0).Trim();

                qStr = $@"
                        SELECT * FROM ""@FIL_MR_PSMCS""
                        WHERE ""Code"" = '{styleCode}'
                          AND ""U_Code"" = '{Code}'";

                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRS.DoQuery(qStr);

                if (oRS.RecordCount == 0)
                {
                    UpdateProductMaster(oForm);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "ADD After Error " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void UpdateProductMasterExisting(SAPbouiCOM.Form pForm)
        {
            string styleCode = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_STYLENO", 0).Trim();
            string Code     = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Code", 0).Trim();
            string Name     = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Name", 0).Trim();
            string DraftEntry = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_DRFTNTRY", 0).Trim();

            string qStr = $@"
                    SELECT * FROM ""@FIL_MR_PSMCS""
                    WHERE ""Code"" = '{styleCode}'
                      AND ""U_Code"" = '{Code}'
                      AND ""U_DRFTNTRY"" = '{DraftEntry}'
                      AND ""U_Active"" = 'Y'";

            SAPbobsCOM.Recordset rsCheck =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsCheck.DoQuery(qStr);

            if (rsCheck.RecordCount == 0)
            {
                // Update Draft Entry
                qStr = $@"
                        UPDATE B SET ""U_DRFTNTRY"" = '{DraftEntry}'
                        FROM ""@FIL_MR_PSMCS"" B
                        INNER JOIN ""@FIL_MH_OCSM"" C ON C.""Code"" = B.""U_Code"" AND B.""Code"" = C.""U_STYLENO""
                        WHERE C.""Code"" = '{Code}'";

                SAPbobsCOM.Recordset rs1 =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs1.DoQuery(qStr);

                // Activate current
                qStr = $@"
                        UPDATE ""@DTS_PSMCS"" SET
                            ""U_Code""   = '{Code}',
                            ""U_Desc""   = '{Name}',
                            ""U_Active"" = 'Y'
                        WHERE ""Code"" = '{styleCode}'
                          AND ""U_Code"" = '{Code}'
                          AND ""U_DRFTNTRY"" = '{DraftEntry}'";

                SAPbobsCOM.Recordset rs2 =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs2.DoQuery(qStr);
            }

            // Always sync draft
            qStr = $@"
                    UPDATE B SET ""U_DRFTNTRY"" = '{DraftEntry}'
                    FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C ON C.""Code"" = B.""U_Code"" AND B.""Code"" = C.""U_STYLENO""
                    WHERE C.""Code"" = '{Code}'";

            SAPbobsCOM.Recordset rs3 =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs3.DoQuery(qStr);

            // Activate matched
            qStr = $@"
                    UPDATE B SET ""U_Active"" = 'Y'
                    FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C 
                    ON C.""Code"" = B.""U_Code""
                    AND B.""Code"" = C.""U_STYLENO""
                    AND C.""U_DRFTNTRY"" = B.""U_DRFTNTRY""
                    WHERE C.""Code"" = '{Code}'";
            rs3.DoQuery(qStr);

            // Deactivate others
            qStr = $@"
                    UPDATE B SET ""U_Active"" = 'N'
                    FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C 
                    ON C.""Code"" <> B.""U_Code""
                    AND B.""Code"" = C.""U_STYLENO""
                    AND C.""U_DRFTNTRY"" = B.""U_DRFTNTRY""
                    WHERE C.""Code"" = '{Code}'";
            rs3.DoQuery(qStr);
        }


        private void UpdateProductMaster(SAPbouiCOM.Form pForm)
        {
            string qStr = "";

            string styleCode = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_STYLENO", 0).Trim();
            string Code = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Code", 0).Trim();
            string Name = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Name", 0).Trim();
            string DraftEntry = pForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_DRFTNTRY", 0).Trim();

            qStr = $@"
                    SELECT * FROM ""@FIL_MR_PSMCS"" 
                    WHERE ""Code"" = '{styleCode}' 
                    AND IFNULL(""U_Code"",'-1') = '-1'";

            SAPbobsCOM.Recordset rsCheck =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsCheck.DoQuery(qStr);

            //================ UPDATE =================
            if (rsCheck.RecordCount > 0)
            {
                qStr = $@"
                        UPDATE ""@FIL_MR_PSMCS"" 
                        SET
                            ""U_Code""      = '{Code}',
                            ""U_Desc""      = '{Name}',
                            ""U_Active""    = 'Y',
                            ""U_DRFTNTRY""  = '{DraftEntry}'
                        WHERE ""Code"" = '{styleCode}' 
                              AND IFNULL(""U_Code"",'-1')='-1'";

                SAPbobsCOM.Recordset rsUpd =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rsUpd.DoQuery(qStr);
            }
            //================ ADD =================
            else
            {
                SAPbobsCOM.CompanyService oCompService = Global.oComp.GetCompanyService();
                SAPbobsCOM.GeneralService oGeneralService = oCompService.GetGeneralService("FIL_M_OPSM");
                SAPbobsCOM.GeneralDataParams oParams =
                    (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);

                oParams.SetProperty("Code", styleCode);

                SAPbobsCOM.GeneralData oData = oGeneralService.GetByParams(oParams);
                SAPbobsCOM.GeneralDataCollection oChildren = oData.Child("FIL_MR_PSMCS");

                SAPbobsCOM.GeneralData oChild = oChildren.Add();
                oChild.SetProperty("U_Code", Code);
                oChild.SetProperty("U_Desc", Name);
                oChild.SetProperty("U_DRFTNTRY", DraftEntry);
                oChild.SetProperty("U_Active", "Y");

                oGeneralService.Update(oData);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oGeneralService);
            }

            //================ COMMON UPDATES =================
            SAPbobsCOM.Recordset rsFinal =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            // Update Draft Entry
            qStr = $@"
                    UPDATE B SET ""U_DRFTNTRY"" = '{DraftEntry}'
                        FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C 
                        ON C.""Code"" = B.""U_Code"" 
                        AND B.""Code"" = C.""U_STYLENO""
                    WHERE C.""Code"" = '{Code}'";
            rsFinal.DoQuery(qStr);

            // Activate correct row
            qStr = $@"
                    UPDATE B SET ""U_Active"" = 'Y'
                        FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C 
                        ON C.""Code"" = B.""U_Code"" 
                        AND B.""Code"" = C.""U_STYLENO""
                        AND C.""U_DRFTNTRY"" = B.""U_DRFTNTRY""
                    WHERE C.""Code"" = '{Code}'";
            rsFinal.DoQuery(qStr);

            // Deactivate others
            qStr = $@"
                    UPDATE B SET ""U_Active"" = 'N'
                        FROM ""@FIL_MR_PSMCS"" B
                    INNER JOIN ""@FIL_MH_OCSM"" C 
                        ON C.""Code"" <> B.""U_Code"" 
                        AND B.""Code"" = C.""U_STYLENO""
                        AND C.""U_DRFTNTRY"" = B.""U_DRFTNTRY""
                    WHERE C.""Code"" = '{Code}'";
            rsFinal.DoQuery(qStr);
        }
//______________ test 
        private const string MNU_DUPLICATE = "FIL_DUPL";   // must be unique globally
        private string FormUid = "";
        private string ItemUid = "";
        private string ColUid = "";
        private int    Row = 0;


        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            FormUid = eventInfo.FormUID;
            ItemUid = eventInfo.ItemUID;
            ColUid = eventInfo.ColUID;
            Row = eventInfo.Row;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(eventInfo.FormUID);
            bool shouldShow = (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE);
            AddOrRemoveRightClickMenu(shouldShow);
        }
        private void Form_RightClickAfter(ref SAPbouiCOM.ContextMenuInfo eventInfo)
        {
            AddOrRemoveRightClickMenu(false);
        }

        private void AddOrRemoveRightClickMenu(bool add)
        {
            // Most add-ons attach to Data menu ("1280") so it appears in context menu too
            SAPbouiCOM.MenuItem dataMenu = Application.SBO_Application.Menus.Item("1280");
            SAPbouiCOM.Menus subMenus = dataMenu.SubMenus;

            if (add)
            {
                if (!subMenus.Exists(MNU_DUPLICATE))
                {
                    SAPbouiCOM.MenuCreationParams cp =
                        (SAPbouiCOM.MenuCreationParams)Application.SBO_Application
                            .CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);

                    cp.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                    cp.UniqueID = MNU_DUPLICATE;
                    cp.String = "Duplicate (Custom)";
                    cp.Enabled = true;
                    cp.Position = subMenus.Count + 1;

                    subMenus.AddEx(cp);
                }
            }
            else
            {
                if (subMenus.Exists(MNU_DUPLICATE))
                    subMenus.RemoveEx(MNU_DUPLICATE);
            }
        }

//---------------test
        private void MTXTRMFB_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.Row <= 0) return;

                // Only act when user leaves Profit % column
                if (!string.Equals(pVal.ColUID, "CLPRFTPR", StringComparison.OrdinalIgnoreCase))
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMFB").Specific;

                int row = pVal.Row;

                // Read Profit % and Total Cost from this row
                string prftPrStr = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRFTPR").Cells.Item(row).Specific).Value;
                string ttlCstStr = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLTTLCST").Cells.Item(row).Specific).Value;

                double profitPercent = ParseDoubleSafe(prftPrStr);  // your double variable
                double totalCost = ParseDoubleSafe(ttlCstStr);  // your double variable

                // Calculations
                double profitValue = totalCost * profitPercent / 100.0;
                double sellingPrice = totalCost + profitValue;

                // Set back to matrix
                oMatrix.SetCellWithoutValidation(row, "CLPRFTVL", profitValue.ToString());
                oMatrix.SetCellWithoutValidation(row, "CLSELPRC", sellingPrice.ToString());


                // Push current matrix edits to DS (helps when user was still editing a cell)
                oMatrix.FlushToDataSource();

                // Matrix ColumnId  ->  EditText ItemId
                var map = new Dictionary<string, string>
                {
                    {"CLPRFTPR", "ETCPRFTP"},
                    {"CLPRFTVL", "ETCLPRFT"},
                    {"CLSELPRC", "ETSLPRIC"},
                };

                var sum = new Dictionary<string, double>();
                var cnt = new Dictionary<string, int>();

                foreach (var col in map.Keys)
                {
                    sum[col] = 0.0;
                    cnt[col] = 0;
                }

                int rows = oMatrix.RowCount;

                for (int r = 1; r <= rows; r++)
                {
                    foreach (var col in map.Keys)
                    {
                        string raw = GetMatrixCellValue(oMatrix, col, r);

                        if (TryParseDouble(raw, out double val))
                        {
                            sum[col] += val;
                            cnt[col] += 1;
                        }
                    }
                }

                oForm.Freeze(true);

                foreach (var kv in map)
                {
                    string colId = kv.Key;
                    string etId = kv.Value;

                    string outVal = "";
                    if (cnt[colId] > 0)
                    {
                        double avg = sum[colId] / cnt[colId];
                        outVal = avg.ToString("0.00", CultureInfo.InvariantCulture);
                    }

                    ((SAPbouiCOM.EditText)oForm.Items.Item(etId).Specific).Value = outVal;
                }
                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "MTXTRMFB LostFocus calc failed: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private double ParseDoubleSafe(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            // Handle both "1,23" and "1.23"
            s = s.Trim();
            s = s.Replace(" ", "");
            s = s.Replace(",", ".");

            double v;
            return double.TryParse(s, System.Globalization.NumberStyles.Any,
                                   System.Globalization.CultureInfo.InvariantCulture, out v)
                ? v
                : 0;
        }

        private void BTNCALCU_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            SAPbouiCOM.Matrix mtx = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMFB").Specific;

                // Push current matrix edits to DS (helps when user was still editing a cell)
                mtx.FlushToDataSource();

                // Matrix ColumnId  ->  EditText ItemId
                var map = new Dictionary<string, string>
                {
                    {"CLFOB",    "ETOFRFOB"},
                    {"CLFABCST", "ETFABCST"},
                    {"CLTACCST", "ETTRMCST"},
                    {"CLPACST",  "ETPRICST"},
                    {"CLOTHCST", "ETOTHCST"},
                    {"CLRUTCST", "ETRUTCST"},
                    {"CLOVHCST", "ETOVHCST"},
                    {"CLCALCST", "ETCALCM"},
                    {"CLTTLCST", "ETOTLCST"},

                    //{"CLPRFTPR", "ETCPRFTP"},
                    //{"CLPRFTVL", "ETCLPRFT"},
                    //{"CLSELPRC", "ETSLPRIC"},
                };

                var sum = new Dictionary<string, double>();
                var cnt = new Dictionary<string, int>();

                foreach (var col in map.Keys)
                {
                    sum[col] = 0.0;
                    cnt[col] = 0;
                }

                int rows = mtx.RowCount;

                for (int r = 1; r <= rows; r++)
                {
                    foreach (var col in map.Keys)
                    {
                        string raw = GetMatrixCellValue(mtx, col, r);

                        if (TryParseDouble(raw, out double val))
                        {
                            sum[col] += val;
                            cnt[col] += 1;
                        }
                    }
                }

                oForm.Freeze(true);

                foreach (var kv in map)
                {
                    string colId = kv.Key;
                    string etId = kv.Value;

                    string outVal = "";
                    if (cnt[colId] > 0)
                    {
                        double avg = sum[colId] / cnt[colId];
                        outVal = avg.ToString("0.00", CultureInfo.InvariantCulture);
                    }

                    ((SAPbouiCOM.EditText)oForm.Items.Item(etId).Specific).Value = outVal;
                }

                // Get ETOFRFOB value into a double variable
                double fobValue = 0.0;
                double ttlValue = 0.0;
                double stdValue = 0.0;
                string fobRaw = ((SAPbouiCOM.EditText)oForm.Items.Item("ETOFRFOB").Specific).Value;
                string ttlRaw = ((SAPbouiCOM.EditText)oForm.Items.Item("ETOTLCST").Specific).Value;
                string stdRaw = ((SAPbouiCOM.EditText)oForm.Items.Item("ETNDPRFT").Specific).Value;
                double.TryParse(fobRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out fobValue);
                double.TryParse(ttlRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out ttlValue);
                double.TryParse(stdRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out stdValue);

                // now use fobValue for calculations

                double res = fobValue - ttlValue;
                double percent = (res / fobValue) * 100;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETACPFPR").Specific).Value = percent.ToString();
               
                var oItem = oForm.Items.Item("STACPFPR"); 
                double check = stdValue - percent;
                if (res < 0)
                {
                    oItem.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
                    oItem.ForeColor = 255;
                   
                }
                else
                {
                    if (check <0)
                    {
                        oItem.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
                        oItem.ForeColor = 255;
                    }
                    else
                    {
                        oItem.ForeColor = 0;
                    }
                   
                }

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "BTNCALCU error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
            finally
            {
                try { if (oForm != null) oForm.Freeze(false); } catch { }
            }
        }

        private string GetMatrixCellValue(SAPbouiCOM.Matrix mtx, string colId, int row)
        {
            try
            {
                var cell = (SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(row).Specific;
                return (cell.Value ?? "").Trim();
            }
            catch
            {
                return "";
            }
        }

        private bool TryParseDouble(string s, out double val)
        {
            val = 0;

            if (string.IsNullOrWhiteSpace(s)) return false;

            // Remove common formatting
            s = s.Trim().Replace(",", "");

            return double.TryParse(
                s,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out val
            );
        }

        private void BTNCALCU_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            string costCode = ETCSHTCD.Value;
            string styleCode = ETSTYLCD.Value;
            string cusCode = ETCUSCOD.Value;
            string CADNo = ETCADNO.Value;
            string draftSO = ETDRFTSO.Value;
            string routeCost = ETOTLPRC.Value;

            if (string.IsNullOrEmpty(costCode) || string.IsNullOrEmpty(styleCode) ||
                string.IsNullOrEmpty(cusCode) || string.IsNullOrEmpty(CADNo) ||
                string.IsNullOrEmpty(draftSO) || string.IsNullOrEmpty(routeCost))
            {
                BubbleEvent = false;
                return;
            }
            else
            {
                try
                {
                    oForm.Freeze(true);
                    string sql = $@"
                        SELECT top 1
                            fob.""LineId"" AS ""LineId"",
                            fob.""U_FOB""  AS ""FOB"",
                            COALESCE(mat.""Material Cost"", 0) AS ""Material"",
                            COALESCE(acc.""ACC Cost"", 0)      AS ""Acc"",
                            COALESCE(pack.""Pack Cost"", 0)    AS ""Pack"",
                            COALESCE(oth.""Other Cost"", 0)    AS ""Other""
                        FROM ""@FIL_MR_CSMFOB"" fob
                        LEFT JOIN (
                            SELECT
                                ""Code"",
                                ""U_FOBLINE"",
                                SUM(COALESCE(""U_TOTAL"", 0)) / NULLIF(COUNT(DISTINCT ""U_CLRCODE""), 0) AS ""Material Cost""
                            FROM ""@FIL_MR_CSMFAB""
                            GROUP BY ""Code"", ""U_FOBLINE""
                        ) mat
                        ON mat.""Code"" = fob.""Code""
                        AND mat.""U_FOBLINE"" = fob.""LineId""
                        LEFT JOIN (
                            SELECT
                                ""Code"",
                                SUM(COALESCE(""U_Total"", 0)) AS ""ACC Cost""
                            FROM ""@FIL_MR_CSMTA""
                            WHERE ""U_IMGPTPNM"" IN ('Accessories', 'Raw Material', 'Overhead Cost')
                            GROUP BY ""Code""
                        ) acc
                        ON acc.""Code"" = fob.""Code""
                        LEFT JOIN (
                            SELECT
                                ""Code"",
                                SUM(COALESCE(""U_Total"", 0)) AS ""Pack Cost""
                            FROM ""@FIL_MR_CSMTA""
                            WHERE ""U_IMGPTPNM"" = 'Packing Material'
                            GROUP BY ""Code""
                        ) pack
                        ON pack.""Code"" = fob.""Code""
                        LEFT JOIN (
                            SELECT
                                f.""Code"",
                                f.""LineId"" AS ""FOB_LineId"",
                                SUM(
                                    CASE
                                        WHEN COALESCE(o.""U_PRCNTG"", 0) <> 0
                                            THEN f.""U_FOB"" * o.""U_PRCNTG"" / 100
                                        ELSE COALESCE(o.""U_VALUE"", 0)
                                    END
                                ) AS ""Other Cost""
                            FROM ""@FIL_MR_CSMFOB"" f
                            LEFT JOIN ""@FIL_MR_CSOTHRCS"" o
                                   ON o.""Code"" = f.""Code""
                            GROUP BY f.""Code"", f.""LineId"", f.""U_FOB""
                        ) oth
                        ON oth.""Code"" = fob.""Code""
                        AND oth.""FOB_LineId"" = fob.""LineId""
                        WHERE fob.""Code"" = '{costCode}' and fob.""U_FOB"" > 1
                        ORDER BY fob.""LineId""";

                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    oRS.DoQuery(sql);

                    // --- Get Matrix ---
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMFB").Specific;
                    SAPbouiCOM.DBDataSource ds =
                        oForm.DataSources.DBDataSources.Item("@FIL_MR_CSMCST");

                    // --- Clear Old Rows ---
                    ds.Clear();
                    oMatrix.Clear();

                    // --- Insert Query Rows ---
                    int rowIndex = 0;
                    while (!oRS.EoF)
                    {
                        ds.InsertRecord(rowIndex);
                        ds.SetValue("LineId", rowIndex, oRS.Fields.Item("LineId").Value.ToString());
                        ds.SetValue("U_FOB", rowIndex, oRS.Fields.Item("FOB").Value.ToString());
                        ds.SetValue("U_FABRCCST", rowIndex, oRS.Fields.Item("Material").Value.ToString());
                        ds.SetValue("U_TRMSCST", rowIndex, oRS.Fields.Item("Acc").Value.ToString());
                        ds.SetValue("U_PCKGCST", rowIndex, oRS.Fields.Item("Pack").Value.ToString());
                        ds.SetValue("U_OTHCOSTO", rowIndex, oRS.Fields.Item("Other").Value.ToString());
                        ds.SetValue("U_ROUTECST", rowIndex, routeCost);

                        double overcost = Double.Parse(routeCost) + Double.Parse(oRS.Fields.Item("Other").Value.ToString());
                        ds.SetValue("U_OVRHDCST", rowIndex, overcost.ToString());

                        double total = Double.Parse(oRS.Fields.Item("Material").Value.ToString()) +
                            Double.Parse(oRS.Fields.Item("Acc").Value.ToString()) +
                            Double.Parse(oRS.Fields.Item("Pack").Value.ToString()) + overcost;

                        double cm = GetTotalRouteTime(oForm);

                        ds.SetValue("U_CALCM", rowIndex, cm.ToString()); 
                        ds.SetValue("U_TOTCOST", rowIndex, total.ToString());

                        rowIndex++;
                        oRS.MoveNext();
                    }
                    // --- Load into Matrix ---
                    oMatrix.LoadFromDataSource();
                    oMatrix.AutoResizeColumns();

                    Application.SBO_Application.StatusBar.SetText(
                       "Calculated All Costing Successfully ",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success
                    );
                    oForm.Freeze(false);
                }
                catch (Exception ex)
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Error filtering CFL: " + ex.Message,
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                    );
                }

            }

        }

        private double GetTotalRouteTime(SAPbouiCOM.Form oForm)
        {
            var mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;

            double sum = 0;
            for (int r = 1; r <= mtx.RowCount; r++) // matrix is 1-based
            {
                string a = ((SAPbouiCOM.EditText)mtx.Columns.Item("CLTTLTME").Cells.Item(r).Specific).Value;
                string b = ((SAPbouiCOM.EditText)mtx.Columns.Item("CLLEDTME").Cells.Item(r).Specific).Value;

                if (!string.IsNullOrWhiteSpace(a) && double.TryParse(a.Replace(",", "").Trim(), out double va)) sum += va;
                if (!string.IsNullOrWhiteSpace(b) && double.TryParse(b.Replace(",", "").Trim(), out double vb)) sum += vb;
            }
            return sum;
        }



        private void LBSTYLCD_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSTYLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific;
            string styleCode = ETSTYLCD.Value.Trim();
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

        private void LBCADNO_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETCADNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETCADNO").Specific;
            string cadCode = ETCADNO.Value.Trim();
            CAD cad = new CAD();
            cad.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETDOCNUM").Enabled = true;
                SAPbouiCOM.EditText cETCADNO = (SAPbouiCOM.EditText)cForm.Items.Item("ETDOCNUM").Specific;
                cETCADNO.Value = cadCode;
                cForm.Items.Item("1").Click();
             
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }

        }

        private void BTNRTSTG_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            string route = ETRTSGCD.Value;
            string styleCode = ETSTYLCD.Value;
            string cusCode = ETCUSCOD.Value;
            string totalQty = ETOTLQTY.Value;
            oForm.Freeze(true);
            try
            {
                if (string.IsNullOrEmpty(route) || string.IsNullOrEmpty(styleCode) || string.IsNullOrEmpty(cusCode))
                {
                    oForm.Freeze(false);
                    return;
                }
                SAPbobsCOM.Recordset oRS =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    string check = $@"
                                    SELECT
                                        O.""U_Brand"",
                                        O.""U_PrCateg"",
                                        CASE
                                            WHEN EXISTS (
                                                SELECT 1
                                                FROM ""@FIL_MH_CPMMSTR"" C
                                                WHERE C.""U_CARDCODE"" = '{cusCode}'
                                                  AND C.""U_BRAND""    = O.""U_Brand""
                                                  AND C.""U_PRDGRP""   = O.""U_PrCateg""
                                            )
                                            THEN 1
                                            ELSE 0
                                        END AS ""IsExists""
                                    FROM ""@FIL_MH_OPSM"" O
                                    WHERE O.""Code"" = '{styleCode}'";

                    oRS.DoQuery(check);

                    string brand = "";
                    string prCateg = "";
                    int isExists = 0;

                    if (!oRS.EoF)
                    {
                        brand = oRS.Fields.Item("U_Brand").Value.ToString();
                        prCateg = oRS.Fields.Item("U_PrCateg").Value.ToString();
                        isExists = Convert.ToInt32(oRS.Fields.Item("IsExists").Value);
                    }
                SAPbobsCOM.Recordset oRS2 =
                           (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = "";
                string msg = "";
                if (isExists==0)
                {
                    sql = $@"SELECT 
                                  t.*,
                                  TO_DECIMAL(t.""U_LeadTime"") * t.""CPM"" AS ""TOTAL""
                              FROM(
                                    SELECT
                                        RSM.""LineId"",
                                        RSM.""U_Code"",
                                        RSM.""U_Name"",
                                        RSM.""U_LeadTime"",
                                        RSM.""U_Price"" AS ""CPM"",
                                        RSM.""U_UOM"",
                                        SAM.""U_SAM"",
                                        OQST.""Code"" AS ""U_ORDRTYPE""


                                    FROM ""@FIL_MR_RSM1"" RSM
                                    LEFT JOIN ""@FIL_MH_IESAMMST"" IES
                                           ON IES.""U_RTSTAGE"" = RSM.""Code"" And IES.""U_STYLECD"" = '{styleCode}'
                                    LEFT JOIN ""@FIL_MR_IESAMMST"" SAM
                                           ON SAM.""Code""     = IES.""Code""
                                          AND SAM.""U_RSCODE"" = RSM.""U_Code""
                                          AND SAM.""U_RSDESC"" = RSM.""U_Name""

                                    LEFT JOIN ""@FIL_MH_CPMMSTR"" HCPM
                                           ON HCPM.""U_PROCESS""  = RSM.""U_Code""
                                          AND HCPM.""U_CARDCODE"" = '{cusCode}'
                                          AND HCPM.""U_BRAND""    = '{brand}'

                                    LEFT JOIN ""@FIL_MH_OQST"" OQST
                                            ON TO_DECIMAL({totalQty}) BETWEEN OQST.""U_QTYFROM"" AND OQST.""U_QTYTO""

                                    WHERE
                                        RSM.""Code""     = '{route}'
                                        AND RSM.""U_Active"" = 'Y'
                                    ORDER BY 
                                        RSM.""LineId""
                             ) t  order by t.""LineId"";";
                    msg = " Price Load From Route Stage";
                }
                else
                {
    
                      sql = $@"SELECT 
                                   t.*,
                                   TO_DECIMAL(t.""U_LeadTime"") * t.""CPM"" AS ""TOTAL""
                               FROM(
                                    SELECT
                                        RSM.""LineId"",
                                        RSM.""U_Code"",
                                        RSM.""U_Name"",
                                        RSM.""U_LeadTime"",
                                        RSM.""U_UOM"",
                                        SAM.""U_SAM"",
                                        CPMROW.""U_ORDRTYPE"",
                                        CASE CPMRNG.""U_RANGE""
                                            WHEN 'Range1' THEN CPMROW.""U_CPM1""
                                            WHEN 'Range2' THEN CPMROW.""U_CPM2""
                                            WHEN 'Range3' THEN CPMROW.""U_CPM3""
                                            WHEN 'Range4' THEN CPMROW.""U_CPM4""
                                            WHEN 'Range5' THEN CPMROW.""U_CPM5""
                                            WHEN 'Range6' THEN CPMROW.""U_CPM6""
                                        END AS ""CPM""
                                    FROM ""@FIL_MR_RSM1"" RSM
                                    LEFT JOIN ""@FIL_MH_IESAMMST"" IES
                                           ON IES.""U_RTSTAGE"" = RSM.""Code"" And IES.""U_STYLECD"" = '{styleCode}'
                                    LEFT JOIN ""@FIL_MR_IESAMMST"" SAM
                                           ON SAM.""Code""     = IES.""Code""
                                          AND SAM.""U_RSCODE"" = RSM.""U_Code""
                                          AND SAM.""U_RSDESC"" = RSM.""U_Name""

                                    LEFT JOIN ""@FIL_MH_CPMMSTR"" HCPM
                                           ON HCPM.""U_PROCESS""  = RSM.""U_Code""
                                          AND HCPM.""U_CARDCODE"" = '{cusCode}'
                                          AND HCPM.""U_BRAND""    = '{brand}'

                                    LEFT JOIN ""@FIL_MR_CPMMSTR2"" CPMRNG
                                           ON CPMRNG.""Code"" = HCPM.""Code""
                                          AND TO_DECIMAL(SAM.""U_SAM"") BETWEEN CPMRNG.""U_Start"" AND CPMRNG.""U_End""

                                    LEFT JOIN ""@FIL_MR_CPMMSTR"" CPMROW
                                           ON CPMROW.""Code"" = HCPM.""Code""
                                          AND TO_DECIMAL({totalQty}) BETWEEN CPMROW.""U_ORDSZFRM"" AND CPMROW.""U_ORDSZTO""

                                    WHERE
                                        RSM.""Code""     = '{route}'
                                    AND RSM.""U_Active"" = 'Y'
                                    ORDER BY 
                                        RSM.""LineId""
                                ) order by t.""LineId"";";
                    msg = " Price Load From CPM Master";
                }

                oRS.DoQuery(sql);

                // --- Get Matrix ---
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXROUTE").Specific;
                SAPbouiCOM.DBDataSource ds =
                    oForm.DataSources.DBDataSources.Item("@FIL_MR_CSMRS");

                // --- Clear Old Rows ---
                ds.Clear();
                oMatrix.Clear();

                // --- Insert Query Rows ---
                int rowIndex = 0;
                while (!oRS.EoF)
                {
                    ds.InsertRecord(rowIndex);
                    ds.SetValue("LineId", rowIndex, oRS.Fields.Item("LineId").Value.ToString());
                    ds.SetValue("U_RSCode", rowIndex, oRS.Fields.Item("U_Code").Value.ToString());
                    ds.SetValue("U_RSDesc", rowIndex, oRS.Fields.Item("U_Name").Value.ToString());
                    ds.SetValue("U_RSLeadTime", rowIndex, oRS.Fields.Item("U_LeadTime").Value.ToString());
                    ds.SetValue("U_RSPrice", rowIndex, oRS.Fields.Item("CPM").Value.ToString());
                    ds.SetValue("U_RSUoM", rowIndex, oRS.Fields.Item("U_UOM").Value.ToString());
                    ds.SetValue("U_RSQty", rowIndex, oRS.Fields.Item("U_SAM").Value.ToString());
                    ds.SetValue("U_ORDRTYPE", rowIndex, oRS.Fields.Item("U_ORDRTYPE").Value.ToString());
                    ds.SetValue("U_RSTotal", rowIndex, oRS.Fields.Item("TOTAL").Value.ToString());

                    rowIndex++;
                    oRS.MoveNext();
                }

                // --- Sum U_RSTotal ---
                double totalSum = 0.0;

                int recordCount = ds.Size;   

                for (int i = 0; i < recordCount; i++)
                {
                    string val = ds.GetValue("U_RSTotal", i).Trim();

                    if (!string.IsNullOrEmpty(val))
                    {
                        double rowTotal;
                        if (double.TryParse(val, out rowTotal))
                        {
                            totalSum += rowTotal;
                        }
                    }
                }

                // --- Set to EditText ---
                SAPbouiCOM.EditText oEditTotal =(SAPbouiCOM.EditText)oForm.Items.Item("ETOTLPRC").Specific;
                oEditTotal.Value = totalSum.ToString("0.00");

                // --- Load into Matrix ---
                oMatrix.LoadFromDataSource();
                oMatrix.AutoResizeColumns();

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }

                Application.SBO_Application.StatusBar.SetText(
                    msg,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Success
                );
                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
            finally
            {
                oForm.Freeze(false);
            }

        }

        private void ETOHCSCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Freeze(true);

            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                string code = dt.GetValue("Code", 0).ToString().Trim();
                ETOHCSCD.Value = code;

                // --- Query Data ---
                SAPbobsCOM.Recordset oRS =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = $@"
            SELECT ""LineId"", ""U_PRMCODE"", ""U_EDITABLE"", ""U_STPRCNTG"", ""U_STVALUE"",
                   ""U_BASEDON"", ""U_PRCNTG"", ""U_VALUE""
            FROM ""@FIL_MR_CSOTHCST"" 
            WHERE ""Code"" = '{code}' 
            ORDER BY ""LineId"";
        ";
                oRS.DoQuery(sql);

                // --- Get Matrix ---
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOHCST").Specific;
                SAPbouiCOM.DBDataSource ds =
                    oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHRCS");

                // --- Clear Old Rows ---
                ds.Clear();
                oMatrix.Clear();

                // --- Insert Query Rows ---
                int rowIndex = 0;
                while (!oRS.EoF)
                {
                    ds.InsertRecord(rowIndex);

                    ds.SetValue("LineId", rowIndex, oRS.Fields.Item("LineId").Value.ToString());
                    ds.SetValue("U_PARAMTR", rowIndex, oRS.Fields.Item("U_PRMCODE").Value.ToString());
                    ds.SetValue("U_EDITABLE", rowIndex, oRS.Fields.Item("U_EDITABLE").Value.ToString());
                    ds.SetValue("U_MPRCNTG", rowIndex, oRS.Fields.Item("U_STPRCNTG").Value.ToString());
                    ds.SetValue("U_MVALUE", rowIndex, oRS.Fields.Item("U_STVALUE").Value.ToString());
                    ds.SetValue("U_BASEDON", rowIndex, oRS.Fields.Item("U_BASEDON").Value.ToString());
                    ds.SetValue("U_PRCNTG", rowIndex, oRS.Fields.Item("U_PRCNTG").Value.ToString());
                    ds.SetValue("U_VALUE", rowIndex, oRS.Fields.Item("U_VALUE").Value.ToString());

                    ds.SetValue("U_ACTIVE", rowIndex, "Y");

                    rowIndex++;
                    oRS.MoveNext();
                }

                // --- Load into Matrix ---
                oMatrix.LoadFromDataSource();

                // ============================
                // APPLY ENABLE/DISABLE LOGIC
                // ============================
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.ComboBox cbEdit =(SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLEDIT").Cells.Item(i).Specific;
                    string editable = cbEdit.Value.Trim();

                    SAPbouiCOM.ComboBox cbBasedOn =(SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLBSDON").Cells.Item(i).Specific;
                    string basedOn = cbBasedOn.Value.Trim();

                 

                    // Disable both first
                    oMatrix.CommonSetting.SetCellEditable(i, GetColumnIndex(oMatrix, "CLALOPER"), false);
                    oMatrix.CommonSetting.SetCellEditable(i, GetColumnIndex(oMatrix, "CLALOVAL"), false);

                    if (basedOn == "V")
                    {

                        SAPbouiCOM.EditText allocatedVal = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLALOVAL").Cells.Item(i).Specific;
                        string valStr = allocatedVal.Value;
                        double val = Convert.ToDouble(valStr);

                        SAPbouiCOM.EditText stdVal = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTDVAL").Cells.Item(i).Specific;
                        string stdvalStr = stdVal.Value;
                        double stdval = Convert.ToDouble(stdvalStr);

                        double resV = stdval - val;
                        oMatrix.SetCellWithoutValidation(i, "CLVARNCV", resV.ToString());
                    }
                    else if (basedOn == "P")
                    {
                        SAPbouiCOM.EditText allocatedPer = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLALOPER").Cells.Item(i).Specific;
                        string perStr = allocatedPer.Value;
                        double per = Convert.ToDouble(perStr);

                        SAPbouiCOM.EditText stdPer = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTDPER").Cells.Item(i).Specific;
                        string stdperStr = stdPer.Value;
                        double stdper = Convert.ToDouble(stdperStr);

                        double resP = stdper - per;
                        oMatrix.SetCellWithoutValidation(i, "CLVARNCP", resP.ToString());
                    }

                    if (editable == "Y")
                    {
                        if (basedOn == "V")
                        {
                            //Enable CLALOVAL
                            oMatrix.CommonSetting.SetCellEditable(i, GetColumnIndex(oMatrix, "CLALOVAL"), true);
                        }
                        else if (basedOn == "P")
                        {
                            //Enable CLALOPER
                            oMatrix.CommonSetting.SetCellEditable(i, GetColumnIndex(oMatrix, "CLALOPER"), true);

                        }
                    }
                }

                oMatrix.AutoResizeColumns();
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private int GetColumnIndex(SAPbouiCOM.Matrix matrix, string columnId)
        {
            for (int i = 1; i <= matrix.Columns.Count; i++)
            {
                if (matrix.Columns.Item(i).UniqueID == columnId)
                {
                    return i;
                }
            }
            throw new Exception("Column not found: " + columnId);
        }



        private void ETOHCSCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OHCT")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    // ---- Get Style Code ----
                    SAPbouiCOM.EditText ETSTYLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific;
                    string styleCodeValue = ETSTYLCD.Value?.Trim();

                    // ---- Query Brand by Style Code ----
                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string sql = $@"SELECT ""U_Brand"" FROM ""@FIL_MH_OPSM"" WHERE ""Code"" = '{styleCodeValue}'";
                    oRS.DoQuery(sql);

                    string brandCode = "";

                    // ---- If No Record Found 
                    if (oRS.EoF)
                    {
                        Application.SBO_Application.MessageBox("No Brand found , Update Style Master First");
                        BubbleEvent = false;
                        return;
                    }


                    brandCode = oRS.Fields.Item("U_Brand").Value.ToString().Trim();

                    string cusCode = ETCUSCOD.Value;

                    // ---- Build Conditions ----
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_CARDCODE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = cusCode.Trim();
                    oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon2 = oCons.Add();
                    oCon2.Alias = "U_BRNDCODE";
                    oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon2.CondVal = brandCode.Trim();
                    oCon2.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon3 = oCons.Add();
                    oCon3.Alias = "U_ACTIVE";
                    oCon3.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon3.CondVal = "Y";

                    // ---- Apply Conditions ----
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

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
           // Global.G_UI_Application.ActivateMenuItem("521");
            AddLineIfLastRowHasValue(oForm, "MTXFOB", "@FIL_MR_CSMFOB", "U_FOB");
            AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_MR_CSMCLR", "U_CLRCODE");
            AddLineIfLastRowHasValue(oForm, "MTXTRMAC", "@FIL_MR_CSMTA", "U_ItemCode");

            //EnsureLine(oForm, "MTXFOB", "@FIL_MR_CSMFOB");
            //EnsureLine(oForm, "MTXCOLOR", "@FIL_MR_CSMCLR");
            //EnsureLine(oForm, "MTXFBRIC", "@FIL_MR_CSMFAB");
            EnsureLine(oForm, "MTXTRMAC", "@FIL_MR_CSMTA");
            //EnsureLine(oForm, "MTXTRMFB", "@FIL_MR_CSMCST");

        }
        private void MTXTRMAC_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            { 
                if (pVal.ItemUID != "MTXTRMAC" || pVal.Row <= 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMAC").Specific;


                string Code = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTCD").Specific).Value;
                // --- Get selected row values from parent matrix ---
                string lineId = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(pVal.Row).Specific).Value?.Trim() ?? "";
                string styleCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLNO").Cells.Item(pVal.Row).Specific).Value?.Trim() ?? "";
                bool size = ((SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLSIZE").Cells.Item(pVal.Row).Specific).Checked;
                bool color = ((SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLCOLOUR").Cells.Item(pVal.Row).Specific).Checked;

                // --- Basic validation ---
                if (string.IsNullOrWhiteSpace(styleCode))
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Style/Code is empty — cannot load size/color data.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    return;
                }
                if (!size && !color)
                {
                    Application.SBO_Application.StatusBar.SetText("You have to Checked Size or Colour First", SAPbouiCOM.BoMessageTime.bmt_Short);
                    return;
                }


                // --- Open SubColor form (reuse your existing form open code) ---
                SizeColorConsumption subForm = new SizeColorConsumption();
                subForm.Show();
                SAPbouiCOM.Form oSubForm = Application.SBO_Application.Forms.Item("FIL_FRM_SZCLRCON");

                // --- Pass parent info to SubColor form (keep your existing values) ---
                oSubForm.DataSources.UserDataSources.Item("UDPARENT").ValueEx = pVal.FormUID;
                oSubForm.DataSources.UserDataSources.Item("UDBSLINE").ValueEx = lineId;
                oSubForm.DataSources.UserDataSources.Item("UDSIZE").ValueEx = size.ToString();
                oSubForm.DataSources.UserDataSources.Item("UDCOLOR").ValueEx = color.ToString();
                oSubForm.Freeze(true);

                // === Enable/Disable Columns based on UDSIZE / UDCOLOR ===
                SAPbouiCOM.Matrix mtxSZ = (SAPbouiCOM.Matrix)oSubForm.Items.Item("MTXSZCON").Specific;

                SAPbouiCOM.Column colColor = mtxSZ.Columns.Item("CLRMCODE");
                SAPbouiCOM.Column colSize = mtxSZ.Columns.Item("CLSZPRAM");

                bool isSize = size;
                bool isColor = color;

                if (isSize && !isColor)
                {
                    // Only SIZE allowed
                    colColor.Editable = false;
                    colSize.Editable = true;
                }
                else if (!isSize && isColor)
                {
                    // Only COLOR allowed
                    colColor.Editable = true;
                    colSize.Editable = false;
                }
                else if (isSize && isColor)
                {
                    // Both allowed
                    colColor.Editable = true;
                    colSize.Editable = true;
                }
                else
                {
                    // None selected
                    colColor.Editable = false;
                    colSize.Editable = false;
                }


                // --- Prepare subform matrix and datasource ---
                SAPbouiCOM.Matrix subMatrix = (SAPbouiCOM.Matrix)oSubForm.Items.Item("MTXSZCON").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oSubForm.DataSources.DBDataSources.Item("@FIL_MR_SIZEDTLS");

                // --- Get parent’s sub-detail datasource (if you keep parent sub colors) ---
               // SAPbouiCOM.Matrix parentSubMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMAC").Specific;
               // SAPbouiCOM.DBDataSource parentSubDS = oForm.DataSources.DBDataSources.Item("@@FIL_MR_CSMTA");
                //parentSubMatrix.FlushToDataSource();

                // --- Always clear subform datasource before reloading ---
                DBDataSourceLine.Clear();
                subMatrix.Clear();

                // Use the company recordset to run queries
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = string.Empty;

                // --- Only Size selected: get codes + names ---
                if (size && !color)
                {
                    sql = $@"
                            SELECT DISTINCT           
                                T0.""U_SizeCode""   AS ""U_SIZECODE"",   
                                T0.""U_SizeName""   AS ""U_SIZENAME"",                 
                                T1.""U_RMCLCODE"",
                                T1.""U_RMClNAME"",
                                T1.""U_SIZEPARM"",
                                T1.""U_QUANTITY"",
                                T1.""U_UOM""
                            FROM ""@FIL_MR_PSMST"" T0 
                             LEFT OUTER JOIN ""@FIL_MR_SIZEDTLS"" T1  ON T1.""U_SIZECODE"" = T0.""U_SizeCode"" AND T1.""Code"" = '{Code}'
                            WHERE T0.""Code"" = '{styleCode}' 
                            ORDER BY  T0.""U_SizeCode""";
                }
                // --- Only Colour selected: get codes + names ---
                else if (!size && color)
                {
                    sql = $@"
                            SELECT DISTINCT 
                                T0.""U_ColourCode"" AS ""U_CLCODE"", 
                                T0.""U_ColourName"" AS ""U_CLRNAME"",                          
                                T1.""U_RMCLCODE"",
                                T1.""U_RMClNAME"",
                                T1.""U_SIZEPARM"",
                                T1.""U_QUANTITY"",
                                T1.""U_UOM""
                            FROM ""@FIL_MR_PSMCO"" T0 
                             LEFT OUTER JOIN ""@FIL_MR_SIZEDTLS"" T1 ON T1.""U_CLCODE"" = T0.""U_ColourCode"" AND T1.""Code"" = '{Code}'
                            WHERE T0.""Code"" = '{styleCode}' AND T0.""U_ColourAppl"" = 'Y'
                            ORDER BY T0.""U_ColourCode"" ";
                }
                // --- Both selected: get colour + size combos ---
                else // size && color
                {
                       sql = $@"
                            SELECT DISTINCT 
                                T0.""U_ColourCode"" AS ""U_CLCODE"", 
                                T0.""U_ColourName"" AS ""U_CLRNAME"",                 
                                T0.""U_SizeCode""   AS ""U_SIZECODE"",   
                                T0.""U_SizeName""   AS ""U_SIZENAME"",                 
                                T1.""U_RMCLCODE"",
                                T1.""U_RMClNAME"",
                                T1.""U_SIZEPARM"",
                                T1.""U_QUANTITY"",
                                T1.""U_UOM""
                            FROM ""@FIL_MR_PSMIP"" T0 
                            LEFT OUTER JOIN ""@FIL_MR_SIZEDTLS"" T1 
                                ON T1.""U_CLCODE"" = T0.""U_ColourCode"" 
                                AND T1.""U_SIZECODE"" = T0.""U_SizeCode"" 
                                AND T1.""Code"" = '{Code}'
                            WHERE T0.""Code"" = '{styleCode}'
                            ORDER BY T0.""U_ColourCode"", T0.""U_SizeCode""
                       ";
                  }

                // --- Execute query ---
                oRS.DoQuery(sql);

                // --- Populate DBDataSourceLine from recordset ---
                int insertRow = 0;

                while (!oRS.EoF)
                {
                    // Insert a new record at the end
                    DBDataSourceLine.InsertRecord(insertRow);

                    try
                    {
                        DBDataSourceLine.SetValue("LineId", insertRow, (insertRow + 1).ToString());
                    }
                    catch
                    {
                        // ignore if LineId not available in DS
                    }

                    // Always set baseline
                    DBDataSourceLine.SetValue("U_BASELINE", insertRow, lineId);

                    try
                    {
                        if (size && !color)
                        {
                            // size-only: fields U_SIZECODE, U_SIZENAME
                            string sCode = oRS.Fields.Item("U_SIZECODE").Value != null ? oRS.Fields.Item("U_SIZECODE").Value.ToString().Trim() : "";
                            string sName = oRS.Fields.Item("U_SIZENAME").Value != null ? oRS.Fields.Item("U_SIZENAME").Value.ToString().Trim() : "";
                            string RmCode = oRS.Fields.Item("U_RMCLCODE").Value != null ? oRS.Fields.Item("U_RMCLCODE").Value.ToString().Trim() : "";
                            string RmName = oRS.Fields.Item("U_RMClNAME").Value != null ? oRS.Fields.Item("U_RMClNAME").Value.ToString().Trim() : "";
                            string SizeParm = oRS.Fields.Item("U_SIZEPARM").Value != null ? oRS.Fields.Item("U_SIZEPARM").Value.ToString().Trim() : "";

                            string Quantity = oRS.Fields.Item("U_QUANTITY").Value != null ? oRS.Fields.Item("U_QUANTITY").Value.ToString().Trim() : "";
                            string Uom = oRS.Fields.Item("U_UOM").Value != null ? oRS.Fields.Item("U_UOM").Value.ToString().Trim() : "";

                            DBDataSourceLine.SetValue("U_SIZECODE", insertRow, sCode);
                            DBDataSourceLine.SetValue("U_SIZENAME", insertRow, sName);

                            // clear colour fields
                            DBDataSourceLine.SetValue("U_CLCODE", insertRow, "");
                            DBDataSourceLine.SetValue("U_CLRNAME", insertRow, "");
                            DBDataSourceLine.SetValue("U_RMCLCODE", insertRow, RmCode);
                            DBDataSourceLine.SetValue("U_RMClNAME", insertRow, RmName);
                            DBDataSourceLine.SetValue("U_SIZEPARM", insertRow, SizeParm);
                            DBDataSourceLine.SetValue("U_QUANTITY", insertRow, Quantity);
                            DBDataSourceLine.SetValue("U_UOM", insertRow, Uom);

                        }
                        else if (!size && color)
                        {
                            // color-only: fields U_CLCODE, U_CLRNAME
                            string cCode = oRS.Fields.Item("U_CLCODE").Value != null ? oRS.Fields.Item("U_CLCODE").Value.ToString().Trim() : "";
                            string cName = oRS.Fields.Item("U_CLRNAME").Value != null ? oRS.Fields.Item("U_CLRNAME").Value.ToString().Trim() : "";
                            string RmCode = oRS.Fields.Item("U_RMCLCODE").Value != null ? oRS.Fields.Item("U_RMCLCODE").Value.ToString().Trim() : "";
                            string RmName = oRS.Fields.Item("U_RMClNAME").Value != null ? oRS.Fields.Item("U_RMClNAME").Value.ToString().Trim() : "";
                            string SizeParm = oRS.Fields.Item("U_SIZEPARM").Value != null ? oRS.Fields.Item("U_SIZEPARM").Value.ToString().Trim() : "";
                            string Quantity = oRS.Fields.Item("U_QUANTITY").Value != null ? oRS.Fields.Item("U_QUANTITY").Value.ToString().Trim() : "";
                            string Uom = oRS.Fields.Item("U_UOM").Value != null ? oRS.Fields.Item("U_UOM").Value.ToString().Trim() : "";

                            DBDataSourceLine.SetValue("U_CLCODE", insertRow, cCode);
                            DBDataSourceLine.SetValue("U_CLRNAME", insertRow, cName);

                            // clear size fields
                            DBDataSourceLine.SetValue("U_SIZECODE", insertRow, "");
                            DBDataSourceLine.SetValue("U_SIZENAME", insertRow, "");

                            DBDataSourceLine.SetValue("U_RMCLCODE", insertRow, RmCode);
                            DBDataSourceLine.SetValue("U_RMClNAME", insertRow, RmName);
                            DBDataSourceLine.SetValue("U_SIZEPARM", insertRow, SizeParm);
                            DBDataSourceLine.SetValue("U_QUANTITY", insertRow, Quantity);
                            DBDataSourceLine.SetValue("U_UOM", insertRow, Uom);
                        }
                        else
                        {
                            // both selected: fields U_CLCODE, U_CLRNAME, U_SIZECODE, U_SIZENAME
                            string cCode = oRS.Fields.Item("U_CLCODE").Value != null ? oRS.Fields.Item("U_CLCODE").Value.ToString().Trim() : "";
                            string cName = oRS.Fields.Item("U_CLRNAME").Value != null ? oRS.Fields.Item("U_CLRNAME").Value.ToString().Trim() : "";
                            string sCode = oRS.Fields.Item("U_SIZECODE").Value != null ? oRS.Fields.Item("U_SIZECODE").Value.ToString().Trim() : "";
                            string sName = oRS.Fields.Item("U_SIZENAME").Value != null ? oRS.Fields.Item("U_SIZENAME").Value.ToString().Trim() : "";
                            string RmCode = oRS.Fields.Item("U_RMCLCODE").Value != null ? oRS.Fields.Item("U_RMCLCODE").Value.ToString().Trim() : "";
                            string RmName = oRS.Fields.Item("U_RMClNAME").Value != null ? oRS.Fields.Item("U_RMClNAME").Value.ToString().Trim() : "";
                            string SizeParm = oRS.Fields.Item("U_SIZEPARM").Value != null ? oRS.Fields.Item("U_SIZEPARM").Value.ToString().Trim() : "";

                            string Quantity = oRS.Fields.Item("U_QUANTITY").Value != null ? oRS.Fields.Item("U_QUANTITY").Value.ToString().Trim() : "";
                            string Uom = oRS.Fields.Item("U_UOM").Value != null ? oRS.Fields.Item("U_UOM").Value.ToString().Trim() : "";

                            DBDataSourceLine.SetValue("U_CLCODE", insertRow, cCode);
                            DBDataSourceLine.SetValue("U_CLRNAME", insertRow, cName);
                            DBDataSourceLine.SetValue("U_SIZECODE", insertRow, sCode);
                            DBDataSourceLine.SetValue("U_SIZENAME", insertRow, sName);

                            DBDataSourceLine.SetValue("U_RMCLCODE", insertRow, RmCode);
                            DBDataSourceLine.SetValue("U_RMClNAME", insertRow, RmName);
                            DBDataSourceLine.SetValue("U_SIZEPARM", insertRow, SizeParm);

                            DBDataSourceLine.SetValue("U_QUANTITY", insertRow, Quantity);
                            DBDataSourceLine.SetValue("U_UOM", insertRow, Uom);

                        }
                    }
                    catch (Exception exInner)
                    {
                        // If field not found or other error, log but continue
                        Application.SBO_Application.StatusBar.SetText(
                            "Populate warning: " + exInner.Message,
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    }

                    insertRow++;
                    oRS.MoveNext();
                }

             
                // --- Refresh sub-matrix ---
                subMatrix.LoadFromDataSource();
                subMatrix.AutoResizeColumns();

                oSubForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in MTXTRMAC_DoubleClickAfter: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                try
                {
                    // Attempt to unfreeze form if left frozen
                    SAPbouiCOM.Form maybe = Application.SBO_Application.Forms.Item("FIL_FRM_SZCLRCON");
                    if (maybe != null) maybe.Freeze(false);
                }
                catch { }
            }
        }


        private void MTXTRMAC_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ItemUID != "MTXTRMAC")
                    return;

                // Only these columns should trigger calculations
                string[] validCols = { "CLQUAN", "CLWTGPER", "CLEXTPER", "CLPRICE" };
                if (!validCols.Contains(pVal.ColUID))
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMAC").Specific;

                int row = pVal.Row;

                oForm.Freeze(true);

                // Read values directly from matrix
                double QtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLQUAN").Cells.Item(row).Specific).Value);
                double wstPerValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLWTGPER").Cells.Item(row).Specific).Value);
                double wstQtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLWTGQTY").Cells.Item(row).Specific).Value);
                double extPerValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXTPER").Cells.Item(row).Specific).Value);
                double extQtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXTQTY").Cells.Item(row).Specific).Value);
                double priceValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRICE").Cells.Item(row).Specific).Value);
                double totalQty = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLTTLQTY").Cells.Item(row).Specific).Value);

                double calcuQty = 0;
                double calcuPrcn = 0;
                double calcuPric = 0;


                switch (pVal.ColUID)
                {
                    case "CLQUAN":

                        double calcuw = QtyValue * (wstPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLWTGQTY", calcuw.ToString());

                        double calcue = QtyValue * (extPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLEXTQTY", calcue.ToString());

                        calcuQty = QtyValue + calcuw + calcue;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());

                        break;

                    case "CLWTGPER":
                        calcuPrcn = QtyValue * (wstPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLWTGQTY", calcuPrcn.ToString());

                        calcuQty = QtyValue + calcuPrcn + extQtyValue;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());

                        break;

                    case "CLEXTPER":
                        calcuPrcn = QtyValue * (extPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLEXTQTY", calcuPrcn.ToString());

                        calcuQty = QtyValue + wstQtyValue + calcuPrcn;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());
                        break;

                    case "CLPRICE":
                        calcuPric = priceValue * totalQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());
                        break;
                }

                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "LostFocusAfter Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }

        }


        private void MTXTRMAC_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXTRMAC").Specific;

            string styleCode = ETSTYLCD.Value;
            SAPbouiCOM.ComboBox cb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBITMGRP").Specific;
            string selDesc = cb.Selected.Description;

            try
            {
                if (pVal.ColUID == "CLITMCOD" && pVal.ItemUID == "MTXTRMAC" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string iCode = oDataTable.GetValue("ItemCode", 0).ToString();
                        string iName = oDataTable.GetValue("ItemName", 0).ToString();
                        string iGrp = oDataTable.GetValue("ItmsGrpCod", 0).ToString();
                        string iUom = oDataTable.GetValue("InvntryUom", 0).ToString();

                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLITMCOD", iCode);
                        oMatrix.SetCellWithoutValidation(row, "CLITMNAM", iName);
                        oMatrix.SetCellWithoutValidation(row, "CLITMGRP", iGrp);
                        oMatrix.SetCellWithoutValidation(row, "CLUOM", iUom);
                        oMatrix.SetCellWithoutValidation(row, "CLSTYLNO", styleCode);
                        oMatrix.SetCellWithoutValidation(row, "CLTYPE", selDesc);

                        oMatrix.FlushToDataSource();
                        oMatrix.AutoResizeColumns();
                    }

                    AddLineIfLastRowHasValue(oForm, "MTXTRMAC", "@FIL_MR_CSMTA", "U_ItemCode");
                }
                else if (pVal.ColUID == "CLPOSTN" && pVal.ItemUID == "MTXTRMAC" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string pCode = oDataTable.GetValue("Code", 0).ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLPOSTN", pCode);
                        oMatrix.FlushToDataSource();
                    }

                }

                else if (pVal.ColUID == "CLRTSTAGE" && pVal.ItemUID == "MTXTRMAC" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string pCode = oDataTable.GetValue("Code", 0).ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLRTSTAGE", pCode);
                        oMatrix.FlushToDataSource();
                    }

                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in CFL: " + ex.Message);
            }

        }

        private void MTXTRMAC_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OITM")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    if (CBITMGRP.Selected == null)
                    {
                        Application.SBO_Application.StatusBar.SetText("Please select item group first.");
                        oForm.ActiveItem = "CBITMGRP";
                        BubbleEvent = false;
                        return;
                    }
                    string val = CBITMGRP.Selected.Value;



                    // SQL call
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string sql = $@"SELECT  A.""ItemCode"" AS ""ItemsCode"" FROM OITM A INNER JOIN OITB B
                                ON A.""ItmsGrpCod"" = B.""ItmsGrpCod""
                                WHERE B.""U_ITMSGRPTP"" = '{val}'";
                    rs.DoQuery(sql);

                    // Store allowed colour codes into list
                    List<string> allowedItems = new List<string>();
                    while (!rs.EoF)
                    {
                        string item = rs.Fields.Item("ItemsCode").Value.ToString();
                        if (!string.IsNullOrEmpty(item))
                            allowedItems.Add(item);

                        rs.MoveNext();
                    }


                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    if (allowedItems.Count == 0)
                    {
                        SAPbouiCOM.Condition oCon = oCons.Add();
                        oCon.Alias = "ItemCode";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = "-1";
                    }
                    else
                    {
                        for (int i = 0; i < allowedItems.Count; i++)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "ItemCode";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = allowedItems[i];

                            // Relationship must be set on the previous condition
                            if (i > 0)
                                oCons.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                        }


                    }
                    oCFL.SetConditions(oCons);
                }

                if(cflUID == "CFL_ORST1")
                {
                   BubbleEvent = true;
                    try
                    {
                      
                        if (cflUID == "CFL_ORST1")
                        {
                            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                            int value = 6;
                            string val =value.ToString();

                            SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                            SAPbouiCOM.Condition oCon1 = oCons.Add();
                            oCon1.Alias = "AbsEntry";
                            oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_GRATER_THAN;
                            oCon1.CondVal = val;
                            oCFL.SetConditions(oCons);
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.StatusBar.SetText(
                            "Error filtering Route CFL: " + ex.Message,
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error
                        );
                        BubbleEvent = false;
                    }
                        }


                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.StatusBar.SetText(
                            "Error filtering Route CFL: " + ex.Message,
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error
                        );
                        BubbleEvent = false;
                    }

        }


        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            
            string styleCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_STYLENO", 0);
            string customer = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_CARDCODE", 0);
            string cstDesc = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("Name", 0);
            string cadNo = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_CADNTRY", 0);
            string draftSO = oForm.DataSources.DBDataSources.Item("@FIL_MH_OCSM").GetValue("U_DRFTNTRY", 0);

            if (styleCode == "")
            {
                Global.GFunc.ShowError("Enter Style Code");
                oForm.ActiveItem = "ETSTYLCD";
                return BubbleEvent = false;
            }
            else if (customer == "")
            {
                Global.GFunc.ShowError("Enter Customer Code");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;
            }
            else if (cstDesc == "")
            {
                Global.GFunc.ShowError("Enter Cost Sheet Description");
                oForm.ActiveItem = "ETCSHTDS";
                return BubbleEvent = false;
            }
            else if (cadNo == "")
            {
                Global.GFunc.ShowError("Select The CAD No");
                oForm.ActiveItem = "ETCADNO";
                return BubbleEvent = false;
            }
            else if (draftSO == "")
            {
                Global.GFunc.ShowError("Select The Draft So");
                oForm.ActiveItem = "ETDRFTSO";
                return BubbleEvent = false;
            }

            PreventEmptyLastRow(oForm, "@FIL_MR_CSMFOB", MTXFOB, "U_FOB");
            PreventEmptyLastRow(oForm, "@FIL_MR_CSMCLR", MTXCOLOR, "U_CLRCODE");
            //PreventEmptyLastRow(oForm, "@FIL_MR_CSMFAB", MTXFBRIC, "U_CLRCODE");
            PreventEmptyLastRow(oForm, "@FIL_MR_CSMTA", MTXTRMAC, "U_ItemCode");
            PreventEmptyLastRow(oForm, "@FIL_MR_CSMCST", MTXTRMFB, "U_FOB");
            PreventEmptyLastRow(oForm, "@FIL_MR_CSOTHRCS", MTXOHCST, "U_PARAMTR");
            PreventEmptyLastRow(oForm, "@FIL_MR_CSMRS", MTXROUTE, "U_RSCode");
            PreventEmptyLastRow(oForm, "@FIL_MR_SIZEDTLS", MTXSZCON, "U_QUANTITY");

            return BubbleEvent;
        }
        private void PreventEmptyLastRow(SAPbouiCOM.Form oForm, string dbDatasourceUID, SAPbouiCOM.Matrix matrix, string columnName)
        {
            SAPbouiCOM.DBDataSource oDB = oForm.DataSources.DBDataSources.Item(dbDatasourceUID);
            int rowCount = matrix.VisualRowCount;

            if (rowCount > 0)
            {
                string lastValue = oDB.GetValue(columnName, rowCount - 1).Trim();

                if(string.IsNullOrEmpty(lastValue) || lastValue.Equals("0.0"))
                {
                    matrix.DeleteRow(rowCount);
                    oDB.RemoveRecord(rowCount - 1);
                }
            }
        }


        private void MTXFBRIC_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ItemUID != "MTXFBRIC")
                    return;

                // Only these columns should trigger calculations
                string[] validCols = { "CLCONQTY", "CLWSTPER", "CLEXTPER", "CLPRICE" };
                if (!validCols.Contains(pVal.ColUID))
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXFBRIC").Specific;

                int row = pVal.Row;

                oForm.Freeze(true);

                // Read values directly from matrix
                double conQtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCONQTY").Cells.Item(row).Specific).Value);
                double wstPerValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLWSTPER").Cells.Item(row).Specific).Value);
                double wstQtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLWSTQTY").Cells.Item(row).Specific).Value);
                double extPerValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXTPER").Cells.Item(row).Specific).Value);
                double extQtyValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEXTQTY").Cells.Item(row).Specific).Value);
                double priceValue = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRICE").Cells.Item(row).Specific).Value);
                double totalQty = Convert.ToDouble(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLTTLQTY").Cells.Item(row).Specific).Value);

                double calcuQty = 0;
                double calcuPrcn = 0;
                double calcuPric = 0;


                switch (pVal.ColUID)
                {
                    case "CLCONQTY":
                        
                        double calcuw = conQtyValue * (wstPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLWSTQTY", calcuw.ToString());

                        double calcue = conQtyValue * (extPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLEXTQTY", calcue.ToString());

                        calcuQty = conQtyValue + calcuw + calcue;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());

                        break;

                    case "CLWSTPER":
                        calcuPrcn = conQtyValue * (wstPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLWSTQTY", calcuPrcn.ToString());

                        calcuQty = conQtyValue + calcuPrcn + extQtyValue;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());

                        break;

                    case "CLEXTPER":
                        calcuPrcn = conQtyValue * (extPerValue / 100);
                        oMatrix.SetCellWithoutValidation(row, "CLEXTQTY", calcuPrcn.ToString());

                        calcuQty = conQtyValue + wstQtyValue + calcuPrcn;
                        oMatrix.SetCellWithoutValidation(row, "CLTTLQTY", calcuQty.ToString());

                        calcuPric = priceValue * calcuQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());
                        break;

                    case "CLPRICE":
                        calcuPric = priceValue * totalQty;
                        oMatrix.SetCellWithoutValidation(row, "CLTOTAL", calcuPric.ToString());
                        break;
                }

                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "LostFocusAfter Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }





        private void MTXFBRIC_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXFBRIC").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSMFAB");
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string code = oDataTable.GetValue("Code", 0).ToString();
                    int row = pVal.Row; 
                    oMatrix.SetCellWithoutValidation(row, "CLRUTSTG", code);
                    oMatrix.FlushToDataSource();

                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Route CFL Error: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short,
                   SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void MTXFBRIC_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_ORST")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    int value = 6;
                    string val =value.ToString();

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "AbsEntry";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_GRATER_THAN;
                    oCon1.CondVal = val;
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Route CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }

        }



        private void MTXCOLOR_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;

                int row = pVal.Row;

                    if (row > 0)
                    {
                        // Get value
                        string clrCode = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCRCODE", row)).Value.Trim();

                        // Only do if CLFOB has value
                        if (!string.IsNullOrEmpty(clrCode))
                        {
                            // Get LineId value from "#" column
                            string lineIdStr = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("#", row)).Value.Trim();

                            if (int.TryParse(lineIdStr, out int lineId))
                            {
                                lastFocusedLineIdMTXCOLOR = lineId;
                            }

                        }
                    }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void BTNFBRIC_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix mtxColor = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
            SAPbouiCOM.Matrix mtxFabric = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXFBRIC").Specific;
            string cadNo = ETCADNO.Value;

            if (oForm.Mode==SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                // Fetch From CAD   
                string fobline = lastFocusedLineIdMTXFOB.ToString();

                try
                {
                   // oForm.Freeze(true);
                    List<string> colorList = new List<string>();

                    for (int i = 1; i <= mtxColor.RowCount; i++)
                    {
                        string clrCode = ((SAPbouiCOM.EditText)mtxColor.Columns.Item("CLCRCODE").Cells.Item(i).Specific).Value;

                        if (!string.IsNullOrEmpty(clrCode))
                            colorList.Add(clrCode);
                    }

                    if (colorList.Count == 0)
                    {
                        Application.SBO_Application.StatusBar.SetText("No color codes found in matrix.", SAPbouiCOM.BoMessageTime.bmt_Short);
                        BubbleEvent = false;
                        return;
                    }

                    string inColorList = string.Join("','", colorList);

                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    //string sql = $@"
                    //     SELECT 
                    //        A.""U_BASECLR"",A.""U_ITEMCODE"",A.""U_ITEMNAME"",C.""ItmsGrpNam"",
                    //        A.""U_USETYPE"",A.""U_ACTCONSM"",A.""U_UOM"",
                    //        B.""OnHand"",B.""LastPurPrc""
                    //        FROM ""@FIL_DR_CADFABCN"" A
                    //        LEFT JOIN OITM B ON A.""U_ITEMCODE"" = B.""ItemCode""
                    //        LEFT JOIN OITB C ON B.""ItmsGrpCod"" = C.""ItmsGrpCod""
                    //        WHERE A.""DocEntry"" = '{cadNo}'
                    //        AND A.""U_BASECLR"" IN ('{inColorList}');
                    //        ";
                    string sql = $@"
                                    SELECT *
                                    FROM (
                                        SELECT 
                                            CASE 
                                                WHEN D.""U_CLRAPPL"" = 'Y' THEN A.""U_BASECLR"" 
                                                ELSE 'No Color' 
                                            END AS ""U_BASECLR"",
                                            A.""U_ITEMCODE"",
                                            A.""U_ITEMNAME"",
                                            C.""ItmsGrpNam"",
                                            A.""U_USETYPE"",
                                            A.""U_ACTCONSM"",
                                            A.""U_UOM"",
                                            B.""OnHand"",
                                            B.""LastPurPrc"",

                                            ROW_NUMBER() OVER (
                                                PARTITION BY 
                                                    A.""U_ITEMCODE"",
                                                    CASE WHEN D.""U_CLRAPPL"" = 'Y' THEN A.""U_BASECLR"" ELSE 'NULL' END
                                                ORDER BY  CASE WHEN D.""U_CLRAPPL"" = 'Y' THEN 0 ELSE 1 END
                                            ) AS RN
                                        FROM ""@FIL_DR_CADFABCN"" A
                                        INNER JOIN ""@FIL_DR_CADMFAB"" D ON D.""DocEntry"" = A.""DocEntry"" AND D.""U_ITEMCODE"" = A.""U_ITEMCODE""
                                        LEFT JOIN OITM B  ON A.""U_ITEMCODE"" = B.""ItemCode""
                                        LEFT JOIN OITB C   ON B.""ItmsGrpCod"" = C.""ItmsGrpCod""
                                        WHERE A.""DocEntry"" = '{cadNo}'
                                          AND A.""U_BASECLR"" IN ('{inColorList}')
                                    ) T
                                    WHERE T.RN = 1
                                    ORDER BY CASE WHEN T.""U_BASECLR"" = '' THEN 1 ELSE 0 END,T.""U_BASECLR"";";

                    oRS.DoQuery(sql);

                    if (oRS.RecordCount == 0)
                    {
                        Application.SBO_Application.StatusBar.SetText("No fabric found for selected colors.", SAPbouiCOM.BoMessageTime.bmt_Short);
                        BubbleEvent = false;
                        return;
                    }

                    int newRow;

                    // ✔ Only clear in ADD mode
                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    {
                        mtxFabric.Clear();
                        newRow = 1;
                    }
                    else
                    {
                        // ✔ Append new rows in UPDATE mode
                        newRow = mtxFabric.RowCount + 1;
                    }

                    while (!oRS.EoF)
                    {
                        string clr = oRS.Fields.Item(0).Value.ToString();
                        string itmc = oRS.Fields.Item(1).Value.ToString();

                        // ❗ Skip if duplicate
                        if (IsDuplicateInMatrix(mtxFabric, clr, itmc))
                        {
                            oRS.MoveNext();
                            continue;
                        }

                        mtxFabric.AddRow();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("#").Cells.Item(newRow).Specific).Value = newRow.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCLRCOD").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(0).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMCOD").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(1).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMNAM").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(2).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMTYP").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(3).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPOSITN").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(4).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCADQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(5).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCONQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(5).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLUOM").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(6).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLINSTCK").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(7).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPPRICE").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(8).Value.ToString();
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLFCADNO").Cells.Item(newRow).Specific).Value = cadNo;
                        ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLFBRFLN").Cells.Item(newRow).Specific).Value = fobline;

                        newRow++;
                        oRS.MoveNext();
                    }

                    mtxFabric.AutoResizeColumns();
                    oForm.Freeze(false);
                }
                catch (Exception ex)
                {
                    oForm.Freeze(false);
                    Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
                        SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
                oForm.Freeze(false);
            }
            //else if(oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            //{
            //    //Fetch From Own Table 
            //    if (lastFocusedLineIdMTXCOLOR < 0)
            //    {
            //        //Application.SBO_Application.MessageBox("Select the Color Row First ", 1, "OK");
            //        //BubbleEvent = false;
            //        //return;
            //    }
            //    else
            //    {
            //        oForm.Freeze(true);
            //        string cstCode = ETCSHTCD.Value;
            //        string clrCode = ((SAPbouiCOM.EditText)mtxColor.Columns.Item("CLCRCODE").Cells.Item(lastFocusedLineIdMTXCOLOR).Specific).Value;
            //        string fobline = lastFocusedLineIdMTXCOLOR.ToString();
            //        try
            //        {
            //            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
            //                Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            //            string sql = $@"Select ""LineId"",""U_CLRCODE"",""U_ITEMCODE"",""U_ITEMNAME"",""U_ITEMTYPE"",""U_POSITION"",""U_ONHAND"",""U_LstEvlPric"",""U_CADQTY"",
            //            ""U_CONQTY"",""U_WSTGPRCN"",""U_WSTGQTY"",""U_EXTRQTYP"",""U_EXTRQTY"",""U_TOTALQTY"",""U_UOM"",
            //            ""U_PRICELST"",""U_PRICE"",""U_TOTAL"",""U_ISSUEMTH"",""U_RSTAGE"",""U_FROMCAD"",""U_FOBLINE"" from 
            //            ""@FIL_MR_CSMFAB"" WHERE ""Code"" ='{cstCode}' AND ""U_CLRCODE"" = '{clrCode}';";

            //            oRS.DoQuery(sql);

            //            if (oRS.RecordCount == 0)
            //            {
            //                Application.SBO_Application.StatusBar.SetText("No fabric found.", SAPbouiCOM.BoMessageTime.bmt_Short);
            //                BubbleEvent = false;
            //                return;
            //            }

            //            // Clear matrix rows
            //            mtxFabric.Clear();

            //            int newRow = 1;

            //            while (!oRS.EoF)
            //            {

            //                mtxFabric.AddRow();

            //                // Fill only required columns
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("#").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(0).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCLRCOD").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(1).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMCOD").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(2).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMNAM").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(3).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLITMTYP").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(4).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPOSITN").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(5).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLINSTCK").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(6).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPPRICE").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(7).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCADQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(8).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLCONQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(9).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLWSTPER").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(10).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLWSTQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(11).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLEXTPER").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(12).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLEXTQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(13).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLTTLQTY").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(14).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLUOM").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(15).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPRCLST").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(15).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLPRICE").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(16).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLTOTAL").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(18).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLISMETH").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(19).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLRUTSTG").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(20).Value.ToString();
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLFCADNO").Cells.Item(newRow).Specific).Value = cadNo;
            //                ((SAPbouiCOM.EditText)mtxFabric.Columns.Item("CLFBRFLN").Cells.Item(newRow).Specific).Value = fobline;

            //                newRow++;
            //                oRS.MoveNext();
            //            }

            //            mtxFabric.AutoResizeColumns();
            //            oForm.Freeze(false);
            //            //Application.SBO_Application.StatusBar.SetText("Fabric loaded.", SAPbouiCOM.BoMessageTime.bmt_Short);
            //        }
            //        catch (Exception ex)
            //        {
            //            oForm.Freeze(false);
            //            Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
            //                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            //        }
            //        oForm.Freeze(false);
            //    }
            //}
            
        }

        private bool IsDuplicateInMatrix(SAPbouiCOM.Matrix mtx, string color, string itemCode)
        {
            for (int i = 1; i <= mtx.RowCount; i++)
            {
                string existingColor =
                    ((SAPbouiCOM.EditText)mtx.Columns.Item("CLCLRCOD").Cells.Item(i).Specific).Value;

                string existingItem =
                    ((SAPbouiCOM.EditText)mtx.Columns.Item("CLITMCOD").Cells.Item(i).Specific).Value;

                if (existingColor == color && existingItem == itemCode)
                {
                    return true;   // duplicate found
                }
            }
            return false;
        }



        private void MTXCOLOR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSMCLR");


            try
            {
                if (pVal.ColUID == "CLCRCODE" && pVal.ItemUID == "MTXCOLOR" && pVal.ActionSuccess)
                {
                    SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;
                    if (oDataTable.Rows.Count > 0)
                    {
                        string cCode = oDataTable.GetValue("Code", 0).ToString();
                        string cName = oDataTable.GetValue("Name", 0).ToString();
                        string lineId = lastFocusedLineIdMTXFOB.ToString();
                        int row = pVal.Row;
                        oMatrix.SetCellWithoutValidation(row, "CLCRCODE", cCode);
                        oMatrix.SetCellWithoutValidation(row, "CLCRNAME", cName);
                        oMatrix.SetCellWithoutValidation(row, "CLCRFOBL", lineId);
                        oMatrix.FlushToDataSource();
                    }

                    AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_MR_CSMCLR", "U_CLRCODE");
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error in CFL: " + ex.Message);
            }

        }

        private void MTXCOLOR_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
             BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_CLR");

                if (lastFocusedLineIdMTXFOB < 0)
                {
                    Application.SBO_Application.MessageBox("Set The FOB First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {
                    // Read Style Code
                    string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value.Trim();
                    if (string.IsNullOrEmpty(styleCode))
                        return;

                    // SQL call
                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string sql = $@"SELECT ""U_ColourCode"" FROM ""@FIL_MR_PSMCO"" WHERE ""Code"" = '{styleCode}' AND ""U_ColourAppl"" = 'Y'";
                    rs.DoQuery(sql);

                    // Store allowed colour codes into list
                    List<string> allowedColors = new List<string>();
                    while (!rs.EoF)
                    {
                        string clr = rs.Fields.Item("U_ColourCode").Value.ToString();
                        if (!string.IsNullOrEmpty(clr))
                            allowedColors.Add(clr);

                        rs.MoveNext();
                    }


                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    if (allowedColors.Count == 0)
                    {
                        SAPbouiCOM.Condition oCon = oCons.Add();
                        oCon.Alias = "Code";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = "-1";
                    }
                    else
                    {
                        for (int i = 0; i < allowedColors.Count; i++)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "Code";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = allowedColors[i];

                            // Relationship must be set on the previous condition
                            if (i > 0)
                                oCons.Item(i - 1).Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                        }


                    }
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }




        private void MTXFOB_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXFOB").Specific;
                SAPbouiCOM.Matrix mtxColor = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                int row = pVal.Row;
                string fobLnValue = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("#", row)).Value.Trim();
                string fobValue = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLFOB", row)).Value.Trim();
                string cstCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTCD").Specific).Value.Trim();
                if (pVal.ColUID == "CLFOB")
                {
                    if (row > 0)
                    {
                        if (!string.IsNullOrEmpty(fobValue))
                        {
                            string lineIdStr = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("#", row)).Value.Trim();
                            if (int.TryParse(lineIdStr, out int lineId))
                            {
                                lastFocusedLineIdMTXFOB = lineId;
                            }
                            AddLineIfLastRowHasValue(oForm, "MTXFOB", "@FIL_MR_CSMFOB", "U_FOB");
                        }
                    }
                }

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    if (pVal.ColUID == "CLFOB")
                    {
                        int totalrow = oMatrix.VisualRowCount;
                        //string cstCode = ETCSHTCD.Value;

                        if (totalrow > 2)
                        {
                            int prevRow = totalrow - 1;
                            string prevRowFOB =
                                ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLFOB", prevRow)).Value.Trim();

                            if (!string.IsNullOrEmpty(prevRowFOB) || !prevRowFOB.Equals("0.0"))
                            {
                                bool prevExists = CheckFOBExists(prevRowFOB, cstCode);
                                if (!prevExists)
                                {
                                    Application.SBO_Application.MessageBox("You have to add the previous FOB ");
                                    oMatrix.SetCellWithoutValidation(prevRow, "CLFOB", " ");
                                    oMatrix.DeleteRow(prevRow);
                                    oMatrix.FlushToDataSource();
                                    
                                }
                            }
                        }
                    }
                }
                else if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    try
                    {
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                            Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                        string sql = $@"Select ""LineId"",""U_CLRCODE"",""U_CLRNAME"",""U_FOBLINE"" FROM ""@FIL_MR_CSMCLR"" WHERE ""Code""= '{cstCode}' 
                                    AND ""U_FOBLINE"" = '{fobLnValue}';";
                        oRS.DoQuery(sql);

                        if (oRS.RecordCount == 0)
                        {
                            Application.SBO_Application.StatusBar.SetText("No Colour Under this FOB.", SAPbouiCOM.BoMessageTime.bmt_Short);
                            return;
                        }

                        oForm.Freeze(true);
                        mtxColor.Clear();

                        int newRow = 1;
                        while (!oRS.EoF)
                        {
                            mtxColor.AddRow();

                            // Fill only required columns
                            ((SAPbouiCOM.EditText)mtxColor.Columns.Item("#").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(0).Value.ToString();
                            ((SAPbouiCOM.EditText)mtxColor.Columns.Item("CLCRCODE").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(1).Value.ToString();
                            ((SAPbouiCOM.EditText)mtxColor.Columns.Item("CLCRNAME").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(2).Value.ToString();
                            ((SAPbouiCOM.EditText)mtxColor.Columns.Item("CLCRFOBL").Cells.Item(newRow).Specific).Value = oRS.Fields.Item(3).Value.ToString();
                            newRow++;
                            oRS.MoveNext();
                        }
                        mtxColor.AutoResizeColumns();
                        oForm.Freeze(false);
                    }
                    catch (Exception ex)
                    {
                        oForm.Freeze(false);
                        Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private bool CheckFOBExists(string fobValue,string code)
        {
            if (string.IsNullOrEmpty(fobValue)|| string.IsNullOrEmpty(code))
                return false;

            SAPbobsCOM.Recordset oRS =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string sql = $@"SELECT TOP 1 ""U_FOB"" FROM ""@FIL_MR_CSMFOB"" WHERE ""U_FOB"" = '{fobValue}' AND ""Code""='{code}' ";
            oRS.DoQuery(sql);
            return !oRS.EoF;  
        }


        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            
            ////Item Group Combobox
            //string itemGrpSql = @"SELECT  ""ItmsGrpCod"", ""ItmsGrpNam"" FROM ""OITB""  ";
            //SAPbouiCOM.ComboBox CBITMGRP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBITMGRP").Specific;
            //Global.GFunc.setComboBoxValue(CBITMGRP, itemGrpSql);

            

        }



        private void ETDRFTSO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Make sure this handler runs ONLY for the Draft field + Draft CFL
            if (pVal.ItemUID != "ETDRFTSO") return;

            var cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            if (cflArg.ChooseFromListUID != "CFL_DRFT") return;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0) return;

            string docEntry = dt.GetValue("DocEntry", 0).ToString().Trim();
            string docNum = dt.GetValue("DocNum", 0).ToString().Trim();
            cardCode = dt.GetValue("CardCode", 0).ToString().Trim();

            ETDRFTSO.Value = docEntry;
            ETDRFTNM.Value = docNum;

            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string sql = $@"SELECT COALESCE(SUM(""Quantity""), 0) AS ""QUANTITY""
                    FROM ""QUT1""
                    WHERE ""DocEntry"" = {docEntry};";
            oRS.DoQuery(sql);

            ETOTLQTY.Value = oRS.Fields.Item("QUANTITY").Value.ToString();

            EnsureLine(oForm, "MTXFOB", "@FIL_MR_CSMFOB");
            EnsureLine(oForm, "MTXCOLOR", "@FIL_MR_CSMCLR");
            EnsureLine(oForm, "MTXFBRIC", "@FIL_MR_CSMFAB");
            EnsureLine(oForm, "MTXTRMAC", "@FIL_MR_CSMTA");
            EnsureLine(oForm, "MTXTRMFB", "@FIL_MR_CSMCST");

            SAPbouiCOM.Item ETCUSCOD = oForm.Items.Item("ETCUSCOD");
            ETCUSCOD.Enabled = true;

            SAPbouiCOM.EditText ECUSCOD = (SAPbouiCOM.EditText)ETCUSCOD.Specific;
            ECUSCOD.ChooseFromListUID = "CFL_OCRD";
            ECUSCOD.ChooseFromListAlias = "CardCode";

            GenerateCostCode(oForm);
            GenerateCostVersion(oForm);
        }



        private void ETDRFTSO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DRFT")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    //styleNO fetching
                    string styleNo = ETSTYLCD.Value;
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_StyleNo";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = styleNo;
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

        private void ETCADNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string docEntry = dt.GetValue("DocEntry", 0).ToString().Trim();
            string docNum = dt.GetValue("DocNum", 0).ToString().Trim();


            ETCADNO.Value = docEntry;
            ETCADNM.Value = docNum;

        }

        private void ETCADNO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_CAD")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    //styleNO fetching
                    string styleCode = ETSTYLCD.Value;
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon;

                    oCon = oCons.Add();
                    oCon.Alias = "U_STYLENO";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = styleCode;

                    oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    oCon = oCons.Add();
                    oCon.Alias = "U_STATUS";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = "C";

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

        private void ETCUSCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CardCode", 0).ToString().Trim();
            string Name = dt.GetValue("CardName", 0).ToString().Trim();

            if (!string.IsNullOrEmpty(cardCode))
            {
                if (!string.Equals(Code, cardCode, StringComparison.OrdinalIgnoreCase))
                {
                    // Show warning message
                    Application.SBO_Application.MessageBox("Selected Customer does not match with Dratt SO  customer!", 1, "OK");

                }
            }

            ETCUSCOD.Value = Code;
            ETCUSNAM.Value = Name;

            if (!string.IsNullOrEmpty(brandCode))
            {
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = $@"
                    Select ""U_STDPFTPR"" 
                        FROM ""@FIL_MR_CUSTBRDMAP"" WHERE ""Code""='{Code}' and ""U_BRNDCODE""='{brandCode}' ";


                oRS.DoQuery(sql);
                string stdValue = "";
                if (!oRS.EoF)
                {
                    stdValue = oRS.Fields.Item("U_STDPFTPR").Value.ToString();
                }

                ETNDPRFT.Value = stdValue;
            }
        }

        private void ETSTYLCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();
            string curr = dt.GetValue("U_CURRENCY", 0).ToString().Trim();
            string uom = dt.GetValue("U_UoM", 0).ToString().Trim();
            string route = dt.GetValue("U_RSTemp", 0).ToString().Trim();
            brandCode = dt.GetValue("U_Brand", 0).ToString().Trim();


            ETSTYLCD.Value = Code;
            ETSTYLDS.Value = Name;
            ETCURR.Value = curr;
            ETUOM.Value = uom;
            ETRTSGCD.Value = route;  
        }



        private void GenerateCostCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                string styleCode = ETSTYLCD.Value.Trim();
                string draftCode = ETDRFTSO.Value.Trim();
                string currdate = DateTime.Now.ToString("ddMMyyyy");

                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sqlCheck = $@"
                    SELECT
                        CASE
                            WHEN EXISTS (
                                SELECT 1
                                FROM ""@FIL_MH_OCSM""
                                WHERE ""U_STYLENO""  = '{styleCode}'
                                  AND ""U_DRFTNTRY"" = '{draftCode}'
                            )
                            THEN 'True'
                            ELSE (
                                SELECT LPAD(TO_NVARCHAR(COUNT(*) + 1), 2, '0')
                                FROM ""@FIL_MH_OCSM""
                                WHERE ""U_STYLENO""  = '{styleCode}'
                                  AND ""U_DRFTNTRY"" = '{draftCode}'
                            )
                        END AS ""RESULT""
                    FROM DUMMY";

                oRS.DoQuery(sqlCheck);
                string result = oRS.EoF ? "" : (oRS.Fields.Item("RESULT").Value ?? "").ToString().Trim();

                if (result.Equals("True", StringComparison.OrdinalIgnoreCase))
                {
                    Application.SBO_Application.MessageBox(
                        "You cant add this Draft So , But you can duplicate",
                        1, "OK"
                    );

                    // This runs only after user clicks OK
                    //oForm.Close();
                    return;
                }

                else
                {
                    string costSheetCode = $"{styleCode}-{currdate}-{draftCode}-{result}";
                    if (oForm.Items.Item("ETCSHTCD") != null)
                    {
                        var oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTCD").Specific;
                        oEdit.Value = costSheetCode;
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Route Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }


        private void GenerateCostVersion(SAPbouiCOM.Form oForm)
        {
            try
            {
                string styleCode = ETSTYLCD.Value;
                string draftCode = ETDRFTSO.Value;
                // --- Get Next Available DocEntry from @FIL_MH_ORSM
                string nextValue = string.Empty;
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string sql = $@"
                    SELECT
                       LPAD(TO_NVARCHAR(COUNT(*) + 1), 2, '0') AS ""RESULT""
                    FROM ""@FIL_MH_OCSM""
                    WHERE ""U_STYLENO"" = '{styleCode}'
                    AND ""U_DRFTNTRY"" = '{draftCode}'; ";


                oRS2.DoQuery(sql);

                if (!oRS2.EoF)
                    nextValue = oRS2.Fields.Item("RESULT").Value.ToString();

                // --- Generate the Style Code ---
                string verCode = $"{styleCode}-{nextValue}";

                // --- Set Value to ETSTYLID ---
                if (oForm.Items.Item("ETSTYLCD") != null)
                {
                    SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific;
                    oEdit.Value = verCode;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error generating Version Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
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

                // Sync UI to DB first
                matrix.FlushToDataSource();

                int dbRowCount = db.Size;

                // If no rows exist in DB → add first row
                if (dbRowCount == 0)
                {
                    Global.GFunc.SetNewLine(matrix, db, 1, "");
                    return;
                }

                // Last DB row index (0 based)
                int lastDbRow = dbRowCount - 1;

                // Last value
                string lastValue = db.GetValue(columnName, lastDbRow).Trim();

                // If last row has value and not "0.0" → add new line
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



        public static void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);

            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
            }
        }


        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                int formWidth = oForm.Width;
                int formHeight = oForm.Height;

                var MTXTRMAC = oForm.Items.Item("MTXTRMAC");
                var MTXTRMFB = oForm.Items.Item("MTXTRMFB");

  
                int paneHeight = 254;

                // gaps
                int topGap = 120;
                int middleGap = 15;
                int bottomGaps = 10;
                

                int usableHeight = paneHeight - (topGap + middleGap + bottomGaps);
                int matrixHeight = (usableHeight + 140) / 2;

                // first matrix
                MTXTRMAC.Top = topGap;
                MTXTRMAC.Height = matrixHeight + 50;

                // second matrix
                MTXTRMFB.Top = MTXTRMAC.Top + MTXTRMAC.Height + middleGap;
                MTXTRMFB.Height = matrixHeight + 2;


                // Margins
                int leftMargin = 21;
                int spacing = 8;

                // Fixed widths
                int widthFOB = 90;
                int widthColor = 142;

                // Fabric width auto
                int widthFabric = formWidth - (leftMargin + widthFOB + spacing + widthColor + spacing + 20);
                if (widthFabric < 150)
                    widthFabric = 150;

                var mtxFOB = oForm.Items.Item("MTXFOB");
                var mtxCOLOR = oForm.Items.Item("MTXCOLOR");
                var mtxFABRIC = oForm.Items.Item("MTXFBRIC");

                mtxFOB.Left = leftMargin;
                mtxFOB.Width = widthFOB;

                mtxCOLOR.Left = mtxFOB.Left + mtxFOB.Width + spacing;
                mtxCOLOR.Width = widthColor;

                mtxFABRIC.Left = mtxCOLOR.Left + mtxCOLOR.Width + spacing;
                mtxFABRIC.Width = widthFabric;

                // ---------------------------------------------------------
                // ** FIXED TAB RESIZING (CORRECT LOGIC ) **
                // ---------------------------------------------------------

                int currentPane = oForm.PaneLevel;
                if (currentPane != 2) return;

                var itM1 = oForm.Items.Item("MTXTRMAC");
                var itM2 = oForm.Items.Item("MTXTRMFB");

                SAPbouiCOM.Matrix m1 = (SAPbouiCOM.Matrix)itM1.Specific;
                SAPbouiCOM.Matrix m2 = (SAPbouiCOM.Matrix)itM2.Specific;

                // ===== Tab content area derived from INITIAL layout (scaled with form resize) =====
                const int tabLeft = 11;
                const int tabTop = 83;

                const int formW0 = 1003;
                const int formH0 = 468;

                const int tabW0 = 977;
                const int tabH0 = 254;

                int rightGap = formW0 - (tabLeft + tabW0);     // 15
                int bottomGap = formH0 - (tabTop + tabH0);     // 131

                // ===== Inner layout inside tab =====
                const int marginLeft = 7;
                const int marginRight = 5;
                const int marginTop = 31;
                const int gap = 18;
                const int marginBottom = 13;

                const int baseH1 = 112;
                const int baseH2 = 80;

                // Better minimums so it never becomes “tiny”
                const int minW = 600;
                const int minH1 = 90;
                const int minH2 = 70;

                oForm.Freeze(true);
                try
                {
                    // Calculate usable tab area from current form size
                    int tabW = oForm.Width - tabLeft - rightGap;
                    int tabH = oForm.Height - tabTop - bottomGap;

                    if (tabW < minW) tabW = minW;
                    if (tabH < (marginTop + gap + marginBottom + minH1 + minH2))
                        tabH = (marginTop + gap + marginBottom + minH1 + minH2);

                    int innerW = tabW - marginLeft - marginRight;
                    int innerH = tabH - marginTop - gap - marginBottom;

                    // Proportional heights
                    double totalBase = (double)(baseH1 + baseH2);
                    int h1 = (int)Math.Round(innerH * (baseH1 / totalBase));
                    int h2 = innerH - h1;

                    // Enforce min heights (and rebalance)
                    if (h1 < minH1) { h1 = minH1; h2 = innerH - h1; }
                    if (h2 < minH2) { h2 = minH2; h1 = innerH - h2; }

                    // Final positions
                    int left = tabLeft + marginLeft;
                    int top1 = tabTop + marginTop;
                    int top2 = top1 + h1 + gap;

                    itM1.Left = left;
                    itM1.Top = top1;
                    itM1.Width = innerW;
                    itM1.Height = h1;

                    itM2.Left = left;
                    itM2.Top = top2;
                    itM2.Width = innerW;
                    itM2.Height = h2;

                    // IMPORTANT: AutoResizeColumns() on every resize can make columns “weird” + heavy.
                    // Run only when form grows, or comment out:
                    // m1.AutoResizeColumns();
                    // m2.AutoResizeColumns();
                }
                finally
                {
                    oForm.Freeze(false);
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Resize Error: " + ex.Message);
            }
        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
    }
}
