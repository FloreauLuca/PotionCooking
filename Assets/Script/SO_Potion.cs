using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Potion")]
public class SO_Potion : ScriptableObject
{
    [SerializeField] private Sprite[] recipe;

    [SerializeField] private Sprite potion;

    [SerializeField] private string potionName;
    [SerializeField] private GameObject panelPrefab;

    public Sprite[] Recipe
    {
        get { return recipe; }
    }

    public Sprite Potion
    {
        get { return potion; }
    }

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
