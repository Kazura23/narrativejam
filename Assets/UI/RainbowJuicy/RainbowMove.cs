using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RainbowMove : MonoBehaviour
{
    public enum Type{
        LocalVertical,
        LocalHorizontal,
        GlobalVertical,
        GlobalHorizontal
    }

    public enum Mode{
        Addition,
        Direct
    }

    int index = -1;
    public float time = .2f;
    public Type movesType;
    public Mode movesMode;
    public float[] moves;
    public Ease easeType;

    private float LocalY;
    public bool stopTween;
    public int numberMoves;
    int stopMoves;

    void OnEnable()
    {
        stopMoves = moves.Length;
        
        Next();
        //index = -1;
        //transform.DOMoveY(LocalY, 0);
        //Debug.Log(LocalY);
    }

    void Next()
    {
        if(stopTween && stopMoves == numberMoves)
        {
            if(movesType == Type.LocalHorizontal)
                transform.DOLocalMoveX(moves[0],0);

            if(movesType == Type.LocalVertical)
                transform.DOLocalMoveY(moves[0],0);

            if(movesType == Type.GlobalHorizontal)
                transform.DOMoveX(moves[0],0);

            if(movesType == Type.GlobalVertical)
                transform.DOMoveY(moves[0],0);

            index = 0;
            index = (index + 1) % moves.Length;
        }
        else
        {
            index = (index + 1) % moves.Length;
        }

        if (movesType == Type.LocalHorizontal){
            if(movesMode == Mode.Addition)
                transform.DOLocalMoveX(transform.localPosition.x + moves[index], time).SetEase(easeType).OnComplete(() => Next());
            if(movesMode == Mode.Direct)
                transform.DOLocalMoveX(moves[index], time).SetEase(easeType).OnComplete(() => Next());   
        } 
        
        if (movesType == Type.LocalVertical){
            if(movesMode == Mode.Addition)
                transform.DOLocalMoveY(transform.localPosition.y + moves[index], time).SetEase(easeType).OnComplete(() => Next());
            if(movesMode == Mode.Direct)
                transform.DOLocalMoveY(moves[index], time).SetEase(easeType).OnComplete(() => Next());
        }
            

        if (movesType == Type.GlobalHorizontal){
            if(movesMode == Mode.Addition)
                transform.DOMoveX(transform.position.x + moves[index], time).SetEase(easeType).OnComplete(() => Next());
            if(movesMode == Mode.Direct)
                transform.DOMoveX(moves[index], time).SetEase(easeType).OnComplete(() => Next());
        }
            

        if (movesType == Type.GlobalVertical){
            if(movesMode == Mode.Addition)
                transform.DOMoveY(transform.position.y + moves[index], time).SetEase(easeType).OnComplete(() => Next());
            if(movesMode == Mode.Direct)
                transform.DOMoveY(moves[index], time).SetEase(easeType).OnComplete(() => Next());
        }
    }

    void OnDisable()
    {
        if (movesType == Type.LocalHorizontal)
            transform.DOKill();
            //transform.DOLocalMoveX(moves[index], time).SetEase(easeType).OnComplete(() => Next());

        if (movesType == Type.LocalVertical)
        {
            transform.DOKill();
        }

        if (movesType == Type.GlobalHorizontal)
            transform.DOKill();
            //transform.DOMoveX(moves[index], time).SetEase(easeType).OnComplete(() => Next());

        if (movesType == Type.GlobalVertical)
            transform.DOKill();
            //transform.DOMoveY(moves[index], time).SetEase(easeType).OnComplete(() => Next());

    }
}