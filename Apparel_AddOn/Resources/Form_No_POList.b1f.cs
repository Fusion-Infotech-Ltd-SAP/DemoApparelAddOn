using Apparel_AddOn.Helper;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.Form_No_POList", "Resources/Form_No_POList.b1f")]
    class Form_No_POList : UserFormBase
    {
        private SAPbouiCOM.Button BTSELECT;
        public Form_No_POList()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.BTSELECT = ((SAPbouiCOM.Button)(this.GetItem("BTSELECT").Specific));
            this.BTSELECT.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTSELECT_PressedAfter);
            this.BTSELECT.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTSELECT_PressedBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        internal static void LoadPOList(ref SAPbouiCOM.Form pForm, string strDocEntry)
        {
            int count = strDocEntry.Split(',').Length;
            pForm.Freeze(true);
            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)pForm.Items.Item("GRID01").Specific;

                string qStr = @"
                                SELECT 
                                    T1.""DocEntry"" AS ""POEntry"",
                                    T1.""LineNum"" AS ""BaseLine"",
                                    T0.""DocNum"" AS ""PONumber"",
                                    T0.""ObjType"",
                                    T1.""ItemCode"" AS ""ItemCode"",
                                    T1.""Dscription"" AS ""ItemDescription"",
                                    T1.""Quantity"",
                                    T1.""Price"" AS ""UnitPrice"",
                                    T1.""TaxCode"" AS ""TaxCode"",
                                    (T1.""GTotal"" - T1.""LineTotal"") AS ""TaxValue"",
                                    T1.""GTotal""
                                FROM ""OPOR"" T0
                                INNER JOIN ""POR1"" T1 
                                    ON T0.""DocEntry"" = T1.""DocEntry""
                                WHERE T0.""CANCELED"" = 'N'
                                AND T0.""DocEntry"" IN ({0})
                                ORDER BY T0.""DocNum"", T1.""LineNum"";
                            ";

                oGrid.DataTable.Clear();
                qStr = string.Format(qStr, strDocEntry);
                oGrid.DataTable.ExecuteQuery(qStr);

                if (oGrid.DataTable.IsEmpty)
                {
                    oGrid.DataTable.Clear();
                    Global.GFunc.ShowError("No Item Available");
                    pForm.Freeze(false);
                    return;
                }

            int rowCount = oGrid.DataTable.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                oGrid.Rows.SelectedRows.Add(i);
            }
            oGrid.AutoResizeColumns();
            pForm.Freeze(false);

        }

        private void BTSELECT_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_NO_POLIST");
            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRID01").Specific;

            SAPbouiCOM.SelectedRows selRows = oGrid.Rows.SelectedRows;


            List<string> checkList = new List<string>();

            for (int i = 0; i < selRows.Count; i++)
            {
                int dtRow = selRows.Item(i, SAPbouiCOM.BoOrderType.ot_RowOrder);

                string docEntry = oGrid.DataTable.GetValue("POEntry", dtRow)?.ToString();
                string lineNum  = oGrid.DataTable.GetValue("BaseLine", dtRow)?.ToString();
                var docNum      = oGrid.DataTable.GetValue("PONumber", dtRow)?.ToString();
                var itemCode    = oGrid.DataTable.GetValue("ItemCode", dtRow)?.ToString();
                string key      = docEntry + "-" + lineNum;

                if (checkList.Contains(key))
                {
                    Global.GFunc.ShowError($"Duplicate Rows Found! DocNum: {docNum}, ItemCode: {itemCode}");
                    BubbleEvent = false;
                }

                checkList.Add(key);
            }
        }

        private void BTSELECT_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FIL_FRM_NO_POLIST");
            
            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRID01").Specific;

            SAPbouiCOM.SelectedRows selRows = oGrid.Rows.SelectedRows;

            if (selRows.Count == 0)
            {
                Application.SBO_Application.MessageBox("No rows selected!");
                return;
            }

            var Data = new List<(string DocEntry, string BaseType, int BaseLine, string PONumber,
                                      string ItemCode, string ItemDescription, double Quantity,
                                      double UnitPrice, string TaxCode, double TaxValue, double GTotal)>();

            for (int i = 0; i < selRows.Count; i++)
            {
                int dtRow = selRows.Item(i, SAPbouiCOM.BoOrderType.ot_RowOrder);

                var DocEntry = oGrid.DataTable.GetValue("POEntry", dtRow)?.ToString();
                var BaseType = oGrid.DataTable.GetValue("ObjType", dtRow)?.ToString();

                int.TryParse(oGrid.DataTable.GetValue("BaseLine", dtRow)?.ToString(), out int BaseLine);

                var PONumber = oGrid.DataTable.GetValue("PONumber", dtRow)?.ToString();
                var ItemCode = oGrid.DataTable.GetValue("ItemCode", dtRow)?.ToString();
                var ItemDescription = oGrid.DataTable.GetValue("ItemDescription", dtRow)?.ToString();

                double.TryParse(oGrid.DataTable.GetValue("Quantity", dtRow)?.ToString(), out double Quantity);
                double.TryParse(oGrid.DataTable.GetValue("UnitPrice", dtRow)?.ToString(), out double UnitPrice);

                var TaxCode = oGrid.DataTable.GetValue("TaxCode", dtRow)?.ToString();

                double.TryParse(oGrid.DataTable.GetValue("TaxValue", dtRow)?.ToString(), out double TaxValue);
                double.TryParse(oGrid.DataTable.GetValue("GTotal", dtRow)?.ToString(), out double GTotal);

                Data.Add((DocEntry, BaseType, BaseLine, PONumber, ItemCode, ItemDescription,
                          Quantity, UnitPrice, TaxCode, TaxValue, GTotal));
            }
            oForm.Close();
            DownPayment.ItemList(Data);

        }

    }
}

