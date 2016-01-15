using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePhase : MonoBehaviour
{
    public Image image;
    private bool startFondue = false;

    public void hitAlduinFirstTime()
    {
        this.gameObject.GetComponentInParent<Gliding>().startSecondPhase();
        startFondue = true;
    }
    public void hitAlduinSecondTime()
    {
        this.gameObject.GetComponentInParent<Gliding>().secondStep = false;
    }

    void Update()
    {
        if (startFondue)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
            if(image.color.a >= 1.0f)
            {
                startFondue = false;
            }
        }
        else
        {
            if (image.color.a <= 0.0f) return;
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
        }
    }
}
