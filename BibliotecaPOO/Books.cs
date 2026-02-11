namespace BibliotecaPOO;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Category { get; set; }
    public int TotalQuantity { get; set; }
    public int AvailableQuantity { get; set; }

    public void CanAvailable(int TotalQuantity)
    {
        AvailableQuantity = TotalQuantity;
    }


}