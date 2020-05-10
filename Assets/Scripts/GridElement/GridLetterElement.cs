using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EasyTween))]
public class GridLetterElement : GridElementMain
{
    public override Vector2 Possition { get ; set; }
    Vector2 startposition;
    [SerializeField ] private Text currentTextElement;
    EasyTween animator;
    [SerializeField]
    AnimationCurve startCurve;
    [SerializeField]
    AnimationCurve endCurve;
    
    bool isMovind;

    public char CurrentLetter {get; private set;}

    protected override void Awake() 
    {
        base.Awake();
        CurrentLetter = (char)Random.Range(65, 90);
        currentTextElement.text = CurrentLetter.ToString();
        animator = GetComponent<EasyTween>();
    }
    public void StartMovement( Vector2 targetPoint)
    {
        if(!isMovind)
        {
           isMovind = true;
          startposition = ElementTransform.anchoredPosition;
          animator.SetAnimationPosition(startposition,targetPoint, startCurve,endCurve);
          animator.OpenCloseObjectAnimation();
                   
          
        }
    }
    
    public void EndMove()
    {
        isMovind = false;
    }
}
