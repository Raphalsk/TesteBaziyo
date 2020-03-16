using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelComplete : MonoBehaviour
{

    public Text levelComplete;

    void Start()
    {

        levelComplete.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "baziyo")
        {
            levelComplete.enabled = true;
        }
    }
}
