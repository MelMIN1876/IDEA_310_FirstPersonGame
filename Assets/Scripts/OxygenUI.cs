using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    public PlayerOxygen playerOxygen;
    public Slider oxygenSlider;
    public TextMeshProUGUI oxygenText;

    // Update is called once per frame
    void Update()
    {
        oxygenText.text = ((int)playerOxygen.currentOxygen).ToString();
        oxygenSlider.value = playerOxygen.GetNormalized();
    }


}
