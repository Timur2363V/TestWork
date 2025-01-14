using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform moveObject;
    [SerializeField]
    private float distanceStartWalk;
    [SerializeField]
    private float distanceStop;
    [SerializeField]
    private float speed;

    private bool CheckMove => Vector3.Distance(moveObject.position, Player.Instance.transform.position) <= distanceStartWalk;

    private void Update()
    {
        if (CheckMove)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Vector3.Distance(moveObject.position, Player.Instance.transform.position) > distanceStop)
        {
            moveObject.position += speed * (Player.Instance.transform.position - transform.position).normalized;
        }
    }
}
