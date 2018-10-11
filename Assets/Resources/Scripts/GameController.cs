
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum State {
    load,
    play,
    gameOver
}
public class GameController : Singleton<GameController> {

    public static string RECORD = "record";
    public GameObject prefab;
    public GameObject prefabGem;
    public float offsetXmin = -0.2f;
    public float offsetXmax = 0.2f;
    private int countPlatrformStart = 5;
    public CameraController cameraController;
    public Ball ball;
    private int lastPosition = 2;
    private int count;
    private int countGem;
    public Text TextGemCount;
    public Text text;
    public State state;
    public Queue<GameObject> platforms;
    private int CountQueue = 8;
    private int record;
    public ParticleSystem particle;
    public void GemCollect()
    {
        countGem++;
        TextGemCount.text = countGem.ToString();
    }


    public int CurrentResult {
       get   { return count; }
    }
    public void Start()
    {
        record = PlayerPrefs.GetInt(RECORD);
        platforms = new Queue<GameObject>(CountQueue);
        createStartPlatforms();
    }

    public void createStartPlatforms() {
        for (int i = 0; i < countPlatrformStart; i++)
        {
            CreatePlatrform();
        }
    }


    public void CreatePlatrform()
    {
        GameObject platformObject = null;
        var rnd = Random.Range(0.0f, 1f);
        if (rnd < 0.2f)
        {
            platformObject = Instantiate(prefabGem, transform);
            
        }
        else
        {
            platformObject = Instantiate(prefab, transform);
        }
        lastPosition += 2;
        var position = new Vector3(Random.Range(offsetXmin, offsetXmax), 0, lastPosition);
        platformObject.transform.position = position;

        if (platforms.Count == CountQueue) {
           var platform = platforms.Dequeue();
           GameObject.Destroy(platform.gameObject);
        }

        platforms.Enqueue(platformObject);
    }

    public void completePlatform() {
        count++;

        if (count % 3 == 0)
        {
            var positionCamera = Camera.main.transform.position;
            var particlePosition = particle.transform.position;
            particlePosition.x = positionCamera.x;
            particlePosition.z = positionCamera.z + 4;
            particle.transform.position = particlePosition;
            particle.Play();
        }

        text.text = count.ToString();
        CreatePlatrform();
    }

    public void startGame() {
        if (state != State.play)
        {
            state = State.play;
        }
    }

    public void gameOver() {

        if (count > record)
        {
            PlayerPrefs.SetInt(RECORD,count);
            record = count;
        }

        state = State.gameOver;
        Instantiate(Resources.Load("Prefabs/GameOverPanel"), GameObject.Find("Canvas").transform);
    }

    public void restart() {
        cameraController.reset();
        ball.reset();
        state = State.load;
        count = 0;
        countGem = 0;
        TextGemCount.text = "0";
        text.text = "0";
        lastPosition = 2;
        resetPlatforms();

    }

    private void resetPlatforms()
    {
        while (platforms.Count > 0) {
            var platform = platforms.Dequeue();
            GameObject.Destroy(platform);
        }

        createStartPlatforms();
    }
}
