using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CreateNewGame()
    {
        SceneManager.LoadScene("FlatScene");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLastStage() { }

}
