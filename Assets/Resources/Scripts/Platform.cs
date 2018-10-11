using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Platform : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Collision();
    }

    virtual public void Collision()
    {
        transform.DOMoveY(-0.4f, 0.5f).SetLoops(2, LoopType.Yoyo);
    }
}
