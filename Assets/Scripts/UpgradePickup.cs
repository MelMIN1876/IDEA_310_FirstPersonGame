using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    public enum UpgradeType
    {
        Oxygen,
        Damage,
        Health
    }
    public UpgradeType upgradeType;
    public int amount = 25;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyUpgrade(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ApplyUpgrade(GameObject player)
    {
        switch (upgradeType)
        {
            case UpgradeType.Oxygen:
                GameManager.instance.maxOxygen += amount;
                PlayerOxygen oxygen = player.GetComponent<PlayerOxygen>();
                oxygen.maxOxygen = GameManager.instance.maxOxygen;
                oxygen.Refill(amount); //refills instantly, maybe get rid of
                break;

            case UpgradeType.Damage:
                GameManager.instance.projectileDamage += amount;
                break;
            
            case UpgradeType.Health:
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if(playerHealth.currentHealth < 100){
                    //GameManager.instance.playerHealth = 100;
                    //PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                    //playerHealth.maxHealth = GameManager.instance.playerHealth;
                    playerHealth.currentHealth = 100;
                    playerHealth.UpdateHealthUI();
                }
                break;
        }
    }
}
