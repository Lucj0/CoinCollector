using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    private CoinCollector coinCollector;

    void Start()
    {
        player = GameObject.Find("Square").transform;
        coinCollector = player.GetComponent<CoinCollector>();
    }

    void Update()
    {
        if (player != null && coinCollector.gameIsActive)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
