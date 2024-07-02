using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SampleCSV : MonoBehaviour
{
    public string CarriageReturn = "\r";
    public string LineFeed = "\n";

    string SeparateSymbol = ",";

    string LineFeedSymbol = "\r\n";

    // Start is called before the first frame update
    void Start()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        string csvPath = Path.Combine(Application.dataPath, "Sample.csv");
        string csvString = File.ReadAllText(csvPath);

        string[] csvRowDatas = csvString.Split(LineFeedSymbol);

        //因为第一行是表头,不需要输出,所以这里不读取表头
        for(int i = 1; i < csvRowDatas.Length; i++)
        {

            string[] csvColunmDatas = csvRowDatas[i].Split(SeparateSymbol);

            for(int j = 0; j < csvColunmDatas.Length; j++)
            {
                Debug.Log(csvColunmDatas[j]);
            }
        }
    }

    void SaveCSV()
    {
        DataTable csvSample = new DataTable("示例CSV");
        csvSample.Columns.Add("序号");
        csvSample.Columns.Add("姓名");
        csvSample.Columns.Add("成绩");

        DataRow dataRow = csvSample.NewRow();

        dataRow["序号"] = 0;
        dataRow["姓名"] = "张三";
        dataRow["成绩"] = Random.Range(50, 100);

        csvSample.Rows.Add(dataRow);

        dataRow = csvSample.NewRow();
        dataRow[0] = 1;
        dataRow[1] = "李四";
        dataRow[2] = Random.Range(50, 100);

        csvSample.Rows.Add(dataRow);


        for (int i = 1; i < 10; i++)
        {
            dataRow = csvSample.NewRow();

            dataRow[0] = i;
            dataRow[1] = "李四" + i;
            dataRow[2] = Random.Range(50, 100);

            csvSample.Rows.Add(dataRow);
        }

        StringBuilder csvString = new StringBuilder();


        //单独添加表头
        for (int j = 0; j < csvSample.Columns.Count; j++)
        {
            csvString.Append(csvSample.Columns[j].ColumnName);

            if (j < csvSample.Columns.Count - 1)
            {
                csvString.Append(SeparateSymbol);
            }
        }

        //遍历每一行,并将某一行某一列的数据传入到字符串中
        for (int i = 0; i < csvSample.Rows.Count; i++)
        {
            csvString.Append(LineFeedSymbol);


            for (int j = 0; j < csvSample.Columns.Count; j++)
            {
                csvString.Append(csvSample.Rows[i][j].ToString());

                if (j < csvSample.Columns.Count - 1)
                {
                    csvString.Append(SeparateSymbol);
                }
            }
        }

        string csvPath = Path.Combine(Application.dataPath, "csv.Sample");

        File.WriteAllText(csvPath, csvString.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
