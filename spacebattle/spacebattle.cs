namespace spacebattle;
public class SpaceBattle
{
    double[] point = {double.NaN, double.NaN};
    public double[] Point {set {point = value;}}
    double[] speed = {double.NaN, double.NaN};
    public double[] Speed {set {speed = value;}}
    bool change_position = true;
    public bool Change_position {set {change_position = value;}}
    bool HasNormalValue(double[] a)
    {
        return !double.IsNaN(a[0]) && !double.IsNaN(a[1]);
    }
    public double[] Uniform_motion()
    {
        if (HasNormalValue(point) && HasNormalValue(speed) && change_position)
        {
            point[0] = point[0] + speed[0];
            point[1] = point[1] + speed[1];
        }
        else { throw new Exception(); }
        return point;
    }
}