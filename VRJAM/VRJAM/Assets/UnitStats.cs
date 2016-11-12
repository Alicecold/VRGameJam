using UnityEngine;
using System.Collections;

public class UnitStats : MonoBehaviour
{
    int myUnitID;
    int myHealth;
    int mySpeed;
    int myDamage;
    bool myIsRanged;

    void start()
    {
        myUnitID = 1;
        myHealth = 1;
        mySpeed = 1;
        myDamage = 1;
        myIsRanged = false;
    }

    void update()
    {

    }
}
