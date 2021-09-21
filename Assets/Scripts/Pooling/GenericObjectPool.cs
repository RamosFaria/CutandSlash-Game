using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    
    public List<T> prefab = new List<T>();

    public static GenericObjectPool<T> Instance { get; private set; }

    private Queue<T> objectsAvailable = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if(objectsAvailable.Count == 0)
        {
            AddToPool(1);
        }
        return objectsAvailable.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectsAvailable.Enqueue(objectToReturn);
    }

    private void AddToPool(int count)
    {
        for(int i=0;i<prefab.Count;i++)
        {
            var newObj = GameObject.Instantiate(prefab[i]); 
            newObj.gameObject.SetActive(false);
            objectsAvailable.Enqueue(newObj);
        }

    }
}
