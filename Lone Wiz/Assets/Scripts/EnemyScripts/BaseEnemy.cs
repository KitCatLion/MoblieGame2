using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public void Die()
    {
        GameManager.Instance.EnemyDefeated();
        Destroy(gameObject);
    }
}