using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAnim_Scale : MonoBehaviour {

	public float scaleValue;
	public float duration;
	public float delay;
	public Ease ease;
	public bool multipleClick;
	bool isClicked = false;

	public void ScaleMove(){

		isClicked = true;

		if(multipleClick){
			isClicked = true;
			StartScaleMove();
		}

		if(!multipleClick && !isClicked){
			isClicked = true;
			StartScaleMove();
		}
	}

	void StartScaleMove(){
		DOVirtual.DelayedCall(delay, ()=>{

			transform.DOScale(transform.localScale * scaleValue, duration).SetEase(ease).OnComplete(()=>{

				isClicked = false;
			});
		});
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
