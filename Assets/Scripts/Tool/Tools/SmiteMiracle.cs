using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteMiracle : Tool
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    public override void Shot()
    {
        base.Shot();

        shoot.Play();

        GameObject bullet = Instantiate(m_bulletPrefab, m_bulletPos.position, m_bulletPos.rotation);
        bullet.AddComponent<Miracle1Projectile>();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<Miracle1Projectile>();

        Vector3 direction = m_bulletPos.transform.TransformDirection(Vector3.forward);
        bulletRb.AddForce(direction * m_speed);
        bulletScript.Initialize(m_level, this.gameObject);

        bulletScript.impactSound.clip = m_impactSound;

        bulletScript.travelSound.clip = m_travelSound;

        bulletScript.travelSound.Play();

        Destroy(bullet, 5f);
    }
}
