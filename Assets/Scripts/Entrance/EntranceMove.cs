using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceMove : MonoBehaviour
{
    private void OnMouseDown()
    {
        GoByStairs();
    }

    public void GoByStairs()
    {
        SceneTransition.SwitchToScene("Final");
    }

    public void GoByElevator()
    {
        SceneTransition.SwitchToScene("WayToSchool");
    }
}
