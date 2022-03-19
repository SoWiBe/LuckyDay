using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    private float _timeLeft = 0f;
    private bool _timerOn = false;
    public bool TimeOn
    {
        set
        {
            _timerOn = value;
        }
    }

    void Start()
    {
        _timeLeft = time;
        _timerOn = true;
    }

    void Update()
    {
        if (_timerOn)
        {
            if(_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } 
            else
            {
                _timeLeft = time;
                _timerOn = false;
                SceneManager.LoadScene("Die");
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
