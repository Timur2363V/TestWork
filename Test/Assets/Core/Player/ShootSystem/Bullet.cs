using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float distance = 20f;

    private LayerTag enemyTag;
    private float currentDistance;

    public void Instantiate(LayerTag enemyTag)
    {
        this.enemyTag = enemyTag;
    }


    private void Update()
    {
        transform.position += transform.right * speed;
        currentDistance += speed;

        if (currentDistance >= distance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerController.Instance.GetNameLayer(enemyTag)))
        {
            collision.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
