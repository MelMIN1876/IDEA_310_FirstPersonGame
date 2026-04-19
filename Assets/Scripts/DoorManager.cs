using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance;
    public GameObject door;

    void Awake()
    {
        Instance = this;
    }

    public void OpenDoors()
    {
        Debug.Log("Opening Door");
        door.SetActive(false);
    }
}
