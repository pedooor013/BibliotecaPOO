namespace BibliotecaPOO;

public class Loans
{
    public int Id { get; set; }
    public string Book { get; set; }
    public string? User { get; set; }
    public DateTime? LoanDate { get; set; }
    public DateTime? ReturnLoanDate { get; set; }
    public string Status { get; set; }

    public void IsLate()
    {
        
    }

}