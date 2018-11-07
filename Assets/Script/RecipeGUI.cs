using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeGUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", false);
    }
}
