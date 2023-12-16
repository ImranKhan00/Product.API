namespace Product.API.Data
{
	public class SQL
	{
    //SELECT c.Id CategoryId , c.Name CategoryName, SUM(sli.SalePrice* sli.Quantity)  Amount FRoM SaleLineItems sli
    //INNER JOIN Products p
    //ON p.Id = sli.productId
    //INNER JOIN Categories c
    //ON c.Id = p.CategoryId
    //GROUP BY c.Id, c.Name

  }
}
