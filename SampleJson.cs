using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Newtonsoft.Json;
using System.IO;

public class Student
{
    public string Name;
    public int Index;

    public Dictionary<string, int> NameDic;
}

public class SampleJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Student sampleStudent = new Student();
        sampleStudent.Name = "zhangSan";
        sampleStudent.Index = 1;
        sampleStudent.NameDic = new Dictionary<string, int>();
        sampleStudent.NameDic.Add(sampleStudent.Name, sampleStudent.Index);

        //SaveJson(sampleStudent);

        LoadJson();
    }

    void SaveJson(object targetObject)
    {
        string jsonString = JsonMapper.ToJson(targetObject);
        string jsonPath = Path.Combine(Application.dataPath, "LitJson.Sample");

        File.WriteAllText(jsonPath, jsonString);

        jsonString = JsonConvert.SerializeObject(targetObject);
        jsonPath = Path.Combine(Application.dataPath, "NewtonJson.Sample");
        File.WriteAllText(jsonPath, jsonString);

        jsonString= JsonUtility.ToJson(targetObject);
        jsonPath= Path.Combine(Application.dataPath, "JsonUtility.Sample");
        File.WriteAllText(jsonPath, jsonString);
    }

    void LoadJson()
    {
        string jsonPath = Path.Combine(Application.dataPath, "LitJson.Sample");
        string jsonString = File.ReadAllText(jsonPath);
        Student sampleStudent = JsonMapper.ToObject<Student>(jsonString);

        Debug.Log(sampleStudent.Name);

        jsonPath = Path.Combine(Application.dataPath, "NewtonJson.Sample");
        jsonString = File.ReadAllText(jsonPath);
        sampleStudent = JsonConvert.DeserializeObject<Student>(jsonString);

        Debug.Log(sampleStudent.Name);

        jsonPath = Path.Combine(Application.dataPath, "JsonUtility.Sample");
        jsonString = File.ReadAllText(jsonPath);
        sampleStudent = JsonUtility.FromJson<Student>(jsonString);

        Debug.Log(sampleStudent.Name);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
