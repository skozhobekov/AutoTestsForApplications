namespace apitest.Interfaces;

public class ShapeService
{
    public double CalculateArea(IShape shape)
    {
        return  shape.GetArea();
    }
}