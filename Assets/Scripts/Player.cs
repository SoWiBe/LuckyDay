using UnityEngine;

public class Player : MonoBehaviour
{
    //Скорость движения игрока
    [SerializeField] private float _speed = 1.5f;
    //Объект огнетушителя
    [SerializeField] private GameObject extinguisher;
    //Точка появления огнетушителя
    [SerializeField] private Transform holdExtinguisherPoint;
    //Кнопка тушения
    [SerializeField] private GameObject buttonExtinguisher;
    //Менеджер уровней
    [SerializeField] private LevelManager levelManager;
    //Объект класса fire для работы с огнем
    [SerializeField] private Fire fire;
    //обработка движений через joystick
    [SerializeField] Joystick joystick;
    //Аниматор, который отвечает за все анимации персонажа
    private Animator _playerAnimator;

    //проверки на движение и наличие чего-либо в руках
    private bool _isWalking = false;
    private bool _isHandling = false;

    //выполненные уровни
    private int completeLevels;
    //свойство на установку значения булевой переменной - наличие чего-либо в руках 
    public bool Handling
    {
        set
        {
            _isHandling = value;
        }
    }

    //проверка на возможность подобрать предмет (огнетушитель)
    private bool _isCanToHandThing = false;
    
    private void Start()
    {
        //получаем Аниматор с нашего объекта, на котором висит этот скрипт
        _playerAnimator = GetComponent<Animator>();
        //получаем пройденные уровни
        completeLevels = levelManager.CompleteLevels;
    }

    private void Update()
    {
        //обновление движения
        UpdateMovement();
        //обновление анимаций
        UpdateAnimation();
        //обновление уровней
        UpdateLevels();
        //отобразить кнопку тушения, если взят огнетушитель
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
        //если есть возможность взять предмет и мы его еще не взяли, то берем
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
        //установка позиции для огнетушителя после подбора
        extinguisher.transform.position = holdExtinguisherPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Extinguisher"))
        {
            this._isCanToHandThing = true;
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
        //установка значений с joystick'a
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        //проверка на поворот по горизонтали
        CheckToFlip(horizontal);
        //если в руках предмет, то проверяем и его на поворот
        if (_isHandling)
        {
            CheckToFlipThing(horizontal, extinguisher);
        }

        //движение персонажа
        _isWalking = horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0;

        Vector3 direction = new Vector3(horizontal, vertical, 0f);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    //обновление анимации
    private void UpdateAnimation()
    {
        //если мы идем и предмет не взят
        if (_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isExtinguisher", false);
            _playerAnimator.SetBool("isWalkingWithThing", false);
            _playerAnimator.SetBool("isWalking", true);
        }
        //если мы не идем и предмет не взят
        else if (!_isWalking && !_isHandling)
        {
            _playerAnimator.SetBool("isWalkingWithThing", false);
            _playerAnimator.SetBool("isExtinguisher", false);
            _playerAnimator.SetBool("isWalking", false);
        }
        //если мы идем и предмет взят
        else if (_isHandling && _isWalking)
        {
            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("isExtinguisher", true);
            _playerAnimator.SetBool("isWalkingWithThing", true);
        }
        //если мы взяли предмет и не идем
        else if (_isHandling && !_isWalking)
        {
            _playerAnimator.SetBool("isWalkingWithThing", false);
        }
    }

    //проверка на поворот персонажа
    public void CheckToFlip(float horizontal)
    {
        Vector3 localScale = transform.localScale;

        if (horizontal < 0 && localScale.x > 0) localScale.x *= -1;
        if (horizontal > 0 && localScale.x < 0) localScale.x *= -1;

        transform.localScale = localScale;
    }
    //проверка на поворот вещи
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
