using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public int numberOfTreasures = 5;
    public GameObject treasurePrefab;
    public Transform leftBottom;
    public Transform rightTop;
    public float spawnRadius = 0.5f; // Smaller radius for more precise collision detection

    void Start()
    {
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        int attempts = 0;
        int maxAttempts = numberOfTreasures * 20; // Increase max attempts for more robustness

        for (int i = 0; i < numberOfTreasures; i++)
        {
            Vector2 randomPosition = GetRandomPositionWithinBorders();

            // Check for collisions at the random position
            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, spawnRadius); // Reduced radius
            bool isColliding = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall") || collider.CompareTag("Treasure")) // Check for collisions with existing treasures as well
                {
                    isColliding = true;
                    break;
                }
            }

            // If there's no collision with a wall or another treasure, instantiate the treasure
            if (!isColliding)
            {
                Instantiate(treasurePrefab, randomPosition, Quaternion.identity);
            }
            else
            {

                i--;
                attempts++;
                if (attempts >= maxAttempts)
                {
                    break;
                }
            }
        }
    }

    Vector2 GetRandomPositionWithinBorders()
    {
        float randomX = Random.Range(leftBottom.position.x, rightTop.position.x);
        float randomY = Random.Range(leftBottom.position.y, rightTop.position.y);

        Vector2 randomPosition = new Vector2(randomX, randomY);
        return randomPosition;
    }

}
