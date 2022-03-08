using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;

    private bool _isWalking = false;

    private bool _joystickTouchStart = false;

    private Vector2 _touchStartPoint;

    private Vector2 _touchEndPoint;

    private Animator _playerAnimator;

    [SerializeField]
    private Transform _joystickInnerCircle;

    [SerializeField]
    private Transform _joystickOuterCircle;

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

        // test
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerAnimator.SetTrigger("interactTrigger");
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
            Vector2 offset = _touchEndPoint - _touchStartPoint;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            transform.Translate(direction * _speed * Time.deltaTime);

            _joystickInnerCircle.transform.position =
                new Vector2(_touchStartPoint.x + direction.x,
                    _touchStartPoint.y + direction.y);
        }
    }

    private void UpdateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        CheckToFlip (horizontal);
        _isWalking =
            horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0;

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

        if (horizontal < 0 && localScale.x > 0) localScale.x *= -1;
        if (horizontal > 0 && localScale.x < 0) localScale.x *= -1;

        transform.localScale = localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: ������ �������� �� ��������� � �������
        // ���� ������, �� ��������� �����-���� �������
        // (��������� ��������, ��������� �� ������ �����, �������� �����-���� �������������� ����)
        // ������:
        // if (other.CompareTag("runFightCutscene")) ...
    }

    private void OnCollisionEnter(Collision collision)
    {
        // TODO: ������ �������� �� ��������������� � �����-���� ��������
        // ���� ��� ����� ��������� �� ���� �������
        // (���� � ������� ������, ��� ��� ��� �����, �� ������� �� ������ �������)
        // ������:
        // if (collision.collider.CompareTag("enemy")) ...
    }
}
