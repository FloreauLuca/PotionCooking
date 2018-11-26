using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class SO_Potion : ScriptableObject
{
    [SerializeField] private Sprite[] recipe;

    [SerializeField] private Sprite[] potionCupSprites;
    //private Sprite currentPotionCup;

    [SerializeField] private string potionName;
    [SerializeField] private GameObject panelPrefab;

    [SerializeField] private Sprite potionCauldron;

    [SerializeField] private int cookingTime = 10;

    public int CookingTime
    {
        get { return cookingTime; }
    }

    public Sprite PotionCauldron
    {
        get { return potionCauldron; }
    }

    public Sprite[] Recipe
    {
        get { return recipe; }
    }

    public Sprite[] PotionCupSprites
    {
        get { return potionCupSprites; }
    }

    /*public Sprite CurrentPotionCup
    {
        get { return currentPotionCup; }
        set { currentPotionCup = value; }
    }*/

    public string PotionName
    {
        get { return potionName; }
    }

    public GameObject PanelPrefab
    {
        get
        { return panelPrefab;}
    }
}
