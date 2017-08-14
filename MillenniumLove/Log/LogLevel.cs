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
    [DefaultValue(LogLevel.Info)]
    public enum LogLevel
    {
        [FinalValue("Debug")]
        All = 1,
        [FinalValue("Debug")]
        Debug = 2,
        [FinalValue("Info")]
        Info = 3,
        [FinalValue("Warn")]
        Warn = 4,
        [FinalValue("Error")]
        Error = 5,
        [FinalValue("Fatal")]
        Fatal = 6
    }
}
