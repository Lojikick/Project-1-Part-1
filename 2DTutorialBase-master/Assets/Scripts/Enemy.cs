using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    
        #region Movement_varibles
        public float movespeed;
        #endregion

        #region Physics_components
        Rigidbody2D EnemyRB;
        #endregion

        #region Targeting_variables
        public Transform player;
        #endregion

        # region Attack_variables
        public float explosionDamage;
        public float explosionRadius;
        public GameObject explosionObject;
        #endregion

        #region Health_variables
        public float maxHealth;
        float currHealth;
        #endregion
        #region Unity_Functions
        private void Awake()
        {
            EnemyRB = GetComponent<Rigidbody2D>();

            currHealth = maxHealth;
        }
        private void Update()
        {
            if(player == null){
                return;
            }

            move();
        }
        #endregion

        #region Movement_functions
        private void move(){
            Vector2 direction = player.position - transform.position;

            EnemyRB.velocity = direction.normalized * movespeed;
        }
        #endregion
    
        #region Attack_functions
        private void Explode(){
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.transform.CompareTag("Player")){
                    //Compare FDmage
                    Debug.Log("EXPLOSIM ENTERTAINMENT");

                    Instantiate(explosionObject,transform.position,transform.rotation);
                     hit.transform.GetComponent<Controller>().TakeDamage(explosionDamage);
                    Destroy(this.gameObject);
                }
            }
            
        }
        private void OnCollisionEnter2D(Collision2D collision){
            Debug.Log("i should die");
            if(collision.transform.CompareTag("Player")){
                Explode();
            }
        }
        #endregion
    // Update is called once per frame

    #region Health_functions
    public void TakeDamage(float value){
        currHealth -= value;
        Debug.Log("Health is now"+currHealth.ToString());

        if(currHealth <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(this.gameObject);
    }
    #endregion
}

