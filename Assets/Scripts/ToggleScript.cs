using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject bean;
    public GameObject teddy;
    public GameObject car;
    public GameObject granny;
    public GameObject toggleLeft;
    public GameObject toggleRight;

    public void ToggleBean(bool value)
    {
        bean.SetActive(value);
        toggleLeft.GetComponent<Toggle>().interactable = value;
        toggleRight.GetComponent<Toggle>().interactable = value;
    }

    public void toLeft()
    {
        bean.transform.localScale = new Vector2(1, 1);
    }

    public void toRight()
    {
        bean.transform.localScale = new Vector2(-1, 1);
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