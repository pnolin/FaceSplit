using FaceSplit.Dtos;
using Newtonsoft.Json;
using System.IO;

namespace FaceSplit.services
{
    public class RunLoader
    {
        public RunLoader() { }

        public RunDto LoadRun(string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            RunDto runDto = new RunDto();

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    runDto = serializer.Deserialize<RunDto>(reader);
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (JsonReaderException)
            {
                throw;
            }

            return runDto;
        }
    }
}
