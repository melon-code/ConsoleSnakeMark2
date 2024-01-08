namespace ConsoleSnakeMark2 {
    public class BigFoodSpawner : GameLogicUser {
        int lastValue = 0;

        int AteFood => Logic.AteFood;

        public override void ApplyLogic() {
            if (lastValue != AteFood && AteFood % GameData.BigFoodPeriod == 0) {
                lastValue = AteFood;
                Logic.SpawnFood(GameData.BigFoodValue);
            }
        }
    }
}
