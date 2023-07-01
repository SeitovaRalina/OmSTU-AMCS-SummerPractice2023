namespace spacebattle;
public class SpaceShip
{
    double[] point = {double.NaN, double.NaN};
    public double[] Point {set {point = value;}}

    // ПОЛЕ SPEED И СВОЙСТВО ДЛЯ НЕГО НЕ НУЖНЫ, Т.К. В КЛАССЕ ХАРАКТЕРИЗУЕТСЯ 
    // ТОЛЬКО СОСТОЯНИЕ КОРАБЛЯ НА ДАННЫЙ МОМЕНТ, его положение и возможность дальнейшего движения, а не само движение
    // как я понимаю, для характеризации движения нужен отдельный класс, но пока ограничимся одним ...
    bool change_position = true;
    public bool Change_position {set {change_position = value;}}
    double fuel = double.NaN;
    public double Volume_of_fuel {set {fuel = value;}}
    double angle = double.NaN;
    public double Angle_of_inclination {set {angle = value;}}
    bool change_angle = true;
    public bool Change_angle {set {change_position = value;}}
    bool HasNormalValue(double[] a)
    {
        return !double.IsNaN(a[0]) && !double.IsNaN(a[1]);
    }
    public double[] Find_point(double[] speed)
    {
        if (HasNormalValue(point) && HasNormalValue(speed) && change_position)
        {
            point[0] += speed[0];
            point[1] += speed[1];
        }
        else { throw new Exception(); }
        return point;
    }
    public double Find_fuel(double delta_fuel)
    {
        if (Math.Abs(fuel - delta_fuel) > Double.Epsilon)
        {
            fuel -= delta_fuel;
        }
        else {throw new Exception();}
        return fuel;
    }
    public double Find_angle(double delta_angle)
    {
        if (HasNormalValue(new double[2]{angle, delta_angle}) && change_angle)
        {
            angle += delta_angle;

        }
        else {throw new Exception();}
        return angle;        
    }
}