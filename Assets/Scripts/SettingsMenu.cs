using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        animator.SetBool("isHovering", true);
    }

    void OnMouseExit()
    {
        animator.SetBool("isHovering", false);
    }
}
