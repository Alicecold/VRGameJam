using UnityEngine;

public class SingleUnit : MonoBehaviour
{
    private GameObject myObject;

    public int myCurrentHp;
    public int myMaxHp;


    private void Start()
    {
        myObject = this.gameObject;
    }

    public void TakeDamage(int aDamage)
    {
        myCurrentHp -= aDamage;
        if (myCurrentHp <= 0)
        {
            Destroy(myObject);
        }
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.tag == "Arrow")
        {
            TakeDamage(aCol.gameObject.GetComponent<Arrow>().myDamage);
        }

        //myBloodEffect.SetActive(true);
    }
}
