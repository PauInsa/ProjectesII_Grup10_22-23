using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearUI : MonoBehaviour
{
    public List<SpriteRenderer> UI;
    public float appearingTime;

    float triggeredTime = 0.0f;
    bool triggered = false;

    private void Update()
    {

        if (triggered)
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
        color = new Color(1.0f, 1.0f, 1.0f, alpha);
        for (int i = 0; i < UI.Count; i++)
            UI[i].color = color;
    }
}
