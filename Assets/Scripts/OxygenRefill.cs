using UnityEngine;

public class OxygenRefill : MonoBehaviour
{
    public float refillRate = 20f;

    void OnTriggerStay(Collider other)
    {
        PlayerOxygen oxygen = other.GetComponent<PlayerOxygen>();
        if(oxygen != null)
        {
            oxygen.RefillMeter(refillRate * Time.deltaTime);
        }
    }
}
