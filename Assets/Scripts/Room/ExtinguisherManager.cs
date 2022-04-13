using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtinguisherManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Player player;
    [SerializeField] private ParticleSystem systemPutOutFire;
    [SerializeField] private AudioSource soundFirePutOut;
    [SerializeField] private Fire fire;

    private bool _isStart = false;
    private float startTime;
    private float timeTouch;

    public float TimeTouch
    {
        get
        {
            return timeTouch;
        }

        set
        {
            timeTouch = value;
        }
    }

    private void Update()
    {
        if (_isStart)
        {
            SaveTime();
            SendResults();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _isStart = true;
        StartTime();
        OutFire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isStart = false;
        StopPena();
    }

    public void StartTime()
    {
        startTime = Time.deltaTime;
    }

    public void SaveTime()
    {
        timeTouch += Time.deltaTime - startTime;
        Debug.Log(timeTouch % 60);
    }
    public void OutFire()
    {
        systemPutOutFire.Play();
        soundFirePutOut.Play();
        
    }
    public void SendResults()
    {
        fire.CheckToPutOutFire(timeTouch);
    }

    public void StopPena()
    {
        systemPutOutFire.Stop();
        soundFirePutOut.Stop();
    }
}
