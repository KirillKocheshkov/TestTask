using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UniqueIntGenerator :  IRandomizer<int>
{

    private List<int> currentList;
    int maxValue;
    int minValue;

    public UniqueIntGenerator (int minValue ,int maxValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
        FillTheList();
    }
    public int GetRandomeValue()
    {
        if(currentList.Count> 0)
        {
            int value = currentList[0];
            currentList.Remove(0);
            return value;
        }
        return 0;
    }
    // суть метода выдвать уникальное значение, не совпадающие с текушим. если же значение совпадает с текущем, и у него не выходит взядть другой элемент
    // то возвращает null, тк если бы она возвращало 0 , то это значение могло бы уже быть возвращено и оно не было бы уникальным.
    public int? GetRandomeValue(int currentValue)
    {
        if(currentList.Count> 0)
        {
            int value = currentList[0];
            if(value != currentValue)
            {
                currentList.RemoveAt(0);
                return value;
            }
            else 
            {
                if(currentList.Count>1)
                {
                  value = currentList[1] ;
                currentList.RemoveAt(1);
                return value;
                }
                return null;
            }
            
        }
       return null;
    }

    private void FillTheList()
    {
       currentList = new List<int>();
       while(currentList.Count< (Mathf.Abs(maxValue - minValue)))
     {
          var currentNumber = Random.Range(minValue,maxValue);
           if(!currentList.Contains(currentNumber))
       {
           currentList.Add(currentNumber);

       }
     }
    }
}
