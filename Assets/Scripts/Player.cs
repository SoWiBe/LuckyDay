using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;
    
    private Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateMovement();
        UpdateAnimation();
    }

    private void UpdateMovement()
    {
    	float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
    
    private void UpdateAnimation()
    {
    }    
}
