namespace TechChallenge.Domain.Entities
{
<<<<<<<< HEAD:src/TechChallengeAPI.Domain/Entities/Customer.cs
    public class Customer : BaseModel
========
    public class Costumer : BaseModel
>>>>>>>> 2a00abc54098f34cf5a5a789647fd0c53560a41e:src/TechChallengeAPI.Domain/Entities/Costumer.cs
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
