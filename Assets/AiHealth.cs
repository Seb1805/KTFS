using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;

    Ragdoll ragdoll;

    public float blinkIntensity;
    public float blinkDuration;
    public float blinkTimer;

    SkinnedMeshRenderer skinnedMeshRenderer;

    UiHealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<UiHealthBar>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            Hitbox hitbox = rigidbody.gameObject.AddComponent<Hitbox>();
            hitbox.health = this;
        }
    }


    //TODO: Make interface
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealthPercentage(currentHealth / maxHealth);
        if (currentHealth <= 0.0f)
        {
            Die();
        }

        blinkTimer = blinkDuration;
    }

    private void Die()
    {
        ragdoll.ActivateRagdoll();
        AiBaseScript ai = GetComponentInParent<AiBaseScript>();
        //TODO: Handle correctly
        ai.isDead = true;
        healthBar.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;
    }
}
