using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlurEffect : MonoBehaviour {

    public float duration;
    [HideInInspector]
    public Image image;
    public Canvas canvas;
    float Timer;
    Material matBlur;
    // Use this for initialization
    void Start () {

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        image = transform.GetComponent<Image>();

        matBlur = Instantiate(image.material);

        matBlur.SetFloat("_Size", 3f);

        image.material = matBlur;

        DOTween.To(() => Timer, x => Timer = x, 5, 1).SetOptions(false).OnComplete(()=> {
            DOTween.To(() => Timer, x => Timer = x, 0, 1).SetOptions(false).OnComplete(()=> {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.renderMode = RenderMode.WorldSpace;
            });
        });

        //StartCoroutine("StartTimer");
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            Timer += Time.deltaTime;
            Debug.Log("Time");
            matBlur.SetFloat("_Size", Timer);
            image.material = matBlur;
        }

        yield return null;

    }
	
	// Update is called once per frame
	void Update () {

        matBlur.SetFloat("_Size", Timer);

        image.material = matBlur;

        /*
        if (Input.GetKeyDown(KeyCode.A)){
            StartTimer();
        }
        */
    }
}
