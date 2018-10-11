using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : BasePanel {

    public Text record;
    public Text current;
    public override void init()
    {
        base.init();
        current.text = GameController.Instance.CurrentResult.ToString();
        record.text = PlayerPrefs.GetInt(GameController.RECORD).ToString();
    }

    public void onLoadMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void restart() {
        GameController.Instance.restart();
        close();
    }


}
