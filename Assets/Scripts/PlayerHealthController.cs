﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //talks to UIControllerScript
    public static PlayerHealthController instance;
    public int currentHealth;
    public int maxHealth;
    public float damagedInvincibleLength = 1f;
    private float invincCointer;

    public Animator anim;
    

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        /*UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (invincCointer > 0)
        {
            invincCointer-= Time.deltaTime;
            if(invincCointer <= 0)
            {
                for (int i = 0; i < PlayerController.instance.bonySR.Length; i++)
                {
                    PlayerController.instance.bonySR[i].color = new Color(PlayerController.instance.bonySR[i].color.r, PlayerController.instance.bonySR[i].color.g, PlayerController.instance.bonySR[i].color.b, 1f);// or (1, 1, 1, 1f)
                }
            }
        }
    }
    public void DamagePlayer()
    {
       
        if (invincCointer <= 0)
        {
            currentHealth--;

            invincCointer = damagedInvincibleLength;

            AudioManager.instance.Playsfx(2);

            CameraShake.Instance.ShakeCamera(2f, .5f);

            for (int i = 0; i < PlayerController.instance.bonySR.Length; i++)
            {
                PlayerController.instance.bonySR[i].color = new Color(PlayerController.instance.bonySR[i].color.r, PlayerController.instance.bonySR[i].color.g, PlayerController.instance.bonySR[i].color.b, 0.5f);// or (1, 1, 1, 1f)
            }
            if (currentHealth <= 0)
            {
                anim.SetBool("isDead", true);
                StartCoroutine(deadSequence());
                
            }
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
        
    }

    
    public IEnumerator deadSequence()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerController.instance.gameObject.SetActive(false);
        UIController.instance.deathScreen.SetActive(true);
        AudioManager.instance.playGameOver();
    }
}
