using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball: MonoBehaviour {

    private bool isDrag;
    public Rigidbody ri;
    private float offsetX;
    public int countCollider;
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = this.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.IndexOf("Cube")>=0){
            if(collision.gameObject.name.IndexOf("Gem")>=0)
            {
                GameController.Instance.GemCollect();
            }
            countCollider++;
            if (transform.position.z > countCollider * 2)
            {
                ri.velocity = new Vector3(0, 5, 1.95f);
            }
            else
            {
                ri.velocity = new Vector3(0, 5, 2f);
            }


            GameController.Instance.completePlatform();
        }
    }

    void FixedUpdate()
    {
        if (GameController.Instance.state == State.gameOver)
            return;

        if (transform.position.y < -10)
        {
            GameController.Instance.gameOver();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameController.Instance.startGame();
            ri.isKinematic = false;

            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            Vector3 pressPos = Camera.main.ScreenToWorldPoint(mousePosition);
            offsetX = Mathf.Abs(pressPos.x - transform.position.x);
            isDrag = true;
        }

        if (isDrag)
        {
            var mousePositionScreen = Input.mousePosition;
            mousePositionScreen.z = 10;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePositionScreen);
            Vector3 temp = transform.position;
            float position = 0;

            if (mousePosition.x >= transform.position.x)
                position = mousePosition.x - offsetX;
            else
                position = offsetX + mousePosition.x;

            temp.x = position;
            transform.position = Vector3.Lerp(transform.position, temp, 1f);
        }
    }

    public void reset()
    {
        countCollider = 0;
        transform.position = startPosition;
        ri.isKinematic = true;
    }
}
