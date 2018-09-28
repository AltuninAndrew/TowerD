using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreep : MonoBehaviour {

    [SerializeField]
    List<Transform> targetPoints = new List<Transform>();
    [SerializeField]
    private float speedRotation = 2, speedMove = 1,speedAnim = 1;


    public float distToTargPos {get; private set;}
    public bool isMove { get; set; }
    private Quaternion lookRotation;
    private int index = 0;
    private Animator anim;
    void Start()
    {
        isMove = true;
        anim = GetComponent<Animator>();
        anim.speed *= speedAnim;
    }

    void Update()
    {
        if(isMove&&(targetPoints.Count>0))
        {
            distToTargPos = Vector3.Distance(transform.position, targetPoints[index].position);
            if (distToTargPos <= 0)
            {
                index++;
            }
            if (index < targetPoints.Count)
            {
                lookRotation = Quaternion.LookRotation(targetPoints[index].position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speedRotation);
                transform.position = Vector3.MoveTowards(transform.position, targetPoints[index].position, speedMove * Time.deltaTime);
                anim.SetBool("isWalk", true);

            }
            else
            {
                isMove = false;
                anim.SetBool("isWalk", false);
                Destroy(gameObject);
            }

        }
    }

    public void SetTargetPoints(List<Transform> targP)
    {
        targetPoints = targP;
    }

    



   


}
