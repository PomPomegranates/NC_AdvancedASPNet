using EvieWizarding.Resources;
using System.Text.Json;

namespace EvieWizarding.Models
{
    public class TeacherModel
    {
        private List<Teacher> Teachers { get; set; }

        private List<Teacher> ReadTeachers()
        {
            var jsonTeachers = File.ReadAllText("Resources\\Teachers.json");
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(jsonTeachers);
            return teachers;

        }

        public List<Teacher> ReturnTeacher()
        {
            //if (Teachers == null)
            Teachers = ReadTeachers();
            return Teachers;

        }
    }
}
