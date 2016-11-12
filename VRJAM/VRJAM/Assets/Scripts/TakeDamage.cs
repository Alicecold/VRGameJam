using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour
{
    public int myDamage;

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.tag == "Unit")
        {
            aCol.gameObject.GetComponent<SingleUnit>().TakeDamage(myDamage);
        }

        //myBloodEffect.SetActive(true);
    }
}
