using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObj : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool updatedScore = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        updatedScore = false;
        rb2d.velocity = new Vector2(GameController.instance.scrollingSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(GameController.instance.scrollingSpeed, 0);
        }
    }
}
