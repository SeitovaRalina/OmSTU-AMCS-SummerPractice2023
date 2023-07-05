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
        SpaceBattle spaceship = new SpaceBattle();
        Func<double[]> result;        
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
            spaceship.Speed = new double[2]{p0, p1};
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
                result = () => spaceship.Uniform_motion();
            }
            catch { }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void ThenКосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(double p0, double p1)
        {
            Assert.Equal(result(), new double[2]{p0, p1});
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenВозникаетОшибкаException()
        {
            Assert.Throws<Exception>(() => result());
        }
    }
}