using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleVLF
{
    public static class VlfProjectHandler
    {
        private const int Version = 100;

        public static void Save(VlfProject project, string filename)
        {
            if (File.Exists(filename)) File.Delete(filename);
            
            Stream fs = new FileStream(filename,FileMode.Create);
            IFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(fs,Version);
            if (project.FraserDatas.Count == 0 && project.TiltDatas.Count == 0 && project.KarousHjeltDatas.Count == 0)
            {
                fs.Close();
                return;
            }
            binFormatter.Serialize(fs,project);
            fs.Close();
        }

        public static VlfProject Read(string filename)
        {
            Stream fs = new FileStream(filename,FileMode.Open,FileAccess.Read);
            IFormatter binFormatter = new BinaryFormatter();
            var version = (int) binFormatter.Deserialize(fs);
            if (!version.Equals(Version)) return null;
            if (fs.Position == fs.Length)
            {
                fs.Close();
                return new VlfProject();
            }
            var result = (VlfProject) binFormatter.Deserialize(fs);
            fs.Close();
            return result;
        }
    }
}
