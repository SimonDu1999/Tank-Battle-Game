using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private void Awake()
    {
            
    }
    // Use this for initialization
    Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        maxHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        TankMove();

        //间隔
        TankAttack();
    }

    public int index;
    public void TankMove()
    {
        float horizontal = Input.GetAxis("Horizontal" + index);
        rig.angularVelocity = transform.up * horizontal * 3;
        float vertical = Input.GetAxis("Vertical" + index);
        rig.velocity = transform.forward * vertical * 10;

    }
    public KeyCode key;
    private void TankAttack()
    {
        //按下键位执行攻击
        if (Input.GetKeyDown(key))
        {
            //调用创建子弹的方法
            GetComponentInChildren<SpawnController>().ShellSpawn();
        }
    }

    public Image uiHP;
    float hp = 100, maxHP;
    public void TankDamage(float damage)
    {
        hp -= damage;
        uiHP.fillAmount = hp / maxHP;
        if (hp <= 0)
        {
            //死亡
            TankDie();
        }
    }

    public void TankDie()
    {
        Destroy(gameObject);
        Destroy(Instantiate(Resources.Load("TankExplosion"),transform.position,transform.rotation),1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shell")
        {
            TankDamage(100);
        }
    }
}
