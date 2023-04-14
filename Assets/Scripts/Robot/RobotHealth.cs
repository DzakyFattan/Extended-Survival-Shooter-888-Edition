using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class RobotHealth : MonoBehaviour, IHealth
{
    public int startingHealth = 100;
    public int currentHealth;

    bool isDead;                                                
    bool damaged;

    Animator anim;
    [SerializeField]
    Slider healthSlider;                                           
    AudioSource robotAudio;
    [SerializeField]
    AudioClip deathClip;

    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        robotAudio = GetComponent<AudioSource>();
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        float currentHealthFloat = currentHealth;
        float startingHealthFloat = startingHealth;

        robotAudio.Play();

        healthSlider.value = Mathf.RoundToInt((currentHealthFloat / startingHealthFloat) * 100);

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        //Animate death triggerring death animation
        anim.SetTrigger("Dead");

        // Remove pet from target list
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().RemoveTarget(gameObject);
            enemy.GetComponent<EnemyAttack>().RemoveTarget(gameObject);
        }

        robotAudio.clip = deathClip;
        robotAudio.Play();

        //Set body to dissapear
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5f);

        GameObject.Find("HUDCanvas").GetComponent<GameOverManager>().SetGameOver();
    }
    // public void RestartLevel()
    // {
    //     SceneManager.LoadScene(0);
    // }
}
