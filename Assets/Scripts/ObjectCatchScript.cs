using UnityEngine;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;
    private Rigidbody2D rb;
    SFX_Script sfx;
    DonutBakerScript baker;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        baker = FindFirstObjectByType<DonutBakerScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform))
            return;

        // 1. JA NOĶERTS LABAIS VIRTULIS
        if (collision.CompareTag("Donut"))
        {
            if (sfx != null) sfx.PlaySFX(4);

            if (baker != null)
            {
                baker.AddScore(1);
            }

            Destroy(collision.gameObject);

            // Augšanas loģika
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;
        }

        // 2. JA NOĶERTS SLIKTAIS VIRTULIS (BadDonut)
        else if (collision.CompareTag("Danger"))
        {
            // Pieņemot, ka tev ir SFX priekš kļūdas, piemēram, indekss 5
            if (sfx != null) sfx.PlaySFX(5);

            if (baker != null)
            {
                baker.LoseLife(); // Atņem dzīvību
            }

            Destroy(collision.gameObject);

            // OPTIONĀLI: Saraušanās loģika (pretēji augšanai)
            if (transform.localScale.x > 1.0f) // Neļaujam kļūt mazākam par sākuma izmēru
            {
                transform.localScale -= new Vector3(sizeIncrease, sizeIncrease, 0);
                rb.mass -= massIncrease;
            }
        }
    }
}