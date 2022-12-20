using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStats : MonoBehaviour
{
	//Health
	int PlayerHealth;
	public int Health = 6;
	public int NumberOfHearts;

	//Health UI
	public Image[] Hearts;
	public Sprite FullHeart;
	public Sprite EmptyHeart;

	//Lives
	public int Lives = 3;

	//Lives UI
	public TMP_Text LivesValue;

	public GameObject Player;

	private float flickerTIme = 0f;
	public float flickerDuration = 0.1f;

	private SpriteRenderer spriteRenderer;

	public bool isImmune = false;

	private float immunityTime = 0f;
	public float immunityDuration = 1.5f;

	private float DeathAfter = 0f;
	private float DeathDuration = 2f;

	private bool GameEnd = false;

	void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		PlayerHealth = Health;
	}

	void SpriteFlicker()
	{
		if (this.flickerTIme < this.flickerDuration)
		{
			this.flickerTIme += Time.deltaTime;
		}
		else if (this.flickerTIme >= this.flickerDuration)
		{
			spriteRenderer.enabled = !(spriteRenderer.enabled);
			this.flickerTIme = 0;
		}
	}

	private void ReduceHealth()
	{
		if (this.Health < 0)
		{
			this.Health = 0;
		}
		if (this.Lives > 0 && this.Health == 0)
		{
			FindObjectOfType<LevelManager>().RespawnPlayer();
			this.Health = PlayerHealth;
			this.Lives--;
		}
		else if (this.Lives == 0 && this.Health == 0)
		{
			Player.GetComponent<Animator>().SetTrigger("IsDead");
			Destroy(this.gameObject, 2f);
			DeathAfter = Time.time + DeathDuration;
		}
	}

	public void TakeDamage(int damage)
	{
		if (this.isImmune == false)
		{
			this.Health -= damage;
			ReduceHealth();

		}
		if (this.Health > 0)
		{
			PlayHitReaction();
		}
	}

	public void Heal(int HealAmount)
	{
		if ((this.Health += HealAmount) > PlayerHealth)
		{
			this.Health = PlayerHealth;
		}
		else
		{
			this.Health += HealAmount;
		}

	}

	public void UltimateDeath()
	{
		this.Health = 0;
		this.Lives = 0;
		ReduceHealth();
		GameEnd = true;
	}

	public void FireballSelfHurt()
	{
		this.Health -= 1;
		ReduceHealth();
	}

	void PlayHitReaction()
	{
		this.isImmune = true;
		this.immunityTime = 0f;
	}

	// Update is called once per frame
	void Update()
	{
		if (this.Lives == 0 && this.Health == 0 && Time.time > DeathAfter && !GameEnd)
		{
			(new NavigationController()).GoToEndScreen();
		}

		if (this.Lives == 0 && this.Health == 0 && Time.time > DeathAfter && GameEnd)
		{
			(new NavigationController()).GoToEndScreen();
		}

		if (Health > NumberOfHearts)
		{
			Health = NumberOfHearts;
		}

		LivesValue.text = Mathf.RoundToInt(Lives).ToString();

		//if(Lives > int.Parse(LivesValue.text))

		for (int i = 0; i < Hearts.Length; i++)
		{
			if (i < Health)
			{
				Hearts[i].sprite = FullHeart;
			}
			else
			{
				Hearts[i].sprite = EmptyHeart;
			}

			if (i < NumberOfHearts)
			{
				Hearts[i].enabled = true;
			}
			else
			{
				Hearts[i].enabled = false;
			}
		}
		if (this.isImmune)
		{
			SpriteFlicker();
			immunityTime += Time.deltaTime;
			if (immunityTime >= immunityDuration)
			{
				this.isImmune = false;
				this.spriteRenderer.enabled = true;
			}
		}



		//healthUI.value = health;
	}
}