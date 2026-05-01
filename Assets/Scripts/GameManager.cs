using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float maxOxygen = 100f;
    public int projectileDamage = 25;
    public int playerHealth = 100;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
