using fall21Collabs.Models;
using fall21Collabs.Repositories;

namespace fall21Collabs.Services
{
    public class AccountProjectService
    {
        private readonly ProjectRepository _prepo;
        private readonly AccountProjectRepository _aprepo;

        public AccountProjectService(ProjectRepository prepo, AccountProjectRepository aprepo)
        {
            _prepo = prepo;
            _aprepo = aprepo;
        }

        internal AccountProject Create(AccountProject newAP){
            Project p = _prepo.getById(newAP.projectId);
            newAP.Id = _aprepo.createAccountProject(newAP);
            return newAP;
        }
        internal AccountProject getById(int id){
            var data = _aprepo.getById(id);
            if(data == null){
                throw new System.Exception("Invalid ID!");
            }
            return data; 
        }
    }
}