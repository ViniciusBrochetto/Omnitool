using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageChangeController : MonoBehaviour
{

    public Image imgLv1, imgLv2, imgLv3, imgLv4, imgLv5;

    public Image currSelected;
    public int level;

    public void Start()
    {
        currSelected = imgLv1;
    }

    public void SetLevel(int l)
    {
        level = l;
    }

    public void ChangeImage()
    {
        currSelected.enabled = false;

        switch (level)
        {
            case 1:
                currSelected = imgLv1;
                break;
            case 2:
                currSelected = imgLv2;
                break;
            case 3:
                currSelected = imgLv3;
                break;
            case 4:
                currSelected = imgLv4;
                break;
            case 5:
                currSelected = imgLv5;
                break;
            default:
                currSelected = imgLv1;
                break;
        }

        currSelected.enabled = true;
    }
}
