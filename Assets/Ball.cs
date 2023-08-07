using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float iniBallSpeed = 10f;
    private float ballSpeed;
    private Vector2 direction;
    [SerializeField] private string padTag, bounceWallUpTag, bounceWallSidesTag, deathWallTag, blockTag;

    void Start()
    {
        direction = new Vector2(1, 1);
        ballSpeed = iniBallSpeed;
    }

    public void Move()
    {
        transform.Translate(direction * ballSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == bounceWallUpTag || collision.gameObject.tag == padTag)
        {
            direction = new Vector2(direction.x, -direction.y);
        }
        if (collision.gameObject.tag == bounceWallSidesTag)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
        if (collision.gameObject.tag == blockTag)
        {
            collision.gameObject.SetActive(false);
            direction = new Vector2(direction.x, -direction.y);
            gameManager.AddPoint();
         }
         if (collision.gameObject.tag == deathWallTag)
         {
            direction = new Vector2(1, 1);
            gameManager.RemoveLife();
         }
    }
}