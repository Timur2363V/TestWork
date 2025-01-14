using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LiftObject : MonoBehaviour
{
    [SerializeField]
    private int count;
    [SerializeField]
    private InventoryObject inventoryObject;

    private const LayerTag playerLayer = LayerTag.Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerController.Instance.GetNameLayer(playerLayer)))
        {
            Inventory.Instance.AddObject(count, inventoryObject);
            Destroy(gameObject);
        }
    }
}
