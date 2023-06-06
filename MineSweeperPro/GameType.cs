namespace MineSweeperPro
{

    public class GameType
    {

        private const int EASY_WIDTH = 9;
        private const int EASY_HEIGHT = 9;
        private const int EASY_MINE_COUNT = 9;
        private const int EASY_HINT_COUNT = 0;

        private const int MEDIUM_WIDTH = 16;
        private const int MEDIUM_HEIGHT = 16;
        private const int MEDIUM_MINE_COUNT = 40;
        private const int MEDIUM_HINT_COUNT = 1;

        private const int HARD_WIDTH = 20;
        private const int HARD_HEIGHT = 20;
        private const int HARD_MINE_COUNT = 60;
        private const int HARD_HINT_COUNT = 3;

        private const int EXTREME_WIDTH = 30;
        private const int EXTREME_HEIGHT = 16;
        private const int EXTREME_MINE_COUNT = 99;
        private const int EXTREME_HINT_COUNT = 3;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MineCount { get; private set; }
        public int HintCount { get; private set; }

        public GameType(GameTypeEnum gameType)
        {
            switch (gameType)
            {
                case GameTypeEnum.Easy:
                    Width = EASY_WIDTH;
                    Height = EASY_HEIGHT;
                    MineCount = EASY_MINE_COUNT;
                    HintCount = EASY_HINT_COUNT;
                    break;
                case GameTypeEnum.Medium:
                    Width = MEDIUM_WIDTH;
                    Height = MEDIUM_HEIGHT;
                    MineCount = MEDIUM_MINE_COUNT;
                    HintCount = MEDIUM_HINT_COUNT;
                    break;
                case GameTypeEnum.Hard:
                    Width = HARD_WIDTH;
                    Height = HARD_HEIGHT;
                    MineCount = HARD_MINE_COUNT;
                    HintCount = HARD_HINT_COUNT;
                    break;
                case GameTypeEnum.Extreme:
                    Width = EXTREME_WIDTH;
                    Height = EXTREME_HEIGHT;
                    MineCount = EXTREME_MINE_COUNT;
                    HintCount = EXTREME_HINT_COUNT;
                    break;
                default:
                    Width = EASY_WIDTH;
                    Height = EASY_HEIGHT;
                    MineCount = EASY_MINE_COUNT;
                    HintCount = EASY_HINT_COUNT;
                    break;
            }
        }

        public static GameTypeEnum GetGameType(int gameType)
        {
            GameTypeEnum[] gameTypeEnumValues = (GameTypeEnum[])Enum.GetValues(typeof(GameTypeEnum));

            return gameTypeEnumValues[gameType];
        }
    }
    public enum GameTypeEnum
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
        Extreme = 3
    }
}
