using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int myDamage;

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.tag == "Units")
        {
            aCol.gameObject.GetComponent<SingleUnit>().TakeDamage(myDamage);
        }

        //myBloodEffect.SetActive(true);
    }
}
