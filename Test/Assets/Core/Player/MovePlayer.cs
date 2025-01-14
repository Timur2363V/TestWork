using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += speed * Joystick.Instance.Position;
    }
}
