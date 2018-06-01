using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tiorem.agentMongoDB
{
  
    public class AYMKLogger
    {
        string logPath, logfilePattern, logAppfile, logFileName;
        public readonly string s = "\t\t";
        ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        public AYMKLogger(string rootFolder)
        {
            logPath = rootFolder + "\\log";
            logfilePattern = logPath + "\\log_{0:yyyyMMddHHmm}.txt";
            logAppfile = logPath + "\\logApp.txt";
            logFileName = string.Empty;
            

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            if (!File.Exists(logAppfile))
                File.Create(logAppfile).Close();

        }

        public void addLog(string msg, bool isError = true)
        {
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                string preTag = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + s + (isError ? "INFO" : "ERROR") + s;
                using (StreamWriter sw = File.AppendText(logFileName))
                {
                    sw.WriteLine(preTag + msg);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public void addAppLog(string msg, bool isError = true)
        {

            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                string preTag = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + s + (isError ? "INFO" : "ERROR") + s;
                using (StreamWriter sw = File.AppendText(logAppfile))
                {
                    sw.WriteLine(preTag + msg);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public void logFileCreate(DateTime date)
        {
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            logFileName = string.Format(logfilePattern, date);
            if (!File.Exists(logFileName))
                File.Create(logFileName).Close();
        }
    }
}
