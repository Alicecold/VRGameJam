using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GroupManager : MonoBehaviour
{

    public float myMovementSpeed;
    public float myDamping;
    public int myUnitID;
    public int myHealth;
    public int myDamage;
    public float myAttackRange;
    public float myAggroRange;
    public GameObject myStoneTarget;
    public GameObject myEnemyTarget;
    public List<GameObject> myEnemyStones;

    public bool myTeam; // True = white, false = black

    public bool myIsMoving;
    public Vector3 myDestination;

    private float myCurrentUpdateCooldown;
    private const float myUpdateCooldown = 0.2f;

    void Start()
    {
        myCurrentUpdateCooldown = 0.0f;
    }

    void Update()
    {
        if (myEnemyTarget == null)
        {
            if (myCurrentUpdateCooldown < 0)
            {
                FindTarget();
                if(myEnemyTarget == null)
                {
                    SetTargetToUnits(myStoneTarget);
                }
                myCurrentUpdateCooldown = myUpdateCooldown;
            }
            else
            {
                myCurrentUpdateCooldown -= Time.fixedDeltaTime;
            }
        }
        else
        {
            UnitManager unit = myEnemyTarget.GetComponent<UnitManager>();
            if(unit.IsDead() || (myEnemyTarget.transform.position - myStoneTarget.transform.position).magnitude < myAggroRange)
            {
                myEnemyTarget = null;
                myCurrentUpdateCooldown = -1.0f;
            }
        }
    }

    void FindTarget()
    {
        GameObject targetStone = FindClosestGroupTarget();
        if (targetStone == null)
        {
            return;
        }
        else
        {
            UnitManager[] units = targetStone.GetComponentsInChildren<UnitManager>();

            foreach (UnitManager unit in units)
            {
                if(unit.IsDead() == false)
                {
                    myEnemyTarget = unit.gameObject;
                    return;
                }
            }
        }
    }

    GameObject FindClosestGroupTarget()
    {
        GameObject selectedObject = null;

        foreach (GameObject go in myEnemyStones)
        {
            if ((go.transform.position - transform.position).magnitude < myAggroRange)
            {
                selectedObject = go;
                break;
            }
        }
        
        return selectedObject;
    }

    void SetTargetToUnits(GameObject aGameObject)
    {
        UnitManager[] units = GetComponentsInChildren<UnitManager>();

        foreach (UnitManager unit in units)
        {
            unit.SetTarget(aGameObject);
        }
    }
}
