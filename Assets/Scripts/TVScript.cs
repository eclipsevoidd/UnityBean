using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TVScript : MonoBehaviour
{
    public GameObject tvScreen1;
    public GameObject tvScreen2;

    public TMP_Text buttonText;
    public GameObject channelButton;

    public AudioSource audioSource;
    public AudioClip tvSound;

    public bool isOn = false;

    void Start()
    {
        channelButtonVisible();
    }

    public void ToggleTV()
    {
        audioSource.PlayOneShot(tvSound);
        isOn = !isOn;

        if (isOn)
        {
            tvScreen1.SetActive(true);
            tvScreen2.SetActive(false);
            buttonText.text = "Izslēgt televizoru";
        }
        else
        {
            tvScreen1.SetActive(false);
            tvScreen2.SetActive(false);
            buttonText.text = "Ieslēgt televizoru";
        }

        channelButtonVisible();
    }

    public void SwitchChannel()
    {
        if (!isOn)
        {
            return;
        }

        audioSource.PlayOneShot(tvSound);

        bool isScreen1Active = tvScreen1.activeSelf; // nosaka, vai bilde ir aktīva

        tvScreen1.SetActive(!isScreen1Active);
        tvScreen2.SetActive(isScreen1Active);
    }

    private void channelButtonVisible()
    {
        if (channelButton != null)
        {
            channelButton.SetActive(isOn);
        }
    }
}