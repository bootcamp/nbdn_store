using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;
        int Id;

        public ViewSubDepartments()
            : this(new StubRepository(),
            new StubResponseEngine())
        {
        }

        public ViewSubDepartments(Repository repository, ResponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
            
        }

        public void process(Request request)
        {
            get_dept_id();
            response_engine.prepare(repository.get_all_sub_depts_in_dept(get_dept_id()));
        }

        private int get_dept_id()
        {
            return 1;
        }
    }
}