using System.Collections;
using System.IO;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class SampleIEnumrator : MonoBehaviour
{
    public Image SampleImage;
    public Button SampleButton;
    // Start is called before the first frame update
    async UniTask Start()
    {
         Downaload();
        Fade();
    }

    IEnumerator IEnumratorDownload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");

        UnityWebRequest request= UnityWebRequest.Get(fileURL);

        Debug.Log($"IEnumrator���ؿ�ʼ{Time.frameCount}");

         request.SendWebRequest();
        while (!request.isDone)
        {
            Debug.Log(request.downloadProgress);
            yield return null;
        }

        Debug.Log($"IEnumrator�������{Time.frameCount}");

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "downloadIEnumrator.zip");

        //Э��֧�������е��첽����
        yield return File.WriteAllBytesAsync(localSavePath, request.downloadHandler.data);
    }
    async UniTask<string> UniTaskDownload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");

        UnityWebRequest request = UnityWebRequest.Get(fileURL);

        Debug.Log($"UniTask���ؿ�ʼ{Time.frameCount}");

        request.SendWebRequest();

        while (!request.isDone)
        {
            Debug.Log(request.downloadProgress);
            await UniTask.Yield(PlayerLoopTiming.LastUpdate);
        }

        Debug.Log($"UniTask�������{Time.frameCount}");

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "downloadUniTask.zip");

        //Э��֧�������е��첽����
        await File.WriteAllBytesAsync(localSavePath, request.downloadHandler.data);

        return localSavePath;
    }

    async void Downaload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");
        HttpClient client = new HttpClient();
	//await Delay(1);
        Debug.Log($"���ؿ�ʼ{Time.frameCount}");

        HttpResponseMessage responseMessage = await client.GetAsync(fileURL);
        Debug.Log($"�������{Time.frameCount}");
        byte[] bytes = await responseMessage.Content.ReadAsByteArrayAsync();

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "download.zip");
        await File.WriteAllBytesAsync(localSavePath, bytes);
    }
    async UniTask Sample()
    {
        Debug.Log("�첽��ʼ");
        await UniTask.Delay(1000);
        Debug.Log("�첽����");
    }

    void Fade() {
        float alpha = 3.0f;
 	Debug.Log($"���ؿ�ʼ{Time.frameCount}");
        while (alpha > 0)
        {
            Debug.Log("����ִ��");
            alpha -= Time.deltaTime;
            //Color color = SampleImage.color;
            //color.a = alpha;
            //SampleImage.color = color;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
