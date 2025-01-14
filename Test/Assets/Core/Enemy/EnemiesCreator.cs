using UnityEngine;

public class EnemiesCreator : MonoBehaviour
{
    [SerializeField]
    private Vector3 boxStart;
    [SerializeField]
    private Vector3 boxEnd;
    [SerializeField]
    private int count = 3;
    [SerializeField]
    private Health enemy;

    private void Awake()
    {
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition() => new Vector3(Random.Range(boxStart.x, boxEnd.x), Random.Range(boxStart.y, boxEnd.y), 0f);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(boxStart, new Vector3(boxEnd.x, boxStart.y, 0f));
        Gizmos.DrawLine(boxStart, new Vector3(boxStart.x, boxEnd.y, 0f));
        Gizmos.DrawLine(new Vector3(boxEnd.x, boxStart.y, 0f), boxEnd);
        Gizmos.DrawLine(new Vector3(boxStart.x, boxEnd.y, 0f), boxEnd);
    }
}
