using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : Tool
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
        bullet.AddComponent<TridentProjectile>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<TridentProjectile>();

        Vector3 direction = m_bulletPos.transform.TransformDirection(Vector3.forward);
        bulletRb.AddForce(direction * m_speed);
        bulletScript.Initialize(m_level, this.gameObject);

        Destroy(bullet, 5f);
    }
}
