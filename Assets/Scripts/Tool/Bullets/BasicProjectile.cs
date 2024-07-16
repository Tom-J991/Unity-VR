using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Bullet
{

    public override void Initialize(int level, GameObject gun)
    {
        base.Initialize(level, gun);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        impactSound.Play();

        Region region = RevolutionTrigger.GetRegionFromParent(collision.gameObject.transform);
        if (region != null)
        {
            Debug.Log("Collision {Sin Tier: " + region.sinTier + " }.{Level: " + m_level + "}");
            if (region.sinTier == m_level)
            {
                Debug.Log("Striked Region {Sin Tier: " + region.sinTier + " }.{Level: " + m_level + "}");
                region.StrikeSin();
                //Destroy(collision.gameObject);
            }
            else 
            {
                region.ReturnEvent().score -= region.ReturnEvent().missMatchScore;
            }
        }

        Destroy(this.gameObject, impactSound.clip.length);
    }
}
