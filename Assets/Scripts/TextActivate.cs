using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Activate(GameObject whichText){
		//whichText.transform.gameObject.SetActive(true);
		whichText.transform.GetComponent<CanvasGroup>().DOFade(1,.5f);
	}

	public void Desactivate(GameObject whichText){
		//whichText.transform.gameObject.SetActive(false);
		whichText.transform.GetComponent<CanvasGroup>().DOFade(0,.5f);
	}
}
