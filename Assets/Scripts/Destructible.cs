using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destructionTime = 1f;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }

    private void OnDestroy()
    {
        if (spawnableItems.Length > 0 && Random.value < itemSpawnChance)
        {
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Vector2 correctPosition = new Vector2(Mathf.Round(transform.position.x) - 
                0.5f, Mathf.Round(transform.position.y)-0.5f);
            Instantiate(spawnableItems[randomIndex], correctPosition, Quaternion.identity);
        }
    }

}
