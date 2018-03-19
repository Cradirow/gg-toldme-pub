using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TVNT
{
    public class ArrowNormalAttack : WeaponController
    {
        void Start()
        {
            damage = GetComponentInParent<WeaponController>().damage;
        }
        void Update()
        {
            transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);
            //빗나갔을 경우 2�?????��
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Monster")
            {
                //Debug.Log("arrow attack!!");
                if (other.GetComponent<TVNTCharacterController>().lives >= 5)
                {
                    other.GetComponent<TVNTCharacterController>().lives -= damage;
                    other.GetComponent<MonsterAIController>().threatenTime = 0;
                }
                if (other.GetComponent<TVNTCharacterController>().lives < 5 && other.GetComponent<TVNTCharacterController>().lives > 2)
                {
                    other.GetComponent<TVNTCharacterController>().lives -= damage;
                    other.GetComponent<MonsterAIController>().threatenTime = 0;
                    other.GetComponent<MonsterAIController>().SetSituation(MonsterAIController.Situation.MONSTERDEAD);
                }
                else
                {
                    other.GetComponent<MonsterAIController>().CharacterDead();
                    //other.gameObject.SetActive(false);
                }
                GameObject.Destroy(gameObject);
            }
        }
    }
}
