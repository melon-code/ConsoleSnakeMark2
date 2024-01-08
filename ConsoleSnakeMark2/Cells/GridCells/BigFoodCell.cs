namespace ConsoleSnakeMark2 {
    public class BigFoodCell : FoodCell {
        public int Value { get; }
        
        public BigFoodCell(int value) : base(value) {
            Value = value;
        }
    }
}
