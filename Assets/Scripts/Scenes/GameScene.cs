using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private void Awake()
    {
        Debug.Log("GameScene Init");
    }

    protected override IEnumerator LoadingRoutine()
    {
        Debug.Log("GameScene Load");
        // fake loading
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.2f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.4f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.6f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(0.2f);
        progress = 1.0f;
        Debug.Log("GameScene Loaded");
    }

    private void OnDestroy()
    {
        Debug.Log("GameScene Release");
    }
}
