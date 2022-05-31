using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject continueBtn;
    [SerializeField] private GameObject closeImage;
    [SerializeField] private GameObject stages;
    [SerializeField] private GameObject settings;

    private Button btnContinue;
    [SerializeField]
    private Button btnStages;

    private int completeLevels;
    private void Start()
    {
        //btnContinue = continueBtn.GetComponent<Button>();
        //closeImage.SetActive(true);
        //completeLevels = PlayerPrefs.GetInt("CompleteLevels");
        //if(btnContinue != null)
        //    btnContinue.interactable = true;
        //btnStages.interactable = true;
        //closeImage.SetActive(false);
        //if (completeLevels > 1)
        //{
        //    btnContinue.interactable = true;
        //    btnStages.interactable = true;
        //    closeImage.SetActive(false);
        //}
    }

    private void Update()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels");
    }

    public void CreateNewGame()
    {
        //if (btnContinue != null)
        //    btnContinue.interactable = false;
        //btnStages.interactable = false;
        PlayerPrefs.DeleteAll();
        //SceneTransition.SwitchToScene("");
        StartProlog();
    }
    
    public void TryAgain()
    {
        SceneTransition.SwitchToScene("Prolog");
    }

    public void OpenMenu()
    {
        SceneTransition.SwitchToScene("Menu");
    }

    public void Continue()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels", 1);
        SceneManager.LoadScene(completeLevels + 1);
    }

    public void OpenStages()
    {
        stages.SetActive(true);
    }

    public void CloseStages()
    {
        stages.SetActive(false);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void StartProlog()
    {

        SceneTransition.SwitchToScene("Prolog");
    }

    public void StartNightDay()
    {
        SceneTransition.SwitchToScene("NightDay");
    }

    public void StartOutOfHome()
    {
        SceneTransition.SwitchToScene("WayToSchool");
    }

    public void StartRoad()
    {
        SceneTransition.SwitchToScene("Road");
    }

    public void StartSchool()
    {
        SceneTransition.SwitchToScene("SchoolMain");
    }

    public void StartFight()
    {
        SceneTransition.SwitchToScene("Fight");
    }
}
