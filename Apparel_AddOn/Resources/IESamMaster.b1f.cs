using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.IESamMaster", "Resources/IESamMaster.b1f")]
    class IESamMaster : UserFormBase
    {
        public IESamMaster()
        {
        }
        // ---- StaticTexts ----
        private SAPbouiCOM.StaticText STCODE, STCUSCOD, STSTYLCD, STBRND, STPDTPCD,
            STPDLNCD, STPDGPCD, STPDCYCD, STCURR, STROUTCD;
   

        // ---- EditTexts ----
        private SAPbouiCOM.EditText ETCODE, ETPDTPNM, ETDOCTRY, ETCUSCOD,ETSTYLCD, 
            ETSTYLNM, ETBRNDCD, ETBRNDNM, ETPDTPCD, ETPDLNCD, ETPDCYCD, ETPDGPCD, 
            ETPDGPNM, ETCUSNAM, ETCURR, ETPDCYNM, ETPDLNNM, ETROUTCD,ETNAME;



        private SAPbouiCOM.Matrix MTXSAM;
        private SAPbouiCOM.Button ADDButton, CancelButton;

        private SAPbouiCOM.LinkedButton LKSTYLCD;

        public override void OnInitializeComponent()
        {
            //         ---- StaticTexts ----
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STSTYLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.STBRND = ((SAPbouiCOM.StaticText)(this.GetItem("STBRND").Specific));
            this.STPDTPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDTPCD").Specific));
            this.STPDLNCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDLNCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STPDCYCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDCYCD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STROUTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STROUTCD").Specific));
            //         ---- EditTexts ----
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETPDTPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDTPNM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETSTYLCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSTYLCD_ChooseFromListBefore);
            this.ETSTYLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLCD_ChooseFromListAfter);
            this.ETSTYLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLNM").Specific));
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETBRNDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNDCD_ChooseFromListBefore);
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETPDTPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDTPCD").Specific));
            this.ETPDLNCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDLNCD").Specific));
            this.ETPDCYCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDCYCD").Specific));
            this.ETPDGPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPCD").Specific));
            this.ETPDGPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETPDCYNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDCYNM").Specific));
            this.ETPDLNNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDLNNM").Specific));
            this.ETROUTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETROUTCD").Specific));
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            //         ---- Matrix ----
            this.MTXSAM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAM").Specific));
            //        ----Buttons-----
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.LKSTYLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLCD").Specific));
            this.LKSTYLCD.ClickBefore += new SAPbouiCOM._ILinkedButtonEvents_ClickBeforeEventHandler(this.LKSTYLCD_ClickBefore);
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }



        private void OnCustomInitialize()
        {

        }

        private void ETSTYLCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;
                
                // Read Brand Code
                string brandCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific).Value.Trim();
                if (string.IsNullOrEmpty(brandCode))
                {
                    Application.SBO_Application.MessageBox("Please Select Brand First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {
                    if (cflUID == "CFL_OPSM")
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
           
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string code = dt.GetValue("Code", 0).ToString().Trim();
            string name = dt.GetValue("Name", 0).ToString().Trim();


            ETBRNDCD.Value = code;
            ETBRNDNM.Value = name;

        }

        private void ETBRNDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_BRND");

                // Read Style Code
                string cusCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific).Value.Trim();
                if (string.IsNullOrEmpty(cusCode))
                {
                    Application.SBO_Application.MessageBox("Please Select Customer First ", 1, "OK");
                    BubbleEvent = false;
                    return;
                }
                else
                {
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
                    List<string> allowedColors = new List<string>();
                    while (!rs.EoF)
                    {
                        string clr = rs.Fields.Item("U_BRNDCODE").Value.ToString();
                        if (!string.IsNullOrEmpty(clr))
                            allowedColors.Add(clr);

                        rs.MoveNext();
                    }

                    if (allowedColors.Count == 0)
                    {
                        Application.SBO_Application.MessageBox("Please Map the Customer Brand Relation First ", 1, "OK");
                        BubbleEvent = false;
                        return;
                    }
                    else
                    {

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

        private void LKSTYLCD_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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
        private void ETCUSCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CardCode", 0).ToString().Trim();
            string Name = dt.GetValue("CardName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCUSCOD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific;
            ETCUSCOD.Value = Code;
            SAPbouiCOM.EditText ETCUSNAM = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSNAM").Specific;
            ETCUSNAM.Value = Name;
            //Size Type Matrix On
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_MR_IESAMMST");
            int lastRow = oMatrix.RowCount;
            if (lastRow == 0)
            {
                Global.GFunc.SetNewLine(oMatrix, DBDataSourceLine, 1, "");
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
            string route = dt.GetValue("U_RSTemp", 0).ToString().Trim();
            string type = dt.GetValue("U_PRDTPCD", 0).ToString().Trim();
            string typeName = dt.GetValue("U_PRDTPNM", 0).ToString().Trim();
            string line = dt.GetValue("U_PrdLine", 0).ToString().Trim();
            string lineName = dt.GetValue("U_PrdLineN", 0).ToString().Trim();
            string grp = dt.GetValue("U_PrGroup", 0).ToString().Trim();
            string grpName = dt.GetValue("U_PrGroupN", 0).ToString().Trim();
            string cat = dt.GetValue("U_PrCateg", 0).ToString().Trim();
            string catName = dt.GetValue("U_PrCategN", 0).ToString().Trim();


            SAPbouiCOM.EditText ETSTYLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific;
            SAPbouiCOM.EditText ETSTYLNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNM").Specific;
            SAPbouiCOM.EditText ETCURR = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            SAPbouiCOM.EditText ETROUTCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETROUTCD").Specific;
            SAPbouiCOM.EditText ETPDTPCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTPCD").Specific;
            SAPbouiCOM.EditText ETPDTPNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDTPNM").Specific;
            SAPbouiCOM.EditText ETPDLNCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNCD").Specific;
            SAPbouiCOM.EditText ETPDLNNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDLNNM").Specific;
            SAPbouiCOM.EditText ETPDGPCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific;
            SAPbouiCOM.EditText ETPDGPNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPNM").Specific;
            SAPbouiCOM.EditText ETPDCYCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDCYCD").Specific;
            SAPbouiCOM.EditText ETPDCYNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETPDCYNM").Specific;

            // assign values
            ETSTYLCD.Value = Code;
            ETSTYLNM.Value = Name;
            ETCODE.Value = Code;
            ETCURR.Value = curr;
            ETROUTCD.Value = route;
            ETPDTPCD.Value = type;
            ETPDTPNM.Value = typeName;
            ETPDLNCD.Value = line;
            ETPDLNNM.Value = lineName;
            ETPDGPCD.Value = grp;
            ETPDGPNM.Value = grpName;
            ETPDCYCD.Value = cat;
            ETPDCYNM.Value = catName;


            LoadMatrixData(oForm, route);

        }
        private void LoadMatrixData(SAPbouiCOM.Form oForm, string route)
        {
            try
            {
                // --- Get the matrix ---
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;

                // --- Get the underlying DataTable (optional, for query results) ---
                SAPbouiCOM.DataTable oDT = oForm.DataSources.DataTables.Item("DT_SAM");
                oDT.Clear();

                // --- Execute SQL query ---
                string sql = $@"
            SELECT 
                B.""U_Code"" AS ""CLROUTCD"", 
                B.""U_Name"" AS ""CLROUTNM""
            FROM ""@FIL_MH_ORSM"" AS A
            INNER JOIN ""@FIL_MR_RSM1"" AS B
            ON A.""Code"" = B.""Code""
            WHERE A.""Code"" = '{route}'";

                oDT.ExecuteQuery(sql);

                // --- Clear existing matrix rows ---
                if (oMatrix.RowCount > 0)
                    oMatrix.Clear();

                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    oMatrix.AddRow();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(i + 1).Specific).Value =(i + 1).ToString();

                    // Cast each cell's Specific to the correct control type (EditText)
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLROUTCD").Cells.Item(i + 1).Specific).Value =
                        oDT.GetValue("CLROUTCD", i).ToString();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLROUTNM").Cells.Item(i + 1).Specific).Value =
                        oDT.GetValue("CLROUTNM", i).ToString();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSAM").Cells.Item(i + 1).Specific).Value = "0"; // default
                }


                // --- Auto resize columns ---
                oMatrix.AutoResizeColumns();

                Application.SBO_Application.SetStatusBarMessage(
                    $"Matrix loaded for route: {route}", SAPbouiCOM.BoMessageTime.bmt_Short, false);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error loading matrix: " + ex.Message);
            }
        }


    }
}
