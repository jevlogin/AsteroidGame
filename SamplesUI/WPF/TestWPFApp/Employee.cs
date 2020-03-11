namespace TestWPFApp
{
    internal class Employee
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int Age { get; internal set; }
        public int Salary { get; internal set; }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Age}\t{Salary}";
        }
    }
}