using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TVScript : MonoBehaviour
{
    public GameObject tvScreen1;
    public GameObject tvScreen2;
    public TMP_Text buttonText;

    public AudioSource AudioSource;
    public AudioClip tvSound;

    public bool isOn = false;

    public void ToggleTV()
    {
    AudioSource.PlayOneShot(tvSound);
        if (!isOn)
        {
            tvScreen1.SetActive(true);
            buttonText.text = "Izslēgt televizoru";
            isOn = true;
    }
        else
        {
            tvScreen1.SetActive(false);
            buttonText.text = "Ieslēgt televizoru";
            isOn = false;
        }
    }
}
