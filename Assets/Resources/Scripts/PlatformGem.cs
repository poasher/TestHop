using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGem : Platform {

    public SpriteRenderer gem;

    public override void Collision()
    {
        base.Collision();
        gem.transform.DOScale(0, 0.3f);
    }

}
