using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseWindow;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void OpenPauseWindow()
    {
        pauseWindow.SetActive(true);
    }

    public void ClosePauseWindow()
    {
        pauseWindow.SetActive(false);
    }
}
