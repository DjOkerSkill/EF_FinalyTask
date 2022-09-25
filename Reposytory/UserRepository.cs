using EF_FinalyTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FinalyTask.Reposytory
{
    public class UserRepository
    {
        
        // Выбоз всех пользователей
        public List<User> SelectAllUsers()
        {
            using (var context = new Context())
            {
                return context.Users.ToList();
            }
        }

        // Выбор пользователя по ID
        public User SelectUserById(int id)
        {
            using (var context = new Context())
            {
                var temp = context.Users.FirstOrDefault(p => p.Id == id);

                if (temp != null)
                    return temp;

                return null;
            }
        }

        // Добавление пользователя в базу данных

        public void AddUsers()
        {
            using (var context = new Context())
            {
                int exit = 1;
                do
                {
                    Console.WriteLine("Введите имя пользователя");
                    string name = Console.ReadLine();
                    Console.WriteLine("Ввеидте email");
                    string email = Console.ReadLine();
                   

                    User user = new User() { Name=name, Email=email };

                    context.Users.Add(user);
                    context.SaveChanges();

                    Console.WriteLine("Введите 1, чтобы добавить книгу или нажмите 2, чтобы выйти");
                    exit = Convert.ToInt32(Console.ReadLine());
                }
                while (exit == 1);
            }
        }

        // Удаление пользователя из базы данных
        public void DeletedUserById(int id)
        {
            using (var context = new Context())
            {
                var temp = context.Users.FirstOrDefault(p => p.Id == id);

                if (temp != null)
                {
                    context.Users.Remove(temp);
                    context.SaveChanges();
                }
            }
        }
        //Обновление имени пользователя по Id
        public void UpdateUserById(int id, string name)
        {
            using (var context = new Context())
            {
                var temp = context.Users.FirstOrDefault(p => p.Id == id);

                if (temp != null)
                {
                    temp.Name = name;
                    context.SaveChanges();
                }
            }
        }
    }
}
