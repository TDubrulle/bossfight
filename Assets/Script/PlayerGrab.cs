using UnityEngine;
using System.Collections;

public class PlayerGrab : MonoBehaviour {

    public int maxStamina = 2000;
    private int stamina;
    private bool hanging = false;
    private int canHangItself = 0;
    private bool canMove = true;
    private PlayerControler pc;
    private PlayerAttack pa;

	// Use this for initialization
	void Start () {
        stamina = maxStamina;

        pc = this.gameObject.GetComponent<PlayerControler>();
        pa = this.gameObject.GetComponent<PlayerAttack>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "HangingPoint")
        {
            canHangItself++;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "HangingPoint")
        {
            canHangItself--;
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
	
	// Update is called once per frame
	void Update () {
	    
        if(canHangItself > 0 && canMove)
        {
            if(Input.GetButton("Hang"))
            {
                pc.cantMove();
                pa.cantMove();

                hanging = true;
                stamina--;
            }

            if(Input.GetButtonUp("Hang") || stamina == 0 )
            {
                hanging = false;

                pc.freeMove();
                pa.freeMove();
            }
        }
        
        if(!hanging && stamina < maxStamina)
        {
            stamina++;
        }

	}
}
