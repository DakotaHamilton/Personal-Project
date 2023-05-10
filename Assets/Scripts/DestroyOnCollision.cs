using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
