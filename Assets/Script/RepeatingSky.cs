using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSky : MonoBehaviour
{
    private BoxCollider2D groundCollier;
    private float groundHorizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        groundCollier = GetComponent<BoxCollider2D> ();
        groundHorizontalLength = groundCollier.size.x;
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.x < -groundHorizontalLength)  
      {
          RepostitionBackground();
      }
    }
    private void RepostitionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
