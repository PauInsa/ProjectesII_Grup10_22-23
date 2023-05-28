using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    public Shoot shoot;
    public int level;

    public GameObject endMenu;
    public RankingManager rankingManager;

    void Start()
    {
        endMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Gun"))
        {
            rankingManager.EndLevel(level, Time.time, shoot.shotCount);
            endMenu.SetActive(true);
        }
    }
}
