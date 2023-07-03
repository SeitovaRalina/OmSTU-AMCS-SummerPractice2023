using Newtonsoft.Json;  // подключаем пространство имен из пакета Newtonsoft.Json
using Newtonsoft.Json.Linq;
namespace SpaceCadets1
{
    public class Student
    {
        public string name = "";
        public string group = "";
        public string discipline = "";
        public double mark = 0;
    }
    public class Task
    {
        public string? taskName;
        public List<Student> data = new List<Student>();
    }
    class Program
    {
        static void WriteDynamicJsonObject(JObject jsonObj, string fileName)
        {
            string exit_file = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(fileName, exit_file);
        }
        static Task LoadJson(string file)
        {
            using (StreamReader r = new StreamReader($"{file}"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Task>(json);
            }
        }
        static JObject GetStudentsWithHighestGPA(List<Student> data)
        {
            var GPA_all = data.GroupBy(x => x.name).Select(g => new {Name = g.Key, GPA = g.Average(x => x.mark)});
            var max =  GPA_all.Max(r => r.GPA);
            return new JObject(
                new JProperty("Response",
                    new JArray(GPA_all.Where(r => r.GPA == max).Select(g =>
                        new JObject(new JProperty("Cadet", g.Name),
                                    new JProperty("GPA", Convert.ToInt32(g.GPA)))))));
        }
        static JObject CalculateGPAByDiscipline(List<Student> data)
        {
            return new JObject(
                new JProperty("Response",
                    new JArray(data.GroupBy(x => x.discipline).Select(g =>
                    new JObject(new JProperty($"{g.Key}",g.Average(x => x.mark)))))));
        }
        static JObject GetBestGroupsByDiscipline(List<Student> data)
        {
            var result3 = data.GroupBy(s => new { s.discipline, s.group })
                            .Select(g => new
                            {
                                Discipline = g.Key.discipline,
                                Group = g.Key.group,
                                GPA = g.Average(s => s.mark)
                            }).GroupBy(x => x.Discipline)
                            .Select(e => new
                            {
                                Discipline = e.Key,
                                GPA = e.Max(t => t.GPA),
                                Group = e.Where(r => r.GPA == e.Max(t => t.GPA)).Select(x => x.Group)
                            });
            return new JObject(
                new JProperty("Response",
                    new JArray(result3.SelectMany(c => c.Group,
                        (c, emp) => new JObject(new JProperty("Discipline", c.Discipline),
                                                new JProperty("Group", emp),
                                                new JProperty("GPA", c.GPA))))));
        } 
        static void Main(string[] args)
        {
            string inputFilePath = args[0]; 
            string outputFilePath = args[1];
            
            var json = LoadJson(inputFilePath);
            var taskName = json.taskName;
            var data = json.data;
            JObject result;
            switch (taskName)
            {
                case "GetStudentsWithHighestGPA":
                    result = GetStudentsWithHighestGPA(data);
                    break;
                case "CalculateGPAByDiscipline":
                    result = CalculateGPAByDiscipline(data);
                    break;
                case "GetBestGroupsByDiscipline":
                    result = GetBestGroupsByDiscipline(data);
                    break;
                default:
                    result = new JObject();
                    break;
            }
            WriteDynamicJsonObject(result, outputFilePath);
        }
    }
}