using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CreepController : MonoBehaviour {


    Transform targetPosition;
    [SerializeField]
    float speedAnimWalk = 1;

    private NavMeshAgent agent;
    private Animator anim;
    private float defaultSpeedAnim;
    //private CreepHP creepHP;
	void Start ()
    {
       // creepHP = gameObject.GetComponent<CreepHP>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        defaultSpeedAnim = anim.speed;
    }
	
	void Update()
    {
        try
        {
            if(agent.velocity.magnitude>0)
            {
                anim.SetBool("isWalk", true);
                anim.speed = speedAnimWalk;
            } else
            {
                anim.SetBool("isWalk", false);
                anim.speed = defaultSpeedAnim;
            }

            if(agent.remainingDistance>0 && agent.remainingDistance < 1)
            {
                Destroy(gameObject);
                //creepHP.SetHP(0);                
            }

        }
        catch
        {
                Debug.LogError("Set destination for creep");
        }
        
	}

    public void SetTargetPos(Transform value)
    {
        targetPosition = value;
        ResetTargetPos();
    }
    
    public void ResetTargetPos()
    {
        GetComponent<NavMeshAgent>().SetDestination(targetPosition.position);
    }

  
}
