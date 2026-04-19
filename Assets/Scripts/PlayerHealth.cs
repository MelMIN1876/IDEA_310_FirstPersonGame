using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public GameObject gameOverScreen;
    //private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void UpdateHealthUI()
    {
        healthText.text = currentHealth + " / " + maxHealth;
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // if (isDead)
        // {
        //     return;
        // }
        Debug.Log("Player took damage");
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Player died");
        //isDead = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
