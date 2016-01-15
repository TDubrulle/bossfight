using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private bool canMove = true;
    public AudioClip stepOne;
    public AudioClip stepTwo;
    public AudioSource music;
    public MenuScript menus;
    private Vector3 initPos;
    private Quaternion initRot;
    private PlayerControler pc;
    private PlayerGrab pg;
    private Animator anim;
    private Collider weakPoint = null;
    private int timesHit = 0;
    private bool secondStep = false;
    private bool deadStep = false;

    void Awake()
    {
        initPos = this.transform.position;
        initRot = this.transform.rotation;
        music.clip = stepOne;
        music.Play();
    }

	// Use this for initialization
	void Start () {
        pc = this.gameObject.GetComponent<PlayerControler>();
        pg = this.gameObject.GetComponent<PlayerGrab>();
        anim = this.gameObject.GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "WeakPoint")
        {
            weakPoint = col;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "WeakPoint")
        {
            weakPoint = null;
        }
    }

    public void cantMove()
    {
        canMove = false;
    }

    public void freeMove()
    {
        canMove = true;
    }

    public void attackEnd(string msg)
    {
        if (msg == "endAttack")
            attacking = false;

        if(secondStep)
        {
            weakPoint.GetComponentInParent<ChangePhase>().hitAlduinFirstTime();
            this.transform.position = initPos;
            this.transform.rotation = initRot;
            music.clip = stepTwo;
            music.Play();
        }

        if(deadStep)
        {
            weakPoint.GetComponentInParent<ChangePhase>().hitAlduinSecondTime();
            menus.winGame();
            music.Stop();
            this.transform.position = initPos;
            this.transform.rotation = initRot;
            timesHit = 0;
            secondStep = false;
            deadStep = false;
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
	    
        if(canMove)
        {
            if(Input.GetButtonDown("Attack") && !attacking)
            {
                pc.stopMovement();
                pc.cantDoAnAction();
                pg.cantMove();

                anim.SetBool("attacking", true);

                attacking = true;

                if(weakPoint != null)
                {
                    if(timesHit == 1)
                    {
                        deadStep = true;
                        secondStep = false;
                        timesHit++;
                    }

                    if(timesHit == 0)
                    {
                        secondStep = true;
                        timesHit++; 
                    }
                }
            }

            if(!attacking)
            {

                anim.SetBool("attacking", false);

                pc.freeAction();
                pg.freeMove();
            }
        }

	}
}
