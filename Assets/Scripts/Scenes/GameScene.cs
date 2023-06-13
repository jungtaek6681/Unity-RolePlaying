using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("GameScene Init");
    }

    private void OnDestroy()
    {
        Debug.Log("GameScene Release");
    }
}
