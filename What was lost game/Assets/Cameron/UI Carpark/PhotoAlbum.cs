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

    // Change the photo display based on position in array & either display or hide a mask if the photo has been 'unlocked'
    public void UpdatePhoto()
    {
        gameObject.GetComponent<Image>().sprite = photos[imageNum];

        if (photoFound[imageNum])
        {
            photoMask.SetActive(false);
        }
        else if (!photoFound[imageNum])
        {
            photoMask.SetActive(true);
        }
    }

    // Change to the previous photo in array
    public void PrevPhoto()
    {
        imageNum = imageNum - 1;
        UpdatePhoto();
    }

    // Change to the next photo in array
    public void NextPhoto()
    {
        imageNum = imageNum + 1;
        UpdatePhoto();
    }

    // Display or hide previous & next button based on position in photo array
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

        if (imageNum == photos.Length - 1)
        {
            nextPhoto.SetActive(false);
        }
        else
        {
            nextPhoto.SetActive(true);
        }

    }
}