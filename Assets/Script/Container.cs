using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    [SerializeField] private List<Sprite> currentContainObjectType;

    // Use this for initialization
    void Start ()
    {
        currentContainObjectType = new List<Sprite>();
    }

    public void OnDropObject(List<Sprite> objectType)
    {
        if (gameObject.tag == "Cauldron")
        {
            if (gameObject.GetComponent<Cauldron>().Locked)
            {
                gameObject.GetComponent<Cauldron>().SetContainerNull();
            }
        }

        if (gameObject.tag == "Cup")
        {
            currentContainObjectType = new List<Sprite>();
        }

        currentContainObjectType.AddRange(objectType);
    }

    public List<Sprite> CurrentContainObjectType
    {
        get
        {
            return currentContainObjectType;
        }
        set { currentContainObjectType = value; }
    }

}
