using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public AudioClip flyClip;
    public AudioClip gameoverClip;
    
    private AudioSource audioSource;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource> ();
        audioSource.clip = flyClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                audioSource.Play();
            }
        }
    }

    void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        if (!GameController.instance.gameOver)
        {
            audioSource.clip = gameoverClip;
            audioSource.Play();
            GameController.instance.BirdDie();
        }
    }
}
