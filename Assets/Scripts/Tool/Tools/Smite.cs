using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : Tool
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    public override void Shot()
    {
        base.Shot();

        GameObject bullet = Instantiate(m_bulletPrefab, m_bulletPos.position, m_bulletPos.rotation);
        bullet.AddComponent<BasicProjectile>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<BasicProjectile>();

        bulletScript.impactSound.clip = m_impactSound;

        bulletScript.travelSound.clip = m_travelSound;

        Vector3 direction = m_bulletPos.transform.TransformDirection(Vector3.forward);
        bulletRb.AddForce(direction * m_speed);
        bulletScript.Initialize(m_level, this.gameObject);

        Destroy(bullet, 5f);
    }
}
