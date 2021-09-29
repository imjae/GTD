//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseMana (float Mana);
// HealthSystem.Instance.RestoreMana (float Mana);
// Attach to the Hero.
//==============================================================

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

	//==============================================================
	// Regenerate Health & Mana
	//==============================================================

	public float hitPoint = 0.0f;
	public float maxHitPoint = 0.0f;

	public bool Regenerate = true;
	public float regen = 0.1f;

	public bool isDecrease = true;
	public float decreaseHealth = 0.1f;

	private float timeleft = 0.0f;  // Left time for current interval
	
	public float regenUpdateInterval = 1f;

	public bool GodMode;

	private GameObject realObject;


	//==============================================================
	// Awake
	//==============================================================
  	void Start()
	{
		realObject = transform.parent.parent.gameObject;
		float hp = realObject.GetComponent<Monster>().hp;
		this.hitPoint = hp;
		this.maxHitPoint = hp;

		UpdateGraphics();
		timeleft = regenUpdateInterval;
	}

	//==============================================================
	// Update
	//==============================================================
	void Update ()
	{
		if (Regenerate)
			Regen();
		if (isDecrease)
			Decrease();

	}

	//==============================================================
	// Regenerate Health & Mana
	//==============================================================
	private void Regen()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
		{
			// Debug mode
			if (GodMode)
			{
				HealDamage(maxHitPoint);
			}
			else
			{
				HealDamage(regen);			
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	//==============================================================
	// Decrease Health
	// =====================================
	private void Decrease()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
		{
			// Debug mode
			if (!GodMode)
			{
				TakeDamage(decreaseHealth);
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	//==============================================================
	// Health Logic
	//==============================================================
	private void UpdateHealthBar()
	{
		transform.localScale = new Vector3(hitPoint/100f, 1, 1);
	}


	public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
		{
			hitPoint = 0;

		}

		UpdateGraphics();
	}

	public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}


	//==============================================================
	// Update all Bars & Globes UI graphics
	//==============================================================
	private void UpdateGraphics()
	{
		UpdateHealthBar();
	}
}
