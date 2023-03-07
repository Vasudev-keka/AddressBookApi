using AddressBookApi;
using API.Data.Models;

namespace API.Services.services
{
    public class Service : IServices
    {
        private readonly Context _context;

        public Service(Context context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.Users_Api.ToList();
        }
        public void AddUser(User user)
        {
           _context.Users_Api.Add(user);
            save();

        }
        public User GetUserData(int id)
        {
            return _context.Users_Api.Find(id)!;
        }
        public User PopUserContact(int id)
        {
            User temp = _context.Users_Api.Find(id)!;
            _context.Users_Api.Remove(temp);
            save();
            return temp;

        }
        public void UpdateUserContact(User user, int id)
        {
            _context.Users_Api.Update(user);
            save();
        }
        public User DefaultContact()
        {
            return _context.Users_Api.FirstOrDefault()!;
        }
        public User LatestContact()
        {
            var records = _context.Users_Api.OrderBy(x => x.Id);
            return records.LastOrDefault()!;
        }
        public void save()
        {
            _context.SaveChanges();
        }

    }
}
