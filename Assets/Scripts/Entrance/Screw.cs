using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void ScrewUp()
    {
        animator.SetBool("isScrew", true);
        Invoke("SetActiveForObject", 2);
    }

    private void SetActiveForObject()
    {
        gameObject.SetActive(false);
    }
}
