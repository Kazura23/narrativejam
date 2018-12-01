using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour {

    public void ShakeLow()
    {
        transform.DOKill(true);

        transform.DOShakePosition(.2f, 1, 10, 90);
        //transform.DOShakeRotation(.2f, 1, 10, 90);
        transform.DOShakeScale(.2f, 3, 15, 90);
    }

    public void ShakeHigh()
    {
        transform.DOKill(true);

        transform.DOShakePosition(.4f, 3, 25, 90);
        //transform.DOShakeRotation(.2f, 1, 10, 90);
        transform.DOShakeScale(.4f, 3, 25, 90);
    }
}
