using UnityEngine;

public class LayerObject : MonoBehaviour
{
    [SerializeField]
    private LayerTag layerTag;

    public LayerTag LayerTag => layerTag;

    private void OnValidate()
    {
        gameObject.layer = LayerMask.NameToLayer(LayerController.Instance.GetNameLayer(layerTag));
    }
}
