using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public System.Action OnDeath; // Event for when the enemy dies

    public void Die()
    {
        if (OnDeath != null)
            OnDeath.Invoke(); // Notify GameManager when this enemy dies

        Destroy(gameObject);
    }
}