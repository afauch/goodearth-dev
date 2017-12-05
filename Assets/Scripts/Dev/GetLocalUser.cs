using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class GetLocalUser : MonoBehaviour {

    public GameObject tagPrefab;
    string userName;
    List<Tag> tagList = new List<Tag>();
    List<GameObject> tagObjectList = new List<GameObject>();
    public List<TagObject> selectedTagObjects { get; private set; }
    public GameObject name;
    public GameObject tagParent;

    public int userId;
    UserData userData;

    private void Start()
    {
        GenerateUser();
    }

    private void GenerateUser()
    {
        userData = QueryUserData.GetInstance().GetUserDataById(userId);
        tagList = userData.tagList;
        userName = userData.UserName;
        selectedTagObjects = new List<TagObject>();

        GenerateFunctionalTag();
        GenerateName();
    }

    private void GenerateFunctionalTag()
    {
        for (int i = 0; i < tagList.Count; i++)
        {
            GameObject tagObject = Instantiate(tagPrefab, tagParent.transform) as GameObject;
            tagObject.transform.localPosition = new Vector3(tagObject.transform.localPosition.x, (tagObject.transform.localPosition.y - i * (GlobalUISettings.Instance._tagSpacing)), tagObject.transform.localPosition.z);
            tagObject.GetComponent<MatchSize>().SetText(tagList[i].Content);

            tagObject.AddComponent<TagObject>();
            tagObject.GetComponent<TagObject>().myTag = tagList[i];
            tagObject.GetComponent<TagObject>().userId = userId;

            tagObjectList.Add(tagObject);
        }
    }

    private void GenerateName()
    {
        name.GetComponent<TextMesh>().text = userName;
    }

    public void ShowMatchedTag()
    {
        Debug.Log("ShowMatchedTag called");
        foreach(GameObject to in tagObjectList)
        {
            to.GetComponent<TagObject>().SelectTag(true);
            to.SetState(CrayonStateType.Selected);
            //selectedTagObjects.Add(to.GetComponent<TagObject>());
            //print(to.GetComponent<TagObject>().myTag.Content);
        }

        SendFilterRequest();
    }

    public void ClearFilter()
    {
        foreach (GameObject to in tagObjectList)
        {
            to.GetComponent<TagObject>().SelectTag(false);
            to.SetState(CrayonStateType.Default);
        }
        SendFilterRequest();
    }

    public void SendFilterRequest()
    {
        Debug.Log("SendFilterRequest called");

        List<Tag> selectedTags = new List<Tag>();

        foreach(TagObject to in selectedTagObjects)
        {
            if(!selectedTags.Contains(to.myTag))
                selectedTags.Add(to.myTag);
        }

        List<User> allUser = QueryUserData.GetInstance().GetOtherUser(userId);
        foreach (User u in allUser)
        {
            if(selectedTagObjects.Count == 0)
            {
                u.TurnOffFilter();
            }
            else
            {
                u.TurnOnFilter(selectedTags);
            }
        }



    }
}
