
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool feedbackDone;
        public bool promptDone;

        // Ваши сохранения
        public bool sound = true;
        public float sensetive = 0.1f;
        public int level = 1;
        public int exp = 0;
        public int wave = 1;
        public int ability = 0;
        public float bonusexp = 1.0f;
        public float bonusspeed = 0.0f;
        public int bonusdamage = 0;
        public float bonusknockback = 0.0f;
        public float bonuscritical = 5.0f;
    }
}
