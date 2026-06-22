using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_AddOn.Resources
{
    [FormAttribute("Apparel_AddOn.Resources.ORDRQUANSEG", "Resources/ORDRQUANSEG.b1f")]
    class ORDRQUANSEG : UserFormBase
    {
        public ORDRQUANSEG()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STNAME, STQUNFRM, STQUNTO, STACTIVE;
        private SAPbouiCOM.EditText ETCODE, ETNAME, ETQUNFRM, ETQUNTO, ETDOCTRY;
        private SAPbouiCOM.CheckBox CKACTIVE;
        private SAPbouiCOM.Button ADDButton, CancelButton;

        public override void OnInitializeComponent()
        {

            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STQUNFRM = ((SAPbouiCOM.StaticText)(this.GetItem("STQUNFRM").Specific));
            this.STACTIVE = ((SAPbouiCOM.StaticText)(this.GetItem("STACTIVE").Specific));
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.STQUNTO = ((SAPbouiCOM.StaticText)(this.GetItem("STQUNTO").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETQUNFRM = ((SAPbouiCOM.EditText)(this.GetItem("ETQUNFRM").Specific));
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.ETQUNTO = ((SAPbouiCOM.EditText)(this.GetItem("ETQUNTO").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }


        public override void OnInitializeFormEvents()
        {
        }
        private void OnCustomInitialize()
        {

        }

        
    }
}
