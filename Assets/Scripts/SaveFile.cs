using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class SaveFile : ISaveFile
{
    string filename;
    Action<string> callback;
    ISaveContainer data;
    [System.NonSerialized]
    FileStream filestream;

    public SaveFile(string filename)
    {
        this.filename = Application.persistentDataPath + "/" + filename;
    }

    public SaveFile(string filename, ISaveContainer data)
    {
        this.filename = Application.persistentDataPath + "/" + filename;
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
            filestream = File.Create(filename);
            return filestream;
        }
    }

    public FileStream Readfile
    {
        get
        {
            if (!File.Exists(filename)) return null;
            filestream = File.Open(filename, FileMode.Open);
            return filestream;
        }
    }

    public void Close()
    {
        filestream.Close();
    }
}
