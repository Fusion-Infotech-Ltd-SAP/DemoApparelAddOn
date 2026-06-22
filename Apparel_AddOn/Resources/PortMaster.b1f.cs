using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.PortMaster", "Resources/PortMaster.b1f")]
    class PortMaster : UserFormBase
    {
        public PortMaster()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STNAME, STTYPE, STCNTRY, STCITY, STLOCCOD, STACTIVE;
        private SAPbouiCOM.EditText ETCODE, ETNAME, ETDOCTRY, ETCITY, ETLOCCOD;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.CheckBox CKACTIVE;
        private SAPbouiCOM.ComboBox CBTYPE, CBCNTRY;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETCODE.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETCODE_LostFocusAfter);
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STTYPE = ((SAPbouiCOM.StaticText)(this.GetItem("STTYPE").Specific));
            this.CBTYPE = ((SAPbouiCOM.ComboBox)(this.GetItem("CBTYPE").Specific));
            this.STCNTRY = ((SAPbouiCOM.StaticText)(this.GetItem("STCNTRY").Specific));
            this.STCITY = ((SAPbouiCOM.StaticText)(this.GetItem("STCITY").Specific));
            this.CBCNTRY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCNTRY").Specific));
            this.STLOCCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STLOCCOD").Specific));
            this.ETCITY = ((SAPbouiCOM.EditText)(this.GetItem("ETCITY").Specific));
            this.ETLOCCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETLOCCOD").Specific));
            this.STACTIVE = ((SAPbouiCOM.StaticText)(this.GetItem("STACTIVE").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
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
                        string query = $@"SELECT 1 FROM ""@FIL_MH_PORTMSTR"" WHERE ""Code"" = '{code.Replace("'", "''")}'";
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
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("Code", 0);
            string name = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("Name", 0);
            string type = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("U_TYPE", 0);
            string country = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("U_COUNTRY", 0);
            string city = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("U_CITY", 0);
            string location = oForm.DataSources.DBDataSources.Item("@FIL_MH_PORTMSTR").GetValue("U_LocalCode", 0);
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Port Master Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (name == "")
            {
                Global.GFunc.ShowError("Enter Port Master Name");
                oForm.ActiveItem = "ETNAME";
                return BubbleEvent = false;
            }
            else if (type == "")
            {
                Global.GFunc.ShowError("Select Port Master Type");
                oForm.ActiveItem = "CBTYPE";
                return BubbleEvent = false;
            }
            else if (country == "")
            {
                Global.GFunc.ShowError("Select Port Master Country");
                oForm.ActiveItem = "CBCNTRY";
                return BubbleEvent = false;
            }
            else if (city == "")
            {
                Global.GFunc.ShowError("Enter Port Master City");
                oForm.ActiveItem = "ETCITY";
                return BubbleEvent = false;
            }
            else if (location == "")
            {
                Global.GFunc.ShowError("Enter Port Master Local Code");
                oForm.ActiveItem = "ETLOCCOD";
                return BubbleEvent = false;
            }
            return BubbleEvent;
        }

    }
}
