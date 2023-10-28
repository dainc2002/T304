using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace tkBravoTool.DPL
{
    class GetXML
    {

        #region XML methods
        public static string DataTableToXML(DataTable dataTbl)
        {
            MemoryStream stream = new MemoryStream();
            dataTbl.WriteXml(stream, true);
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(stream);
            string xmlOut = sr.ReadToEnd();

            return xmlOut;
        }
        #endregion
    }
}
