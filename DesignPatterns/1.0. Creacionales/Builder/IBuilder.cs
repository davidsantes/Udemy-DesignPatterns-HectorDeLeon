namespace DesignPatterns._1._0._Creacionales.Builder
{
    public interface IBuilder
    {
        /// <summary>
        /// El objeto regresará a una creación en blanco
        /// </summary>
        public void Reset();
        public void SetAlcohol(decimal alcohol);
        public void SetWater(int water);
        public void SetMilk(int milk);
        public void AddIngredients(string ingredients);
        public void Mix();
        /// <summary>
        /// Cuánto tiempo se deja reposar una bebida una vez ya hecha
        /// </summary>
        /// <param name="time"></param>
        public void Rest(int time);
    }
}
