using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start ()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();        
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject , 2);
    }


    [SerializeField] GameObject obstaclePrefabs;

    public void SpawnObstacle ()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefabs, spawnPoint.position, Quaternion.identity, transform);
    }

    [SerializeField] GameObject coinPrefabs;

    public void SpawnCoin ()
    {
        int coinToSpawn = 10;
        for (int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefabs,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 
                                    Random.Range(collider.bounds.min.y, collider.bounds.max.y), 
                                    Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
