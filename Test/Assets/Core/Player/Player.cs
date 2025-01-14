using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Health health;

    public Health Health => health;

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Player>();
            }
            return instance;
        }
    }

    private void OnValidate()
    {
        health = GetComponent<Health>();
    }
}
