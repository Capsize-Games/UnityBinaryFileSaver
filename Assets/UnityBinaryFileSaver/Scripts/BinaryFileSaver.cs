using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace UnityBinaryFileSaver
{
    public class BinaryFileSaver
    {
        static BinaryFileSaver instance;
        BinaryFormatter bf;

        static BinaryFileSaver Instance
        {
            get {
                if (instance == null) instance = new BinaryFileSaver();
                return instance;
            }
            set { instance = value; }
        }

        static BinaryFormatter BF
        {
            get {
                if (Instance.bf == null) Instance.bf = new BinaryFormatter();
                return Instance.bf;
            }
        }

        public static void Save(ISaveFile f)
        {
            BF.Serialize(f.Writefile, f.Data);
            f.Close();
        }

        public static ISaveContainer Load(ISaveFile f)
        {
            ISaveContainer data = null;
            var file = f.Readfile;
            if (file != null) {
                try {
                    data = (ISaveContainer) BF.Deserialize(file);
                } catch {}
                file.Close();
            }
            return data;
        }
    }
}
