using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    [SerializeField]
    private float delay = 0.5f;
    [SerializeField]
    private int damage = 3;
    [SerializeField]
    private float distanceAttack;

    private float currentTimeDelay;

    private void Update()
    {
        CheckAttack();
        UpdateTimer();
    }

    private void CheckAttack()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= distanceAttack && currentTimeDelay == 0f)
        {
            Player.Instance.Health.Damage(damage);
            currentTimeDelay = delay;
        }
    }

    private void UpdateTimer()
    {
        currentTimeDelay = Mathf.Max(0f, currentTimeDelay - Time.deltaTime);
    }
}
