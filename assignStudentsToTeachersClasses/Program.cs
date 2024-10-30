// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


bool suprapunere_intervale(int[] intervalProfesor, int[] intervalElev)
{
    int startProfesor = intervalProfesor[0], endProfesor = intervalProfesor[1];
    int startElev = intervalElev[0], endElev = intervalElev[1];

    return startProfesor <= startElev && endElev <= endProfesor;
}

