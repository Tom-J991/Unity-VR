using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleWandProjectile : Bullet
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

        Region region = RevolutionTrigger.GetRegionFromParent(collision.gameObject.transform);
        if (region != null && region.miracleTier == m_level)
        {
            foreach (Region neighbor in region.neighbors)
            {
                neighbor.SetBeliefTier(0);
            }
            region.SetBeliefTier(0);
        }

        Destroy(this.gameObject);
    }
}
