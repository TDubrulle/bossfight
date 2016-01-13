using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private bool canMove = true;
    private PlayerControler pc;
    private PlayerGrab pg;

	// Use this for initialization
	void Start () {
        pc = this.gameObject.GetComponent<PlayerControler>();
        pg = this.gameObject.GetComponent<PlayerGrab>();
	}

    void OnCollisionEnter(Collision col)
    {

    }

    void OnCollisionExit(Collision col)
    {

    }

    public void cantMove()
    {
        canMove = false;
    }

    public void freeMove()
    {
        canMove = true;
    }
	
	// Update is called once per frame
	void Update () {
	    
        if(canMove)
        {
            if(Input.GetButtonDown("Attack"))
            {
                //pc.cantMove();
                //pg.cantMove();

                attacking = true;
            }

            if(!attacking)
            {
                pc.freeMove();
                pg.freeMove();
            }
        }

	}
}
