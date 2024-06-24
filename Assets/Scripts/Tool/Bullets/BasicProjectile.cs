using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Bullet
{

    public override void Insialize(Type type, int level, GameObject gun, Manager manager)
    {
        base.Insialize(type, level, gun, manager);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        PopUp pop = collision.gameObject.GetComponent<PopUp>();

        if (pop.Level == m_level)
        {
            if (pop.m_type == m_typeCurrent)
            {
                m_manager.ReturnScore().Sin(m_level * -3);
                m_manager.ReturnScore().Pray(m_level * 3);
                Destroy(collision.gameObject);
            }
            else if (pop.m_type != m_typeCurrent)
            {
                m_manager.ReturnScore().Sin(m_level * 3);
                m_manager.ReturnScore().Pray(m_level * -3);
                Destroy(collision.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
}
