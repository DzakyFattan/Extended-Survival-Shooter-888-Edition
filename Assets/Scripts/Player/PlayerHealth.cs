using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour, IHealth
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public bool isNoDamageEnabled = false;

    // TODO: refactor to use PlayerAnimationController  
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;


    void Awake()
    {
        // TODO: refactor to use PlayerAnimationController
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        // if damage image is not null
        if (damageImage != null)
        {
            if (damaged)
            {
                damageImage.color = flashColour;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            damaged = false;
        }
    }


    public void TakeDamage(int amount)
    {
        if (!isNoDamageEnabled)
        {
            if (healthSlider != null)
            {
                damaged = true;

                currentHealth -= amount;

                healthSlider.value = currentHealth;

                playerAudio.Play();

                if (currentHealth <= 0 && !isDead)
                {
                    Death();
                }
            }
        }
    }

    public void Heal(int amount)
    {
        if (healthSlider != null)
        {
            currentHealth += amount;
            if (currentHealth > startingHealth)
            {
                currentHealth = startingHealth;
            }
            healthSlider.value = currentHealth;
        }
    }


    public void Death()
    {
        isDead = true;

        // TODO: refactor to use PlayerAnimationController
        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
    }
    // public void RestartLevel()
    // {
    //     SceneManager.LoadScene(0);
    // }

    public void SetNoDamage(bool value)
    {
        isNoDamageEnabled = value;
    }
}
