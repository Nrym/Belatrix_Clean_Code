namespace SOLID._02_OpenClosed
{
    public class Employee
    {
        public int ID { get; set; }
        public EmployeeTypeEnum Type { get; set; }
        public string Name { get; set; }
        public decimal Bonus { get; set; }

        public Employee(int id, string name)
        {
            ID = id;
            Name = name;
            Type = EmployeeTypeEnum.Other;
            Bonus = .05M;
        }

        protected Employee(int id, string name, EmployeeTypeEnum type, decimal bonus)
        {
            ID = id;
            Name = name;
            Type = type;
            Bonus = bonus;
        }

        public virtual decimal CalculateBonus(decimal salary)
        {
            return salary * Bonus;
        }
    }

    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name) : base(id, name, EmployeeTypeEnum.Permanent, .1M)
        {
        }
    }
    public class GerenteEmployee : Employee
    {
        public GerenteEmployee(int id, string name) : base(id, name, EmployeeTypeEnum.Gerente, 1.05M)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            return base.CalculateBonus(salary) + 500;
        }
    }

    public enum EmployeeTypeEnum
    {
        Other = 0,
        Permanent = 1,
        Gerente = 2
    }

    public class Testing
    {
        Employee empOther = new Employee(1, "");
        PermanentEmployee empPermanent = new PermanentEmployee(2, "");
        Employee superEmp = new PermanentEmployee(3, "");
        GerenteEmployee gere = new GerenteEmployee(4, "");
    }
}