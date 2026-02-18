using UnityEngine;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;
    private Rigidbody2D rb;
    SFX_Script sfx;
    DonutBakerScript baker; // Reference uz otru skriptu

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        baker = FindFirstObjectByType<DonutBakerScript>(); // Atrodam baker skriptu
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform))
            return;

        if (collision.CompareTag("Donut"))
        {
            // Atskaņojam skaņu (ar drošības pārbaudi)
            if (sfx != null) sfx.PlaySFX(4);

            // PIESKAITĀM PUNKTU TEKSTAM
            if (baker != null)
            {
                baker.AddScore(1);
            }

            Destroy(collision.gameObject);
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;
        }
    }
}