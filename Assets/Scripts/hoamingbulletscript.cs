using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class HoamingBulletScript : MonoBehaviour
    {
 
        public float speed = 5;
        Transform target;
        public GameObject HitEffect;
        public int buildingHitsToDestroy = 2;
        public int gunHitsToDestroy = 1;
      
        private int buildingHits = 0;
        private int gunHits = 0;
 
        void Start()
        {
            FindNearestTarget();
            
        }

        void Update()
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                FindNearestTarget();
            }
        }

        void FindNearestTarget()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("player");
            GameObject building1 = GameObject.FindGameObjectWithTag("building1");
            GameObject building2 = GameObject.FindGameObjectWithTag("building2");

            Transform nearestTarget = null;
            float nearestDistance = float.MaxValue;

            if (playerObject != null)//player ko isliye float.maxvalue diya takay wo compare krske
            {
                float playerDistance = Vector2.Distance(transform.position, playerObject.transform.position);
                if (playerDistance < nearestDistance)
                {
                    nearestTarget = playerObject.transform;
                    nearestDistance = playerDistance;
                }
            }

            if (building1 != null)
            {
                float building1Distance = Vector2.Distance(transform.position, building1.transform.position);
                if (building1Distance < nearestDistance)
                {
                    nearestTarget = building1.transform;
                    nearestDistance = building1Distance;
                }
            }

            if (building2 != null)
            {
                float building2Distance = Vector2.Distance(transform.position, building2.transform.position);
                if (building2Distance < nearestDistance)
                {
                    nearestTarget = building2.transform;
                }
            }

            target = nearestTarget;
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
       

    
   

        if (collision.gameObject.CompareTag("building1") || collision.gameObject.CompareTag("building2") || collision.gameObject.CompareTag("building3") || collision.gameObject.CompareTag("building4") || collision.gameObject.CompareTag("building5"))
        {
         

            Instantiate(HitEffect, transform.position, Quaternion.identity);

            buildingHits += 1;


            if (buildingHits >= buildingHitsToDestroy)
            {
   
                buildingHits = 0; 
                Destroy(collision.gameObject);
                PlayHitSound();
             
            }
            else
            {
                Destroy(gameObject); 
            }
        }
        else if (collision.gameObject.CompareTag("player"))
        {
   

            Instantiate(HitEffect, transform.position, Quaternion.identity);
         
           

          

       

            if (gunHits >= gunHitsToDestroy)
            {
        
                gunHits = 0; 
                Destroy(collision.gameObject);
                PlayHitSound();
             
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


    void PlayHitSound()
        {
            
            Destroy(gameObject);
        }
    }


