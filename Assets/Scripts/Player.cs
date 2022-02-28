using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    [SerializeField] private GameObject extinguisher;

    [SerializeField] private Transform holdExtinguisherPoint;

    [SerializeField] private ParticleSystem systemPutOutFire;

    private Animator _playerAnimator;

    private bool _isWalking = false;

    private bool _isHandling = false;

    private bool _isCanToHandThing = false;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateAnimation();
        PutOutFire();

        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerAnimator.SetTrigger("interactTrigger");

            if (_isCanToHandThing && !_isHandling)
            {
                this._isHandling = true;
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
        }
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
        if (_isWalking)
            _playerAnimator.SetBool("isWalking", true);
        else
            _playerAnimator.SetBool("isWalking", false);
    }

    public void CheckToFlip(float horizontal)
    {
        Vector3 localScale = transform.localScale;

        if (horizontal < 0 && localScale.x > 0)
            localScale.x *= -1;
        if (horizontal > 0 && localScale.x < 0)
            localScale.x *= -1;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: делаем проверку на соприкосновение с каким-либо объектом
        // пока что будем проверять по тэгу объекта
        // (если в будущем узнаем, что это кал схема, то заменим на лучшее решение)
        // Пример:
        // if (collision.collider.CompareTag("enemy")) ...

        //probably useless lines
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Destroy(gameObject);
        //}
    }

}
