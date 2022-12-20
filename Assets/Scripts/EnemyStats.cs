using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : MonoBehaviour
{


    public int health = 6;
    private bool alive = true;
    private SpriteRenderer spriteRenderer;
    public GameObject enemy;


    void Start()
    {
        enemy.GetComponent<Animator>().SetBool("alive", true);
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void enemyTakeDamage(int damage)
    {
        this.health -= damage;
        if (health > 0)
        {
            alive = true;

        }
        else if (health == 0 || health < 0)
        {
            this.health = 0;
            alive = false;
            enemy.GetComponent<Animator>().SetBool("alive", alive);
            Destroy(this.gameObject, 0.533f);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }


}