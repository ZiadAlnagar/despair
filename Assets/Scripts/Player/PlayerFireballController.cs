using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballController : MonoBehaviour
{
    private float TimeSinceFireballCast = 0.0f;
    public float speed;
    private Player player;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();

        if (player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        TimeSinceFireballCast += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //while (TimeSinceFireballCast < 1.5f)
        //{
           
            if (other.tag == "Enemy")
            {
                FindObjectOfType<EnemyStats>().enemyTakeDamage(player.FireballDamage);
                anim.SetTrigger("Explode");
                Destroy(gameObject);
        }
            if (other.tag == "HittableObject")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        Destroy(gameObject, 1.5f);
    }
}
