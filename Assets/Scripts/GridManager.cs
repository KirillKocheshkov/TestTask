using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
   private List<GridElementMain> elementList;
   private GridAlignmentMain gridAlignment;
   private ShufflerMain currentShuffler;
   private ElementFabricmMain currentFabric;
   int gridRaws;
   int gridColumns;
   bool canGenerate = true;
   [SerializeField] Text warning;
   
   private RectTransform gridRectTransform;
    private float timeToWait = 5f;

    public List<GridElementMain> ElementList { get => elementList;  }
    public int GridRaws { get => gridRaws; set {if(value> 0) gridRaws = value;}  }
    public int GridColumns { get => gridColumns; set {if(value> 0) gridColumns = value;} }

    public RectTransform GridRectTransform { get => gridRectTransform;  }

    private void Awake()
   {
      gridRectTransform = (RectTransform) transform;
      gridAlignment= GetComponent<GridAlignmentMain>();
      elementList = new List<GridElementMain>();
      currentShuffler = GetComponent<ShufflerMain>();
      currentFabric = GetComponent <ElementFabricmMain>();
      
   }

    public void GenerateGrid ()
    {
        if(GridRaws == 0 ||GridColumns == 0 )
     { 
         PrintMsg(" Введены неправильные данные");
         return ;
     }
           if(elementList.Count == 0 && canGenerate)
        {
            canGenerate = false;
            for(int i =0; i<  GridRaws; i++)
          {
            for (int j= 0; j<  GridColumns; j++)
            {
                
               Add(currentFabric.GetPoolObject());
               
            }
          }
        AttachToGrid();
        canGenerate = true;
         if( warning.IsActive()) warning.gameObject.SetActive(false);
        }

        else
        {
            canGenerate = false;
            while (elementList.Count>0)
            {
                var item = elementList[0];
                item.ElementTransform.sizeDelta = new Vector2 (100,100);
                item.ElementTransform.anchoredPosition = new Vector2 (-100, -100);
                item.ElementTransform.SetParent(null);
                currentFabric.ReturnOnjectToPool(item);
                elementList.Remove(item);
            }
            canGenerate = true;
            GenerateGrid ();
             if( warning.IsActive()) warning.gameObject.SetActive(false);
        }
     
      
        
    }
    
    public void AttachToGrid()
    {
        gridAlignment.AlignmentToGrid();
    }
    public void Shuffle()
    {
        if(elementList.Count>0)
        {
            if( warning.IsActive()) warning.gameObject.SetActive(false);
            currentShuffler.ShuffleNet(elementList);
        }
        else
        {
            PrintMsg("Отсутсвуют элементы");
        }
       
    }

    private void PrintMsg( string msg)
    {
        warning.text = msg;
        warning.gameObject.SetActive(true);
        
    }

    

    public void Add(GridElementMain elemnt)
    {
        if(!elementList.Contains(elemnt))

      { 
           elementList.Add(elemnt);
           elemnt.transform.SetParent(this.transform as RectTransform);
      }
    }
   
 public void SetXCount(string numb)
    {
        if(string.IsNullOrEmpty(numb) || numb == "0")
        {
            
            return;
        }
        int.TryParse(numb, out gridColumns);
       
    }
    public void SetYCount(string numb)
    {
        if(string.IsNullOrEmpty(numb) || numb == "0") 
        {
            
            return;
        }
        int.TryParse(numb, out gridRaws);
        
    }

    
}
