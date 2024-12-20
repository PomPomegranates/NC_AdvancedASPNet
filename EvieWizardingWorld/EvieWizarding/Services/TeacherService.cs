using EvieWizarding.Resources;
using EvieWizarding.Models;

namespace EvieWizarding.Services
{
    public class TeacherService
    {

        private readonly TeacherModel _model;

        public TeacherService(TeacherModel model)
        {
            _model = model;
        }

        public List<Teacher> GetTeachers()
        {
            return _model.ReturnTeacher();
        }

    }
}
