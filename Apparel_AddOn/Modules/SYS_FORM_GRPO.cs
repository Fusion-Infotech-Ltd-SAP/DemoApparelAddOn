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
    class SYS_FORM_GRPO
    {
        public SYS_FORM_GRPO()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
        }

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {

            BubbleEvent = true;
            try
            {

                if (pVal.FormTypeEx == "143" && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)
                {

                    Global.G_Form = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);


                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)
                    {
                        switch (pVal.ItemUID)
                        {
                            case "1":   
                                if (pVal.BeforeAction)
                                {
                                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        try
                                        {
                                          AddBatchDetials(ref oForm);
                                        }
                                        catch (Exception ex)
                                        {
                                           
                                        }
                                    }
                                }
                                break;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in Good Receipt PO for SAP Screen - " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }

        }

        private static void AddBatchDetials(ref SAPbouiCOM.Form pForm)
        {
            if (pForm.DataSources.DBDataSources.Item("OPDN").GetValue("CANCELED", 0) != "N")
                return;

            //SAPbobsCOM.Recordset rSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            //rSet.DoQuery("SELECT TOP 1 \"DistNumber\" FROM \"OBTN\" WHERE \"DistNumber\" LIKE 'G/%' ORDER BY \"DistNumber\" DESC");

            //int counter = 0;

            //if (!rSet.EoF)
            //{
            //    string lastDist = rSet.Fields.Item("DistNumber").Value.ToString();

            //    if (string.IsNullOrEmpty(lastDist))
            //    {
            //        counter = 0;
            //    }
            //    else if (lastDist.Contains("@"))
            //    {
            //        counter = Convert.ToInt32(lastDist.Split('@')[1]);
            //    }
            //}

            string docNum = pForm.DataSources.DBDataSources.Item("OPDN").GetValue("DocNum", 0).Trim();
            string currentDate = DateTime.Now.ToString("yyyyMMdd");


            SAPbouiCOM.Matrix ItemMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;
            try
            {
                for (int i = 1; i <= ItemMatrix.RowCount - 1; i++)
                {
                    SAPbobsCOM.Items oItemMaster = (SAPbobsCOM.Items)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
                  
                    if (oItemMaster.GetByKey(((SAPbouiCOM.EditText)ItemMatrix.Columns.Item("1").Cells.Item(i).Specific).Value))
                    {
                        if (oItemMaster.ManageBatchNumbers == SAPbobsCOM.BoYesNoEnum.tYES)
                        {
                            //++counter;
                            string BatchNo = $"G/{docNum}/{currentDate}@{i}";
                            pForm.Items.Item("112").Click();
                            double Quantity = double.Parse(((SAPbouiCOM.EditText)ItemMatrix.Columns.Item("11").Cells.Item(i).Specific).Value);

                            if (Global.G_UI_Application.ClientType == SAPbouiCOM.BoClientType.ct_Browser)
                            {
                                ItemMatrix.Columns.Item("11").Cells.Item(i).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                                pForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
                                pForm.Menu.Item("5896").Activate();
                            }
                            else if (Global.G_UI_Application.ClientType == SAPbouiCOM.BoClientType.ct_Desktop)
                            {
                                ItemMatrix.Columns.Item("11").Cells.Item(i).Click(SAPbouiCOM.BoCellClickType.ct_Regular, (int)SAPbouiCOM.BoModifiersEnum.mt_CTRL);
                                Global.G_UI_Application.SendKeys("^{TAB}");
                            }

                            SAPbouiCOM.Form BatchForm = Global.G_UI_Application.Forms.ActiveForm;
                            if (Global.G_UI_Application.ClientType == SAPbouiCOM.BoClientType.ct_Desktop)
                                BatchForm.State = SAPbouiCOM.BoFormStateEnum.fs_Minimized;
                            BatchForm.Freeze(true);

                            try
                            {
                                SAPbouiCOM.Matrix BatchMatrix = (SAPbouiCOM.Matrix)BatchForm.Items.Item("3").Specific;
                                for (int k = BatchMatrix.VisualRowCount; k >= 1; k--)
                                {
                                    try
                                    {
                                        if (k == 1)
                                        {
                                            ((SAPbouiCOM.EditText)BatchMatrix.Columns.Item("2").Cells.Item(k).Specific).Value = BatchNo;
                                            ((SAPbouiCOM.EditText)BatchMatrix.Columns.Item("234000024").Cells.Item(k).Specific).Value = Quantity.ToString();
                                        }
                                        else
                                        {
                                            if (((SAPbouiCOM.EditText)BatchMatrix.Columns.Item("2").Cells.Item(k).Specific).Value.ToString().TrimEnd() != "")
                                            {
                                                BatchMatrix.Columns.Item("0").Cells.Item(k).Click(SAPbouiCOM.BoCellClickType.ct_RightNoBlocking);
                                                Global.G_UI_Application.ActivateMenuItem("1293");    // Delete Row                                          
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                                BatchForm.Freeze(false);
                            }
                            catch (Exception)
                            {
                                BatchForm.Freeze(false);
                            }
                            BatchForm.Items.Item("1").Click();
                            BatchForm.Items.Item("1").Click();
                        }
                    }
                    pForm.Freeze(false);
                }
            }
            catch (Exception)
            {
                pForm.Freeze(false);
            }
        }


    }
}
