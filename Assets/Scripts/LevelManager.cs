using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int completeLevels;
    public int CompleteLevels
    {
        get
        {
            return completeLevels;
        }
        set
        {
            if (value != 0)
                completeLevels = value;
        }
    }
    private void Start()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
