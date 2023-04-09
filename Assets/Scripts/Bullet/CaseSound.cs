using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSound : MonoBehaviour
{
    public List<AudioSource> caseSounds;

    private void OnCollisionEnter2D()
    {
        caseSounds[Random.Range(0, caseSounds.Count)].Play();
    }
}
