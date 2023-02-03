using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("Blue", 4);
        Rectangle rect1 = new Rectangle("Yellow", 2, 8);
        Circle circle1 = new Circle("Red", 3);

        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(square1);
        shapeList.Add(rect1);
        shapeList.Add(circle1);
        foreach (var shape in shapeList)
        {
            double area = shape.GetArea();
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {area}.");
        }
    }
}