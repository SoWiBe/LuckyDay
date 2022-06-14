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
    private bool isMoveOne = false, isMoveTwo = false, isMoveThree = false, isMoveFour = false, isMoveFive = false;
    private void Start()
    {
        
    }

    public void CreateNewGame()
    {
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
        if (isMoveOne)
            return;
        isMoveOne = true;
        SceneTransition.SwitchToScene("Prolog");
    }

    public void StartNightDay()
    {
        if (isMoveTwo)
            return;
        isMoveTwo = true;
        SceneTransition.SwitchToScene("NightDay");
    }

    public void StartOutOfHome()
    {
        if (isMoveThree)
            return;
        isMoveThree = true;
        SceneTransition.SwitchToScene("WayToSchool");
    }

    public void StartRoad()
    {
        if (isMoveFour)
            return;
        isMoveFour = true;
        SceneTransition.SwitchToScene("Road");
    }

    public void StartSchool()
    {
        if (isMoveFive)
            return;
        isMoveFive = true;
        SceneTransition.SwitchToScene("SchoolMain");
    }
}
