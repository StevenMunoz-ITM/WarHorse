public class WarHorse
{
    // Programa principal
    public static void Main()
    {   
        Console.WriteLine("Ingrese ubicacion de los caballos");
        string ubicacion = Console.ReadLine()!;
        string[] cab = ubicacion.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        int n = cab.Length;
        int[,] tab = new int[8, 8];
        int[,] pos = new int[64, 2];
        int tope = 0;

        // Colocar caballos en el tablero
        for (int i = 0; i < n; i++)
        {
            string posStr = cab[i].Trim().ToLower();
            if (posStr.Length != 2)
            {
                Console.WriteLine($"Posición inválida: {posStr}");
                continue;
            }
            char col = char.ToUpper(posStr[0]);
            char fil = posStr[1];
            tab[Ef(fil), Ec(col)] = 1;
            pos[tope, 0] = Ef(fil);
            pos[tope, 1] = Ec(col);
            tope++;
        }

        // Show(tab);

        // Análisis de conflictos
        for (int i = 0; i < tope; i++)
        {
            Console.WriteLine("Analizando caballo en"
                + EcInv(pos[i, 1])
                + EfInv(pos[i, 0])
                + "=>");
            //Conflictos
            int fil, col;

            fil = pos[i, 0] - 2; 
            col = pos[i, 1] - 1;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] - 2; 
            col = pos[i, 1] + 1;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] - 1; 
            col = pos[i, 1] - 2;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] + 1; 
            col = pos[i, 1] - 2;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] - 1; 
            col = pos[i, 1] + 2;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] + 1; 
            col = pos[i, 1] + 2;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] + 2; 
            col = pos[i, 1] - 1;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            fil = pos[i, 0] + 2; 
            col = pos[i, 1] + 1;
            if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                if (tab[fil, col] == 1) Console.WriteLine("Ataca a " + EcInv(col) + EfInv(fil) + "\t");

            Console.WriteLine();
        }


    }
    // Convertir fila a índice
    public static int Ef(char f)
    {
        return f switch
        {
            '8' => 0,
            '7' => 1,
            '6' => 2,
            '5' => 3,
            '4' => 4,
            '3' => 5,
            '2' => 6,
            '1' => 7,
            _ => throw new ArgumentException("Fila inválida")
        };
    }
    // Convertir índice a fila
    public static char EfInv(int f)
    { 
    return f switch
        {
            0 => '8',
            1 => '7',
            2 => '6',
            3 => '5',
            4 => '4',
            5 => '3',
            6 => '2',
            7 => '1',
            _ => throw new ArgumentException("Fila inválida")
        };
    }
    // Convertir columna a índice
    public static int Ec(char c)
    {
        return c switch
        {
            'A' => 0,
            'B' => 1,
            'C' => 2,
            'D' => 3,
            'E' => 4,
            'F' => 5,
            'G' => 6,
            'H' => 7,
            _ => throw new ArgumentException("Columna inválida")
        };
    }
    // Convertir índice a columna
    public static char EcInv(int c)
    {
        return c switch
        {
            0 => 'A',
            1 => 'B',
            2 => 'C',
            3 => 'D',
            4 => 'E',
            5 => 'F',
            6 => 'G',
            7 => 'H',
            _ => throw new ArgumentException("Columna inválida")
        };
    }
    // Mostrar tablero
    public static void Show(int[,] tab)
    {
        Console.WriteLine("0 1 2 3 4 5 6 7");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(tab[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
