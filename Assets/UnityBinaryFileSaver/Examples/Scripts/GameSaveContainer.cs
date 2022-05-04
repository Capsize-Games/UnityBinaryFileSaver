using UnityEngine;
using System;
using UnityBinaryFileSaver;

[Serializable]
class GameSaveContainer : ISaveContainer
{
    public string name;
    [NonSerialized]
    public GameObject foobar;

    public GameSaveContainer(string name)
    {
        this.name = name;
    }
}
