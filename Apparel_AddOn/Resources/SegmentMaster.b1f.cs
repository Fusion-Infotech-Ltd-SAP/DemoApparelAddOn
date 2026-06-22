using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_AddOn.Helper;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.SegmentMaster", "Resources/SegmentMaster.b1f")]
    class SegmentMaster : UserFormBase
    {
        public SegmentMaster()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STDESC, STSLCODE, STSIZE, STCOLR, STSEPATR, STMXLEN;
        private SAPbouiCOM.EditText ETCODE, ETDESC, ETSEPATR, ETMXLEN, ETSLCODE, ETSIZE, ETCOLR, ETDCNTRY;



        private SAPbouiCOM.CheckBox CHKSCODE, CHKSIZE, CHKCLR;
        private SAPbouiCOM.Button ADDButton, CancelButton;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.STSLCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STSLCODE").Specific));
            this.STSIZE = ((SAPbouiCOM.StaticText)(this.GetItem("STSIZE").Specific));
            this.STCOLR = ((SAPbouiCOM.StaticText)(this.GetItem("STCOLR").Specific));
            this.STSEPATR = ((SAPbouiCOM.StaticText)(this.GetItem("STSEPATR").Specific));
            this.STMXLEN = ((SAPbouiCOM.StaticText)(this.GetItem("STMXLEN").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETCODE.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETCODE_LostFocusAfter);
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.ETSEPATR = ((SAPbouiCOM.EditText)(this.GetItem("ETSEPATR").Specific));
            this.ETMXLEN = ((SAPbouiCOM.EditText)(this.GetItem("ETMXLEN").Specific));
            this.ETSLCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETSLCODE").Specific));
            this.ETSIZE = ((SAPbouiCOM.EditText)(this.GetItem("ETSIZE").Specific));
            this.ETCOLR = ((SAPbouiCOM.EditText)(this.GetItem("ETCOLR").Specific));
            this.CHKSCODE = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKSCODE").Specific));
            this.CHKSIZE = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKSIZE").Specific));
            this.CHKCLR = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKCLR").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDCNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDCNTRY").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
           
           
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

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
                        string query = $@"SELECT 1 FROM ""@FIL_MH_OSGM"" WHERE ""Code"" = '{code.Replace("'", "''")}'";
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
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("Code", 0);
            string desc = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("Name", 0);
            string pcode = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("U_PRODUCT", 0);
            string size = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("U_SIZE", 0);
            string colour = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("U_COLOUR", 0);
            string separator = oForm.DataSources.DBDataSources.Item("@FIL_MH_OSGM").GetValue("U_SEPARATOR", 0);
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Segment Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (desc == "")
            {
                Global.GFunc.ShowError("Enter Segment Description");
                oForm.ActiveItem = "ETDESC";
                return BubbleEvent = false;
            }
            else if (pcode == "")
            {
                Global.GFunc.ShowError("Enter Product Style Code Address");
                oForm.ActiveItem = "ETSLCODE";
                return BubbleEvent = false;
            }
            else if (size == "")
            {
                Global.GFunc.ShowError("Enter Size");
                oForm.ActiveItem = "ETSIZE";
                return BubbleEvent = false;
            }
            else if (colour == "")
            {
                Global.GFunc.ShowError("Enter Colour");
                oForm.ActiveItem = "ETCOLR";
                return BubbleEvent = false;
            }
            else if (separator == "")
            {
                Global.GFunc.ShowError("Enter Separator");
                oForm.ActiveItem = "ETSEPATR";
                return BubbleEvent = false;
            }
            return BubbleEvent;
        }


}
}
