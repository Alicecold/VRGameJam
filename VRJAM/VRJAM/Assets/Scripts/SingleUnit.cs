using UnityEngine;
using System.Collections;

public class SingleUnit : MonoBehaviour
{
    public int myCurrentHp;
    public int myMaxHp;


    public void TakeDamage(int aDamage)
    {
        myCurrentHp -= aDamage;
        if (myCurrentHp == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
