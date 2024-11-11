using System.Collections.Generic;
using Common;
using Common.Events;
using Obstacles;
using UnityEngine;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<BrickData> brickDataCollection;
        [SerializeField] private Brick brickPrefab;

        [SerializeField] private float columnSpacing = 4f;
        [SerializeField] private float rowSpacing = 1.45f;

        private void OnEnable()
        {
            Services.GameManager.GameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            Services.GameManager.GameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameStateChangedEventArgs args)
        {
            if (args.NewState != GameState.Gameplay)
                return;
            
            GenerateLevel(args.CurrentLevel);
        }

        private void GenerateLevel(int level)
        {
            var levelDataCollection = LevelDataLoader.LoadLevelDataCollection();
            var levelData = levelDataCollection.Levels[level];
            
            var centerX = (levelData.Columns - 1) * columnSpacing / 2f;
            var centerY = (levelData.Rows - 1) * rowSpacing / 2f;
            var position = transform.position;

            for (var i = 0; i < levelData.Rows; i++)
            {
                for (var j = 0; j < levelData.Columns; j++)
                {
                    var brickId = levelData.Layout[j][i] - 1;
                    var brickData = brickDataCollection[brickId];
                    
                    var brick = Instantiate(brickPrefab, transform);
                    var xPos = j * columnSpacing - centerX + position.x;
                    var yPos = i * rowSpacing - centerY + position.y;
                    
                    brick.transform.position = new Vector3(xPos, yPos);
                    brick.gameObject.name = $"Brick_r{i}_c{j}";
                    brick.Setup(brickData);
                }   
            }
        }
    }
}
