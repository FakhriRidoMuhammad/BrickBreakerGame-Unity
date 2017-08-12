using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private float MouseRelativePosX;
    private Ball ball;
    private Vector3 tempVector3;

    public bool isAutoPlay = false;

	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update () {
        if(isAutoPlay)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }
        
    }

    void AutoPlay()
    {
        tempVector3 = ball.transform.position;
        tempVector3.y = 0.5f;
        transform.position = tempVector3;
    }

    void MoveWithMouse()
    {
        MouseRelativePosX = Input.mousePosition.x / Screen.width * 16;
        MouseRelativePosX = Mathf.Clamp(MouseRelativePosX, 0.5f, 15.5f);
        Vector3 padPosition = new Vector3(MouseRelativePosX, this.transform.position.y, 0f);
        this.transform.position = padPosition;
    }
}
