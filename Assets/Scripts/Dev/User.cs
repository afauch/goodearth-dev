using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class User: MonoBehaviour {

    string userName;
    string userJob;
    string userAffiliation;
    List<Tag> tagList = new List<Tag>();
    List<GameObject> tagObjectList = new List<GameObject>();
    public GameObject tagPrefab;
    private GameObject rollUp;
    public int filterMatches;

    public int userId;
    UserData userData;

    private void Start()
    {
        GenerateUser();
    }


    //public method to generate user
    public void GenerateUser()
    {
        userData = QueryUserData.GetInstance().GetUserDataById(userId);
        tagList = userData.tagList;
        userName = userData.UserName;
        userJob = userData.Job;
        userAffiliation = userData.Affiliation;

        GenerateTag();
        GenerateName();
        GenerateJob();
        GenerateAffiliation();
        GenerateRollup();

        QueryUserData.GetInstance().AddUser(this);
    }

    //helper method: generate tags for this user and add to a tag list
    private void GenerateTag()
    {
        for (int i = 0; i < tagList.Count; i++)
        {
                GameObject tagObject = Instantiate(tagPrefab, this.transform) as GameObject;
                tagObject.transform.localPosition = new Vector3(tagObject.transform.localPosition.x, (tagObject.transform.localPosition.y - i * (GlobalUISettings.Instance._tagSpacing)), tagObject.transform.localPosition.z);
                // TODO: Clean this up to get a 'TagObject' component and put the property there.
                tagObject.GetComponent<MatchSize>().SetText(tagList[i].Content);
                tagObjectList.Add(tagObject);
        }
    }

    //helper method: generate name object for this user
    private void GenerateName()
    {
        GameObject nameObject = Instantiate(GlobalUISettings.Instance.namePrefab, this.transform) as GameObject;
        nameObject.GetComponent<TextMesh>().text = userName;
    }

    private void GenerateJob()
    {
        GameObject jobObject = Instantiate(GlobalUISettings.Instance.jobPrefab, this.transform) as GameObject;
        jobObject.GetComponent<TextMesh>().text = userJob;
    }

    private void GenerateAffiliation()
    {
        GameObject affObject = Instantiate(GlobalUISettings.Instance.affPrefab, this.transform) as GameObject;
        affObject.GetComponent<TextMesh>().text = userAffiliation;
    }

    private void GenerateRollup()
    {
        rollUp = Instantiate(GlobalUISettings.Instance.rollupPrefab, this.transform) as GameObject;
        rollUp.GetComponent<TextMesh>().text = filterMatches.ToString() + " matching tags";
    }

    //show tags in this user based on selected tag list from local user
    public void TurnOnFilter(List<Tag> tList)
    {

        // Reset filter matches
        filterMatches = 0;

        foreach (GameObject to in tagObjectList)
        {
            // to.SetActive(false);
            to.SetState(CrayonStateType.Default);
        }

        // Cycle through tags to see if there's a match
        foreach (GameObject to in tagObjectList)
        {
            Tag myTag = this.tagList[tagObjectList.IndexOf(to)];

            foreach(Tag t in tList)
            {
                if(t.Content == myTag.Content)
                {
                    // to.SetActive(true);
                    to.SetState(CrayonStateType.Selected);
                    filterMatches += 1;
                }
            }

        }

        UpdateRollup();

    }

    //show all tags in this user
    public void TurnOffFilter()
    {
        // Reset filter matches
        filterMatches = 0;

        foreach (Tag t in tagList)
        {
            GameObject to = tagObjectList[tagList.IndexOf(t)];
            to.SetState(CrayonStateType.Default);
        }

        UpdateRollup();
    }

    public void UpdateRollup()
    {
        Debug.Log("Current filtermatches = " + filterMatches);
        Debug.Log("Update Rollup called");
        if (filterMatches > 0)
        {
            if (filterMatches == 1)
            {
                rollUp.GetComponent<TextMesh>().text = filterMatches.ToString() + " matching tag";
            } else
            {
                rollUp.GetComponent<TextMesh>().text = filterMatches.ToString() + " matching tags";
            }
            rollUp.GetComponent<TextMesh>().color = GlobalUISettings.Instance._rollupMatchColor;
        } else
        {
            rollUp.GetComponent<TextMesh>().text = "No matching tags";
            rollUp.GetComponent<TextMesh>().color = GlobalUISettings.Instance._rollupDefaultColor;
        }

    }

}
