using EvieWizarding.Resources;
using System.Text.Json;

namespace EvieWizarding.Models
{
    public class TeachersModel
    {
        private List<Teacher>? Teachers { get; set; }

        private List<Teacher>? ReadTeachers()
        {
            var jsonTeachers = File.ReadAllText("Resources\\Teachers.json");
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(jsonTeachers);
            return teachers;

        }

        public List<Teacher>? ReturnTeacher()
        {
            if (Teachers == null) Teachers = ReadTeachers();
            return Teachers;

        }
        public Teacher? ReturnTeacher(int id)
        {
            if (Teachers == null) Teachers = ReadTeachers();
            var foundTeacher = Teachers.Find(x => x.id == id);
            return foundTeacher;

        }

        public bool AddTeacher(Teacher teacher)
        {
            teacher.id = ReturnTeacher().Max(x => x.id) + 1;
            if (Teachers != null)
            {
                Teachers.Add(teacher);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
