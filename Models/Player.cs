namespace W9_assignment_template.Models
{
    public class Player : Character
    {
        public int Experience { get; set; }

        public override void Attack(ICharacter target)
        {
            // Player-specific attack logic
            Console.WriteLine($"{Name} attacks {target.Name} with a sword!");
        }
    }
}
