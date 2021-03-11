using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoAlbum : MonoBehaviour
{
    public RectTransform parentPanel;
    public Sprite[] photos;
    public int imageNum;
    public GameObject prevPhoto, nextPhoto, photoMask;

    public bool[] photoFound;

    private void Start()
    {
        photoMask = GameObject.Find("Photo_Mask");
        photoFound = new bool[photos.Length];

        imageNum = 0;

        UpdatePhoto();
    }

    public void UpdatePhoto()
    {
        gameObject.GetComponent<Image>().sprite = photos[imageNum];

        if (photoFound[imageNum])
        {
            photoMask.SetActive(false);
        } else if (!photoFound[imageNum])
        {
            photoMask.SetActive(true);
        }
    }

    public void PrevPhoto()
    {
        imageNum = imageNum-1;
        UpdatePhoto();
    }

    public void NextPhoto()
    {
        imageNum = imageNum+1;
        UpdatePhoto();
    }

    private void Update()
    {
        if (imageNum == 0)
        {
            prevPhoto.SetActive(false);
        }
        else
        {
            prevPhoto.SetActive(true);
        }

        if (imageNum == photos.Length -1)
        {
            nextPhoto.SetActive(false);
        }
        else
        {
            nextPhoto.SetActive(true);
        }

    }
}
