using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
   #region 
   [SerializeField]
   [Tooltip("the amount the player heals")]
   
   private int healamount;
   #endregion

   #region Heal_functions
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.transform.CompareTag("Player"))
       {
           collision.transform.GetComponent<Controller>().Heal(healamount);
           Destroy(this.gameObject);
       }
   }
   #endregion
}
