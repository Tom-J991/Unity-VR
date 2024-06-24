using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : Tool
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
        bullet.AddComponent<PlaugeProjectile>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<PlaugeProjectile>();

        Vector3 direction = m_bulletPos.transform.TransformDirection(Vector3.forward);
        bulletRb.AddForce(direction * m_speed);
        bulletScript.Insialize(currentType, m_level, this.gameObject, m_manager);

        Destroy(bullet, 5f);
    }
}
