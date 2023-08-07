using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string axisName;
    [SerializeField] private float speed;
    [SerializeField] Transform LeftWall, RightWall;

    private float paddleWidth;
    private float leftWallWidth, rightWallWidth;

    private void Start()
    {
        paddleWidth = transform.localScale.x;
        leftWallWidth = LeftWall.transform.localScale.x;
        rightWallWidth = RightWall.transform.localScale.x;
    }
    void Update()
    {
        float move = Input.GetAxis(axisName) * speed;

        float nextPlayerPositionX = transform.position.x + (move * Time.deltaTime);

        float minLimit = LeftWall.position.x + paddleWidth / 2 + leftWallWidth / 2;
        float maxLimit = RightWall.position.x - paddleWidth / 2 - rightWallWidth / 2;
        float clampedPositionX = Mathf.Clamp(nextPlayerPositionX, minLimit, maxLimit);

        transform.position = new Vector3(clampedPositionX, transform.position.y, transform.position.z);
    }
}