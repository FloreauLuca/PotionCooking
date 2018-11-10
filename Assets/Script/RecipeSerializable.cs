using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeSerializable
{
    [SerializeField] private Sprite[] recipe;

    [SerializeField] private Sprite potion;

    
    public Sprite[] Recipe
    {
        get { return recipe; }
        set { recipe = value; }
    }

    public Sprite Potion
    {
        get { return potion; }
        set { potion = value; }
    }

}
