using System.IO;

namespace UnityBinaryFileSaver
{
    public interface ISaveFile
    {
        FileStream Readfile { get; }
        FileStream Writefile { get; }
        ISaveContainer Data { get; set; }
        void Close();
    }
}
