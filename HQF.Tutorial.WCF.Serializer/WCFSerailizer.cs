using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HQF.Tutorial.WCF.Serializer
{
    public class WCFSerailizer
    {
        /// <summary>
        /// Export XSD File.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
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

        #region Serializer

        /// <summary>
        /// The constructors have a no parameters etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
        public static void ExportXmlSerializer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, t);
                writer.Close();
            }
        }

        /// <summary>
        /// The Type T must be marked as [Serializable]
        /// The constructor is no parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
        public static void ExportBinarySerializer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var binarySerializer = new BinaryFormatter();
                binarySerializer.Serialize(writer, t);
                writer.Close();
            }
        }

        #endregion Serializer

        #region DataContract

        /// <summary>
        /// The Entity Export DataContract
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
        public static void ExportDataContract<T>(T t, string fileName = "sample.xml")
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(writer, t);
                writer.Close();
            }
        }

        /// <summary>
        /// Export NetDataContract Serializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
        public static void ExportNetDataContractSerializer<T>(T t, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new NetDataContractSerializer();
                serializer.WriteObject(writer, t);
                writer.Close();
            }
        }

        /// <summary>
        /// Export Json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="fileName"></param>
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