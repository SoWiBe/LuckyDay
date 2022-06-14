using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isOpenShield = false;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject joystick;
    public GameObject canvasShield;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject chest;

    [SerializeField] private Pickup[] inventoryItems;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private DialogueTrigger dialogueWithoutThings;

    public PointControl[] pointControls;
    [SerializeField] private ConnectManager ConnectManager;

    private bool isShowDialogue = false;
    private bool isShowDialogueForFindThings = false;

    [SerializeField] private AudioSource audio;

    private void OnMouseDown()
    {

        if (!inventoryItems[1].isTaked)
        {
            if(!isShowDialogueForFindThings)
            {
                isShowDialogueForFindThings = true;
                dialogueWithoutThings.StartDialog();
                audio.Play();
            }
            return;
        }
        if (ConnectManager.isGame)
        {
            if(!isShowDialogue)
            {
                dialogueTrigger.StartDialog();
                isShowDialogue = true;
            }
            isOpenShield = !isOpenShield;
            canvasShield.SetActive(true);
            gameObject.SetActive(false);
            SetStatusActiveObjects();
            
        }

        if(!ConnectManager.isGame)
            gameObject.SetActive(false);
    }

    public void SetStatusActiveObjects()
    {
        inventory.SetActive(!isOpenShield);
        player.SetActive(!isOpenShield);
        joystick.SetActive(!isOpenShield);
        chest.SetActive(!isOpenShield);
    }

    public void CloseShield()
    {
        for (int i = 0; i < pointControls.Length; i++)
        {
            pointControls[i].SetBasePositionLine();
        }
        isOpenShield = !isOpenShield;
        canvasShield.SetActive(false);
        gameObject.SetActive(true);
        SetStatusActiveObjects();

        Debug.Log("Hello");
    }
}
