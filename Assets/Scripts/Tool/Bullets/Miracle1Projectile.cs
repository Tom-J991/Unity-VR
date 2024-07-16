using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miracle1Projectile : Bullet
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
            Debug.Log("Collision {Sin Tier: " + region.miracleTier + " }.{Level: " + m_level + "}");
            if (region.miracleTier == m_level)
            {
                Debug.Log("Striked Region {Sin Tier: " + region.miracleTier + " }.{Level: " + m_level + "}");
                region.StrikeMiracle();
            }
            else
            {
                region.ReturnEvent().score -= region.ReturnEvent().missMatchScore;
            }
        }

        Destroy(this.gameObject, impactSound.clip.length);
    }
}
