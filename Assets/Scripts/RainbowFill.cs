using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RainbowFill : MonoBehaviour
{

    int index = -1;
    public float time = .2f;
    public float[] fillAmount;
    public Ease easeType;
	Image currT;

    public float DelayDisable;

	public void reStart()
	{
        transform.GetComponent<Image>().DOFillAmount(0,0);
		index = - 1;
	}

    void OnEnable()
    {
		currT = transform.GetComponent<Image>();
		//startRot = transform.localRotation;
        Next();
        //transform.DOMoveY(LocalY, 0);
        //Debug.Log("yo");

        if(DelayDisable > 0){
            DOVirtual.DelayedCall(DelayDisable,()=>{
                this.enabled = false;
            });
        }
    }

    void Next()
    {
        index = (index + 1) % fillAmount.Length;
	
		currT.DOFillAmount ( fillAmount [ index ], time).SetEase ( easeType ).OnComplete ( ( ) => Next ( ) );
	}

    void OnDisable()
    {
		currT.DOKill(true);

		//currT.localRotation = startRot;
    }
}