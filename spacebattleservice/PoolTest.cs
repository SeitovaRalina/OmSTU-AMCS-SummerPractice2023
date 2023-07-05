using spacebattle;
namespace spacebattleservice;
class Example
{
    public static void Main(string[] args)
    {
        Pool<SpaceShip> pool = new Pool<SpaceShip>(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
        using (PoolGuard<SpaceShip> guard = new PoolGuard<SpaceShip>(pool))
        {
            SpaceShip spaceship = guard.Object;
            spaceship.Point = new double[2]{1, 3};
            double[] speed = {2, 2};
            var result = spaceship.Find_point(speed);
            System.Console.WriteLine($"Новое положение корабля: {result}");
            spaceship.ReturnToBasicSettings();
        }
    }
}