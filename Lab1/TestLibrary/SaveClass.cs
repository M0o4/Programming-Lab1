using System.IO;
using System.Xml.Serialization;

namespace TestLibrary
{
    public class SaveClass
    {
        public void Save(Test test, string fileName)
        {
            string path = $@".\Tests\{fileName}.txt";
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(test.GetType());
            formatter.Serialize(outFile, test);
        }
        
        // public void Load(Test test, string fileName)
        // {
        //     string file = $@".\Tests\{fileName}.txt";
        //     XmlSerializer formatter = new XmlSerializer(test.GetType());
        //     FileStream aFile = new FileStream(file, FileMode.Open);
        //     byte[] buffer = new byte[aFile.Length];
        //     aFile.Read(buffer, 0, (int) aFile.Length);
        //     MemoryStream stream = new MemoryStream(buffer);
        //     test = formatter.Deserialize(stream);
        // }
    }
    
}