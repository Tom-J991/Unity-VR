using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class SpawnEvent : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] Vector3 m_multiplier;
    [SerializeField] List<Material> mats = new();
    public void SpawnPopUp(Transform random, Manager mana)
    {
        Vector3 newPos = new Vector3(
            Random.Range(random.position.x - m_multiplier.x, random.position.x + m_multiplier.x), 
            Random.Range(random.position.y - m_multiplier.y, random.position.y + m_multiplier.y), 
            random.position.z);

        Vector3 tempPos = new Vector3(newPos.x, newPos.y, newPos.z - 1);
        RaycastHit hit;

        if(Physics.Raycast(tempPos, transform.TransformDirection(Vector3.forward), out hit))
        {

            if (hit.collider.tag == "Continent")
            {
                Debug.DrawRay(tempPos, transform.TransformDirection(Vector3.forward));

                GameObject a = Instantiate(prefab, hit.point, transform.rotation);

                MeshRenderer material = a.GetComponent<MeshRenderer>();
                PopUp pop = a.GetComponent<PopUp>();

                mana.Pop = pop;
                
                pop.Level = Random.Range(1, 3);
                a.transform.localScale = new Vector3(pop.Level * 0.3f, pop.Level * 0.3f, pop.Level * 0.3f);

                float type = Random.Range(1, 3);
                switch (type)
                {
                    case 1:
                        pop.m_type = Type.sinner;
                        material.material = mats[0];
                        break;
                    case 2:
                        pop.m_type = Type.prayer;
                        material.material = mats[1];
                        break;
                }
            }
            else
                SpawnPopUp(random, mana);
        }
    }
}
