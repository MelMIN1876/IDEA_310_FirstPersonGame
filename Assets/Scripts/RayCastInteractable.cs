using UnityEngine;

public class RayCastInteractable : MonoBehaviour
{

    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Create a raycasthit variable to store info in later
            RaycastHit hit;

            //Check if raycast hits something
            if(Physics.Raycast(transform.position, mainCamera.transform.forward, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                //check if object we hit has a collider then save it to the hit variable
                if(hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    Debug.Log("Found Rigidbody");
                    rb.AddForce(mainCamera.transform.forward * 100f, ForceMode.Impulse);
                }
            }
        }
    }
}
