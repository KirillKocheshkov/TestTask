using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementFabricmMain : MonoBehaviour, IPoolable<GridElementMain>
{
    [SerializeField] protected GridElementMain prefab;

    protected abstract GridElementMain CreateObject();

    public abstract GridElementMain GetPoolObject();
    

    public abstract void ReturnOnjectToPool(GridElementMain obj);
    
}
