using System;
namespace bank_project
{
    public interface IClientDataAccess
    {
        void GetAll();

        void CreateUser();

        void GetClient(string id);

        void UpdateClient(string id);

        void DeleteClient(string id);

        Client ParseClient(string id);
    }
}
