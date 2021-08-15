using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<ObjectPoolItems> itemsToPool;
    private List<GameObject> pooledObjects;
    void Start()
    {
        pooledObjects = new List<GameObject>();
    }


}

[Serializable]
public class ObjectPoolItems
{
    public string name;
    public int poolAmount;
    public GameObject poolObject;
    public bool shouldExpland;
}