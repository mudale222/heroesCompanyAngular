using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Log4net {
    public static class Logger {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void StartLogging() {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            AppDomain.CurrentDomain.FirstChanceException += (sender, e) => {
                if (e.Exception.TargetSite.DeclaringType.Assembly == Assembly.GetExecutingAssembly()) {
                    log.ErrorFormat("Exception Thrown: {0}\n{1}", e.Exception.Message, e.Exception.StackTrace);
                }
            };
        }
    }
}
