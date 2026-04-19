using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        //Input.GetKeyDown(KeyCode.Mouse0)
        //Mouse.current.leftButton.wasPressedThisFrame
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(projectile, mainCamera.transform.position, mainCamera.transform.rotation);
        }
    }
}
