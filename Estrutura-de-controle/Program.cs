public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Informe o número de lados");
        string? numberSideString = Console.ReadLine();
        int numberSide = Convert.ToInt32(numberSideString);

        // Estrutura if else

        string name = String.Empty;

        if (numberSide == 3)
        {
            name = "triângulo";
        }
        else if (numberSide == 4)
        {
            name = "retângulo";
        }
        else if (numberSide == 5)
        {
            name = "pentágono";
        }
        else if (numberSide == 6)
        {
            name = "hexágono";
        }
        else {
            name = "polígono não identificado";
        }

        Console.WriteLine("O polígono é um " + name);



        // Estrutura switch case
        string complexity = String.Empty;

        switch (numberSide)
        {
            case 3:
            case 4:
            case 5:
                complexity = "básico";
                break;
            default:
                complexity = "complexo";
                break;
        }

        Console.WriteLine("O polígono é: " + complexity);
    }
}