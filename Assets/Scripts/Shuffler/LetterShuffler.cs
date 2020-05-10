using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterShuffler : ShufflerMain
{

   
    public override void ShuffleNet(List<GridElementMain> listToShaffle)
    {
       UniqueIntGenerator randomizer = new UniqueIntGenerator( 0, (listToShaffle.Count));
       Vector2 targetPosition ;
        for(int i = 0; i <listToShaffle.Count; i++ )
        {
            int? index = randomizer.GetRandomeValue(i);
            if(index != null)
            {
                targetPosition = listToShaffle[(int)index ].ElementTransform.anchoredPosition;
            }
            else
            {
                targetPosition = listToShaffle[i].ElementTransform.anchoredPosition;
            }
            
           if(listToShaffle[i] is GridLetterElement item)
           {
               item.StartMovement(targetPosition);
           }
        }
    }
}
