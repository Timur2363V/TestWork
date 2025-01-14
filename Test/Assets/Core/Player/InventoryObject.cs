using UnityEngine;
using UnityEngine.UI;

public class InventoryObject : MonoBehaviour
{
    [SerializeField]
    private InventoryObjectTag tagObject; 
    [SerializeField]
    private Text textCount;
    [SerializeField]
    private Button button;
    [SerializeField]
    private int maxCount = 64;

    private int count;

    public bool IsFilled => count == maxCount;
    public InventoryObjectTag TagObject => tagObject;

    private void Awake()
    {
        CheckObjectNotCalculated();
    }

    private void CheckObjectNotCalculated()
    {
        if (maxCount == 1)
        {
            textCount.gameObject.SetActive(false);
        }
    }

    public void ResetCount()
    {
        count = 0;
    }

    public void AddObject(int count)
    {
        if (this.count + count > maxCount)
        {
            var addNewObjectCount = this.count + count - maxCount;
            this.count = maxCount;
            Inventory.Instance.AddObject(addNewObjectCount, this);
        }
        else
        {
            this.count = Mathf.Min(this.count + count, maxCount);
        }
    }

    public void RemoveObject()
    {
        Inventory.Instance.RemoveObject(this);
    }

    public void Decrease()
    {
        count = Mathf.Max(0, count - 1);

        if (count == 0)
        {
            Inventory.Instance.RemoveObject(this);
        }
    }

    private void OnValidate()
    {
        button = GetComponent<Button>();
        textCount = GetComponentInChildren<Text>();
    }
}
