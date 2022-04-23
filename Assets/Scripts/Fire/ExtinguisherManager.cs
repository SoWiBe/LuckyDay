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
    private float startTime, endTime;
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
            if(fire.FireOut)
            {
                startTime += Time.deltaTime;
                Debug.Log(startTime);
                SendResults();
            }
        }
    }

    private IEnumerator StartTime(float timeFireDone)
    {
        Debug.Log(timeFireDone);
        yield return new WaitForSeconds(timeFireDone);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isStart = true;
        OutFire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isStart = false;
        StopPena();
    }

    public void SaveTime()
    {
    }
    public void OutFire()
    {
        systemPutOutFire.Play();
        soundFirePutOut.Play();
        
    }
    public void SendResults()
    {
        fire.CheckToPutOutFire(startTime);
    }

    public void StopPena()
    {
        systemPutOutFire.Stop();
        soundFirePutOut.Stop();
    }
}
