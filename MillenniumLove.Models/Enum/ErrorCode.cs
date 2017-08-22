
using System.ComponentModel;
using System.Xml.Serialization;

namespace MillenniumLove.Models
{
    public partial class Ref
    {
        /// <summary>
        ///
        /// </summary>
        [Description("錯誤代碼")]
        public enum ErrorCode
        {
            /// <summary>
            /// 執行成功
            /// </summary>
            [Description("執行成功")]
            [FinalValue("000")]
            _000,

            /// <summary>
            /// mask錯誤
            /// </summary>
            [Description("mask錯誤")]
            [FinalValue("001")]
            _001,

            /// <summary>
            /// 必要參數不足
            /// </summary>
            [Description("必要參數不足")]
            [FinalValue("002")]
            _002,

            /// <summary>
            /// 參數格式錯誤
            /// </summary>
            [Description("參數格式錯誤")]
            [FinalValue("003")]
            _003,


            /// <summary>
            /// 其它錯誤
            /// </summary>
            [Description("其它錯誤")]
            [FinalValue("999")]
            _999,
        }


    }
}
