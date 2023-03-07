using API.Data.Models;

namespace API.Services.services
{
    public interface IServices
    {
        public List<User> GetUsers();
        public void AddUser(User user);
        public User GetUserData(int id);
        public User PopUserContact(int id);
        public void UpdateUserContact(User user, int id);
        User DefaultContact();
        User LatestContact();
        void save();
    }
}
