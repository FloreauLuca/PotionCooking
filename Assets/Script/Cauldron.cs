using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.Audio;

public class Cauldron : MonoBehaviour
{

    [SerializeField] private SO_Potion[] recipeArray;

    private int nbGoodIngredient;
    private int recipeSucessfulIndex = -1;

    private Container container;
    [SerializeField] private GameObject[] item;
    private const int RECIPE_ARRAY_LENGTH = 3;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite fillInvisibility;
    [SerializeField] private Sprite fillLevitation;
    [SerializeField] private Sprite fillMetamorphose;
    private Sprite emptySprite;

    private float recipeTime;

    [SerializeField] private Animator sandGlassAnimator;

    [SerializeField] private ParticleSystem bubbleInvisibility;
    [SerializeField] private ParticleSystem bubbleLevitation;
    [SerializeField] private ParticleSystem bubbleMetamorphose;
    [SerializeField] private GameObject bubbleSpawner;
    private ParticleSystem currentBubbleParticule;
    private AudioSource audioSource;
    [SerializeField] private AudioClip bubblesAudioClip;

    private bool locked = false; // detecter si le chaudron possède une potion
    public bool Locked
    {
        get { return locked; }
    }

    void Start ()
    {
        container = GetComponent<Container>();
        emptySprite = spriteRenderer.sprite;
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
	    if (container.CurrentContainObjectType.Count == RECIPE_ARRAY_LENGTH && !locked) // si une recette est compléter
	    {
	        recipeSucessfulIndex = -1;
	        for (int recipeIndex = 0; recipeIndex < recipeArray.Length; recipeIndex++)
	        {
	            nbGoodIngredient = 0;
	            foreach (Sprite recipeIngredientIndex in recipeArray[recipeIndex].Recipe)
	            {
	                foreach (Sprite ingredientIndex in container.CurrentContainObjectType)
	                {
	                    if (ingredientIndex == recipeIngredientIndex)
	                    {
	                        nbGoodIngredient++;
	                        break;
	                    }
	                }
	            }
                if (nbGoodIngredient == 3)
	            {
	                recipeSucessfulIndex = recipeIndex;
	            }
            }

	        SetContainerNull();
            if (recipeSucessfulIndex > -1)
            {
                recipeTime = recipeArray[recipeSucessfulIndex].CookingTime;
                locked = true;
                StartCoroutine(Cooking(recipeArray[recipeSucessfulIndex].PotionCauldron));
                sandGlassAnimator.SetFloat("Speed", 1/recipeTime);
            }
        }


	    if (container.CurrentContainObjectType.Count < 3) // affichage des ingrédients actuelllement dans le chaudron
	    {
	        for (int i = 0; i < container.CurrentContainObjectType.Count; i++)
	        {
	            item[i].GetComponentInChildren<SpriteRenderer>().sprite = container.CurrentContainObjectType[i];
	        }
	    }
        
	    if (container.CurrentContainObjectType.Any()) // test si il n'est pas vide
	    {

	        if (container.CurrentContainObjectType[0].name == "PotionInvisibility")
	        {
	            locked = true;
	            spriteRenderer.sprite = fillInvisibility;
	        }
	        else if (container.CurrentContainObjectType[0].name == "PotionLevitation")
	        {
	            locked = true;
	            spriteRenderer.sprite = fillLevitation;
	        }
	        else if (container.CurrentContainObjectType[0].name == "PotionMetamorphose")
	        {
	            locked = true;
	            spriteRenderer.sprite = fillMetamorphose;
	        }
	        else
	        {
                spriteRenderer.sprite = emptySprite;
	        }
	    }
	    else
	    {
	        spriteRenderer.sprite = emptySprite;
        }
	}

    public void SetContainerNull()
    {
        container.CurrentContainObjectType = new List<Sprite>();
        for (int i = 0; i < 3; i++)
        {
            item[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
        }
        locked = false;
    }


    IEnumerator Cooking(Sprite potion)
    {
        if (potion.name == "PotionInvisibility")
        {
            currentBubbleParticule = Instantiate(bubbleInvisibility, bubbleSpawner.transform);
        }
        else if (potion.name == "PotionLevitation")
        {
            currentBubbleParticule = Instantiate(bubbleLevitation, bubbleSpawner.transform);
        }
        else if (potion.name == "PotionMetamorphose")
        {
            currentBubbleParticule = Instantiate(bubbleMetamorphose, bubbleSpawner.transform);
        }

        audioSource.clip = bubblesAudioClip;
        audioSource.Play();

        yield return new WaitForSeconds(recipeTime);

        container.CurrentContainObjectType.Add(recipeArray[recipeSucessfulIndex].PotionCauldron);
        Destroy(currentBubbleParticule);
        audioSource.Stop();
        sandGlassAnimator.SetFloat("Speed", 0);
    }

}
