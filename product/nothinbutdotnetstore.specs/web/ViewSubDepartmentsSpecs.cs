using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewSubDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartments>
        {
        }

        [Subject(typeof(ViewSubDepartments))]
        public class when_processing_sub_departments : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_sub_depts = new List<Department>();
                request = an<Request>();

                department_repository.Stub(x => x.get_all_sub_depts_in_dept(1)).Return(
                    the_sub_depts);
            };

            Because b = () =>
                sut.process(request);

            It shd_tell_response_to_display_sub_departments = () =>
                response_engine.received(x => x.prepare(the_sub_depts));

            static Repository department_repository;
            static Request request;
            static IEnumerable<Department> the_sub_depts;
            static ResponseEngine response_engine;
        }
    }
}