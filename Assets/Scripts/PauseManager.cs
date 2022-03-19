using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private AudioSource sirenSound;
    [SerializeField] private AudioSource mainSoundTheme;

    private bool isMusic;
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
        if (sirenSound.isPlaying && mainSoundTheme.isPlaying)
        {
            sirenSound.Pause();
            mainSoundTheme.Pause();
            isMusic = true;
        }
        pauseWindow.SetActive(true);
    }

    public void ClosePauseWindow()
    {
        if (isMusic)
        {
            sirenSound.Play();
            mainSoundTheme.Play();
        }

        pauseWindow.SetActive(false);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
