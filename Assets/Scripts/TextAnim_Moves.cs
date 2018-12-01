using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAnim_Moves : MonoBehaviour {


	public enum TypeDirection {Up, Right, Down, Left};
	public float duration;
	public float delay;
	public Ease ease;
	public bool multipleClick;
	bool isClicked = false;

	[Header("DIRECTIONS MOVE")]
	public TypeDirection Direction = TypeDirection.Up;

	[Header("FREE MOVE")]
	public Vector2 FreePosition;


	public void MoveDirection(){

		if(multipleClick){

			isClicked = true;
			StartMoveDirection();
		} 

		if(!multipleClick && !isClicked){
			isClicked = true;
			StartMoveDirection();
		}
	}

	void StartMoveDirection(){

		DOVirtual.DelayedCall(delay, ()=>{

				if(Direction == TypeDirection.Up)
					transform.DOLocalMoveY(transform.localPosition.y + 350,duration).SetEase(ease).OnComplete(()=>{
						isClicked = false;
					});

				if(Direction == TypeDirection.Down)
					transform.DOLocalMoveY(transform.localPosition.y -350,duration).SetEase(ease).OnComplete(()=>{
						isClicked = false;
					});

				if(Direction == TypeDirection.Left)
					transform.DOLocalMoveX(transform.localPosition.x -750,duration).SetEase(ease).OnComplete(()=>{
						isClicked = false;
					});

				if(Direction == TypeDirection.Right)
					transform.DOLocalMoveX(transform.localPosition.x + 750,duration).SetEase(ease).OnComplete(()=>{
						isClicked = false;
					});
			});
	}
	public void MoveFree(){

		if(multipleClick){
			isClicked = true;
			StartMoveFree();
		}

		if(!multipleClick && !isClicked){
			isClicked = true;
			StartMoveFree();
		}
	}

	void StartMoveFree(){

			DOVirtual.DelayedCall(delay, ()=>{

				transform.DOLocalMove(new Vector2(transform.localPosition.x + FreePosition.x, transform.localPosition.y + FreePosition.y), duration).SetEase(ease).OnComplete(()=>{

					isClicked = false;
				});
			});
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(isClicked);
	}
}
