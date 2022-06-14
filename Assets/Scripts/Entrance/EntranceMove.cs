using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceMove : MonoBehaviour
{
    private bool isMoving = false;
    private void OnMouseDown()
    {
        if (isMoving)
            return;
        isMoving = true;
        GoByElevator();
    }

    public void GoByStairs()
    {
        SceneTransition.SwitchToScene("Final");
    }

    public void GoByElevator()
    {
        SceneTransition.SwitchToScene("Road");
    }
}
