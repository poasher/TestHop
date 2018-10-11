using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloaderManager : MonoBehaviour {



    public void loadGameScene() {
        SceneManager.LoadSceneAsync("Game");
    }


    public void showOptions()
    {
        Instantiate(Resources.Load("Prefabs/OptionsPanel"), GameObject.Find("Canvas").transform);
    }

}
