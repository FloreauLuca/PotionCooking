using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class SO_Potion : ScriptableObject
{
    [SerializeField] private Sprite[] recipe;
    public Sprite[] Recipe
    {
        get { return recipe; }
    }

    [SerializeField] private Sprite[] potionCupSprites;
    public Sprite[] PotionCupSprites
    {
        get { return potionCupSprites; }
    }

    [SerializeField] private string potionName;
    public string PotionName
    {
        get { return potionName; }
    }

    [SerializeField] private GameObject panelPrefab;
    public GameObject PanelPrefab
    {
        get { return panelPrefab; }
    }

    [SerializeField] private Sprite potionCauldron;
    public Sprite PotionCauldron
    {
        get { return potionCauldron; }
    }

    [SerializeField] private int cookingTime = 10;
    public int CookingTime
    {
        get { return cookingTime; }
    }
}
