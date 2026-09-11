using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class GoogleSheetDataLoader : MonoBehaviour
{
    [Header("Google Sheet Export URL")]
    [SerializeField]
    private string _sheetUrl = "https://docs.google.com/spreadsheets/d/YOUR_SHEET_ID/export?format=csv&gid=0";

    [Header("Data Table SO")]
    [SerializeField] private EnemySpawnDataTableSO _dataTableSO; // 인스펙터에서 할당할 SO 에셋

    void Start()
    {
        StartCoroutine(DownloadCSVAndProcess());
    }

    IEnumerator DownloadCSVAndProcess()
    {
        using (var www = UnityWebRequest.Get(_sheetUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"[오류] 구글 시트 다운로드 실패: {www.error}");
                yield break;
            }

            string csvText = www.downloadHandler.text;

            // 1. CsvHelper 파싱 결과를 배열로 SO의 Datas에 할당
            if (_dataTableSO != null)
            {
                _dataTableSO.Datas = ParseCSVData(csvText);

                // 2. SO 데이터를 바탕으로 프리팹 로드 작업 실행
                LoadPrefabsToSO();
            }
            else
            {
                Debug.LogError("EnemySpawnDataTableSO가 인스펙터에 할당되지 않았습니다!");
            }
        }
    }

    private EnemySpawnData[] ParseCSVData(string csvText)
    {
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // GetRecords 결과를 ToArray()를 사용하여 배열로 변환
            IEnumerable<EnemySpawnData> records = csv.GetRecords<EnemySpawnData>();
            return new List<EnemySpawnData>(records).ToArray();
        }
    }

    private void LoadPrefabsToSO()
    {
        if (_dataTableSO == null || _dataTableSO.Datas == null) return;

        foreach (EnemySpawnData data in _dataTableSO.Datas)
        {
            if (string.IsNullOrEmpty(data.PrefabPath)) continue;

            string cleanPath = data.PrefabPath.Trim();

            // Resources.Load로 프리팹 받아오기
            Enemy enemyPrefab = Resources.Load<Enemy>(cleanPath);

            if (enemyPrefab != null)
            {
                // Enemy 컴포넌트가 붙어있는지 확인 후 저장
                data.Prefab = enemyPrefab.GetComponent<Enemy>();
                Debug.Log($"[SO 저장 성공] {enemyPrefab.name} | Weight: {data.Weight}");
            }
            else
            {
                Debug.LogError($"[로드 실패] Assets/Resources/{cleanPath}.prefab 파일이 없습니다.");
            }
        }
    }
}