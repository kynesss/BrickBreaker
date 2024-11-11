using System;
using System.Collections.Generic;

namespace Level
{
    [Serializable]
    public class LevelData
    {
        public int Level { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<List<int>> Layout { get; set; }
    }
}