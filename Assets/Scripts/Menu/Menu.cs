using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject continueBtn;

    private Button btnContinue;
    [SerializeField]
    private Button btnStages;

    private int completeLevels;
    private void Start()
    {
        btnContinue = continueBtn.GetComponent<Button>();
        completeLevels = PlayerPrefs.GetInt("CompleteLevels");
        if(completeLevels > 1)
        {
            btnContinue.interactable = true;
            btnStages.interactable = true;
        }
    }

    private void Update()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels");
    }

    public void CreateNewGame()
    {
        btnContinue.interactable = false;
        btnStages.interactable = false;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Prolog");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels", 1);
        SceneManager.LoadScene(completeLevels + 1);
    }

    public void OpenStages()
    {
        SceneManager.LoadScene(1);
    }

    public void StartProlog()
    {
        SceneManager.LoadScene("Prolog");
    }

    public void StartNightDay()
    {
        SceneManager.LoadScene("NightDay");
    }
}
