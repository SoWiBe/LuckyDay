using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectUsing : MonoBehaviour
{
    [SerializeField] private TriggersHelpManager trigger;

    public void UseExtinguisher()
    {
        trigger.SetActiveMessage();
    }
}
