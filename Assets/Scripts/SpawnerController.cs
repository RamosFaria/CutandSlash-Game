using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]private Transform[] spawnPoint;
    [SerializeField]private Packs defaultPack;

    private List<Component> pooled = new List<Component>();

    private float time;
    private float spawnTime = 1.5f;
    private float rand;
    private void Awake()
    {
        if(CurrentGameData.packSelected == null)
        {
            CurrentGameData.packSelected = defaultPack;
        }
    }
    private void Start()
    {
        foreach (GameObject packObj in CurrentGameData.packSelected.ObjectsInPack)
        {
            
            if (packObj.GetComponent<ObjectsToSlice>() != null)
            {
                ObjectToSlicePool.Instance.prefab.Add(packObj.GetComponent<ObjectsToSlice>());
                ObjectToSlicePool.Instance.Get();
            }
            else if (packObj.GetComponent<Bomb>() != null)
            {
                BombPool.Instance.prefab.Add(packObj.GetComponent<Bomb>());
                BombPool.Instance.Get();
            }
        }

        
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnTime)
        {
            rand = Random.Range(0f, 1f);
            
            SpawnObj(rand);
            time = 0;
        }
    }

    public void SpawnObj(float rand)
    {

        int posIndex = Random.Range(0, spawnPoint.Length);
        
        
        float delay = Random.Range(0.1f, 1f);
        //yield return new WaitForSeconds(delay);

        if (rand >= 0.3)
        {
            GameObject obj = ObjectToSlicePool.Instance.Get().gameObject;
            obj.transform.position = spawnPoint[posIndex].position;
            obj.SetActive(true);
        }

        else
        {
            GameObject obj = BombPool.Instance.Get().gameObject;
            obj.transform.position = spawnPoint[posIndex].position;
            obj.SetActive(true);
        }
           
    }
}
