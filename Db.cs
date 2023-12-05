namespace PizzaStore.DB;

public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
public class PizzaDB
{
    private static List<Pizza> _pizzas = new List<Pizza>() {
        new Pizza{ Id= 1, Name= "Monte Carlo"},
        new Pizza{ Id= 2, Name= "Margueritta"},
        new Pizza{ Id= 3, Name= "Mussarela"},
        new Pizza{ Id= 4, Name= "Pepperoni"}
    };

    public static List<Pizza> GetPizzas() { return _pizzas; }

    public static Pizza? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(p => p.Id == id);
    }

    public static Pizza CreatePizza(Pizza pizza)
    {
        _pizzas.Add(pizza);
        return pizza;
    }

    public static Pizza UpdatePizza(Pizza update)
    {
        _pizzas = _pizzas.Select(p =>
        {
            if (p.Id == update.Id)
            {
                p.Name = update.Name;
            }
            return p;
        }).ToList();
        return update;
    }

    public static void RemovePizza(int id)
    {
        _pizzas = _pizzas.FindAll(p => p.Id != id).ToList();
    }

}
