using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public bool autoPlay = false;
    private ballController gameBall;
    void Start()
    {
        gameBall = GameObject.FindAnyObjectByType<ballController>();
    }
    void Update()
    {
        if (autoPlay)
        {
            AutoAction();
        }
        else
        {
            MouseAction();
        }
    }

    void MouseAction()
    {
        Vector3 barLocation = new Vector3(0f, this.transform.position.y, 0f);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        barLocation.x = Mathf.Clamp(mousePosition.x, -8f, 8f);
        transform.position = barLocation;
    }

    void AutoAction()
    {
        Vector3 barLocation = new Vector3(0f, this.transform.position.y, 0f);
        Vector3 ballLocation = gameBall.transform.position;
        barLocation.x = Mathf.Clamp(ballLocation.x, -8f, 8f);
        this.transform.position = barLocation;
    }
}