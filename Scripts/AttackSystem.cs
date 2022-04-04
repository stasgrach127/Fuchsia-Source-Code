using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackSystem : MonoBehaviour
{
    Animator anim;
    BoxCollider col;
    int curAnim;
    bool canGo;
    [SerializeField] WeaponScriptable[] availableWeapons;
    [SerializeField] WeaponScriptable curWeapon;
    [SerializeField] GameObject damagePopup;
    TimerChamber tChamber;
    UIManager uiManager;
    MusicManager musManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        tChamber = GameObject.FindObjectOfType<TimerChamber>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        col = transform.GetComponent<BoxCollider>();
        col.enabled = false;
        canGo = true;
        musManager = GameObject.FindObjectOfType<MusicManager>();
        curWeapon = availableWeapons[PlayerPrefs.GetInt("WeaponUpgrade")];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canGo)
        {
            ChangeAnimations();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ResetAnim();
        }
    }

    void ChangeAnimations()
    {
        anim.SetInteger("curAttack", anim.GetInteger("curAttack") + 1);
        if (anim.GetInteger("curAttack") == 5)
        {
            anim.SetInteger("curAttack", 1);
        }
        canGo = false;
    }

    public void AllowChange()
    {
        canGo = true;
    }

    public void ResetAnim()
    {
        anim.SetInteger("curAttack", 0);
    }

    public void TurnTrigger()
    {
        col.enabled = !col.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            DealDamage(other.gameObject.GetComponent<EnemyBehaviour>());
        }
    }

    void DealDamage(EnemyBehaviour enemy)
    {
        int hit = Random.Range(0, 100);
        musManager.PlaySwordSound();
        if (hit < curWeapon.wsCritChance)
        {
            enemy.enemyHealth -= curWeapon.wsCritDamage;
        }
        else
        {
            enemy.enemyHealth -= curWeapon.wsDamage;
        }
        CheckHealth(enemy);
        TMP_Text popupText = Instantiate(damagePopup, enemy.gameObject.transform.position, Quaternion.identity).GetComponent<TMP_Text>();
        popupText.transform.LookAt(transform);
        popupText.text = curWeapon.wsDamage.ToString();
        StartCoroutine(DestroyText(popupText.gameObject));
    }

    void CheckHealth(EnemyBehaviour beh)
    {
        if (beh.enemyHealth <= 0)
        {
            Destroy(beh.gameObject);
            tChamber.AddTime(beh.enemyScriptable.esDropTime);
            PlayerPrefs.SetInt("ReceivedMoney", PlayerPrefs.GetInt("ReceivedMoney") + beh.enemyScriptable.esDrop);
            uiManager.SetMoneyText();
            uiManager.ChangeChamberTimer(tChamber.curChamberTime);
            uiManager.TimeAddText(beh.enemyScriptable.esDropTime);
            musManager.PlaySound("clock");
        }
    }

    IEnumerator DestroyText(GameObject text)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(text);
    }
}
