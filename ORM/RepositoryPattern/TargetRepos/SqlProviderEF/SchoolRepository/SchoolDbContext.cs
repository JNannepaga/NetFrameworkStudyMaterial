using RepositoryPattern.TargetRepos.Core;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class SchoolDbContext : ApplicationDbContext
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeachersRepository _teacherRepository;
        
        public SchoolDbContext()
            :this(new SchoolEFAdapter("TargetSingleRepos_SchoolDb"))
        {
            
        }

        public SchoolDbContext(IDbAdapter dbAdapter)
            : this(dbAdapter, 
                  new StudentRepository(dbAdapter), 
                  new TeacherRepository(dbAdapter))
        {

        }

        public SchoolDbContext(IDbAdapter dbAdapter,
            IStudentRepository studentRepository,
            ITeachersRepository teachersRepository)
            : base(dbAdapter)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teachersRepository;
        }

        public IStudentRepository StudentRepository { 
            get
            {
                return _studentRepository; 
            }
        } 
        public ITeachersRepository TeachersRepository {
            get 
            {
                return _teacherRepository;
            }
        }
    }
}
