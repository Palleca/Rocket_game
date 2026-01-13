using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float timer;
    public float timeToSpawn;
    public GameObject obstacle;

    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= timeToSpawn)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
