using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HQF.Tutorial.WCF.Serializer
{
    public  class WCFSerailizer
    {
        public static void ExportXsd<T>(string fileName="sample.xsd")
        {
            var xsdexp = new XsdDataContractExporter();
            xsdexp.Options = new ExportOptions();
            xsdexp.Export(typeof(T));

            //Write out exported schema to a file
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                foreach (XmlSchema sch in xsdexp.Schemas.Schemas())
                {
                    sch.Write(fs);
                }
            }

        }


        public static void ExportDataContract<T>(T t,string fileName= "sample.xml")
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(Employee));
                serializer.WriteObject(writer, t);
                writer.Close();
            }

        }


        public static void ExportNetDataContractSerializer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new NetDataContractSerializer();
                serializer.WriteObject(writer, t);
                writer.Close();
            }
        }







    }
}
