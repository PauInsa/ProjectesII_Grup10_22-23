using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    public string scene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Gun"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
