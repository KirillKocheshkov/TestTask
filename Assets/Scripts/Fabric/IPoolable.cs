using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable <T>
{
    T GetPoolObject();
    void ReturnOnjectToPool(T obj);
}
