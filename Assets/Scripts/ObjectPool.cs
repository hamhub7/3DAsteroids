using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prototype;
    private List<GameObject> pool;
    private bool canGrow;

    public ObjectPool(GameObject prefab, bool canGrow, int count)
    {
        pool = new List<GameObject>();
        for(int i = 0; i < count; i++)
        {
            GameObject next = Object.Instantiate(prefab);
            next.SetActive(false);
            pool.Add(next);
        }

        prototype = prefab;
        this.canGrow = canGrow;
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if(!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        if(canGrow)
        {
            GameObject next = Object.Instantiate(prototype);
            next.SetActive(false);
            pool.Add(next);
            return next;
        }

        return null;
    }
}
