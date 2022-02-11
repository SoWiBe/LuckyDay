using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;

    private bool _isWalking = false;

    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateAnimation();

        // test
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerAnimator.SetTrigger("interactTrigger");
        }
    }

    private void UpdateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        CheckToFlip(horizontal);
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
