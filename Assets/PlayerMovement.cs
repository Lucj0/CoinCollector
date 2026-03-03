using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private CoinCollector coinCollector;

    void Start()
    {
        coinCollector = GetComponent<CoinCollector>();
    }

    void Update()
    {
        if (coinCollector.gameIsActive)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(moveHorizontal, moveVertical, 0) * speed * Time.deltaTime;

            float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
            float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
            transform.position = new Vector3(clampedX, clampedY, 0);
        }
    }
}
