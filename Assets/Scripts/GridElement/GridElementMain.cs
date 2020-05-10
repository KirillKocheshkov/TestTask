using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridElementMain : MonoBehaviour
{
    public abstract Vector2 Possition{get;set;}
    public RectTransform ElementTransform {get; private set;}
    protected virtual void Awake() 
    {
        ElementTransform = (RectTransform) transform;
    }
   
}
