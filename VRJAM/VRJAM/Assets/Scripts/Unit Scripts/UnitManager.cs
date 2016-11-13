using UnityEngine;
using System.Collections;

public enum eState
{
    NORMAL,
    ATTACK,
    DEAD
}

public class UnitManager : MonoBehaviour
{
    public GameObject myFuturePoint;

    private float myMovementSpeed;
    private float myDamping;
    private int myUnitID;
    private int myHealth;
    private int myDamage;
    private float myAttackRange;

    private ParticleSystem myParticles;

    private bool myTeam; // True = white, false = black
    private bool myIsMoving;
    private Vector3 myDestination;
    private eState myState;
    private float myAttackCooldown;
    private float myCurrentCooldown;

    GameObject myTarget;

    public void SetState(eState aState)
    {
        myState = aState;
    }
    public void SetTarget(GameObject aTarget)
    {
        myTarget = aTarget;
    }

    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        GroupManager InitSettings = transform.parent.gameObject.GetComponent<GroupManager>();
        myMovementSpeed = InitSettings.myMovementSpeed / 5;
        myDamping = InitSettings.myDamping;
        myUnitID = InitSettings.myUnitID;
        myHealth = InitSettings.myHealth;
        myDamage = InitSettings.myDamage;
        myAttackRange = InitSettings.myAttackRange;
        myAttackCooldown = InitSettings.myAttackCooldown;
        myCurrentCooldown = myAttackCooldown;

        myTeam = InitSettings.myTeam;
        myState = eState.NORMAL;

        myTarget = InitSettings.myStoneTarget;
    }

    void NormalState()
    {
        MoveToDestination();
    }

    void AttackState()
    {
        if (MoveToDestination())
        {
            Attack();
        }
    }
    void DeadState()
    {

    }

    void Attack()
    {
        if (myCurrentCooldown <= 0)
        {
            if (myTarget != null)
            {
                UnitManager enemyUnit = myTarget.GetComponent<UnitManager>();

                if (enemyUnit != null && !enemyUnit.IsDead())
                {
                    enemyUnit.TakeDamage(myDamage);
                    myCurrentCooldown = myAttackCooldown;
                }
            }
        }
        else
        {
            myCurrentCooldown -= Time.deltaTime;
        }
    }


    public void TakeDamage(int someDamage)
    {
        if (!IsDead())
        {
            myHealth -= someDamage;
            if (myHealth <= 0)
            {
                myState = eState.DEAD;
                Destroy(this.gameObject);
            }
        }
    }
    public bool IsDead()
    {
        if (myState == eState.DEAD)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        switch (myState)
        {
            case eState.NORMAL:
                NormalState();
                break;
            case eState.ATTACK:
                AttackState();
                break;
            case eState.DEAD:
                myParticles.Play();
                DeadState();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.tag == "Arrow")
        {
            TakeDamage(aCol.gameObject.GetComponent<Arrow>().myDamage);
        }
    }

    //Returns true if destination reached
    bool MoveToDestination()
    {
        myDestination = myTarget.transform.position;
        myDestination.y = 0;
        Vector3 position = transform.position;
        position.y = 0;
        if ((myDestination - position).magnitude < 2)
        {
            myIsMoving = false;
            return true;
        }
        else
        {
            Vector3 direction = Vector3.MoveTowards(position, myDestination, Time.fixedDeltaTime * myMovementSpeed);
            transform.position = direction;
            Vector3 lookPos = myDestination - position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * myDamping);
            return false;
        }
    }
}

