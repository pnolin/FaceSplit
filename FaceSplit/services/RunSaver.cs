using FaceSplit.Dtos;
using Newtonsoft.Json;
using System.IO;

namespace FaceSplit.services
{
    public class RunSaver
    {
        public RunSaver() { }

        public void SaveRun(RunDto dto, string fileName)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                jsonSerializer.Serialize(writer, dto);
            }
        }
    }
}
