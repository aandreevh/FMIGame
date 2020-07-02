namespace Global.Level
{
    [System.Serializable]
    public class LevelState
    {
        private string levelName;
        private bool isAvailable;

        public string LevelName
        {
            get => levelName;
            set => levelName = value;
        }

        public bool IsAvailable
        {
            get => isAvailable;
            set => isAvailable = value;
        }

        public LevelState(string levelName, bool isAvailable)
        {
            this.LevelName = levelName;
            this.IsAvailable = isAvailable;
        }
    }
}