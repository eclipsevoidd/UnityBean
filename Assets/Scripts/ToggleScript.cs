using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public GameObject bean;
    public GameObject teddy;
    public GameObject car;
    public GameObject granny;

    public void ToggleBean(bool value)
    {
        bean.SetActive(value);
    }

    public void ToggleTeddy(bool value)
    {
        teddy.SetActive(value);
    }

    public void ToggleCar(bool value)
    {
        car.SetActive(value);
    }

    public void ToggleGranny(bool value)
    {
        granny.SetActive(value);
    }
}
