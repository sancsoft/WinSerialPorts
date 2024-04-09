using System.IO.Ports;

namespace WinSerialPorts
{
    internal class SerialPortInfo
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SerialPortInfo() { Number = 0; Name = ""; Status = "Undefined"; }

        /// <summary>
        /// Create a serial port from a dirty name
        /// </summary>
        /// <param name="name">dirty name of port</param>
        public SerialPortInfo(string name)
        {
            Name = CleanPortName(name);
            Number = PortNumberFromName(Name);
            Status = PortStatusFromName(Name);
        }
        
        /// <summary>
        /// Determines the COM port number from the name string
        /// </summary>
        /// <param name="name">clean name</param>
        /// <returns>port number or 0 on failure</returns>
        public static int PortNumberFromName(string name)
        {
            int number = 0;
            if (name.Length > 3)
            {
                name = name.Substring(3);
                if (Int32.TryParse(name, out number))
                { 
                    if (number > 99)
                    {
                        number = 0;
                    }
                }
            }
            
            return number;
        }

        /// <summary>
        /// Gets the status of a serial port (available, in use, error)
        /// </summary>
        /// <param name="name">clean port name</param>
        /// <returns>status string</returns>
        public static string PortStatusFromName(string name)
        {
            string status = "Unknown";

            try
            {
                SerialPort sp = new SerialPort(name, 9600);
                sp.Open();
                sp.Close();
                status = "Available";
            }
            catch (UnauthorizedAccessException)
            {
                status = "In Use";
            }
            catch
            {
                status = "Error";
            }

            return status;
        }

        /// <summary>
        /// Does its best to clean up a port name; a clean name is a 4 or 5 
        /// character string in the form "COM1" to "COM99"
        /// </summary>
        /// <param name="name">dirty name</param>
        /// <returns>clean name</returns>
        public static string CleanPortName(string name)
        {
            name = name.Substring(0, (name.Length > 4) ? 5 : 4);
            if (name.Length == 5)
            {
                if ((name[4] < '0') || (name[4] > '9'))
                {
                    name = name.Substring(0, 4);
                }
            }
            return name;
        }

        public int Number { get; set; }
        public string Name { get; set; }   
        public string Status {  get; set; }
    }
}
