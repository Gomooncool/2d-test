using System.Collections;
using UnityEngine;

public class AIhandler : MonoBehaviour

{
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject player;

    /*void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (animator.GetBool("ZombieIsMoving") == true)
        {
            gameObject.transform.Translate((player.transform.position - gameObject.transform.position) * Time.deltaTime * 1);


        }




    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        StartCoroutine (AttackAfterTime(1));



         IEnumerator AttackAfterTime(float timeInSec)
         {
             yield return new WaitForSeconds(timeInSec);
             animator.SetBool("ZombieIsAttacking", true);
             player.GetComponent<HealthHandler>().Health -= 1;


             yield return new WaitForSeconds(1.0f);
             animator.SetBool("ZombieIsAttacking", false);


         } 


    }



    void OnTriggerStay(Collider other)
    {

        animator.SetBool("ZombieIsMoving", true);

        if ((other.gameObject.GetComponent<Animator>().GetBool ("IsAttacking") == true) & (animator.GetBool("ZombieIsAttacking") == false))
        {
            Destroy(gameObject, 1.0f);
            animator.SetBool("ZombieIsDying", true);

        }

    }

    void OnTriggerExit(Collider other)
    {
        animator.SetBool("ZombieIsMoving", false);
        animator.SetBool("ZombieIsAttacking", false);

    }



  
    
}
