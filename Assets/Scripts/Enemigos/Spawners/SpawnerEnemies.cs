using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private SpawnPercentage[] spawnPercentages;
    [SerializeField] private bool _isSpawned;

    public void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        
        float totalPercentage = 0;
        foreach (var spawn in spawnPercentages)
        {
            totalPercentage += spawn.percentage;
        }

        
        float randomValue = Random.Range(0, totalPercentage);
        float currentSum = 0;

        
        foreach (var spawn in spawnPercentages)
        {
            currentSum += spawn.percentage;

            if (randomValue <= currentSum)
            {
                Instantiate(spawn.Enemy, transform);
                
                break;
            }
        }
    }
}

[System.Serializable]

public struct SpawnPercentage
{
    public Entity Enemy;
    public float percentage;
}