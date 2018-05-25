using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyAI : MonoBehaviour {

    public Transform player;
    public float lookRadius = 10f;
    static Animator anim;
    PlayerStats playerStats;
    CharacterStats myStats;
    CharacterCombat cCombat;

    private float attackSpeed = 0.3f;
    private float attackCooldown = 0f;

	void Start () {
        playerStats = PlayerStats.instance;
        myStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        attackCooldown -= Time.deltaTime;
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < lookRadius && angle < 120)
        {
            //direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f*Time.deltaTime);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0, 0.01f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isTakingDamage", false);
            }
            else
            {
                // cCombat.Attack(playerStats);
                if (attackCooldown <= 0f)
                {
                    playerStats.TakeDamage(myStats.physicalDamage, myStats.magicDamage);
                    attackCooldown = 1f / attackSpeed;
                }
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isTakingDamage", false);
            }
        }else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isTakingDamage", false);
        }
	}

}
