using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class RecipeGUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    [SerializeField] private SO_Potion potion;

    [SerializeField] private GameObject[] ingredientItem;

    [SerializeField] private GameObject potionItem;
    [SerializeField] private GameObject textMesh;
    void Start()
    {

        animator = GetComponent<Animator>();

        for (int i = 0; i < ingredientItem.Length; i++)
        {
            ingredientItem[i].GetComponent<Image>().sprite = potion.Recipe[i];
        }

        ;

        potionItem.GetComponent<Image>().sprite = potion.CurrentPotionCup;
        textMesh.GetComponent<TextMeshProUGUI>().text = potion.PotionName;


    }
    // Use this for initialization
    
	

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", false);
    }

    public SO_Potion Potion
    {
        get { return potion; }
        set { potion = value; }
    }
}
