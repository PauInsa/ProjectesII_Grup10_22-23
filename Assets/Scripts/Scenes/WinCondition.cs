using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject victory;
    public GameObject defeat;

    public PauseMenu pause;

    public HumanManager humans;
    public Spawner enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (humans.ended)
        {
            EndGameplay(false);
        }

        if (enemies.ended)
        {
            EndGameplay(true);
        }
    }

    public void EndGameplay(bool win)
    {
        pause.ableToPause = false;
        pause.PauseGame();

        if (win)
            victory.SetActive(true);
        else
            defeat.SetActive(true);
    }
}
