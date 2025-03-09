using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t;
    public int i;

    private Vector3 InitialPosition;

    void Start()
    {
        InitialPosition = new Vector3(-2.029f, 2.21f, 0.078f);
        i = 0;
        Debug.Log("Hello " + i);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello " + i + " " + t.position.y);
    }

    void ResetBall()
    {

    }
}
