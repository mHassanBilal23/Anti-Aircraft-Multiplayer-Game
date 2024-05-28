
using UnityEngine;
using UnityEngine.UI;

public class SliderMoveSpeed : MonoBehaviour
{
   
    public Slider slid ;


   public  void Onslider()
    {

        slid.onValueChanged.AddListener(OnSliderValueChanged);
    }
    public void OnSliderValueChanged(float newValue)
    {
        PlayerMovement.rotationSpeed = newValue;
    }
}
