using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private float damageAmount = 1f;

    private RaycastHit2D[] hits;

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        //if (UserInput.instance.controls.Attack.Attack.WasPressedThisFrame())
        {
          //  Attack();
        }
    }

    // Update is called once per frame
    private void Attack()
    {

        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackLayer);

        for(int i = 0; i < hits.Length; i++)
        {
            IDamageable iDamageable = hits [i].collider.gameObject.GetComponent<IDamageable>();

            if(iDamageable != null )
            {
                iDamageable.Damage(damageAmount);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

}
