using EF_FinalyTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FinalyTask.Reposytory
{
    public class BookRepository
    {
        // Выбоз всех книг
        public List<Book> SelectAllBooks() 
        { 
            using(var context = new Context()) 
            { 
                return context.Books.ToList();
            }
        }
        // Выбор книг по ID
        public Book SelectBookById(int id)
        {
            using (var context = new Context())
            {
                var temp = context.Books.FirstOrDefault(p => p.Id == id);
                
                if (temp != null)
                  return temp;

                return null;
            }
        }

        // Добавление книг в базу данных

        public void AddBooks() 
        { 
            using( var context = new Context()) 
            {
                int exit = 1;
                do
                {
                    Console.WriteLine("Введите Название книги");
                    string title = Console.ReadLine();
                    Console.WriteLine("Ввелите год издания книги");  
                    int yearofissue = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите автора книги");
                    string autor = Console.ReadLine();
                    Console.WriteLine("Введите жанр книги");
                    BookGenre bookGenre = (BookGenre)Convert.ToInt32(Console.ReadLine());

                    Book book = new Book() { Title= title, YearOfIssue = yearofissue, Autor=autor, Genre = bookGenre};
                    
                    context.Books.Add(book);
                    context.SaveChanges();

                    Console.WriteLine("Введите 1, чтобы добавить книгу или нажмите 2, чтобы выйти");
                    exit = Convert.ToInt32(Console.ReadLine());
                } 
                while (exit==1);            
            }
        }
        
        // Удаление книги из базы данных
        public void DeletedBookById(int id)
        {
            using (var context = new Context())
            {
                var temp = context.Books.FirstOrDefault(p => p.Id == id);

                if (temp != null) 
                { 
                    context.Books.Remove(temp);
                    context.SaveChanges();
                }
            }
        }
        //Обновление года выпуска книги по Id
        public void UpdateBookById(int id, int yearofissue)
        {
            using (var context = new Context())
            {
                var temp = context.Books.FirstOrDefault(p => p.Id == id);

                if (temp != null)
                {
                    temp.YearOfIssue = yearofissue;
                    context.SaveChanges();
                }
            }
        }

        //Получать список книг определенного жанра и вышедших между определенными годами
        public List<Book> SelectBooksByGenryAndYears(BookGenre bookGenre, int year1, int year2)
        {
            using (var context = new Context())
            {
                return context.Books.Where(p=>p.Genre==bookGenre).Where(p=>p.YearOfIssue>year1).Where(p=>p.YearOfIssue<year2).ToList();
            }
        }

        //Получать количество книг определенного автора в библиотеке
        public int CountBooksByAutor(string autor)
        {
            using (var context = new Context())
            {
                return context.Books.Where(p => p.Autor==autor).Count();
            }
        }

        //Получать количество книг определенного жанра в библиотеке.
        public int CountBooksByGenre(BookGenre bookGenre)
        {
            using (var context = new Context())
            {
                return context.Books.Where(p => p.Genre==bookGenre).Count();
            }
        }

        //Получение последней вышедшей книги

        public Book LastYearBook()
        {
            using (var context = new Context())
            {
                return context.Books.OrderByDescending(p=>p.YearOfIssue).First();
            }
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> OrderByBooks()
        {
            using (var context = new Context())
            {
                return context.Books.OrderBy(p => p.Title).ToList();
            }
        }

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода

        public List<Book> OrderByDesendingBooks()
        {
            using (var context = new Context())
            {
                return context.Books.OrderByDescending(p=>p.YearOfIssue).ToList();
            }
        }
    }
}
