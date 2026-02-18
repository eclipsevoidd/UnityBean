using TMPro;
using UnityEngine;

public class DonutDestroyScript : MonoBehaviour
{
    private SFX_Script sfx;
    public TMP_Text VeirtuliText;
    private int destroyedDonuts = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            destroyedDonuts++;
            Debug.Log(destroyedDonuts);

            if (VeirtuliText != null)
            {
                VeirtuliText.text = "Donuts Destroyed: " + destroyedDonuts;
            }

            Destroy(collision.gameObject);

            if (sfx != null)
            {
                sfx.PlaySFX(3);
            }
        }
    }
}