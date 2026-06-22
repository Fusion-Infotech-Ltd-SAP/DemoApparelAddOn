using Apparel_AddOn.Helper;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.CAD", "Resources/CAD.b1f")]
    class CAD : UserFormBase
    {
        public CAD()
        {
        }

        private SAPbouiCOM.StaticText STSTYLE, STCUSTYE, STSTATUS, STDOCNUM, STDOCDAT, STCADC,
                                      STMARCHR, STDRAFTO, STREMARK, STMERCON, STSIZE, STCOLOUR;

        private SAPbouiCOM.EditText ETDOCTRY, ETSTYLNO, ETCSTYLC, ETSTYLNM, ETCSTYLN, ETDOCNUM,
                                    ETDDATE, ETMERCHC, ETMERCHN, ETDONO, ETDONAM, EXTREMRK;

        private SAPbouiCOM.ComboBox CBSTATUS;

        private SAPbouiCOM.Button ADDButton, CancelButton, DoRefreshBtn;

        private SAPbouiCOM.Matrix MTX_COLUR, MTX_CCON, MTX_SIZE, MTX_MCON;

        private SAPbouiCOM.LinkedButton LINKDO, LINKSTYL, LINKMRC;

        static Dictionary<string, bool> formFreezeState = new Dictionary<string, bool>();

        public override void OnInitializeComponent()
        {
            //                                    ------> Static Text <------\\
            this.STSTYLE = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLE").Specific));
            this.STCUSTYE = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTYE").Specific));
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STMARCHR = ((SAPbouiCOM.StaticText)(this.GetItem("STMARCHR").Specific));
            this.STDRAFTO = ((SAPbouiCOM.StaticText)(this.GetItem("STDRAFTO").Specific));
            this.STREMARK = ((SAPbouiCOM.StaticText)(this.GetItem("STREMARK").Specific));
            this.STMERCON = ((SAPbouiCOM.StaticText)(this.GetItem("STMERCON").Specific));
            this.STSIZE = ((SAPbouiCOM.StaticText)(this.GetItem("STSIZE").Specific));
            this.STCOLOUR = ((SAPbouiCOM.StaticText)(this.GetItem("STCOLOUR").Specific));
            this.STCADC = ((SAPbouiCOM.StaticText)(this.GetItem("STCADC").Specific));
            //                                     ------> Edit Text <-----------\\
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETSTYLNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNO").Specific));
            this.ETSTYLNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLNO_ChooseFromListAfter);
            this.ETCSTYLC = ((SAPbouiCOM.EditText)(this.GetItem("ETCSTYLC").Specific));
            this.ETSTYLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNM").Specific));
            this.ETCSTYLN = ((SAPbouiCOM.EditText)(this.GetItem("ETCSTYLN").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDDATE = ((SAPbouiCOM.EditText)(this.GetItem("ETDDATE").Specific));
            this.ETMERCHC = ((SAPbouiCOM.EditText)(this.GetItem("ETMERCHC").Specific));
            this.ETMERCHN = ((SAPbouiCOM.EditText)(this.GetItem("ETMERCHN").Specific));
            this.ETDONO = ((SAPbouiCOM.EditText)(this.GetItem("ETDONO").Specific));
            this.ETDONO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETDONO_ChooseFromListAfter);
            this.ETDONAM = ((SAPbouiCOM.EditText)(this.GetItem("ETDONAM").Specific));
            this.EXTREMRK = ((SAPbouiCOM.EditText)(this.GetItem("EXTREMRK").Specific));
            //                                      ------> Matrix <------\\
            this.MTX_COLUR = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_COLUR").Specific));
            this.MTX_CCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_CCON").Specific));
            this.MTX_SIZE = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_SIZE").Specific));
            this.MTX_MCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_MCON").Specific));
            //                                     ------> Combo Box <------\\
            this.CBSTATUS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATUS").Specific));
            //                                     ------> Button <------\\
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.DoRefreshBtn = ((SAPbouiCOM.Button)(this.GetItem("BTNDASO").Specific));
            //                            ------> CFL Event <------\\
            this.MTX_COLUR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTX_COLUR_ChooseFromListAfter);
            this.MTX_MCON.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTX_MCON_ChooseFromListAfter);
            //                             ------> Validation && Button Press <------\\
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.DoRefreshBtn.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.DoRefreshBtn_PressedAfter);
            //                             ------> Single Selection Colour <------\\
            this.MTX_COLUR.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.MTX_COLUR_ClickAfter);
            //                             ------> Link Btn <------\\
            this.LINKDO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LINKDO").Specific));
            this.LINKSTYL = ((SAPbouiCOM.LinkedButton)(this.GetItem("LINKSTYL").Specific));
            this.LINKSTYL.PressedBefore += new SAPbouiCOM._ILinkedButtonEvents_PressedBeforeEventHandler(this.LINKSTYL_PressedBefore);
            this.LINKMRC = ((SAPbouiCOM.LinkedButton)(this.GetItem("LINKMRC").Specific));
            this.LINKMRC.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.LINKMRC_PressedAfter);
            this.LINKMRC.PressedBefore += new SAPbouiCOM._ILinkedButtonEvents_PressedBeforeEventHandler(this.LINKMRC_PressedBefore);
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {

        }

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            AdjustMatrixSizes(oForm);

        }

        private void AdjustMatrixSizes(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                //// You can adjust based on form size
                int formWidth = oForm.Width;
                int formHeight = oForm.Height;

                oForm.Items.Item("STCADC").Top = (int)(formHeight / 2.38);

                oForm.Items.Item("MTX_CCON").Top = (int)(formHeight / 2.2);
                oForm.Items.Item("MTX_CCON").Height = (int)(formHeight / 2.8);
                oForm.Items.Item("MTX_CCON").Width = formWidth - 15;

                oForm.Items.Item("MTX_COLUR").Height = (int)(formHeight / 4.1);
                oForm.Items.Item("MTX_COLUR").Width = oForm.Items.Item("STCUSTYE").Width + oForm.Items.Item("CBSTATUS").Width + 15;

                oForm.Items.Item("MTX_MCON").Height = (int)(formHeight / 2.8);
                oForm.Items.Item("MTX_MCON").Width = oForm.Items.Item("STDOCNUM").Left - (oForm.Items.Item("MTX_COLUR").Width + 15);
                oForm.Items.Item("MTX_MCON").Left = oForm.Items.Item("MTX_COLUR").Width + 15;

                oForm.Items.Item("MTX_SIZE").Height = (int)(formHeight / 4.40);
                oForm.Items.Item("MTX_SIZE").Width = oForm.Items.Item("STCUSTYE").Width + oForm.Items.Item("CBSTATUS").Width + 25;
                oForm.Items.Item("MTX_SIZE").Left = oForm.Items.Item("STDRAFTO").Left;

                //Column Width Optimize
                SAPbouiCOM.Matrix oMatrix_COLUR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                oMatrix_COLUR.AutoResizeColumns();
                SAPbouiCOM.Matrix oMatrix_SIZE = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                oMatrix_SIZE.AutoResizeColumns();
                SAPbouiCOM.Matrix oMatrix_MCON = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                oMatrix_MCON.AutoResizeColumns();
                SAPbouiCOM.Matrix oMatrix_CCON = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                oMatrix_CCON.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText($"Resize error: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void DoRefreshBtn_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE) //For Update Mode
            {
                oForm.Freeze(true);
                SAPbouiCOM.Matrix oMatrixSize = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                SAPbouiCOM.DBDataSource dbs_CCON = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABSZ");
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                SAPbouiCOM.EditText etDONo = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONO").Specific;
                string docDOValue = etDONo.Value;
                string sql_matrix = $"SELECT A.\"U_ColourCode\", A.\"U_ColourName\", A.\"U_SizeCode\", B.\"Name\" AS \"U_SizeName\" , A.\"U_Qty\", A.\"U_TotalQty\" FROM \"@FIL_DR_OQUT\" A " +
                    $"LEFT OUTER JOIN \"@FIL_MH_SIZEMSTR\" B ON A.\"U_SizeCode\" = B.\"Code\" " +
                    $"LEFT OUTER JOIN \"OQUT\" C ON A.\"DocEntry\" = C.\"U_CRSZNTRY\"" +
                    $"WHERE C.\"DocEntry\" = {docDOValue}  ORDER BY \"LineId\" ASC;";
                oRS.DoQuery(sql_matrix);

                int i = 0;
                if (oRS.RecordCount > 0)
                {

                    while (!oRS.EoF)
                    {
                        int existingIndex = -1;
                        for (int j = 0; j < dbs_CCON.Size; j++)
                        {
                            string dsClrCode = dbs_CCON.GetValue("U_BASECLR", j).Trim();
                            string dsSizeCode = dbs_CCON.GetValue("U_SIZECODE", j).Trim();
                            string dsClrCodeV = oRS.Fields.Item("U_ColourCode").Value.ToString();
                            string SizeCodeV = oRS.Fields.Item("U_SizeCode").Value.ToString();
                            if (dsClrCode == dsClrCodeV && dsSizeCode == SizeCodeV)
                            {
                                existingIndex = j;
                                break;
                            }
                            else
                            {
                                existingIndex = -1;
                            }
                        }

                        // For update record
                        if (existingIndex >= 0)
                        {
                            dbs_CCON.SetValue("U_BASECLR", existingIndex, oRS.Fields.Item("U_ColourCode").Value.ToString());
                            dbs_CCON.SetValue("U_SIZECODE", existingIndex, oRS.Fields.Item("U_SizeCode").Value.ToString());
                            dbs_CCON.SetValue("U_SIZENAME", existingIndex, oRS.Fields.Item("U_SizeName").Value.ToString());
                            dbs_CCON.SetValue("U_RATION", existingIndex, oRS.Fields.Item("U_Qty").Value.ToString());
                        }
                        else
                        {
                            dbs_CCON.SetValue("U_BASECLR", dbs_CCON.Size - 1, oRS.Fields.Item("U_ColourCode").Value.ToString());
                            dbs_CCON.SetValue("U_SIZECODE", dbs_CCON.Size - 1, oRS.Fields.Item("U_SizeCode").Value.ToString());
                            dbs_CCON.SetValue("U_SIZENAME", dbs_CCON.Size - 1, oRS.Fields.Item("U_SizeName").Value.ToString());
                            dbs_CCON.SetValue("U_RATION", dbs_CCON.Size - 1, oRS.Fields.Item("U_Qty").Value.ToString());
                            dbs_CCON.InsertRecord(dbs_CCON.Size);
                        }

                        i++;
                        oRS.MoveNext();
                    }
                }
                oMatrixSize.Clear();
                oMatrixSize.LoadFromDataSource();
                //oForm.Freeze(false); ///-test

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }

                oForm.Items.Item("1").Click();  // “1” = system Add/Update button
            }
        }

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            { 
            
           
                    //Validation Start
                    //start
                SAPbouiCOM.EditText ETSTYLNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;
                SAPbouiCOM.ComboBox CBSTATUS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATUS").Specific;
                SAPbouiCOM.EditText ETDDATE = (SAPbouiCOM.EditText)oForm.Items.Item("ETDDATE").Specific;
                SAPbouiCOM.EditText ETDONO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONO").Specific;
                SAPbouiCOM.Matrix oMatrix_COLOUR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                SAPbouiCOM.Matrix oMatrix_MCON = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;

                if (ETSTYLNO.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout Style!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (CBSTATUS.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Select Status!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (ETDDATE.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout Document Date!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (ETDONO.Value == "")
                {
                    Application.SBO_Application.StatusBar.SetText("Fillout Draft Order!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (oMatrix_COLOUR.RowCount <= 1)
                {
                    Application.SBO_Application.StatusBar.SetText("No colour Found!",
                        SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }
                else if (oMatrix_MCON.RowCount <= 1)
                {
                    Application.SBO_Application.StatusBar.SetText("No Mercenhndise Found!",
                    SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    BubbleEvent = false;
                }

                //---->For Colour
                if (BubbleEvent == true)
                {
                    for (int i = 1; i < oMatrix_COLOUR.RowCount; i++)
                    {
                        string CLCLRCD = ((SAPbouiCOM.EditText)oMatrix_COLOUR.GetCellSpecific("CLCLRCD", i)).Value.Trim();

                        if (string.IsNullOrEmpty(CLCLRCD))
                        {
                            oMatrix_COLOUR.SelectRow(i, true, false);  // highlight row
                            Application.SBO_Application.StatusBar.SetText("Fillout Colour Code!",
                                                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            break;
                        }
                    }
                }

                //---->For Mercehndise Consumption
                if (BubbleEvent == true)
                {
                    for (int i = 1; i < oMatrix_MCON.RowCount; i++)
                    {
                        string UseType = ((SAPbouiCOM.ComboBox)oMatrix_MCON.GetCellSpecific("CLUSETYP", i)).Value.Trim();
                        string ItemCode = ((SAPbouiCOM.EditText)oMatrix_MCON.GetCellSpecific("CLITMCD", i)).Value.Trim();

                        if (string.IsNullOrEmpty(UseType) || string.IsNullOrEmpty(ItemCode))
                        {
                            oMatrix_MCON.SelectRow(i, true, false);  // highlight row
                            Application.SBO_Application.StatusBar.SetText("Fillout Use Type!",
                                                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            break;
                        }
                    }
                }

                //Validation End

                //next Process
                if (BubbleEvent == true)
                {
                    try
                    {
                        oForm.Freeze(true);

                        SAPbobsCOM.Recordset oRS3 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        SAPbouiCOM.Matrix oMatrixSize = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                        int count = 0;
                        if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE) //For Update Mode
                        {
                            //Line item issue on CAD consumption Matrix
                            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                            SAPbouiCOM.DBDataSource dbs_CCON = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCN");

                            if (dbs_CCON.Size == 1)
                            { count++; }

                            int existingIndex = -1;
                            for (int i = 1; i <= oMatrix.RowCount; i++)
                            {

                                string itemCode = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLITMCD", i)).Value.Trim();
                                string UseType = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLUSETYP", i)).Value.Trim();
                                string Clrcode = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCLRCD", i)).Value.Trim();

                                for (int j = 0; j < dbs_CCON.Size; j++)
                                {
                                    string dsItemCode = dbs_CCON.GetValue("U_ITEMCODE", j).Trim();
                                    string dsClrCode = dbs_CCON.GetValue("U_BASECLR", j).Trim();
                                    string dsUseType = dbs_CCON.GetValue("U_USETYPE", j).Trim();

                                    if (dsItemCode == itemCode && dsClrCode == Clrcode && dsUseType == UseType)
                                    {
                                        existingIndex = j;
                                        break;
                                    }
                                }

                                // For update record
                                if (existingIndex >= 0)
                                {
                                    dbs_CCON.SetValue("U_USETYPE", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLUSETYP", i)).Value);
                                    dbs_CCON.SetValue("U_ITEMNAME", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLITMNAM", i)).Value);
                                    dbs_CCON.SetValue("U_UOM", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLUOM", i)).Value);
                                    dbs_CCON.SetValue("U_SHRNLPRC", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLSHRINK", i)).Value);
                                    dbs_CCON.SetValue("U_WAYOFMKR", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLWOFM", i)).Value);
                                    dbs_CCON.SetValue("U_CBLWDIN", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCWINCH", i)).Value);
                                    dbs_CCON.SetValue("U_CUTWSTG", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLWASTG", i)).Value);
                                    dbs_CCON.SetValue("U_CBLWDCM", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCWDCM", i)).Value);
                                    dbs_CCON.SetValue("U_ACTCONSM", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCONSM", i)).Value);
                                    dbs_CCON.SetValue("U_REMARKS", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLREMRK", i)).Value);
                                    dbs_CCON.SetValue("U_BASECLR", existingIndex, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCLRCD", i)).Value);
                                }
                                else // For Insert record
                                {
                                    if (count == 0) //For After 1st time insert in Table
                                    { dbs_CCON.InsertRecord(dbs_CCON.Size); }

                                    dbs_CCON.SetValue("U_USETYPE", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLUSETYP", i)).Value);
                                    dbs_CCON.SetValue("U_ITEMCODE", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLITMCD", i)).Value);
                                    dbs_CCON.SetValue("U_ITEMNAME", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLITMNAM", i)).Value);
                                    dbs_CCON.SetValue("U_UOM", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLUOM", i)).Value);
                                    dbs_CCON.SetValue("U_SHRNLPRC", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLSHRINK", i)).Value);
                                    dbs_CCON.SetValue("U_WAYOFMKR", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLWOFM", i)).Value);
                                    dbs_CCON.SetValue("U_CBLWDIN", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCWINCH", i)).Value);
                                    dbs_CCON.SetValue("U_CUTWSTG", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLWASTG", i)).Value);
                                    dbs_CCON.SetValue("U_CBLWDCM", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCWDCM", i)).Value);
                                    dbs_CCON.SetValue("U_ACTCONSM", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCONSM", i)).Value);
                                    dbs_CCON.SetValue("U_REMARKS", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLREMRK", i)).Value);
                                    dbs_CCON.SetValue("U_BASECLR", dbs_CCON.Size - 1, ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCLRCD", i)).Value);

                                    if (count > 0) //For 1st time insert in Table
                                    { dbs_CCON.InsertRecord(dbs_CCON.Size); }
                                }
                            }

                            if (dbs_CCON.Size > 0)
                            {
                                if (string.IsNullOrEmpty(dbs_CCON.GetValue("U_ITEMCODE", dbs_CCON.Size - 1).Trim()))
                                {
                                    dbs_CCON.RemoveRecord(dbs_CCON.Size - 1);
                                }
                            }

                            oMatrix.LoadFromDataSource();

                            ///Matrix - Size
                            oMatrixSize.LoadFromDataSource();
                        }
                        else
                        {
                            ////For Size Matrix
                            SAPbouiCOM.EditText etDONo = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONO").Specific;
                            string docDOValue = etDONo.Value;
                            string sql_matrix = $"SELECT A.\"U_ColourCode\", A.\"U_ColourName\", A.\"U_SizeCode\", B.\"Name\" AS \"U_SizeName\" , A.\"U_Qty\", A.\"U_TotalQty\" FROM \"@FIL_DR_OQUT\" A " +
                                $"LEFT OUTER JOIN \"@FIL_MH_SIZEMSTR\" B ON A.\"U_SizeCode\" = B.\"Code\" " +
                                $"LEFT OUTER JOIN \"OQUT\" C ON A.\"DocEntry\" = C.\"U_CRSZNTRY\"" +
                                $"WHERE C.\"DocEntry\" = {docDOValue}  ORDER BY \"LineId\" ASC;";

                            oRS3.DoQuery(sql_matrix);

                            if (oRS3.RecordCount > 0)
                            {
                                oMatrixSize.Clear();
                                int row3 = 1;
                                while (!oRS3.EoF)
                                {
                                    if (oRS3.Fields.Item("U_SizeCode").Value.ToString() != "")
                                    {
                                        oMatrixSize.AddRow();
                                        oMatrixSize.SetCellWithoutValidation(row3, "CLSIZECD", oRS3.Fields.Item("U_SizeCode").Value.ToString());
                                        oMatrixSize.SetCellWithoutValidation(row3, "CLSIZENM", oRS3.Fields.Item("U_SizeName").Value.ToString());
                                        oMatrixSize.SetCellWithoutValidation(row3, "CLRATIO", oRS3.Fields.Item("U_Qty").Value.ToString());
                                        oMatrixSize.SetCellWithoutValidation(row3, "CLCLRCD", oRS3.Fields.Item("U_ColourCode").Value.ToString());
                                        row3++;
                                    }
                                    oRS3.MoveNext();
                                }
                            }

                        }

                        SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                        SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                        SAPbouiCOM.Matrix oMatrix4 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;

                        //Last Empty Row Delete
                        if (oMatrix2.RowCount > 0)
                        {
                            SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix2.Columns.Item("CLCLRCD").Cells.Item(oMatrix2.RowCount).Specific;
                            string Code = oCell.Value.Trim();

                            if (string.IsNullOrEmpty(Code))
                            {
                                oMatrix2.DeleteRow(oMatrix2.RowCount);
                            }
                        }

                        if (oMatrix3.RowCount > 0)
                        {
                            SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix3.Columns.Item("CLSIZECD").Cells.Item(oMatrix3.RowCount).Specific;
                            string Code = oCell.Value.Trim();

                            if (string.IsNullOrEmpty(Code))
                            {
                                oMatrix3.DeleteRow(oMatrix3.RowCount);
                            }
                        }

                        if (oMatrix4.RowCount > 0)
                        {
                            SAPbouiCOM.EditText oCell = (SAPbouiCOM.EditText)oMatrix4.Columns.Item("CLITMCD").Cells.Item(oMatrix4.RowCount).Specific;
                            string Code = oCell.Value.Trim();

                            if (string.IsNullOrEmpty(Code))
                            {
                                oMatrix4.DeleteRow(oMatrix4.RowCount);
                            }
                        }

                        //oForm.Freeze(false); ///-test
                    }
                    catch (Exception ex)
                    {

                        BubbleEvent = false;
                        oForm.Freeze(false);
                        Application.SBO_Application.StatusBar.SetText($"Error: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    }
             
                }
            }
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                //oForm.Freeze(true);
                //Init Matrix Colour
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                //New Line Add
                int lastRow = oMatrix.RowCount;
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");

                //Init Matrix Size
                SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                oMatrix2.Clear();

                ////Init Matrix Mercehndise Consumption
                SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine3 = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                //New Line Add
                int lastRow3 = oMatrix3.RowCount;
                Global.GFunc.SetNewLine(oMatrix3, DBDataSourceLine3, lastRow3 + 1, "");

                SAPbouiCOM.Matrix oMatrix4 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                oMatrix4.Clear();

                oForm.Freeze(false);

            }
            catch (Exception e)
            {
                oForm.Freeze(false);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                oForm.Freeze(true);
                //Init Matrix Colour
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                //New Line Add
                int lastRow = oMatrix.RowCount;
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");

                //Init Matrix Size
                SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                oMatrix2.Clear();

                ////Init Matrix Mercehndise Consumption
                SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine3 = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                //New Line Add
                int lastRow3 = oMatrix3.RowCount;
                Global.GFunc.SetNewLine(oMatrix3, DBDataSourceLine3, lastRow3 + 1, "");

                //Init Matrix CAD Consumptionm
                SAPbouiCOM.Matrix oMatrix4 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                oMatrix4.Clear();

                oForm.Freeze(false);
            }
            catch (Exception e)
            {
                oForm.Freeze(false);
            }
        }

        private void MTX_COLUR_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                SAPbouiCOM.Matrix oMatrixHead = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                SAPbouiCOM.Matrix oMatrixDetail = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_CCON").Specific;
                SAPbouiCOM.Matrix oMatrixSize = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                SAPbouiCOM.EditText DocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific;

                int selectedRow = pVal.Row;
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                SAPbobsCOM.Recordset oRS2 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string ColourCode = ((SAPbouiCOM.EditText)oMatrixHead.GetCellSpecific("CLCLRCD", selectedRow)).Value.Trim();

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    if (pVal.ColUID == "#" && pVal.Row > 0 && !string.IsNullOrEmpty(ColourCode))
                    {
                        oForm.Freeze(true);

                        string sql = $"SELECT T0.\"U_USETYPE\", T1.\"Name\" As \"U_POSITION\",T0.\"U_ITEMCODE\", T0.\"U_ITEMNAME\", T0.\"U_UOM\",T0.\"U_SHRNLPRC\", T0.\"U_WAYOFMKR\", T0.\"U_CBLWDIN\", T0.\"U_CUTWSTG\", " +
                                     $" T0.\"U_CBLWDCM\",  T0.\"U_ACTCONSM\",  T0.\"U_REMARKS\" FROM \"@FIL_DR_CADFABCN\" T0 " +
                                     $"INNER JOIN \"@FIL_MH_POSITION\" T1 ON T1.\"Code\" = T0.\"U_USETYPE\"" +
                                     $" WHERE T0.\"DocEntry\" = '{DocEntry.Value}' AND T0.\"U_BASECLR\" = '{ColourCode}'";
                        oRS.DoQuery(sql);

                        if (oRS.RecordCount > 0)
                        {
                            oMatrixDetail.Clear();
                            int row = 1;
                            while (!oRS.EoF)
                            {
                                if (oRS.Fields.Item("U_ITEMCODE").Value.ToString() != "")
                                {
                                    oMatrixDetail.AddRow();
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLUSETYP", oRS.Fields.Item("U_USETYPE").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLUSETNM", oRS.Fields.Item("U_POSITION").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLITMCD", oRS.Fields.Item("U_ITEMCODE").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLITMNAM", oRS.Fields.Item("U_ITEMNAME").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLUOM", oRS.Fields.Item("U_UOM").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLSHRINK", oRS.Fields.Item("U_SHRNLPRC").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLWOFM", oRS.Fields.Item("U_WAYOFMKR").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLCWINCH", oRS.Fields.Item("U_CBLWDIN").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLCWDCM", oRS.Fields.Item("U_CBLWDCM").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLWASTG", oRS.Fields.Item("U_CUTWSTG").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLCONSM", oRS.Fields.Item("U_ACTCONSM").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row, "CLREMRK", oRS.Fields.Item("U_REMARKS").Value.ToString());
                                    row++;
                                }
                                oRS.MoveNext();
                            }
                        }
                        else
                        {
                            oMatrixDetail.Clear();
                            string sql2 = $"SELECT T0.\"U_USETYPE\", T1.\"Name\" As \"U_POSITION\", T0.\"U_ITEMCODE\", T0.\"U_ITEMNAME\", T0.\"U_UOM\", T0.\"U_SHRNLPRC\", T0.\"U_WAYOFMKR\", T0.\"U_CBLWDIN\", " +
                                          $" T0.\"U_CBLWDCM\" FROM \"@FIL_DR_CADMFAB\" T0 " +
                                          $" INNER JOIN \"@FIL_MH_POSITION\" T1 ON T1.\"Code\" = T0.\"U_USETYPE\"" +
                                          $" WHERE T0.\"DocEntry\" = '{DocEntry.Value}'";
                            oRS2.DoQuery(sql2);

                            int row2 = 1;
                            while (!oRS2.EoF)
                            {
                                if (oRS2.Fields.Item("U_ITEMCODE").Value.ToString() != "")
                                {
                                    oMatrixDetail.AddRow();
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLUSETYP", oRS2.Fields.Item("U_USETYPE").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLUSETNM", oRS2.Fields.Item("U_POSITION").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLITMCD", oRS2.Fields.Item("U_ITEMCODE").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLITMNAM", oRS2.Fields.Item("U_ITEMNAME").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLUOM", oRS2.Fields.Item("U_UOM").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLSHRINK", oRS2.Fields.Item("U_SHRNLPRC").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLWOFM", oRS2.Fields.Item("U_WAYOFMKR").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLCWINCH", oRS2.Fields.Item("U_CBLWDIN").Value.ToString());
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLCWDCM", oRS2.Fields.Item("U_CBLWDCM").Value.ToString());

                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLWASTG", "");
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLCONSM", "");
                                    oMatrixDetail.SetCellWithoutValidation(row2, "CLREMRK", "");
                                    row2++;

                                }
                                oRS2.MoveNext();
                            }
                        }

                        for (int i = 1; i <= oMatrixDetail.RowCount; i++)
                        {
                            oMatrixDetail.SetCellWithoutValidation(i, "CLCLRCD", ColourCode);
                        }

                        ////For Size Matrix
                        SAPbouiCOM.EditText etDocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific;
                        string docEntryValue = etDocEntry.Value;
                        SAPbobsCOM.Recordset oRS3 = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string sql_matrix = $"SELECT \"U_SIZECODE\", \"U_SIZENAME\", \"U_RATION\", \"U_BASECLR\" FROM \"@FIL_DR_CADFABSZ\" WHERE \"DocEntry\" = {docEntryValue} AND \"U_BASECLR\" = '{ColourCode}' ORDER BY \"LineId\" ASC;";
                        oRS3.DoQuery(sql_matrix);

                        oMatrixSize.Clear();
                        if (oRS3.RecordCount > 0)
                        {
                            int row3 = 1;
                            while (!oRS3.EoF)
                            {
                                if (oRS3.Fields.Item("U_SIZECODE").Value.ToString() != "")
                                {
                                    oMatrixSize.AddRow();
                                    oMatrixSize.SetCellWithoutValidation(row3, "CLSIZECD", oRS3.Fields.Item("U_SIZECODE").Value.ToString());
                                    oMatrixSize.SetCellWithoutValidation(row3, "CLSIZENM", oRS3.Fields.Item("U_SIZENAME").Value.ToString());
                                    oMatrixSize.SetCellWithoutValidation(row3, "CLRATIO", oRS3.Fields.Item("U_RATION").Value.ToString());
                                    oMatrixSize.SetCellWithoutValidation(row3, "CLCLRCD", oRS3.Fields.Item("U_BASECLR").Value.ToString());
                                    row3++;
                                }
                                oRS3.MoveNext();
                            }
                        }

                        oForm.Freeze(false);
                    }
                    else
                    {
                        oForm.Freeze(true);
                        oMatrixSize.Clear();
                        oMatrixDetail.Clear();
                        oForm.Freeze(false);
                    }
                }

            }
            catch (Exception ex)
            {
                oForm.Freeze(false);
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void ETSTYLNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

            if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                return;
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                //Clear Related Field After New selected Style
                SAPbouiCOM.EditText ETSTYLNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNM").Specific; ETSTYLNM.Value = "";
                SAPbouiCOM.EditText ETCSTYLC = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSTYLC").Specific; ETCSTYLC.Value = "";
                SAPbouiCOM.EditText ETCSTYLN = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSTYLN").Specific; ETCSTYLN.Value = "";
                SAPbouiCOM.EditText ETMERCHC = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHC").Specific; ETMERCHC.Value = "";
                SAPbouiCOM.EditText ETMERCHN = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHN").Specific; ETMERCHN.Value = "";
                SAPbouiCOM.EditText ETDONO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONO").Specific; ETDONO.Value = "";
                SAPbouiCOM.EditText ETDONAM = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONAM").Specific; ETDONAM.Value = "";

                SAPbouiCOM.Matrix oMatrixColour = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                oMatrixColour.Clear();

                //Init Matrix Colour
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                //New Line Add
                int lastRow = oMatrix.RowCount;
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");

                SAPbouiCOM.Matrix oMatrixSize = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_SIZE").Specific;
                oMatrixSize.Clear();
                //Clear Related Field After New selected Style

                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                string Code = dt.GetValue("Code", 0).ToString().Trim();
                string Name = dt.GetValue("Name", 0).ToString().Trim();
                string CuCOde = dt.GetValue("U_BUYRCODE", 0).ToString().Trim();
                string CuName = dt.GetValue("U_BURSNAME", 0).ToString().Trim();
                string MrchCOde = dt.GetValue("U_Marchen", 0).ToString().Trim();
                string MrchName = dt.GetValue("U_MarchenN", 0).ToString().Trim();

                SAPbouiCOM.EditText etStyleCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;
                SAPbouiCOM.EditText etStyleName = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNM").Specific;
                SAPbouiCOM.EditText etCusStylCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSTYLC").Specific;
                SAPbouiCOM.EditText etCusStylNam = (SAPbouiCOM.EditText)oForm.Items.Item("ETCSTYLN").Specific;
                SAPbouiCOM.EditText etMrchStylCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHC").Specific;
                SAPbouiCOM.EditText etMrchStylNam = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCHN").Specific;

                etStyleCode.Value = Code;
                etStyleName.Value = Name;
                etCusStylCode.Value = CuCOde;
                etCusStylNam.Value = CuName;
                etMrchStylCode.Value = MrchCOde;
                etMrchStylNam.Value = MrchName;

                //Initiallization

                //Draft Order Filter
                SAPbouiCOM.ChooseFromList oCFL_DO = oForm.ChooseFromLists.Item("CFLDO");
                SAPbouiCOM.Conditions oCons_DO = new SAPbouiCOM.Conditions();
                SAPbouiCOM.Condition oCon_DO;
                oCon_DO = oCons_DO.Add();
                oCon_DO.Alias = "U_StyleNo";
                oCon_DO.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon_DO.CondVal = Code;
                oCFL_DO.SetConditions(oCons_DO);

                //////Style wise Colour--start
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFLCOLOUR");
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = $"Select DISTINCT(A.\"U_ColourCode\") As \"Code\" FROM \"@FIL_MR_PSMCO\" A LEFT OUTER JOIN \"@FIL_MH_OCOM\" B ON A.\"U_ColourCode\" = B.\"Code\" WHERE B.\"U_ACTIVE\" = 'Y' AND A.\"U_ColourAppl\" = 'Y' AND A.\"Code\" = '" + Code + "'";
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
            }

        }

        private void ETDONO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

            if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                return;
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                string Code = dt.GetValue("DocEntry", 0).ToString().Trim();
                string Name = dt.GetValue("DocNum", 0).ToString().Trim();

                SAPbouiCOM.EditText etDOCode = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONO").Specific;
                SAPbouiCOM.EditText etDOName = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONAM").Specific;

                //etDOCode.Value = Code;
                etDOName.Value = Name;
            }
        }

        private void MTX_MCON_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

            if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                return;
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (cflArg.SelectedObjects.UniqueID == "CFLITEM")
                {
                    SAPbouiCOM.Matrix oMatrix3 = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_MCON").Specific;
                    string Code = dt.GetValue("ItemCode", 0).ToString().Trim();
                    string Name = dt.GetValue("ItemName", 0).ToString().Trim();

                    oMatrix3.SetCellWithoutValidation(pVal.Row, "CLITMCD", Code);
                    oMatrix3.SetCellWithoutValidation(pVal.Row, "CLITMNAM", Name);

                    if (Code != null)
                    {
                        string uom = "";
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string sql = $"SELECT T1.\"UomName\" " +
                                     $"FROM OITM T0 " +
                                     $"LEFT JOIN OUOM T1 ON T0.\"IUoMEntry\" = T1.\"UomEntry\" " +
                                     $"WHERE T0.\"ItemCode\" = '{Code}'";
                        oRS.DoQuery(sql);

                        if (!oRS.EoF)
                        {
                            uom = oRS.Fields.Item("UomName").Value.ToString();
                            oMatrix3.SetCellWithoutValidation(pVal.Row, "CLUOM", uom);
                        }
                    }

                    SAPbouiCOM.DBDataSource DBDataSourceLine3 = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                    //New Line Add
                    int lastRow3 = oMatrix3.RowCount;
                    string ItemCode = ((SAPbouiCOM.EditText)oMatrix3.GetCellSpecific("CLITMCD", lastRow3)).Value.Trim();
                    if (!string.IsNullOrEmpty(ItemCode))
                    {
                        Global.GFunc.SetNewLine(oMatrix3, DBDataSourceLine3, lastRow3 + 1, "");
                    }
                }
            }
        }

        private void MTX_COLUR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

            if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                return;
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (cflArg.SelectedObjects.UniqueID == "CFLCOLOUR")
                {
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_COLUR").Specific;
                    string Code = dt.GetValue("Code", 0).ToString().Trim();
                    string Name = dt.GetValue("Name", 0).ToString().Trim();

                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRCD", Code);
                    oMatrix.SetCellWithoutValidation(pVal.Row, "CLCLRNAM", Name);

                    //New Line Add
                    SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                    int lastRow = oMatrix.RowCount;

                    string ColourCode = ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific("CLCLRCD", lastRow)).Value.Trim();
                    if (!string.IsNullOrEmpty(ColourCode))
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, lastRow + 1, "");
                    }

                }
            }
        }

        private void LINKMRC_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
            oForm.Freeze(true);
            oForm.Items.Item("ETMERCHC").Enabled = true;
        }
        private void LINKMRC_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
            oForm.Items.Item("ETMERCHC").Enabled = false;
            oForm.Freeze(false);

        }
        private void LINKSTYL_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSTYLNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;
            string styleCode = ETSTYLNO.Value.Trim();
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
}
