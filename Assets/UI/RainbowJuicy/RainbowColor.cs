using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RainbowColor : MonoBehaviour
{
    public enum Type
    {
        Image,
        Material,
        Sprite,
        Text,
    }

	int index = -1;
	public float time = .2f;
	public Color[] colors = new Color[]{ Color.red, Color.yellow, Color.green, Color.blue, Color.cyan };
    // Use this for initialization
    //public string rainbowType = "Image";
    public Type ComponentType;
    public bool KeepOriginalColorOnKill;
    public Color OriginalColor;

    public float DelayDisable;

    

    public bool stopTween;
   // public int numberColors;
    int stopColors;



    void OnEnable ()
	{
        stopColors = colors.Length;

        if(ComponentType == Type.Image)
                OriginalColor = GetComponent<Image>().color;

        if (ComponentType == Type.Material)
                OriginalColor = GetComponentInChildren<Renderer>().material.color;

        if (ComponentType == Type.Sprite)
                OriginalColor = GetComponent<SpriteRenderer>().color;


        if (ComponentType == Type.Text)
                OriginalColor = GetComponent<Text>().color;

        index = -1;
        GetComponent<Image>().DOKill(true);
        Next ();

        if(DelayDisable > 0){
            DOVirtual.DelayedCall(DelayDisable,()=>{
                this.enabled = false;
            });
        }
	}

	void Next ()
	{
        if(stopTween && index + 1 == stopColors)
        {
            if(ComponentType == Type.Image){
                GetComponent<Image> ().DOColor (colors [0], 0);
            }

            if(ComponentType == Type.Material){
                GetComponent<Renderer> ().material.DOColor (colors [0], 0);
            }

            if (ComponentType == Type.Sprite){
                GetComponent<SpriteRenderer>().DOColor(colors[0], 0);
            }

            if (ComponentType == Type.Text){
                GetComponent<Text>().DOColor(colors[0], 0);
            }
            
            index = 0;
            index = (index + 1) % colors.Length;
        }
        else
        {
            index = (index + 1) % colors.Length;
        }

		

        if(ComponentType == Type.Image){

            if(KeepOriginalColorOnKill){
                OriginalColor = GetComponent<Image>().color;
                KeepOriginalColorOnKill = false;
            }

		    GetComponent<Image> ().DOColor (colors [index], time).OnComplete(() => Next());
        }

        if (ComponentType == Type.Material)
        {

            if(KeepOriginalColorOnKill){
                OriginalColor = GetComponentInChildren<Renderer>().material.color;
                KeepOriginalColorOnKill = false;
            }

            GetComponentInChildren<Renderer>().material.DOColor(colors[index], time).OnComplete(() => Next());
        }

        if (ComponentType == Type.Sprite){

            if(KeepOriginalColorOnKill){
                OriginalColor = GetComponent<SpriteRenderer>().color;
                KeepOriginalColorOnKill = false;
            }

            GetComponent<SpriteRenderer>().DOColor(colors[index], time).OnComplete(() => Next());
        }


        if (ComponentType == Type.Text){

            if(KeepOriginalColorOnKill){
                OriginalColor = GetComponent<Text>().color;
                KeepOriginalColorOnKill = false;
            }
            
            GetComponent<Text>().DOColor(colors[index], time).OnComplete(() => Next());
        }
    }

    void OnDisable ()
	{
        if (ComponentType == Type.Image) { 
            GetComponent<Image> ().DOKill (true);
            if(OriginalColor != null)
                GetComponent<Image> ().DOColor (OriginalColor, time * 2f);
            else
                GetComponent<Image>().DOColor(Color.white, time * 2f);
            
        }

        if (ComponentType == Type.Material)
        {
            GetComponent<Material>().DOKill(true);
            GetComponent<Material>().DOColor(Color.white, time * 2f);
        }

        if (ComponentType == Type.Sprite)
        {
            GetComponent<SpriteRenderer>().DOKill(true);
            GetComponent<SpriteRenderer>().DOColor(Color.white, time * 2f);
        }

        if (ComponentType == Type.Text)
        {
            GetComponent<Text>().DOKill(true);
            if(OriginalColor != null)
                GetComponent<Text> ().DOColor (OriginalColor, time * 2f);
            else
                GetComponent<Text>().DOColor(Color.white, time * 2f);
        }

        
    }
}
