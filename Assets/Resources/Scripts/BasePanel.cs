using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour {

    public GameObject forScale;
    public void Awake()
    {
        forScale.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void Start()
    {
        init();
        forScale.transform.DOScale(1, 2f).SetEase(Ease.OutBack);
    }

    public virtual void init() {

    }

    public void close()
    {
        forScale.transform.DOScale(0.5f, 1f).OnComplete(() => {
            GameObject.Destroy(this.gameObject);
        });
    }
}
