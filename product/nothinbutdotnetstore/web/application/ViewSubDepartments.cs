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
            new StubResponseEngine(),1)
        {
        }

        public ViewSubDepartments(Repository repository, ResponseEngine response_engine, int deptId)
        {
            this.repository = repository;
            this.response_engine = response_engine;
            Id = deptId;
        }

        public void process(Request request)
        {
            response_engine.prepare(repository.get_all_sub_depts_in_dept(Id));
        }
    }
}