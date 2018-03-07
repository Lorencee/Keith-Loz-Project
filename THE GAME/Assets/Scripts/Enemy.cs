
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    public bool Alive;
    public Item_Drops item_dropped;
    public Vector3 diePos;
    

    void Start()
    {
        if (gameObject.activeInHierarchy ==true)
        {
            Alive = true;
        }
    }

    void Update()
    {
        if(item_dropped.finished == true)
        {
            DieAnim();
        }   
    }

    public void TakeDamage(float Amount)
    {
        health -= Amount;
        if (health <= 0 )
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy Dead");
        Item_Drops x = GetComponent<Item_Drops>();
        Alive = false;
        diePos = gameObject.transform.position;


             
    }
    public void DieAnim()
    {
        Destroy(gameObject);
    }
}

