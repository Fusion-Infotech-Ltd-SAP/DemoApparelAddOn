using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.MRP", "Resources/MRP.b1f")]
    class MRP : UserFormBase
    {
        public MRP()
        {
        }
      
        private SAPbouiCOM.StaticText STDOCNUM, STUNIT, STCUSTCD, STODRTYP, STSTYLNO, STDDATE,
                                      STPOSRI, STTYPE, STRMDTLS, STVENCD, STPAYTRM, STSHPTYP,
                                      STSHPFRM, STINCTRM, STPODTLS, STBRNDCD, STBYCODE;

        private SAPbouiCOM.EditText ETDOCTRY, ETDOCNUM, ETCUSTCD, ETCUSTNM, ETSTYLNO, ETSTYLNM,
                                    ETDDATE, ETBRNDCD, ETBRNDNM, ETBYCODE, ETBYNAME, ETVND;

        //Tab
        private SAPbouiCOM.Folder TAB_SO, TAB_SKU, TAB_MAT;
        private SAPbouiCOM.ComboBox CBUNIT, CBPOSRI, CBODRTYP, CBPAYTRM, CBSHPTYP, CBSHPFRM, CBINCTRM, CBTYPE;
        private SAPbouiCOM.Button ADDButton, CancelButton, BTNPPO, BTNGTSKU, BTNGTRMD;

      

        private SAPbouiCOM.Grid GRD_PODTL;
        private SAPbouiCOM.Matrix MTXSLODR, MTX_SKU, MTX_RMD;
        private SAPbouiCOM.LinkedButton LBSTYLE, LBCUSCOD;
        //private SAPbouiCOM.LinkedButton LINKDO;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            //                     Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNPPO = ((SAPbouiCOM.Button)(this.GetItem("BTNPPO").Specific));
            this.BTNPPO.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNPPO_PressedBefore);
            this.BTNPPO.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNPPO_PressedAfter);
            this.BTNGTSKU = ((SAPbouiCOM.Button)(this.GetItem("BTNGTSKU").Specific));
            this.BTNGTSKU.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNGTSKU_PressedAfter);
            this.BTNGTSKU.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNGTSKU_PressedBefore);
            this.BTNGTRMD = ((SAPbouiCOM.Button)(this.GetItem("BTNGTRMD").Specific));
            this.BTNGTRMD.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.BTNGTRMD_ClickBefore);
            //                     Static Text
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STUNIT = ((SAPbouiCOM.StaticText)(this.GetItem("STUNIT").Specific));
            this.STCUSTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTCD").Specific));
            this.STODRTYP = ((SAPbouiCOM.StaticText)(this.GetItem("STODRTYP").Specific));
            this.STSTYLNO = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLNO").Specific));
            this.STDDATE = ((SAPbouiCOM.StaticText)(this.GetItem("STDDATE").Specific));
            this.STPOSRI = ((SAPbouiCOM.StaticText)(this.GetItem("STPOSRI").Specific));
            this.STTYPE = ((SAPbouiCOM.StaticText)(this.GetItem("STTYPE").Specific));
            this.STRMDTLS = ((SAPbouiCOM.StaticText)(this.GetItem("STRMDTLS").Specific));
            this.STVENCD = ((SAPbouiCOM.StaticText)(this.GetItem("STVENCD").Specific));
            this.STPAYTRM = ((SAPbouiCOM.StaticText)(this.GetItem("STPAYTRM").Specific));
            this.STSHPTYP = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPTYP").Specific));
            this.STSHPFRM = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPFRM").Specific));
            this.STINCTRM = ((SAPbouiCOM.StaticText)(this.GetItem("STINCTRM").Specific));
            this.STPODTLS = ((SAPbouiCOM.StaticText)(this.GetItem("STPODTLS").Specific));
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            //                     Edit Text
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETCUSTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTCD").Specific));
            this.ETCUSTCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSTCD_ChooseFromListAfter);
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.ETSTYLNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNO").Specific));
            this.ETSTYLNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLNO_ChooseFromListAfter);
            this.ETSTYLNO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSTYLNO_ChooseFromListBefore);
            this.ETSTYLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNM").Specific));
            this.ETDDATE = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDATE").Specific));
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETBRNDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNDCD_ChooseFromListBefore);
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            //                     Combo Box
            this.CBUNIT = ((SAPbouiCOM.ComboBox)(this.GetItem("CBUNIT").Specific));
            this.CBPOSRI = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPOSRI").Specific));
            this.CBODRTYP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBODRTYP").Specific));
            this.CBPAYTRM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPAYTRM").Specific));
            this.CBSHPTYP = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSHPTYP").Specific));
            this.CBSHPFRM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSHPFRM").Specific));
            this.CBINCTRM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINCTRM").Specific));
            //                     Tab
            this.TAB_SO = ((SAPbouiCOM.Folder)(this.GetItem("TAB_SO").Specific));
            this.TAB_SKU = ((SAPbouiCOM.Folder)(this.GetItem("TAB_SKU").Specific));
            this.TAB_MAT = ((SAPbouiCOM.Folder)(this.GetItem("TAB_MAT").Specific));
            //                     Matrix
            this.MTXSLODR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSLODR").Specific));
            this.MTXSLODR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXSLODR_ChooseFromListAfter);
            this.MTXSLODR.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXSLODR_ChooseFromListBefore);
            this.MTX_SKU = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSKUDL").Specific));
            this.MTX_SKU.LinkPressedAfter += new SAPbouiCOM._IMatrixEvents_LinkPressedAfterEventHandler(this.MTX_SKU_LinkPressedAfter);
            this.MTX_RMD = ((SAPbouiCOM.Matrix)(this.GetItem("MTX_RMD").Specific));
            this.MTX_RMD.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTX_RMD_ChooseFromListAfter);
            //                     Grid
            this.GRD_PODTL = ((SAPbouiCOM.Grid)(this.GetItem("GRD_PODTL").Specific));
            this.ETBYNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETBYNAME").Specific));
            this.ETBYCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETBYCODE").Specific));
            this.STBYCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STBYCODE").Specific));
            this.LBCUSCOD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBCUSCOD").Specific));
            this.LBSTYLE = ((SAPbouiCOM.LinkedButton)(this.GetItem("LBSTYLE").Specific));
            this.LBSTYLE.ClickAfter += new SAPbouiCOM._ILinkedButtonEvents_ClickAfterEventHandler(this.LBSTYLE_ClickAfter);
            this.CBTYPE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBTYPE").Specific));
            this.ETVND = ((SAPbouiCOM.EditText)(this.GetItem("ETVND").Specific));
            this.ETVND.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETVND_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {

        }

        private void MTX_SKU_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                // Safety: ignore invalid rows
                if (pVal.Row <= 0) return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item(pVal.ItemUID).Specific;

                string col = pVal.ColUID;
                int row = pVal.Row;


                if (col == "CLCSTCOD")
                {

                    var et = (SAPbouiCOM.EditText)mtx.Columns.Item("CLCSTCOD").Cells.Item(pVal.Row).Specific;
                    string cstCode = et.Value.Trim();
                    Costing cost = new Costing();
                    cost.Show();
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
                    catch (Exception)
                    {
                        cForm.Freeze(false);
                    }
                }
                else if (col == "CLCADTRY")
                {
                    var et = (SAPbouiCOM.EditText)mtx.Columns.Item("CLCADTRY").Cells.Item(pVal.Row).Specific;
                    string cadEntry = et.Value.Trim();
                    CAD cad = new CAD();
                    cad.Show();
                    SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
                    try
                    {
                        cForm.Freeze(true);
                        cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                        cForm.Items.Item("ETDOCNUM").Enabled = true;
                        SAPbouiCOM.EditText cETCADNO = (SAPbouiCOM.EditText)cForm.Items.Item("ETDOCNUM").Specific;
                        cETCADNO.Value = cadEntry;
                        cForm.Items.Item("1").Click();

                        cForm.Freeze(false);
                    }
                    catch (Exception)
                    {
                        cForm.Freeze(false);
                    }
                }
                else if (col == "CLSTYLNO")
                {
                    var et = (SAPbouiCOM.EditText)mtx.Columns.Item("CLSTYLNO").Cells.Item(pVal.Row).Specific;
                    string styleCode = et.Value.Trim();
                    StyleMaster sm = new StyleMaster();
                    sm.Show();
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

                        cForm.Freeze(false);
                    }
                    catch (Exception)
                    {
                        cForm.Freeze(false);
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


        private void LBSTYLE_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSTYLNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;
            string styleCode = ETSTYLNO.Value.Trim();
            StyleMaster sm = new StyleMaster();
            sm.Show();
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

                cForm.Freeze(false);
            }
            catch (Exception)
            {
                cForm.Freeze(false);
            }

        }

        private void BTNGTSKU_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            FillMrpAndPlanFromMrp2(oForm);
        }
        private void FillMrpAndPlanFromMrp2(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Matrix mtxSKU = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSKUDL").Specific;

            string colOrderQty = "CLODRQTY";
            string colPlanQty = "CLPLNQTY";
            string colMrpQty = "CLMRPQTY";

            SAPbobsCOM.Recordset rs =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oForm.Freeze(true);
            try
            {
                for (int r = 1; r <= mtxSKU.VisualRowCount; r++)
                {
                    string docEntry = GetCell(mtxSKU, "CLDOCTRY", r);   
                    string itemCode = GetCell(mtxSKU, "CLITMCOD", r);

                    if (string.IsNullOrWhiteSpace(docEntry) || string.IsNullOrWhiteSpace(itemCode))
                        continue;

                    double orderQty = ParseDouble(GetCell(mtxSKU, colOrderQty, r));
                    double userPlan = ParseDouble(GetCell(mtxSKU, colPlanQty, r)); // whatever user typed

                    string sql = $@"
                                    SELECT ""U_SODocEntry"",""U_ItemCode"",SUM(""U_PlanQty"") AS ""PrevPlanQty""
                                    FROM ""@FIL_DR_MRP2""
                                    WHERE ""U_SODocEntry"" = '{docEntry}'
                                      AND ""U_ItemCode""   = '{itemCode}'
                                    GROUP BY ""U_SODocEntry"",""U_ItemCode"" ";

                    rs.DoQuery(sql);

                    if (rs.RecordCount > 0)
                    {
                        // exists -> mrp = previous plan qty, plan = order - mrp
                        double prevPlan = ToDouble(rs.Fields.Item("PrevPlanQty").Value);
                        double mrpQty = prevPlan;
                        double newPlan = orderQty - mrpQty;

                        if (newPlan < 0) newPlan = 0; // optional safety

                        SetCell(mtxSKU, colMrpQty, r, mrpQty);
                        SetCell(mtxSKU, colPlanQty, r, newPlan);
                    }
                    else
                    {
                        // not exists -> mrp = 0, plan stays user input
                        SetCell(mtxSKU, colMrpQty, r, 0);
                        // keep userPlan as-is 
                        //SetCell(mtxSKU, colPlanQty, r, userPlan);
                        SetCell(mtxSKU, colPlanQty, r, orderQty);
                    }
                }
            }
            finally
            {
                oForm.Freeze(false);
            }
        }
        private string GetCell(SAPbouiCOM.Matrix mtx, string colId, int row)
        {
            return ((SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(row).Specific).Value?.Trim() ?? "";
        }

        private void SetCell(SAPbouiCOM.Matrix mtx, string colId, int row, double val)
        {
            ((SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(row).Specific).Value =
                val.ToString("0.####"); // adjust format if you want
        }

        private double ParseDouble(string s)
        {
            if (double.TryParse(s, out double d)) return d;
            return 0;
        }

        private double ToDouble(object v)
        {
            if (v == null || v == DBNull.Value) return 0;
            double.TryParse(Convert.ToString(v), out double d);
            return d;
        }

        private string EscapeSql(string s)
        {
            return (s ?? "").Replace("'", "''");
        }


        private void BTNGTSKU_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            SAPbouiCOM.Matrix mtxSODR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
            SAPbouiCOM.Matrix mtxSKU = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSKUDL").Specific;

            // ---------------- Task 1: Read DocEntry from MTXSLODR.CLdocent ----------------
            List<int> docEntries = new List<int>();

            for (int r = 1; r <= mtxSODR.VisualRowCount; r++)
            {
                string s = ((SAPbouiCOM.EditText)mtxSODR.Columns.Item("CLDOCENT").Cells.Item(r).Specific).Value?.Trim();
                if (int.TryParse(s, out int de) && de > 0)
                    docEntries.Add(de);
            }

            docEntries = docEntries.Distinct().ToList();

            if (docEntries.Count == 0)
            {
                Application.SBO_Application.MessageBox("No Draft SO found. Please add Draft SO first.");
                BubbleEvent = false;
                return;
            }

            // ---------------- Task 2: Query + Fill MTXSKUDL ----------------
            string inList = string.Join(",", docEntries); // ints only, ok


            string sql = $@"
                        SELECT
                            DHSO.""U_TYPE"",
                            DHSO.""DocEntry"",
                            DHSO.""DocNum"",
                            DHSO.""TaxDate"",
                            DHSO.""DocDate"",
                            DHSO.""DocDueDate"",
                            DHSO.""U_StyleNo"",
                            DHSO.""U_CRSZNTRY"",

                            DRSO.""LineNum"",
                            DRSO.""ItemCode"",
                            DRSO.""Dscription"",
                            DRSO.""Quantity"",

                            CRSZ.""U_ColourCode"",
                            CRSZ.""U_ColourName"",
                            CRSZ.""U_SizeCode"",

                            CST.""Code""      AS ""CSMCode"",
                            CST.""U_CADNTRY"",
                            CST.""U_CADNO""
                        FROM OQUT DHSO

                        INNER JOIN (
                            SELECT
                                q.""DocEntry"",
                                q.""LineNum"",
                                q.""ItemCode"",
                                q.""Dscription"",
                                q.""Quantity"",
                                ROW_NUMBER() OVER (PARTITION BY q.""DocEntry"" ORDER BY q.""LineNum"") AS ""LN""
                            FROM QUT1 q
                        ) DRSO
                            ON DRSO.""DocEntry"" = DHSO.""DocEntry""

                        LEFT JOIN ""@FIL_DR_OQUT"" CRSZ
                            ON CRSZ.""DocEntry"" = DHSO.""U_CRSZNTRY""
                           AND CRSZ.""LineId""   = DRSO.""LN""

                        LEFT JOIN ""@FIL_MR_PSMCS"" PSMCS
                            ON PSMCS.""U_DRFTNTRY"" = TO_NVARCHAR(DHSO.""DocEntry"")
                           AND PSMCS.""U_Active""   = 'Y'

                        LEFT JOIN ""@FIL_MH_OCSM"" CST
                            ON CST.""Code"" = PSMCS.""U_Code""

                        WHERE DHSO.""DocEntry"" IN ({inList})
                        ORDER BY DHSO.""DocEntry"", DRSO.""LineNum"";
                        ";

            oForm.Freeze(true);
            try
            {
                // Clear MTXSKUDL fully (like you do in other places)
                mtxSKU.Clear();
                while (mtxSKU.RowCount > 0) mtxSKU.DeleteRow(1);

                SAPbobsCOM.Recordset rs =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                rs.DoQuery(sql);

                if (rs.RecordCount == 0)
                {
                    Application.SBO_Application.MessageBox("No SKU data found for the selected Draft SO.");
                    return;
                }

                int newRow = 1;

                while (!rs.EoF)
                {
                    mtxSKU.AddRow();

                    // If you have line-number column "#", keep it; otherwise comment it

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("#").Cells.Item(newRow).Specific).Value = newRow.ToString();

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLODRTYP").Cells.Item(newRow).Specific).Value = rs.Fields.Item(0).Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLDOCTRY").Cells.Item(newRow).Specific).Value = rs.Fields.Item("DocEntry").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLDOCNUM").Cells.Item(newRow).Specific).Value = rs.Fields.Item("DocNum").Value.ToString();

                    // Dates: matrix edittext usually wants yyyyMMdd in B1
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLODRDAT").Cells.Item(newRow).Specific).Value = SafeDate(rs.Fields.Item("TaxDate").Value);
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLSTRDAT").Cells.Item(newRow).Specific).Value = SafeDate(rs.Fields.Item("DocDate").Value);
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLDUEDAT").Cells.Item(newRow).Specific).Value = SafeDate(rs.Fields.Item("DocDueDate").Value);

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLSTYLNO").Cells.Item(newRow).Specific).Value = rs.Fields.Item("U_StyleNo").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCSYLCD").Cells.Item(newRow).Specific).Value = (ETBYCODE.Value).ToString();

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLITMCOD").Cells.Item(newRow).Specific).Value = rs.Fields.Item("ItemCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLITMNAM").Cells.Item(newRow).Specific).Value = rs.Fields.Item("Dscription").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLODRQTY").Cells.Item(newRow).Specific).Value = rs.Fields.Item("Quantity").Value.ToString();

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCLRCOD").Cells.Item(newRow).Specific).Value = rs.Fields.Item("U_ColourCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCLRNAM").Cells.Item(newRow).Specific).Value = rs.Fields.Item("U_ColourName").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLSZCODE").Cells.Item(newRow).Specific).Value = rs.Fields.Item("U_SizeCode").Value.ToString();

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCSTCOD").Cells.Item(newRow).Specific).Value =rs.Fields.Item("CSMCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCADTRY").Cells.Item(newRow).Specific).Value =rs.Fields.Item("U_CADNTRY").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCADNO").Cells.Item(newRow).Specific).Value = rs.Fields.Item("U_CADNO").Value.ToString();

                    newRow++;
                    rs.MoveNext();
                }
                mtxSKU.AutoResizeColumns();
            }
            finally
            {
                oForm.Freeze(false);
            }
        }



        private string SafeDate(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            if (v is DateTime dt) return dt.ToString("yyyyMMdd"); // best for SAP B1 edittext date
                                                                  // sometimes HANA returns string already
            string s = Convert.ToString(v).Trim();
            // if it's like 2026-01-14 -> convert quick
            if (s.Length >= 10 && s[4] == '-' && s[7] == '-') return s.Replace("-", "");
            return s;
        }

        private void MTXSLODR_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific).Value;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DRFT")
                {

                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_StyleNo";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = styleCode;
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

        private void MTX_RMD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                if (cflArg.SelectedObjects == null || cflArg.SelectedObjects.Rows.Count == 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                switch (pVal.ColUID)
                {
                    case "CLSPLRCD":
                        string cardCode = dt.GetValue("CardCode", 0).ToString().Trim();
                        string cardName = dt.GetValue("CardName", 0).ToString().Trim();

                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSPLRCD")
                            .Cells.Item(pVal.Row).Specific).Value = cardCode;

                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSPLRNM")
                            .Cells.Item(pVal.Row).Specific).Value = cardName;
                        break;

                   
                    case "CLPOUOM":
                        string uomCode = dt.GetValue("UomEntry", 0).ToString().Trim();
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPOUOM").Cells.Item(pVal.Row).Specific).Value = uomCode;

                        break;
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
            }
        }

        //private void MTX_RMD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;

        //        SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

        //        if (oDataTable != null && oDataTable.Rows.Count > 0)
        //        {
        //            string clsplrcd = oDataTable.GetValue("CardCode", 0).ToString().Trim();

        //            ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSPLRCD")
        //                .Cells.Item(pVal.Row).Specific).Value = clsplrcd;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.MessageBox(ex.Message);
        //    }
        //}

        private void MTXSLODR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_MRP1");
                SAPbouiCOM.DataTable oDataTable = cflArg.SelectedObjects;

                if (oDataTable.Rows.Count > 0)
                {
                    string docType = oDataTable.GetValue("U_TYPE", 0).ToString();
                    string docNum = oDataTable.GetValue("DocNum", 0).ToString();
                    string docEntry = oDataTable.GetValue("DocEntry", 0).ToString();
                    string postDate = ToSapDateString(oDataTable.GetValue("DocDate", 0));
                    string delDate = ToSapDateString(oDataTable.GetValue("DocDueDate", 0));
                    string docDate = ToSapDateString(oDataTable.GetValue("TaxDate", 0));
                    string custPO = oDataTable.GetValue("NumAtCard", 0).ToString();
                    string totalQty = oDataTable.GetValue("U_TotalQty", 0).ToString();
                    int row = pVal.Row; // matrix row where CFL triggered
                    //Set Values
                    oMatrix.SetCellWithoutValidation(row, "CLDOCTYP", docType);
                    oMatrix.SetCellWithoutValidation(row, "CLDOCNM", docNum);
                    oMatrix.SetCellWithoutValidation(row, "CLDOCENT", docEntry);
                    oMatrix.SetCellWithoutValidation(row, "CLPDATE", postDate);
                    oMatrix.SetCellWithoutValidation(row, "CLDELDAT", delDate);
                    oMatrix.SetCellWithoutValidation(row, "CLDOCDAT", docDate);
                    oMatrix.SetCellWithoutValidation(row, "CLCUPONO", custPO);
                    oMatrix.SetCellWithoutValidation(row, "CLTOTQTY", totalQty);
                    oMatrix.FlushToDataSource();

                    // Add new row if last row has data
                    int lastRow = oMatrix.RowCount;
                    bool lastRowHasData = !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLDOCENT").Cells.Item(lastRow).Specific).Value);

                    if (pVal.Row == lastRow && lastRowHasData)
                    {
                        Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Draft Matrix CFL Error: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short,
                   SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }
        private static string ToSapDateString(object dtVal)
        {
            if (dtVal == null) return "";

            // If COM returns DateTime already
            if (dtVal is DateTime d1)
                return d1.ToString("yyyyMMdd");

            // Try parse string
            var s = dtVal.ToString().Trim();
            if (string.IsNullOrEmpty(s)) return "";

            // Some cases include time
            if (DateTime.TryParse(s, out DateTime d2))
                return d2.ToString("yyyyMMdd");

            return ""; // fallback
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

                int formWidth = oForm.Width;
                int formHeight = oForm.Height;

                oForm.Items.Item("GRD_PODTL").Top = oForm.Items.Item("STPODTLS").Top + oForm.Items.Item("STPODTLS").Height + 5;
                oForm.Items.Item("GRD_PODTL").Height = (oForm.Items.Item("STRMDTLS").Top - oForm.Items.Item("STPODTLS").Top) - 30;


                oForm.Items.Item("MTX_RMD").Top = oForm.Items.Item("STRMDTLS").Top + 25;
                oForm.Items.Item("MTX_RMD").Height = (oForm.Items.Item("1").Top - oForm.Items.Item("STRMDTLS").Top) - 40;

                SAPbouiCOM.Matrix oMatrix_RMD = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;
                oMatrix_RMD.AutoResizeColumns();

                SAPbouiCOM.Grid oGrid_PODTL = (SAPbouiCOM.Grid)oForm.Items.Item("GRD_PODTL").Specific;
                oGrid_PODTL.AutoResizeColumns();
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
        private void ETSTYLNO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string brandCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific).Value;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_STYL")
                {
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_Brand";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = brandCode;
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
        private void ETSTYLNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();
            string cusCode = dt.GetValue("U_BUYRCODE", 0).ToString().Trim();
            string cusName = dt.GetValue("U_BURSNAME", 0).ToString().Trim();

            ETSTYLNO.Value = Code;
            ETSTYLNM.Value = Name;
            ETBYCODE.Value = cusCode;
            ETBYNAME.Value = cusName;

            EnsureLine(oForm, "MTXSLODR", "@FIL_DR_MRP1");
        }

        private void ETBRNDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();

            ETBRNDCD.Value = Code;
            ETBRNDNM.Value = Name;

        }

        private void ETVND_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string CardCode = dt.GetValue("CardCode", 0).ToString().Trim();

            ETVND.Value = CardCode;
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
        private void ETBRNDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_BRND");

                // Read Style Code
                string cusCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTCD").Specific).Value.Trim();
                if (string.IsNullOrEmpty(cusCode))
                    return;

                // SQL call
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = $@"
                            SELECT T0.""U_BRNDCODE""
                            FROM ""@FIL_MR_CUSTBRDMAP"" T0
                            INNER JOIN ""@FIL_MH_CUSTBRDMAP"" T1 
                                ON T1.""Code"" = T0.""Code""
                            WHERE T1.""U_CUSTCODE"" = '{cusCode}'
                              AND T0.""U_ACTIVE"" = 'Y'";
                rs.DoQuery(sql);

                // Store allowed colour codes into list
                List<string> allowedBrands = new List<string>();
                while (!rs.EoF)
                {
                    string clr = rs.Fields.Item("U_BRNDCODE").Value.ToString();
                    if (!string.IsNullOrEmpty(clr))
                        allowedBrands.Add(clr);

                    rs.MoveNext();
                }

                if (allowedBrands.Count == 0)
                {
                    Application.SBO_Application.MessageBox("Please Map the Customer Brand Relation First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    if (allowedBrands.Count == 0)
                    {
                        SAPbouiCOM.Condition oCon = oCons.Add();
                        oCon.Alias = "Code";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = "-1";
                    }
                    else
                    {
                        for (int i = 0; i < allowedBrands.Count; i++)
                        {
                            SAPbouiCOM.Condition oCon = oCons.Add();
                            oCon.Alias = "Code";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            oCon.CondVal = allowedBrands[i];

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

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            ValidateForm(ref oForm, ref BubbleEvent);
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Matrix MTX_RMD = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;
            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRD_PODTL").Specific;
            SAPbouiCOM.DBDataSource oDB = oForm.DataSources.DBDataSources.Item("@FIL_DR_MRP3");
            FormMode(oForm);
            string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value;
            // Load Po Details
            string qStr = $@"
                       SELECT * FROM 
                         (
                            SELECT 
                                ROW_NUMBER() OVER (ORDER BY T1.""ItemCode"") AS ""SL"",
                                T0.""DocEntry"",
                                T0.""DocNum"",
                                T0.""CardCode"",
                                T0.""CardName"",
                                T1.""ItemCode"",
                                T1.""Dscription"" AS ""ItemName"",
                                T1.""Quantity"",
                                T1.""WhsCode"",
                                T1.""Price"",
                                T1.""TaxCode""
                            FROM ""OPOR"" T0
                            INNER JOIN ""POR1"" T1 ON T1.""DocEntry"" = T0.""DocEntry""
                            WHERE T0.""U_MRPNTRY"" = {docEntry}
                            ORDER BY T0.""DocEntry""
                         )
                         Order By ""SL""";
            oGrid.DataTable.Clear();
            oGrid.DataTable.ExecuteQuery(qStr);
            var docEntryCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("DocEntry");
            docEntryCol.LinkedObjectType = "22";
            docEntryCol.Width = 80;

            for (int i = 1; i <= MTX_RMD.RowCount; i++)
            {
                SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)MTX_RMD.Columns.Item("CLSELECT").Cells.Item(i).Specific;
                if (chk.Checked)
                {
                    MTX_RMD.CommonSetting.SetRowEditable(i, false);

                }
            }

        }

        private void ETCUSTCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CardCode", 0).ToString().Trim();
            string Name = dt.GetValue("CardName", 0).ToString().Trim();

            ETCUSTCD.Value = Code;
            ETCUSTNM.Value = Name;
        }

        private void BTNGTRMD_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbouiCOM.Matrix mtxSKU = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;

            try
            {
                int docEntry = Convert.ToInt32(((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value);
                string qStr = "CALL SP_FIL_MRP_RESULT(" + docEntry + ")";
                rSet.DoQuery(qStr);

                int newRow = 1;

                while (!rSet.EoF)
                {
                    
                    if (newRow > mtxSKU.RowCount)
                    {
                        mtxSKU.AddRow();
                    }
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLLINEID").Cells.Item(newRow).Specific).Value = newRow.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLITEMCD").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("ItemCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLITEMNM").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("ItemName").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPOSITN").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("Position").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCOLCD").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("GMTColorCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCOLNAM").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("GMTColorName").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLSIZECODE").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("GMTSize").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLRMCLRCD").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("RMSizeCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLRMSIZECD").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("RmClorCode").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLUOM").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("MainUom").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPOUOM").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("PurchaseUom").Value.ToString();
                    //string uom = Convert.ToString(rSet.Fields.Item("PurchaseUom").Value).Trim();

                    //if (!string.IsNullOrEmpty(uom))
                    //{
                    //    SAPbouiCOM.EditText txt =
                    //        (SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPOUOM")
                    //        .Cells.Item(newRow).Specific;

                    //    txt.Value = uom;
                    //}
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLSTYLCD").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("U_StyleNo").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCSTLNM").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("U_StyleDesc").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLCURSTK").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("CurrentStock").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLBOMQTY").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("BOMQty").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPPOQTY").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("PrePoQty").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLREMQTY").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("RemQty").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPURQTY").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("PurchaseQty").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPRICE").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("Price").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPURRT").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("Purchaserate").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLBOMVAL").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("BomValue").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLTOTVAL").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("TotalValue").Value.ToString();
                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLPURVAL").Cells.Item(newRow).Specific).Value = rSet.Fields.Item("PurchaseValue").Value.ToString();

                    ((SAPbouiCOM.EditText)mtxSKU.Columns.Item("CLMRPLINE").Cells.Item(newRow).Specific).Value = (newRow - 1).ToString();

                    newRow++;
                    rSet.MoveNext();
                }

                mtxSKU.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
    
        private void BTNPPO_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            ValidateForm(ref oForm, ref BubbleEvent);

        }


        private void BTNPPO_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            Application.SBO_Application.StatusBar.SetText("Please wait... Processing", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
            SAPbobsCOM.Documents oPurchaseOrder = (SAPbobsCOM.Documents)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
            SAPbouiCOM.Matrix MTX_RMD = (SAPbouiCOM.Matrix)oForm.Items.Item("MTX_RMD").Specific;
            SAPbouiCOM.DBDataSource oDB = oForm.DataSources.DBDataSources.Item("@FIL_DR_MRP3");
            SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            try
            {
                string bpcode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVND").Specific).Value;
                int paymentTerm = Convert.ToInt32(((SAPbouiCOM.ComboBox)oForm.Items.Item("CBPAYTRM").Specific).Value);
                int shippingType = Convert.ToInt32(((SAPbouiCOM.ComboBox)oForm.Items.Item("CBSHPTYP").Specific).Value);
                //string shipForm = ((SAPbouiCOM.ComboBox)oForm.Items.Item("CBSHPFRM").Specific).Value;
                string DocEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value;


                oPurchaseOrder.CardCode = bpcode;
                oPurchaseOrder.BPL_IDAssignedToInvoice = 1;
                oPurchaseOrder.GroupNumber = paymentTerm;
                oPurchaseOrder.TransportationCode = shippingType;
                // oPurchaseOrder.ShipToCode = shipForm;

                oPurchaseOrder.UserFields.Fields.Item("U_MRPNTRY").Value = DocEntry;

                for (int i = 1; i <= MTX_RMD.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)MTX_RMD.Columns.Item("CLSELECT").Cells.Item(i).Specific;
                    SAPbouiCOM.EditText poDocEntry = (SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLPOENTR").Cells.Item(i).Specific;
                    if (chk.Checked && poDocEntry.Value == "")
                    {
                        string itemCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLITEMCD").Cells.Item(i).Specific).Value;
                        double Quantity = Convert.ToDouble(((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLPURQTY").Cells.Item(i).Specific).Value);
                        double unitPrice = Convert.ToDouble(((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLPRICE").Cells.Item(i).Specific).Value);
                        int mrpLine = Convert.ToInt32(((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLMRPLINE").Cells.Item(i).Specific).Value);

                        string styleCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLSTYLCD").Cells.Item(i).Specific).Value;
                        string gmtColorCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLCOLCD").Cells.Item(i).Specific).Value;
                        string gmtColorName = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLCOLNAM").Cells.Item(i).Specific).Value;
                        string gmtSize = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLSIZECODE").Cells.Item(i).Specific).Value;
                        string rmSizeCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLRMSIZECD").Cells.Item(i).Specific).Value;
                        string rmColorCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLRMCLRCD").Cells.Item(i).Specific).Value;
                        string buyerStyleCode = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLCSTYCD").Cells.Item(i).Specific).Value;
                        string buyerStyleName = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLCSTLNM").Cells.Item(i).Specific).Value;
                        string position = ((SAPbouiCOM.EditText)MTX_RMD.Columns.Item("CLPOSITN").Cells.Item(i).Specific).Value;

                        oPurchaseOrder.Lines.ItemCode = itemCode;
                        oPurchaseOrder.Lines.Quantity = Quantity;
                        oPurchaseOrder.Lines.UnitPrice = unitPrice;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_MRPNTRY").Value = DocEntry;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_MRPLINE").Value = mrpLine;

                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_StyleCode").Value = styleCode;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_FGCOLOUR").Value = gmtColorCode;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_FGCOLRNM").Value = gmtColorName;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_FGSIZE").Value = gmtSize;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_RMSIZE").Value = rmSizeCode;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_RMCOLOUR").Value = rmColorCode;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_BUYRSTCD").Value = buyerStyleCode;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_BUYRSTNM").Value = buyerStyleName;
                        oPurchaseOrder.Lines.UserFields.Fields.Item("U_POSITION").Value = position;


                        oPurchaseOrder.Lines.Add();

                    }
                }

                if (oPurchaseOrder.Add() != 0)
                {
                    Application.SBO_Application.StatusBar.SetText(Global.oComp.GetLastErrorDescription());
                    Global.GFunc.ShowError(Global.oComp.GetLastErrorDescription());

                }
                else
                {
                    try
                    {
                        int PoDocEntry = int.Parse(Global.oComp.GetNewObjectKey());
                        Global.GFunc.ShowSuccess("PO Posted Successfully. ");

                        SAPbouiCOM.Form oForms = Application.SBO_Application.Forms.Item(pVal.FormUID);

                        oForm.Freeze(true);
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                        {
                            oForm.Items.Item("1").Click();
                          //  oForm.Freeze(false);
                        }

                        //Update MRP 
                        string qsTr =
                                $"UPDATE C " +
                                $"SET " +
                                $"C.\"U_PODocEntry\" = A.\"DocEntry\", " +
                                $"C.\"U_POLINE\" = A.\"LineNum\", " +
                                $"C.\"U_PODocNum\" = B.\"DocNum\", " +
                                $"C.\"U_POTYPE\" = '22', " +   // <-- comma was missing here
                                $"C.\"U_RemQty\" = (C.\"U_BOMQty\" - C.\"U_Quantity\") " +
                                $"FROM \"@FIL_DR_MRP3\" C " +
                                $"INNER JOIN \"POR1\" A ON C.\"DocEntry\" = A.\"U_MRPNTRY\" AND C.\"U_MRPLINE\" = A.\"U_MRPLINE\" " +
                                $"INNER JOIN \"OPOR\" B ON A.\"DocEntry\" = B.\"DocEntry\" " +
                                $"WHERE A.\"DocEntry\" = {PoDocEntry}";
                        rSet.DoQuery(qsTr);
                        Global.G_UI_Application.ActivateMenuItem("1304");
                        oForm.Freeze(false);
                    }

                    catch (Exception ex)
                    {
                       oForm.Freeze(false);
                    }
                    finally
                    {
                      oForm.Freeze(false);
                    }
                }

            }
            catch (Exception ex)
            {
                oForm.Freeze(false);
            }

        }


        private void FormMode(SAPbouiCOM.Form pForm)
        {
            try
            {
                SAPbouiCOM.Matrix MTXSKUDL = (SAPbouiCOM.Matrix)pForm.Items.Item("MTXSKUDL").Specific;

                if (MTXSKUDL.RowCount > 0)
                {
                    pForm.Items.Item("BTNGTSKU").Enabled = false;
                }
            }
            catch (Exception exception1)
            {

                Application.SBO_Application.StatusBar.SetText("DeleteRow  Method Failed:" + exception1.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

            }
        }
        private static bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {

            //if (((SAPbouiCOM.EditText)oForm.Items.Item("ETVND").Specific).Value == "")
            //{
            //    BubbleEvent = false;
            //    Global.GFunc.ShowError("Please Enter Vendor Code");
            //    oForm.ActiveItem = "ETVND";
            //    return BubbleEvent;
            //}


            SAPbouiCOM.Matrix MTXSKUDL = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSKUDL").Specific;

            for(int i = 1; i <= MTXSKUDL.VisualRowCount; i++)
            {
                double orderQty = Convert.ToDouble(((SAPbouiCOM.EditText)MTXSKUDL.Columns.Item("CLODRQTY").Cells.Item(i).Specific).Value);
                double mrpQty = Convert.ToDouble(((SAPbouiCOM.EditText)MTXSKUDL.Columns.Item("CLMRPQTY").Cells.Item(i).Specific).Value);
                double planQty = Convert.ToDouble(((SAPbouiCOM.EditText)MTXSKUDL.Columns.Item("CLPLNQTY").Cells.Item(i).Specific).Value);

                if(orderQty < (mrpQty + planQty))
                {
                    BubbleEvent = false;
                    Global.GFunc.ShowError("MRP Quantity can not be gretter than Order Quantity.");
                    return BubbleEvent;
                }
            }


            return BubbleEvent;
        }
    }
}
