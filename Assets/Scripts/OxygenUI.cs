using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    public PlayerOxygen playerOxygen;
    public Slider oxygenSlider;

    // Update is called once per frame
    void Update()
    {
        oxygenSlider.value = playerOxygen.GetNormalized();
    }
}
