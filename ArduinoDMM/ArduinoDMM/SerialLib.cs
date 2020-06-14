using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoDMM
{
    class SerialLib
    {
        private string _inData;
        private string _command;
        private int _number;
        public SerialLib(string inData) 
        { 
            this._inData = inData;
            StringSplitter();
        }
        private void StringSplitter()
        {
            string[] words = this._inData.Split('/');
            this._command = words[0];
            try { this._number = Convert.ToInt32(words[1]); }
            catch { }
        }
        public string getCommand { get { return this._command; } }
        public int getNumber { get { return this._number; } }
    }
}
