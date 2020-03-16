using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace ExampleIXFE_v_3_1
{
    [DataContract]
    public class StreamInfo : IDisposable
    {
        [DataMember]
        public Stream Stream { get; set; }

        [DataMember]
        public string Filename { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamInfo {\n");
            sb.Append("  Filename: ").Append(Filename).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void Dispose()
        {
            if (Stream != null)
            {
                string fileToDelete = null;

                var fileStream = (Stream as System.IO.FileStream);
                if (fileStream != null)
                {
                    fileToDelete = fileStream.Name;
                }

                Stream.Dispose();

                if (!string.IsNullOrEmpty(fileToDelete))
                {
                    try
                    {
                        File.Delete(fileToDelete);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
