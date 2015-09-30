using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HQF.Tutorial.WCF.Serializer
{
    public class WCFSerailizer
    {
        public static void ExportXsd<T>(string fileName = "sample.xsd")
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

        public static void ExportXmlSerializer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, t);
                writer.Close();
            }
        }

        #region DataContract

        public static void ExportDataContract<T>(T t, string fileName = "sample.xml")
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(T));
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

        public static void ExportDataContractJsonSerilizer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                //https://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer(v=vs.105).aspx
                var ser = new DataContractJsonSerializer(typeof(T));

                ser.WriteObject(writer, t);
                writer.Close();
            }
        }

        #endregion DataContract




    }
}