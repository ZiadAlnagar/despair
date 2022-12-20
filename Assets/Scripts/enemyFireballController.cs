using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class enemyFireballController : MonoBehaviour
{

    public float speed;
    private EnemyController enemy;
    // Use this for initialization
    void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
        if (enemy.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(enemy.fireballDamage);
        }
        Destroy(gameObject, 1.5f);
    }
}
*/