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
    
    public partial class BE_User
    {
        public int User_ID { get; set; }
        public string User_Account { get; set; }
        public string User_Password { get; set; }
        public Nullable<bool> User_Disabled { get; set; }
        public byte User_Group { get; set; }
        public System.DateTime User_Create_Date { get; set; }
        public string User_Create_User { get; set; }
        public System.DateTime User_Update_Date { get; set; }
        public string User_Update_User { get; set; }
        public short User_Update_Cnt { get; set; }
    }
}
