using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.GarmentsTypeMaster", "Resources/GarmentsTypeMaster.b1f")]
    class GarmentsTypeMaster : UserFormBase
    {
        public GarmentsTypeMaster()
        {
        }
        private SAPbouiCOM.StaticText STCODE, STNAME, STCATGRY, STMALE, STFEMALE, STKIDS;
        private SAPbouiCOM.EditText ETCODE, ETNAME, ETDOCTRY;
        private SAPbouiCOM.CheckBox CHKMALE, CHKFEMLE, CHKKIDS;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.ComboBox CBCATGRY;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.STCATGRY = ((SAPbouiCOM.StaticText)(this.GetItem("STCATGRY").Specific));
            this.STMALE = ((SAPbouiCOM.StaticText)(this.GetItem("STMALE").Specific));
            this.STFEMALE = ((SAPbouiCOM.StaticText)(this.GetItem("STFEMALE").Specific));
            this.STKIDS = ((SAPbouiCOM.StaticText)(this.GetItem("STKIDS").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.CHKMALE = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKMALE").Specific));
            this.CHKFEMLE = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKFEMLE").Specific));
            this.CHKKIDS = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKKIDS").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.CBCATGRY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCATGRY").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
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

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

        }

        private void ETCODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                {
                    string code = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value.Trim();
                    if (!string.IsNullOrEmpty(code))
                    {
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string query = $@"SELECT 1 FROM ""@FIL_MH_OGTM"" WHERE ""Code"" = '{code.Replace("'", "''")}'";
                        oRS.DoQuery(query);
                        if (!oRS.EoF)
                        {
                            Application.SBO_Application.StatusBar.SetText("Code already exists!", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_OGTM").GetValue("Code", 0);
            string name = oForm.DataSources.DBDataSources.Item("@FIL_MH_OGTM").GetValue("Name", 0);
            string active = oForm.DataSources.DBDataSources.Item("@FIL_MH_OGTM").GetValue("U_CATEGORY", 0);
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Garments Type Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (name == "")
            {
                Global.GFunc.ShowError("Enter Garments Type Name");
                oForm.ActiveItem = "ETNAME";
                return BubbleEvent = false;
            }
            else if (active == "")
            {
                Global.GFunc.ShowError("Select Category");
                oForm.ActiveItem = "CBCATGRY";
                return BubbleEvent = false;
            }
            return BubbleEvent;
        }

    }
}
