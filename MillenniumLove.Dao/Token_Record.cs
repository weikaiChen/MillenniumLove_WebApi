//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MillenniumLove.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class Token_Record
    {
        public string Token { get; set; }
        public string Token_Machine_ID { get; set; }
        public string Token_Function_ID { get; set; }
        public System.DateTime Token_StartDate { get; set; }
        public System.DateTime Token_ExpireDate { get; set; }
        public bool Token_IsUsed { get; set; }
        public System.DateTime Token_Create_Date { get; set; }
        public string Token_Create_User { get; set; }
        public System.DateTime Token_Update_Date { get; set; }
        public string Token_Update_User { get; set; }
    }
}
