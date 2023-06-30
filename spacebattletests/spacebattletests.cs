using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using spacebattle;

namespace spacebattletests
{
    [Binding]
    public class РеализоватьПрямолинейноеДвижение
    {
        public readonly ScenarioContext _scensrioContext;
        Exception exp = new Exception();
        SpaceShip spaceship = new SpaceShip();
        double[] speed = {double.NaN, double.NaN};
        double[] result1 = new double[2];
        double delta_fuel = double.NaN;
        double delta_angle = double.NaN;
        double result2;
        public РеализоватьПрямолинейноеДвижение(ScenarioContext scensrioContext)
        {
            _scensrioContext = scensrioContext;
        }

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void GivenКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(int p0, int p1)
        {
            spaceship.Point = new double[2]{p0, p1};
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void GivenИмеетМгновеннуюСкорость(int p0, int p1)
        {
            speed[0] = p0;
            speed[1] = p1;
        }

        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void GivenКосмическийКорабльПоложениеВПространствеКоторогоНевозможноОпределить()
        {

        }

        [Given(@"скорость корабля определить невозможно")]
        public void GivenСкоростьКорабляОпределитьНевозможно()
        {

        }

        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void GivenИзменитьПоложениеВПространствеКосмическогоКорабляНевозможно()
        {
            spaceship.Change_position = false;
        }

        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void WhenПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
        {
            try
            {
                result1 = spaceship.Find_point(speed);
            }
            catch (Exception e) 
            { 
                try
                {
                    result2 = spaceship.Find_fuel(delta_fuel);
                }
                catch {}
                exp =  e;
            }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void ThenКосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(int p0, int p1)
        {
            Assert.True((result1[0] == p0) && (result1[1] == p1));
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenВозникаетОшибкаException()
        {
            Assert.ThrowsAsync<Exception>(() => throw exp);
        }

        // exercise 7

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void GivenКосмическийКорабльИмеетТопливоВОбъемеЕд(int p0)
        {
            spaceship.Volume_of_fuel = p0;
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void GivenИмеетСкоростьРасходаТопливаПриДвиженииЕд(int p0)
        {
            delta_fuel = p0;
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void GivenКосмическийКорабльИмеетУголНаклонаГрадКОсиOX(int p0)
        {
            spaceship.Angle_of_inclination = p0;
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void GivenИмеетМгновеннуюУгловуюСкоростьГрад(int p0)
        {
            delta_angle = p0;
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void GivenКосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
        {

        }

        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void GivenМгновеннуюУгловуюСкоростьНевозможноОпределить()
        {

        }

        [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
        public void GivenНевозможноИзменитьУголНаклонаКОсиOXКосмическогоКорабля()
        {
            spaceship.Change_angle = false;
        }        

        [When(@"происходит вращение вокруг собственной оси")]
        public void WhenПроисходитВращениеВокругСобственнойОси()
        {
            try
            {
                result2 = spaceship.Find_angle(delta_angle);
            }
            catch (Exception e)
            {
                exp = e;
            }
        }

        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void ThenНовыйОбъемТопливаКосмическогоКорабляРавенЕд(int p0)
        {
            Assert.True(result2 == p0);
        }        

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void ThenУголНаклонаКосмическогоКорабляКОсиOXСоставляетГрад(int p0)
        {
            Assert.True(result2 == p0);
        }
    }
}