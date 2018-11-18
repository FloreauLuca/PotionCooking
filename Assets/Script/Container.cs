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
	
	// Update is called once per frame
	void Update () {
	}

    public void OnDropObject(List<Sprite> objectType)
    {
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
