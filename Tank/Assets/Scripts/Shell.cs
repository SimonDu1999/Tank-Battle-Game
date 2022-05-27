using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    //直接消失
    //private void OnTriggerStay(Collider other)
    //{
    //    Destroy(gameObject);
    //    Destroy(Instantiate(Resources.Load("ShellExplosion"),transform.position,Quaternion.identity),1);
    //}

   static int maxTop = 5;
    //碰到子弹消失
    private void OnTriggerEnter(Collider other)
    {
        //碰到任何游戏物体会消失子弹,同时创建特效
        Destroy(gameObject);
        Destroy(Instantiate(Resources.Load("ShellExplosion"), transform.position, Quaternion.identity), 1);
        //只有碰到标签为Shell的游戏物体时会同时消失子弹和Shell标签的游戏物体
        if (other.tag == "Shell")
        {
            maxTop--;
            print(maxTop);
            if (maxTop == 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                Destroy(Instantiate(Resources.Load("ShellExplosion"), transform.position, Quaternion.identity), 1);
            }
           
        }
    }
}
