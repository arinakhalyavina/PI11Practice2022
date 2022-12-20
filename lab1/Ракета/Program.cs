using static System.Console;
using static System.Math;
#region

double f=60;    //топливо
double h=1000;  //высота
double v=0;     //скорость 
double t;       //время 
double eps=0.0000001;

const double vmax=10; //максимальная скорость ракеты
const double g=-1.62; 
const double a=2;    //ускорение движения при включенном двигателе
#endregion

while (h>= Abs(eps))
{
 
    WriteLine($"Высота:{h}м");
    WriteLine($"Количество топлива:{f}с");
    WriteLine($"Скорость:{v}м/с");   

    int actoin=ActionChoose("(1-включить, 0-выключить): ", 0, 1);
    WriteLine(":");
    t=TimeChoose();
    double chosen = actoin == 0 ? g : a ;

    //вычесления

    if (t<0) t=0;
    if (t>f) t=f;

    int n;
    double t1, t2;
    SquareRoot(chosen/2, v, h, out n, out t1, out t2);

    if (n>0 && t1>0 && t>t1) t = t1;
    if (n>0 && t2>0 && t>t2) t = t2;

    if (chosen == 1) f-=t;
    h=h+v*t+chosen/2*t*t;
    v=v+chosen*t;

}

Console.WriteLine($"Текущие значения: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек"); 
            if (Math.Abs(v) > vmax)
                Console.WriteLine("Вы разбились");
            else
                Console.WriteLine("Вы приземлились");


static int TimeChoose()
    {
        int number;
                do
                {
                    Console.Write("Введите номер от 1 до 35: ");
                    int.TryParse(Console.ReadLine(), out number);
                } while (number < 0 || number > 35);
                return number;
    }
static int ActionChoose(string msg, int x1, int x2)
        {
            bool valid = false;
            int input = 0;

            do
            {
                Console.Write(msg);
                valid = int.TryParse(Console.ReadLine(), out input);
            } while (!valid || (input != x1 && input != x2));

            return input;
        }
static void SquareRoot(double A,double B, double C, out int n, out double x1, out double x2)
{
    n=0;
    x1=0;
    x2=0;

    if (A==0)
    {   
        x1=C/B;
    }
    else
    {
        double d = B*B-4*A*C;

        if (d<0) return;
        if (d==0) n=1;
        if (d>0) n=2;

        x1=(-B+Sqrt(d))/(2*A);
        x2=(-B-Sqrt(d))/(2*A);
    }
}    