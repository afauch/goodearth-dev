using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class QueryUserData : MonoBehaviour
{
    private static QueryUserData instance = null;

    private string url = "https://spreadsheets.google.com/feeds/list/";
    private const string key = "1Whb0SqBW6D51rzOOX2XiqDrB4lhgtxCmjknVSHiEevU";
    private string urlp2 = "/1/public/values?alt=json";

    private List<UserData> userDataList = new List<UserData>();
    private List<User> userList = new List<User>();

    public ControllerLoadingData controllerLoadingData;

    public bool loadComplete { get; private set; }


    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            loadComplete = false;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }


    public static QueryUserData GetInstance()
    {
        return instance;
    }

    public UserData GetUserDataById(int id)
    {
        foreach (UserData ud in userDataList)
        {
            if (ud.id == id)
            {
                return ud;
            }
        }

        Debug.Log("QueryUserData can't get UserData by " + id);
        return new UserData();
    }

    public List<User> GetOtherUser(int id)
    {
        List<User> otherUsers = new List<User>();
        foreach (User u in userList)
        {
            if (u.userId != id)
            {
                otherUsers.Add(u);
            }
        }

        return otherUsers;
    }

    public void AddUser(User u)
    {
        userList.Add(u);
        Debug.Log("User added: " + u.userId);
    }

    public User GetUserById(int id)
    {
        foreach (User u in userList)
        {
            if (u.userId == id)
            {
                return u;
            }
        }

        Debug.Log("QueryUserData can't get user by " + id);
        return new User();
    }

    public void GetData()
    {
        string reqUrl = url + key + urlp2;
        IEnumerator coroutine = SendRequest(reqUrl);
        StartCoroutine(coroutine);
    }

    private IEnumerator SendRequest(string requestString)
    {
        // Make the request
        UnityWebRequest request = UnityWebRequest.Get(requestString);
        yield return request.Send();

        // UnityEngine.Debug.Log(request.downloadHandler.text);

        string result = request.downloadHandler.text;

        // call function to Parse JSON
        ParseJson(result);

        yield return null;

    }

    //parse result. store users and their tags.
    private void ParseJson(string data)
    {
        Debug.Log(data);
        var N = SimpleJSON.JSON.Parse("[" + data + "]");
        int entriesLength = N[0]["feed"]["entry"].Count;

        for (int i = 0; i < entriesLength; i++)
        {
            //store users
            UserData newUserData = new UserData();
            newUserData.id = i;
            newUserData.tagList = new List<Tag>();

            string subjectName = N[0]["feed"]["entry"][i]["gsx$name"]["$t"].ToString();
            newUserData.UserName = subjectName.Replace("\"", "");

            string job = N[0]["feed"]["entry"][i]["gsx$job"]["$t"].ToString();
            newUserData.Job = job.Replace("\"", "");

            string affiliation = N[0]["feed"]["entry"][i]["gsx$affiliation"]["$t"].ToString();
            newUserData.Affiliation = affiliation.Replace("\"", "");

            string tags = N[0]["feed"]["entry"][i]["gsx$tags"]["$t"].ToString().Replace("\"", "");
            string[] tagArray = tags.Split(new[] { ',', ' ' });
            foreach(string s in tagArray)
            {
                CreateTag(s, newUserData);
            }

            userDataList.Add(newUserData);
        }

        controllerLoadingData.DataWasLoaded();
        loadComplete = true;
    }

    //helper method: creating tags
    private void CreateTag(string input, UserData userData)
    {
        // Don't create tags for empty slots
        if (!IsNullOrWhiteSpace(input))
        {
            Tag newTag = new Tag();
            newTag.Content = input;
            newTag.bShow = true;
            userData.tagList.Add(newTag);
        }
    }

    private bool IsNullOrWhiteSpace(String value)
    {
        if (value == null) return true;

        for (int i = 0; i < value.Length; i++)
        {
            if (!Char.IsWhiteSpace(value[i])) return false;
        }

        return true;
    }

}