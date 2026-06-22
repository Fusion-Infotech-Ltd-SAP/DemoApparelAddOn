using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
using Apparel_AddOn.Helper;
using Apparel_AddOn.Resources;

namespace Apparel_AddOn.Modules
{
    class StandardFormManipulation
    {
        public StandardFormManipulation()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
        }

        private string lastFocusedItemUID = "";
        private string lastFocusedColUID = "";

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (pVal.FormUID == "FIL_FRM_B2BLC_AMEND")
            {
                if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_GOT_FOCUS ||
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                {
                    lastFocusedItemUID = pVal.ItemUID;
                    lastFocusedColUID = pVal.ColUID; 
                }
            }
            else if (pVal.FormUID == "FIL_FRM_MLC_AMEND")
            {
                if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_GOT_FOCUS ||
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                {
                    lastFocusedItemUID = pVal.ItemUID;
                    lastFocusedColUID = pVal.ColUID;
                }
            }
            else if (pVal.FormUID == "FIL_FRM_B2BLC")
            {
                if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_GOT_FOCUS ||
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                {
                    lastFocusedItemUID = pVal.ItemUID;
                    lastFocusedColUID = pVal.ColUID; 
                }
            }
            else if (pVal.FormUID == "FIL_FRM_SCAMEND")
            {
                if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_GOT_FOCUS ||
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                {
                    lastFocusedItemUID = pVal.ItemUID;
                    lastFocusedColUID = pVal.ColUID; // only for matrix columns, empty for EditText
                }
            }
            else if (pVal.FormUID == "FIL_FRM_COSTING")
            {
                if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_GOT_FOCUS ||
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                {
                    lastFocusedItemUID = pVal.ItemUID;
                    lastFocusedColUID = pVal.ColUID; // only for matrix columns, empty for EditText
                }
            }


