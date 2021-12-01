using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public AudioSource source;

  void DestroyObject()
    {
        source.Play();
        Destroy(gameObject);
    }
}
