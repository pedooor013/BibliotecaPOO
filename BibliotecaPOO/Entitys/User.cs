namespace BibliotecaPOO;

public class User
{

    public Guid Id { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime RegisterDate { get; set; }

    public enum UserStatus
    {
        Active,
        Inactive
    }
    public UserStatus Status { get; private set; }
    private List<Loan> _loanList = new();

    public void CanLoanBook()
    {
        if (_loanList.Count > 3)
        {
            Console.WriteLine("You don't can loan the book!");
            BlockToLoan();
        }                                                                        
    }
    public void BlockToLoan()
    {
        
    }
    public void UnlockToLoan()
    {
        
    }
    public void AddLoan()
    {
        
    }
    public void RemoveLoan()
    {
    }

    public User(string nome, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        RegisterDate = DateTime.Now.Date;
        Status = UserStatus.Active;
        
    }
    
}