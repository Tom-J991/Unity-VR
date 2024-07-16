using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeProjectile : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Initialize(int level, GameObject gun)
    {
        base.Initialize(level, gun);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        impactSound.Play();

        Region region = RevolutionTrigger.GetRegionFromParent(collision.gameObject.transform);
        if (region != null && region.sinTier == m_level)
        {
            region.plagued = true;
        }
        else
        {
            region.ReturnEvent().score -= region.ReturnEvent().missMatchScore;
        }

        Destroy(this.gameObject, impactSound.clip.length);
    }
}
