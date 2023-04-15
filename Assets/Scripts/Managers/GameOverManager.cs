using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5.0f;

    [SerializeField] TMP_Text TimeText;

    Animator anim;
    float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        anim.SetTrigger("GameOver");

        restartDelay -= Time.deltaTime;
        TimeText.text = "Time: " + restartDelay.ToString("F2");
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (restartDelay <= 0)
        {
            SceneManager.LoadScene("NewMainMenu");
            State.Instance.Reset();
        }
    }
}