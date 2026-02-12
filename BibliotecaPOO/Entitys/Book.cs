namespace BibliotecaPOO;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Category { get; set; }
    public int TotalQuantity { get; set; }
    public int AvailableQuantity { get; set; }

    public bool CanAvailable(int TotalQuantiy, int AvailableQuantity)
    {
        if (TotalQuantiy - AvailableQuantity > 0)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    public int ReduceAvailable()
    {
        return AvailableQuantity--;
    }

    public int MoreAvailable()
    {
        return AvailableQuantity++;
    }
}