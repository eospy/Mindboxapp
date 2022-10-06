namespace Easyareafinder;
public static class Areafinderlib
{
  /// <summary>
  /// Вычисление площади любого многоугольника по коордиантам вершин,перечисленным по часовой стрелке
  /// </summary>
  /// <param name="dots"></param>
  /// <returns></returns>
    public static double Universalareafinder (this double[,] dots)
    {
        double[,] array=new double[dots.GetUpperBound(0)+2,dots.GetUpperBound(1)+1];
        for (int i = 0; i < dots.GetUpperBound(0)+1; i++)
        {
            for (int j = 0; j < dots.GetUpperBound(1)+1; j++)
            {
                array[i, j] = dots[i, j];
            }
            if (i== dots.GetUpperBound(0))
            {
                array[i+1,0] = dots[0,0];
                array[i+1,1] = dots[0,1];
            }
        }
        double leftsum = 0;
        double rightsum = 0;
        for(int i = 0; i < array.GetUpperBound(0) ; i++)
        {
            leftsum += array[i, 0] * array[i+1, 1];
            rightsum += array[i, 1] * array[i + 1, 0];
        }
        
        return Math.Abs(leftsum-rightsum)/2;
    }
}
public abstract class Shape
{
    public string Name { get; private set; }
    public Shape(string name)
    {
        this.Name = name;
    }
    public abstract double Calcmethod();
}
public static class ShapePrototype
{
    public static double Calcmethod(Shape shape) => shape.Calcmethod();
}
public class Triangle : Shape
{
    public double a { get; private set; }
    public double b { get; private set; }
    public double c { get; private set; }
    public Triangle(string name, double a, double b, double c) : base(name)
    {
        if (a < 0 || b < 0 || c < 0) throw new ArgumentException($"Error: Side can not be less than 0");
        else if (a > (b + c) || b > (a + c) || c > (a + b)) throw new ArgumentException($"Error: Your side greater than summary of two another sides");
        else
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
    public bool IsRectangular()
    {
        bool check = (a == Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2))
                         || b == Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2))
                         || c == Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
        return check;
    }
    public override double Calcmethod()
    {
        double p = (a + b + c) / 2;
        double result = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 1);
        return result;
    }
}
public class Circle : Shape
{
    public double radius { get; private set; }
    public Circle(string name,double r) : base(name)
    {
        this.radius = r;
    }

    public override double Calcmethod()
    {
        return Math.Round(Math.PI * Math.Pow(radius, 2), 1); ;
    }
}


