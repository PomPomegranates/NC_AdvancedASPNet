using EvieWizarding.Resources;
using EvieWizarding.Models;

namespace EvieWizarding.Services
{
    public class TeachersService
    {

        private readonly TeachersModel _model;

        public TeachersService(TeachersModel model)
        {
            _model = model;
        }

        public List<Teacher>? GetTeachers()
        {
            return _model.ReturnTeacher();
        }

        public Teacher? GetTeachers(int id)
        {
            return _model.ReturnTeacher(id);
        }

        public bool AddTeacher(Teacher teacher, out Teacher result) 
        {
            result = teacher;
            return _model.AddTeacher(teacher);
        }

    }
}
