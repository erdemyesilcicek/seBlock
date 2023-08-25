using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocks : MonoBehaviour
{
    public GameObject effect;
    public static int brokeBlockNumber = 0;
    public int hitNumber;
    bool isBroke;
    private SceneController sceneManager;
    public Sprite[] blockViews;
    void Start()
    {
        isBroke = (this.tag == "Broke");
        if (isBroke)
        {
            brokeBlockNumber++;
        }
        hitNumber = 0;
        sceneManager = GameObject.FindObjectOfType<SceneController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
        if (isBroke)
        {
            hitControl();
        }
    }
    public void hitControl()
    {
        int health;
        health = blockViews.Length + 1;
        hitNumber++;
        if (hitNumber >= health)
        {
            brokeBlockNumber--;
            EffectCreate();
            Destroy(gameObject);
            sceneManager.DestroyBlocks();
        }
        else
        {
            BlockViewChange();
        }
    }
    void EffectCreate()
    {
        GameObject myEffect = Instantiate(effect, gameObject.transform.position, Quaternion.identity) as GameObject;
        myEffect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    public void BlockViewChange()
    {
        this.GetComponent<SpriteRenderer>().sprite = blockViews[hitNumber - 1];
    }
    public void NextScene()
    {
        sceneManager.NextScene();
    }
}