using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("TitleScene Init");
    }

    private void OnDestroy()
    {
        Debug.Log("TitleScene Release");
    }

    public void OnStartButton()
    {
        GameManager.Scene.LoadScene("GameScene");
    }
}
