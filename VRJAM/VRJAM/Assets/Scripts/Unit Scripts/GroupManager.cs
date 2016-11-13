using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GroupManager : MonoBehaviour
{
    public float myMovementSpeed;
    public int myUnitID;
    public int myHealth;
    public int myDamage;
    public float myAttackRange;
    public float myAggroRange;

    public float myAttackCooldown;

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
                    SetTargetToUnits(myStoneTarget, eState.NORMAL);
                }
                else
                {
                    SetTargetToUnits(myEnemyTarget, eState.ATTACK);
                }
                myCurrentUpdateCooldown = myUpdateCooldown;
            }
            else
            {
                myCurrentUpdateCooldown -= Time.deltaTime;
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

        UnitManager[] units = GetComponentsInChildren<UnitManager>();
        if(units.Length == 0)
        {
            Destroy(this.gameObject);
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
            UnitManager[] units = targetStone.transform.parent.GetComponentsInChildren<UnitManager>();

            foreach (UnitManager unit in units)
            {
                if(unit != null && unit.IsDead() == false)
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

        Vector3 position = myStoneTarget.transform.position;
        position.y = 0;

        for (int i = myEnemyStones.Count - 1; i < 0; i--)
        {
            if(myEnemyStones[i] == null)
            {
                myEnemyStones.RemoveAt(i);
            }
        }

        foreach (GameObject go in myEnemyStones)
        {
            if(go == null)
            {
                break;
            }
            Vector3 goPosition = go.transform.position;
            goPosition.y = 0;

            if ((goPosition - position).magnitude < myAggroRange)
            {
                selectedObject = go;
                break;
            }
        }
        
        return selectedObject;
    }

    void SetTargetToUnits(GameObject aGameObject, eState aState)
    {
        UnitManager[] units = GetComponentsInChildren<UnitManager>();

        foreach (UnitManager unit in units)
        {
            unit.SetTarget(aGameObject);
            unit.SetState(aState);
        }
    }
}
