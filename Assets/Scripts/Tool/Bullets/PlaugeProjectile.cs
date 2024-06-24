using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeProjectile : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Insialize(Type type, int level, GameObject gun, Manager manager)
    {
        base.Insialize(type, level, gun, manager);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        RaycastHit[] hit = Physics.SphereCastAll(this.gameObject.transform.position, 2, transform.forward);

        foreach (RaycastHit cas in hit)
        {
            if (cas.collider.gameObject.GetComponent<PopUp>())
            {
                cas.collider.gameObject.GetComponent<PopUp>().Plagued = true;
            }

        }
        Destroy(this.gameObject);
    }
}
