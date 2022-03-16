using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    [SerializeField] private GameObject extinguisher;

    [SerializeField] private Transform holdExtinguisherPoint;

    [SerializeField] private ParticleSystem systemPutOutFire;

    [SerializeField] private GameObject closeDoor;

    [SerializeField] private AudioSource soundDoorOpen;

    [SerializeField] private AudioSource soundFirePutOut;

    [SerializeField] private GameObject doorImage;

    private bool _joystickTouchStart = false;

    private Vector2 _touchStartPoint;

    private Vector2 _touchEndPoint;

    private Animator _playerAnimator;

    [SerializeField]
    private Transform _joystickInnerCircle;

    [SerializeField]
    private Transform _joystickOuterCircle;
    
    private bool _isWalking = false;

    private bool _isHandling = false;

    private bool _isCanToHandThing = false;

    private bool _isCanToOpenDoor = false;
    
    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateJoystick();
        UpdateJoystickMovement();
        UpdateAnimation();
        PutOutFire();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isCanToHandThing && !_isHandling)
            {
                _playerAnimator.SetBool("isExtinguisher", true);
                extinguisher.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Fire");
                this._isHandling = true;
            }

            if (_isCanToOpenDoor)
            {
                _playerAnimator.SetTrigger("interactTrigger");
                Destroy(closeDoor);
                doorImage.SetActive(true);
                soundDoorOpen.Play();
                this._isCanToOpenDoor = false;
            }
        }

        if (_isHandling)
            extinguisher.transform.position = holdExtinguisherPoint.position;

    }

    private void PutOutFire()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isHandling)
        {
            systemPutOutFire.Play();
            soundFirePutOut.Play();
        }
    }

    private void UpdateJoystick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchStartPoint =
                Camera
                    .main
                    .ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y,
                        Camera.main.transform.position.z));

            _joystickInnerCircle.transform.position = _touchStartPoint;
            _joystickInnerCircle.GetComponent<SpriteRenderer>().enabled = true;
            _joystickOuterCircle.transform.position = _touchStartPoint;
            _joystickOuterCircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            _joystickTouchStart = true;
            _touchEndPoint =
                Camera
                    .main
                    .ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y,
                        Camera.main.transform.position.z));
        }
        else
        {
            _joystickTouchStart = false;
            _joystickInnerCircle.GetComponent<SpriteRenderer>().enabled = false;
            _joystickOuterCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void UpdateJoystickMovement()
    {
        if (_joystickTouchStart)
        {
            _isWalking = true;
            Vector2 offset = _touchEndPoint - _touchStartPoint;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            transform.Translate(direction * _speed * Time.deltaTime);

            CheckToFlip(direction.x);

            _joystickInnerCircle.transform.position =
                new Vector2(_touchStartPoint.x + direction.x,
                    _touchStartPoint.y + direction.y);
        }
        else
            _isWalking = false;
    }

    private void UpdateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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
<<<<<<< HEAD
        if (_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isWalking", true);
        }
        else if (!_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isWalking", false);
        }
        else if (_isHandling && !_isWalking)
        {
            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("isExtinguisher", true);
=======
        _playerAnimator.SetBool("isWalking", _isWalking);

        if (_isHandling && _isHandling)
            _playerAnimator.SetBool("isWalkingWithThing", true);
        else
>>>>>>> main
            _playerAnimator.SetBool("isWalkingWithThing", false);
        }
        else if (_isHandling && _isWalking)
        {
            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("isExtinguisher", true);
            _playerAnimator.SetBool("isWalkingWithThing", true);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Extinguisher"))
        {
            this._isCanToHandThing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Extinguisher"))
        {
            this._isCanToHandThing = false;
        }

        if (collision.CompareTag("Door"))
        {
            this._isCanToOpenDoor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            this._isCanToOpenDoor = true;
        }
    }

}
