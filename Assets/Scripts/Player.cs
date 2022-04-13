using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    [SerializeField] private GameObject extinguisher;

    [SerializeField] private Transform holdExtinguisherPoint;

    [SerializeField] private GameObject buttonExtinguisher;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Fire fire;

    [SerializeField] Joystick joystick;

    private Animator _playerAnimator;

    private bool _isWalking = false;

    private bool _isHandling = false;

    private int completeLevels;

    public bool Handling
    {
        set
        {
            _isHandling = value;
        }
    }

    private bool _isCanToHandThing = false;
    
    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        completeLevels = levelManager.CompleteLevels;
    }

    private void Update()
    {
        UpdateMovement();
        UpdateAnimation();
        UpdateLevels();
        if (_isHandling)
        {
            SetPositionToExtinguisher();
            buttonExtinguisher.SetActive(true);
        }
    }

    private void UpdateLevels()
    {
        completeLevels = PlayerPrefs.GetInt("CompleteLevels", 1);
    }

    public void GetExtinguisher()
    {
        if (_isCanToHandThing && !_isHandling)
        {
            _playerAnimator.SetBool("isExtinguisher", true);
            extinguisher.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Fire");
            this._isHandling = true;
            SetPositionToExtinguisher();
        }
    }

    private void SetPositionToExtinguisher()
    {
        extinguisher.transform.position = holdExtinguisherPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Extinguisher"))
        {
            this._isCanToHandThing = true;
        }

        if (collision.CompareTag("Entrance") && fire.FireDone)
        {
            fire.StartWhiteScreen();
            int completeLevels = PlayerPrefs.GetInt("CompleteLevels");
            if(completeLevels < 2)
            {
                PlayerPrefs.SetInt("CompleteLevels", 2);
            }
            Invoke("SetNextLevel", 4f);
        }
    }

    private void SetNextLevel()
    {
        levelManager.NextLevel();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Extinguisher"))
        {
            this._isCanToHandThing = false;
        }
    }

    private void UpdateMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        CheckToFlip(horizontal);
        if (_isHandling)
        {
            CheckToFlipThing(horizontal, extinguisher);
        }

        _isWalking = horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0;

        Vector3 direction = new Vector3(horizontal, vertical, 0f);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void UpdateAnimation()
    {
        if (_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isExtinguisher", false);
            _playerAnimator.SetBool("isWalkingWithThing", false);
            _playerAnimator.SetBool("isWalking", true);
        }
        else if (!_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isWalkingWithThing", false);
            _playerAnimator.SetBool("isExtinguisher", false);
            _playerAnimator.SetBool("isWalking", false);
        }
        else if (_isHandling && _isWalking)
        {
            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("isExtinguisher", true);
            _playerAnimator.SetBool("isWalkingWithThing", true);
        } 
        else if (_isHandling && !_isWalking)
        {
            _playerAnimator.SetBool("isWalkingWithThing", false);
        }
    }

    public void CheckToFlip(float horizontal)
    {
        Vector3 localScale = transform.localScale;

        if (horizontal < 0 && localScale.x > 0) localScale.x *= -1;
        if (horizontal > 0 && localScale.x < 0) localScale.x *= -1;

        transform.localScale = localScale;
    }

    private void CheckToFlipThing(float horizontal, GameObject thing)
    {
        Vector3 localScale = thing.transform.localScale;

        if (horizontal < 0 && localScale.x > 0)
            localScale.x *= -1;
        if (horizontal > 0 && localScale.x < 0)
            localScale.x *= -1;

        thing.transform.localScale = localScale;
    }
}
