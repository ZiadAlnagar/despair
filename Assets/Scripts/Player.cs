using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    //Key Bendings
    public KeyCode Up;
    public KeyCode L;
    public KeyCode R;
    public KeyCode Run;
    public KeyCode Interact;
    public KeyCode PrimaryAttack;
    public KeyCode FireballShoot;
    public KeyCode Barrier;
    public KeyCode Heal;
    public KeyCode Inventory;

    //Movement
    private float Move;
    bool isFacingRight;
    public float moveSpeed;
    public float RunSpeed;

    //Jumping
    private bool grounded;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //Basic Attack
    private float NextbasicAttack = 0;
    public float BasicAttackCD = 0.3f;
    private int CurrentAttack = 0;
    private float TimeSinceAttack = 0.0f;
    public int BasicAttackDamage = 3;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask AttackTargets;

    //Fireball
    private float NextFireball = 0;
    private bool FireballIsCooldown = false;
    public float FireballCD = 2f;
    private float FireballCDTxt;
    public int FireballDamage;
    public Transform FirePoint;
    public GameObject Fireball;
    public Collider2D[] result;

    //Barrier
    private float NextBarrier = 0;
    private bool BarrierIsCooldown = false;
    private float BarrierDuration = 1f;
    private float NextBarrierDuration = 0;
    public float BarrierCD = 2f;
    private float BarrierCDTxt;
    private bool BarrierActive;
    public GameObject BarrierObject;

    //Healing
    private float NextHeal = 0;
    private bool HealIsCooldown = false;
    public float HealCD = 2f;
    private float HealCDTxt;
    public int HealAmount;
    public GameObject HealEffectObj;

    //UI - Abilities CD
    public Image FireballCDBorder;
    public TMP_Text FireballTextCD;
    public Image BarrierCDBorder;
    public TMP_Text BarrierTextCD;
    public Image HealCDBorder;
    public TMP_Text HealTextCD;

    private Animator anim;
    private Animator FireBallCloneAnim;
    private GameObject FireballClone;
    private GameObject InventoryUI;

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    // Use this for initialization
    void Start()
    {
        FireballCDTxt = FireballCD;
        isFacingRight = true;
        anim = GetComponent<Animator>();
        //Fireball = GameObject.Find("Fireball(Clone)");
        //FireballAnim = Fireball.GetComponent<Animator>();
        InventoryUI = GameObject.Find("Inventory");
        InventoryUI.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        FireballClone = GameObject.Find("Fireball(Clone)");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (FireballClone != null)
            FireBallCloneAnim = FireballClone.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceAttack += Time.deltaTime;

        Move = moveSpeed;

        HealEffectObj.GetComponent<Animator>().SetBool("Heal", false);
        //FireballCDBorder.fillAmount = Mathf.RoundToInt(CooldownTimer);

        if (Input.GetKeyDown(Up) && grounded)
        {
            Jump();
        }
        anim.SetBool("Grounded", grounded);

        if (Input.GetKey(Run))
        {
            Move = RunSpeed;
        }

        if (Input.GetKeyDown(Inventory))
        {
            InventoryUI.gameObject.active = !(InventoryUI.gameObject.active);
        }

        if (FireballIsCooldown)
        {
            FireballCDTxt -= Time.deltaTime;
            FireballCDBorder.fillAmount -= 1 / FireballCD * Time.deltaTime;
            FireballTextCD.text = Mathf.RoundToInt(FireballCDTxt).ToString();
            if (FireballCDBorder.fillAmount <= 0)
            {
                FireballCDBorder.fillAmount = 0;
                FireballCDTxt = FireballCD;
                FireballTextCD.gameObject.SetActive(false);
                FireballIsCooldown = false;
            }
        }

        if (BarrierIsCooldown)
        {
            BarrierCDTxt -= Time.deltaTime;
            BarrierCDBorder.fillAmount -= 1 / FireballCD * Time.deltaTime;
            BarrierTextCD.text = Mathf.RoundToInt(FireballCDTxt).ToString();
            if (BarrierCDBorder.fillAmount <= 0)
            {
                BarrierCDBorder.fillAmount = 0;
                BarrierCDTxt = FireballCD;
                BarrierTextCD.gameObject.SetActive(false);
                BarrierIsCooldown = false;
            }
        }

        if (HealIsCooldown)
        {
            HealCDTxt -= Time.deltaTime;
            HealCDBorder.fillAmount -= 1 / HealCD * Time.deltaTime;
            HealTextCD.text = Mathf.RoundToInt(HealCDTxt).ToString();
            if (HealCDBorder.fillAmount <= 0)
            {
                HealCDBorder.fillAmount = 0;
                HealCDTxt = HealCD;
                HealTextCD.gameObject.SetActive(false);
                HealIsCooldown = false;
            }
        }

        if (Time.time >= NextBarrierDuration)
        {
            BarrierObject.SetActive(false);
            BarrierActive = false;
            NextBarrierDuration = Time.time + BarrierDuration;
        }

        //Attack
        else if (Input.GetKeyDown(PrimaryAttack))
        {
            NextbasicAttack = Time.time + BasicAttackCD;

            CurrentAttack++;

            if (CurrentAttack > 2)
                CurrentAttack = 1;

            if (TimeSinceAttack > 1.0f)
                CurrentAttack = 1;

            anim.SetTrigger("Attack" + CurrentAttack);
            Collider2D[] HitCollidables = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, AttackTargets);
            foreach (Collider2D hitable in HitCollidables)
            {
                if (hitable.tag == "Enemy")
                {
                    FindObjectOfType<EnemyStats>().enemyTakeDamage(BasicAttackDamage);
                }

                else if (hitable.tag == "HittableObject")
                {
                    Destroy(hitable.gameObject);
                }
            }

            TimeSinceAttack = 0.0f;
        }

        //Cast Fireball
        else if (Input.GetKeyDown(FireballShoot) && Time.time > NextFireball && FireballIsCooldown == false)
        {
            FireballIsCooldown = true;
            FireballTextCD.gameObject.SetActive(true);
            FireballTextCD.text = Mathf.RoundToInt(FireballCD).ToString();
            FireballCDBorder.fillAmount = 1;
            NextFireball = Time.time + FireballCD;
            FindObjectOfType<PlayerStats>().FireballSelfHurt();
            Instantiate(Fireball, FirePoint.position, FirePoint.rotation);
            //if(FireballClone != null)
            //FireBallCloneAnim.SetTrigger("Explode");            
        }

        //Cast Barrier
        else if (Input.GetKeyDown(Barrier) && Time.time > NextBarrier && BarrierIsCooldown == false)
        {
            BarrierIsCooldown = true;
            BarrierTextCD.gameObject.SetActive(true);
            BarrierTextCD.text = Mathf.RoundToInt(BarrierCD).ToString();
            BarrierCDBorder.fillAmount = 1;
            NextBarrier = Time.time + FireballCD;
            BarrierObject.SetActive(true);
            BarrierActive = true;
        }

        //Cast Heal
        else if (Input.GetKeyDown(Heal) && Time.time > NextHeal && HealIsCooldown == false)
        {
            HealIsCooldown = true;
            HealTextCD.gameObject.SetActive(true);
            HealTextCD.text = Mathf.RoundToInt(HealCD).ToString();
            HealCDBorder.fillAmount = 1;
            NextHeal = Time.time + HealCD;
            FindObjectOfType<PlayerStats>().Heal(HealAmount);
            HealEffectObj.GetComponent<Animator>().SetBool("Heal", true);
        }

        else if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Move, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }

        else if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Move, GetComponent<Rigidbody2D>().velocity.y);

            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    public bool BarrierIsActive
    {
        get
        {
            return BarrierActive;
        }
        set
        {
            BarrierActive = value;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
