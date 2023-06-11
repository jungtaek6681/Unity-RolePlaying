using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactor : MonoBehaviour, IListenable
{
    public void Listen(AudioSource source)
    {
        transform.LookAt(source.transform.position);
    }
}
