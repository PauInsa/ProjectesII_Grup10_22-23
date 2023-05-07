using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearUI : MonoBehaviour
{
    public List<SpriteRenderer> UI;
    public float appearingTime;

    float triggeredTime = 0.0f;
    bool triggered = false;
    bool appeared = false;

    private void Update()
    {

        if (triggered && !appeared)
            Appear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            triggered = true;
            triggeredTime = Time.time;
        }
        
    }

    void Appear()
    {
        Color color;
        float alpha = (Time.time - triggeredTime) / appearingTime;
        if (alpha >= 1.0f)
            appeared = true;
        color = new Color(1.0f, 1.0f, 1.0f, alpha);
        for (int i = 0; i < UI.Count; i++)
            UI[i].color = color;
    }
}
