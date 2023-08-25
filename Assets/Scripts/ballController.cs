using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    //private SceneController managerBall;
    public BarController gameBar;
    private bool isStartGame;
    private Vector3 ballAndBarDistance;
    void Start()
    {
        ballAndBarDistance = this.transform.position - gameBar.transform.position;
    }
    void Update()
    {
        if (!isStartGame)
        {
            this.transform.position = gameBar.transform.position + ballAndBarDistance;
            if (Input.GetMouseButtonDown(0))
            {
                isStartGame = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(3f, 9f, 0f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tinyDeviation = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f));
        //Debug.Log(tinyDeviation);
        if (isStartGame)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tinyDeviation;
        }
    }
}