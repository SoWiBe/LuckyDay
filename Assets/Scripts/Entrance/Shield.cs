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

    private void OnMouseDown()
    {

        if (!inventoryItems[0].isTaked)
        {
            if(!isShowDialogueForFindThings)
            {
                isShowDialogueForFindThings = true;
                dialogueWithoutThings.StartDialog();
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
            SetStatusActiveObjects();
            gameObject.SetActive(false);
        }
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
        canvasShield.SetActive(isOpenShield);
        SetStatusActiveObjects();
    }


}