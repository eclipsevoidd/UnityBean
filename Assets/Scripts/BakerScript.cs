using System.Collections;
using UnityEngine;

public class BakerScript : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float bakeInterval = 1.0f;
    float minPoz, maxPoz;
    Transform ovenTransform;
    void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

    public void BakeDonut(bool state)
    {
        if (state)
        {
            StartCoroutine(Bake());
        }
        else
        {
            StopAllCoroutines();
        }

        IEnumerator Bake()
        {
            while (true)
            {
                minPoz = ovenTransform.position.x - 20.0f;
                maxPoz = ovenTransform.position.x + 20.0f;
                float randPoz = Random.Range(minPoz, maxPoz);
                Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

                int donutIndex = Random.Range(0, donutPrefabs.Length);
                Instantiate(donutPrefabs[donutIndex], spawnPoz, Quaternion.identity, ovenTransform);
                yield return new WaitForSeconds(bakeInterval);
            }
        }
    }
}