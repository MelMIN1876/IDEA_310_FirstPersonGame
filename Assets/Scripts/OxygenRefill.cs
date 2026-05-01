using UnityEngine;

public class OxygenRefill : MonoBehaviour
{
    public float respawnTime = 10f;
    private Collider bubbleCollider;
    private MeshRenderer meshRenderer;
    void Start()
    {
        bubbleCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerOxygen oxygen = other.GetComponent<PlayerOxygen>();
            if(oxygen != null)
            {
                oxygen.currentOxygen = oxygen.maxOxygen;
                StartCoroutine(Respawn());
                
                System.Collections.IEnumerator Respawn()
                {
                    bubbleCollider.enabled = false;
                    meshRenderer.enabled = false;
                    yield return new WaitForSeconds(respawnTime);
                    bubbleCollider.enabled = true;
                    meshRenderer.enabled = true;
                }
            }
        }
        

    }




    // public float refillRate = 100f;

    // void OnTriggerStay(Collider other)
    // {
    //     PlayerOxygen oxygen = other.GetComponent<PlayerOxygen>();
    //     if(oxygen != null)
    //     {
    //         oxygen.Refill(refillRate * Time.deltaTime);
    //     }
    // }
}
