using System.Collections.Generic;
using Newtonsoft.Json;
using Obstacles;
using UnityEngine;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<BrickData> brickDataCollection;
        [SerializeField] private Brick brickPrefab;

        [SerializeField] private float columnSpacing = 6f;
        [SerializeField] private float rowSpacing = 1f;
        
        private LevelDataCollection _levelDataCollection;
        private const string LevelsFilePath = "levels";

        private void Awake()
        {
            LoadLevelDataCollection();
        }

        private void Start()
        {
            GenerateLevel(0);
        }

        private void GenerateLevel(int level)
        {
            var levelData = _levelDataCollection.Levels[level];

            for (var i = 0; i < levelData.Rows; i++)
            {
                for (var j = 0; j < levelData.Columns; j++)
                {
                    var brickId = levelData.Layout[i][j];
                    var brickData = brickDataCollection[brickId];
                    
                    var brick = Instantiate(brickPrefab, transform);
                    brick.transform.position = new Vector3(j * columnSpacing, i * rowSpacing);
                    brick.gameObject.name = $"Brick_r{i}_c{j}";
                    brick.Setup(brickData);
                }   
            }
        }

        private void LoadLevelDataCollection()
        {
            var json = Resources.Load<TextAsset>(LevelsFilePath);
            _levelDataCollection = JsonConvert.DeserializeObject<LevelDataCollection>(json.text);
        }
    }
}
