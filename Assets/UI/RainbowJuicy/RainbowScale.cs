using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RainbowScale : MonoBehaviour
{
    int index = -1;
    public float time = .2f;
    public Vector3[] scales;
    public Ease easeType;
    public bool stopTween;
    //public int numberScales;
    int stopScales;

    public float DelayDisable;
    public bool ResetScaleOnDisabled;

    
    void OnEnable()
    {
        stopScales = scales.Length;

        Next();

        if(DelayDisable > 0){
            DOVirtual.DelayedCall(DelayDisable,()=>{
                this.enabled = false;
            });
        }

        
    }

    void Next()
    {
        

        if(stopTween && index + 1 == stopScales)
        {
            transform.DOScale(scales[0],0);
            index = 0;
            index = (index + 1) % scales.Length;
        }
        else
        {
            index = (index + 1) % scales.Length;
        }


        transform.DOScale(scales[index], time).SetEase(easeType).OnComplete(() => {
            Next();
        });
    }

    void OnDisable()
    {
        transform.DOKill(true);
        index = 0;
        if (ResetScaleOnDisabled)
            transform.DOScale(Vector3.one, 0);
    }
}
