using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public int ability;
    private bool pickable = false;
    public GameObject thisObject;

    private void Start()
    {
        StartCoroutine(timePickUp());
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Car" && pickable == true)
        {
            switch(ability)
            {
                case 1:
                    GameMaster.Instance.AddBulletSpeed(1f);
                    UIManager.Instance.ActivateAbilityText("speed");
                    break;
                case 2:
                    GameMaster.Instance.ReduceBulletRecoil(0.05f);
                    UIManager.Instance.ActivateAbilityText("firespeed");
                    break;
                case 3:
                    GameMaster.Instance.SetCurrentAbility("shield");
                    UIManager.Instance.ActivateAbilityText("shield");
                    UIManager.Instance.SetAbilitySlot("shield");
                    break;
            }

            MuiscManager.Instance.PlayShotAbilityPickUp();
            Destroy(thisObject);
        }
    }

    private IEnumerator timePickUp()
    {
        yield return new WaitForSeconds(1f);
        pickable = true;
    }
}
