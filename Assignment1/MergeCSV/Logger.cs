using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace MergeCsvFiles
{
    /// <summary>
    /// This is singleton class which gives the log4net logger instance to be used for logger
    /// </summary>
    public class Logger
    {

        private static Logger instance = null;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Logger()
        {

        }

        /// <summary>
        /// Returns logger Instance
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets IlogInstance
        /// </summary>
        /// <returns></returns>
        public ILog GetLogger()
        {
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            return log;
        }
    }
}
