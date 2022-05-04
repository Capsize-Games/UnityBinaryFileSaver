using UnityEngine;
using UnityEngine.UI;
using UnityBinaryFileSaver;

class Example : MonoBehaviour
{
    public Text input = null;
    public Text info = null;
    public GameObject infoContainer;
    public string saveFileName = "example.savefile";

    void Start()
    {
        var savefile = new SaveFile(saveFileName);
        GameSaveContainer gsc = (GameSaveContainer) BinaryFileSaver.Load(savefile);
        if (gsc != null) {
            infoContainer.SetActive(true);
            info.text = "Hello, " + gsc.name;
        }
    }

    public void Save()
    {
        var savefile = new SaveFile(
            saveFileName,
            new GameSaveContainer(input.text)
        );
        BinaryFileSaver.Save(savefile);
        infoContainer.SetActive(true);
        info.text = "Reload the game and your name will appear here.";
    }
}
