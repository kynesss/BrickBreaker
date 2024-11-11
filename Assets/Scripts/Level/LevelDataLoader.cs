using Newtonsoft.Json;
using UnityEngine;

namespace Level
{
    public static class LevelDataLoader
    {
        private const string LevelsFilePath = "levels";
        
        public static LevelDataCollection LoadLevelDataCollection()
        {
            var json = Resources.Load<TextAsset>(LevelsFilePath);
            return JsonConvert.DeserializeObject<LevelDataCollection>(json.text);
        }
    }
}