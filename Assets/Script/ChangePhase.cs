using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePhase : MonoBehaviour
{
    public Image image;
    private bool startFondue = false;

    public void hitAlduinFirstTime()
    {
        this.gameObject.GetComponentInParent<Gliding>().secondStep = true;
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
            if (image.color.a > 255) return;

            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.1f);
            if(image.color.a >= 255)
            {
                startFondue = false;
            }
        }
        else
        {
            if (image.color.a < 0) return;
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 1);
        }
    }
}
