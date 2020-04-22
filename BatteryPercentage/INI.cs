using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace BatteryPercentage
{
    class INI
    {
        string Path;
        string AppName = Assembly.GetExecutingAssembly().GetName().Name; // return the name of executable

       

        public INI(string IniPath = null)
        {
            Path = new FileInfo( (IniPath!=null) ? IniPath: AppName+".ini").FullName; // return the path of inifile

            bool fileExist = File.Exists(Path);   // check if Setting.ini is present and if not write it
            if (!fileExist)

            {
                Write("LowBatteryLevel", "25");  // write default values
                Write("LowBatteryAlert", "True");
            }
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString((Section != null) ?Section : AppName, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString((Section != null) ? Section : AppName, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, (Section != null) ? Section : AppName);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, (Section != null) ? Section : AppName);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
        
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    
    }
}
