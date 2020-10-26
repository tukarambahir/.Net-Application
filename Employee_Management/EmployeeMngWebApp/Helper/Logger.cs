using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeMngWebApp.Helper
{
    public class Logger
    {
        private static Logger logger = new Logger();
        private string FilePath = null;
        private FileStream fs = null;
        private StreamWriter writer = null;
        private Logger()
        {
            this.FilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        }

        public static Logger CurrentLogger { get { return logger; } }

        public void Log(string message)
        {
            try
            {
                if (File.Exists(this.FilePath))
                {
                    fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                }

                writer = new StreamWriter(fs);
                writer.WriteLine(string.Format("Log: at {0}: Details: {1}", DateTime.Now, message));
                writer.Flush();
            }
            catch (Exception ex)
            {
                //EMail
            }
            finally
            {
                writer.Close();
                fs.Close();

                writer = null;
                fs = null;
            }
        }
    }
}