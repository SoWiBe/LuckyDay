using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    [SerializeField] private List<GameObject> firesElements;
    [SerializeField] private List<GameObject> smokeElements;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private AudioSource mainThemeSound;
    [SerializeField] private AudioSource sirenaSound;
    [SerializeField] private FireTimer timer;
    [SerializeField] private Text textTimer;
    [SerializeField] private GameObject sirena;
    [SerializeField] private GameObject redScreen;
    [SerializeField] private GameObject extinguisher;
    [SerializeField] private GameObject holdPoint;
    [SerializeField] private Player player;
    [SerializeField] private GameObject btnExtinguisher;
    [SerializeField] private AudioSource audioAfterFireDone;
    [SerializeField] private GameObject whiteFinal;
    [SerializeField] private ExtinguisherManager extinguisherManager;

    private Animator animatorText, animatorSiren, animatorPlayer, animatorWhiteScreen;
    private bool _isFireOut;
    public bool FireOut
    {
        get
        {
            return _isFireOut;
        }
        set
        {
            _isFireOut = value;
        }
    }

    private bool _isFireDone;
    public bool FireDone
    {
        get
        {
            return _isFireDone;
        }
        set
        {
            _isFireDone = value;
        }
    }

    private void Start()
    {
        animatorPlayer = player.GetComponent<Animator>();
        animatorText = textTimer.GetComponent<Animator>();
        animatorSiren = sirena.GetComponent<Animator>();
        animatorWhiteScreen = whiteFinal.GetComponent<Animator>();
    }

    public void CheckToPutOutFire(float timePutOut)
    {
        if (_isFireOut && !_isFireDone)
        {
            if (timePutOut <= 2)
            {
                Destroy(firesElements[0]);
                Destroy(firesElements[1]);
                Destroy(firesElements[5]);
                Destroy(smokeElements[0]);
                Destroy(smokeElements[1]);
                Destroy(smokeElements[5]);
            }
            else if (timePutOut <= 3)
            {
                Destroy(firesElements[2]);
                Destroy(firesElements[3]);
                Destroy(firesElements[6]);
                Destroy(smokeElements[2]);
                Destroy(smokeElements[3]);
                Destroy(smokeElements[6]);
            }
            else if (timePutOut <= 4)
            {
                Destroy(firesElements[4]);
                Destroy(firesElements[8]);
                Destroy(firesElements[7]);
                Destroy(smokeElements[4]);
            }
            else if (timePutOut < 5)
            {
                Destroy(smokeElements[7]);
                Destroy(smokeElements[8]);
                Destroy(smokeElements[9]);
                Destroy(firesElements[9]);
                Destroy(firesElements[10]);
                Destroy(firesElements[11]);
                FireDone = true;
                CheckFireToDone(FireDone);
            }
        }
    }

    private void CheckFireToDone(bool fireDone)
    {
        if (fireDone)
        {
            timer.TimeOn = false;
            extinguisherManager.StopPena();
            StopMusic();
            SetAnimationAfterFire();
            redScreen.SetActive(false);
            dialogueTrigger.StartDialog();
            btnExtinguisher.SetActive(false);
            Invoke("PlaySoundDoor", 1f);
            SetPositionToExtinguisher();

            StartCoroutine(LoadNightDay());
        }
    }

    IEnumerator LoadNightDay()
    {
        yield return new WaitForSeconds(7);

        StartWhiteScreen();
        SceneTransition.SwitchToScene("NightDay");
    }
    public void PlaySoundDoor()
    {
        audioAfterFireDone.Play();
    }
    public void StartWhiteScreen()
    {
        whiteFinal.SetActive(true);
        animatorWhiteScreen.SetTrigger("isFinalProlog");
    }
    private void StopMusic()
    {
        sirenaSound.Stop();
        mainThemeSound.Stop();
    }
    private void SetAnimationAfterFire()
    {
        animatorText.SetBool("isHidden", true);
        animatorSiren.SetBool("isHidden", true);
    }
    private void SetPositionToExtinguisher()
    {
        player.Handling = false;
        extinguisher.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Default");
        extinguisher.transform.position = holdPoint.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pena"))
        {
            this._isFireOut = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pena"))
        {
            this._isFireOut = false;
        }
    }
}