            if (pVal.FormTypeEx == "9999" && pVal.ItemUID == "1" && pVal.BeforeAction == true && pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED ||
                pVal.FormTypeEx == "9999" && pVal.ItemUID == "7" && pVal.BeforeAction == true && pVal.EventType == SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK)
            {
                try
                {
                    SAPbouiCOM.Form ofrm = null;
                    string openForm = "";
                    // Detect which of the three forms is open
                    foreach (string formUID in new[] { "FIL_FRM_MLC_AMEND", "FIL_FRM_B2BLC_AMEND", "FIL_FRM_B2BLC", "FIL_FRM_SCAMEND", "FIL_FRM_COSTING" })
                    {
                        try
                        {
                            ofrm = Application.SBO_Application.Forms.Item(formUID);
                            openForm = formUID;
                            break; // stop once we found one
                        }
                        catch
                        {
                            // not open → keep checking
                        }
                    }

                    if (ofrm == null) return; // no relevant form is open

                    // Branch logic based on which form is open
                    if (openForm == "FIL_FRM_MLC_AMEND")
                    {
                        if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                        {
                            ofrm.Freeze(true);
                            // Get selected value from CBSERISE
                            string LCno = "";
                            string amdno = "";
                            if (string.IsNullOrEmpty(LCno))
                            {
                                // ── Get value from Form 9999 Matrix ──
                                SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                if (rowSelected > 0)
                                {
                                    LCno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCNo").Cells.Item(rowSelected).Specific).Value;
                                    amdno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCAMDNO").Cells.Item(rowSelected).Specific).Value;
                                }
                            }

                            int maxAmdNo = 0; // default value if nothing found

                            // Create Recordset
                            SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                            // Build SQL
                            string sql = $@"SELECT MAX(""U_LCAMDNO"") AS ""MAX_AMDNO"" FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNo"" = '{LCno}'";

                            // Execute Query
                            oRec.DoQuery(sql);

                            // Read result
                            if (!oRec.EoF && oRec.Fields.Item("MAX_AMDNO").Value != null && oRec.Fields.Item("MAX_AMDNO").Value.ToString() != "")
                            {
                                int.TryParse(oRec.Fields.Item("MAX_AMDNO").Value.ToString(), out maxAmdNo);
                            }

                            int amendmentno;

                            if (amdno == "")
                            {
                                amendmentno = 0;
                            }
                            else
                            {
                                amendmentno = int.Parse(amdno);
                            }
                            // Now maxAmdNo holds the max U_LCAMDNO as integer

                            if (amendmentno == maxAmdNo)
                            {

                                string sqlQuery = $@"SELECT 
                             ROW_NUMBER() OVER (ORDER BY ""U_LCAMDNO"" DESC) AS ""#"",  -- serial number
                             ""U_LCAMDNO"",""CreateDate"", ""U_CardCode"" AS ""CardCode"", ""U_LCNo"" AS ""LCNo"",
                             ""U_SCNo"" AS ""SCNo"",""U_Desc"" AS ""Desc"",""U_DocDate"" AS ""DocDate"",""U_IssueDate"" AS ""IssueDate"",
                             ""U_ShipDate"" AS ""ShipDate"",""U_ExpDate"" AS ""ExpDate"",""U_Amt"" AS ""Amount"",""U_Curr"" AS ""Currency"",
                             ""U_IssueBank"" AS ""IssuBank"",""U_NegBank"" AS ""NegoBank"",""U_PTerm1"" AS ""Payment"",""U_PTerm2"" AS ""Days"",
                             ""U_INCOTRMS"" AS ""Inco Terms"" FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNo"" = '{LCno}' ORDER BY ""U_LCAMDNO"" DESC";


                                // Execute Query and Load into DataTable
                                SAPbouiCOM.DataTable dt = ofrm.DataSources.DataTables.Item("DTAMEND");
                                dt.ExecuteQuery(sqlQuery);

                                // Bind the Grid
                                SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)ofrm.Items.Item("GRIDAMND").Specific;
                                grid.DataTable = dt;

                                Application.SBO_Application.StatusBar.SetText("Amendment History Loaded.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                            }
                            else
                            {
                                Application.SBO_Application.StatusBar.SetText("Cannot access Older Version.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                // Optional delay to let user see the message (not mandatory)
                                System.Threading.Thread.Sleep(500); // half a second

                                // Close the form
                                Application.SBO_Application.Forms.Item(ofrm.UniqueID).Close();
                                ofrm.Freeze(false);

                                BubbleEvent = false;
                                return;
                            }
                            ofrm.Freeze(false);
                        }
                    }
                    else if (openForm == "FIL_FRM_B2BLC_AMEND")
                    {
                        if (lastFocusedItemUID == "ETB2LCNO")
                        {
                            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                            {
                                ofrm.Freeze(true);
                                // Get selected value from CBSERISE
                                string LCno = "";
                                string amdno = "";
                                if (string.IsNullOrEmpty(LCno))
                                {
                                    // ── Get value from Form 9999 Matrix ──
                                    SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                    int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                    if (rowSelected > 0)
                                    {
                                        LCno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCNo").Cells.Item(rowSelected).Specific).Value;
                                        amdno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_BTBAMNO").Cells.Item(rowSelected).Specific).Value;
                                    }
                                }

                                int maxAmdNo = 0; // default value if nothing found

                                // Create Recordset
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                // Build SQL
                                string sql = $@"SELECT MAX(""U_BTBAMNO"") AS ""MAX_AMDNO"" FROM ""@FIL_DH_OLCB"" WHERE ""U_LCNo"" = '{LCno}'";

                                // Execute Query
                                oRec.DoQuery(sql);

                                // Read result
                                if (!oRec.EoF && oRec.Fields.Item("MAX_AMDNO").Value != null && oRec.Fields.Item("MAX_AMDNO").Value.ToString() != "")
                                {
                                    int.TryParse(oRec.Fields.Item("MAX_AMDNO").Value.ToString(), out maxAmdNo);
                                }

                                int amendmentno;

                                if (amdno == "")
                                {
                                    amendmentno = 0;
                                }
                                else
                                {
                                    amendmentno = int.Parse(amdno);
                                }
                                // Now maxAmdNo holds the max U_LCAMDNO as integer

                                if (amendmentno == maxAmdNo)
                                {

                                    string sqlQuery = $@"
                                    SELECT ROW_NUMBER() OVER (ORDER BY ""U_BTBAMNO"" DESC) AS ""#"",  -- serial number
                                    ""U_BTBAMNO"" AS ""AMDNO"",""U_LCNo"" AS ""B2BLCNo"",""U_IssueBank"" AS ""IssuBank"",""U_SUPPBANK"" AS ""NegBank"",""U_CardCode"" AS ""CardCode"",
                                    ""U_Amt"" AS ""Value"",""U_DocDate"" AS ""DocDate"",""U_IssueDate"" AS ""IssueDate"",""U_ShipDate"" AS ""ShipDate"",""U_ExpDate"" AS ""ExpDate"", 
                                    ""U_PTerm1"" AS ""Payment"",""U_PTerm2"" AS ""Days"",""U_INCOTRMS"" AS ""Inco Terms"",""U_HSCODE"" AS ""HSCODE""FROM ""@FIL_DH_OLCB""
                                    WHERE ""U_LCNo"" = '{LCno}'ORDER BY ""U_BTBAMNO"" DESC";


                                    // Execute Query and Load into DataTable
                                    SAPbouiCOM.DataTable dt = ofrm.DataSources.DataTables.Item("DT_B2BAMD");
                                    dt.ExecuteQuery(sqlQuery);

                                    // Bind the Grid
                                    SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)ofrm.Items.Item("GRIDAMDH").Specific;
                                    grid.DataTable = dt;

                                    Application.SBO_Application.StatusBar.SetText("B2B Amendment History Loaded.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                                }
                                else
                                {
                                    Application.SBO_Application.StatusBar.SetText("Cannot access Older Version.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                    // Optional delay to let user see the message (not mandatory)
                                    System.Threading.Thread.Sleep(500); // half a second

                                    // Close the form
                                    Application.SBO_Application.Forms.Item(ofrm.UniqueID).Close();
                                    ofrm.Freeze(false);

                                    BubbleEvent = false;
                                    return;
                                }
                                ofrm.Freeze(false);
                            }
                        }
                        else if (lastFocusedItemUID == "MTXMLCDS" && lastFocusedColUID == "CLLCCODE")
                        {
                            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                            {
                                ofrm.Freeze(true);
                                // Get selected value from CBSERISE
                                string LCno = "";
                                string amdno = "";
                                if (string.IsNullOrEmpty(LCno))
                                {
                                    // ── Get value from Form 9999 Matrix ──
                                    SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                    int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                    if (rowSelected > 0)
                                    {
                                        LCno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCNo").Cells.Item(rowSelected).Specific).Value;
                                        amdno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCAMDNO").Cells.Item(rowSelected).Specific).Value;
                                    }
                                }

                                int maxAmdNo = 0; // default value if nothing found

                                // Create Recordset
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                // Build SQL
                                string sql = $@"SELECT MAX(""U_LCAMDNO"") AS ""MAX_AMDNO"" FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNo"" = '{LCno}'";

                                // Execute Query
                                oRec.DoQuery(sql);

                                // Read result
                                if (!oRec.EoF && oRec.Fields.Item("MAX_AMDNO").Value != null && oRec.Fields.Item("MAX_AMDNO").Value.ToString() != "")
                                {
                                    int.TryParse(oRec.Fields.Item("MAX_AMDNO").Value.ToString(), out maxAmdNo);
                                }

                                int amendmentno;

                                if (amdno == "")
                                {
                                    amendmentno = 0;
                                }
                                else
                                {
                                    amendmentno = int.Parse(amdno);
                                }


                                if (amendmentno != maxAmdNo)
                                {
                                    int response = Application.SBO_Application.MessageBox("OPPS!!! You have chosen the older Version", 1, "OK", "", "");

                                    if (response == 1) // OK clicked
                                    {
                                        SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                        ofrm.Freeze(false);
                                        frm9999.Close();
                                        BubbleEvent = false;
                                        return;
                                    }

                                }

                                ofrm.Freeze(false);
                            }
                        }

                    }

                    else if (openForm == "FIL_FRM_B2BLC")
                    {
                        if (lastFocusedItemUID == "ETB2LCNO")
                        {

                        }
                        else if (lastFocusedItemUID == "MTXMLCDS" && lastFocusedColUID == "CLLCCODE")
                        {
                            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                            {
                                ofrm.Freeze(true);
                                // Get selected value from CBSERISE
                                string LCno = "";
                                string amdno = "";
                                if (string.IsNullOrEmpty(LCno))
                                {
                                    // ── Get value from Form 9999 Matrix ──
                                    SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                    int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                    if (rowSelected > 0)
                                    {
                                        LCno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCNo").Cells.Item(rowSelected).Specific).Value;
                                        amdno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_LCAMDNO").Cells.Item(rowSelected).Specific).Value;
                                    }
                                }

                                int maxAmdNo = 0; // default value if nothing found

                                // Create Recordset
                                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                // Build SQL
                                string sql = $@"SELECT MAX(""U_LCAMDNO"") AS ""MAX_AMDNO"" FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNo"" = '{LCno}'";

                                // Execute Query
                                oRec.DoQuery(sql);

                                // Read result
                                if (!oRec.EoF && oRec.Fields.Item("MAX_AMDNO").Value != null && oRec.Fields.Item("MAX_AMDNO").Value.ToString() != "")
                                {
                                    int.TryParse(oRec.Fields.Item("MAX_AMDNO").Value.ToString(), out maxAmdNo);
                                }

                                int amendmentno;

                                if (amdno == "")
                                {
                                    amendmentno = 0;
                                }
                                else
                                {
                                    amendmentno = int.Parse(amdno);
                                }


                                if (amendmentno != maxAmdNo)
                                {
                                    int response = Application.SBO_Application.MessageBox("OPPS!!! You have chosen the older Version", 1, "OK", "", "");

                                    if (response == 1) // OK clicked
                                    {
                                        SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                        ofrm.Freeze(false);
                                        frm9999.Close();
                                        BubbleEvent = false;
                                        return;
                                    }
                                    
                                }

                                ofrm.Freeze(false);
                            }
                        }
                    }
                    else if (openForm == "FIL_FRM_SCAMEND")
                    {

                        if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                        {
                            ofrm.Freeze(true);
                            string scNo = "";
                            string amdno = "";
                            if (string.IsNullOrEmpty(scNo))
                            {
                                // ── Get value from Form 9999 Matrix ──
                                SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                if (rowSelected > 0)
                                {
                                    scNo = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_SCNo").Cells.Item(rowSelected).Specific).Value;
                                    amdno = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_SCAMDNO").Cells.Item(rowSelected).Specific).Value;
                                }
                            }

                            int maxAmdNo = 0; // default value if nothing found

                            // Create Recordset
                            SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                            // Build SQL
                            string sql = $@"SELECT MAX(""U_SCAMDNO"") AS ""MAX_AMDNO"" FROM ""@FIL_DH_OSCM"" WHERE ""U_SCNo"" = '{scNo}'";

                            // Execute Query
                            oRec.DoQuery(sql);

                            // Read result
                            if (!oRec.EoF && oRec.Fields.Item("MAX_AMDNO").Value != null && oRec.Fields.Item("MAX_AMDNO").Value.ToString() != "")
                            {
                                int.TryParse(oRec.Fields.Item("MAX_AMDNO").Value.ToString(), out maxAmdNo);
                            }

                            int amendmentno;

                            if (amdno == "")
                            {
                                amendmentno = 0;
                            }
                            else
                            {
                                amendmentno = int.Parse(amdno);
                            }
                            // Now maxAmdNo holds the max U_LCAMDNO as integer

                            if (amendmentno == maxAmdNo)
                            {

                                string sqlQuery = $@"SELECT ROW_NUMBER() OVER (ORDER BY ""U_SCAMDNO"" DESC) AS ""#"",  -- serial number
                                ""U_SCAMDNO"",""CreateDate"",""U_CardCode"" AS ""CardCode"",""U_BRANDCD"" AS ""Brand"",""U_SCNo"" AS ""SCNo"",""U_SCVALUE"" AS ""SC Value"",
                                ""U_Desc"" AS ""Desc"",""U_DocDate"" AS ""DocDate"",""U_IssueDate"" AS ""IssueDate"",""U_ShipDate"" AS ""ShipDate"",""U_ExpDate"" AS ""ExpDate"",
                                ""U_Amt"" AS ""Amount"",""U_Curr"" AS ""Currency"",""U_IssueBank"" AS ""IssuBank"",""U_NegBank"" AS ""NegoBank""
                                FROM ""@FIL_DH_OSCM"" WHERE ""U_SCNo"" = '{scNo}' ORDER BY ""U_SCAMDNO"" DESC";


                                // Execute Query and Load into DataTable
                                SAPbouiCOM.DataTable dt = ofrm.DataSources.DataTables.Item("DTSCAMND");
                                dt.ExecuteQuery(sqlQuery);

                                // Bind the Grid
                                SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)ofrm.Items.Item("GRDAMDMT").Specific;
                                grid.DataTable = dt;

                                Application.SBO_Application.StatusBar.SetText("Amendment History Loaded.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                            }
                            else
                            {
                                int response = Application.SBO_Application.MessageBox("OPPS!!! You have chosen the older Version", 1, "OK", "", "");

                                if (response == 1) // OK clicked
                                {
                                    SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                    ofrm.Freeze(false);
                                    frm9999.Close();
                                    BubbleEvent = false;
                                    return;
                                }
                            }
                            ofrm.Freeze(false);

                        }

                        
                    }
                    else if (openForm == "FIL_FRM_COSTING")
                    {
                        if (lastFocusedItemUID == "MTXCOLOR" && lastFocusedColUID == "CLCRCODE")
                        {
                            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                            {
                                ofrm.Freeze(true);
                                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_COSTING");   // FormUID
                                string cstCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCSHTCD").Specific).Value.Trim();
                                string clrCode = "";
                                if (string.IsNullOrEmpty(cstCode))
                                {
                                    return;
                                }
                                else
                                {
                                    SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)frm9999.Items.Item("7").Specific;

                                    int rowSelected = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                    if (rowSelected > 0)
                                    {
                                        clrCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("Code").Cells.Item(rowSelected).Specific).Value;
                                    }
                                }



                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                string sql = $@"SELECT 
                                             CASE 
                                                 WHEN EXISTS (
                                                                SELECT 1 
                                                                FROM ""@FIL_MR_CSMCLR""
                                                                WHERE ""Code"" = '{cstCode}'
                                                                AND ""U_CLRCODE"" = '{clrCode}'
                                                               ) THEN 1 
                                                               ELSE 0 
                                                              END AS ""IS_EXIST""
                                                             FROM DUMMY; ";

                                oRS.DoQuery(sql);

                                // Store result in int variable
                                int isExist = Convert.ToInt32(oRS.Fields.Item("IS_EXIST").Value);

                                // Example usage
                                if (isExist == 1)
                                {
                                    int response = Application.SBO_Application.MessageBox("OPPS!!! This Colour is already taken", 1, "OK", "", "");

                                    if (response == 1) // OK clicked
                                    {
                                        SAPbouiCOM.Form frm9999 = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                        ofrm.Freeze(false);
                                        frm9999.Close();
                                        BubbleEvent = false;
                                        return;
                                    }
                                }                                
                                ofrm.Freeze(false);

                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
            }


        }
    }
}
