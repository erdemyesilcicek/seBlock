using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static int LastGameScene { get; set; }
    public void NextScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene + 1);
    }
    public void BackScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene - 1);
    }
    public void LastScene()
    {
        SceneManager.LoadScene(LastGameScene);
    }
    public void PresentScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene);
    }
    public void toScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void toGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void toMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void DestroyBlocks()
    {
        if (Blocks.brokeBlockNumber <= 0)
        {
            NextScene();
        }
    }
}