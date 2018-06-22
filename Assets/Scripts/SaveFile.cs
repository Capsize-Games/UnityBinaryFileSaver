using UnityEngine;
using System;
using System.IO;

namespace UnityBinaryFileSaver
{
    [System.Serializable]
    public class SaveFile : ISaveFile
    {
        string filename;
        Action<string> callback;
        ISaveContainer data;
        [System.NonSerialized]
        FileStream filestream;

        string Path
        {
            get {
                return Application.persistentDataPath + "/";
            }
        }

        string Filename
        {
            get {
                return Path + filename;
            }
        }

        public SaveFile(string filename)
        {
            this.filename = filename;
        }

        public SaveFile(string filename, ISaveContainer data)
        {
            this.filename = filename;
            this.data = data;
        }

        public ISaveContainer Data
        {
            get { return data; }
            set { data = value; }
        }

        public FileStream Writefile
        {
            get
            {
                filestream = File.Create(Filename);
                return filestream;
            }
        }

        public FileStream Readfile
        {
            get
            {
                if (!File.Exists(Filename)) return null;
                filestream = File.Open(Filename, FileMode.Open);
                return filestream;
            }
        }

        public void Close()
        {
            filestream.Close();
        }
    }
}
