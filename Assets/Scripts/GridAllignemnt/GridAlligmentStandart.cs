using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (GridManager))]
public class GridAlligmentStandart : GridAlignmentMain
{
    
    public event ResolutionChangeHandler OnResolutionChange ;
    Vector2 elementSize;
    GridManager currentGrid;
    private Vector2 lastScreenSize;
    private void Awake() 
    {
        currentGrid = GetComponent<GridManager> ();
        lastScreenSize = new Vector2(Screen.width,Screen.height);
        OnResolutionChange += AlignmentToGrid;
    }

    

    private void FixedUpdate()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height); 
 
         if (lastScreenSize != screenSize)
          {
             lastScreenSize = screenSize;
            if(OnResolutionChange != null)
            {
                OnResolutionChange();
            }
          }
    }
    public override void AlignmentToGrid()
    {
        ResizeContent();
    }
    

    private void SetElementPosition(RectTransform item, Vector2  position)
    {
        item.anchoredPosition = position;        
        
    }

    

    private void ResizeContent()
    {
        float gridWidth = currentGrid.GridRectTransform.rect.width;
        float gridHeight = currentGrid.GridRectTransform.rect.height;

        float elementWidth = gridWidth / currentGrid.GridColumns;
        float elementHeight = gridHeight / currentGrid.GridRaws;

        elementSize.x = elementWidth;
        elementSize.y = elementHeight;
         int currentColumn =0; 
         int currentRaw =0 ;        
           for (int i = 0; i< currentGrid.ElementList.Count; i++)
           {
               currentColumn = i% currentGrid.GridColumns;
               currentRaw = i/ currentGrid.GridColumns;
               var item = currentGrid.ElementList[i];
               float x = (elementSize.x * currentColumn);
               float y = (elementSize.y * currentRaw);
               item.ElementTransform.sizeDelta = elementSize;
               SetElementPosition(item.ElementTransform,new Vector2(x,-y));
           }
        
    }
}

public delegate void ResolutionChangeHandler();