using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public static class ModeloSerialization
    {
        public static void Serializar(string Ruta, ModeloContext modelo)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Ruta, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, modelo);
            stream.Close();
        }

        public static void Deserealizar(string Ruta, ref ModeloContext modelo)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            Stream streamReader = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.None);
            var proyectoDeserializado = (ModeloContext)formatter.Deserialize(streamReader);

            modelo = proyectoDeserializado;
            streamReader.Close();
        }
    }
}
