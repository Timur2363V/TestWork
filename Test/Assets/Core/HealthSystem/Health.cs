using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxCount;
    [SerializeField]
    private VisualSlider slider;

    private int count;

    private const float fullHealth = 1f;

    private void Awake()
    {
        count = maxCount;
        slider.Update(fullHealth);
    }

    public void Damage(int count)
    {
        if (this.count - count <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            this.count -= count;
        }
        slider.Update(this.count * fullHealth / maxCount);
    }
}
