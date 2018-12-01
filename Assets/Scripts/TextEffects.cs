using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour {

	public GameObject barObject;
	public float barFillDuration;
    public GameObject blurObject;
    //public Renderer blurRend;
    public Material m_Material;
    // Use this for initialization
    void Start () {

        m_Material.shader = Shader.Find("Custom/BLUR");
        Debug.Log(m_Material.shader);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlurScreen()
    {
        m_Material.SetFloat("_Size", 3);
    }

	public void CrossedText(GameObject objectToCross){

		GameObject bar = Instantiate(barObject, transform.position, Quaternion.identity, objectToCross.transform);

		Rect barRect = bar.transform.GetComponent<RectTransform>().rect; 
		barRect.width = objectToCross.transform.GetComponent<RectTransform>().rect.width * 2.5f;
		barRect.height = bar.transform.GetComponent<RectTransform>().rect.height;
		bar.transform.GetComponent<RectTransform>().sizeDelta = new Vector2( barRect.width, barRect.height);

		//Debug.Log(barRect.width);
		bar.transform.DOLocalMove(Vector3.zero,0);
		bar.transform.GetComponent<Image>().DOFillAmount(1,barFillDuration).SetEase(Ease.Linear);
	}

	public void RainbowColorActivated(GameObject objectRainbow){
			objectRainbow.transform.GetComponent<RainbowColor>().enabled = true;
	}

	public void RainbowColorDesactivated(GameObject objectRainbow){
			objectRainbow.transform.GetComponent<RainbowColor>().enabled = false;
	}

	public void RainbowRotateActivated(GameObject objectRotate){
			objectRotate.transform.GetComponent<RainbowRotate>().enabled = true;
	}

	public void RainbowRotateDesactivated(GameObject objectRotate){
			objectRotate.transform.GetComponent<RainbowRotate>().enabled = false;
	}

	public void RainbowScaleActivated(GameObject objectScale){
			objectScale.transform.GetComponent<RainbowScale>().enabled = true;
	}

	public void RainbowScaleDesactivated(GameObject objectScale){
			objectScale.transform.GetComponent<RainbowScale>().enabled = false;
	}

	public void RainbowMoveActivated(GameObject objectMove){
			objectMove.transform.GetComponent<RainbowMove>().enabled = true;
	}
	public void RainbowMoveDesactivated(GameObject objectMove){
			objectMove.transform.GetComponent<RainbowMove>().enabled = false;
	}
}
