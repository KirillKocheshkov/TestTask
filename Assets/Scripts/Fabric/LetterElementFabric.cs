using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterElementFabric : ElementFabricmMain
{
    [SerializeField] int starPoolSize;
    
    private Queue<GridElementMain> currentPool;
    private void Start() 
    {
        currentPool = new Queue<GridElementMain>();
        FillTheQueue(starPoolSize);
    }
    protected override GridElementMain CreateObject()
    {
        
        return Instantiate(prefab);
    }

    public override GridElementMain GetPoolObject()
    {
        if(currentPool.Count> 0)
        {
            var item = currentPool.Dequeue();
            item.gameObject.SetActive(true);
            return item;
        }

        return CreateObject();
    }

    public override void ReturnOnjectToPool(GridElementMain obj)
    {
        obj.gameObject.SetActive(false);
        currentPool.Enqueue(obj);
    }

    public void FillTheQueue( int amount)
    {
        for(int i =0; i< amount; i++)
        {
            var item = CreateObject();
            item.gameObject.SetActive(false);
            currentPool.Enqueue(item);
        }
    }
}
