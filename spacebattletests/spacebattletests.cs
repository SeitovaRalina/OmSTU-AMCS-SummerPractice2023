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
        SpaceBattle spaceship = new SpaceBattle();
        double[] result = new double[2];
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
                result = spaceship.Uniform_motion();
            }
            catch (Exception e) { exp =  e;}
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void ThenКосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(int p0, int p1)
        {
            Assert.True((result[0] == p0) && (result[1] == p1));
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenВозникаетОшибкаException()
        {
            Assert.ThrowsAsync<Exception>(() => throw exp);
        }
    }
}