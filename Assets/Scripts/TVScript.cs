using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TVScript : MonoBehaviour
{
    [Header("Screens")]
    public GameObject tvScreen1;
    public GameObject tvScreen2;

    [Header("UI Controls")]
    public TMP_Text buttonText;
    public GameObject channelButton; // The main "Switch Channel" button

    [Header("Channel 1 Buttons")]
    public GameObject epstein;
    public GameObject bean;
    public GameObject trump;

    [Header("Channel 2 Buttons")]
    public GameObject epstein2;
    public GameObject vitols;
    public GameObject bean2;

    [Header("Audio & Animation")]
    public AudioSource audioSource;
    public AudioClip tvSound;
    public Animator RemoteAnimation;

    public bool isOn = false;

    void Start()
    {
        RefreshButtons();
    }

    public void ToggleTV()
    {
        audioSource.PlayOneShot(tvSound);
        if (RemoteAnimation != null) RemoteAnimation.SetTrigger("nospiests");

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

        RefreshButtons();
    }

    public void SwitchChannel()
    {
        if (RemoteAnimation != null) RemoteAnimation.SetTrigger("nospiests");
        if (!isOn) return;

        audioSource.PlayOneShot(tvSound);

        bool isScreen1Active = tvScreen1.activeSelf;
        tvScreen1.SetActive(!isScreen1Active);
        tvScreen2.SetActive(isScreen1Active);

        RefreshButtons();
    }

    private void RefreshButtons()
    {
        if (channelButton != null) channelButton.SetActive(isOn);

        bool showSet1 = isOn && tvScreen1.activeSelf;
        epstein.SetActive(showSet1);
        bean.SetActive(showSet1);
        trump.SetActive(showSet1);

        bool showSet2 = isOn && tvScreen2.activeSelf;
        epstein2.SetActive(showSet2);
        vitols.SetActive(showSet2);
        bean2.SetActive(showSet2);
    }
}