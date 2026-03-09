using UnityEngine;

public class ChaseControll : MonoBehaviour
{

    public FlyingEnemy[] enemyArea;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && enemyArea != null)
        {
            foreach (FlyingEnemy enemy in enemyArea)
            {
               
                if (enemy != null)
                {
                    enemy.chase = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemyArea != null)
        {
            foreach (FlyingEnemy enemy in enemyArea)
            {
                if (enemy != null)
                {
                    enemy.chase = false;
                }
            }
        }
    }






}
