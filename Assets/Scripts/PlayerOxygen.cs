using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{

    public float maxOxygen = 100f;
    public float currentOxygen;
    public float oxygenDrainRate = 2.5f;
    public int healthDrainRate = 10;
    float damageTimer = 0f;
    public float damageInterval = 1f;
    private PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxOxygen = GameManager.instance.maxOxygen;
        currentOxygen = maxOxygen;
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentOxygen > 0)
        {
            currentOxygen -= oxygenDrainRate * Time.deltaTime;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
        }
        else
        {
            damageTimer += Time.deltaTime;
            if(playerHealth != null && damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(healthDrainRate);
                damageTimer = 0f;
            }
        }
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
    }

    public void Refill(float amount)
    {
        currentOxygen += amount;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
    }

    public float GetNormalized()
    {
        return currentOxygen / maxOxygen;
    }
}
