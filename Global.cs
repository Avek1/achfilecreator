using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
    class Global
    {

        private string theString;
        public string TheString
        {
            get
            {
                return theString;
            }
            set
            {
                theString = value;
            }
        }
    }
}
