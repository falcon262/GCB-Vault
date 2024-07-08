using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database;
using System;
using Unity.VisualScripting;
using Newtonsoft.Json;

[Serializable]
public class UserData
{
    public string userName;
    public int highScore;

    public UserData(string userName, int highScore)
    {
        this.userName = userName;
        this.highScore = highScore; 
    }

    public UserData() { }
}

public class AuthManagerFirebaseLocal : MonoBehaviour
{
/*    private DependencyStatus dependancyStatus;
    private FirebaseAuth auth;*/

    public UserData userData;
    public string userId;
    DatabaseReference database;

    private void Awake()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;

        /*FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependancyStatus = task.Result;
            if(dependancyStatus == DependencyStatus.Available)
            {
                InitFirebase();
            }
        });*/
    }

    public void SaveData()
    {
        string json = JsonConvert.SerializeObject(userData);
        database.Child("users").Child(userId).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null || task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("FirebaseStorageService - Upload User Data - FAILED! " + task.Status);
            }
            else
            {
                Debug.Log("FirebaseStorageService - Upload User Data - DONE");
            }
        });
    }

    public void PushSaveData()
    {
        SaveData();
    }

    public IEnumerator LoadData()
    {
        var task = database.Child("users").GetValueAsync();

        yield return new WaitUntil(predicate: () => task.IsCompleted);

        if(task != null)
        {
            DataSnapshot snapshot = task.Result;
            UserData user = new UserData();
            user = JsonUtility.FromJson<UserData>(snapshot.GetRawJsonValue());
            Debug.Log(user.userName);
        }
    }

    void Start()
    {
        StartCoroutine(LoadData());
    }

    void Update()
    {
        
    }





/*    private void InitFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        EmailLogin("papayaw@gmail.com", "123456");
    }

    public void EmailLogin(string email, string password)
    {
        Credential cred = EmailAuthProvider.GetCredential(email, password);
        auth.SignInAndRetrieveDataWithCredentialAsync(cred).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(message: task.Exception.Message);
                return;
            }
            else
            {
                Debug.Log(task.Result.User.DisplayName + " and Email: " + task.Result.User.Email + " ID: " + task.Result.User.UserId);
                userId = task.Result.User.UserId;
            }

        });

    }*/

}
