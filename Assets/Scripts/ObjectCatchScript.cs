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

        if (collision.CompareTag("Donut"))
        {
            if (sfx != null) sfx.PlaySFX(4);

            if (baker != null)
            {
                baker.AddScore(1);
            }

            Destroy(collision.gameObject);

            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;
        }

        else if (collision.CompareTag("Danger"))
        {
            if (sfx != null) sfx.PlaySFX(5);

            if (baker != null)
            {
                baker.LoseLife();
            }

            Destroy(collision.gameObject);

            if (transform.localScale.x > 1.0f)
            {
                transform.localScale -= new Vector3(sizeIncrease, sizeIncrease, 0);
                rb.mass -= massIncrease;
            }
        }
    }
}