namespace BibliotecaPOO;

public class Loan
{
    public int Id { get; set; }
    public string Book { get; set; }
    public string User { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnLoanDate { get; set; }
    public string Status { get; set; }

    public void IsLate()
    {
    }
    public void FinishLoan()
    {
    }
    public static void CalculateDelayDays(DateTime loanDate, DateTime returnLoanDate)
    {
    }
}