using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public float maxHealth;
    
    [HideInInspector]
    public float currentHealth;

    AiAgent agent;
    Ragdoll ragdoll;

    public float blinkIntensity;
    public float blinkDuration;
    public float blinkTimer;

    SkinnedMeshRenderer skinnedMeshRenderer;

    UiHealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AiAgent>();
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
    public void TakeDamage(float dmg, Vector3 direction)
    {

        //https://www.youtube.com/watch?v=oLT4k-lrnwg&list=PLyBYG1JGBcd009lc1ZfX9ZN5oVUW7AFVy&index=7 look at tutorial if we wanna apply force to the ragdool
        currentHealth -= dmg;
        healthBar.SetHealthPercentage(currentHealth / maxHealth);
        if (currentHealth <= 0.0f)
        {
            Die(direction);
        }

        blinkTimer = blinkDuration;
    }

    private void Die(Vector3 direction)
    {
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        deathState.direction = direction;
        agent.stateMachine.ChangeState(AiStateId.Death);
        //TODO: Handle correctly
        //AiBaseScript ai = GetComponentInParent<AiBaseScript>();
        //ai.isDead = true;

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
