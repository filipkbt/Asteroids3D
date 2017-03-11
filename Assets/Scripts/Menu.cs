using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    private Animator animator;
    private CanvasGroup canvasGroup;
	// Use this for initialization
	public bool IsOpen
    {
        get { return animator.GetBool("IsOpen"); }
        set { animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

       

    }

    public void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
            canvasGroup.blocksRaycasts = canvasGroup.interactable = false;

        else
            canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
    }

}
