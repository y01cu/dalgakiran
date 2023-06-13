using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PostBoxController : MonoBehaviour
{

    // This class used to be child of Post class.

    // Is SetParent method obsolete?

    public GameObject pfPostBoxText;
    public GameObject pfPostBoxImage;
    public GameObject pfPostBoxVideo;

    public GameObject initialPostBox;

    private int postTextIndex = 0;

    List<GameObject> postsList = new List<GameObject>();
    List<string> postTexts = new List<string>();

    private bool isPostCointingImage = false;
    public Image imageSpriteToPost;

    public Image iconToAddImageOrNot;
    public Sprite imageIconSprite;
    public Sprite textIconSprite;

    private bool isIconImage = true;

    private void Start()
    {
        // SettingsManager texts here:
        SetTexts();
    }

    public void AddImageToPost()
    {
        imageSpriteToPost.gameObject.SetActive(true);
        isPostCointingImage = true;
    }

    public void RemoveImageFromPost()
    {
        imageSpriteToPost.gameObject.SetActive(false);
        isPostCointingImage = false;
    }

    public void ChangeSpriteIcon()
    {
        // Is the icon on the left bottom image or not:
        if (isIconImage)
        {
            AddImageToPost();
            iconToAddImageOrNot.sprite = textIconSprite;
            isIconImage = false;
            return;
        }
        RemoveImageFromPost();
        iconToAddImageOrNot.sprite = imageIconSprite;
        isIconImage = true;

    }

    public void ChangeToImagePost()
    {
        GameObject newInitialImagePost = Instantiate(pfPostBoxImage);
        newInitialImagePost.transform.position = initialPostBox.transform.position;

    }

    public void ChangeToTextPost()
    {
        GameObject newInitialTextPost = Instantiate(pfPostBoxText);
    }


    public void SendVideoPost()
    {

    }

    public void SendPost()
    {
        if (isPostCointingImage)
        {
            SendImagePost();
        }
        else
        {
            SendTextPost();
        }
    }

    public void SendImagePost()
    {
        GameObject newPost = Instantiate(pfPostBoxImage);
        newPost.transform.parent = initialPostBox.transform;


        Vector3 newPositionValues = new Vector3(0, -350, 0);
        newPost.transform.localPosition = newPositionValues;

        // We can print its own quaternion value if the code below doesn't work:
        newPost.transform.rotation = new Quaternion(0, 0, 0, 0);

        newPost.transform.localScale = new Vector3(1, 1, 1);

        //y-170, x-400

        postsList.Add(newPost);

        UpdatePostsPosition();
    }

    public void SendTextPost()
    {
        // Textbox needs to be sent, button needs to be disabled. 
        // Initial textbox needs to be cleared. New one needs to be initialized and sent
        // Instantiated a new G.O. and set its parent as below.
        GameObject newPost = Instantiate(pfPostBoxText);
        newPost.transform.parent = initialPostBox.transform;

        Vector3 newPositionValues = new Vector3(0, -350, 0);
        newPost.transform.localPosition = newPositionValues;

        // We can print its own quaternion value if the code below doesn't work:
        newPost.transform.rotation = new Quaternion(0, 0, 0, 0);

        newPost.transform.localScale = new Vector3(1, 1, 1);

        //y-170, x-400
        //newPost.transform.rotation = initialPostBox.GetComponent<Transform>();
        // Prefab position in the world space should be same with the PostBox_Text_Initial then -50 in X, -20 in Y

        postsList.Add(newPost);

        UpdatePostsPosition();

    }

    private void UpdatePostsPosition()
    {

        float newYValue;
        Vector3 newTransformPosition;


        Debug.Log(postsList.Count);

        for (int i = 0; i < postsList.Count - 1; i++)
        {
            // Should I use local position all code below in this scope.


            // y - 170 probably will be used.
            newYValue = postsList[i].transform.localPosition.y - 360;
            //newYValue = postsList[i].transform.position.y - 170;
            newTransformPosition = new Vector3(transform.localPosition.x, newYValue, transform.localPosition.z);
            postsList[i].transform.localPosition = newTransformPosition;
        }


        //    float newYValue = postsList[i].transform.position.y - 360;
        //    Vector3 newTransformPosition = new Vector3(transform.position.x, newYValue, transform.position.z);
        //    postsList[i].transform.position = newTransformPosition;
        //}

    }

    private void SetTexts()
    {
        for (int i = 0; i < 10; i++)
        {
            postTexts.Add($"Text {i}");
        }
        pfPostBoxText.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[0].ToString();
        pfPostBoxImage.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[0].ToString();
        initialPostBox.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[0].ToString();
    }

    public void NextText()
    {
        postTextIndex += 1;
        postTextIndex %= 10;

        pfPostBoxText.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[postTextIndex].ToString();
        pfPostBoxImage.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[postTextIndex].ToString();
        initialPostBox.GetComponentInChildren<TextMeshProUGUI>().text = postTexts[postTextIndex].ToString();

    }


}
