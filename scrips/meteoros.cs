using Unity.Collections;
using UnityEngine;

public class meteoros : MonoBehaviour
{

    public GameObject meteoro;
    public float Spawnminuto = 30f;
    public float Spawnmas = 1f;
    public float maxTime = 4f;
    private float xLimit = 6f;
    private float spawnNext = 0;

    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / Spawnminuto;
            Spawnminuto += Spawnmas;
            float rand = Random.Range(-xLimit, xLimit);
            Vector2 spawnPosition = new Vector2(rand, 8f);

            GameObject meteoros = Instantiate(meteoro, spawnPosition, Quaternion.identity);
            Destroy(meteoros, maxTime);
        }
    }
}
