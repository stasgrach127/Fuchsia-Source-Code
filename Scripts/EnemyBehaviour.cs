using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    float distance;
    public EnemyScriptable enemyScriptable;
    bool isAttacking;
    Animator anim;
    TimerChamber tChamber;
    UIManager uiManager;
    public int enemyHealth;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyHealth = enemyScriptable.esHealth;
        player = GameObject.FindObjectOfType<CharacterController>().gameObject;
        tChamber = GameObject.FindObjectOfType<TimerChamber>();
        StartCoroutine("MoveToPlayer");
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= enemyScriptable.esRadius)
        {
            if (!isAttacking) AttackTry();
        }
    }

    IEnumerator MoveToPlayer()
    {
        yield return new WaitForSeconds(0.2f);
        if (this) transform.DOMove(player.transform.position, enemyScriptable.esSpeed);
        //transform.Rotate(player.transform.position);
        StartCoroutine("MoveToPlayer");
    }

    void AttackTry()
    {
        anim.SetBool("isAttacking", true);
        int hit = Random.Range(0, 100);
        if (hit < enemyScriptable.esAccuracy)
        {
            
        }
        else
        {
            tChamber.AddTime(-enemyScriptable.esDamage);
            uiManager.ChangeChamberTimer(tChamber.curChamberTime);
        }
        isAttacking = true;
        StartCoroutine("WaitForAttack");
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(enemyScriptable.esCooldown);
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
