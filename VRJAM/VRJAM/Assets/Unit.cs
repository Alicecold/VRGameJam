using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public int myCurrentHp;
    public int myMaxHp;


    public void TakeDamage(int aDamage)
    {
        myCurrentHp -= aDamage;
        if (myCurrentHp == 0)
        {
            //Destory(this.gameobject);
        }
    }
}
