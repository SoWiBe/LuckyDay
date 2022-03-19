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

    private Animator animatorText, animatorSiren, animatorPlayer;
    private bool _isFireOut;
    private bool _isFireDone;
    private int count = 0;
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
    }

    public void CheckToPutOutFire()
    {
        if (_isFireOut && !_isFireDone)
        {
            count++;

            if (count == 5)
            {
                Destroy(firesElements[0]);
                Destroy(firesElements[1]);
                Destroy(firesElements[5]);
                Destroy(smokeElements[0]);
                Destroy(smokeElements[1]);
                Destroy(smokeElements[5]);
            }
            else if (count == 10)
            {
                Destroy(firesElements[2]);
                Destroy(firesElements[3]);
                Destroy(firesElements[6]);
                Destroy(smokeElements[2]);
                Destroy(smokeElements[3]);
                Destroy(smokeElements[6]);
            }
            else if (count == 15)
            {
                Destroy(firesElements[4]);
                Destroy(firesElements[8]);
                Destroy(firesElements[7]);
                Destroy(smokeElements[4]);
            }
            else if (count == 20)
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
            player.StopPena();
            StopMusic();
            SetAnimationAfterFire();
            redScreen.SetActive(false);
            dialogueTrigger.StartDialog();
            btnExtinguisher.SetActive(false);
            InvokeRepeating("PlaySoundDoor", 8f, 14);
            SetPositionToExtinguisher();
        }
    }
    public void PlaySoundDoor()
    {
        audioAfterFireDone.Play();
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
