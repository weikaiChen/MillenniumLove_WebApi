
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace MillenniumLove
{

    public class LogRecord
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger
  (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region const
        public const string ID = "ID";
        public const string TIME = "TIME";
        public const string AREA = "AREA";
        public const string LOG = "LOG";
        public const string EQUITY = "EQUITY";
        public const string DATAS = "DATAS";
        #endregion

        #region property
        [Category(ID)]
        [DataMember]
        [Description("記錄代碼")]
        public string LogID { get; set; }

        [Category(ID)]
        [DataMember]
        [Description("交易代碼")]
        public string Tid { get; set; }

        [Category(ID)]
        [DataMember]
        [Description("上層交易代碼")]
        public string ParentTid { get; set; }

        [Category(TIME)]
        [DataMember]
        [Description("發生時間")]
        public DateTime Timestamp { get; set; }

        [Category(TIME)]
        [DataMember]
        [Description("執行時間長度")]
        public double ExecutionTime { get; set; }

        [Category(LOG)]
        [DataMember]
        [Description("等級")]
        public LogLevel Level { get; set; }

        [Category(ID)]
        [DataMember]
        [Description("系統代碼")]
        public string AppID { get; set; }

        [Category(ID)]
        [DataMember]
        [Description("程式代碼")]
        public string FunctionID { get; set; }

        [Category(AREA)]
        [DataMember]
        [Description("網址")]
        public string Url { get; set; }

        [Category(AREA)]
        [DataMember]
        [Description("程式碼路徑")]
        public string Path { get; set; }

        [Category(AREA)]
        [DataMember]
        [Description("伺服器 IP")]
        public string HostIP { get; set; }

        [Category(AREA)]
        [DataMember]
        [Description("伺服器名稱")]
        public string HostName { get; set; }

        [Category(AREA)]
        [DataMember]
        [Description("使用端IP")]
        public string ClientIP { get; set; }

        [Category(ID)]
        [DataMember]
        [Description("使用者ID")]
        public string UserID { get; set; }

        [Category(LOG)]
        [DataMember]
        [Description("標題")]
        public string Title { get; set; }

        [Category(LOG)]
        [DataMember]
        [Description("訊息")]
        public string Message { get; set; }



        [Category(DATAS)]
        [DataMember]
        [Description("額外資訊")]
        public object Datas { get; set; }

        [Category(TIME)]
        [DataMember]
        [Description("存入時間")]
        public DateTime PutDate { get; set; }

        [Category(TIME)]
        [DataMember]
        [Description("執行時間")]
        public decimal Scn { get; set; }
        #endregion

        #region function


        public LogRecord Error()
        {
            Level = LogLevel.Error;
            return Write();
        }

        public LogRecord Warn()
        {
            Level = LogLevel.Warn;
            return Write();
        }

        public LogRecord Info()
        {
            Level = LogLevel.Info;
            return Write();
        }

        public LogRecord Debug()
        {
            Level = LogLevel.Debug;
            return Write();
        }

        public LogRecord Write()
        {
            return Write(Level);
        }


        public LogRecord SetMessage(string message)
        {
            if (message.NullOrEmpty()) { return this; }
            Message = message;
            return this;
        }
        #endregion

        #region 主要function
        public LogRecord Write(LogLevel level)
        {
            StringBuilder logCompose = new StringBuilder();//組成log的資訊
            logCompose.AppendLine(this.Message);
            switch (level)
            {
                case LogLevel.Debug:
                    logCompose.AppendLine("Debug");
                    logger.Debug(logCompose.ToString());
                    break;
                case LogLevel.Info:
                    logCompose.AppendLine("Info");
                    logger.Info(logCompose.ToString());
                    break;
                case LogLevel.Warn:
                    logCompose.AppendLine("Warn");
                    logger.Warn(logCompose.ToString());
                    break;
                case LogLevel.Error:
                    logCompose.AppendLine("Error");
                    logger.Error(logCompose.ToString());
                    break;
                case LogLevel.Fatal:
                    logCompose.AppendLine("Fatal");
                    logger.Fatal(logCompose.ToString());
                    break;
                default:
                    break;
            }

           

            return this;
        }
        #endregion


        #region static
        public static LogRecord Create()
        {
            return new LogRecord();
        }

        public static LogRecord Create(string title)
        {
            var record = new LogRecord();
            if (!title.NullOrEmpty())
            {
                record.Title = title;
            }
            return record;
        }
        #endregion
    }
}
