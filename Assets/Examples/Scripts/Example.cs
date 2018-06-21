using UnityEngine;
using UnityEngine.UI;

class Example : MonoBehaviour
{
    public Text input;
    public Text info;
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
